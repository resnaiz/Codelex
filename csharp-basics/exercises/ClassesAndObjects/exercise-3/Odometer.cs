namespace exercise_3
{
    internal class Odometer
    {
        private int _currentMileage;
        public FuelGauge fuelGauge;

        public Odometer()
        {
            _currentMileage = 0;
            fuelGauge = new FuelGauge();
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
                    fuelGauge.FuelLow();
                }
            }
            else
            {
                _currentMileage = 0;
            }
        }
    }
}
