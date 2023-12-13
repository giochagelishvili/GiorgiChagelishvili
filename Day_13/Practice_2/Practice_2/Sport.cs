namespace Practice_2
{
    public class Sport : Vehicle
    {
        private string SportVehicleType { get; set; }
        protected override string OriginCountry { get; set; }
        private string Mark { get; set; }
        private int ReleaseYear { get; set; }
        private int TopSpeed { get; set; }

        public Sport()
        {
            SportVehicleType = ChooseType();
            OriginCountry = GetOriginCountry();
            Mark = GetMark();
            ReleaseYear = GetReleaseYear();
            TopSpeed = GetTopSpeed();
            PrintFinalResult();
        }

        private int GetReleaseYear()
        {
            int releaseYear = 0;

            while (true)
            {
                Console.WriteLine("Enter release year: ");
                Console.WriteLine("Type \"info\" to see info.");

                string userInput = Console.ReadLine();

                if (userInput == "info")
                    PrintInfo();
                else
                {
                    releaseYear = int.Parse(userInput);
                    break;
                }
            }

            return releaseYear;
        }

        private int GetTopSpeed()
        {
            int topSpeed = 0;

            while (true)
            {
                Console.WriteLine("Enter top speed: ");
                Console.WriteLine("Type \"info\" to see info.");

                string userInput = Console.ReadLine();

                if (userInput == "info")
                    PrintInfo();
                else
                {
                    topSpeed = int.Parse(userInput);
                    break;
                }
            }

            return topSpeed;
        }

        private string GetMark()
        {
            string mark;

            while (true)
            {
                Console.WriteLine("Enter vehicle mark: ");
                Console.WriteLine("Type \"info\" to see info.");

                mark = Console.ReadLine();

                if (mark == "info")
                    PrintInfo();
                else
                    break;
            }

            return mark;
        }

        protected override string GetOriginCountry()
        {
            string originCountry;

            while (true)
            {
                Console.WriteLine("Enter origin country: ");
                Console.WriteLine("Type \"info\" to see info.");

                originCountry = Console.ReadLine();

                if (originCountry == "info")
                    PrintInfo();
                else
                    break;
            }

            return originCountry;
        }

        protected override string ChooseType()
        {
            int index = 0;
            string chosenType = "";

            while (true)
            {
                Console.WriteLine("Choose consumer vehicle type:");
                Console.WriteLine("Type \"info\" to see info.");

                for (int i = 1; i <= 4; i++)
                {
                    SportTypes currentType = (SportTypes)i;
                    Console.WriteLine($"{i}. {currentType}");
                }

                string userInput = Console.ReadLine();

                if (userInput == "info")
                    PrintInfo();
                else
                {
                    index = int.Parse(userInput);
                    SportTypes currentType = (SportTypes)index;
                    chosenType = currentType.ToString();
                    break;
                }
            }

            return chosenType;
        }

        protected override void PrintInfo()
        {
            Console.WriteLine($"Vehicle type: {SportVehicleType}");
            Console.WriteLine($"Origin country: {OriginCountry}");
            Console.WriteLine($"Mark: {Mark}");
            Console.WriteLine($"Release year: {ReleaseYear}");
            Console.WriteLine($"Top speed: {TopSpeed}");
        }

        protected override void PrintFinalResult()
        {
            Console.WriteLine("Final result:");
            PrintInfo();
        }

        enum SportTypes
        {
            F1 = 1,
            Rally,
            Track,
            Offroad
        }
    }
}
