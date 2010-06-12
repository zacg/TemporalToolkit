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
        /// Returns the quater the date is in assuming
        /// quarters start jan 1st
        /// </summary>
        /// <param name="aDate"></param>
        /// <returns></returns>
        public static int Quarter(this System.DateTime aDate)
        {
            return (int)Math.Ceiling((double)(aDate.Month / 3M));
        }

    }
}
