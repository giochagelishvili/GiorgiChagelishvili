namespace Practice_2
{
    public class Public : Vehicle
    {
        private string PublicVehicleType { get; set; }
        protected override string OriginCountry { get; set; }
        private string Mark { get; set; }
        private int ReleaseYear { get; set; }
        private int Capacity { get; set; }

        public Public()
        {
            PublicVehicleType = ChooseType();
            OriginCountry = GetOriginCountry();
            Mark = GetMark();
            ReleaseYear = GetReleaseYear();
            Capacity = GetCapacity();
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

        private int GetCapacity()
        {
            int capacity = 0;

            while (true)
            {
                Console.WriteLine("Enter capacity: ");
                Console.WriteLine("Type \"info\" to see info.");

                string userInput = Console.ReadLine();

                if (userInput == "info")
                    PrintInfo();
                else
                {
                    capacity = int.Parse(userInput);
                    break;
                }
            }

            return capacity;
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
                    PublicTypes currentType = (PublicTypes)i;
                    Console.WriteLine($"{i}. {currentType}");
                }

                string userInput = Console.ReadLine();

                if (userInput == "info")
                    PrintInfo();
                else
                {
                    index = int.Parse(userInput);
                    PublicTypes currentType = (PublicTypes)index;
                    chosenType = currentType.ToString();
                    break;
                }
            }

            return chosenType;
        }

        protected override void PrintInfo()
        {
            Console.WriteLine($"Vehicle type: {PublicVehicleType}");
            Console.WriteLine($"Origin country: {OriginCountry}");
            Console.WriteLine($"Mark: {Mark}");
            Console.WriteLine($"Release year: {ReleaseYear}");
            Console.WriteLine($"Capacity: {Capacity}");
        }

        protected override void PrintFinalResult()
        {
            Console.WriteLine("Final result:");
            PrintInfo();
        }

        enum PublicTypes
        {
            BUS = 1,
            Train,
            Taxi,
            Tramway
        }
    }
}
