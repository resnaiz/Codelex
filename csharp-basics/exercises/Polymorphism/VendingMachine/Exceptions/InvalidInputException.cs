using System;

namespace VendingMachine;

public class InvalidInputException : Exception
{
    public InvalidInputException() : base("Invalid input.")
    {
    }
}