using CodeTest.Controllers;
using CodeTest.Models;
using CodeTest.Services;
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
    }
}
