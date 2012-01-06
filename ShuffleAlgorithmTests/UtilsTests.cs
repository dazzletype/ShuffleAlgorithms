using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShuffleAlgorithms;

namespace ShuffleAlgorithmTests
{
    /// <summary>
    /// Unit Tests for utilities class
    /// </summary>
    [TestClass]
    public class UtilsTests
    {
        private const int ElementCount = 10000;
        private static int[] orderedList;

        [ClassInitialize]
        public static void InitializeResults(TestContext context)
        {
            orderedList = Utils.CreateSequentialArray(ElementCount);
        }
        

        [TestMethod]
        public void CreateSequentialArrayShouldContainCorrectNumberOfElements()
        {
            Assert.IsTrue(orderedList.Contains(ElementCount));
        }


        [TestMethod]
        public void CreateSequentialArrayShouldContainCorrectFirstElement()
        {
            Assert.IsTrue(orderedList[0] == 1);
        }


        [TestMethod]
        public void CreateSequentialArrayShouldContainCorrectLastElement()
        {
            Assert.IsTrue(orderedList[ElementCount - 1] == ElementCount);
        }
        
        public TestContext TestContext { get; set; }
    }
}
