using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace TemporalToolkit.Extensions
{
    public static class DateExtensions
    {
        /// <summary>
        /// Returns the occurrence of the day in the month as an integer e.g. 4th wednesday in month.
        /// </summary>
        /// <param name="aDate"></param>
        /// <returns></returns>
        public static int OccurrenceOfDayInMonth(this System.DateTime aDate)
        {
            return ((aDate.Day - 1) / 7) + 1;
        }

        /// <summary>
        /// Returns start of the week assuming the week starts on saturday
        /// </summary>
        /// <param name="aDate"></param>
        /// <returns></returns>
        public static System.DateTime StartOfWeek(this System.DateTime aDate)
        {
            int offset = (int)aDate.DayOfWeek * -1;
            DateTime temp = aDate.AddDays(offset);
            return new DateTime(temp.Year, temp.Month, temp.Day);
        }


        /// <summary>
        /// Returns the end of the week assuming the week ends on sunday
        /// </summary>
        /// <param name="aDate"></param>
        /// <returns></returns>
        public static System.DateTime EndOfWeek(this System.DateTime aDate)
        {
            int offset = 6 - (int)aDate.DayOfWeek;
            DateTime temp = aDate.AddDays(offset);
            return new DateTime(temp.Year, temp.Month, temp.Day);
            
        }

        /// <summary>
        /// Returns the quater the date is in, assuming
        /// the year starts jan 1st
        /// </summary>
        /// <param name="aDate"></param>
        /// <returns></returns>
        public static Quarter Quarter(this System.DateTime aDate)
        {
            return aDate.Quarter(Month.January);
        }

        /// <summary>
        /// Returns quarter date is in based on specifed
        /// start of year
        /// </summary>
        /// <param name="aDate"></param>
        /// <param name="startOfQuarter">Start of the year</param>
        /// <returns></returns>
        public static Quarter Quarter(this System.DateTime aDate, Month startOfYear)
        {
            int offset;
            offset = (((int)startOfYear -1) * -1) + aDate.Month;
            if(offset <= 0) offset = 12 - (Math.Abs(offset));
            return (Quarter)Math.Ceiling((double)((offset) / 3M));
        }

    }
}
