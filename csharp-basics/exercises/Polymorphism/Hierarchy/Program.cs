using System;
using System.Collections.Generic;
using System.Globalization;

namespace Hierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            Console.WriteLine("Enter animal: ");
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] animalInfo = input.Split();
                string animalType = animalInfo[0];
                string animalName = animalInfo[1];
                double animalWeight = double.Parse(animalInfo[2], CultureInfo.InvariantCulture);

                Animal animal;

                switch (animalType)
                {
                    case "Mouse":
                        Console.WriteLine("Enter living region: ");
                        var livingRegion = Console.ReadLine();
                        animal = new Mouse(animalType, animalName, animalWeight, 0, livingRegion);
                        break;
                    case "Cat":
                        Console.WriteLine("Enter cat breed: ");
                        var catBreed = Console.ReadLine();
                        Console.WriteLine("Enter living region: ");
                        var livRegion = Console.ReadLine();
                        animal = new Cat(animalType, animalName, animalWeight, 0, livRegion, catBreed);
                        break;
                    case "Tiger":
                        Console.WriteLine("Enter living region: ");
                        var livinRegion = Console.ReadLine();
                        animal = new Tiger(animalType, animalName, animalWeight, 0, livinRegion);
                        break;
                    case "Zebra":
                        Console.WriteLine("Enter living region: ");
                        var lRegion = Console.ReadLine();
                        animal = new Zebra(animalType, animalName, animalWeight, 0, lRegion);
                        break;
                    default:
                        animal = new Mouse(animalType, animalName, animalWeight, 0, "");
                        break;
                }

                animal.MakeSound();

                Console.WriteLine("Enter food quantity: ");
                string[] foodInfo = Console.ReadLine().Split();

                Food food;

                switch (foodInfo[0])
                {
                    case "Vegetable":
                        food = new Vegetable(int.Parse(foodInfo[1]));
                        break;
                    case "Meat":
                        food = new Meat(int.Parse(foodInfo[1]));
                        break;
                    default:
                        food = new Vegetable(1);
                        break;
                }

                animal.Eat(food);
                animals.Add(animal);

                Console.WriteLine("Enter Animal: ");    
                input = Console.ReadLine();
            }
        }
    }
}