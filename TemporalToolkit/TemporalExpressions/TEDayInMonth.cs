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
        public TEDayInMonth(DateTime date)
        {
            this.Start = date.Day;
            this.End = null;
        }

        /// <summary>
        /// Checks for day of month, if negative number is passed
        /// it will count days from end of month.
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
            bool result;

            if (this.End.HasValue)
            {
                if (this.Start > this.End.Value) throw new ArgumentException("Start of range must be less than end of range");
                result = (aDate.Day >= this.Start && aDate.Day <= this.End.Value);
            }
            else
            {
                //count from end of month if negative number
                if (this.Start > 0)
                    result = (aDate.Day == this.Start);
                else
                    result = (((DateTime.DaysInMonth(aDate.Year, aDate.Month) + this.Start) + 1) == aDate.Day);

            }

            return result;
        }
    }
}
