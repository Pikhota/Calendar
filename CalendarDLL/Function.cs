using System;
using System.Collections.Generic;
using System.Linq;

namespace Calendar
{
    public  class Function
    {
        /// <summary>
        /// Return the date ,which  is counted as a start date + duration, without weekends.
        /// </summary>
        /// <param name="startDate">The first day of the period</param>
        /// <param name="duration">Duration of the period</param>
        /// <param name="weekends">Array of the weekends days</param>
        /// <returns>string</returns>
        public static string GetFinalDate(DateTime startDate, int duration, List<DateTime> weekends)
        {
            var count = 0;
            var arr = new List<DateTime>();
            for (int i = 0, day = startDate.Day, month = startDate.Month, year = startDate.Year; i < duration + count; i++)
            {
                if (i == 0)
                {
                    if (!weekends.Contains(startDate))
                        arr.Add(startDate);
                    else
                        count++;
                    continue;
                }
                day++;

                if (day > DateTime.DaysInMonth(year, month))
                {
                    if (month + 1 > DateTime.MaxValue.Month)
                    {
                        month = 1;
                        year++;
                    }
                    else
                        month++;
                    day = 1;
                }
                var date = new DateTime(year, month, day);
                if (!weekends.Contains(date))
                    arr.Add(date);
                else
                    count++;
            }
            return arr.Max().ToShortDateString();
        }

        /// <summary>
        /// Returns the duration as int.
        /// </summary>
        public static int Duration
        {
            get
            {
                Console.Write("Duration: ");
                int duration;
                int.TryParse(Console.ReadLine(), out duration);
                if (duration <= 0)
                    return 1;
                else
                    return duration;
            }
        }

        /// <summary>
        /// Returns the entered date as DateTime
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDate()
        {
            var minDay = DateTime.MinValue.Day;
            var maxDay = DateTime.MaxValue.Day;
            var minMonth = DateTime.MinValue.Month;
            var maxMonth = DateTime.MaxValue.Month;
            var minYear = DateTime.MinValue.Year;
            var maxYear = DateTime.MaxValue.Year;
            int day;
            int month;
            int year;
            var condition = true;
            const string rules = "Enter the date follow the next rules:\n" +
                                 "1.Enter the numeric of day then press 'Enter'. \n" +
                                 "2.After that enter the numeric of month then press 'Enter'. \n" +
                                 "3.And finally enter the year, after that press 'Enter'.\n";
            var note = "Note!\n" +
                        $"The day can be range from {minDay} to {maxDay}(dependencies from month)\n" +
                        $"The month can be range from {minMonth} to {maxMonth}\n" +
                        $"The year can be range from {minYear} to {maxYear}";
            const string txtStartDate = "Start date: ";
            StartText(rules, note);
            Console.Write(txtStartDate);
            do
            {
                int.TryParse(Console.ReadLine(), out day);
                if (!CheckDay(day, minDay, maxDay))
                {
                    StartText(rules, note);
                    Console.WriteLine($"Please enter the number of day from {minDay} to {maxDay}");
                    Console.Write(txtStartDate);
                }
                else
                    condition = false;
            } while (condition);
            switch (day.ToString().Length)
            {
                case 1:
                    StartText(rules, note);
                    Console.Write($"{txtStartDate}0{day}/");
                    break;
                case 2:
                    StartText(rules, note);
                    Console.Write($"{txtStartDate}{day}/");
                    break;
            }

            condition = true;
            do
            {
                int.TryParse(Console.ReadLine(), out month);
                if (!CheckMonth(month, minMonth, maxMonth))
                {
                    StartText(rules, note);
                    Console.WriteLine($"Please enter the number of month from {minMonth} to {maxMonth}");
                    switch (day.ToString().Length)
                    {
                        case 1:
                            StartText(rules, note);
                            Console.Write($"{txtStartDate}0{day}/");
                            break;
                        case 2:
                            StartText(rules, note);
                            Console.Write($"{txtStartDate}{day}/");
                            break;
                    }
                }
                else
                    condition = false;
            } while (condition);
            switch (month.ToString().Length)
            {
                case 1:
                    switch (day.ToString().Length)
                    {
                        case 1:
                            StartText(rules, note);
                            Console.Write($"{txtStartDate}0{day}/0{month}/");
                            break;
                        case 2:
                            StartText(rules, note);
                            Console.Write($"{txtStartDate}{day}/0{month}/");
                            break;
                        default:
                            StartText(rules, note);
                            Console.WriteLine("Please enter correct a day of date!");
                            break;

                    }
                    break;
                case 2:
                    switch (day.ToString().Length)
                    {
                        case 1:
                            StartText(rules, note);
                            Console.Write($"{txtStartDate}0{day}/{month}/");
                            break;
                        case 2:
                            StartText(rules, note);
                            Console.Write($"{txtStartDate}{day}/{month}/");
                            break;
                        default:
                            StartText(rules, note);
                            Console.WriteLine("Please enter correct a day of date!");
                            break;
                    }
                    break;
            }
            condition = true;
            do
            {
                int.TryParse(Console.ReadLine(), out year);
                if (!CheckYear(year, minYear, maxYear))
                {
                    StartText(rules, note);
                    Console.WriteLine($"Please enter the number of month from {minMonth} to {maxMonth}");
                    switch (month.ToString().Length)
                    {
                        case 1:
                            switch (day.ToString().Length)
                            {
                                case 1:
                                    StartText(rules, note);
                                    Console.Write($"{txtStartDate}0{day}/0{month}/");
                                    break;
                                case 2:
                                    StartText(rules, note);
                                    Console.Write($"{txtStartDate}{day}/0{month}/");
                                    break;
                                default:
                                    StartText(rules, note);
                                    Console.WriteLine("Please enter correct a day of date");
                                    Console.Write($"{txtStartDate}{day}/0{month}/");
                                    break;
                            }
                            break;
                        case 2:
                            switch (day.ToString().Length)
                            {
                                case 1:
                                    StartText(rules, note);
                                    Console.Write($"{txtStartDate}0{day}/{month}/");
                                    break;
                                case 2:
                                    StartText(rules, note);
                                    Console.Write($"{txtStartDate}{day}/{month}/");
                                    break;
                                default:
                                    StartText(rules, note);
                                    Console.WriteLine("Please enter a correct month");
                                    break;
                            }
                            break;
                    }
                }
                else
                    condition = false;
            } while (condition);
            switch (month.ToString().Length)
            {
                case 1:
                    switch (day.ToString().Length)
                    {
                        case 1:
                            StartText(rules, note);
                            Console.WriteLine($"{txtStartDate}0{day}/0{month}/{year}");
                            break;
                        case 2:
                            StartText(rules, note);
                            Console.WriteLine($"{txtStartDate}{day}/0{month}/{year}");
                            break;
                    }
                    break;
                case 2:
                    switch (day.ToString().Length)
                    {
                        case 1:
                            StartText(rules, note);
                            Console.WriteLine($"{txtStartDate}0{day}/{month}/{year}");
                            break;
                        case 2:
                            StartText(rules, note);
                            Console.WriteLine($"{txtStartDate}{day}/{month}/{year}");
                            break;
                    }
                    break;
            }
            if (day > DateTime.DaysInMonth(year, month))
            {
                Console.Clear();
                Console.WriteLine($"Month number {month} at {year} has less than of {day} days.");
                Console.WriteLine("Press any key for continue! And Enter correct a date.");
                Console.Clear();
                GetDate();
            }
            return new DateTime(year, month, day);
        }

        private static void StartText(string rules, string note)
        {
            Console.Clear();
            Console.WriteLine(rules);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(note);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static bool CheckDay(int day, int min, int max)
        {
            return day >= min && day <= max;
        }

        private static bool CheckMonth(int month, int min, int max)
        {
            return month >= min && month <= max;
        }

        private static bool CheckYear(int year, int min, int max)
        {
            return year >= min && year <= max;
        }


        /// <summary>\
        ///  Array of objects(DateTime) with the fields "start date" and "end date".
        ///  If "start date" is the same with the "end date", it means the weekend happens only on that day.
        ///  If "start date" isn't same with the "end date", it means that the whole period is a weekend.
        /// </summary>
        /// <param name="start">start date</param>
        /// <param name="end">end date</param>
        /// <returns></returns>
        public static List<DateTime> Weekends(DateTime start, DateTime end)
        {
            if (end < start)
                end = start;
            var count = end - start;
            var list = new List<DateTime>();
            for (var i = 0; i <= count.Days; i++)
                list.Add(start.AddDays(i));
            return list;
        }
    }
}

