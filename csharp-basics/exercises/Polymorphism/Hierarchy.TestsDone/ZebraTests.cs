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
        public void ZebraEatTest_GiveNullFood_ThrowsExceptionNullFood()
        {
            _zebra.Invoking(c => c.Eat(null)).Should().Throw<NullValueException>();
        }

        [Test]
        public void ZebraEatTest_GiveIncorrectFood_ThrowsExceptionIncorrectFood()
        {
            var zebra = new Zebra("Zebra", "Kyle", 0.2, 0, "Europa");
            var food = new Meat(0);

            Assert.Throws<IncorrectFoodException>(() => zebra.Eat(food));
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

            Assert.That(zebra.AnimalType, Is.EqualTo(animalType));
            Assert.That(zebra.AnimalName, Is.EqualTo(animalName));
            Assert.That(zebra.AnimalWeight, Is.EqualTo(animalWeight));
            Assert.That(zebra.FoodEaten, Is.EqualTo(foodEaten));
            Assert.That(zebra.LivingRegion, Is.EqualTo(livingRegion));
        }

        [Test]
        public void ZebraConstructorTest_GiveIncorrectData_ThrowsIncorrectDataReceived()
        {
            string animalType = "Zebra";
            string animalName = "Lee";
            double animalWeight = -3.5;
            int foodEaten = 0;
            string livingRegion = "Home";

            Action act = () => new Zebra(animalType, animalName, animalWeight, foodEaten, livingRegion);

            act.Should().Throw<IncorrectDataException>();
        }
        
        [Test]
        public void ZebraConstructorTest_GiveIncorrectDataForFoodEaten_ThrowsIncorrectDataReceived()
        {
            string animalType = "Zebra";
            string animalName = "Lee";
            double animalWeight = 3.5;
            int foodEaten = -1;
            string livingRegion = "Home";

            Action act = () => new Zebra(animalType, animalName, animalWeight, foodEaten, livingRegion);

            act.Should().Throw<IncorrectDataException>();
        }
        
        [Test]
        public void ZebraConstructorTest_GiveEmptyAnimalType_ThrowsIncorrectDataReceived()
        {
            string animalType = "";
            string animalName = "Lee";
            double animalWeight = 3.5;
            int foodEaten = 0;
            string livingRegion = "Home";

            Action act = () => new Zebra(animalType, animalName, animalWeight, foodEaten, livingRegion);

            act.Should().Throw<IncorrectDataException>();
        }
        
        [Test]
        public void ZebraConstructorTest_GiveEmptyAnimalName_ThrowsIncorrectDataReceived()
        {
            string animalType = "Zebra";
            string animalName = "";
            double animalWeight = 3.5;
            int foodEaten = 0;
            string livingRegion = "Home";

            Action act = () => new Zebra(animalType, animalName, animalWeight, foodEaten, livingRegion);

            act.Should().Throw<IncorrectDataException>();
        }
        
        [Test]
        public void ZebraConstructorTest_GiveEmptyLivingRegion_ThrowsIncorrectDataReceived()
        {
            string animalType = "Zebra";
            string animalName = "test";
            double animalWeight = 3.5;
            int foodEaten = 0;
            string livingRegion = "";

            Action act = () => new Zebra(animalType, animalName, animalWeight, foodEaten, livingRegion);

            act.Should().Throw<IncorrectDataException>();
        }
    }
}    