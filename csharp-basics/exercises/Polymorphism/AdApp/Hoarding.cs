namespace AdApp
{
    public class Hoarding: Advert
    {
        private int _rate;
        private int _numDays;

        public Hoarding(int fee, int numDays, int rate) : base(fee)
        {
            _numDays = numDays;
            _rate = rate;
        }

        public new int Cost() 
        {
            int cost = base.Cost();

            if(_rate > 0)
            {
                cost += _rate * _numDays;

                if(_numDays > 0 && _rate > 0)
                {
                    cost += (cost * 50) / 100;
                }
            }

            return cost;
        }

        public override string ToString() 
        {
            return "\nHoarding: £" + Cost();
        }
    }
}