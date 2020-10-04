using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTest.Models;
using CodeTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        public AlbumController(JsonFileService fileService)
        {
            this.FileService = fileService;
        }
        public JsonFileService FileService { get; }

        List<AlbumModel> albums = new List<AlbumModel>();

        //GET Album data
        [HttpGet("/album")]
        public IEnumerable<AlbumModel> GetAlbums()
        {
            return FileService.GetAlbums();
        }
        //GET Photo data
        [HttpGet("/photo")]
        public IEnumerable<PhotoModel> GetPhotos()
        {
            return FileService.GetPhotos();
        }
        //GET User by Id
        [HttpGet("{id}")]
        public IEnumerable<string> GetById(int Id)
        {
            return FileService.GetUserById(Id);
        }
        //Query albums to that user and photos
        [HttpGet("/info/{id}")]
        public IEnumerable<string> GetAlbumsPhotos(int Id)
        {
            return FileService.GetAlbumsPhotos(Id);
        }
    }
}
