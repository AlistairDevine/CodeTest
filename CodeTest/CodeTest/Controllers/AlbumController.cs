using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        //GET Album data
        //Route, /ablum
        [HttpGet("/album")]
        public IEnumerable<AlbumModel> GetAlbumsController()
        {
            return FileService.GetAlbums();
        }
        //GET Photo data
        //Route, /photo
        [HttpGet("/photo")]
        public IEnumerable<PhotoModel> GetPhotos()
        {
            return FileService.GetPhotos();
        }
        //GET User by Id
        //Route, album/Id e.g. album/1
        [HttpGet("{id}")]
        public IEnumerable<string> GetById(int Id)
        {
            return FileService.GetUserById(Id);
        }
        //Get Album by Id
        //Route, /photo/Id e.g. /photo/5
        [HttpGet("/photo/{id}")]
        public IEnumerable<string>GetAlbumById(int Id)
        {
            return FileService.GetAlbumPhotosById(Id);
        }
        
        //GET user albums and photos
        //Route, /info/Id e.g. /info/2
        [HttpGet("/info/{id}")]
        public IEnumerable<string> GetAlbumsPhotos(int Id)
        {
            return FileService.GetAlbumsPhotos(Id);
        }
    }
}
