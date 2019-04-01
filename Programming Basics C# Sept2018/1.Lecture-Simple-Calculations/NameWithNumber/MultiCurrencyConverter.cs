using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    class CurrencyConverter
    {
        static void Main(string[] args)
        {
            decimal amount = decimal.Parse(Console.ReadLine());
            var inputC = Console.ReadLine();
            var outputC = Console.ReadLine();

            //double BGN = 1;
            //double USD = 1.79549 * BGN;
            //double EUR = 1.95583 * BGN;
            //double GBP = 2.53405 * BGN;

            switch (inputC)
            { 
                case "BGN":
                    amount *= 1;
                    break;
                case "USD":
                    amount *= 1.79549m;
                    break;
                case "EUR":
                    amount *= 1.95583m;
                    break;
                case "GBP":
                    amount *= 2.53405m;
                    break;

            }
            switch (outputC)
            {
                case "BGN":
                    amount /= 1;
                    break;
                case "USD":
                    amount /= 1.79549m;
                    break;
                case "EUR":
                    amount /= 1.95583m;
                    break;
                case "GBP":
                    amount /= 2.53405m;
                    break;

            }

            string result = $"{amount:F2} {outputC}";
            Console.WriteLine(result);
        }
    }
}
