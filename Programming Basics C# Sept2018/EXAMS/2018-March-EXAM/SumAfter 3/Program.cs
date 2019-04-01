using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumAfter_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sum1 = 0;
            var sum2 = 0;
            var sum3 = 0;

            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                if (i % 3 == 0)
                {
                    sum1 += num;
                }
                if (i % 3 == 1)
                {
                    sum2 += num;
                }
                if (i % 3 == 2)
                {
                    sum3 += num;
                }
            }
            Console.WriteLine("Sum1 = {0}", sum1);
            Console.WriteLine("Sum2 = {0}", sum2);
            Console.WriteLine("Sum3 = {0}", sum3);
        }
    }

    //for (int i = 0; i<n; i++)
    //    {
    //        int num = int.Parse(Console.ReadLine());

    //        switch (i % 3)
    //        {
    //            case 0: sum1 += num; break;
    //            case 1: sum2 += num; break;
    //            case 2: sum3 += num; break;
    //        }
    //    }

    //    Console.WriteLine($"sum1 = {sum1}");
    //    Console.WriteLine($"sum2 = {sum2}");
    //    Console.WriteLine($"sum3 = {sum3}");

    // ...........................................................

    //int n = int.Parse(Console.ReadLine());
    //var sum1 = 0;
    //var sum2 = 0;
    //var sum3 = 0;
    //var count1 = 1;
    //var count2 = 2;
    //var count3 = 3;
    //    for (var i = 1; i <= n; i++)
    //    {
    //        int num = int.Parse(Console.ReadLine());
 
    //        if (i == count1)
    //        {
    //            sum1 += num;
    //            count1 += 3;
    //        }
    //        else if (i == count2)
    //        {
    //            sum2 += num;
    //            count2 += 3;
    //        }
    //        else if (i == count3)
    //        {
    //            sum3 += num;
    //            count3 += 3;
    //        }
           
    //    }
    //    Console.WriteLine("sum1 = {0}", sum1);
    //    Console.WriteLine("sum2 = {0}", sum2);
    //    Console.WriteLine("sum3 = {0}", sum3);
   

}
