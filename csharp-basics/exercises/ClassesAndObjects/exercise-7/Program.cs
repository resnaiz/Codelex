using System;

namespace exercise_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How much money is in the account?: ");
            double startBalance = double.Parse(Console.ReadLine());
            Console.Write("Enter the annual interest rate: ");
            double annualInterestRate = double.Parse(Console.ReadLine());
            Console.Write("How long has the account been opened? ");
            int accountOpenedTime = int.Parse(Console.ReadLine());

            SavingsAccount newAccount = new SavingsAccount(startBalance);
            newAccount.SetInterestRate(annualInterestRate);

            double deposit = 0;
            double withdraw = 0;
            double interest = 0;

            for(int i = 1; i <= accountOpenedTime; i++)
            {
                Console.Write("Enter amount deposited for month {0}: ", i);
                double deposited = double.Parse(Console.ReadLine());
                newAccount.AddingAmountOfDeposit(deposited);
                deposit += deposited;

                Console.Write("Enter amount withdrawn for {0}: ", i);
                double withdrawn = double.Parse(Console.ReadLine());
                newAccount.SubtractingAmountOfDeposit(withdrawn);
                withdraw += withdrawn;

                newAccount.AddingAmountOfInterest();
                interest += (newAccount.GetBalance() - deposit + withdraw) * (annualInterestRate / 12);
            }

            Console.WriteLine("Total deposited: ${0:F2}", deposit);
            Console.WriteLine("Total withdrawn: ${0:F2}", withdraw);
            Console.WriteLine("Interest earned: ${0:F2}", interest);
            Console.WriteLine("Ending balance: ${0:F2}", newAccount.GetBalance());
        }
    }
}
