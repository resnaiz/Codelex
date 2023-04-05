namespace Scooter.Test;

public class ScooterServiceTests
{
    private ScooterService _scooterService;
    
    [SetUp]
    public void Setup()
    {
        _scooterService = new ScooterService();
    }

    [Test]
    public void AddScooter_GiveValidId_CorrectUpdateCount()
    {
        _scooterService.AddScooter("1", 1m);
        Assert.That(_scooterService.GetScooters(), Has.Count.EqualTo(1));
    }

    [Test]
    public void AddScooter_GiveEmptyId_ThrowExceptionInvalidId()
    {
        Assert.Throws<InvalidIdException>(() => _scooterService.AddScooter("", 1m));
    }
    
    [Test]
    public void AddScooter_GiveNullId_ThrowExceptionInvalidId()
    {
        Assert.Throws<InvalidIdException>(() => _scooterService.AddScooter(null, 1m));
    }

    [Test]
    public void AddScooter_GiveInvalidPrice_ThrowExceptionInvalidPrice()
    {
        Assert.Throws<InvalidPriceProvidedException>(() => _scooterService.AddScooter("1", -1m));
    }
    
    // RemoveScooter

    [Test]
    public void RemoveScooter_GiveCorrectId_UpdateCorrectCount()
    {
        _scooterService.AddScooter("1", 1m);
        _scooterService.RemoveScooter("1");
        
        Assert.That(_scooterService.GetScooters(), Has.Count.EqualTo(0));
    }

    
    [Test]
    public void RemoveScooter_GiveEmptyId_ThrowExceptionInvalidId()
    {
        Assert.Throws<InvalidIdException>(() => _scooterService.RemoveScooter(""));
    }
    
    [Test]
    public void RemoveScooter_GiveNullId_ThrowExceptionInvalidId()
    {
        Assert.Throws<InvalidIdException>(() => _scooterService.RemoveScooter(null));
    }
    
    [Test]
    public void RemoveScooter_GiveNonExistantId_ThrowExceptionInvalidId()
    {
        Assert.Throws<InvalidIdException>(() => _scooterService.RemoveScooter("3"));
    }
    
    // GetScooterById

    [Test]
    public void GetScooterById_GiveNonExistantId_ThrowExceptionInvalidId()
    {
        _scooterService.AddScooter("1", 1m);

        Assert.Throws<InvalidIdException>(() => _scooterService.GetScooterById("2"));
    }
    
    [Test]
    public void GetScooterById_GiveNullId_ThrowExceptionInvalidId()
    {
        Assert.Throws<InvalidIdException>(() => _scooterService.GetScooterById(null));
    }
    
    [Test]
    public void GetScooterById_GiveEmptyId_ThrowExceptionInvalidId()
    {
        Assert.Throws<InvalidIdException>(() => _scooterService.GetScooterById(""));
    }

    [Test]
    public void GetScooterById_CorrectIdGiven_CorrectScooterReturned()
    {
        var scooterId = "1";
        _scooterService.AddScooter(scooterId, 1m);
        
        var scooter = _scooterService.GetScooterById(scooterId);

        Assert.IsNotNull(scooter);
        Assert.That(scooter.Id, Is.EqualTo(scooterId));
    }
}