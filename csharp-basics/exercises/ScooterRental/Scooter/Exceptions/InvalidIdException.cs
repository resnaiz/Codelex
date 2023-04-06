namespace Scooter;

public class InvalidIdException : Exception
{
    public InvalidIdException() : base("Invalid ID provided.")
    {
    }
}