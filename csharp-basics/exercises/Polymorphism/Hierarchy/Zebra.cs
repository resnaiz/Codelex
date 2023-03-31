using System;

namespace Hierarchy
{
    public class Zebra : Mammal
    {
        public Zebra(string animalType, string animalName, double animalWeight, int foodEaten, string livingRegion) : base(animalType, animalName, animalWeight, foodEaten, livingRegion)
        {
            if (string.IsNullOrEmpty(animalType))
            {
                throw new ExceptionIncorrectDataReceived();
            }
            if (string.IsNullOrEmpty(animalName))
            {
                throw new ExceptionIncorrectDataReceived();
            }
            if (animalWeight <= 0)
            {
                throw new ExceptionIncorrectDataReceived();
            }
            if (foodEaten < 0)
            {
                throw new ExceptionIncorrectDataReceived();
            }
            if (string.IsNullOrEmpty(livingRegion))
            {
                throw new ExceptionIncorrectDataReceived();
            }
        }

        public override void MakeSound()
        {
            Console.WriteLine("Snort!!!");
        }

        public override void Eat(Food? food)
        {
            if (food == null)
            {
                throw new ExceptionNullFoodWasNotEaten();
            }
            
            if (food is Vegetable)
            {
                FoodEaten += food.foodQuantity;
            }
            else
            {
                throw new ExceptionIncorrectFoodWasNotEat();
            }
        }
    }
}