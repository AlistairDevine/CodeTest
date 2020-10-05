using CodeTest.Controllers;
using CodeTest.Models;
using CodeTest.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.CompilerServices;
using Xunit.Sdk;

namespace WebApiTest
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }

        [TestMethod]
        public void GetAlbums_ReturnAllAlbums()
        {
            //Set up
            var JsonFileService = new JsonFileService(WebHostEnvironment);
            AlbumController albumController = new AlbumController(JsonFileService);
            //Action
            var albums = albumController.GetAlbums();
            //Assertion
            Assert.IsNotNull(albums);
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
