using PhoneBook;
using System;

namespace Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneDic = new PhoneDirectory();

            phoneDic.PutNumber("Test", "27654763");
            phoneDic.PutNumber("Arnis", "87654321");
            phoneDic.PutNumber("Test2", "123-123-123");
            phoneDic.PutNumber("Test3", "12000000");

            Console.WriteLine("Test number: " + phoneDic.GetNumber("Test"));
            Console.WriteLine("Test2 number: " + phoneDic.GetNumber("Test2"));
            Console.WriteLine("Test3 number: " + phoneDic.GetNumber("Test3"));
            Console.WriteLine("Arnis number: " + phoneDic.GetNumber("Arnis"));
            Console.WriteLine();
        }
    }
}
