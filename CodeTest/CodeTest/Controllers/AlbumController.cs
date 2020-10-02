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
        //GET Album data
        [HttpGet("/albums")]
        public IEnumerable<AlbumModel> GetAlbums()
        {
            return FileService.GetAlbums();
        }
        //GET Photo data
        [HttpGet("/photos")]
        public IEnumerable<PhotoModel> GetPhotos()
        {
            return FileService.GetPhotos();
        }

        //GET User by Id
        [HttpGet("/1")]
        public IActionResult GetById([FromQuery] int id)
        {
            return Ok(FileService.GetUserById(id));
        }
        //Query albums to that user and photos

        //Reference: https://www.youtube.com/watch?v=oPKq9fNJ6c0&list=PLdo4fOcmZ0oW8nviYduHq7bmKode-p8Wy&index=9
    }
}
