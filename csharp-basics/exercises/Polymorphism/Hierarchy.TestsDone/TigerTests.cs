using FluentAssertions;

namespace Hierarchy.TestsDone;

public class TigerTests
{
    private Tiger _tiger;

    [SetUp]
    public void Setup()
    {
        _tiger = new Tiger("Tiger", "Tiig", 80.0, 0, "Africa");
    }

    [Test]
    public void TigerEatTest_GiveValidProduct_ValidProductWasEaten()
    {
        Food? food = new Meat(2);
        _tiger.Eat(food);
        Assert.That(_tiger.FoodEaten, Is.EqualTo(2));
    }

    [Test]
    public void TigerEatTest_GiveNullFood_ExceptionNullFoodWasNotEaten()
    {
        Action act = () => { _tiger.Eat(null); };

        act.Should().Throw<ExceptionNullFoodWasNotEaten>();
    }

    [Test]
    public void TigerEatTest_GiveIncorrectFood_ExceptionIncorrectFoodWasNotEat()
    {
        var tiger = new Tiger("Tiger", "Kyle", 0.2, 0, "Europa");
        var food = new Vegetable(0);

        Assert.Throws<ExceptionIncorrectFoodWasNotEat>(() => tiger.Eat(food));
    }

    [Test]
    public void TigerConstructorTest_GiveCorrectData_ReceivedCorrectData()
    {
        string animalType = "Tiger";
        string animalName = "Whiskers";
        double animalWeight = 3.5;
        int foodEaten = 0;
        string livingRegion = "Home";

        Tiger tiger = new Tiger(animalType, animalName, animalWeight, foodEaten, livingRegion);

        Assert.AreEqual(animalType, tiger.AnimalType);
        Assert.AreEqual(animalName, tiger.AnimalName);
        Assert.AreEqual(animalWeight, tiger.AnimalWeight);
        Assert.AreEqual(foodEaten, tiger.FoodEaten);
        Assert.AreEqual(livingRegion, tiger.LivingRegion);
    }

    [Test]
    public void TigerConstructorTest_GiveIncorrectDataForAnimalWeight_ReceivedIncorrectDataForAnimalWeight()
    {
        string animalType = "Tiger";
        string animalName = "Lee";
        double animalWeight = -3.5;
        int foodEaten = 0;
        string livingRegion = "Home";

        Action act = () => new Tiger(animalType, animalName, animalWeight, foodEaten, livingRegion);

        act.Should().Throw<ExceptionIncorrectDataReceived>();
    }
        
    [Test]
    public void TigerConstructorTest_GiveIncorrectDataForFoodEaten_ReceivedIncorrectDataForFoodEaten()
    {
        string animalType = "Tiger";
        string animalName = "Lee";
        double animalWeight = 3.5;
        int foodEaten = -1;
        string livingRegion = "Home";

        Action act = () => new Tiger(animalType, animalName, animalWeight, foodEaten, livingRegion);

        act.Should().Throw<ExceptionIncorrectDataReceived>();
    }
        
    [Test]
    public void TigerConstructorTest_GiveEmptyAnimalType_ReceivedEmptyAnimalType()
    {
        string animalType = "";
        string animalName = "Lee";
        double animalWeight = 3.5;
        int foodEaten = 1;
        string livingRegion = "Home";

        Action act = () => new Tiger(animalType, animalName, animalWeight, foodEaten, livingRegion);

        act.Should().Throw<ExceptionIncorrectDataReceived>();
    }
        
    [Test]
    public void TigerConstructorTest_GiveEmptyAnimalName_ReceivedEmptyAnimalName()
    {
        string animalType = "Tiger";
        string animalName = "";
        double animalWeight = 3.5;
        int foodEaten = 1;
        string livingRegion = "Home";

        Action act = () => new Tiger(animalType, animalName, animalWeight, foodEaten, livingRegion);

        act.Should().Throw<ExceptionIncorrectDataReceived>();
    }
        
    [Test]
    public void TigerConstructorTest_GiveEmptyLivingRegion_ReceivedEmptyLivingRegion()
    {
        string animalType = "Tiger";
        string animalName = "Lee";
        double animalWeight = 3.5;
        int foodEaten = 1;
        string livingRegion = "";

        Action act = () => new Tiger(animalType, animalName, animalWeight, foodEaten, livingRegion);

        act.Should().Throw<ExceptionIncorrectDataReceived>();
    }
}