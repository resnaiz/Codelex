using System;
using System.Collections.Generic;

namespace ListExercise6
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

            Console.WriteLine("List without changes: ");
            Console.WriteLine(string.Join(",", colors));
            Console.WriteLine();

            colors.Remove("Orange");

            Console.WriteLine("After removing third element from the list:");
            Console.WriteLine(string.Join(",", colors));
            Console.WriteLine();
        }
    }
}
