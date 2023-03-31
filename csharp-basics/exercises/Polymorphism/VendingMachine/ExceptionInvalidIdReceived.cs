using System;

namespace VendingMachine;

public class ExceptionInvalidIdReceived : Exception
{
    public ExceptionInvalidIdReceived() : base("Invalid ID.")
    {
    }
}