﻿using CodeTest.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeTest.Services
{
    public interface IJsonFileService
    {
        string JsonFileNameAlbum { get; }
        IWebHostEnvironment WebHostEnvironment { get; }

        IEnumerable<string> GetAlbumPhotosById(int albumId);
        IEnumerable<AlbumModel> GetAlbums();
        string GetAlbumsPhotos(int userId);
        IEnumerable<PhotoModel> GetPhotos();
        IEnumerable<string> GetUserById(int userId);
        Task<AlbumModel[]> GetAlbumsUrl();
        Task<PhotoModel[]> GetPhotosUrl();
    }
}