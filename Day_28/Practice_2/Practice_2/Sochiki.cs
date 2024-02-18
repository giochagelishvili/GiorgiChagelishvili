using System.Diagnostics;

namespace Practice_2
{
    public class Sochiki
    {
        public decimal Bill { get; set; }

        private const decimal CostPerSecond = 0.05M;
        private Stopwatch Stopwatch { get; set; }

        public Sochiki(Stopwatch stopwatch)
        {
            Stopwatch = stopwatch;
        }

        public async Task AtrialeSochiki(CancellationTokenSource cts)
        {
            Console.Write("\nSochiki trialebs: ");

            while (!cts.IsCancellationRequested && Stopwatch.IsRunning)
            {
                Bill = CalculateBill(Stopwatch.Elapsed);

                if(Bill <= 9.99M)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    await Task.Delay(1000);
                    Console.Write($"{Bill:C2}");
                    await Task.Delay(1000);
                    Console.Write('.');
                    await Task.Delay(500);
                    Console.Write('.');
                    await Task.Delay(500);
                    Console.Write('.');
                    await Task.Delay(500);

                    Console.Write("\b\b\b\b\b\b\b\b");
                    Console.Write("        ");
                    Console.Write("\b\b\b\b\b\b\b\b");
                } else if (Bill > 9.99M)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    await Task.Delay(1000);
                    Console.Write($"{Bill:C2}");
                    await Task.Delay(1000);
                    Console.Write('.');
                    await Task.Delay(500);
                    Console.Write('.');
                    await Task.Delay(500);
                    Console.Write('.');
                    await Task.Delay(500);

                    Console.Write("\b\b\b\b\b\b\b\b\b");
                    Console.Write("         ");
                    Console.Write("\b\b\b\b\b\b\b\b\b");
                }
            }
        }

        private decimal CalculateBill(TimeSpan timeElapsed) => ((decimal)timeElapsed.TotalSeconds) * CostPerSecond;
    }
}
