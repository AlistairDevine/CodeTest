using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace ApiTesting
{
    [Parallelizable(ParallelScope.Self)]
    public class AlbumIntegration : PlaywrightTest
    {
        //Install playwright cli
        //npx playwright-cli codegen --target=csharp

        [Test]
        public async Task VerifyAlbumsRoute()
        {
            await using var browser = await Playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            });
            var context = await browser.NewContextAsync();

            //Open new page
            var page = await context.NewPageAsync();

            //Go to https://localhost:44344/album
            await page.GotoAsync("https://localhost:44344/album");

            Assert.AreEqual("https://localhost:44344/album", page.Url);
        }

        [Test]
        public async Task VerifyPhotosRoute()
        {
            await using var browser = await Playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            });
            var context = await browser.NewContextAsync();

            //Open new page
            var page = await context.NewPageAsync();

            //Go to https://localhost:44344/album/1
            await page.GotoAsync("https://localhost:44344/album/1");



            Assert.AreEqual("https://localhost:44344/album/1", page.Url);
        }
    }
}
