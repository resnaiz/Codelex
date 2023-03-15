using System;
using System.Collections.Generic;

namespace exercise_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> newSet = new HashSet<string>();

            newSet.Add("A");
            newSet.Add("C");
            newSet.Add("F");
            newSet.Add("H");
            newSet.Add("Y");

            foreach(string word in newSet)
            {
                Console.WriteLine(word);
            }

            newSet.Clear();
            
            Console.WriteLine();  
            Console.WriteLine(newSet.Add("A"));
            Console.WriteLine(newSet.Add("A"));
            Console.WriteLine(newSet.Add("C"));
            Console.WriteLine(newSet.Add("B"));
        }
    }
}
