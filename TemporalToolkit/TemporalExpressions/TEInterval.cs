using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TemporalToolkit.Extensions;
using TemporalToolkit.Utils;

namespace TemporalToolkit.TemporalExpressions
{
    public class TEInterval: TemporalExpression
    {
        public IntervalPrecision Precision { get; set; }
        public int Interval;
        public DateTime Start;

        /// <summary>
        /// Checks wheter dates occurr on an interval
        /// </summary>
        /// <param name="start">Date to count the intervals from</param>
        /// <param name="interval">Interval</param>
        /// <param name="precision"></param>
        public TEInterval(DateTime start, int interval, IntervalPrecision precision)
        {
            this.Precision = precision;
            this.Start = start;
            this.Interval = interval;
        }
                
        /// <summary>
        /// Returns true when specified date falls on specified interval.
        /// </summary>
        /// <param name="aDate"></param>
        /// <returns></returns>
        public override bool Includes(DateTime aDate)
        {
            if (aDate < this.Start) return false;
            

            switch (this.Precision)
            {
                case IntervalPrecision.Seconds:
                    {
                        TimeSpan ts = this.Start - aDate;
                        return ((ts.Seconds % this.Interval) == 0);
                    }
                case IntervalPrecision.Minutes:
                    {
                        TimeSpan ts = this.Start - aDate;
                        return ((ts.Minutes % this.Interval) == 0);
                    }
                case IntervalPrecision.Hours:
                    {
                        TimeSpan ts = this.Start - aDate;
                        return ((ts.Hours % this.Interval) == 0);
                    }
                case IntervalPrecision.Days:
                    {
                        DateTime tempStart = new DateTime(this.Start.Year, this.Start.Month, this.Start.Day);
                        DateTime tempend = new DateTime(aDate.Year, aDate.Month, aDate.Day);
                        TimeSpan ts = tempStart - aDate;
                        return ((ts.Days % this.Interval) == 0);
                    }
                case IntervalPrecision.Weeks:
                    {
                        DateTime tempStart = new DateTime(this.Start.Year, this.Start.Month, this.Start.Day).StartOfWeek();
                        DateTime tempdate = new DateTime(aDate.Year, aDate.Month, aDate.Day).StartOfWeek();
                        TimeSpan ts = tempStart - tempdate;
                        return ((ts.Days % (this.Interval * 7)) == 0);
                    }
                case IntervalPrecision.Months:
                    {
                        DateDifference de = new DateDifference(this.Start, aDate);
                        return ((de.TotalMonths % this.Interval) == 0);
                    }
                //case IntervalPrecision.Quarters:
                //    {
                //        DateDifference de = new DateDifference(this.Start, aDate);
                //        return ((de.TotalMonths % (this.Interval * 3)) == 0);
                //    }
                case IntervalPrecision.Years:
                    {
                        DateDifference de = new DateDifference(this.Start, aDate);
                        return ((de.Years % this.Interval) == 0);
                    }
                default:
                    throw new NotImplementedException();
            }
               
        }
    }
}
