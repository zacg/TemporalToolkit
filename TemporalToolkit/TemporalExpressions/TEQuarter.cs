using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TemporalToolkit.Extensions;

namespace TemporalToolkit.TemporalExpressions
{
    public class TEQuarter: TemporalExpression
    {
        public Quarter Start { get; set; }
        public Quarter? End { get; set; }
        public Month StartOfYear { get; set; }

        /// <summary>
        /// Checks for a single quarter assuming
        /// the year starts Jan 1st
        /// </summary>
        /// <param name="quarter"></param>
        public TEQuarter(Quarter quarter)
        {
            this.Start = quarter;
            this.End = null;
            this.StartOfYear = Month.January;
        }

        /// <summary>
        /// Checks for a range of quarters
        /// assuming the year starts Jan 1st
        /// </summary>
        /// <param name="start">Start of range</param>
        /// <param name="end">End of range</param>
        public TEQuarter(Quarter start, Quarter end)
        {
            this.Start = start;
            this.End = end;
            this.StartOfYear = Month.January;
        }

        /// <summary>
        /// Checks for a quarter based on specified
        /// start of year.
        /// </summary>
        /// <param name="quarter"></param>
        /// <param name="startOfYear"></param>
        public TEQuarter(Quarter quarter, Month startOfYear)
        {
            this.Start = quarter;
            this.End = null;
            this.StartOfYear = startOfYear;
        }

        /// <summary>
        /// Checks for range of quarters based on
        /// specified start of year
        /// </summary>
        /// <param name="start">Start of range</param>
        /// <param name="end">End of range</param>
        /// <param name="startOfYear"></param>
        public TEQuarter(Quarter start, Quarter end, Month startOfYear)
        {
            this.Start = start;
            this.End = end;
            this.StartOfYear = startOfYear;
        }

        /// <summary>
        /// Returns true if date falls on specified quarter or range of quarters
        /// </summary>
        /// <param name="aDate"></param>
        /// <returns></returns>
        public override bool Includes(DateTime aDate)
        {
            //check for valid args
            if (this.Start == Quarter.Unset || (this.End.HasValue && this.End.Value == Quarter.Unset))
                throw new ArgumentException();

            bool result;

            if (this.End.HasValue)
            {
                //range
                if (this.End.Value >= this.Start)
                    result = (aDate.Quarter(this.StartOfYear) <= this.End.Value && aDate.Quarter(this.StartOfYear) >= this.Start);
                else
                    result = (aDate.Quarter(this.StartOfYear) <= this.End.Value || aDate.Quarter(this.StartOfYear)>= this.Start);
            }
            else
                result = (this.Start == aDate.Quarter(this.StartOfYear));

            return result;
        }
    }
}
