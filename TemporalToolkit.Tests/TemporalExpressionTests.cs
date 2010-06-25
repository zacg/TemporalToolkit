using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TemporalToolkit.TemporalExpressions;

namespace TemporalToolkit.Tests
{
    [TestFixture]
    public class TemporalExpressionTests
    {

        //Tests month temporal expression
        [Test]
        public void TE_Month()
        {
            //SIngle Month
            TEMonth tem = new TEMonth(Month.January);
            Assert.IsTrue(tem.Includes(new DateTime(2010,1,1)));
            Assert.IsTrue(tem.Includes(new DateTime(2011,1,1)));
            Assert.IsTrue(tem.Includes(new DateTime(2011,1,23)));
            Assert.IsFalse(tem.Includes(new DateTime(2011, 2, 1)));
            Assert.IsFalse(tem.Includes(new DateTime(2011, 8, 20)));

            //range
            TEMonth temr = new TEMonth(Month.February, Month.June);
            Assert.IsTrue(temr.Includes(new DateTime(2010, 4, 1)));
            Assert.IsTrue(temr.Includes(new DateTime(2010, 5, 25)));
            Assert.IsTrue(temr.Includes(new DateTime(2010, 2, 1)));
            Assert.IsTrue(temr.Includes(new DateTime(2010, 6, 30)));
            Assert.IsFalse(temr.Includes(new DateTime(2011, 8, 20)));
            Assert.IsFalse(temr.Includes(new DateTime(2011, 9, 10)));
            Assert.IsFalse(temr.Includes(new DateTime(2011, 12, 1)));

        }

        [Test]
        public void TE_Weekday()
        {
            //single day
            TEWeekDay tew = new TEWeekDay(DayOfWeek.Wednesday);
            Assert.IsTrue(tew.Includes(new DateTime(2010, 6, 2)));
            Assert.IsTrue(tew.Includes(new DateTime(2010, 6, 23)));
            Assert.IsTrue(tew.Includes(new DateTime(2011, 6, 8)));
            Assert.IsTrue(tew.Includes(new DateTime(2010, 7, 7)));
            Assert.IsFalse(tew.Includes(new DateTime(2010, 6, 1)));
            Assert.IsFalse(tew.Includes(new DateTime(2010, 6, 14)));
            Assert.IsFalse(tew.Includes(new DateTime(2010, 7, 12)));

            //range
            TEWeekDay tewr = new TEWeekDay(DayOfWeek.Monday, DayOfWeek.Friday);

            Assert.IsFalse(tew.Includes(new DateTime(2010, 6, 6)));
            Assert.IsTrue(tewr.Includes(new DateTime(2010, 6, 7)));
            Assert.IsTrue(tewr.Includes(new DateTime(2010, 6, 8)));
            Assert.IsTrue(tewr.Includes(new DateTime(2010, 6, 9)));
            Assert.IsTrue(tewr.Includes(new DateTime(2010, 6, 10)));
            Assert.IsTrue(tewr.Includes(new DateTime(2010, 6, 11)));
            Assert.IsFalse(tew.Includes(new DateTime(2010, 6, 12)));
            
            Assert.IsFalse(tew.Includes(new DateTime(2010, 7, 4)));
            Assert.IsTrue(tewr.Includes(new DateTime(2010, 7, 5)));
            Assert.IsTrue(tewr.Includes(new DateTime(2010, 7, 7)));

            Assert.IsTrue(tewr.Includes(new DateTime(2011, 6, 15)));
        }

        [Test]
        public void TE_Year()
        {
            //single year
            TEYear tey = new TEYear(2010);
            Assert.IsTrue(tey.Includes(new DateTime(2010, 6, 2)));
            Assert.IsTrue(tey.Includes(new DateTime(2010, 8, 2)));
            Assert.IsTrue(tey.Includes(new DateTime(2010, 9, 5)));

            Assert.IsFalse(tey.Includes(new DateTime(2011, 6, 2)));
            Assert.IsFalse(tey.Includes(new DateTime(2012, 8, 2)));
            Assert.IsFalse(tey.Includes(new DateTime(1998, 9, 5)));

            //range
            TEYear teyr = new TEYear(2000, 2005);
            Assert.IsTrue(teyr.Includes(new DateTime(2005, 6, 2)));
            Assert.IsTrue(teyr.Includes(new DateTime(2003, 8, 2)));
            Assert.IsTrue(teyr.Includes(new DateTime(2000, 9, 5)));

            Assert.IsFalse(teyr.Includes(new DateTime(2011, 6, 2)));
            Assert.IsFalse(teyr.Includes(new DateTime(2012, 8, 2)));
            Assert.IsFalse(teyr.Includes(new DateTime(1998, 9, 5)));

        }
             

        [Test]
        public void TE_DayInMonth()
        {
            //single day
            TEDayInMonth tem = new TEDayInMonth(4);
            Assert.IsTrue(tem.Includes(new DateTime(2010, 6, 4)));
            Assert.IsTrue(tem.Includes(new DateTime(2010, 8, 4)));
            Assert.IsTrue(tem.Includes(new DateTime(2011, 9, 4)));

            Assert.IsFalse(tem.Includes(new DateTime(2010, 6, 2)));
            Assert.IsFalse(tem.Includes(new DateTime(2012, 8, 3)));
            Assert.IsFalse(tem.Includes(new DateTime(1998, 9, 5)));

            //range
            TEDayInMonth temr = new TEDayInMonth(5, 10);
            Assert.IsTrue(temr.Includes(new DateTime(2010, 5, 5)));
            Assert.IsTrue(temr.Includes(new DateTime(2010, 8, 7)));
            Assert.IsTrue(temr.Includes(new DateTime(2011, 9, 10)));

            Assert.IsFalse(temr.Includes(new DateTime(2010, 6, 2)));
            Assert.IsFalse(temr.Includes(new DateTime(2012, 8, 3)));
            Assert.IsFalse(temr.Includes(new DateTime(1998, 9, 15)));

            //negative
            TEDayInMonth ten = new TEDayInMonth(-4);
            Assert.IsTrue(ten.Includes(new DateTime(2010, 6, 27)));
            Assert.IsTrue(ten.Includes(new DateTime(2010, 7, 28)));
            Assert.IsTrue(ten.Includes(new DateTime(2010, 5, 28)));

            Assert.IsFalse(ten.Includes(new DateTime(2010, 6, 26)));
            Assert.IsFalse(ten.Includes(new DateTime(2010, 7, 29)));
            Assert.IsFalse(ten.Includes(new DateTime(2010, 5, 27)));

        }

        [Test]
        public void TE_DayOfMonth()
        {
            //Single occurrence from start of month
            TEDayOfMonth tem = new TEDayOfMonth(DayOfWeek.Monday, 1);
            Assert.IsTrue(tem.Includes(new DateTime(2010, 6, 7)));
            Assert.IsTrue(tem.Includes(new DateTime(2010, 7, 5)));
            Assert.IsTrue(tem.Includes(new DateTime(2011, 6, 6)));

            Assert.IsFalse(tem.Includes(new DateTime(2010, 6, 8)));
            Assert.IsFalse(tem.Includes(new DateTime(2010, 6, 3)));
            Assert.IsFalse(tem.Includes(new DateTime(2011, 6, 7)));

            //test counting from end of month (-1 == last occurrence)
            TEDayOfMonth tem2 = new TEDayOfMonth(DayOfWeek.Thursday, -1);
            Assert.IsTrue(tem2.Includes(new DateTime(2010, 6, 24)));
            Assert.IsTrue(tem2.Includes(new DateTime(2010, 7, 29)));
            Assert.IsTrue(tem2.Includes(new DateTime(2011, 6, 30)));

            Assert.IsFalse(tem2.Includes(new DateTime(2010, 6, 8)));
            Assert.IsFalse(tem2.Includes(new DateTime(2010, 6, 25)));
            Assert.IsFalse(tem2.Includes(new DateTime(2011, 6, 29)));



        }

        [Test]
        public void TE_Before()
        {
            TEBefore teb = new TEBefore(new DateTime(2010,1,1));

            Assert.IsTrue(teb.Includes(new DateTime(2009, 6, 7)));
            Assert.IsTrue(teb.Includes(new DateTime(2009, 7, 5)));
            Assert.IsTrue(teb.Includes(new DateTime(2000, 6, 6)));

            Assert.IsFalse(teb.Includes(new DateTime(2010, 6, 8)));
            Assert.IsFalse(teb.Includes(new DateTime(2010, 6, 3)));
            Assert.IsFalse(teb.Includes(new DateTime(2011, 6, 7)));
        }

        [Test]
        public void TE_After()
        {
            TEAfter teb = new TEAfter(new DateTime(2010, 1, 10));

            Assert.IsTrue(teb.Includes(new DateTime(2010, 1, 17)));
            Assert.IsTrue(teb.Includes(new DateTime(2010, 7, 5)));
            Assert.IsTrue(teb.Includes(new DateTime(2011, 6, 6)));

            Assert.IsFalse(teb.Includes(new DateTime(2009, 6, 8)));
            Assert.IsFalse(teb.Includes(new DateTime(2010, 1, 3)));
            Assert.IsFalse(teb.Includes(new DateTime(2000, 6, 7)));
        }

        [Test]
        public void TE_Interval()
        {
            //seconds interval
            TEInterval tis = new TEInterval(new DateTime(2010, 6, 1, 0, 0, 1), 5, IntervalPrecision.Seconds);
            Assert.IsTrue(tis.Includes(new DateTime(2010, 6, 3,0,0,6)));
            Assert.IsTrue(tis.Includes(new DateTime(2010, 6, 3, 0, 0, 11)));
            Assert.IsTrue(tis.Includes(new DateTime(2011, 6, 3, 0, 0, 11)));
            Assert.IsTrue(tis.Includes(new DateTime(2011, 7, 7, 7, 9, 11)));

            Assert.IsFalse(tis.Includes(new DateTime(2010, 6, 3, 0, 0, 7)));
            Assert.IsFalse(tis.Includes(new DateTime(2010, 6, 3, 0, 0, 4)));
            Assert.IsFalse(tis.Includes(new DateTime(2011, 6, 3, 0, 0, 10)));
            Assert.IsFalse(tis.Includes(new DateTime(2011, 7, 7, 7, 9, 20)));

            //minutes interval
            TEInterval tim = new TEInterval(new DateTime(2010, 6, 1, 0, 0, 0), 5, IntervalPrecision.Minutes);
            Assert.IsTrue(tim.Includes(new DateTime(2010, 6, 3, 0, 5, 0)));
            Assert.IsTrue(tim.Includes(new DateTime(2010, 6, 3, 0, 10, 0)));
            Assert.IsTrue(tim.Includes(new DateTime(2011, 6, 3, 0, 25, 0)));
            Assert.IsTrue(tim.Includes(new DateTime(2011, 7, 7, 4, 45, 9)));

            Assert.IsFalse(tim.Includes(new DateTime(2010, 6, 3, 0, 2, 0)));
            Assert.IsFalse(tim.Includes(new DateTime(2010, 6, 3, 0, 11, 0)));
            Assert.IsFalse(tim.Includes(new DateTime(2011, 6, 3, 0, 27, 0)));
            Assert.IsFalse(tim.Includes(new DateTime(2011, 7, 7, 4, 47, 9)));

            //day interval
            TEInterval tid = new TEInterval(new DateTime(2010, 6, 1,5,3,1), 2, IntervalPrecision.Days);
            Assert.IsTrue(tid.Includes(new DateTime(2010, 6, 3)));
            Assert.IsTrue(tid.Includes(new DateTime(2010, 6, 3,8,8,8)));
            Assert.IsTrue(tid.Includes(new DateTime(2010, 7, 1)));

            Assert.IsFalse(tid.Includes(new DateTime(2010, 6, 2)));
            Assert.IsFalse(tid.Includes(new DateTime(2010, 6, 4,5,3,1)));
            Assert.IsFalse(tid.Includes(new DateTime(2010, 6, 6)));
            Assert.IsFalse(tid.Includes(new DateTime(2010, 7, 2)));

            //week interval
            TEInterval tiw = new TEInterval(new DateTime(2010, 6, 1, 5, 3, 1), 3, IntervalPrecision.Weeks);
            Assert.IsTrue(tiw.Includes(new DateTime(2010, 6, 23)));
            Assert.IsTrue(tiw.Includes(new DateTime(2010, 6, 24)));
            Assert.IsTrue(tiw.Includes(new DateTime(2010, 6, 20)));
            Assert.IsTrue(tiw.Includes(new DateTime(2010, 6, 26)));
            Assert.IsTrue(tiw.Includes(new DateTime(2010, 7, 11, 8, 8, 8)));
            Assert.IsTrue(tiw.Includes(new DateTime(2010, 7, 17, 8, 8, 8)));
            Assert.IsTrue(tiw.Includes(new DateTime(2010, 8, 4)));

            Assert.IsFalse(tiw.Includes(new DateTime(2010, 6, 16)));
            Assert.IsFalse(tiw.Includes(new DateTime(2010, 6, 9)));
            Assert.IsFalse(tiw.Includes(new DateTime(2010, 6, 30)));
            Assert.IsFalse(tiw.Includes(new DateTime(2010, 7, 10)));

            //month interval
            TEInterval timo = new TEInterval(new DateTime(2010, 6, 1, 5, 3, 1), 3, IntervalPrecision.Months);
            Assert.IsTrue(timo.Includes(new DateTime(2010, 9, 23)));
            Assert.IsTrue(timo.Includes(new DateTime(2010, 12, 1)));
            Assert.IsTrue(timo.Includes(new DateTime(2011, 6, 5)));
            Assert.IsTrue(timo.Includes(new DateTime(2011, 9, 1,5,3,2)));

            Assert.IsFalse(timo.Includes(new DateTime(2010, 10, 23)));
            Assert.IsFalse(timo.Includes(new DateTime(2011, 1, 4)));
            Assert.IsFalse(timo.Includes(new DateTime(2010, 11, 23,1,1,1)));

            //quarter interval
            //TEInterval tiq = new TEInterval(new DateTime(2010, 6, 1, 5, 3, 1), 2, IntervalPrecision.Quarters);
            //Assert.IsTrue(tiq.Includes(new DateTime(2010, 12, 23)));
            //Assert.IsTrue(tiq.Includes(new DateTime(2010, 12, 1)));
            //Assert.IsTrue(tiq.Includes(new DateTime(2011, 6, 5)));
            //Assert.IsTrue(tiq.Includes(new DateTime(2011, 6, 1, 5, 3, 2)));

            //Assert.IsFalse(tiq.Includes(new DateTime(2010, 11, 23)));
            //Assert.IsFalse(tiq.Includes(new DateTime(2010, 11, 1)));
            //Assert.IsFalse(tiq.Includes(new DateTime(2011, 8, 5)));
            //Assert.IsFalse(tiq.Includes(new DateTime(2011, 5, 1, 5, 3, 2)));

            //year interval
            TEInterval tiy = new TEInterval(new DateTime(2010, 6, 1, 5, 3, 1), 2, IntervalPrecision.Years);
            Assert.IsTrue(tiy.Includes(new DateTime(2012, 12, 23)));
            Assert.IsTrue(tiy.Includes(new DateTime(2012, 12, 7)));
            Assert.IsTrue(tiy.Includes(new DateTime(2014, 6, 5)));
            Assert.IsTrue(tiy.Includes(new DateTime(2016, 6, 1, 5, 3, 2)));

            Assert.IsFalse(tiy.Includes(new DateTime(2011, 12, 23)));
            Assert.IsFalse(tiy.Includes(new DateTime(2013, 12, 23)));
            Assert.IsFalse(tiy.Includes(new DateTime(2015, 6, 1, 5, 3, 2)));

        }

        [Test]
        public void TE_Quarter()
        {
            //single quarter jan 1st start of year
            TEQuarter te = new TEQuarter(Quarter.First);
            Assert.IsTrue(te.Includes(new DateTime(2010, 1, 1)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 2, 1)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 3, 1)));
            Assert.IsFalse(te.Includes(new DateTime(2010, 4, 1)));

            //range of quarters 2nd-3rd, jan 1st start of year
            TEQuarter ter = new TEQuarter(Quarter.Second, Quarter.Third);
            Assert.IsTrue(ter.Includes(new DateTime(2010, 4, 1)));
            Assert.IsTrue(ter.Includes(new DateTime(2010, 5, 1)));
            Assert.IsTrue(ter.Includes(new DateTime(2010, 6, 1)));
            Assert.IsTrue(ter.Includes(new DateTime(2010, 7, 1)));
            Assert.IsTrue(ter.Includes(new DateTime(2010, 8, 1)));
            Assert.IsTrue(ter.Includes(new DateTime(2010, 9, 1)));
            Assert.IsFalse(ter.Includes(new DateTime(2010, 10, 1)));

            //single quarter July 1st start of year
            TEQuarter tey = new TEQuarter(Quarter.First, Month.July);
            Assert.IsTrue(tey.Includes(new DateTime(2010, 7, 1)));
            Assert.IsTrue(tey.Includes(new DateTime(2010, 8, 1)));
            Assert.IsTrue(tey.Includes(new DateTime(2010, 9, 1)));
            Assert.IsFalse(tey.Includes(new DateTime(2010, 10, 1)));
            Assert.IsFalse(tey.Includes(new DateTime(2010, 6, 1)));

            //range of quarters 2nd-3rd, july 1st start of year
            TEQuarter teyr = new TEQuarter(Quarter.Second, Quarter.Third, Month.July);
            Assert.IsTrue(teyr.Includes(new DateTime(2010, 10, 1)));
            Assert.IsTrue(teyr.Includes(new DateTime(2010, 11, 1)));
            Assert.IsTrue(teyr.Includes(new DateTime(2010, 12, 1)));
            Assert.IsTrue(teyr.Includes(new DateTime(2010, 1, 1)));
            Assert.IsTrue(teyr.Includes(new DateTime(2010, 2, 1)));
            Assert.IsTrue(teyr.Includes(new DateTime(2010, 3, 1)));
            Assert.IsFalse(teyr.Includes(new DateTime(2010, 9, 1)));
            Assert.IsFalse(teyr.Includes(new DateTime(2010, 8, 1)));

        }

        [Test]
        public void UnionTest()
        {
            //And (union)
            TemporalExpression te;
            te = new TEYear(2010) & new TEWeekDay(DayOfWeek.Sunday);

            Assert.IsTrue(te.Includes(new DateTime(2010,6,13)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 6, 20)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 6, 27)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 7, 18)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 5, 23)));

            Assert.IsFalse(te.Includes(new DateTime(2010, 6, 14)));
            Assert.IsFalse(te.Includes(new DateTime(2010, 6, 15)));
            Assert.IsFalse(te.Includes(new DateTime(2010, 7, 19)));
            Assert.IsFalse(te.Includes(new DateTime(2011, 6, 14)));

        }

        [Test]
        public void IntersectTest()
        {
            TemporalExpression te;
            //sunday or wednesday
            te = new TEWeekDay(DayOfWeek.Wednesday) | new TEWeekDay(DayOfWeek.Sunday);

            Assert.IsTrue(te.Includes(new DateTime(2010, 6, 13)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 6, 9)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 7, 18)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 7, 14)));
            Assert.IsTrue(te.Includes(new DateTime(2011, 6, 22)));

            Assert.IsFalse(te.Includes(new DateTime(2010, 6, 14)));
            Assert.IsFalse(te.Includes(new DateTime(2010, 6, 15)));
            Assert.IsFalse(te.Includes(new DateTime(2010, 7, 19)));
            Assert.IsFalse(te.Includes(new DateTime(2011, 6, 14)));
        }

        [Test]
        public void Difference()
        {
            TemporalExpression te;
            //All days in june except sundays
            te = new TEMonth(Month.June) - new TEWeekDay(DayOfWeek.Sunday);

            Assert.IsTrue(te.Includes(new DateTime(2010, 6, 7)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 6, 16)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 6, 18)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 6, 14)));
            Assert.IsTrue(te.Includes(new DateTime(2011, 6, 24)));

            Assert.IsFalse(te.Includes(new DateTime(2010, 6, 6)));
            Assert.IsFalse(te.Includes(new DateTime(2010, 6, 20)));
            Assert.IsFalse(te.Includes(new DateTime(2010, 7, 19)));
            Assert.IsFalse(te.Includes(new DateTime(2011, 6, 19)));
        }

        [Test]
        public void ComplexExpressions()
        {
            TemporalExpression te;
            te = (new TEWeekDay(DayOfWeek.Tuesday) | new TEWeekDay(DayOfWeek.Friday));
            te &= new TEInterval(new DateTime(2010, 6, 1), 2, IntervalPrecision.Weeks);

            Assert.IsTrue(te.Includes(new DateTime(2010,6,1)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 6, 4)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 6, 15)));
            Assert.IsTrue(te.Includes(new DateTime(2010, 6, 18)));

            Assert.IsFalse(te.Includes(new DateTime(2010, 6, 8)));
            Assert.IsFalse(te.Includes(new DateTime(2010, 6, 11)));
            Assert.IsFalse(te.Includes(new DateTime(2010, 6, 10)));
            Assert.IsFalse(te.Includes(new DateTime(2010, 6, 16)));

        }

    }
}
