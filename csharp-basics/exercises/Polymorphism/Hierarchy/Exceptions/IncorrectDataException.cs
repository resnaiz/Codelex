using System;

namespace Hierarchy;

public class IncorrectDataException : Exception
{
    public IncorrectDataException() : base("Invalid data received.")
    {
    }
}