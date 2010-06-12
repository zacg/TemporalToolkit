using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemporalToolkit.TemporalExpressions
{
    /// <summary>
    /// Temporal expression for checking minute
    /// </summary>
    public class TEMinute: TemporalExpression
    {

        public int Start { get; set; }
        public int? End { get; set; }

        /// <summary>
        /// Check if minutes match
        /// </summary>
        /// <param name="minute"></param>
        public TEMinute(int minute)
        {
            this.Start = minute;
            this.End = null;
        }

        /// <summary>
        /// Check of minutes fall within a range
        /// </summary>
        /// <param name="start">Start of minute range</param>
        /// <param name="end">End of minute range</param>
        public TEMinute(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }

        /// <summary>
        /// Returns true if minutes match or fall within range
        /// </summary>
        /// <param name="aDate"></param>
        /// <returns></returns>
        
        public override bool Includes(DateTime aDate)
        {
            bool result;

            if (this.End.HasValue)
                if(this.End.Value > this.Start)
                    result = (aDate.Minute >= this.Start && aDate.Minute <= this.End.Value);
                else
                    result = (aDate.Minute >= this.Start || aDate.Minute <= this.End.Value);
            else
                result = (this.Start == aDate.Minute);

            return result;
        }
    }
}
