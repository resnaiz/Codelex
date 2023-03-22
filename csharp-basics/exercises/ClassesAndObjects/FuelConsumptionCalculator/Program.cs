using System;

namespace FuelConsumptionCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int startKilometers;
            double liters;

            Car car = new Car(0);
            Car car1 = new Car(0);

            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter first reading for Car 1: ");
                startKilometers = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter liters reading for Car 1: ");
                liters = Convert.ToDouble(Console.ReadLine());
                car.FillUp(startKilometers, liters);

                Console.Write("Enter first reading for Car 2: ");
                startKilometers = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter liters reading for Car 2: ");
                liters = Convert.ToDouble(Console.ReadLine());
                car1.FillUp(startKilometers, liters);
            }

            Console.WriteLine("Car 1:");
            Console.WriteLine("Kilometers per liter: " + car.CalculateConsumption());

            if (car.GasHog())
            {
                Console.WriteLine("Gas hog!");
            }
            else if (car.EconomyCar())
            {
                Console.WriteLine("Economy car!");
            }

            Console.WriteLine();

            Console.WriteLine("Car 2:");
            Console.WriteLine("Kilometers per liter: " + car1.CalculateConsumption());
            if (car1.GasHog())
            {
                Console.WriteLine("Gas hog!");
            }
            else if (car1.EconomyCar())
            {
                Console.WriteLine("Economy car!");
            }

            Console.ReadKey();
        }
    }
}
