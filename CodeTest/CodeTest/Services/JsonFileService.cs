using CodeTest.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.ContentRootPath, "data", "albums.json"); }
        }
        /// <summary>
        /// Album JSON data (No filter)
        /// </summary>
        /// <returns>Reads through the complete album JSON file, from start ToEnd.</returns>
        public IEnumerable<AlbumModel> GetAlbums()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<AlbumModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        //Album JSON user data (Filter)

        //Photo JSON data (No Filters)

        //All Data (Album & Photo)

    }
}
