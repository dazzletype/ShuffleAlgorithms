using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShuffleAlgorithms;

namespace ShuffleAlgorithmTests
{
    /// <summary>
    /// Unit Tests for the Brute Force shuffle algorithm
    /// </summary>
    [TestClass]
    public class BruteForceTests
    {
        private const int ElementCount = 10000;

        private static int[] bruteForceResults;


        /// <summary>
        /// Get results of the Brute Force algorithm once to run our tests against
        /// </summary>
        /// <param name="context"></param>
        [ClassInitialize]
        public static void InitializeResults(TestContext context)
        {
            bruteForceResults = Algorithms.BruteForceShuffle(ElementCount);
        }


        /// <summary>
        /// The resulting list should always contain the number 1
        /// </summary>
        [TestMethod]
        public void BruteForceShouldHaveOneInList()
        {
            Assert.IsTrue(bruteForceResults.Contains(1));
        }


        /// <summary>
        /// The list should always contain the very last number
        /// </summary>
        [TestMethod]
        public void BruteForceShouldContainLastElement()
        {
            Assert.IsTrue(bruteForceResults.Contains(ElementCount));
        }


        /// <summary>
        /// The list should always contain a number of elements equivalent to the last number
        /// </summary>
        [TestMethod]
        public void BruteForceShouldHaveTheCorrectElementCount()
        {
            Assert.IsTrue(bruteForceResults.Count() == ElementCount);
        }


        /// <summary>
        /// The list should not contain a value larger than the last number
        /// </summary>
        [TestMethod]
        public void BruteForceShouldNotExceedUpperBounds()
        {
            Assert.IsFalse(bruteForceResults.Contains(ElementCount + 1));
        }


        /// <summary>
        /// A comprehensive test to insure the list includes every unique value from 1..N. 
        /// Test Ignored for now unless unit test performance is secondary to precision
        /// </summary>
        [Ignore]
        public void BruteForceIncludesEverySingleNumber()
        {
            Assert.IsTrue(TestHelpers.ListContainsAllUniqueElements(bruteForceResults));
        }



        [ClassCleanup]
        public static void CleanupResults()
        {
            bruteForceResults = null; // handled by .net garbage collection but listed here for completeness
        }



        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
    }
}
