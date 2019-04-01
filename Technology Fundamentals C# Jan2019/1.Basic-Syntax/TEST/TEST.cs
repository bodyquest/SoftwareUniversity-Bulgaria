using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            int fact = 1;
            int temp = num;
            while (temp > 0)
            {
                int digit = temp % 10;
                while(true)
                {
                    if (digit <= 1)
                    {
                        break;
                    }
                        fact *= digit;
                        digit--;
                }
                sum += fact;
                temp = temp / 10;
                fact = 1;
            }

            if (num == sum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
            
        }
    }
}
