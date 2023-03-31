using System;
using System.Collections.Generic;
using System.Linq;

namespace DragRace
{
    class Program
    {
        private static void Main(string[] args)
        {
            var cars = new List<ICar>();
            cars.Add(new Audi());
            cars.Add(new Bmw());
            cars.Add(new Lexus());
            cars.Add(new Tesla());
            cars.Add(new Raf());
            cars.Add(new Golf3());

            for (int i = 0; i < 10; i++)
            {
                if(i == 0)
                {
                    cars.ForEach(car => car.StartEngine());
                }
                else
                {
                    for(int j = 0; j < cars.Count; j++)
                    {
                        if(i == 2)
                        {
                            if (cars[j] is IBoostable boostable)
                            {
                                boostable.UseNitrousOxideEngine();
                            }
                            else
                            {
                                cars[j].SpeedUp();
                            }
                        }
                        else
                        {
                            cars[j].SpeedUp();
                        }
                    }
                }
            }
            var maxSpeed = cars.Max(c => int.Parse(c.ShowCurrentSpeed()));
            var carO = cars.First(c => c.ShowCurrentSpeed() == maxSpeed.ToString());

            Console.WriteLine($"{carO.GetType().Name} : {maxSpeed}");
            Console.ReadKey();
        }
    }
}