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
        public void MouseEatTest_GiveNullFood_ThrowsNullValueReceived()    
        {
            _mouse.Invoking(c => c.Eat(null)).Should().Throw<NullValueException>();
        }

        [Test]
        public void CatEatTest_GiveIncorrectFood_ExceptionIncorrectFoodWasNotEat()
        {
            var mouse = new Mouse("Mouse", "Kyle", 0.2, 0, "Europa");
            var food = new Meat(0);

            Assert.Throws<IncorrectFoodException>(() => mouse.Eat(food));
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

            Assert.That(mouse.AnimalType, Is.EqualTo(animalType));
            Assert.That(mouse.AnimalName, Is.EqualTo(animalName));
            Assert.That(mouse.AnimalWeight, Is.EqualTo(animalWeight));
            Assert.That(mouse.FoodEaten, Is.EqualTo(foodEaten));
            Assert.That(mouse.LivingRegion, Is.EqualTo(livingRegion));
        }

        [Test]
        public void MouseConstructorTest_GiveIncorrectData_ThrowsIncorrectDataReceived()
        {
            string animalType = "Mouse";
            string animalName = "Lee";
            double animalWeight = -3.5;
            int foodEaten = 0;
            string livingRegion = "Home";

            Action act = () => new Mouse(animalType, animalName, animalWeight, foodEaten, livingRegion);

            act.Should().Throw<IncorrectDataException>();
        }
        
        [Test]
        public void MouseConstructorTest_GiveIncorrectDataForFoodEaten_ThrowsIncorrectDataReceived()
        {
            string animalType = "Test";
            string animalName = "Lee";
            double animalWeight = 3.5;
            int foodEaten = -1;
            string livingRegion = "Home";

            Action act = () => new Mouse(animalType, animalName, animalWeight, foodEaten, livingRegion);

            act.Should().Throw<IncorrectDataException>();
        }

        [Test]
        public void MouseConstructorTest_GiveEmptyAnimalName_ThrowsIncorrectDataReceived()
        {
            string animalType = "Test";
            string animalName = "";
            double animalWeight = 3.5;
            int foodEaten = 0;
            string livingRegion = "Home";

            Action act = () => new Mouse(animalType, animalName, animalWeight, foodEaten, livingRegion);

            act.Should().Throw<IncorrectDataException>();
        }

        [Test]
        public void MouseConstructorTest_GiveEmptyLivingRegion_ThrowsIncorrectDataReceived()
        {
            string animalType = "Test";
            string animalName = "Test2";
            double animalWeight = 3.5;
            int foodEaten = 0;
            string livingRegion = "";

            Action act = () => new Mouse(animalType, animalName, animalWeight, foodEaten, livingRegion);

            act.Should().Throw<IncorrectDataException>();
        }
        
        [Test]
        public void MouseConstructorTest_GiveEmptyAnimalType_ThrowsIncorrectDataReceived()
        {
            string animalType = "";
            string animalName = "Lee";
            double animalWeight = 3.5;
            int foodEaten = 0;
            string livingRegion = "Home";

            Action act = () => new Mouse(animalType, animalName, animalWeight, foodEaten, livingRegion);

            act.Should().Throw<IncorrectDataException>();
        }
    }
}    