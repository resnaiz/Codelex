using System;
using System.Collections.Generic;

namespace Exercise1
{
    class Program
    {
        private static void Main(string[] args)
        {
            string[] array = { "Audi", "BMW", "Honda", "Mercedes", "VolksWagen", "Mercedes", "Tesla" };
            
            List<string> newList = new List<string>();
            HashSet<string> newSet = new HashSet<string>();
            Dictionary<string, string> newDic = new Dictionary<string, string>
            {
                { "Audi", "Germany" },
                { "BMW", "Germany" },
                { "Honda", "Japan" },
                { "Mercedes", "Germany" },
                { "VolksWagen", "Germany" },
                { "Tesla", "USA" }
            };


            for (int i = 0; i < array.Length; i++)
            {
                newList.Add(array[i]);
                newSet.Add(array[i]);
            }

            foreach(string item in newList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            foreach (string otherItem in newSet)
            {
                Console.WriteLine(otherItem);
            }

            Console.WriteLine();

            foreach (KeyValuePair<string, string> oneCar in newDic)
            {
                Console.WriteLine($"{oneCar.Value}");
            }

            Console.WriteLine();
        }
    }
}
