using System;

namespace exercise_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Date firstDate = new Date(1970, 9, 21);
            Date secondDate = new Date(1945, 9, 2);
            Date thirdDate = new Date(2001, 9, 11);

            Console.WriteLine(firstDate.WeekdayInDutch());
            Console.WriteLine(secondDate.WeekdayInDutch());
            Console.WriteLine(thirdDate.WeekdayInDutch());
        }
    }
}
