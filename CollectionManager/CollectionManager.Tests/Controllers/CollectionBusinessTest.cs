using CollectionManager.Controllers;
using CollectionManager.Models.entity;
using CollectionManager.Tests.Controllers.commom;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Http;
using System.Web.Http.Results;

namespace CollectionManager.Tests.Controllers
{
    // RN001
    // Only one collection may have the combination of the fields 'Type', 'Description' and 'Location',  
    // if another one with the same values is inserted or updated. The app should not allowed it.
    [TestClass]
    public class CollectionBusinessTest : CollectionTest
    {
        private static int Sleep_Seconds = 1000;

        [TestMethod]
        public void Test_Insert_Same_Collection_Available()
        {
            CollectionController cc = new CollectionController();
            Collection input = new Collection
            {
                Description = "TestInsertSameCollectionAvailable",
                Type = "Livro",
                Location = "UFSC",
                Available = false               
            };
            cc.Post(input);

            Collection sameInput = new Collection
            {
                Description = "TestInsertSameCollectionAvailable",
                Type = "Livro",
                Location = "UFSC",
                Available = false
            };
            System.Threading.Thread.Sleep(Sleep_Seconds);
            input.CdCollection = 0;
            IHttpActionResult httpActionResult = cc.Post(sameInput);
            var contentResult = httpActionResult as OkNegotiatedContentResult<Object[]>;
            Assert.IsFalse((bool)contentResult.Content[0]);
        }

        [TestMethod]
        public void Test_Update_Same_Collection()
        {
            CollectionController cc = new CollectionController();
            Collection input = new Collection
            {
                Description = "CCC",
                Type = "Livro",
                Location = "ZZZ",
                Available = false
               
            };
            cc.Post(input);
            input.User.Name = "ATUALIZADO";
            input.User.Contact = "ATUALIZADO";
            System.Threading.Thread.Sleep(Sleep_Seconds);
            IHttpActionResult httpActionResult = cc.Put(input);
            var contentResult = httpActionResult as OkNegotiatedContentResult<Object[]>;
            Assert.IsTrue((bool)contentResult.Content[0]);
        }

        [TestMethod]
        public void Test_Update_Different_Collection()
        {
            CollectionController cc = new CollectionController();
            Collection input = new Collection
            {
                Description = "AAA",
                Type = "Livro",
                Location = "TTT",
                Available = true
            };
            cc.Post(input);
            Collection input2 = new Collection
            {
                Description = "AAA",
                Type = "Livro",
                Location = "LLL", //different
                Available = true
            };
            cc.Post(input2);

            System.Threading.Thread.Sleep(Sleep_Seconds);

            input2.Location = input.Location;
            IHttpActionResult httpActionResult = cc.Put(input2);
            var contentResult = httpActionResult as OkNegotiatedContentResult<Object[]>;
            Assert.IsFalse((bool)contentResult.Content[0]);

        }
    }
}
