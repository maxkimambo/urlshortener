using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shorty.Core;
using Shorty.Data;

namespace Shorty.TestsMSUnit
{
    [TestClass]
    public class UrlShortenerTests
    {
        private IShortener shortener; 


        [TestInitialize]
        public void Init()
        {

        }


        [TestMethod]
        public void CanShortenUrl()
        {

            var userUrl = new UserDto()
            {
                Id = 1000,
                OriginalUrl = "http://google.com",
                AccessCount = 0,
                LastAccessedOn = DateTime.Now
            };

            var dbUserUrl = new Shorty.Data.UserUrl()
            {
                Id = 1000,

            };

            var repo = new Mock<IRepository>();
            repo.Setup(r => r.SaveUrl(It.IsAny<UserUrl>()))
                .Returns(() => dbUserUrl); 

            var converter = new BaseConverter();
            shortener = new ShortService(converter, repo.Object);

            var result = shortener.ShortenUrl(userUrl);

            Assert.AreEqual("Ge", result.Url);
        }

     

        [TestMethod]
        public void CanExpandUrl()
        {
              var dbUserUrl = new Shorty.Data.UserUrl()
            {
                Id = 1000,
                OriginalUrl = "http://google.com",
                AccessCount = 0,
            };

            var testUrl = "http://bitly.com/Ge";
            var repo = new Mock<IRepository>();
            repo.Setup(r => r.GetById(It.IsAny<int>())).Returns(() => dbUserUrl);

            var converter = new BaseConverter(); 
            shortener = new ShortService(converter, repo.Object);

            var result = shortener.ExpandUrl(testUrl); 

        }

    }
}
