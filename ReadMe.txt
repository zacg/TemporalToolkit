Temporal Toolkit Read Me
==============================

------------------------------
| About
------------------------------
 
 Version 1.0.0 (2010/6/11)

 Temporal Toolkit is a library used for representing/manipulating dates & time.
 
 The temporal expressions are based on a paper by Martin Fowler (www.martinfowler.com/apsupp/recurring.pdf).
 and the ruby runt library (www.runt.rubyforge.org)
 
 

------------------------------
| Getting Started
------------------------------
 
 Add reference to TemporalToolkit.dll to your project.   
    
    --------------------------
    | Using Temporal Expressions
    --------------------------
        Add the following to the top of your code:
                C#: using TemporalToolkit.TemporalExpressions;
            VB.NET: Imports TemporalToolkit.TemporalExpressions
        
        Then use operators: &,|,- to build temporal expressions.
          TemporalExpression te = new TEYear(2010) & TEMonthInDay(1,3);
          bool result = te.Includes(new DateTime(2010,1,1));
        
    ---------------------------
    | Using Date Extension Methods
    ---------------------------
            C#: using TemporalToolkit.Extensions;
        VB.NET: Imports TemporalToolkit.Extensions;    