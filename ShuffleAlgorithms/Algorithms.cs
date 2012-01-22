using System;
using System.Collections.Generic;
using System.Linq;

namespace ShuffleAlgorithms
{
    /// <summary>
    /// A collection of algorithms to shuffle a list of elements
    /// </summary>
    public static class Algorithms
    {
        private static readonly Random randomGenerator = new Random();

        /// <summary>
        /// Fisher-Yates shuffle algorithm. A fast and memory efficient algorithm.
        /// http://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle#The_modern_algorithm
        /// </summary>
        /// <param name="elementCount">Number of items in shuffled list</param>
        /// <returns>A shuffled list with unique items</returns>
        public static int[] FisherYatesShuffle(int elementCount)
        {
            Random random = randomGenerator;
            int[] orderedList = Utils.CreateSequentialArray(elementCount);

            for (int i = orderedList.Length; i > 1; i--)
            {
                // Pick random element to swap.
                int randomSwapElement = random.Next(i);
                Utils.Swap(orderedList, randomSwapElement, i - 1);
            }

            return orderedList;
        }


        /// <summary>
        /// Shuffle List. A fast algorithm but at the expense of large memory usage.
        /// Inserts a random element into an empty list, and removes that element from the initial collection so that it's not used again.
        /// </summary>
        /// <param name="elementCount">Number of items in shuffled list</param>
        /// <returns>A shuffled list with unique items</returns>
        public static int[] ShuffleList(int elementCount)
        {
            var randomList = new List<int>(elementCount);
            List<int> orderedList = Utils.CreateSequentialArray(elementCount).ToList();


            var random = new Random();
            int randomIndex;
            while (orderedList.Count > 0)
            {
                randomIndex = random.Next(0, orderedList.Count); //Choose a random object in the list
                randomList.Add(orderedList[randomIndex]); //add it to the new list to a random position
                orderedList.RemoveAt(randomIndex); //remove from collection so it's not used again
            }

            return randomList.ToArray(); //return the new random list
        }


        /// <summary>
        /// Brute force shuffle. A very inefficient algorithm.
        /// Appends a random element to the list sequentially. If the element is already in the list,  a new random value is generated and is retested for uniqueness.
        /// <param name="elementCount">Number of items in shuffled list</param>
        /// </summary>
        /// <returns>A shuffled list with unique items</returns>
        public static int[] BruteForceShuffle(int elementCount)
        {
            var shuffledList = new int[elementCount];

            var random = new Random();
            int randomValue;

            for (int i = 1; i < elementCount; i++)
            {
                randomValue = random.Next(1, elementCount + 1);

                // find a random number that hasn't been used yet
                while (shuffledList.Contains(randomValue))
                    randomValue = random.Next(1, elementCount + 1);

                shuffledList[i] = randomValue;
            }


            return shuffledList;
        }
    }
}