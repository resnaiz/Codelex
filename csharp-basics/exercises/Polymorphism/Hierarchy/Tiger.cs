using System;

namespace Hierarchy
{
    class Tiger : Felime
    {
        public Tiger(string animalType, string animalName, double animalWeight, int foodEaten, string livingRegion) : base(animalType, animalName, animalWeight, foodEaten, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("ROARRR!!!");
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                FoodEaten += food.foodQuantity;
            }
            else
            {
                Console.WriteLine("Tigers are not eating that type of food!");
            }
        }
    }
}
