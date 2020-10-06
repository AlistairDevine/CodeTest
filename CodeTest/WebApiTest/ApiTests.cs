using CodeTest;
using CodeTest.Controllers;
using CodeTest.Models;
using CodeTest.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        private readonly HttpClient _httpClient;

        public ApiTests(IWebHostEnvironment webHostEnvironment) 
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _httpClient = server.CreateClient();

                WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }

        [Theory]
        [InlineData("GET")]
        public void GetAlbums_ReturnAllAlbums(string method)
        {
            //Set up
            var request = new HttpRequestMessage(new HttpMethod(method), "/album");
            var testJson = new JsonFileService(WebHostEnvironment);
            var testAlbum = testJson.GetAlbums();
            //Action
            var reposnse = _httpClient.SendAsync(request);
            //Assertion
            
            Assert.AreEqual(testAlbum, reposnse);
        }
        [TestMethod]
        public void GetPhotos_ReturnAllPhotos()
        {
        }
        [TestMethod]
        public void GetById_ReturnAllAlbumByUserId()
        {
        }
        [TestMethod]
        public void GetAlbumsPhotos_ReturnAllAlbumsPhotosByUserId()
        {
        }
    }
}
