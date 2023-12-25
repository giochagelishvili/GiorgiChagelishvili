using Exception_Practice.Exceptions;

namespace Exception_Practice.Classes
{
    internal class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private CreditIBAN? CreditIBAN { get; set; }
        private DebitIBAN? DebitIBAN { get; set; }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        // Continiously lets user execute ATM operations (deposit, withdraw, show balance, create IBAN)
        // User can stop executing method by input 6
        public void StartATM()
        {
            Console.WriteLine($"Hello, {FirstName}!");

            int chosenOperation = 0;

            do
            {
                Console.WriteLine("1) Withdraw");
                Console.WriteLine("2) Deposit");
                Console.WriteLine("3) Show Balance");
                Console.WriteLine("4) Create Credit IBAN");
                Console.WriteLine("5) Create Debit IBAN");
                Console.WriteLine("6) Exit");

                try
                {
                    bool userInput = int.TryParse(Console.ReadLine(), out chosenOperation);

                    if (!userInput)
                        throw new InvalidATMOperationException("Input must be one of operation's corresponding number.");

                    if (chosenOperation < 1 || chosenOperation > 6)
                        throw new InvalidATMOperationException();
                }
                catch (InvalidATMOperationException ex)
                { 
                    Console.WriteLine(ex.Message); 
                }

                try
                {
                    // Check if user wants to create an IBAN
                    if (chosenOperation == 4 || chosenOperation == 5)
                        Execute(chosenOperation);
                    else if (chosenOperation > 0 && chosenOperation < 4)
                    {
                        // Ask the user on which IBAN would they like to execute an operation
                        string type = GetIBANType();

                        // Execute operation on chosen IBAN
                        Execute(chosenOperation, type);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(Output.GetAllInnerExMessageTogether(ex));
                }

            } while (chosenOperation != 6);
        }

        // Returns the chosen type of IBAN. It's either "Credit" or "Debit"
        private string GetIBANType()
        {
            Console.WriteLine("Please choose IBAN: ");
            Console.WriteLine("1) Credit IBAN");
            Console.WriteLine("2) Debit IBAN");

            int chosenType = 0;

            try
            {
                bool userInput = int.TryParse(Console.ReadLine(), out chosenType);

                if (!userInput)
                    throw new InvalidATMOperationException("Input must be one of IBAN's corresponding number.");

                if (chosenType < 1 || chosenType > 2)
                    throw new InvalidATMOperationException("Please choose one of listed types.");
            }
            catch (InvalidATMOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (chosenType == 1)
                return "Credit";
            else
                return "Debit";
        }

        // Executes the method according to passed operation
        // List of operations and corresponding numbers can be found in StartATM() method
        private void Execute(int operation, string type = null)
        {
            // Check if credit IBAN already exists
            if (operation == 4 && CreditIBAN != null) 
                throw new InvalidIBANException("IBAN already exists.");
            else if (operation == 4 && CreditIBAN == null)
            {
                GenerateIBAN("Credit");
                return;
            }

            // Check if debit IBAN already exists
            if (operation == 5 && DebitIBAN != null)
                throw new InvalidIBANException("IBAN already exists.");
            else if (operation == 5 && DebitIBAN == null)
            {
                GenerateIBAN("Debit");
                return;
            }

            // If user wants to execute operation on credit IBAN
            if (type == "Credit" && CreditIBAN != null)
            {
                switch (operation)
                {
                    case 1:
                        CreditIBAN.Withdraw();
                        break;
                    case 2:
                        CreditIBAN.Deposit();
                        break;
                    case 3:
                        CreditIBAN.ShowBalance();
                        break;
                }
            } 
            else if (type == "Credit" && CreditIBAN == null)
            {
                throw new InvalidIBANException("Invalid IBAN operation.", new IBANDoesNotExistException());
            }

            // If user wants to execute operation on debit IBAN
            if (type == "Debit" && DebitIBAN != null)
            {
                switch (operation)
                {
                    case 1:
                        DebitIBAN.Withdraw();
                        break;
                    case 2:
                        DebitIBAN.Deposit();
                        break;
                    case 3:
                        DebitIBAN.ShowBalance();
                        break;
                }
            }
            else if (type == "Debit" && DebitIBAN == null)
            {
                throw new InvalidIBANException("Invalid IBAN operation.", new IBANDoesNotExistException());
            }
        }
        
        // Generates random IBAN for the user
        private void GenerateIBAN(string type)
        {
            string countryCode = "GE";
            int checkDigits = new Random().Next(10, 99);
            string bankCode = "TB";
            string accountNumber = "";

            for (int i = 0; i < 8; i++)
                accountNumber += $"{new Random().Next(10, 99)}";

            if (type == "Credit")
            {
                CreditIBAN = new CreditIBAN(countryCode, checkDigits, bankCode, accountNumber);
                Console.WriteLine("Credit IBAN created successfully.");
            }
            else if (type == "Debit")
            {
                DebitIBAN = new DebitIBAN(countryCode, checkDigits, bankCode, accountNumber);
                Console.WriteLine("Debit IBAN created successfully.");
            }
        }
    }
}
