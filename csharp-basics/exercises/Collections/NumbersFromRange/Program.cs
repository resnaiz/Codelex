using System;
using System.Collections.Generic;
using System.Linq;

namespace NumbersFromRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var numbers = new List<int>();

            while (numbers.Count() < 10)
            {
                numbers.Add(random.Next(1, 100));
            }

            var result = numbers.Where(i => i > 30 && i < 100).ToList();

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
