using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListExercise9
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstList = new List<string>
            {
                "Red",
                "Green",
                "Black",
                "White",
                "Pink"
            };

            Console.WriteLine("First list: ");
            Console.WriteLine(string.Join(",", firstList));
            Console.WriteLine();

            var secondList = new List<string>
            {
                "Red",
                "Green",
                "Black",
                "White",
                "Pink"
            };

            Console.WriteLine("Second list: ");
            Console.WriteLine(string.Join(",", secondList));
            Console.WriteLine();

            Console.WriteLine("Final list view: ");

            var finalList = firstList.Concat(secondList).ToList();

            Console.WriteLine(string.Join(",", finalList));
            Console.WriteLine();
        }
    }
}
