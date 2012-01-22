using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShuffleAlgorithms;

namespace ShuffleAlgorithmTests
{
    /// <summary>
    /// Unit Tests for Fisher Yates Algorithms
    /// </summary>
    [TestClass]
    public class AlgorithmTests
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
        public void ShuffledListContainsNumberOne()
        {
            Assert.IsTrue(fisherYatesShuffleResults.Contains(1));
        }


        /// <summary>
        /// The list should always contain the very last number
        /// </summary>
        [TestMethod]
        public void ShuffledListContainsLastElement()
        {
            Assert.IsTrue(fisherYatesShuffleResults.Contains(ElementCount));
        }


        /// <summary>
        /// The list should always contain a number of elements equivalent to the last number
        /// </summary>
        [TestMethod]
        public void ShuffledListHasCorrectElementCount()
        {
            Assert.IsTrue(fisherYatesShuffleResults.Count() == ElementCount);
        }

        /// <summary>
        /// The list should not contain a value larger than the last number
        /// </summary>
        [TestMethod]
        public void ShuffledListShouldNotExceedUpperBounds()
        {
            Assert.IsFalse(fisherYatesShuffleResults.Contains(ElementCount + 1));
        }


        /// <summary>
        /// A comprehensive test to insure the list includes every unique value from 1..N. 
        /// </summary>
        [TestMethod]
        public void ShuffledListIncludesEverySingleNumber()
        {
            Assert.IsTrue(TestHelpers.ListContainsAllUniqueElements(fisherYatesShuffleResults));
        }


        /// <summary>
        /// Tests to ensure a truly random set of results are produced. 
        /// In a set of 3 shuffled numbers (1, 2, 3), the 2 should statistically be shuffled to position 1 nearly 33.3% of the time given enough runs
        /// </summary>
        [TestMethod]
        public void ResultsAreTrulyRandom()
        {
            const int algorithmRunCount = 1000000;
            const int elementSize = 3;
            List<int[]> resultsList = new List<int[]>();

            // frequency the number '2' being in position one should be very close to 33.3% given enough runs
            const decimal randomLowerThresholdPercent = 33.1M;
            const decimal randomUpperThresholdPercent = 33.5M;
            decimal actualOccurance = 0;
            decimal occurancePercent;
            
            for (int i = 0; i < algorithmRunCount; i++)
            {
                int[] results = Algorithms.FisherYatesShuffle(elementSize);
                resultsList.Add(results);
            }

            foreach (var intse in resultsList)
            {
                if (intse[0] == 2)
                    actualOccurance++;
            }

            occurancePercent = (actualOccurance / algorithmRunCount) * 100;

            Assert.IsTrue(occurancePercent > randomLowerThresholdPercent && occurancePercent < randomUpperThresholdPercent);

        }


        [ClassCleanup]
        public static void CleanupResults()
        {
            fisherYatesShuffleResults = null; // handled by .net garbage collection but listed here for completeness
        }


        public TestContext TestContext { get; set; }
    }
}
