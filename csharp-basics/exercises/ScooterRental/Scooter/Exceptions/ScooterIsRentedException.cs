namespace Scooter;

public class ScooterIsRentedException : Exception
{
    public ScooterIsRentedException() : base("Scooter is rented.")
    {
    }
}