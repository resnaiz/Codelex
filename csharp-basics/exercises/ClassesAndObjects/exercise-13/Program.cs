using System;

namespace exercise_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Smoothie firstSmoothie = new Smoothie(new string[] { "Banana" });
            Console.WriteLine(string.Join(", ", firstSmoothie.Ingredients));
            Console.WriteLine("£" + firstSmoothie.GetCost());
            Console.WriteLine(firstSmoothie.GetPrice());
            Console.WriteLine(firstSmoothie.GetName());

            Console.WriteLine();
            Smoothie secondSmoothie = new Smoothie(new string[] { "Raspberries", "Strawberries", "Blueberries" });
            Console.WriteLine(string.Join(", ", secondSmoothie.Ingredients));
            Console.WriteLine("£" + secondSmoothie.GetCost());
            Console.WriteLine(secondSmoothie.GetPrice());
            Console.WriteLine(secondSmoothie.GetName());
        }
    }
}
