using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemporalToolkit.TemporalExpressions
{
    /// <summary>
    /// Checks for a single or range of week days
    /// E.g. monday, or monday-friday
    /// </summary>
    public class TEWeekDay: TemporalExpression
    {
        public System.DayOfWeek Start { get; set; }
        public System.DayOfWeek? End { get; set; }

        /// <summary>
        /// Checks a single day, e.g. Monday
        /// </summary>
        /// <param name="date">date to compare</param>
        public TEWeekDay(DateTime date)
        {
            this.Start = date.DayOfWeek;
            this.End = null;
        }
        

        /// <summary>
        /// Checks a single day, e.g. Monday
        /// </summary>
        /// <param name="day">Day to compare</param>
        public TEWeekDay(System.DayOfWeek day)
        {
            this.Start = day;
            this.End = null;
        }
        
        /// <summary>
        /// Checks for a range of weekdays, e.g. wed-sun
        /// </summary>
        /// <param name="start">Start of range</param>
        /// <param name="end">End of range</param>
        public TEWeekDay(System.DayOfWeek start, System.DayOfWeek end)
        {
            this.Start = start;
            this.End = end;
        }

        /// <summary>
        /// Returns true if specified date occurrs on day of week or 
        /// range of days of week
        /// </summary>
        /// <param name="aDate"></param>
        /// <returns></returns>
        public override bool Includes(DateTime aDate)
        {
            bool result;
            
            if (this.End.HasValue)
            {
                //range
                if (this.End.Value >= this.Start)
                     result = (aDate.DayOfWeek <= this.End.Value && aDate.DayOfWeek >= this.Start);
                else
                     result = (aDate.DayOfWeek <= this.End.Value || aDate.DayOfWeek >= this.Start);
            }
            else
               result = (this.Start == aDate.DayOfWeek);

            return result;
        }
    }
}
