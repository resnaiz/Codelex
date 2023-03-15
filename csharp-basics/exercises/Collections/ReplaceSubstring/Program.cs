using System;
using System.Linq;

namespace ReplaceSubstring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var words = new[] { "near", "speak", "tonight", "weapon", "customer", "deal", "lawyer" };

            var result = words.Select(x => x.Replace("ea", "*")).ToArray();

            Console.WriteLine(string.Join(", ", result));
            //ToDo: Write a query that replaces 'ea' substring with astersik (*) in given list of words.
            //ToDo: "learn", "current", "deal" →  "l*rn", "current", "d*l"
        }
    }
}
