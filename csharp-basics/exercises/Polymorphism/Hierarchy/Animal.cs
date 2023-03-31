namespace Hierarchy
{
    public abstract class Animal
    {
        public string AnimalName { get; set; }
        public string AnimalType { get; set; }
        public double AnimalWeight { get; set; }
        public int FoodEaten { get; set; }

        public Animal(string animalType, string animalName, double animalWeight, int foodEaten) 
        {
            AnimalType = animalType;
            AnimalWeight = animalWeight;
            AnimalName = animalName;
            FoodEaten = foodEaten;
        }

        public abstract void MakeSound();

        public abstract void Eat(Food? food);
    }
}