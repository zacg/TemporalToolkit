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

    }
}
