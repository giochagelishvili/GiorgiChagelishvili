namespace Practice_2
{
    public class Combat : Vehicle
    {
        private string CombatVehicleType { get; set; }
        protected override string OriginCountry { get; set; }
        private int AttackDamage { get; set; }
        private int Health { get; set; }
        private int Armor { get; set; }
        private int AmmoCapacity { get; set; }

        public Combat()
        {
            CombatVehicleType = ChooseType();
            OriginCountry = GetOriginCountry();
            AttackDamage = GetAttackDamage();
            Health = GetHealth();
            Armor = GetArmor();
            AmmoCapacity = GetAmmoCapacity();
            PrintFinalResult();
        }

        private int GetAmmoCapacity()
        {
            int ammoCapacity = 0;

            while (true)
            {
                Console.WriteLine("Enter ammo capacity: ");
                Console.WriteLine("Type \"info\" to see info.");

                string userInput = Console.ReadLine();

                if (userInput == "info")
                    PrintInfo();
                else
                {
                    ammoCapacity = int.Parse(userInput);
                    break;
                }
            }

            return ammoCapacity;
        }
        private int GetArmor()
        {
            int armor = 0;

            while (true)
            {
                Console.WriteLine("Enter armor: ");
                Console.WriteLine("Type \"info\" to see info.");

                string userInput = Console.ReadLine();

                if (userInput == "info")
                    PrintInfo();
                else
                {
                    armor = int.Parse(userInput);
                    break;
                }
            }

            return armor;
        }
        private int GetHealth()
        {
            int health = 0;

            while (true)
            {
                Console.WriteLine("Enter health: ");
                Console.WriteLine("Type \"info\" to see info.");

                string userInput = Console.ReadLine();

                if (userInput == "info")
                    PrintInfo();
                else
                {
                    health = int.Parse(userInput);
                    break;
                }
            }

            return health;
        }
        private int GetAttackDamage()
        {
            int attackDamage = 0;

            while(true)
            {
                Console.WriteLine("Enter attack damage: ");
                Console.WriteLine("Type \"info\" to see info.");

                string userInput = Console.ReadLine();

                if (userInput == "info")
                    PrintInfo();
                else
                {
                    attackDamage = int.Parse(userInput);
                    break;
                }
            }

            return attackDamage;
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

            while(true)
            {
                Console.WriteLine("Choose combat vehicle type:");
                Console.WriteLine("Type \"info\" to see info.");

                for (int i = 1; i <= 4; i++)
                {
                    CombatTypes currentType = (CombatTypes)i;
                    Console.WriteLine($"{i}. {currentType}");
                }

                string userInput = Console.ReadLine();

                if (userInput == "info")
                    PrintInfo();
                else
                {
                    index = int.Parse(userInput);
                    CombatTypes currentType = (CombatTypes)index;
                    chosenType = currentType.ToString();
                    break;
                }
            }

            return chosenType;
        }

        protected override void PrintInfo()
        {
            Console.WriteLine($"Vehicle type: {CombatVehicleType}");
            Console.WriteLine($"Origin country: {OriginCountry}");
            Console.WriteLine($"Attack damage: {AttackDamage}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Armor: {Armor}");
            Console.WriteLine($"Ammo capacity: {AmmoCapacity}");
        }

        protected override void PrintFinalResult()
        {
            Console.WriteLine("Final result:");
            PrintInfo();
        }

        // didgori tu ar icit saqartvelos sheiaragebashi iyo javshan-teqnika ;)
        enum CombatTypes 
        {
            Tank = 1,
            BTR,
            ArmoredCar,
            Didgori
        }
    }
}
