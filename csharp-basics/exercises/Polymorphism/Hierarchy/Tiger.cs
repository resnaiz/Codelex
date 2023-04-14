using System;

namespace Hierarchy
{
    public class Tiger : Felime
    {
        public Tiger(string animalType, string animalName, double animalWeight, int foodEaten, string livingRegion) : base(animalType, animalName, animalWeight, foodEaten, livingRegion)
        {
            if (string.IsNullOrEmpty(animalType))
            {
                throw new IncorrectDataException();
            }
            if (string.IsNullOrEmpty(animalName))
            {
                throw new IncorrectDataException();
            }
            if (animalWeight <= 0)
            {
                throw new IncorrectDataException();
            }
            if (foodEaten < 0)
            {
                throw new IncorrectDataException();
            }
            if (string.IsNullOrEmpty(livingRegion))
            {
                throw new IncorrectDataException();
            }
        }

        public override void MakeSound()
        {
            Console.WriteLine("ROARRR!!!");
        }

        public override void Eat(Food food)
        {
            if (food == null)
            {
                throw new NullValueException();
            }
            
            if (food is Meat)
            {
                FoodEaten += food.foodQuantity;
            }
            else
            {
                throw new IncorrectFoodException();
            }
        }
    }
}