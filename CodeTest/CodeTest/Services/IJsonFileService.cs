using CodeTest.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

namespace CodeTest.Services
{
    public interface IJsonFileService
    {
        string JsonFileNameAlbum { get; }
        IWebHostEnvironment WebHostEnvironment { get; }

        IEnumerable<string> GetAlbumPhotosById(int albumId);
        IEnumerable<AlbumModel> GetAlbums();
        IEnumerable<string> GetAlbumsPhotos(int userId);
        IEnumerable<PhotoModel> GetPhotos();
        IEnumerable<string> GetUserById(int userId);
    }
}