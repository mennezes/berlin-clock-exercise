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
        private int hours;
        public int Hours => hours;

        private int minutes;
        public int Minutes => minutes;

        private int seconds;
        public int Seconds => seconds;

        public static Time Parse(string timeString)
        {
            string[] parts = timeString.Split(':');
            if (parts.Length < 3) throw new ArgumentException("Invalid time provided. It should be in 'hh:mm:ss' format");

            Time time = new Time();

            if (!int.TryParse(parts[0], out time.hours) || time.hours < 0 || time.hours > 24) throw new ArgumentException("Invalid time provided. Hours must be between 00 and 24");
            if (!int.TryParse(parts[1], out time.minutes) || time.minutes < 0 || time.minutes > 59) throw new ArgumentException("Invalid time provided. Minutes must be between 00 and 59");
            if (!int.TryParse(parts[2], out time.seconds) || time.seconds < 0 || time.seconds > 59) throw new ArgumentException("Invalid time provided. Seconds must be between 00 and 59");

            return time;
        }
    }
}
