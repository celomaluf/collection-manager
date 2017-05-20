using CollectionManager.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectionManager.Tests.Controllers.commom
{
    [TestClass]
    public class CollectionTest
    {
        private CollectionService service = new CollectionService();


        [TestInitialize]
        public void Prepare_Each_Test()
        {
            DeleteAllCollectionsElasticSearch();
        }

        //[TestCleanup]
        //public void End_Each_Test()
        //{
        //    DeleteAllCollectionsElasticSearch();
        //}

        // Delete all data after ending a test
        protected void DeleteAllCollectionsElasticSearch()
        {
            service.FindAllCollections().ForEach(
                c => service.DeleteCollection(c.CdCollection));
            CollectionService.reset();
        }

        //insert the mockinglist into the Elasticsearch
        //protected void LoadMockingList()
        //{
        //    List<Collection> collections = RetrieveMockingList();
        //    collections.ForEach(
        //        c => service.InsertCollection(c));
        //}

        ////This is a starting List of Collection
        //private List<Collection> RetrieveMockingList()
        //{

        //    List<Collection> collections = new List<Collection>();
        //    //1
        //    collections.Add(new Collection {
        //        Description = "A",
        //        Type = "Livro",
        //        Location = "UFSC",
        //        Available = false, User = new User {
        //            Name = "Marcelo",
        //            Contact = "(48) 98434-2715"
        //        }});
        //    //2
        //    collections.Add(new Collection {
        //        Description = "B",
        //        Type = "Livro",
        //        Location = "UDESC",
        //        Available = true
        //    });
        //    //3
        //    collections.Add(new Collection {
        //        Description = "Metallica",
        //        Type = "CD",
        //        Location = "Flamengo", 
        //        Available = false, User = new User {
        //            Name = "Thiago",
        //            Contact = "(48) 98543-2112"
        //    }});
        //    //4
        //    collections.Add(new Collection {
        //        Description = "The Offspring",
        //        Type = "CD",
        //        Location = "Santa Tereza",
        //        Available = true
        //    });
        //    //5
        //    collections.Add(new Collection {
        //        Description = "Inside Out",
        //        Type = "DVD",
        //        Location = "Centro - RJ",
        //        Available = true
        //    });
        //    //6
        //    collections.Add(new Collection
        //    {
        //        Description = "Avangers",
        //        Type = "DVD",
        //        Location = "Córrego Grande",
        //        Available = false,
        //        User = new User
        //        {
        //            Name = "Karine",
        //            Contact = "(48) 98222-2123"
        //        }
        //    });
        //    return collections;
        //}
    }
}
