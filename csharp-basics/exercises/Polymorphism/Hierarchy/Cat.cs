using System;

namespace Hierarchy
{
    public class Cat : Felime
    {
        public string Breed { get; set; }

        public Cat(string animalType, string animalName, double animalWeight, int foodEaten, string livingRegion, string breed) : base(animalType, animalName, animalWeight, foodEaten, livingRegion)
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
            if (string.IsNullOrEmpty(breed))
            {
                throw new ExceptionIncorrectDataReceived();
            }
            
            this.Breed = breed;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Moew!!!");
        }

        public override void Eat(Food food)
        {
            if (food is null)
            {
                throw new ExceptionNullFoodWasNotEaten();
            }
            else
            {
                FoodEaten += food.foodQuantity;   
            }
        }
    }
}