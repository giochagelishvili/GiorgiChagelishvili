namespace Practice_2
{
    public class ElectricCar
    {
        public Model Model { get; set; }
        public int Year { get; set; }
        public int BatteryLevel { get; set; }

        public ElectricCar(Model model, int year, int batteryLevel)
        {
            Model = model;
            Year = year;
            BatteryLevel = batteryLevel;
        }

        public async Task Charge(CancellationTokenSource cts)
        {
            while(BatteryLevel < 100 && !cts.IsCancellationRequested)
            {
                await Task.Delay(10000);
                BatteryLevel += 5;
            }

            if (BatteryLevel > 100)
                BatteryLevel = 100;
        }

        public void PrintDetails()
        {
            Console.Write($"Model: {Model,-12} Year: {Year,-10} Battery Level: ");

            if (BatteryLevel < 100)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.Green;

            Console.Write($"{BatteryLevel}\n");

            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public enum Model
    {
        i7 = 1,
        Model3,
        ModelS
    }
}
