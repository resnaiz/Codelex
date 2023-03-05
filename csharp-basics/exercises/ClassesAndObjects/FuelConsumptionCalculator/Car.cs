﻿namespace FuelConsumptionCalculator
{
    public class Car
    {
        double startKilometers;
        double endKilometers;
        double liters;

        public Car(double startOdo)
        {
            this.startKilometers = startOdo;
        }

        public double CalculateConsumption()
        {
            return (endKilometers - startKilometers) / liters;
        }

        private double ConsumptionPer100Km()
        {
            return 100 / CalculateConsumption();
        }

        public bool GasHog()
        {
            return ConsumptionPer100Km() > 15;
        }

        public bool EconomyCar()
        {
            return ConsumptionPer100Km() < 5;
        }

        public void FillUp(int mileage, double liters)
        {
            this.startKilometers = this.endKilometers;
            this.endKilometers = mileage;
            this.liters = liters;
        }
    }
}
