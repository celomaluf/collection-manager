using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CollectionManager.Controllers;
using CollectionManager.Models.dto;
using System.Web.Http;
using CollectionManager.Models.entity;
using System.Web.Http.Results;

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
            Assert.IsTrue(((String)contentResult.Content[1]).Contains("inserida"));

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
            IHttpActionResult httpActionResult = cc.Post(input);
            var contentResult = httpActionResult as OkNegotiatedContentResult<Object[]>;

            Assert.IsTrue((Boolean) contentResult.Content[0]);
        }

        [TestMethod]
        public void Test_Delete_Collection()
        {
            CollectionController cc = new CollectionController();
            int cdCollection = 5;
            IHttpActionResult httpActionResult = cc.Delete(cdCollection);
            var contentResult = httpActionResult as OkNegotiatedContentResult<Object[]>;
            Assert.IsTrue((Boolean)contentResult.Content[0]);

            foreach (Collection c in CollectionDTO.Collections)
            {
                Assert.AreNotSame(cdCollection, c.CdCollection);
            }
        }



        [TestMethod]
        public void Test_Delete_An_Unexisting_Collection()
        {
            CollectionController cc = new CollectionController();
            int cdCollection = 10;
            IHttpActionResult httpActionResult = cc.Delete(cdCollection);
            var contentResult = httpActionResult as OkNegotiatedContentResult<Object[]>;
            Assert.IsFalse((Boolean)contentResult.Content[0]);

            foreach (Collection c in CollectionDTO.Collections)
            {
                Assert.AreNotSame(cdCollection, c.CdCollection);
            }
        }
    }
}
