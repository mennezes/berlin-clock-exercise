using BerlinClock.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        /// <summary>
        /// Lights off pattern
        /// </summary>
        private string[] _off =
        {
            "O",
            "OOOO",
            "OOOO",
            "OOOOOOOOOOO",
            "OOOO"
        };

        /// <summary>
        /// Lights on pattern
        /// </summary>
        private string[] _on = 
        {
            "Y",
            "RRRR",
            "RRRR",
            "YYRYYRYYRYY",
            "YYYY"
        };

        public string convertTime(string aTime)
        {
            TimeParser timeParser = new TimeParser();
            Time time = timeParser.Parse(aTime);

            StringBuilder berlinTime = new StringBuilder();

            byte secondsRow = (byte)(time.Seconds % 2 == 0 ? 1 : 0);
            berlinTime.AppendLine(getBerlinRow(0, secondsRow));

            byte hoursRow1 = (byte)(time.Hours / 5);
            berlinTime.AppendLine(getBerlinRow(1, hoursRow1));

            byte hoursRow2 = (byte)(time.Hours % 5);
            berlinTime.AppendLine(getBerlinRow(2, hoursRow2));

            byte minutesRow1 = (byte)(time.Minutes / 5);
            berlinTime.AppendLine(getBerlinRow(3, minutesRow1));

            byte minutesRow2 = (byte)(time.Minutes % 5);
            berlinTime.Append(getBerlinRow(4, minutesRow2));

            return berlinTime.ToString();

            // Helper to get the row of the clock.
            // It combines the "on" lights with the "off" lights
            string getBerlinRow(byte row, byte amount) => string.Concat(_on[row].Substring(0, amount), _off[row].Substring(amount));
        }
    }
}
