using System.Collections.Generic;
using System.Linq;

namespace VideoStore
{
    class Video
    {
        private string _videoTitle { get; set; }
        private bool _checkedOut { get; set; }
        private List<int> _videoRatings = new List<int>();

        public Video(string title)
        {
            _videoTitle = title;
            _checkedOut = false;
        }

        public void BeingCheckedOut()
        {
            _checkedOut = true;
        }

        public void BeingReturned()
        {
            _checkedOut = false;
        }

        public void ReceivingRating(int rating)
        {
            _videoRatings.Add(rating);
        }

        public double AverageRating()
        {
            if(_videoRatings.Count == 0)
            {
                return 0;
            }
            else
            {
                return _videoRatings.Average();
            }
        }

        public bool Available()
        {
            return !_checkedOut;
        }

        public string Title => _videoTitle;

        public override string ToString()
        {
            return $"{Title} {AverageRating()} {Available()}";
        }
    }
}