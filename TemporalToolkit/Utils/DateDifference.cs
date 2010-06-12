using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemporalToolkit.Utils
{
    public class DateDifference
    {
        /// <summary>
        /// defining Number of days in month; index 0=> january and 11=> December
        /// february contain either 28 or 29 days, that's why here value is -1
        /// which wil be calculate later.
        /// Taken from: http://babuwant2do.wordpress.com/
        /// </summary>
        private int[] monthDay = new int[12] { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        /// <summary>
        /// contain from date
        /// </summary>
        private DateTime fromDate;

        /// <summary>
        /// contain To Date
        /// </summary>
        private DateTime toDate;

               
        public int Years { get; set; }
        public int Months { get; set; }
        public int Days { get; set; }

        public int TotalMonths
        {
            get
            {
                return (this.Years * 12) + this.Months;
            }
        }

        public DateDifference(DateTime d1, DateTime d2)
        {
            int increment;

            if (d1 > d2)
            {
                this.fromDate = d2;
                this.toDate = d1;
            }
            else
            {
                this.fromDate = d1;
                this.toDate = d2;
            }

            /// 
            /// Day Calculation
            /// 
            increment = 0;

            if (this.fromDate.Day > this.toDate.Day)
            {
                increment = this.monthDay[this.fromDate.Month - 1];

            }
            /// if it is february month
            /// if it's to day is less then from day
            if (increment == -1)
            {
                if (DateTime.IsLeapYear(this.fromDate.Year))
                {
                    // leap year february contain 29 days
                    increment = 29;
                }
                else
                {
                    increment = 28;
                }
            }
            if (increment != 0)
            {
                this.Days = (this.toDate.Day + increment) - this.fromDate.Day;
                increment = 1;
            }
            else
            {
                this.Days = this.toDate.Day - this.fromDate.Day;
            }

            ///
            ///month calculation
            ///
            if ((this.fromDate.Month + increment) > this.toDate.Month)
            {
                this.Months = (this.toDate.Month + 12) - (this.fromDate.Month + increment);
                increment = 1;
            }
            else
            {
                this.Months = (this.toDate.Month) - (this.fromDate.Month + increment);
                increment = 0;
            }

            ///
            /// year calculation
            ///
            this.Years = this.toDate.Year - (this.fromDate.Year + increment);

        }

        public override string ToString()
        {
            //return base.ToString();
            return this.Years + " Year(s), " + this.Months + " month(s), " + this.Days + " day(s)";
        }

        
    }
}
