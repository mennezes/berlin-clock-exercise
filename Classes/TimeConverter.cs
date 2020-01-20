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
            Time time = Time.Parse(aTime);
            StringBuilder berlinTime = new StringBuilder();

            // Seconds
            berlinTime.AppendLine(getRow(0, time.Seconds % 2 == 0 ? 1 : 0));

            // Hours
            berlinTime.AppendLine(getRow(1, time.Hours / 5));
            berlinTime.AppendLine(getRow(2, time.Hours % 5));

            // Minutes
            berlinTime.AppendLine(getRow(3, time.Minutes / 5));
            berlinTime.Append(getRow(4, time.Minutes % 5));

            // Returns the final string
            return berlinTime.ToString();
        }

        /// <summary>
        /// Helper to get the row of the clock.
        /// It combines the "on" lights with the "off" lights
        /// </summary>
        /// <param name="row">The number of the row (starts on 0)</param>
        /// <param name="amount">The amout of lights on in the row</param>
        /// <returns></returns>
        private string getRow(int row, int amount) => string.Concat(_on[row].Substring(0, amount),  _off[row].Substring(amount));
    }
}
