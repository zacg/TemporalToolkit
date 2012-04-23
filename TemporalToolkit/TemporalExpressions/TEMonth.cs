using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemporalToolkit.TemporalExpressions
{
    /// <summary>
    /// Compares month or range of months, E.g: February or Feb-March
    /// </summary>
    public class TEMonth:TemporalExpression
    {
        public Month Start { get; set; }
        public Month? End { get; set; }


        /// <summary>
        /// Checks for month match based on month of specified date.
        /// </summary>
        /// <param name="month"></param>
        public TEMonth(DateTime date)
        {
            this.Start = (Month.January);
            this.End = null;
        }

        /// <summary>
        /// Checks for month match, month should be 1-12 value
        /// </summary>
        /// <param name="month"></param>
        public TEMonth(int month)
        {
            if (month > 12 || month < 1)
                throw new ArgumentOutOfRangeException("month");

            this.Start = (Month)month;
            this.End = null;
        }

        /// <summary>
        /// Checks for month match.
        /// </summary>
        /// <param name="month"></param>
        public TEMonth(Month month)
        {
            this.Start = month;
            this.End = null;
        }

        /// <summary>
        /// Checks for a month range
        /// </summary>
        /// <param name="start">Start of range</param>
        /// <param name="end">End of range</param>
        public TEMonth(Month start, Month end)
        {
            this.Start = start;
            this.End = end;
        }


        /// <summary>
        /// Returns true if month matches or is in range of months
        /// </summary>
        /// <param name="aDate">Date to compare</param>
        /// <returns></returns>
        public override bool Includes(DateTime aDate)
        {
            if (this.End.HasValue)
            {
                if (this.End.Value >= this.Start)
                {
                    return (aDate.Month <= (int)this.End.Value && aDate.Month >= (int)this.Start);
                }
                else
                {
                    return (aDate.Month <= (int)this.End.Value || aDate.Month >= (int)this.Start);
                }
            }
            else
              return ((int)this.Start == aDate.Month);
            
        }
    }
}
