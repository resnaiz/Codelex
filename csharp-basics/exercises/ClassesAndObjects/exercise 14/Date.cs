using System;

namespace exercise_14
{
    internal class Date
    {
        private int _year;
        private int _month;
        private int _day;

        public Date(int yearInfo, int monthInfo, int dayInfo)
        {
            _year = yearInfo;
            _month = monthInfo;
            _day = dayInfo;
        }

        public string WeekdayInDutch()
        {
            DateTime dateTime = new DateTime(_year, _month, _day);
            return dateTime.ToString("dddd", new System.Globalization.CultureInfo("nl-NL"));
        }
    }
}
