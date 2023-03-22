using System;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount benben = new BankAccount("Benson", -17.5);
            Console.WriteLine(benben.ShowUserNameAndBalance());
        }
    }
}