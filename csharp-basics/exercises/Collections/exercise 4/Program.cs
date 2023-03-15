using System;
using System.Collections.Generic;

namespace exercise_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var listOfRandomWords = new HashSet<string>();

            bool emptyEnter = false;

            while(!emptyEnter)
            {
                Console.Write("Enter name: ");
                string input = Console.ReadLine().Trim();

                if(string.IsNullOrEmpty(input))
                {
                    break;
                }

                listOfRandomWords.Add(input);
            }

            Console.WriteLine($"Unique name list contains: {string.Join(" ", listOfRandomWords)}");
        }
    }
}
