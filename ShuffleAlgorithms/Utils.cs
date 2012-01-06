using System;

namespace ShuffleAlgorithms
{
    /// <summary>
    /// Utility class providing helper methods to he Shuffle Algorithm generator
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Creates a sequential list
        /// </summary>
        /// <param name="elementCount">list size</param>
        /// <returns></returns>
        public static int[] CreateSequentialArray(int elementCount)
        {
            int[] sequentialArray = new int[elementCount];

            for (int i = 0; i < elementCount; i++)
                sequentialArray[i] = i + 1;

            return sequentialArray;
        }


        /// <summary>
        /// Prints the contents of an array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public static void PrintArray<T>(T[] array)
        {
            foreach (var element in array)
                Console.WriteLine(element);
        }
    }
}
