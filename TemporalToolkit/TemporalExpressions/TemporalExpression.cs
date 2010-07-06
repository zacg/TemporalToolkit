using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemporalToolkit.TemporalExpressions
{
    /// <summary>
    /// Base class for all temporal expressions
    /// </summary>
    public abstract class TemporalExpression
    {
        public abstract bool Includes(DateTime aDate);

        //Or
        public TemporalExpression Or(TemporalExpression expr)
        {
            if (this.GetType() == typeof(TEUnion))
            {
                ((TEUnion)this).Add(expr);
                return this;
            }
            else
            {
                TEUnion union = new TEUnion();
                union.Add(this);
                union.Add(expr);
                return union;
            }
        }

        //and
        public TemporalExpression And(TemporalExpression expr)
        {
            if (this.GetType() == typeof(TEIntersect))
            {
                ((TEIntersect)this).Add(expr);
                return this;
            }
            else
            {
                TEIntersect intersect = new TEIntersect();
                intersect.Add(this);
                intersect.Add(expr);
                return intersect;
            }
        }

        //minus
        public TemporalExpression Minus(TemporalExpression expr)
        {
            return new TEDifference(this, expr);
        }

        //Operators
        public static TemporalExpression operator &(TemporalExpression exprA, TemporalExpression exprB)
        {
            return exprA.And(exprB);
        }

        public static TemporalExpression operator -(TemporalExpression exprA, TemporalExpression exprB)
        {
            return exprA.Minus(exprB);
        }

        public static TemporalExpression operator |(TemporalExpression exprA, TemporalExpression exprB)
        {
            return exprA.Or(exprB);
        }


        
                
       
        /// <summary>
        /// Get specified number of occurrences of TE after specified date.
        /// </summary>
        /// <param name="start">Start date</param>
        /// <param name="maxOccurrences">Number of occurrences to return</param>
        /// <param name="precision">For performance use the longest value possible.</param>
        /// <returns></returns>
        public List<DateTime> Occurrences(DateTime start, int maxOccurrences, IntervalPrecision precision)
        {
            return Occurrences(start, null, maxOccurrences, precision);
        }
       
        /// <summary>
        /// Get occurrences of TE between ranage of dates.
        /// </summary>
        /// <param name="rangeStart">Start of range</param>
        /// <param name="rangeEnd">End of range</param>
        /// <param name="precision">For performance use the longest value possible.</param>
        /// <returns></returns>
        public List<DateTime> Occurrences(DateTime rangeStart, DateTime rangeEnd, IntervalPrecision precision)
        {
            return this.Occurrences(rangeStart, rangeEnd, 0, precision);
        }

        /// <summary>
        /// Returns a list of occurrences between 2 dates or a max number of occurrences from start date
        /// based on the maxOccurrences param.
        /// </summary>
        /// <param name="rangeStart">Start of date range</param>
        /// <param name="rangeEnd">End of date range. Must be specified if maxOccurrences is 0</param>
        /// <param name="maxOccurrences">Max number of occurrences to return. Default 0 means infinte.
        /// rangeEnd must be set if maxOccurrences is 0.
        /// </param>
        /// <param name="precision">For performance use the highest value possible. If using time temporal
        /// expressions (hour,min,sec) increment should be set accordingly. Valid values are
        /// Days, Hours, Mins, Secs, Weeks.
        /// </param>
        /// <returns></returns>
        public List<DateTime> Occurrences(DateTime rangeStart, DateTime? rangeEnd, int maxOccurrences, IntervalPrecision precision)
        {
            if (!rangeEnd.HasValue && maxOccurrences < 1) 
                throw new ArgumentException("Must specify end of range or max occurrences to return.");
            
            List<DateTime> occurrences = new List<DateTime>();
            TimeSpan ts;
            switch (precision)
            {
                case IntervalPrecision.Days:
                    ts = new TimeSpan(1, 0, 0, 0);
                    break;
                case IntervalPrecision.Hours:
                    ts = new TimeSpan(1, 0, 0);
                    break;
                case IntervalPrecision.Minutes:
                    ts = new TimeSpan(0, 1, 0);
                    break;
                case IntervalPrecision.Seconds:
                    ts = new TimeSpan(0, 0, 1);
                    break;
                case IntervalPrecision.Weeks:
                    ts = new TimeSpan(7, 0, 0, 0);
                    break;
                default:
                    throw new NotImplementedException();
            }

            DateTime counter = new DateTime(rangeStart.Ticks);
            if (!rangeEnd.HasValue) 
                rangeEnd = DateTime.MaxValue;

            while (counter <= rangeEnd)
            {
                if (this.Includes(counter)) 
                    occurrences.Add(counter);
                counter = counter.Add(ts);
                if (maxOccurrences > 0 && occurrences.Count == maxOccurrences)
                    break;
            }

            return occurrences;
        }

    }
}
