using CodeTest.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CodeTest.Services
{
    public class JsonFileService : IJsonFileService
    {
        public JsonFileService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }

        //Grabbing the Album JSON data from the file.
        public string JsonFileNameAlbum
        {
            get { return Path.Combine(WebHostEnvironment.ContentRootPath, "data", "albums.json"); }
        }
        //Grabbing the Photo JSON data from the file.
        private string JsonFileNamePhoto
        {
            get { return Path.Combine(WebHostEnvironment.ContentRootPath, "data", "photos.json"); }
        }
        /// <summary>
        /// Album JSON data (No filter)
        /// </summary>
        /// <returns>Reads through the complete album JSON file, from start ToEnd.</returns>
        public IEnumerable<AlbumModel> GetAlbums()
        {
            using (var jsonFileReader = File.OpenText(JsonFileNameAlbum))
            {
                return JsonSerializer.Deserialize<AlbumModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
        /// <summary>
        /// Album JSON user data (Filter)
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Album Title data only, ordered by UserId.</returns>
        public IEnumerable<string> GetUserById(int userId)
        {
            return GetAlbums().Where(x => x.UserId == userId)
                              .Select(i => i.AlbumTitle);
        }
        /// <summary>
        /// Photo JSON data (No Filters)
        /// </summary>
        /// <returns>Reads through the Photo JSON file, from the start ToEnd.</returns>
        public IEnumerable<PhotoModel> GetPhotos()
        {
            using (var jsonFileReader = File.OpenText(JsonFileNamePhoto))
            {
                return JsonSerializer.Deserialize<PhotoModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        /// <summary>
        /// Photo JSON album data (Filter)
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns>Photo Title data, ordered by AlbumId</returns>
        public IEnumerable<string> GetAlbumPhotosById(int albumId)
        {
            return GetPhotos().Where(x => x.AlbumId == albumId)
                               .Select(i => i.PhotoTitle);
        }

        /// <summary>
        /// Albums and Photos linked to a user id number.
        /// </summary>
        /// <param name="userId">User input id number</param>
        /// <returns>Albums and photos joined together.</returns>
        public string GetAlbumsPhotos(int userId)
        {
            //Types of queries used.
            IEnumerable<int> albumIdQuery = new List<int>();
            IEnumerable<string> albumQuery = new List<string>();
            IEnumerable<string> photoQuery = new List<string>();
            IEnumerable<int> photoIdQuery = new List<int>();
            //photoTitle results.
            var result = new StringBuilder();

            //Gets all albumId s' from elements that userId match the Id inputted.
            albumIdQuery = GetAlbums().Where(x => x.UserId == userId)
                       .Select(i => i.AlbumId);

            //Gets all album Titles from Json album that userId matches the Id inputted.
            albumQuery = GetAlbums().Where(l => l.UserId == userId)
                       .Select(m => m.AlbumTitle);
            //Get all PhotoId's from when AlbumId is the same Id that the user inputted.
            photoIdQuery = GetPhotos().Where(x => x.AlbumId == userId)
                       .Select(i => i.PhotoId);

            //Grabbing the photo titles that match with the photoId in photoIdQuery.
            photoQuery = GetPhotos().Where(l => l.PhotoId.ToString() == photoIdQuery.ToString())
                                    .Select(y => y.PhotoTitle);
            //Matching photoId with the photoTitles
            foreach(var photo in GetPhotos())
            {
                foreach(var photo2 in photoIdQuery)
                {
                    if(photo2.ToString() == photo.PhotoId.ToString())
                    {
                        result.Append(photo.PhotoTitle);
                    }
                }
            }

            //Correct formatting for the output from the method!!!

            //Joining the album and photo queries together.
            string resultString = string.Join(", ", albumQuery);
            string resultPhoto = string.Join(", ", result);
            resultString = resultString + resultPhoto;

            //Output the albumQuery list (Collection of users: Album Titles and Photo Titles).
            return resultString;
        }

        //Reference notes: https://www.stevejgordon.co.uk/introduction-to-benchmarking-csharp-code-with-benchmark-dot-net
    }
}
