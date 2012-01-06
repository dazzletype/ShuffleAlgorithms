using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShuffleAlgorithms;

namespace ShuffleAlgorithmTests
{
    /// <summary>
    /// Unit Tests for Fisher Yates Algorithms
    /// </summary>
    [TestClass]
    public class FisherYatesTests
    {
        private const int ElementCount = 10000;
        private static int[] fisherYatesShuffleResults;

        /// <summary>
        /// Get the results once to be able to reuse for each test
        /// </summary>
        /// <param name="context"></param>
        [ClassInitialize]
        public static void InitializeResults(TestContext context)
        {
            fisherYatesShuffleResults = Algorithms.FisherYatesShuffle(ElementCount);
        }
        

        /// <summary>
        /// The resulting list should always contain the number 1
        /// </summary>
        [TestMethod]
        public void FisherYatesShouldContainOne()
        {
            Assert.IsTrue(fisherYatesShuffleResults.Contains(1));
        }


        /// <summary>
        /// The list should always contain the very last number
        /// </summary>
        [TestMethod]
        public void FisherYatesShouldContainLastElement()
        {
            Assert.IsTrue(fisherYatesShuffleResults.Contains(ElementCount));
        }


        /// <summary>
        /// The list should always contain a number of elements equivalent to the last number
        /// </summary>
        [TestMethod]
        public void FisherYatesShouldHaveTheCorrectElementCount()
        {
            Assert.IsTrue(fisherYatesShuffleResults.Count() == ElementCount);
        }

        /// <summary>
        /// The list should not contain a value larger than the last number
        /// </summary>
        [TestMethod]
        public void FisherYatesShouldNotExceedUpperBounds()
        {
            Assert.IsFalse(fisherYatesShuffleResults.Contains(ElementCount + 1));
        }


        /// <summary>
        /// A comprehensive test to insure the list includes every unique value from 1..N. 
        /// Test Ignored for now unless unit test performance is secondary to precision
        /// </summary>
        [Ignore]
        public void FisherYatesIncludesEverySingleNumber()
        {
            Assert.IsTrue(TestHelpers.ListContainsAllUniqueElements(fisherYatesShuffleResults));
        }


        [ClassCleanup]
        public static void CleanupResults()
        {
            fisherYatesShuffleResults = null; // handled by .net garbage collection but listed here for completeness
        }


        public TestContext TestContext { get; set; }
    }
}
