using System;
using System.Collections.Generic;

namespace exercise_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number: ");
            int enteredNum = int.Parse(Console.ReadLine());

            HashSet<int> newSet = new HashSet<int>();

            while(enteredNum != 1 && !newSet.Contains(enteredNum))
            {
                newSet.Add(enteredNum);

                int sum = 0;

                while(enteredNum > 0)
                {
                    int oneDigit = enteredNum % 10;
                    sum += oneDigit * oneDigit;
                    enteredNum /= 10;
                }

                enteredNum = sum;
            }

            if(enteredNum == 1)
            {
                Console.WriteLine("The number is happy!");
            }
            else
            {
                Console.WriteLine("The number is not happy!");
            }
        }
    }
}
