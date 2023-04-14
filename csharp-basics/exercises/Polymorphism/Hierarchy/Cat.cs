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
            if (string.IsNullOrEmpty(breed))
            {
                throw new IncorrectDataException();
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
                throw new NullValueException();
            }
            else
            {
                FoodEaten += food.foodQuantity;   
            }
        }
    }
}