using System;
using System.Collections.Generic;

namespace ListExercise11
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listForTeams = new List<string>
            {
                { "FC Barcelona" },
                { "Real Madrid" },
                { "Atletico Madrid" },
                { "Valencia" },
                { "Espanyol" },
                { "Real Betis" },
                { "Celta" },
                { "Sevilla" },
                { "Villarreal" },
                { "Girona" }
            };

            listForTeams.Insert(4, "Betis");
            int lastPos = listForTeams.Count - 1;
            listForTeams[lastPos] = "Real Sociedad";
            listForTeams.Sort();

            if(listForTeams.Contains("Foobar")) 
            {
                Console.WriteLine("Contains!");
            }
            else
            {
                Console.WriteLine("Element not found!");
            }

            Console.WriteLine();

            for(int i = 0; i < listForTeams.Count; i++)
            {
                Console.WriteLine(listForTeams[i]);
            }

            Console.WriteLine();
        }
    }
}
