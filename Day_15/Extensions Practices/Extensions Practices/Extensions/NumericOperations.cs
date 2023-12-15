namespace Extensions_Practices.Extensions
{
    public static class NumericOperations
    {
        // Returns true if number is even, false if number is odd
        public static bool isEven(this int num)
        {
            if (num % 2 == 0)
                return true;

            return false;
        }

        // Calculates the absolute value of the number
        public static int AbsoluteValue(this int num)
        {
            if (num < 0)
                num *= -1;

            return num;
        }

        // Round the number to the nearest multiple of another given number
        public static double RoundToNearestMultiple(this double numToRound, double multiple)
        {
            return Math.Round(numToRound / multiple) * multiple;
        }
    }
}
