namespace DaysNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek = Enum.GetNames(typeof(DayOfWeek));

            foreach(string day in daysOfWeek)
            {
                Console.WriteLine(day);
            }
        }
    }
}