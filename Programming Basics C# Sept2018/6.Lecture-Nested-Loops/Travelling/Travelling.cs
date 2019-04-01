using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelling
{
    class Travelling
    {
        static void Main(string[] args)
        {
            string destination = String.Empty;
            int sum = 0;
            StringBuilder goingTo = new StringBuilder();
            while (destination != "End")
            {
                destination = (Console.ReadLine());
                int budget = int.Parse(Console.ReadLine());
                int money = 0;
                while (sum < budget)
                {
                    money = int.Parse(Console.ReadLine());
                    sum += money;
                }
                goingTo.AppendLine($"Going to {destination}!");
                sum = 0;
            }
            Console.WriteLine(destination);
        }
    }
}
