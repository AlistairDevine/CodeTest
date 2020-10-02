using CodeTest.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        private string JsonFileNameAlbum
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
        public void GetUserById(int userId)
        {
            var users = GetAlbums();

            var query = users
                        .Where(x => x.UserId == userId)
                        .Select(i => i.AlbumId);

            if(query.UserId == null)
            {
                //No matches of any albums owned by that user.
            }
            else
            {
                var userAlbums = query.AlbumTitle.ToList();
                //If album title then grab photos from json of that album

            }
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

        //All Data (Album & Photo)
        //Concatination process???
    }
}
