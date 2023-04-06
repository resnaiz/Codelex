namespace Scooter;

public class ScooterIsNotRentedException : Exception
{
    public ScooterIsNotRentedException() : base("Scooter is not rented.")
    {
    }
}