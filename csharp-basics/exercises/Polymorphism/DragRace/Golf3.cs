using System;

namespace DragRace
{
    public class Golf3 : ICar
    {
        private int currentSpeed = 0;

        public void SpeedUp()
        {
            currentSpeed += 13;
        }

        public void SlowDown()
        {
            currentSpeed -= 7;
        }

        public string ShowCurrentSpeed()
        {
            return currentSpeed.ToString();
        }

        public void StartEngine()
        {
            Console.WriteLine("Eņnnnn.....");
        }
    }
}
