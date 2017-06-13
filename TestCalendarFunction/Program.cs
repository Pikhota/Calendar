using System;
using System.Collections.Generic;
using Calendar;

namespace TestCalendarFunction
{
    internal class Program
    {
        private static void Main()
        {
            var startDate = Function.GetDate();
            var duration = Function.Duration;
            var weekends = new List<DateTime>();
            weekends.AddRange(Function.Weekends(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25)));
            
            Console.WriteLine($"Finish date is:{Function.GetFinalDate(startDate, duration, weekends)}");
            Console.ReadLine();
        }
    }
}
