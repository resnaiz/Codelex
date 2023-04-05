using FluentAssertions;

namespace Hierarchy.TestsDone
{

    public class ZebraTests
    {
        private Zebra _zebra;
        
        [SetUp]
        public void Setup()
        {
            _zebra = new Zebra("Zebra", "Zeze", 120.0, 0, "Africa");

        }

        [Test]
        public void ZebraEatTest_GiveValidProduct_ValidProductWasEaten()
        {
            Food? food = new Vegetable(2);
            _zebra.Eat(food);
            Assert.That(_zebra.FoodEaten, Is.EqualTo(2));
        }

        [Test]
        public void ZebraEatTest_GiveNullFood_ExceptionNullFoodWasNotEaten()
        {
            _zebra.Invoking(c => c.Eat(null)).Should().Throw<ExceptionNullFoodWasNotEaten>();
        }

        [Test]
        public void ZebraEatTest_GiveIncorrectFood_ExceptionIncorrectFoodWasNotEat()
        {
            var zebra = new Zebra("Zebra", "Kyle", 0.2, 0, "Europa");
            var food = new Meat(0);

            Assert.Throws<ExceptionIncorrectFoodWasNotEat>(() => zebra.Eat(food));
        }

        [Test]
        public void ZebraConstructorTest_GiveCorrectData_ReceivedCorrectData()
        {
            string animalType = "Zebra";
            string animalName = "Whiskers";
            double animalWeight = 3.5;
            int foodEaten = 0;
            string livingRegion = "Home";

            Zebra zebra = new Zebra(animalType, animalName, animalWeight, foodEaten, livingRegion);

            Assert.AreEqual(animalType, zebra.AnimalType);
            Assert.AreEqual(animalName, zebra.AnimalName);
            Assert.AreEqual(animalWeight, zebra.AnimalWeight);
            Assert.AreEqual(foodEaten, zebra.FoodEaten);
            Assert.AreEqual(livingRegion, zebra.LivingRegion);
        }

        [Test]
        public void ZebraConstructorTest_GiveIncorrectData_ReceivedIncorrectData()
        {
            string animalType = "Zebra";
            string animalName = "Lee";
            double animalWeight = -3.5;
            int foodEaten = 0;
            string livingRegion = "Home";

            Action act = () => new Zebra(animalType, animalName, animalWeight, foodEaten, livingRegion);

            act.Should().Throw<ExceptionIncorrectDataReceived>();
        }
        
        [Test]
        public void ZebraConstructorTest_GiveIncorrectDataForFoodEaten_ReceivedIncorrectDataForFoodEaten()
        {
            string animalType = "Zebra";
            string animalName = "Lee";
            double animalWeight = 3.5;
            int foodEaten = -1;
            string livingRegion = "Home";

            Action act = () => new Zebra(animalType, animalName, animalWeight, foodEaten, livingRegion);

            act.Should().Throw<ExceptionIncorrectDataReceived>();
        }
        
        [Test]
        public void ZebraConstructorTest_GiveEmptyAnimalType_ReceivedEmptyAnimalType()
        {
            string animalType = "";
            string animalName = "Lee";
            double animalWeight = 3.5;
            int foodEaten = 0;
            string livingRegion = "Home";

            Action act = () => new Zebra(animalType, animalName, animalWeight, foodEaten, livingRegion);

            act.Should().Throw<ExceptionIncorrectDataReceived>();
        }
        
        [Test]
        public void ZebraConstructorTest_GiveEmptyAnimalName_ReceivedEmptyAnimalName()
        {
            string animalType = "Zebra";
            string animalName = "";
            double animalWeight = 3.5;
            int foodEaten = 0;
            string livingRegion = "Home";

            Action act = () => new Zebra(animalType, animalName, animalWeight, foodEaten, livingRegion);

            act.Should().Throw<ExceptionIncorrectDataReceived>();
        }
        
        [Test]
        public void ZebraConstructorTest_GiveEmptyLivingRegion_ReceivedEmptyLivingRegion()
        {
            string animalType = "Zebra";
            string animalName = "test";
            double animalWeight = 3.5;
            int foodEaten = 0;
            string livingRegion = "";

            Action act = () => new Zebra(animalType, animalName, animalWeight, foodEaten, livingRegion);

            act.Should().Throw<ExceptionIncorrectDataReceived>();
        }
    }
}    