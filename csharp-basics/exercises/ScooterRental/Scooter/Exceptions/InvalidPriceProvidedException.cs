namespace Scooter;

public class InvalidPriceProvidedException : Exception
{
    public InvalidPriceProvidedException() : base("Invalid price provided.")
    {
    }
}