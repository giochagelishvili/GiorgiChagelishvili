using Exception_Practice.Exceptions;

namespace Exception_Practice.Classes
{
    public abstract class IBAN
    {
        protected string CountryCode { get; set; }
        protected int CheckDigits { get; set; }
        protected string BankCode { get; set; }
        protected string AccountNumber { get; set; }
        protected double Balance { get; set; }

        protected IBAN(string countryCode, int checkDigits, string bankCode, string accountNumber)
        {
            CountryCode = countryCode;
            CheckDigits = checkDigits;
            BankCode = bankCode;
            AccountNumber = accountNumber;
        }

        public abstract void Withdraw();
        public void ShowBalance()
        {
            Console.WriteLine($"Current balance is: ${Balance.ToString("0.##")}");
        }
        public void Deposit()
        {
            Console.Write("Please enter the amount you would like to deposit: ");

            double amount = 0;

            try
            {
                bool userInput = double.TryParse(Console.ReadLine(), out amount);

                // If user provided amount in invalid format
                if (!userInput)
                    throw new InvalidAmountException("There was a problem with provided amount.", new InvalidFormatException());

                // If user provided a number, which is less than or equal to 0
                if (amount <= 0)
                    throw new InvalidAmountException("There was a problem with provided amount.", new NegativeAmountException());

                Console.WriteLine($"Depositing ${amount} into account...");

                Balance += amount;

                Console.WriteLine("Deposit successfull.");
            }
            catch (InvalidAmountException ex)
            {
                // Print the message to the user
                Console.WriteLine(Output.GetLastInnerExMessage(ex));
            }
        }
    }
}
