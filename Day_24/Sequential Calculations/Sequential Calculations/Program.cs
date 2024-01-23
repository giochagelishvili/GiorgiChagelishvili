namespace Sequential_Calculations
{
    internal class Program
    {
        public delegate decimal MathOperation(decimal x, decimal y);

        static void Main(string[] args)
        {
            MathOperation sum = Mathematics.Sum;
            MathOperation sub = Mathematics.Subtract;
            MathOperation multiply = Mathematics.Multiply;
            MathOperation divide = Mathematics.Divide;

            MathOperation sumSub = sum + sub;
            MathOperation mulDiv = multiply + divide;
            MathOperation mathOperation = sumSub + mulDiv;

            InvokeDelegateChain(mathOperation);
        }

        public static void InvokeDelegateChain(MathOperation delegateChain)
        {
            foreach (var item in delegateChain.GetInvocationList())
            {
                string methodName = item.Method.Name;
                Console.WriteLine($"{methodName}: {item.DynamicInvoke(2.5M, 5.2M):F2}");
            }
        }
    }
}