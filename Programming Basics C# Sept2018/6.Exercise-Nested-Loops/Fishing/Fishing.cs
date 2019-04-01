using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing
{
    class Fishing
    {
        static void Main(string[] args)
        {
            int quota = int.Parse(Console.ReadLine());
            string fishName = String.Empty;
            decimal fishSize = 0;
            int count = 0;
            decimal money = 0m;


            while (fishName != "Stop")
            {
                fishName = Console.ReadLine();
                if (fishName == "Stop")
                {
                    break;
                }
                fishSize = decimal.Parse(Console.ReadLine());
                decimal sum = 0m;
                // Convert the string into a byte[].
                byte[] asciiBytes = Encoding.ASCII.GetBytes(fishName);

                foreach (var i in asciiBytes)
                {
                    sum += i;
                }
                count++;
                
                if (count % 3 == 0)
                {
                    money += sum / fishSize;
                }
                else
                {
                    money -= sum / fishSize;
                }
                if (count == quota)
                {
                    Console.WriteLine("Lyubo fulfilled the quota!");
                    break;
                }

            }
            if (money >= 0)
            {
                Console.WriteLine($"Lyubo's profit from {count} fishes is {money:f2} leva.");
            }
            else
            {
                Console.WriteLine($"Lyubo lost {Math.Abs(money):f2} leva today.");
            }
        }
    }
}
