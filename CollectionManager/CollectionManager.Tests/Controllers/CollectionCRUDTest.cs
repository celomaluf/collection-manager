using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CollectionManager.Controllers;
using System.Web.Http;
using CollectionManager.Models.entity;
using System.Web.Http.Results;
using CollectionManager.Models;
using CollectionManager.Tests.Controllers.commom;

namespace CollectionManager.Tests.Controllers
{
    [TestClass]
    public class CollectionCRUDTest : CollectionTest
    {
        [TestMethod]
        public void Test_Insert_Collection_Available()
        {
            CollectionController cc = new CollectionController();
            Collection input = new Collection
            {
                Description = "TestInsertCollectionAvailable",
                Type = "Livro",
                Location = "UFSC",
                Available = false
            };
            IHttpActionResult httpActionResult = cc.Post(input);
            var contentResult = httpActionResult as OkNegotiatedContentResult<Object[]>;
            Assert.IsTrue((Boolean)contentResult.Content[0]);

        }

        [TestMethod]
        public void Test_Update_Collection()
        {
            CollectionController cc = new CollectionController();
            Collection input = new Collection
            {
                CdCollection = 5,
                Description = "Metallica",
                Type = "CD",
                Location = "Praia da Joaquina",
                Available = false,
                User = new User { Name = "Rosângela", Contact = "(48) 985432-2115" }
            };
            IHttpActionResult httpActionResult = cc.Put(input);
            var contentResult = httpActionResult as OkNegotiatedContentResult<Object[]>;

            Assert.IsTrue((Boolean)contentResult.Content[0]);
        }

        [TestMethod]
        public void Test_Delete_Collection()
        {
            CollectionController cc = new CollectionController();
            Collection input = new Collection
            {
                Description = "Test_Delete_Collection",
                Type = "Livro",
                Location = "FGV",
                Available = false
            };
            cc.Post(input);

            int cdCollection = CollectionService.CdCollection;
            IHttpActionResult httpActionResult = cc.Delete(cdCollection);
            var contentResult = httpActionResult as OkNegotiatedContentResult<Object[]>;
            Assert.IsTrue((Boolean)contentResult.Content[0]);

            CollectionService service = new CollectionService();
            service.FindAllCollections().ForEach(
                c => Assert.AreNotSame(cdCollection, c.CdCollection)
            );
        }

        [TestMethod]
        public void Test_Delete_An_Unexisting_Collection()
        {
            CollectionController cc = new CollectionController();
            int cdCollection = 100;
            IHttpActionResult httpActionResult = cc.Delete(cdCollection);
            var contentResult = httpActionResult as OkNegotiatedContentResult<Object[]>;
            Assert.IsFalse((Boolean)contentResult.Content[0]);
        }
    }
}
