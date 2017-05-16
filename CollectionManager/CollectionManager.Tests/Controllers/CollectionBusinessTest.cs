using CollectionManager.Controllers;
using CollectionManager.Models.dto;
using CollectionManager.Models.entity;
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


        [TestMethod]
        public void Test_Insert_Same_Collection_Available()
        {
            CollectionController cc = new CollectionController();
            Collection input = new Collection
            {
                Description = "A",
                Type = "Livro",
                Location = "UFSC",
                Available = false,
                User = new User {
                    Name = "Marcelo",
                    Contact = "(48) 98434-2715"
                }
            };
            IHttpActionResult httpActionResult = cc.Post(input);
            var contentResult = httpActionResult as OkNegotiatedContentResult<Object[]>;

            Assert.IsFalse((bool)contentResult.Content[0]);
        }

        [TestMethod]
        public void Test_Update_Same_Collection()
        {
            CollectionController cc = new CollectionController();
            Collection input = new Collection
            {
                CdCollection = 1,
                Description = "A",
                Type = "Livro",
                Location = "UFSC",
                Available = false,
                User = new User
                {
                    Name = "ATUALIZADO",
                    Contact = "ATUALIZADO"
                }
            };
            IHttpActionResult httpActionResult = cc.Post(input);
            var contentResult = httpActionResult as OkNegotiatedContentResult<Object[]>;

            Assert.IsTrue((bool)contentResult.Content[0]);

        }
    }
}
