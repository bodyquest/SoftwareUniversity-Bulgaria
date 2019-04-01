using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamItem
{
    class DreamItem
    {
        static void Main(string[] args)
        {
            string data = Console.ReadLine();
            string[] split = data.Split('\\');
            string month = split[0];
            string moneyPerH = split[1];

            decimal mPh = 0;
            mPh = decimal.Parse(moneyPerH);
            mPh = Convert.ToDecimal(moneyPerH);

            string hoursPerD = split[2];
            decimal hPd = 0;
            hPd = decimal.Parse(hoursPerD);
            hPd = Convert.ToDecimal(hoursPerD);

            string price = split[3];
            decimal priceDream = 0;
            priceDream = decimal.Parse(price);
            priceDream = Convert.ToDecimal(price);

            decimal sum = 0;
            //double result = Math.Round(Math.Abs(sum - priceDream));

            if (month == "Jan" || month == "March" || month == "May" || month == "July" || month == "Aug" || month == "Oct" || month == "Dec")
            {
                sum = 21 * mPh * hPd;
                if (sum > 700)
                {
                    sum *= 1.1m;
                }
                if (sum >= priceDream)
                {
                    Console.WriteLine($"Money left = {sum - priceDream:f2} leva.");
                }
                else
                {
                    Console.WriteLine($"Not enough money. {priceDream - sum:f2} leva needed.");
                }
            }
            else if (month == "Apr" || month == "June" || month == "Sept" || month == "Nov")
            {
                sum = 20 * mPh * hPd;
                if (sum > 700)
                {
                    sum *= 1.1m;
                }
                if (sum >= priceDream)
                {
                    Console.WriteLine($"Money left = {sum - priceDream, 2:f2} leva.");
                }
                else
                {
                    Console.WriteLine($"Not enough money. {priceDream - sum:f2} leva needed.");
                }
            }
            else if (month == "Feb")
            {
                sum = 18 * mPh * hPd;
                if (sum > 700)
                {
                    sum *= 1.1m;
                }
                if (sum >= priceDream)
                {
                    Console.WriteLine($"Money left = {sum - priceDream:f2} leva.");
                }
                else
                {
                    Console.WriteLine($"Not enough money. {priceDream - sum:f2} leva needed.");
                }
            }

        }
    }
}
