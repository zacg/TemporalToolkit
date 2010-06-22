using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemporalToolkit
{

    public enum Quarter
    {
        Unset = 0,
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4
    }
    
    public enum IntervalPrecision
    {
        Unset = 0,
        Seconds = 1,
        Minutes = 2,
        Hours = 3,
        Days = 4,
        Weeks = 5,
        Months = 6,
        //Quarters = 7,
        Years = 8
    }

    public enum Month
    {
        Unset = 0,
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }
}
