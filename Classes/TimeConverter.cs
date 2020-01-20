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
            // Try parsing to a DateTime and use it to validate the input
            Time time = Time.Parse(aTime);

            // This will store the ammout of lights on per row
            int[] rows = new int[5];

            // The first row is the seconds, if it is even, then it is on
            rows[0] = time.Seconds % 2 == 0 ? 1 : 0;

            // For the hours, we need to divide exactly by 5 to know how many red should be on the 1st row
            // And the rest of the division is the red on the 2nd row
            rows[1] = time.Hours / 5;
            rows[2] = time.Hours % 5;

            // For the minutes, we need the same division as the hours
            rows[3] = time.Minutes / 5;
            rows[4] = time.Minutes % 5;

            // The final string
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < 5; i++)
            {
                sb.AppendLine(getRow(i, rows[i]));
            }
            sb.Length = sb.Length - 2;

            // Returns the final string
            return sb.ToString();
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
