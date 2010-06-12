using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemporalToolkit.TemporalExpressions
{
    /// <summary>
    /// Class for list of temporal expressions
    /// required by the composite pattern.
    /// </summary>
    public abstract class TEList : TemporalExpression
    {
        protected List<TemporalExpression> Expressions;

        public TEList()
        {
            this.Expressions = new List<TemporalExpression>();    
        }

        /// <summary>
        /// Adds a temporal expression to the list
        /// </summary>
        /// <param name="expr">Temporal expression to add.</param>
        public void Add(TemporalExpression expr)
        {
            this.Expressions.Add(expr);    
        }

    }
}
