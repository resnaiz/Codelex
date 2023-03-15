using System;
using System.IO;
using System.Linq;

namespace Histogram
{
    class Program
    {
        private const string Path = "../../midtermscores.txt";

        private static void Main(string[] args)
        {
            var readText = File.ReadAllText(Path);

            var grades = readText.Split(' ').ToList();

            Console.WriteLine($"00-09: {new string('*', grades.Count(s => int.Parse(s) >= 0 && int.Parse(s) < 10))}");
            Console.WriteLine($"10-19: {new string('*', grades.Count(s => int.Parse(s) > 9 && int.Parse(s) < 20))}");
            Console.WriteLine($"20-29: {new string('*', grades.Count(s => int.Parse(s) > 19 && int.Parse(s) < 30))}");
            Console.WriteLine($"30-39: {new string('*', grades.Count(s => int.Parse(s) > 29 && int.Parse(s) < 40))}");
            Console.WriteLine($"40-49: {new string('*', grades.Count(s => int.Parse(s) > 39 && int.Parse(s) < 50))}");
            Console.WriteLine($"50-59: {new string('*', grades.Count(s => int.Parse(s) > 49 && int.Parse(s) < 60))}");
            Console.WriteLine($"60-69: {new string('*', grades.Count(s => int.Parse(s) > 59 && int.Parse(s) < 70))}");
            Console.WriteLine($"70-79: {new string('*', grades.Count(s => int.Parse(s) > 69 && int.Parse(s) < 80))}");
            Console.WriteLine($"80-89: {new string('*', grades.Count(s => int.Parse(s) > 79 && int.Parse(s) < 90))}");
            Console.WriteLine($"90-99: {new string('*', grades.Count(s => int.Parse(s) > 89 && int.Parse(s) < 100))}");
            Console.WriteLine(($"100: {new string('*', grades.Count(s => int.Parse(s) == 100))}").PadLeft(8));

            Console.ReadKey();
        }
    }
}
