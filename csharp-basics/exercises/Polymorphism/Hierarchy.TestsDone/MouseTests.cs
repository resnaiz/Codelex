using FluentAssertions;

namespace Hierarchy.TestsDone
{
    public class MouseTests
    {
        private Mouse _mouse;

        [SetUp]
        public void Setup()
        {
            _mouse = new Mouse("Mouse", "Jerry", 12.0, 0, "Europa");
        }

        [Test]
        public void MouseEatTest_GiveValidProduct_ValidProductWasEaten()
        {
            Food? food = new Vegetable(2);
            _mouse.Eat(food);
            Assert.That(_mouse.FoodEaten, Is.EqualTo(2));
        }

        [Test]
        public void MouseEatTest_GiveNullFood_ExceptionNullFoodWasNotEaten()    
        {
            _mouse.Invoking(c => c.Eat(null)).Should().Throw<ExceptionNullFoodWasNotEaten>();
        }

        [Test]
        public void CatEatTest_GiveIncorrectFood_ExceptionIncorrectFoodWasNotEat()
        {
            var mouse = new Mouse("Mouse", "Kyle", 0.2, 0, "Europa");
            var food = new Meat(0);

            Assert.Throws<ExceptionIncorrectFoodWasNotEat>(() => mouse.Eat(food));
        }

        [Test]
        public void MouseConstructorTest_GiveCorrectData_ReceivedCorrectData()
        {
            string animalType = "Mouse";
            string animalName = "Whiskers";
            double animalWeight = 3.5;
            int foodEaten = 0;
            string livingRegion = "Home";

            Mouse mouse = new Mouse(animalType, animalName, animalWeight, foodEaten, livingRegion);

            Assert.AreEqual(animalType, mouse.AnimalType);
            Assert.AreEqual(animalName, mouse.AnimalName);
            Assert.AreEqual(animalWeight, mouse.AnimalWeight);
            Assert.AreEqual(foodEaten, mouse.FoodEaten);
            Assert.AreEqual(livingRegion, mouse.LivingRegion);
        }

        [Test]
        public void MouseConstructorTest_GiveIncorrectData_ReceivedIncorrectData()
        {
            string animalType = "Mouse";
            string animalName = "Lee";
            double animalWeight = -3.5;
            int foodEaten = 0;
            string livingRegion = "Home";

            Action act = () => new Mouse(animalType, animalName, animalWeight, foodEaten, livingRegion);

            act.Should().Throw<ExceptionIncorrectDataReceived>();
        }
        
        [Test]
        public void MouseConstructorTest_GiveIncorrectDataForFoodEaten_ReceivedIncorrectDataForFoodEaten()
        {
            string animalType = "Test";
            string animalName = "Lee";
            double animalWeight = 3.5;
            int foodEaten = -1;
            string livingRegion = "Home";

            Action act = () => new Mouse(animalType, animalName, animalWeight, foodEaten, livingRegion);

            act.Should().Throw<ExceptionIncorrectDataReceived>();
        }

        [Test]
        public void MouseConstructorTest_GiveEmptyAnimalName_ReceivedEmptyDataForAnimalName()
        {
            string animalType = "Test";
            string animalName = "";
            double animalWeight = 3.5;
            int foodEaten = 0;
            string livingRegion = "Home";

            Action act = () => new Mouse(animalType, animalName, animalWeight, foodEaten, livingRegion);

            act.Should().Throw<ExceptionIncorrectDataReceived>();
        }

        [Test]
        public void MouseConstructorTest_GiveEmptyLivingRegion_ReceivedEmptyDataForLivingRegion()
        {
            string animalType = "Test";
            string animalName = "Test2";
            double animalWeight = 3.5;
            int foodEaten = 0;
            string livingRegion = "";

            Action act = () => new Mouse(animalType, animalName, animalWeight, foodEaten, livingRegion);

            act.Should().Throw<ExceptionIncorrectDataReceived>();
        }
        
        [Test]
        public void MouseConstructorTest_GiveEmptyAnimalType_ReceivedEmptyDataForAnimalType()
        {
            string animalType = "";
            string animalName = "Lee";
            double animalWeight = 3.5;
            int foodEaten = 0;
            string livingRegion = "Home";

            Action act = () => new Mouse(animalType, animalName, animalWeight, foodEaten, livingRegion);

            act.Should().Throw<ExceptionIncorrectDataReceived>();
        }
    }
}    