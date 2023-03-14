﻿namespace Hierarchy
{
    abstract class Animal
    {
        public string AnimalName { get; set; }
        public string AnimalType { get; set; }
        public double AnimalWeight { get; set; }
        public int FoodEaten { get; set; }

        public Animal(string animalType, string animalName, double animalWeight, int foodEaten) 
        {
            this.AnimalType = animalType;
            this.AnimalWeight = animalWeight;
            this.AnimalName = animalName;
            this.FoodEaten = foodEaten;
        }

        public abstract void MakeSound();

        public abstract void Eat(Food food);
    }
}
