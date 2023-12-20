using System.Globalization;

namespace Data_Structures_Practices.Classes
{
    public static class MultipleReturnValues
    {
        public static Tuple<int, bool> findMin(int firstNum, int secondNum)
        {
            if (firstNum == secondNum)
                return new Tuple<int, bool>(firstNum, false);

            if (firstNum < secondNum)
                return new Tuple<int, bool>(firstNum, true);

            return new Tuple<int, bool>(secondNum, true);
        }

        public static Tuple<T, T> Swap<T>(this Tuple<T, T> toSwap)
        {
            return new Tuple<T, T>(toSwap.Item2, toSwap.Item1);
        }
    }
}
