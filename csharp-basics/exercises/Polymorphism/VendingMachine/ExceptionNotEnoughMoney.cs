using System;

namespace VendingMachine;

public class ExceptionNotEnoughMoney : Exception
{
    public ExceptionNotEnoughMoney() : base("Not enough money.")
    {
    }
}