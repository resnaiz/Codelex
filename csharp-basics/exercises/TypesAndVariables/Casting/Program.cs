﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casting
{
    class Program
    {
        static void Main(string[] args)
        {
            First();
            Second();
            Console.ReadKey();
        }

        static void First()
        {
            string a = "1";
            int b = 2;
            int c = 3;
            double d = 4;
            float e = 5;

            int sum = int.Parse(a) + b + c + (int)d + (int)e;
            Console.WriteLine(sum);
        }

        static void Second()
        {
            string a = "1";
            int b = 2;
            int c = 3;
            decimal d = 4.2m;
            decimal e = 5.3m;

            decimal sum = decimal.Parse(a) + b + c + d + e;
            Console.WriteLine(sum);
        }
    }
}
