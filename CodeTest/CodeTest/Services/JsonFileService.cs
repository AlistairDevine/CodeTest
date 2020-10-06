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
    public class JsonFileService
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

        //Concatination process???
        //.ToString method required???

        //All Data (Album & Photo)
        public IEnumerable<string> GetAlbumsPhotos(int userId)
        {
            //Single string with separators for individual element for the single

            IEnumerable<int> albumIdQuery = new List<int>();
            IEnumerable<string> albumQuery = new List<string>(); 
            IEnumerable<string> photoQuery = new List<string>();
            IEnumerable<int> photoIdQuery = new List<int>();

            var result = new StringBuilder();
            List<int> results = new List<int>();

            //Gets all albumId s' from elements that userId match the Id inputted.
            albumIdQuery = GetAlbums().Where(x => x.UserId == userId)
                       .Select(i => i.AlbumId);
            //Gets all album Titles from Json album that userId matches the Id inputted.
            albumQuery = GetAlbums().Where(l => l.UserId == userId)
                       .Select(m => m.AlbumTitle);
            //each albumId collected from Album JSON, 
            //photoQuery collects Photo Titles that hold AblumId (Photo JSON file) matches the AlbumId from the Album JSON file.
            //Adds all of the Photo Titles into the end of albumQuery List of strings.
            photoIdQuery = GetPhotos().Select(y => y.AlbumId);

            foreach(var album in albumIdQuery)
            {
                foreach(var photo in photoIdQuery)
                {
                    if(photoIdQuery.Contains(album))
                    {
                        result.Append(photo);
                    }
                }
            }
            //If no intersection between the two JSON file is found.
            if (result == null)
            {
                return null;
            }

            //photoQuery
            photoQuery = GetPhotos().Where(y => y.AlbumId.ToString() == result.ToString())
                                    .Select(y => y.PhotoTitle);

            albumQuery.ToList().AddRange(photoQuery);

            //Output the albumQuery list (Collection of users: Album Titles and Photo Titles).
            return albumQuery;
            
        }
    }
}
