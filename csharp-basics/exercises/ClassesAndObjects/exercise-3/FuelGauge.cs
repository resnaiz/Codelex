namespace exercise_3
{
    public class FuelGauge
    {
        private int _currentFuelAmount;

        public FuelGauge() 
        {
            _currentFuelAmount = 0;
        }

        public int GetFuelAmount()
        {
            return _currentFuelAmount;
        }

        public void RefuelLimit()
        {
            if(_currentFuelAmount < 70)
            {
                _currentFuelAmount++;
            }
        }

        public void FuelLow()
        {
            if(_currentFuelAmount > 0)
            {
                _currentFuelAmount--;
            }
        }
    }
}
