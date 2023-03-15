using System;
using System.Collections.Generic;

namespace ListExercise7
{
    class Program
    {
        static void Main(string[] args)
        {
            var colors = new List<string>
            {
                "Red",
                "Green",
                "Orange",
                "White",
                "Black"
            };

            if (colors.Contains("White"))
            {
                Console.WriteLine("List contains element - (White)");
            }
            else
            {
                Console.WriteLine("Element not found in list.");
            }

            Console.WriteLine();
        }
    }
}
