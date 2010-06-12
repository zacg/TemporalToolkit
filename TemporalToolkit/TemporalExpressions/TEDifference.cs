using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemporalToolkit.TemporalExpressions
{
    
    /// <summary>
    /// Difference checks if first expression is true and second
    /// expression is false
    /// </summary>
    public class TEDifference: TemporalExpression
    {

        public TemporalExpression ExpressionA { get; set; }
        public TemporalExpression ExpressionB { get; set; }

        public TEDifference(TemporalExpression exprA, TemporalExpression exprB)
        {
            this.ExpressionA = exprA;
            this.ExpressionB = exprB;
        }

        /// <summary>
        /// Returns true if the first expression is true and
        /// the second expression is false
        /// </summary>
        /// <param name="aDate">Date to check</param>
        /// <returns></returns>
        public override bool Includes(DateTime aDate)
        {
            return (this.ExpressionA.Includes(aDate) && !this.ExpressionB.Includes(aDate));
        }
    }
}
