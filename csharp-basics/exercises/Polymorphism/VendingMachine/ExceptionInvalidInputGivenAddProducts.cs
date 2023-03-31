using System;

namespace VendingMachine;

public class ExceptionInvalidInputGivenAddProducts : Exception
{
    public ExceptionInvalidInputGivenAddProducts() : base("Invalid input given Add Products method.")
    {
    }
}