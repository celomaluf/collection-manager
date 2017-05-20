using Microsoft.VisualStudio.TestTools.UnitTesting;
using CollectionManager.ElasticSearch;

namespace CollectionManager.Tests.Controllers.common
{
    [TestClass]
    public class CollectionAssemblyInitializeTest
    {
        //Set the Elastic Search to use index 'cm-test-index'
        [AssemblyInitialize]
        public static void PreparaeEach_Test(TestContext context)
        {
            ESConnection.UnitTest = true;
        }
    }
}
