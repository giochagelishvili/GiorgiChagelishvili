using Extensions_Practices.Extensions;

namespace Extensions_Practices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //-----------------------------//
            //---- String Manipulation ----//
            //-----------------------------//

            // Reverse string
            string text = "Hello, world!";
            string reversedText = text.Reverse();

            Console.WriteLine($"Original text: {text}");
            Console.WriteLine($"Reversed text: {reversedText}");

            // Count the number of occurences of a given character
            int numberOfOccurrences = text.NumberOfOccurrences('l');
            Console.WriteLine($"Number of occurrences of letter \"L\" in \"Hello, world!\": {numberOfOccurrences}");

            // Check if string starts with specific substring
            bool startsOrEndWith = text.StartsOrEndsWith("Hello");

            if (startsOrEndWith)
                Console.WriteLine($"\"{text}\" starts with passed substring.");

            startsOrEndWith = text.StartsOrEndsWith("world!");

            if (startsOrEndWith)
                Console.WriteLine($"\"{text}\" ends with passed substring.");

            startsOrEndWith = text.StartsOrEndsWith("Wakanda");

            if (!startsOrEndWith)
                Console.WriteLine($"\"{text}\" doesn't start or end with passed substring.");

            //----------------------------//
            //---- Numeric Operations ----//
            //----------------------------//

            // Check if the number is even or odd
            int number = -11;
            bool evenOrOdd = number.isEven();

            Console.WriteLine(evenOrOdd ? $"{number} is even." : $"{number} is odd.");

            // Calculate the absolute value of the number
            int absoluteValue = number.AbsoluteValue();

            Console.WriteLine($"The absolute value of {number} is {absoluteValue}");

            // Round one number to the nearest multiple of another number
            double numToRound = 23.5;
            double multiple = 5.25;
            double roundedNum = numToRound.RoundToNearestMultiple(multiple);

            Console.WriteLine($"{numToRound} rounded to the nearest multiple of {multiple} is: {roundedNum}");

            //--------------------------//
            //---- Data Structures ----//
            //------------------------//

            // Remove duplicate values from the array
            int[] withDuplicates = { 1, 1, 3, 2, 4, 4, 2, 5 };
            int[] withoutDuplicates = withDuplicates.RemoveDuplicates();

            Console.Write("Before removing duplicates: ");

            foreach (int num in withDuplicates)
            {
                if (num == withDuplicates.Last())
                    Console.Write($"{num} \n");
                else
                    Console.Write($"{num}, ");
            }

            Console.Write("After removing duplicates: ");

            foreach (int num in withoutDuplicates)
            {
                if (num == withoutDuplicates.Last())
                    Console.Write($"{num} \n");
                else
                    Console.Write($"{num}, ");
            }

            // Check if array contains given element
            double[] numArray = { 1.25, 20.1, 0.1, 31.23 };
            double elementToCheck = 20.3;
            bool containsOrNot = numArray.Contains(elementToCheck);

            Console.WriteLine(containsOrNot ? $"Array contains {elementToCheck}" : $"Array doesn't contain {elementToCheck}");

            // Find the maximum value element in array
            double maxValue = numArray.MaxValue();

            Console.WriteLine($"Element with the biggest value is: {maxValue}");

            //------------------------//
            //---- Date And Time ----//
            //----------------------//

            // Print current time 
            DateTime date = DateTime.Now;
            Console.WriteLine($"Current date: {date.DateToString()}");

            // Check if date falls within a date range
            DateTime dateToCheck = new DateTime(2015, 12, 23);
            DateTime startDate = new DateTime(2010, 10, 11);
            DateTime endDate = new DateTime(2022, 11, 11);

            bool isBetween = dateToCheck.IsBetween(startDate, endDate);

            Console.WriteLine(isBetween ? "Given date falls within given date range." : "Given date doesn't fall within given date range.");

            // Calculate age
            DateTime birthDate = new DateTime(2000, 11, 11);

            Console.WriteLine($"Age is {birthDate.CalculateAge()}");

            //--------------------------------------//
            //---- Collections and Enumerables ----//
            //------------------------------------//
            
            // Merge arrays
            int[] firstNumArray = { 1, 2, 3, 5, 6, 7, 9 };
            int[] secondNumarray = { 2, 4 };

            int[] mergedArrays = firstNumArray.MergeWith(secondNumarray);

            Console.Write("Merged array: ");

            foreach (int num in mergedArrays)
            {
                if (num == mergedArrays.Last())
                    Console.Write($"{num}\n");
                else
                    Console.Write($"{num}, ");
            }

            // Array to string
            double[] doubleArray = { 1.25, 3.2, 0.1, -23.3 };

            Console.WriteLine($"Array represented as string: {doubleArray.ArrayToString(',')}");
        }
    }
}
