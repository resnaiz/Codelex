using System;

namespace VendingMachine;

public class ExceptionInvalidPriceFound : Exception
{
    public ExceptionInvalidPriceFound() : base("Invalid price found here")
    {
    }
}