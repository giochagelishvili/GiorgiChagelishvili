namespace Extensions_Practices.Extensions
{
    public static class DataStructures
    {
        // Removes duplicate values using built-in method and returns new array

        //public static int[] RemoveDuplicates(this int[] numArray)
        //{
        //    return numArray.Distinct().ToArray();
        //}

        // Removes duplicate values and returns new array
        public static int[] RemoveDuplicates(this int[] numArray)
        {
            Array.Sort(numArray);

            // Initialize the length of new (without duplicates) array
            int newArrayLength = 1;

            // Count the number of distinct elements inside numArray
            for (int i = 0; i < numArray.Length; i++)
            {
                if (i != numArray.Length -1 && numArray[i] != numArray[i + 1])
                    newArrayLength++;
            }

            int[] withoutDuplicates = new int[newArrayLength];
            int index = 0; // Indexer for withoutDuplicates array

            foreach(int num in numArray)
            {
                // Default values are 0 so we don't add 0s to array
                if (num == 0)
                    index++;

                // Add distinct numbers into withoutDuplicates array from numArray
                if (!withoutDuplicates.Contains(num))
                    withoutDuplicates[index++] = num;
            }

            return withoutDuplicates;
        }

        // Checks if array contains the element passed as a parameter
        public static bool Contains(this double[] numArray, double value) 
        {
            foreach (double currentElement in numArray) 
            {
                if (currentElement == value)
                    return true;
            }

            return false;
        }

        // Finds and returns the element with the biggest value inside an array
        public static double MaxValue(this double[] numArray) 
        {
            double maxValue = numArray[0];

            foreach (double currentNum in numArray) 
            {
                if (currentNum > maxValue)
                    maxValue = currentNum;
            }

            return maxValue;
        }
    }
}
