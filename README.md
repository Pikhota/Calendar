# Calendar
#Task
To the function input you receive a:
1.Start date, 
2. duration in days (whole number) and 
3. weekends (array of objects with the fields "start date" and "end date")
If "start date" is the same with the "end date", it means the weekend happens only on that day. If "start date" isn't same with the "end date", it means that the whole period is a weekend.
Example. 23/04/2017 - 25/04/2017, two weekends (Saturday and Sunday) and 25th is a holiday, 3 weekends in total. 
The array is sorted by the start date, periods do not intersect. At the end the function should return the date, which is counted as a start date + duration, without weekends. Start date is the first day of the period.
Example. Start date: 21/04/2017 Duration: 5 days Weekends: 23/04/2017 - 25/04/2017 At the exit there should be: End date 28/04/2017
Explanation 1st day = 21.04.2017 2nd day = 22.04.2017 23.04.2017 excluded as weekend 24.04.2017 excluded as weekend 25.04.2017 excluded as weekend 3rd day = 26.04.2017 4th day = 27.04.2017 5th day = 28.04.2017
