using System.Diagnostics;

namespace Practice_2
{
    public static class Helpers
    {
        #region Properties
        public static List<ElectricCar> Cars = GenerateCars();
        private static CancellationTokenSource cts = new();
        private static Stopwatch StopWatch = new();
        private static Sochiki Sochiki = new(StopWatch);
        private static Task[] Tasks = new Task[Cars.Count];
        #endregion

        public static TimeSpan ChargeCars()
        {
            StartCharging();

            Task.Run(() => Sochiki.AtrialeSochiki(cts));

            Task completed = Task.WhenAll(Tasks);

            while (StopWatch.IsRunning)
                if (StopWatch.Elapsed.TotalSeconds > 200 || completed.IsCompleted)
                {
                    StopWatch.Stop();
                    cts.Cancel();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"\nSochiki trials morcha, davalianeba: ");
                    if (Sochiki.Bill > 10)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{Sochiki.Bill:C2}.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            return StopWatch.Elapsed;
        }

        private static void StartCharging()
        {
            StopWatch.Start();

            Console.WriteLine("\nTimer started");

            for (int i = 0; i < Tasks.Length; i++)
            {
                int index = i;
                Tasks[index] = Task.Run(() => Cars[index].Charge(cts));
            }
        }

        public static List<ElectricCar> GenerateCars()
        {
            Random random = new();

            var cars = new List<ElectricCar>();

            for (int i = 0; i < 10; i++)
            {
                int year = random.Next(2020, 2024);
                int batteryLevel = random.Next(5, 100);
                Model model = (Model)random.Next(1, 4);

                cars.Add(new ElectricCar(model, year, batteryLevel));
            }

            return cars;
        }

        public static void PrintCars() => Cars.ForEach(car => car.PrintDetails());
    }
}
