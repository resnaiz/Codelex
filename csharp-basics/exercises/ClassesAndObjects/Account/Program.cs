using System;

namespace Account
{
    class Program
    {
        private static void Main(string[] args)
        {
            Account bartosAccount = new Account("Barto's account", 100.00);
            bartosAccount.Deposit(20.00);
            Console.WriteLine(bartosAccount);

            Account mattsAccount = new Account("Matt's account", 1000.00);
            Account myAccount = new Account("My account", 0.00);

            mattsAccount.Withdrawal(100.00);
            myAccount.Deposit(100.00);

            Console.WriteLine(mattsAccount);
            Console.WriteLine(myAccount);

            Account A = new Account("A account", 100.00);
            Account B = new Account("B account", 0.00);
            Account C = new Account("C account", 0.00);

            Transfer(A, B, 50.00);
            Transfer(B, C, 25.00);

            Console.WriteLine(A);
            Console.WriteLine(B);
            Console.WriteLine(C);
        }

        public static void Transfer(Account from, Account to, double howMuch)
        {
            from.Withdrawal(howMuch);
            to.Deposit(howMuch);
        }
    }
}