using System;

namespace ShuffleAlgorithms
{
    /// <summary>
    /// Command line applications comparing performances of a number of algorithms to display a list of numbers (default of 10,000) in random order.
    /// Each number in the list is unique and between 1 and the upper range specified (default 10,000). 
    /// This application closely demonstrates a similar problem of shuffling a deck of 10,000 cards.
    /// </summary>
    public class Program
    {
        private const int ElementCount = 10000;

        public delegate int[] AlgorithmDelegate(int elementCount);

        static void Main(string[] args)
        {
            // optional command line parameter to suppress the output of the actual list
            bool suppressOutput = true;

            if (args.Length > 0 && args[0].ToLowerInvariant() != "suppresslist")
            {
                Console.WriteLine("Usage: ShuffleAlgorithms.exe [suppresslist]");
                return;
            }

            if (args.Length > 0 && args[0].ToLowerInvariant() == "suppresslist")
                suppressOutput = false;

            Console.WriteLine("Comparison of different shuffling algorithms:\r\n\r\n");

            PrintExecutionSummary("Brute Force", new AlgorithmDelegate(Algorithms.BruteForceShuffle), suppressOutput);
            PrintExecutionSummary("Shuffle List", new AlgorithmDelegate(Algorithms.ShuffleList), suppressOutput);
            PrintExecutionSummary("Fisher-Yates", new AlgorithmDelegate(Algorithms.FisherYatesShuffle), suppressOutput);
        }



        /// <summary>
        /// Prints out a summary of the algorithm to the console, including execution times.
        /// </summary>
        /// <param name="algorithmDescription">Summary of the algorithm used</param>
        /// <param name="algorithm">Algorithm method (delegate)</param>
        /// <param name="suppressListDisplay"><code>true</code> to dispaly the contents of the shuffled list</param>
        private static void PrintExecutionSummary(string algorithmDescription, AlgorithmDelegate algorithm, bool suppressListDisplay)
        {

            int[] algorithmResults;

            Console.WriteLine("===============================================");
            Console.WriteLine(String.Format("Results for the {0} algorithm:", algorithmDescription));

            // determine length of time required to process algorithm
            DateTime Start = DateTime.Now;
            algorithmResults = algorithm(ElementCount);
            TimeSpan Elapsed = DateTime.Now - Start;
            
            if (suppressListDisplay)
                Utils.PrintArray(algorithmResults);
            
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Time required to process the {0} algorithm: {1} ms\r\n", algorithmDescription, Elapsed.Milliseconds);

            Console.WriteLine("Press any key for the next test");
            Console.ReadKey();

        }



    }
}
