using System;

namespace Hierarchy;

public class IncorrectFoodException : Exception
{
    public IncorrectFoodException() : base("Incorrect Food given.")
    {
    }
}