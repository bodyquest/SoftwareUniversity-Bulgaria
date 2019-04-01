using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCommissions
{
    class TradeCommissions
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine().ToLower();
            decimal sales = decimal.Parse(Console.ReadLine());
            decimal comission = -1;

            if (city == "sofia")
            {
                if (0<= sales && sales <= 500)
                {
                    comission = 0.05m;
                }
                else if (500 <  sales && sales <= 1000)
                {
                    comission = 0.07m;
                }
                else if (1000 < sales && sales <= 10000)
                {
                    comission = 0.08m;
                }
                else if (10000 < sales )
                {
                    comission = 0.12m;
                }
            }
            else if (city == "varna")
            {
                if (0 <= sales && sales <= 500)
                {
                    comission = 0.045m;
                }
                else if (500 < sales && sales <= 1000)
                {
                    comission = 0.075m;
                }
                else if (1000 < sales && sales <= 10000)
                {
                    comission = 0.10m;
                }
                else if (10000 < sales)
                {
                    comission = 0.13m;
                }
            }
            else if (city == "plovdiv")
            {
                if (0 <= sales && sales <= 500)
                {
                    comission = 0.055m;
                }
                else if (500 < sales && sales <= 1000)
                {
                    comission = 0.08m;
                }
                else if (1000 < sales && sales <= 10000)
                {
                    comission = 0.12m;
                }
                else if (10000 < sales)
                {
                    comission = 0.145m;
                }
            }
            if (comission == -1)
            {
                Console.WriteLine("error");
            }
            else
            {
                Console.WriteLine("{0:f2}", comission * sales);
            }




        }
    }
}
