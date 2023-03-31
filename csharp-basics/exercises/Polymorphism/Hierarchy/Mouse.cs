using System;

namespace Hierarchy
{
    class Mouse : Mammal
    {
        public Mouse(string animalType, string animalName, double animalWeight, int foodEaten, string livingRegion) : base(animalType, animalName, animalWeight, foodEaten, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Squeak!!!");
        }

        public override void Eat(Food food)
        {
            if (food is Vegetable)
            {
                FoodEaten += food.foodQuantity;
            }
            else
            {
                Console.WriteLine("Mouse are not eating that type of food!");
            }
        }
    }
}
