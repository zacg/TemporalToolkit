using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemporalToolkit.TemporalExpressions
{
    
    /// <summary>
    /// Expression for day of month
    /// </summary>
    public class TEDayInMonth: TemporalExpression
    {
        public int Start {get; set;}
        public int? End { get; set; }

        /// <summary>
        /// Checks for day of month
        /// </summary>
        /// <param name="day">Day of month to check</param>
        public TEDayInMonth(int day)
        {
            this.Start = day;
            this.End = null;
        }

        /// <summary>
        /// Checks for a day range of a month
        /// </summary>
        /// <param name="start">Start of day range</param>
        /// <param name="end">End of day range</param>
        public TEDayInMonth(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }
        
        /// <summary>
        /// Returns true if day of month matches or is in range.
        /// </summary>
        /// <param name="aDate"></param>
        /// <returns></returns>
        public override bool Includes(DateTime aDate)
        {
            if (this.End.HasValue)
            {
                if (this.Start > this.End.Value) throw new ArgumentException("Start of range must be less than end of range");
                return (aDate.Day >= this.Start && aDate.Day <= this.End.Value);
            }
            else  return (aDate.Day == this.Start);
        }
    }
}
