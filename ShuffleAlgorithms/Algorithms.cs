using System;
using System.Collections.Generic;
using System.Linq;

namespace ShuffleAlgorithms
{
    /// <summary>
    /// A set of algorithms to randome shuffle a list of elements
    /// </summary>
    public static class Algorithms
    {
        static Random _random = new Random();

        /// <summary>
        /// Fisher-Yates shuffle algorithm. A fast and memory efficient algorithm.
        /// http://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle#The_modern_algorithm
        /// </summary>
        /// <param name="elementCount">Number of items in shuffled list</param>
        /// <returns>A shuffled list with unique items</returns>
        public static int[] FisherYatesShuffle(int elementCount)
        {
            var random = _random;
            int[] orderedList = Utils.CreateSequentialArray(elementCount);

            for (int i = orderedList.Length; i > 1; i--)
            {
                // Pick random element to swap.
                int randomSwapElement = random.Next(i); // 0 <= j <= i-1
                // Swap.
                int temp = orderedList[randomSwapElement];
                orderedList[randomSwapElement] = orderedList[i - 1];
                orderedList[i - 1] = temp;
            }

            return orderedList;
        }



        /// <summary>
        /// Brute force shuffle. A very inefficient algorithm.
        /// Appends a random element to the list sequentially. If the element is already in the list,  a new random value is generated and is retested for uniqueness.
        /// <param name="elementCount">Number of items in shuffled list</param>
        /// </summary>
        /// <returns>A shuffled list with unique items</returns>
        public static int[] BruteForceShuffle(int elementCount)
        {
            int[] shuffledList = new int[elementCount];

            Random random = new Random();
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


        /// <summary>
        /// Shuffle List. A fast algorithm but at the expense of large memory usage.
        /// Inserts a random element into an empty list, and removes that element from the initial collection so that it's not used again.
        /// </summary>
        /// <param name="elementCount">Number of items in shuffled list</param>
        /// <returns>A shuffled list with unique items</returns>
        public static int[] ShuffleList(int elementCount)
        {
            List<int> randomList = new List<int>();
            List<int> orderedList = Utils.CreateSequentialArray(elementCount).ToList();


            Random r = new Random();
            int randomIndex = 0;
            while (orderedList.Count > 0)
            {
                randomIndex = r.Next(0, orderedList.Count); //Choose a random object in the list
                randomList.Add(orderedList[randomIndex]);   //add it to the new list to a random position
                orderedList.RemoveAt(randomIndex);          //remove from collection so it's not used again
            }

            return randomList.ToArray();                    //return the new random list
        }

    }
}
