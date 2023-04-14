using System;

namespace VendingMachine;

public class InvalidPriceException : Exception
{
    public InvalidPriceException() : base("Invalid price found here")
    {
    }
}