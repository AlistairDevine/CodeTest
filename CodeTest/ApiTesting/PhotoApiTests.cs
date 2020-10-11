using CodeTest.Controllers;
using CodeTest.Models;
using CodeTest.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ApiTesting
{
    public class PhotoApiTests
    {
        private readonly AlbumController _photoController;
        public PhotoApiTests()
        {
            var albumMock = new Mock<IJsonFileService>();
            albumMock.Setup(p => p.GetPhotos())
                .Returns(new List<PhotoModel>
                {
                    new PhotoModel
                    {
                        PhotoId = 2,
                        AlbumId = 1,
                        PhotoTitle = "MockPhotoTitle",
                        Url = "MockTest.com",
                        ThumbnailUrl = "MockThumbnail.com"
                    }
                });
            _photoController = new AlbumController (albumMock.Object);
        }
        [Fact]
        public void GetAllPhoto_ReturnNotBeNull()
        {
            //Assert
            Assert.True(_photoController.GetPhotos() != null);
        }
        [Fact]
        public void GetAllPhotos()
        {
            //Arrange
            //Action
            //Assert
        }
        [Fact]
        public void GetAllPhotoItems_ReturnNumberOfItems()
        {
            //Action
            var okResult = _photoController.GetPhotos().Result as OkObjectResult;
            //Assert
            var items = Assert.IsType<List<PhotoModel>>(okResult.Value);
            Assert.Equal(1, items.Count);
        }
        [Fact]
        public void GetAllPhotosType_ReturnOkStatusCodeType()
        {
            //Assert
            Assert.IsType<OkObjectResult>(_photoController.GetPhotos().Result);
        }
        [Fact]
        public void GetPhotoById_ReturnRightItem()
        {
            //Arrange
            //Action
            //Assert
        }
    }
}
