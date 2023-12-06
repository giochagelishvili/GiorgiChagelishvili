using System.Net.NetworkInformation;

namespace Practices
{
    public static class MathMethods
    {
        enum Statuses
        {
            PowMustBeaPositiveOrZero,
            Success,
            NumbersMustBeDifferent
        }

        public static int Pow(int num, int power, out string status)
        {
            if (power < 0) 
            {
                status = Statuses.PowMustBeaPositiveOrZero.ToString();
                return -1;
            }

            int result = 1;

            for (int i = 0; i < power; i++)
            {
                result *= num;
            }

            status = Statuses.Success.ToString();
            return result;
        }

        public static int Min(int firstNum, int secondNum, out string status)
        {
            if (firstNum == secondNum)
            {
                status = Statuses.NumbersMustBeDifferent.ToString();
                return 0;
            }

            if (firstNum > secondNum)
            {
                status = Statuses.Success.ToString();
                return secondNum;
            } else
            {
                status = Statuses.Success.ToString();
                return firstNum;
            }

        }

        public static int Max(int firstNum, int secondNum, out string status)
        {
            if (firstNum == secondNum)
            {
                status = Statuses.NumbersMustBeDifferent.ToString();
                return 0;
            }

            if (firstNum > secondNum)
            {
                status = Statuses.Success.ToString();
                return firstNum;
            } else
            {
                status = Statuses.Success.ToString();
                return secondNum;
            }
        }
    }
}
