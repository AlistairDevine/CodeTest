using CodeTest.Controllers;
using CodeTest.Models;
using CodeTest.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Xunit;

namespace ApiTesting
{
    public class AlbumApiTests
    {
        private readonly AlbumController _albumController;
        public AlbumApiTests()
        {
            var albumMock = new Mock<IJsonFileService>();
            albumMock.Setup(p => p.GetAlbums())
                .Returns(new List<AlbumModel>
                {
                    new AlbumModel
                    {
                        AlbumId = 1,
                        UserId = 1,
                        AlbumTitle = "MockAlbumTitle"
                    }
                });
            _albumController = new AlbumController(albumMock.Object);
        }
        //Place within a method.
        [Fact]
        public void GetAllAlbums_ReturnNotBeNull()
        {
            //Assert
            Assert.True(_albumController.GetAlbumsController() != null);
        }
        [Fact]
        public void GetAllAlbumsItem_ReturnNumberOfItemsGathered()
        {
            //Action
            var okResult = _albumController.GetAlbumsController().Result as OkObjectResult;
            //Assert
            var items = Assert.IsType<List<AlbumModel>>(okResult.Value);
            Assert.Equal(1, items.Count);
        }
        [Fact]
        public void GetAllAlbumsType_ReturnOkStatusCodeType()
        {
            //StatusCode test
            Assert.IsType<OkObjectResult>(_albumController.GetAlbumsController().Result);
        }
        //Place within a different method.
        //GetById
        [Fact]
        public void GetAlbumById_ReturnRightItem()
        {
            //Arrange
            //(TestingCoding)var testId = new AlbumModel().AlbumId = 1;
            int expected = 1;
            int Id = 1;
            
            //Action
            //var okResult = _albumController.GetAlbumById(testById.UserId).Result as OkObjectResult;
            var Result = _albumController.GetAlbumById(Id);
            
            //Assert
            //Assert.IsType<string[]>(okResult.Value);
            Assert.Equal(expected, (Result.Value as AlbumModel).AlbumId);
        }

    }
}
