using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemporalToolkit.TemporalExpressions
{
    /// <summary>
    /// Union checks if ANY expressions are true
    /// </summary>
    public class TEUnion: TEList
    {

        /// <summary>
        /// Returns true if ANY expressions are true
        /// </summary>
        /// <param name="aDate">Date to test</param>
        /// <returns></returns>
        public override bool Includes(DateTime aDate)
        {
            foreach (TemporalExpression te in this.Expressions)
            {
                if (te.Includes(aDate)) return true;
            }
            return false;
        }
    }
}
