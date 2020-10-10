using CodeTest;
using CodeTest.Controllers;
using CodeTest.Models;
using CodeTest.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Xunit;
using Xunit.Sdk;

namespace WebApiTest
{
    [TestClass]
    public class ApiTests
    {
        AlbumController _controller;
        IJsonFileService _service;
        IWebHostEnvironment _webHostEnvironment;

        private readonly HttpClient _httpClient;
        
        public ApiTests() 
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());

            _httpClient = server.CreateClient();
            _service = new JsonFileService(_webHostEnvironment);
            _controller = new AlbumController(_service);

        }

        //[TestMethod]
        [Fact]
        public void GetAlbums_ReturnAllAlbums(string method)
        {
            //Set up
            var request = new HttpRequestMessage(new HttpMethod(method), "/album");
            var testJson = new JsonFileService(_webHostEnvironment);
            var testAlbum = testJson.GetAlbums();
            //Action
            var reposnse = _httpClient.SendAsync(request);
            var okResult = _controller.GetAlbumsController().Result as OkObjectResult;
            var obj = new AlbumModel();
            //Assertion
            Assert.IsInstanceOfType(obj, typeof(AlbumModel));
        }


        [TestMethod]
        public void GetPhotos_ReturnAllPhotos()
        {
        }
        [TestMethod]
        public void GetById_ReturnAllAlbumByUserId()
        {
            //Setup
            //Act
            
            //Assertion

        }
        [TestMethod]
        public void GetAlbumsPhotos_ReturnAllAlbumsPhotosByUserId()
        {
        }
    }
}
