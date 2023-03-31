using FluentAssertions;

namespace Hierarchy.TestsDone
{
    public class CatTests
    {
        private Cat _cat;

        [SetUp]
        public void Setup()
        {
            _cat = new Cat("Cat", "Mike", 2.0, 0, "Europa", "Persian");
        }
        
        [Test]
        public void CatEatTest_GiveValidProduct_ValidProductWasEaten()
        {
            Food? food = new Vegetable(2);
            _cat.Eat(food);
            Assert.That(_cat.FoodEaten, Is.EqualTo(2));
        }

        [Test]
        public void CatEatTest_GiveNullFood_ExceptionNullFoodWasNotEaten()
        {
            Action act = () =>
            {
                _cat.Eat(null);
            };

            act.Should().Throw<ExceptionNullFoodWasNotEaten>();
        }

        [Test]
        public void CatConstructorTest_GiveCorrectData_ReceivedCorrectData()
        {
            string animalType = "Felime";
            string animalName = "Whiskers";
            double animalWeight = 3.5;
            int foodEaten = 0;
            string livingRegion = "Home";
            string breed = "Persian";

            Cat cat = new Cat(animalType, animalName, animalWeight, foodEaten, livingRegion, breed);

            Assert.That(cat.AnimalType, Is.EqualTo(animalType));
            Assert.That(cat.AnimalName, Is.EqualTo(animalName));
            Assert.That(cat.AnimalWeight, Is.EqualTo(animalWeight));
            Assert.That(cat.FoodEaten, Is.EqualTo(foodEaten));
            Assert.That(cat.LivingRegion, Is.EqualTo(livingRegion));
            Assert.That(cat.Breed, Is.EqualTo(breed));
        }

        [Test]
        public void CatConstructorTest_GiveIncorrectData_ReceivedIncorrectData()
        {
            string animalType = "Cat";
            string animalName = "Whiskers";
            double animalWeight = -3.5;
            int foodEaten = 0;
            string livingRegion = "Home";
            string breed = "Persian";
            
            Action act = () => new Cat(animalType, animalName, animalWeight, foodEaten, livingRegion, breed);
            
            act.Should().Throw<ExceptionIncorrectDataReceived>();
        }
        
        [Test]
        public void CatConstructorTest_GiveEmptyBreed_ReceivedIncorrectData()
        {
            string animalType = "Felime";
            string animalName = "Whiskers";
            double animalWeight = 3.5;
            int foodEaten = 0;
            string livingRegion = "Home";
            string breed = "";
            
            Action act = () => new Cat(animalType, animalName, animalWeight, foodEaten, livingRegion, breed);

            act.Should().Throw<ExceptionIncorrectDataReceived>();
        }
        
        [Test]
        public void CatConstructorTest_GiveNullableData_ReceivedIncorrectData()
        {
            string animalType = null;
            string animalName = null;
            double animalWeight = 3.5;
            int foodEaten = 0;
            string livingRegion = null;
            string breed = null;
            
            Action act = () => new Cat(animalType, animalName, animalWeight, foodEaten, livingRegion, breed);

            act.Should().Throw<ExceptionIncorrectDataReceived>();
        }
        
        [Test]
        public void CatConstructorTest_GiveIncorrectFoodEaten_ReceivedIncorrectDataForFoodEaten()
        {
            string animalType = "Cat";
            string animalName = "Whiskers";
            double animalWeight = 3.5;
            int foodEaten = -1;
            string livingRegion = "Home";
            string breed = "Persian";
            
            Action act = () => new Cat(animalType, animalName, animalWeight, foodEaten, livingRegion, breed);
            
            act.Should().Throw<ExceptionIncorrectDataReceived>();
        }
        
        [Test]
        public void CatConstructorTest_GiveEmptyAnimalType_ReceivedIncorrectDataForAnimalType()
        {
            string animalType = "";
            string animalName = "Whiskers";
            double animalWeight = 3.5;
            int foodEaten = 1;
            string livingRegion = "Home";
            string breed = "Persian";
            
            Action act = () => new Cat(animalType, animalName, animalWeight, foodEaten, livingRegion, breed);
            
            act.Should().Throw<ExceptionIncorrectDataReceived>();
        }
        
        [Test]
        public void CatConstructorTest_GiveEmptyAnimalName_ReceivedIncorrectDataForAnimalName()
        {
            string animalType = "Test";
            string animalName = "";
            double animalWeight = 3.5;
            int foodEaten = 1;
            string livingRegion = "Home";
            string breed = "Persian";
            
            Action act = () => new Cat(animalType, animalName, animalWeight, foodEaten, livingRegion, breed);
            
            act.Should().Throw<ExceptionIncorrectDataReceived>();
        }
        
        [Test]
        public void CatConstructorTest_GiveEmptyLivingRegion_ReceivedIncorrectDataForLivingRegion()
        {
            string animalType = "Test";
            string animalName = "Whiskers";
            double animalWeight = 3.5;
            int foodEaten = 1;
            string livingRegion = "";
            string breed = "Persian";
            
            Action act = () => new Cat(animalType, animalName, animalWeight, foodEaten, livingRegion, breed);
            
            act.Should().Throw<ExceptionIncorrectDataReceived>();
        }
    } 
}