namespace Extensions_Practices.Extensions
{
    public static class CollectionsAndEnumerables
    {
        // Merges two arrays and returns new merged array
        public static int[] MergeWith(this int[] firstNumArray, int[] secondNumArray)
        {
            // Calculate the length of merged array
            int mergedArrayLength = firstNumArray.Length + secondNumArray.Length;

            int[] mergedArray = new int[mergedArrayLength];

            // Indexer is used to access elements into firstNumArray and secondNumArray
            int indexer = 0;
            
            for (int i = 0; i < mergedArrayLength; i++) 
            {
                // Add firstNumArray elements into mergedArray
                if (i < firstNumArray.Length)
                {
                    mergedArray[i] = firstNumArray[indexer];
                    indexer++;

                    // Check if all elements are added from the first array
                    if (indexer == firstNumArray.Length)
                        indexer = 0;

                    continue;
                }

                // Add secondNumArray elements into mergedArray
                mergedArray[i] = secondNumArray[indexer];
                indexer++;
            }

            return mergedArray;
        }

        // Turns array into string, separates elements by passed separator (space by default)
        public static string ArrayToString(this double[] doubleArray, char separator = ' ')
        {
            string result = "";

            foreach (double currentElement in doubleArray)
            {
                if (currentElement == doubleArray.Last())
                    result += currentElement;
                else
                    result += $"{currentElement}{separator}";
            }

            return result;
        }
    }
}
