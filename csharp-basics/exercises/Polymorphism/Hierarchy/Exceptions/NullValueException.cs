using System;

namespace Hierarchy;

public class NullValueException : Exception
{
    public NullValueException() : base("Not given proper food.")
    {
    }
}