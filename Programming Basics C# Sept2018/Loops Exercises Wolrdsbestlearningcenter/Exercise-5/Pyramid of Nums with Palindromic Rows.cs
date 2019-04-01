using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://www.completecsharptutorial.com/basic/loop-constructs-exercises.php

            int n = int.Parse(Console.ReadLine());
            int spaces = 1;
            int num = 1;

            for (int row = 1; row < n; row++)
            {
                for (spaces = 1; spaces <= n - row; spaces++)
                {
                    Console.Write(" ");
                }
                
                for (num = 1; num <= row; num++)
                {
                    Console.Write(num);
                }
                for (int rev = row-1; rev >= 1; rev--)
                {
                    Console.Write(rev);
                }
                Console.WriteLine();
            }
            for (int i = 1; i <= n; i++)
            {
                Console.Write(i);
            }
            for (int rev = n - 1; rev >= 1; rev--)
            {
                Console.Write(rev);
            }
            Console.WriteLine();
            for (int row = 1; row < n; row++)
            {
                for (spaces = 1; spaces <= row; spaces++)
                {
                    Console.Write("{0}", new string (' ', spaces));
                }

                for (num = n-row; num >=1; num--)
                {
                    Console.Write(num);
                }
                for (int rev = row - 1; rev >= 1; rev--)
                {
                    Console.Write(rev);
                }
                Console.WriteLine();
            }
        }
    }
}
