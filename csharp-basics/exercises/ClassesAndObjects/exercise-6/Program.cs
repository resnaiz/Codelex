using System;

namespace Exercise_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog Reksis = new Dog("Reksis", "Male");
            Dog Max = new Dog("Max", "Male");
            Dog Rocky = new Dog("Rocky", "Male");
            Dog Sparky = new Dog("Sparky", "Male");
            Dog Buster = new Dog("Buster", "Male");
            Dog Sam = new Dog("Sam", "Male");
            Dog Lady = new Dog("Lady", "Female");
            Dog Molly = new Dog("Molly", "Female");
            Dog Coco = new Dog("Coco", "Female");

            Max.SetMother("Lady");
            Max.SetFather("Rocky");

            Coco.SetMother("Molly");
            Coco.SetFather("Buster");

            Rocky.SetMother("Molly");
            Rocky.SetFather("Sam");

            Buster.SetMother("Lady");
            Buster.SetFather("Sparky");

            Console.WriteLine(Coco.FathersName());
            Console.WriteLine(Sparky.FathersName());
            Console.WriteLine(Coco.HasSameMotherAs(Rocky));
        }
    }
}