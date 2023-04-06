using System;
using System.Collections.Generic;

namespace ListExercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> colors = new List<string>();

            colors.Add("Red");
            colors.Add("Green");
            colors.Add("Orange");
            colors.Add("White");
            colors.Add("Black");

            Console.WriteLine("List without any changes: ");
            Console.WriteLine(string.Join(",", colors));
            Console.WriteLine();

            colors.Insert(0, "Blue");
            colors.Insert(2, "Pink");

            Console.WriteLine("Changed list:");
            Console.WriteLine(string.Join(",", colors));
            Console.WriteLine();
        }
    }
}
