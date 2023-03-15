using System;
using System.Collections.Generic;
using System.Linq;

namespace DecryptNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cryptedNumbers = new List<string>
            {
                "())(",
                "*$(#&",
                "!!!!!!!!!!",
                "$*^&@!",
                "!)(^&(#@",
                "!)(#&%(*@#%"
            };

            var keyInfo = new Dictionary<int, int>
            {
                {(int) '!', 1 },
                {(int) '@', 2 },
                {(int) '#', 3 },
                {(int) '$', 4 },
                {(int) '%', 5 },
                {(int) '^', 6 },
                {(int) '&', 7 },
                {(int) '*', 8 },
                {(int) '(', 9 },
                {(int) ')', 0 }
            };

            foreach (var s in cryptedNumbers)
            {
                var numbers = s.Select(c => keyInfo.ContainsKey((int)c) ? keyInfo[(int)c] : -1);
                Console.WriteLine(string.Join("", numbers));
            }
            Console.ReadKey();
        }
    }
}
