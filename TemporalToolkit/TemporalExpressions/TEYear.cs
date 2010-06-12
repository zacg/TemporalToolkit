using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TemporalToolkit.TemporalExpressions;

namespace TemporalToolkit.TemporalExpressions
{
    /// <summary>
    /// Compares a year or range of years
    /// </summary>
    public class TEYear: TemporalExpression
    {

        public int Start { get; set; }
        public int? End { get; set; }
        
        /// <summary>
        /// Compares a year, E.g 2009
        /// </summary>
        /// <param name="year">Year to compare</param>
        public TEYear(int year)
        {
            this.Start = year;
        }

        /// <summary>
        /// Compares a range of years, E.g 2001-2010
        /// </summary>
        /// <param name="start">Start of year range</param>
        /// <param name="end">End of year range</param>
        public TEYear(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }

        /// <summary>
        /// Returns true if the date year matches or year is in range
        /// </summary>
        /// <param name="aDate">Date to check</param>
        /// <returns></returns>
        public override bool Includes(DateTime aDate)
        {
            if (this.End.HasValue)
            {
                if (this.End < this.Start) throw new ArgumentException();
                return (aDate.Year >= this.Start && aDate.Year <= this.End);
            }
            else
              return (aDate.Year == this.Start);
            
        }
    }
}
