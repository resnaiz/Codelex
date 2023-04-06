namespace Scooter;

public class InvalidScooterException : Exception
{
    public InvalidScooterException() : base("Invalid scooter provided.")
    {
    }
}