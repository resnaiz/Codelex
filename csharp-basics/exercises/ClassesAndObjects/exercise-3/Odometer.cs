namespace exercise_3
{
    internal class Odometer
    {
        private int _currentMileage;
        public FuelGauge _fuelGauge;

        public Odometer()
        {
            _currentMileage = 0;
            _fuelGauge = new FuelGauge();
        }

        public int GetMileage()
        {
            return _currentMileage;
        }

        public void IncreaseMileage()
        {
            if(_currentMileage < 999999)
            {
                _currentMileage++;
                
                if(_currentMileage % 10 == 0)
                {
                    _fuelGauge.FuelLow();
                }
            }
            else
            {
                _currentMileage = 0;
            }
        }

        public void RefuelLimit()
        {
            _fuelGauge.RefuelLimit();
        }

        public int GetFuelAmount()
        {
            return _fuelGauge.GetFuelAmount();
        }
    }
}
