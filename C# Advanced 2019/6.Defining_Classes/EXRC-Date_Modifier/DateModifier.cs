namespace EXRC_Date_Modifier
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DateModifier
    {
        public static void DateDifference(string date1, string date2)
        {
            var d1 = date1.Split(' ');
            int year1 = int.Parse(d1[0]);
            int month1 = int.Parse(d1[1].TrimStart('0'));
            int day1 = int.Parse(d1[2].TrimStart('0'));

            var d2 = date2.Split(' ');
            int year2 = int.Parse(d2[0]);
            int month2 = int.Parse(d2[1].TrimStart('0'));
            int day2 = int.Parse(d2[2].TrimStart('0'));

            DateTime firstDate = new DateTime(year1, month1, day1);
            DateTime secondDate = new DateTime(year2, month2, day2);
            Console.WriteLine(Math.Abs(firstDate.Subtract(secondDate).TotalDays)); 

        }
    }
}
