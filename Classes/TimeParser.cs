using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    public class TimeParser : ITimeParser
    {
        public Time Parse(string timeString)
        {
            string[] parts = timeString.Split(':');
            if (parts.Length < 3) throw new ArgumentException("Invalid time provided. It should be in 'hh:mm:ss' format");

            if (!byte.TryParse(parts[0], out byte hours) || hours < 0 || hours > 24) throw new ArgumentException("Invalid time provided. Hours must be between 00 and 24");
            if (!byte.TryParse(parts[1], out byte minutes) || minutes < 0 || minutes > 59) throw new ArgumentException("Invalid time provided. Minutes must be between 00 and 59");
            if (!byte.TryParse(parts[2], out byte seconds) || seconds < 0 || seconds > 59) throw new ArgumentException("Invalid time provided. Seconds must be between 00 and 59");

            return new Time(hours, minutes, seconds);
        }
    }
}
