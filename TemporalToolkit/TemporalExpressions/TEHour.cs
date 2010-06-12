using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemporalToolkit.TemporalExpressions
{
    /// <summary>
    /// Temporal expression for checking hour, or span of hours.
    /// </summary>
    public class TEHour: TemporalExpression
    {
        public int Start { get; set; }
        public int? End { get; set; }

        /// <summary>
        /// Matches the hour value of dates.
        /// </summary>
        /// <param name="hour"></param>
        public TEHour(int hour)
        {
            this.Start = hour;
            this.End = null;
        }

        /// <summary>
        /// Matches a dates hour value with a range of dates
        /// </summary>
        /// <param name="startHour">Start of hour range</param>
        /// <param name="endHour">End of hour range</param>
        public TEHour(int startHour, int endHour)
        {
            this.Start = startHour;
            this.End = endHour;
        }

        /// <summary>
        /// Returns true when hour/hour range matches specified dates hour.
        /// </summary>
        /// <param name="aDate"></param>
        /// <returns></returns>
        public override bool Includes(DateTime aDate)
        {
            if (this.End.HasValue)
                return (aDate.Hour >= this.Start && aDate.Hour <= this.End.Value);
            else
                return (this.Start == aDate.Hour);
        }
    }
}
