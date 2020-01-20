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

            int secondsRow = time.Seconds % 2 == 0 ? 1 : 0;
            berlinTime.AppendLine(getRow(0, secondsRow));

            int hoursRow1 = time.Hours / 5;
            berlinTime.AppendLine(getRow(1, hoursRow1));

            int hoursRow2 = time.Hours % 5;
            berlinTime.AppendLine(getRow(2, hoursRow2));

            int minutesRow1 = time.Minutes / 5;
            berlinTime.AppendLine(getRow(3, minutesRow1));

            int minutesRow2 = time.Minutes % 5;
            berlinTime.Append(getRow(4, minutesRow2));

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
