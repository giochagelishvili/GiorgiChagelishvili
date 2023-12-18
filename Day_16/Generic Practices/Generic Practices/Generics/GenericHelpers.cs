namespace Generic_Practices.Generics
{
    public static class GenericHelpers
    {
        // Takes 2 elements and an array as parameters
        // Finds passed elements inside an array and swaps their places
        public static T[] SwapElements<T>(this T[] array, T firstElement, T secondElement)
        {
            // Make sure array contains at least 2 elements
            if (array.Length < 2)
            {
                Console.WriteLine("Array must contain 2 or more elements.");
                return null;
            }

            // Make sure array contains both elements
            if (!array.Contains(firstElement) || !array.Contains(secondElement))
            {
                Console.WriteLine("Array doesn't contain both elements.");
                return null;
            }

            int firstElementIndex = Array.IndexOf(array, firstElement);
            int secondElementIndex = Array.IndexOf(array, secondElement);

            // Swap places of elements
            T temp = array[firstElementIndex];
            array[firstElementIndex] = array[secondElementIndex];
            array[secondElementIndex] = temp;

            return array;
        }

        // Finds and returns the element with highest value
        public static T FindMax<T>(this T[] array) where T : IComparable<T>
        {
            if (array.Length == 0 || array == null)
                return default;

            T maxElement = array[0];

            foreach (T element in array)
            {
                if (element.CompareTo(maxElement) > 0)
                    maxElement = element;
            }

            return maxElement;
        }
    }
}