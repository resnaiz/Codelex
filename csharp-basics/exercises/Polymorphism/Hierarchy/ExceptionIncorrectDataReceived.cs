using System;

namespace Hierarchy;

public class ExceptionIncorrectDataReceived : Exception
{
    public ExceptionIncorrectDataReceived() : base("Invalid data received.")
    {
    }
}