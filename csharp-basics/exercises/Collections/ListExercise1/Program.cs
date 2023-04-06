using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListExercise1
{
    class Program
    {
        private static void Main(string[] args)
        {
            List<string> myList = new List<string>();

            myList.Add("Red");
            myList.Add("Blue");
            myList.Add("Pink");
            myList.Add("Yellow");
            myList.Add("Black");

            foreach(string oneItem in myList)
            {
                Console.WriteLine(oneItem);
            }

            Console.WriteLine();
        }
    }
}
