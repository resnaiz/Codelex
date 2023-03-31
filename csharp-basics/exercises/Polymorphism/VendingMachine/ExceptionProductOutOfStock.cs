using System;

namespace VendingMachine;

public class ExceptionProductOutOfStock : Exception
{
    public ExceptionProductOutOfStock() : base("Out of stock!")
    {
    }
}