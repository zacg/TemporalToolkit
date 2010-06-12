using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TemporalToolkit.TemporalExpressions;

namespace TemporalToolkit.Tests
{
    [TestFixture]
    public class ExpressionTimeTests
    {

        [Test]
        public void TE_Hour()
        {
            //hour
            TEHour te = new TEHour(1);

            Assert.IsTrue(te.Includes(new DateTime(2010,6,5,1,1,1)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 6, 5, 1, 2, 1)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 6, 5, 1, 1, 3)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 6, 7, 1, 1, 1)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 8, 5, 1, 1, 1)));
            Assert.IsTrue(te.Includes(new DateTime(2011, 6, 5, 1, 1, 1)));

            Assert.IsFalse(te.Includes(new DateTime(2010, 6, 5, 2, 1, 1)));

            //hour range
            TEHour ter = new TEHour(12, 14);
            Assert.IsTrue(ter.Includes(new DateTime(2010, 6, 5, 12, 1, 1)));
            Assert.IsTrue(ter.Includes(new DateTime(2010, 6, 5, 13, 1, 1)));
            Assert.IsTrue(ter.Includes(new DateTime(2010, 6, 5, 14, 1, 1)));
            Assert.IsTrue(ter.Includes(new DateTime(2010, 6, 5, 12, 1, 2)));
            Assert.IsTrue(ter.Includes(new DateTime(2010, 6, 5, 13, 7, 1)));
            Assert.IsTrue(ter.Includes(new DateTime(2010, 6, 9, 14, 1, 1)));
            Assert.IsTrue(ter.Includes(new DateTime(2010, 9, 5, 12, 1, 1)));
            Assert.IsTrue(ter.Includes(new DateTime(2011, 6, 5, 13, 1, 1)));
            
            Assert.IsFalse(ter.Includes(new DateTime(2010, 6, 5, 15, 1, 1)));
        }
    }
}
