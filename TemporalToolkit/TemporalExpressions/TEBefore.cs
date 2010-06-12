using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemporalToolkit.TemporalExpressions
{
    /// <summary>
    /// Before TE checks if dates occurr after a specified date.
    /// </summary>
    public class TEBefore: TemporalExpression
    {
        public DateTime Date { get; set; }

        /// <summary>
        /// Checks if dates occurr after given date
        /// </summary>
        /// <param name="aDate">Date to test against</param>
        public TEBefore(DateTime aDate)
        {
            this.Date = aDate;
        }
        
        /// <summary>
        /// Returns true if passed date is after te date.
        /// </summary>
        /// <param name="aDate"></param>
        /// <returns></returns>
        public override bool Includes(DateTime aDate)
        {
            return (aDate < this.Date);
        }
    }
}
