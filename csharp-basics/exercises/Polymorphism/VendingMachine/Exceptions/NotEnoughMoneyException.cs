using System;

namespace VendingMachine;

public class NotEnoughMoneyException : Exception
{
    public NotEnoughMoneyException() : base("Not enough money.")
    {
    }
}