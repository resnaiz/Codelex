using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        private const string Path = "../../lear.txt";

        static void Main(string[] args)
        {
            var readText = File.ReadAllText(Path);

            int counterForLine = readText.Split('\n').Length;

            int countWords = readText.Split().Count(word => !string.IsNullOrEmpty(word) && char.IsLetterOrDigit(word[0]));

            int countChars = readText.Length;

            Console.WriteLine($"Lines = {counterForLine}");
            Console.WriteLine($"Words = {countWords}");
            Console.WriteLine($"Chars = {countChars}");
        }
    }
}
