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
        _tiger.Invoking(c => c.Eat(null)).Should().Throw<NullValueException>();
    }

    [Test]
    public void TigerEatTest_GiveIncorrectFood_ThrowsIncorrectFoodReceived()
    {
        var tiger = new Tiger("Tiger", "Kyle", 0.2, 0, "Europa");
        var food = new Vegetable(0);

        Assert.Throws<IncorrectFoodException>(() => tiger.Eat(food));
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

        Assert.That(tiger.AnimalType, Is.EqualTo(animalType));
        Assert.That(tiger.AnimalName, Is.EqualTo(animalName));
        Assert.That(tiger.AnimalWeight, Is.EqualTo(animalWeight));
        Assert.That(tiger.FoodEaten, Is.EqualTo(foodEaten));
        Assert.That(tiger.LivingRegion, Is.EqualTo(livingRegion));
    }

    [Test]
    public void TigerConstructorTest_GiveIncorrectDataForAnimalWeight_ThrowsIncorrectDataReceived()
    {
        string animalType = "Tiger";
        string animalName = "Lee";
        double animalWeight = -3.5;
        int foodEaten = 0;
        string livingRegion = "Home";

        Action act = () => new Tiger(animalType, animalName, animalWeight, foodEaten, livingRegion);

        act.Should().Throw<IncorrectDataException>();
    }
        
    [Test]
    public void TigerConstructorTest_GiveIncorrectDataForFoodEaten_ThrowsIncorrectDataReceived()
    {
        string animalType = "Tiger";
        string animalName = "Lee";
        double animalWeight = 3.5;
        int foodEaten = -1;
        string livingRegion = "Home";

        Action act = () => new Tiger(animalType, animalName, animalWeight, foodEaten, livingRegion);

        act.Should().Throw<IncorrectDataException>();
    }
        
    [Test]
    public void TigerConstructorTest_GiveEmptyAnimalType_ThrowsIncorrectDataReceived()
    {
        string animalType = "";
        string animalName = "Lee";
        double animalWeight = 3.5;
        int foodEaten = 1;
        string livingRegion = "Home";

        Action act = () => new Tiger(animalType, animalName, animalWeight, foodEaten, livingRegion);

        act.Should().Throw<IncorrectDataException>();
    }
        
    [Test]
    public void TigerConstructorTest_GiveEmptyAnimalName_ThrowsIncorrectDataReceived()
    {
        string animalType = "Tiger";
        string animalName = "";
        double animalWeight = 3.5;
        int foodEaten = 1;
        string livingRegion = "Home";

        Action act = () => new Tiger(animalType, animalName, animalWeight, foodEaten, livingRegion);

        act.Should().Throw<IncorrectDataException>();
    }
        
    [Test]
    public void TigerConstructorTest_GiveEmptyLivingRegion_ThrowsIncorrectDataReceived()
    {
        string animalType = "Tiger";
        string animalName = "Lee";
        double animalWeight = 3.5;
        int foodEaten = 1;
        string livingRegion = "";

        Action act = () => new Tiger(animalType, animalName, animalWeight, foodEaten, livingRegion);

        act.Should().Throw<IncorrectDataException>();
    }
}