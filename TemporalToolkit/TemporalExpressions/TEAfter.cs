using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemporalToolkit.TemporalExpressions
{
    
    /// <summary>
    /// After TE checks for dates after a specifed date.
    /// </summary>
    public class TEAfter: TemporalExpression
    {
        public DateTime Date { get; set; }

        /// <summary>
        /// Checks if dates are after a specified date
        /// </summary>
        /// <param name="aDate">Date to check against</param>
        public TEAfter(DateTime aDate)
        {
            this.Date = aDate;
        }
        
        /// <summary>
        /// Returns true if specified date is after the te date.
        /// </summary>
        /// <param name="aDate"></param>
        /// <returns></returns>
        public override bool Includes(DateTime aDate)
        {
            return (aDate > this.Date);
        }
    }
}
