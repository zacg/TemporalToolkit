using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemporalToolkit.TemporalExpressions
{
    
    /// <summary>
    /// Temporal expression for seconds
    /// </summary>
    public class TESecond: TemporalExpression
    {
        public int Start {get; set;}
        public int? End {get; set;}

        /// <summary>
        /// Check for specified seconds value
        /// </summary>
        /// <param name="second"></param>
        public TESecond(int second)
        {
            this.Start = second;
            this.End = null;
        }

        /// <summary>
        /// Check for a specified range of seconds
        /// </summary>
        /// <param name="start">Start of range</param>
        /// <param name="end">End of range</param>
        public TESecond(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }

        
        /// <summary>
        /// Returns true if seconds match or fall within range.
        /// </summary>
        /// <param name="aDate"></param>
        /// <returns></returns>
        public override bool Includes(DateTime aDate)
        {
            bool result;

            if (this.End.HasValue)
                if (this.End.Value > this.Start)
                    result = (aDate.Second >= this.Start && aDate.Second <= this.End.Value);
                else
                    result = (aDate.Second >= this.Start || aDate.Second <= this.End.Value);
            else
                result = (this.Start == aDate.Second);

            return result;
        }
    }
}
