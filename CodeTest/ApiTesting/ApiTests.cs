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
    public class ApiTests
    {
        //Reference: https://dev.to/masanori_msl/asp-net-core-xunit-moq-add-unit-tests-1-26c8

        /*Support references: 
         * testing environment code https://raaaimund.github.io/tech/2019/05/08/aspnet-core-integration-testing/
         * Assert examples http://dontcodetired.com/blog
         * msDocs https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices
         * typeof  https://stackoverflow.com/questions/22362634/correct-way-to-unit-test-the-type-of-an-object 
         * Assert structure https://code-maze.com/unit-testing-aspnetcore-web-api/
         *      https://docs.microsoft.com/en-us/aspnet/web-api/overview/testing-and-debugging/unit-testing-controllers-in-web-api
        */

        private readonly AlbumController _albumController;
        public ApiTests()
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

        [Fact]
        public void GetAllAlbums_ShouldNotBeNull()
        {
            //Setup

            //Action

            //Assert
            Assert.True(_albumController.GetAlbumsController() != null);
        }
        [Fact]
        public void GetAllAblums()
        {
            //Action
            var page = _albumController.GetAlbumsController();
            var viewResult = Assert.IsType<ViewResult>(page);
            //Assert
            Assert.Equal("1", viewResult.ViewData["AlbumId"].ToString());
        }
        [Fact]
        public void GetAllAlbumsItem_Should()
        {
            //Action
            var okResult = _albumController.GetAlbumsController().Result as OkObjectResult;
            //Assert
            var items = Assert.IsType<List<AlbumModel>>(okResult.Value);
            Assert.Equal(1, items.Count);
        }
        [Fact]
        public void GetAllAlbumsType_Should()
        {
            //StatusCode test
            Assert.IsType<OkObjectResult>(_albumController.GetAlbumsController().GetType());
        }
    }
}
