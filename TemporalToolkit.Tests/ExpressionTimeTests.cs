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
        public void TE_Second()
        {
            //seconds value   
            TESecond te = new TESecond(20);
            Assert.IsTrue(te.Includes(new DateTime(2010, 6, 5, 1, 1, 20)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 6, 5, 5, 1, 20)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 6, 5, 1, 7, 20)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 6, 8, 1, 30, 20)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 9, 5, 1, 1, 20)));
            Assert.IsTrue(te.Includes(new DateTime(2011, 6, 5, 1, 1, 20)));

            Assert.IsFalse(te.Includes(new DateTime(2010, 6, 5, 2, 1, 1)));
            Assert.IsFalse(te.Includes(new DateTime(2010, 6, 5, 2, 1, 29)));

            //seconds range
            TESecond ter = new TESecond(20,40);
            Assert.IsTrue(ter.Includes(new DateTime(2010, 6, 5, 1, 1, 20)));
            Assert.IsTrue(ter.Includes(new DateTime(2010, 6, 5, 5, 1, 21)));
            Assert.IsTrue(ter.Includes(new DateTime(2010, 6, 5, 1, 7, 22)));
            Assert.IsTrue(ter.Includes(new DateTime(2010, 6, 8, 1, 30, 30)));
            Assert.IsTrue(ter.Includes(new DateTime(2010, 9, 5, 1, 1, 35)));
            Assert.IsTrue(ter.Includes(new DateTime(2011, 6, 5, 1, 1, 40)));

            Assert.IsFalse(ter.Includes(new DateTime(2010, 6, 5, 2, 1, 19)));
            Assert.IsFalse(ter.Includes(new DateTime(2010, 6, 5, 2, 1, 41)));

            TESecond ter2 = new TESecond(40, 5);
            Assert.IsTrue(ter2.Includes(new DateTime(2010, 6, 5, 1, 1, 40)));
            Assert.IsTrue(ter2.Includes(new DateTime(2010, 6, 5, 5, 1, 41)));
            Assert.IsTrue(ter2.Includes(new DateTime(2010, 6, 5, 1, 7, 50)));
            Assert.IsTrue(ter2.Includes(new DateTime(2010, 6, 8, 1, 30, 55)));
            Assert.IsTrue(ter2.Includes(new DateTime(2010, 9, 5, 1, 1, 1)));
            Assert.IsTrue(ter2.Includes(new DateTime(2011, 6, 5, 1, 1, 5)));

            Assert.IsFalse(ter2.Includes(new DateTime(2010, 6, 5, 2, 1, 39)));
            Assert.IsFalse(ter2.Includes(new DateTime(2010, 6, 5, 2, 1, 6)));
            Assert.IsFalse(ter2.Includes(new DateTime(2010, 6, 5, 2, 1, 20)));

        }

        [Test]
        public void TE_Minute()
        {
            //minute value
            TEMinute te = new TEMinute(30);
            Assert.IsTrue(te.Includes(new DateTime(2010, 6, 5, 1, 30, 1)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 6, 5, 5, 30, 1)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 6, 5, 1, 30, 7)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 6, 8, 1, 30, 1)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 9, 5, 1, 30, 1)));
            Assert.IsTrue(te.Includes(new DateTime(2011, 6, 5, 1, 30, 1)));

            Assert.IsFalse(te.Includes(new DateTime(2010, 6, 5, 2, 1, 1)));
            Assert.IsFalse(te.Includes(new DateTime(2010, 6, 5, 2, 29, 1)));

            //minute range
            TEMinute ter = new TEMinute(30,45);

            Assert.IsTrue(ter.Includes(new DateTime(2010, 6, 5, 1, 30, 1)));
            Assert.IsTrue(ter.Includes(new DateTime(2010, 6, 5, 5, 31, 1)));
            Assert.IsTrue(ter.Includes(new DateTime(2010, 6, 5, 1, 32, 7)));
            Assert.IsTrue(ter.Includes(new DateTime(2010, 6, 8, 1, 30, 1)));
            Assert.IsTrue(ter.Includes(new DateTime(2010, 9, 5, 1, 40, 1)));
            Assert.IsTrue(ter.Includes(new DateTime(2011, 6, 5, 1, 30, 1)));

            Assert.IsFalse(ter.Includes(new DateTime(2010, 6, 5, 2, 1, 1)));
            Assert.IsFalse(ter.Includes(new DateTime(2010, 6, 5, 2, 29, 1)));
            Assert.IsFalse(ter.Includes(new DateTime(2010, 6, 5, 2, 50, 1)));

            //minute range with start > end
            TEMinute ter2 = new TEMinute(45, 5);

            Assert.IsTrue(ter2.Includes(new DateTime(2010, 6, 5, 1, 46, 1)));
            Assert.IsTrue(ter2.Includes(new DateTime(2010, 6, 5, 5, 50, 1)));
            Assert.IsTrue(ter2.Includes(new DateTime(2010, 6, 5, 1, 1, 7)));
            Assert.IsTrue(ter2.Includes(new DateTime(2010, 6, 8, 1, 2, 1)));
            Assert.IsTrue(ter2.Includes(new DateTime(2010, 9, 5, 1, 55, 1)));
            Assert.IsTrue(ter2.Includes(new DateTime(2011, 6, 5, 1, 5, 1)));

            Assert.IsFalse(ter2.Includes(new DateTime(2010, 6, 5, 2, 44, 1)));
            Assert.IsFalse(ter2.Includes(new DateTime(2010, 6, 5, 2, 29, 1)));
            Assert.IsFalse(ter2.Includes(new DateTime(2010, 6, 5, 2, 6, 1)));
        }
        
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
