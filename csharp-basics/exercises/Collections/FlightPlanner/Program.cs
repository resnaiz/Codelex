using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FlightPlanner
{
    class Program
    {
        private const string Path = "../../flights.txt";

        private static void Main(string[] args)
        {
            var readText = File.ReadAllLines(Path);

            List<string> flightInfo = new List<string>();

            Console.WriteLine("What would you like to do: ");
            Console.WriteLine("To display list of the cities press 1: ");
            Console.WriteLine("To exit program press - #");
            var userInput = Console.ReadLine();

            bool returnStartingPoint = false;

            if(userInput == "1")
            {
                Console.WriteLine("To select the starting city press enter");
                Console.ReadKey();

                foreach (var flight in readText)
                {
                    string[] cityInfo = flight.Split('-');

                    string selectedCity = cityInfo[0].Trim();

                    flightInfo.Add(selectedCity);
                }

                Console.WriteLine(string.Join(", ", flightInfo.Distinct()));

                var startingPoint = "";
                List<string> dest = new List<string>();

                while (!returnStartingPoint)
                {
                    Console.WriteLine("From where?");
                    var cityName = Console.ReadLine();

                    if (string.IsNullOrEmpty(startingPoint))
                    {
                        startingPoint = cityName;
                    }

                    dest.Add(cityName);

                    if (startingPoint == dest.Last() && dest.Count() > 1)
                    {
                        returnStartingPoint = true;
                        break;
                    }

                    Console.WriteLine($"Destinations from {cityName}- ");

                    foreach (var flight in readText)
                    {
                        string[] flightRoute = flight.Split(new char[] { '-', '>' });
                        string selectedC = flightRoute[0].Trim();
                        string to = flightRoute[flightRoute.Length - 1].Trim();

                        if (selectedC == cityName)
                        {
                            Console.WriteLine(to);
                        }
                    }
                }
            }
            else if(userInput == "#")
            {
                return;
            }
        }
    }
}
