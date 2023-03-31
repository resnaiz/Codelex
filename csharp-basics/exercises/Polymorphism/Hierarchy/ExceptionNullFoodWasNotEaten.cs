using System;

namespace Hierarchy;

public class ExceptionNullFoodWasNotEaten : Exception
{
    public ExceptionNullFoodWasNotEaten() : base("Not given proper food.")
    {
    }
}