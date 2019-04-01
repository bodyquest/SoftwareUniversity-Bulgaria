using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Currency_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> curencies = new Dictionary<string, decimal>();
            curencies.Add("BGN", 1m);
            curencies.Add("USD", 1.79549m);
            curencies.Add("EUR", 1.95583m);
            curencies.Add("GBP", 2.53405m);

            decimal amount = decimal.Parse(Console.ReadLine());
            string inputCurrency = Console.ReadLine();
            string outputCurrency = Console.ReadLine();

            amount *= curencies[inputCurrency];
            amount /= curencies[outputCurrency];

            string result = $"{amount:F2} {outputCurrency}";
            Console.WriteLine(result);

        }
    }
}
