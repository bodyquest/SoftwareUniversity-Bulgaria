using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;


namespace Debug_The_Code
{
    class Program
    {
        static void Main()
        {
            var startDate = DateTime.ParseExact(Console.ReadLine(), new string[] { "d.M.yyyy", "dd.MM.yyyy",  }, CultureInfo.InvariantCulture, DateTimeStyles.None);
            var endDate = DateTime.ParseExact(Console.ReadLine(),
                new string[] { "d.M.yyyy", "dd.MM.yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None);
            var holidaysCount = 0;
            for (var date = startDate; date <= endDate; date = date.AddDays(1))
                if (date.DayOfWeek == DayOfWeek.Saturday ||
                    date.DayOfWeek == DayOfWeek.Sunday) holidaysCount++;
            Console.WriteLine(holidaysCount);
        }

    }
}
