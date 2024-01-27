namespace Practice_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Helpers.PrintCars();

            var secondsElapsed = Helpers.ChargeCars().TotalSeconds;

            Console.Write($"Time elapsed: ");

            if (secondsElapsed < 200)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.Write($"{secondsElapsed:F2}");
            Console.Write(" seconds.\n\n");
            Console.ForegroundColor = ConsoleColor.White;

            Helpers.PrintCars();
        }
    }
}
