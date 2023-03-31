using System;

namespace VendingMachine;

public class ExceptionInvalidInputGiven : Exception
{
    public ExceptionInvalidInputGiven() : base("Invalid input.")
    {
    }
}