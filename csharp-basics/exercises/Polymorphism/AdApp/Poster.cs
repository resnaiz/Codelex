namespace AdApp
{
    public class Poster : Advert
    {
        private int _dimension;
        private int _copies;
        private int _costPerCopy;

        public Poster(int fee, int dimensions, int cop, int costPerCopy) : base(fee)
        {
            _dimension = dimensions;
            _copies = cop;
            _costPerCopy = costPerCopy;     
        }

        public new int Cost()
        {
            int cost = _copies * _costPerCopy;

            return base.Cost() + cost;
        }

        public override string ToString()
        {
            return "\nPoster: £" + Cost();
        }
    }
}
