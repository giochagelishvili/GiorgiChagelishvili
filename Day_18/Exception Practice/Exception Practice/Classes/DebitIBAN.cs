using Exception_Practice.Exceptions;

namespace Exception_Practice.Classes
{
    public class DebitIBAN : IBAN
    {
        public DebitIBAN(string countryCode, int checkDigits, string bankCode, string accountNumber) : base(countryCode, checkDigits, bankCode, accountNumber)
        {
        }

        public override void Withdraw()
        {
            ShowBalance();

            Console.Write("Please enter the amount you would like to withdraw: ");

            double amount = 0;

            try
            {
                bool userInput = double.TryParse(Console.ReadLine(), out amount);

                // Invalid format (user didn't enter numbers)
                if (!userInput)
                    throw new InvalidAmountException("There was a problem during withdrawal.", new InvalidFormatException());

                // Invalid amount
                if (amount <= 0)
                    throw new InvalidAmountException("There was a problem during withdrawal.", new NegativeAmountException());

                // Insufficient funds
                if (amount > Balance)
                    throw new InvalidAmountException("There was a problem during withdrawal.", new InsufficientFundsException());

                Balance -= amount;

                Console.WriteLine($"Successfully withdrawn ${amount} from the account.");

                ShowBalance();
            }
            catch (InvalidAmountException ex)
            {
                Console.WriteLine(Output.GetAllInnerExMessageTogether(ex));
            }
        }
    }
}
