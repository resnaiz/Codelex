using System;

namespace VendingMachine;

public class InvalidIdException : Exception
{
    public InvalidIdException() : base("Invalid ID.")
    {
    }
}