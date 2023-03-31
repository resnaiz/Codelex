namespace AdApp
{
    public class TVAd: Advert
    {
        private int _airTime;
        private int _rate;
        private int _timeInSec;
        private bool _isPeak;

        public TVAd(int fee, int airTime, int sec, bool isPeak) : base(fee)
        {
            _airTime = airTime;
            _timeInSec = sec;
            _isPeak = isPeak;
            _rate = isPeak ? airTime * 2 : airTime;
        }
        
        public new int Cost() 
        {
            int cost = base.Cost();

            if(_rate > 0 && _timeInSec > 0)
            {
                cost += _rate * _timeInSec;
            }

            return cost;
        }

        public override string ToString() 
        {
            return "\nTV Ad: £" + Cost();
        }
    }
}