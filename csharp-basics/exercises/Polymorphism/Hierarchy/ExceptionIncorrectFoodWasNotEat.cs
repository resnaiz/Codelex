using System;

namespace Hierarchy;

public class ExceptionIncorrectFoodWasNotEat : Exception
{
    public ExceptionIncorrectFoodWasNotEat() : base("Incorrect Food given.")
    {
    }
}