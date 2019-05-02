using System;
using System.Linq;

namespace EXRC_Date_Modifier
{
    public class Program
    {
        static void Main()
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();

            DateModifier.DateDifference(date1, date2);

        }
    }
}
