using CollectionManager.Models.dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectionManager.Tests.Controllers
{
    [TestClass]
    public class CollectionTest
    {

        [TestInitialize]
        public void Load_Mocking_List()
        {
            CollectionDTO.Collections = null;
            CollectionDTO.Start(true);
        }

        [ClassInitialize]
        public void startNest()
        {

        }


    }
}
