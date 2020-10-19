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
        private readonly IJsonFileService _fileService;
        public AlbumController(IJsonFileService fileService)
        {
            _fileService = fileService;
        }

        //GET Album data
        //Route, /ablum
        [HttpGet("/album")]
        public ActionResult<IEnumerable<AlbumModel>> GetAlbumsController()
        {
            return Ok(_fileService.GetAlbums());
        }
        //GET Photo data
        //Route, /photo
        [HttpGet("/photo")]
        public ActionResult<IEnumerable<PhotoModel>> GetPhotos()
        {
            return Ok(_fileService.GetPhotos());
        }
        //GET User by Id
        //Route, album/Id e.g. album/1
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> GetAlbumById(int Id)
        {
            return Ok(_fileService.GetUserById(Id));
        }
        //Get Album by Id
        //Route, /photo/Id e.g. /photo/5
        [HttpGet("/photo/{id}")]
        public ActionResult<IEnumerable<string>> GetPhotosById(int Id)
        {
            return Ok(_fileService.GetAlbumPhotosById(Id));
        }
        
        //GET user albums and photos
        //Route, /info/Id e.g. /info/2
        [HttpGet("/info/{id}")]
        public ActionResult<string> GetAlbumsPhotos(int Id)
        {
            return Ok(_fileService.GetAlbumsPhotos(Id));
        }
    }
}
