namespace Hierarchy
{
    abstract class Mammal : Animal
    {
        public string LivingRegion { get; set; }

        public Mammal(string animalType, string animalName, double animalWeight, int foodEaten, string livingRegion) : base(animalType, animalName, animalWeight, foodEaten)
        {
            LivingRegion = livingRegion;
        }
    }
}
