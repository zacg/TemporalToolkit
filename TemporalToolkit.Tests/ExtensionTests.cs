using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TemporalToolkit.Extensions; 

namespace TemporalToolkit.Tests
{
    [TestFixture]
    public class ExtensionTests
    {

        /// <summary>
        /// Tests EndOfWeek() date extension method
        /// </summary>
        [Test]
        public void WeekEnd()
        {
            DateTime d = new DateTime(2010, 6, 15);
            Assert.AreEqual(new DateTime(2010, 6, 19), d.EndOfWeek());

            DateTime d1 = new DateTime(2010, 6, 15, 1, 2, 3);
            Assert.AreEqual(new DateTime(2010, 6, 19), d1.EndOfWeek());

            DateTime d2 = new DateTime(2010, 6, 20);
            Assert.AreEqual(new DateTime(2010, 6, 26), d2.EndOfWeek());

            DateTime d3 = new DateTime(2010, 7, 3);
            Assert.AreEqual(new DateTime(2010, 7, 3), d3.EndOfWeek());
        }
        
        /// <summary>
        /// Tests StartOfWeek() date extension method
        /// </summary>
        [Test]
        public void WeekStart()
        {
            DateTime d = new DateTime(2010, 6, 15);
            Assert.AreEqual(new DateTime(2010,6,13), d.StartOfWeek());

            DateTime d1 = new DateTime(2010, 6, 15,1,2,3);
            Assert.AreEqual(new DateTime(2010, 6, 13), d1.StartOfWeek());

            DateTime d2 = new DateTime(2010, 6, 20);
            Assert.AreEqual(new DateTime(2010, 6, 20), d2.StartOfWeek());
        }
        
        /// <summary>
        /// Tests DateOccurrence() date extension method
        /// </summary>
        [Test]
        public void DateOccurrence()
        {
           
            DateTime d = new DateTime(2010, 6, 9);
            Assert.IsTrue(d.OccurrenceOfDayInMonth() == 2);

            DateTime d1 = new DateTime(2010, 6, 7);
            Assert.IsTrue(d1.OccurrenceOfDayInMonth() == 1);

            DateTime d2 = new DateTime(2010, 6, 25);
            Assert.IsTrue(d2.OccurrenceOfDayInMonth() == 4);

            DateTime d3 = new DateTime(2010, 7, 4);
            Assert.IsTrue(d3.OccurrenceOfDayInMonth() == 1);

        }

        /// <summary>
        /// Tests Quarter date extension method
        /// </summary>
        [Test]
        public void Quarter()
        {
            Assert.AreEqual(1,new DateTime(2010,1,1).Quarter());
            Assert.AreEqual(1, new DateTime(2010, 2, 1).Quarter());
            Assert.AreEqual(1, new DateTime(2010, 3, 1).Quarter());
            Assert.AreEqual(2, new DateTime(2010, 4, 1).Quarter());
            Assert.AreEqual(2, new DateTime(2010, 5, 1).Quarter());
            Assert.AreEqual(2, new DateTime(2010, 6, 1).Quarter());
            Assert.AreEqual(3, new DateTime(2010, 7, 1).Quarter());
            Assert.AreEqual(3, new DateTime(2010, 8, 1).Quarter());
            Assert.AreEqual(3, new DateTime(2010, 9, 1).Quarter());
            Assert.AreEqual(4, new DateTime(2010, 10, 1).Quarter());
            Assert.AreEqual(4, new DateTime(2010, 11, 1).Quarter());
            Assert.AreEqual(4, new DateTime(2010, 12, 1).Quarter());
        }

    }
}
