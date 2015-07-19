using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shorty.Data;

namespace Shorty.TestsMSUnit.IntegrationTests
{
    [TestClass]
    public class RepositoryTests
    {

        private IRepository repository;
        private Context context; 
        [TestInitialize]
        public void Init()
        {

            context = new Context();
            repository = new Repository(context);   
        }
        
        [TestMethod]
        public void CanInsertARecord()
        {
           var result = repository.SaveUrl(new UserUrl
            {
                Url = "http://google.com",
                OriginalUrl = "http://google.com",
                AccessCount = 0,
                CreatedOn = DateTime.Now,
                ExpiresOn = DateTime.Now.AddMonths(1),
                UserId = "Max"

            }); 


            Assert.IsTrue(result.Id != 0);
        }

        [TestMethod]
        public void CanFetchAnItem()
        {

            var result = repository.GetAll().FirstOrDefault(); 

            Assert.IsNotNull(result);
        }

       
    }
}
