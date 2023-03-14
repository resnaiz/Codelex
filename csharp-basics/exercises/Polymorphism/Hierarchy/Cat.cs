﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Hierarchy
{
    class Cat : Felime
    {
        public string breed { get; set; }

        public Cat(string animalType, string animalName, double animalWeight, int foodEaten, string livingRegion, string breed) : base(animalType, animalName, animalWeight, foodEaten, livingRegion)
        {
            this.breed = breed;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Moew!!!");
        }

        public override void Eat(Food food)
        {
                FoodEaten += food.foodQuantity;
        }
    }
}
