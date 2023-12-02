namespace Practice_2
{
    internal class Clock
    {
        int _Hours;
        int _Minutes;
        int _Seconds;

        public int Hours
        {
            get
            {
                return _Hours;
            }
            set
            {
                if (value > 0 && value < 25)
                    _Hours = value;
            }
        }
        public int Minutes
        {
            get
            {
                return _Minutes;
            }
            set
            {
                if (value > 0 && value < 61)
                    _Minutes = value;
            }
        }
        public int Seconds
        {
            get
            {
                return _Seconds;
            }
            set
            {
                if (value > 0 && value < 61)
                    _Seconds = value;
            }
        }

        public void AddSecond()
        {
            _Seconds++;

            if (_Seconds >= 60)
            {
                _Minutes++;
                _Seconds = 0;
            }

            if (_Minutes >= 60)
            {
                _Hours++;
                _Minutes = 0;
            }

            if (_Hours >= 24)
                _Hours = 0;
        }

        public void AddMinute()
        {
            _Minutes++;

            if (_Minutes >= 60)
            {
                _Hours++;
                _Minutes = 0;
            }

            if (_Hours >= 24)
                _Hours = 0;
        }

        public void AddHour()
        {
            _Hours++;

            if (_Hours >= 24)
                _Hours = 0;
        }

        public void SubtractSecond()
        {
            _Seconds--;

            if (_Seconds < 0)
            {
                _Minutes--;
                _Seconds = 59;
            }

            if (_Minutes < 0)
            {
                _Hours--;
                _Minutes = 59;
            }

            if (_Hours < 0)
                _Hours = 23;
        }

        public void SubtractMinute()
        {
            _Minutes--;

            if (_Minutes < 0)
            {
                _Hours--;
                _Minutes = 59;
            }

            if (_Hours < 0)
                _Hours = 23;
        }

        public void SubtractHour()
        {
            _Hours--;

            if (_Hours < 0)
                _Hours = 23;
        }

        public string GetCurrentTime()
        {
            TimeSpan currentTime = new TimeSpan(_Hours, _Minutes, _Seconds);

            string formattedTime = $"{currentTime.Hours:D2}:{currentTime.Minutes:D2}:{currentTime.Seconds:D2}";

            return formattedTime;
        }
    }
}
