using System;

namespace VendingMachine;

public class ProductOutOfStockException : Exception
{
    public ProductOutOfStockException() : base("Out of stock!")
    {
    }
}