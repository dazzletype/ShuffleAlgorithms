using System.Linq;

namespace ShuffleAlgorithmTests
{
    /// <summary>
    /// Helper methods for Shuffle Algorithm tests
    /// </summary>
    public static class TestHelpers
    {
        /// <summary>
        /// Determines if a shuffled ordered list contains all its original elements
        /// </summary>
        /// <param name="list">list of ordered elements (shuffled or not)</param>
        /// <returns><code>true</code> if list is not missing any elements</returns>
        public static bool ListContainsAllUniqueElements(int[] list)
        {
            for (int i = 1; i < list.Count(); i++)
                if (!list.Contains(i))
                    return false;

            return true;
        }
    }
}
