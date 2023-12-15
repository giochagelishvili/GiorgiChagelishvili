namespace Extensions_Practices.Extensions
{
    public static class StringManipulation
    {
        // Takes string as a parameter and returns reversed version
        public static string Reverse(this string s) 
        {
            if (!string.IsNullOrEmpty(s))
            {
                char[] chars = s.ToCharArray();
                Array.Reverse(chars);
                return new string(chars);
            }

            return s;
        }

        // Counts the number of occurrences of the given character in the string
        public static int NumberOfOccurrences(this string s, char c)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            char[] chars = s.ToCharArray();
            int numberOfOccurrences = 0;

            foreach (char currentChar in chars)
            {
                if (currentChar == c)
                    numberOfOccurrences++;
            }

            return numberOfOccurrences;
        }

        // Checks if string starts with specific substring
        public static bool StartsOrEndsWith(this string s, string substring)
        {
            if (s.StartsWith(substring))
                return true;

            if (s.EndsWith(substring))
                return true;

            return false;
        }
    }
}
