using System;

namespace Hierarchy
{
    class Zebra : Mammal
    {
        public Zebra(string animalType, string animalName, double animalWeight, int foodEaten, string livingRegion) : base(animalType, animalName, animalWeight, foodEaten, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Snort!!!");
        }

        public override void Eat(Food food)
        {
            if (food is Vegetable)
            {
                FoodEaten += food.foodQuantity;
            }
            else
            {
                Console.WriteLine($"Zebras are not eating that type of food!");
            }
        }
    }
}
