using System;
using System.Collections.Generic;
using System.Linq;

namespace UniqueValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var values = new List<string> { "Hi", "Meow", "Hello", "Meow", "Hi!", "Meow", "Hi", "Bye" };

            var result = values.GroupBy(x => x).Where(I => I.Count() == 1).Select(i => i.Key).ToList();

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
