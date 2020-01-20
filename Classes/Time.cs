using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    /// <summary>
    /// Custom Time parser
    /// </summary>
    public class Time
    {
        private byte _hours;
        public byte Hours
        {
            get => _hours;
            set
            {
                if (_hours < 0 || _hours > 24) throw new ArgumentOutOfRangeException("Hours must be between 0 and 24");
                _hours = value;
            }
        }

        private byte _minutes;
        public byte Minutes
        {
            get => _minutes;
            set
            {
                if (_minutes < 0 || _minutes > 59) throw new ArgumentOutOfRangeException("Minutes must be between 0 and 59");
                _minutes = value;
            }
        }

        private byte _seconds;
        public byte Seconds
        {
            get => _seconds;
            set
            {
                if (_seconds < 0 || _seconds > 59) throw new ArgumentOutOfRangeException("Seconds must be between 0 and 59");
                _seconds = value;
            }
        }

        public Time(byte hours = 0, byte minutes = 0, byte seconds = 0)
        {
            _hours = hours;
            _minutes = minutes;
            _seconds = seconds;
        }

    }
}
