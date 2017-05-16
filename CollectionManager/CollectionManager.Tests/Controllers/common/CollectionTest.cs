using CollectionManager.Models.dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManager.Tests.Controllers
{
    [TestClass]
    public class CollectionTest
    {
        [TestInitialize]
        public void Load_Mocking_List()
        {
            CollectionDTO.Collections = null;
            CollectionDTO.TestingPurpose = true;
            CollectionDTO.Start();
        }
    }
}
