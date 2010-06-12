using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TemporalToolkit.Extensions;


namespace TemporalToolkit.TemporalExpressions
{
    
    /// <summary>
    /// Day of month temporal expression checks for a day of the month
    /// e.g: the 4th tuesday
    /// </summary>
    public class TEDayOfMonth: TemporalExpression
    {
        public System.DayOfWeek Day { get; set; }
        public int Occurrence { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="day">Day of week</param>
        /// <param name="occurrence">Occurrence of day in the month. Use negative integers to
        /// count from end of month. e.g -1 = last occurrence</param>
        public TEDayOfMonth(System.DayOfWeek day, int occurrence)
        {
            this.Day = day;
            this.Occurrence = occurrence;
        }

        /// <summary>
        /// Returns true if occurence of day and day of week match
        /// </summary>
        /// <param name="aDate"></param>
        /// <returns></returns>
        public override bool Includes(DateTime aDate)
        {
            if (Occurrence < 0)
            {
                int index = (DateTime.DaysInMonth(aDate.Year, aDate.Month) - aDate.Day) + 1;
                index = ((index - 1) / 7) + 1;
                return (aDate.DayOfWeek == this.Day && index == Math.Abs(this.Occurrence));
            }
            else
                return (aDate.DayOfWeek == this.Day && aDate.OccurrenceOfDayInMonth() == this.Occurrence);
        }
    }
}
