using System;

namespace VendingMachine;

public class ExceptionInvalidCoin : Exception
{
    public ExceptionInvalidCoin() : base( "Invalid Coin inserted.")
    {
    }
}