namespace Scooter.Test;

public class RentalCompanyTests
{
    private ScooterService _scooterService;
    private RentalCompany _rentalCompany;

    [SetUp]
    public void Setup()
    {
        _scooterService = new ScooterService();
        _rentalCompany = new RentalCompany("Codelex", _scooterService);
    }

    [Test]
    public void StartRent_CorrectIdGiven_StartedRent()
    {
        _scooterService.AddScooter("1", 1m);
        _rentalCompany.StartRent("1");

        Assert.That(_scooterService.GetScooterById("1").IsRented, Is.True);
    }

    [Test]
    public void StartRent_GivenNullId_ThrowExceptionInvalidIdException()
    {
        Assert.Throws<InvalidIdException>(() => _rentalCompany.StartRent(null));
    }

    [Test]
    public void StartRent_GivenEmptyId_ThrowExceptionInvalidIdException()
    {
        Assert.Throws<InvalidIdException>(() => _rentalCompany.StartRent(""));
    }

    [Test]
    public void StartRent_GivenRentedScooter_ThrowExceptionScooterIsRented()
    {
        _scooterService.AddScooter("1", 1m);
        _rentalCompany.StartRent("1");

        Assert.Throws<ScooterIsRentedException>(() => _rentalCompany.StartRent("1"));
    }

    //endrent

    [Test]
    public void EndRent_CorrectIdGiven_EndRent()
    {
        _scooterService.AddScooter("1", 1m);
        _rentalCompany.StartRent("1");
        _rentalCompany.EndRent("1");

        Assert.That(_scooterService.GetScooterById("1").IsRented, Is.False);
    }

    [Test]
    public void EndRent_GivenNullId_ThrowExceptionInvalidIdException()
    {
        Assert.Throws<InvalidIdException>(() => _rentalCompany.EndRent(null));
    }

    [Test]
    public void EndRent_GivenEmptyId_ThrowExceptionInvalidIdException()
    {
        Assert.Throws<InvalidIdException>(() => _rentalCompany.EndRent(""));
    }

    [Test]
    public void EndRent_GivenNotRentedScooter_ThrowExceptionScooterIsNotRented()
    {
        _scooterService.AddScooter("1", 1m);
        _rentalCompany.StartRent("1");
        _rentalCompany.EndRent("1");

        Assert.Throws<ScooterIsNotRentedException>(() => _rentalCompany.EndRent("1"));
    }

    // CalculateIncome

    [Test]
    public void CalculateIncome_WithNoAnyIncome_ReturnedCorrect()
    {
        var price = _rentalCompany.CalculateIncome(null, false);

        Assert.That(price, Is.EqualTo(0));
    }
    
    [Test]
    public void CalculateIncome_MultipleRentals_ReturnsCorrectIncome()
    {
        var rentalCompany = new RentalCompany("Test Company", _scooterService);
        _scooterService.AddScooter("1", 0.5m);
        _scooterService.AddScooter("2", 0.7m);
        _scooterService.AddScooter("3", 0.9m);

        rentalCompany.StartRent("1");
        Thread.Sleep(1000);
        var rentalPrice1 = rentalCompany.EndRent("1");

        rentalCompany.StartRent("2");
        Thread.Sleep(2000);
        var rentalPrice2 = rentalCompany.EndRent("2");

        rentalCompany.StartRent("3");
        Thread.Sleep(3000);
        var rentalPrice3 = rentalCompany.EndRent("3");

        var result = rentalCompany.CalculateIncome(null, true);
        var expected = rentalPrice1 + rentalPrice2 + rentalPrice3;

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CalculateIncome_IncludeNotCompletedRentals_ReturnsCorrectIncome()
    {
        var rentalCompany = new RentalCompany("Test Company", _scooterService);
        _scooterService.AddScooter("1", 0.5m);
        rentalCompany.StartRent("1");
        Thread.Sleep(1000);
        var rentalPrice1 = rentalCompany.EndRent("1");

        var result = rentalCompany.CalculateIncome(null, true);

        Assert.That(result, Is.EqualTo(rentalPrice1));
    }

    [Test]
    public void CalculateIncome_ExcludeNotCompletedRentals_ReturnsCorrectIncome()
    {
        var rentalCompany = new RentalCompany("Test Company", _scooterService);
        _scooterService.AddScooter("1", 0.5m);
        rentalCompany.StartRent("1");
        Thread.Sleep(1000);

        var result = rentalCompany.CalculateIncome(null, false);

        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void CalculateIncome_FilterByYear_ReturnsIncomeOnlyForGivenYear()
    {
        var rentalCompany = new RentalCompany("Test Company", _scooterService);
        _scooterService.AddScooter("1", 0.5m);
        _scooterService.AddScooter("2", 0.5m);
        _scooterService.AddScooter("3", 0.5m);
        rentalCompany.StartRent("1");
        Thread.Sleep(1000);
        var rentalPrice1 = rentalCompany.EndRent("1");
        rentalCompany.StartRent("2");
        Thread.Sleep(1000);
        var rentalPrice2 = rentalCompany.EndRent("2");
        rentalCompany.StartRent("3");
        Thread.Sleep(1000);
        var rentalPrice3 = rentalCompany.EndRent("3");

        var result = rentalCompany.CalculateIncome(DateTime.Now.Year, true);

        Assert.That(result, Is.EqualTo(rentalPrice1 + rentalPrice2 + rentalPrice3));

        result = rentalCompany.CalculateIncome(DateTime.Now.Year - 1, true);

        Assert.That(result, Is.EqualTo(0));
    }
    
    [Test]
    public void CalculateIncome_ExcludeIncompleteRentals_ReturnsIncomeOnlyForCompleteRentals()
    {
        var rentalCompany = new RentalCompany("Test Company", _scooterService);
        _scooterService.AddScooter("1", 1m);
        _scooterService.AddScooter("2", 1m);
        _scooterService.AddScooter("3", 1m);
        rentalCompany.StartRent("1");
        Thread.Sleep(1000);
        var rentalPrice1 = rentalCompany.EndRent("1");
        rentalCompany.StartRent("2");
        Thread.Sleep(1000);
        var rentalPrice2 = rentalCompany.EndRent("2");
        rentalCompany.StartRent("3");
        Thread.Sleep(1000);

        var result = rentalCompany.CalculateIncome(null, true);
        Assert.That(result, Is.EqualTo(rentalPrice1 + rentalPrice2));
    }

    //get name

    [Test]
    public void RentalCompany_GetName_ReturnsCompanyName()
    {
        var scooterService = new ScooterService();
        var rentalCompany = new RentalCompany("CODELEX", scooterService);

        var result = rentalCompany.Name;

        Assert.That(result, Is.EqualTo("CODELEX"));
    }

    // CalculateRentPrice

    [Test]
    public void CalculateRentPrice_RentalLessThanOneDay_ReturnsCorrectPrice()
    {
        var scooter = new Scooter("1", 0.15m);
        scooter.IsRented = true;
        scooter.startRentTime = new DateTime(2023, 4, 5, 12, 0, 0);
        scooter.endRentTime = new DateTime(2023, 4, 5, 12, 30, 0);

        var result = RentalCompany.CalculateRentPrice(scooter);

        Assert.That(result, Is.EqualTo(4.5m));
    }

    [Test]
    public void CalculateRentPrice_RentalMoreThanOneDay_ReturnsCorrectPrice()
    {
        var scooter = new Scooter("1", 0.3m);
        scooter.IsRented = true;
        scooter.startRentTime = new DateTime(2023, 4, 5, 12, 0, 0);
        scooter.endRentTime = new DateTime(2023, 4, 6, 12, 0, 0);

        var result = RentalCompany.CalculateRentPrice(scooter);

        Assert.That(result, Is.EqualTo(20m));
    }

    [Test]
    public void CalculateRentPrice_ScooterIsNull_ThrowsInvalidScooterException()
    {
        Assert.Throws<InvalidScooterException>(() => RentalCompany.CalculateRentPrice(null));
    }

    [Test]
    public void CalculateRentPrice_ScooterIsEmpty_ReturnsZero()
    {
        var scooter = new Scooter("", 0.5m)
        {
            startRentTime = DateTime.MinValue,
            endRentTime = DateTime.MinValue
        };

        var result = RentalCompany.CalculateRentPrice(scooter);

        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void CalculateRentPrice_RentalStartsAndEndsOnDifferentDays_ReturnsCorrectPrice()
    {
        var scooter = new Scooter("1", 1m);
        scooter.IsRented = true;
        scooter.startRentTime = new DateTime(2023, 4, 5, 23, 30, 0);
        scooter.endRentTime = new DateTime(2023, 4, 6, 0, 30, 0);
        
        var result = RentalCompany.CalculateRentPrice(scooter);

        Assert.That(result, Is.EqualTo(20m));
    }
    
    [Test]
    public void CalculateRentPrice_RentalLastsExactly24Hours_ReturnsCorrectPrice()
    {
        var scooter = new Scooter("1", 0.2m);
        scooter.IsRented = true;
        scooter.startRentTime = new DateTime(2023, 4, 5, 12, 0, 0);
        scooter.endRentTime = new DateTime(2023, 4, 6, 12, 0, 0);

        var result = RentalCompany.CalculateRentPrice(scooter);

        Assert.That(result, Is.EqualTo(20m));
    }
    
    [Test]
    public void CalculateRentPrice_RentalLessThanOneMinute_ReturnsCorrectPrice()
    {
        var scooter = new Scooter("1", 0.5m);
        scooter.IsRented = true;
        scooter.startRentTime = new DateTime(2023, 4, 5, 12, 0, 0);
        scooter.endRentTime = new DateTime(2023, 4, 5, 12, 0, 59);

        var result = RentalCompany.CalculateRentPrice(scooter);

        Assert.That(result, Is.EqualTo(0.5m));
    }
    
    [Test]
    public void CalculateRentPrice_ReturnsCorrectPriceWhenPriceIsGreaterThanOrEqualTo20()
    {
        var scooter = new Scooter("1", 1.50m);

        scooter.startRentTime = new DateTime(2023, 4, 5, 10, 0, 0);
        scooter.endRentTime = new DateTime(2023, 4, 5, 12, 0, 0);

        var price = RentalCompany.CalculateRentPrice(scooter);

        Assert.That(price, Is.EqualTo(20.00m));
    }
    
    [Test]
    public void CalculateRentPrice_WhenScooterRentalDatesNotSet_ReturnsZero()
    {
        var scooter = new Scooter("1", 1m)
        {
            startRentTime = DateTime.MinValue,
            endRentTime = DateTime.MinValue
        };
        
        var result = RentalCompany.CalculateRentPrice(scooter);

        Assert.That(result, Is.EqualTo(0m));
    }

    [Test]
    public void CalculateRentPrice_Price2LessThan20_ReturnsCorrectAmount()
    {
        var scooter = new Scooter("1", 0.01m)
        {
            startRentTime = DateTime.Now.AddDays(-1),
            endRentTime = DateTime.Now,
        };

        var result = RentalCompany.CalculateRentPrice(scooter);

        Assert.That(result, Is.EqualTo(14.4m));
    }
}