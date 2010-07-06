using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TemporalToolkit.TemporalExpressions;

namespace TemporalToolkit.Tests
{
    [TestFixture]
    public class ExpressionBaseTests
    {
        [Test]
        public void OccurrencesHour()
        {
            TemporalExpression te = new TEHour(3);
            List<DateTime> dates = te.Occurrences(new DateTime(2010, 6, 1), new DateTime(2010,6,4),IntervalPrecision.Hours);
            Assert.AreEqual(3,dates.Count);
            Assert.AreEqual(new DateTime(2010, 6, 1, 3, 0, 0), dates[0]);
            Assert.AreEqual(new DateTime(2010, 6, 2, 3, 0, 0), dates[1]);
            Assert.AreEqual(new DateTime(2010, 6, 3, 3, 0, 0), dates[2]);

            List<DateTime> dates2 = te.Occurrences(new DateTime(2010, 7, 1), 3,IntervalPrecision.Hours);
            Assert.AreEqual(3, dates2.Count);
            Assert.AreEqual(new DateTime(2010, 7, 1, 3, 0, 0), dates2[0]);
            Assert.AreEqual(new DateTime(2010, 7, 2, 3, 0, 0), dates2[1]);
            Assert.AreEqual(new DateTime(2010, 7, 3, 3, 0, 0), dates2[2]);

        }

        [Test]
        public void OccurrenceMinute()
        {
            TemporalExpression te = new TEMinute(45);
            List<DateTime> dates = te.Occurrences(new DateTime(2010, 6, 1), new DateTime(2010, 6, 2), IntervalPrecision.Minutes);
            Assert.AreEqual(24, dates.Count);
            Assert.AreEqual(new DateTime(2010, 6, 1, 0, 45, 0), dates[0]);
            Assert.AreEqual(new DateTime(2010, 6, 1, 23, 45, 0), dates[23]);

            List<DateTime> dates2 = te.Occurrences(new DateTime(2010, 6, 1), 12, IntervalPrecision.Minutes);
            Assert.AreEqual(12, dates2.Count);
            Assert.AreEqual(new DateTime(2010, 6, 1, 0, 45, 0), dates2[0]);
            Assert.AreEqual(new DateTime(2010, 6, 1, 11, 45, 0), dates2[11]);
        }

        [Test]
        public void OccurrenceSecond()
        {
            TemporalExpression te = new TESecond(45);
            List<DateTime> dates = te.Occurrences(new DateTime(2010, 6, 1), new DateTime(2010, 6, 2), IntervalPrecision.Seconds);
            Assert.AreEqual(1440, dates.Count);
            Assert.AreEqual(new DateTime(2010, 6, 1, 0, 0, 45), dates[0]);
            Assert.AreEqual(new DateTime(2010, 6, 1, 23, 59, 45), dates[1439]);

            List<DateTime> dates2 = te.Occurrences(new DateTime(2010, 6, 1), 720, IntervalPrecision.Seconds);
            Assert.AreEqual(720, dates2.Count);
            Assert.AreEqual(new DateTime(2010, 6, 1, 0, 0, 45), dates2[0]);
            Assert.AreEqual(new DateTime(2010, 6, 1, 11, 59, 45), dates2[719]);
        }

        [Test]
        public void OccurrenceDay()
        {
            TemporalExpression te = new TEDayInMonth(3);
            List<DateTime> dates = te.Occurrences(new DateTime(2010, 6, 1), new DateTime(2011, 6, 5), IntervalPrecision.Days);
            Assert.AreEqual(13, dates.Count);
            Assert.AreEqual(new DateTime(2010, 6, 3, 0, 0, 0), dates[0]);
            Assert.AreEqual(new DateTime(2011, 6, 3, 0, 0, 0), dates[12]);

            List<DateTime> dates2 = te.Occurrences(new DateTime(2010, 6, 1), 12, IntervalPrecision.Days);
            Assert.AreEqual(12, dates2.Count);
            Assert.AreEqual(new DateTime(2010, 6, 3, 0, 0, 0), dates2[0]);
            Assert.AreEqual(new DateTime(2011, 5, 3, 0, 0, 0), dates2[11]);
        }

        [Test]
        public void OccurrenceWeek()
        {
            TemporalExpression te = new TEInterval(new DateTime(2010, 6, 1), 1, IntervalPrecision.Weeks);
            
            List<DateTime> dates = te.Occurrences(new DateTime(2010, 6, 1), new DateTime(2011, 6, 5), IntervalPrecision.Weeks);
            Assert.AreEqual(53, dates.Count);
            Assert.AreEqual(new DateTime(2010, 6, 1, 0, 0, 0), dates[0]);
            Assert.AreEqual(new DateTime(2011, 5, 31, 0, 0, 0), dates[52]);

            List<DateTime> dates2 = te.Occurrences(new DateTime(2010, 6, 1), 12, IntervalPrecision.Weeks);
            Assert.AreEqual(12, dates2.Count);
            Assert.AreEqual(new DateTime(2010, 6, 1, 0, 0, 0), dates2[0]);
            Assert.AreEqual(new DateTime(2010, 8, 17, 0, 0, 0), dates2[11]);
        }

    }
}
