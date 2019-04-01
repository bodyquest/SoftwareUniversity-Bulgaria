using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Margarita
{
    class Margarita
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            // Row 1
            Console.Write("'&$");
            for (int i = 1; i <= 8*n -1; i++)
            {
                Console.Write("'");
            }
            Console.WriteLine();
            ///////////////////////////////////////////////

            //ROW n-1
            for (int i = 1; i <= n-1; i++)
            {
                Console.Write("'");
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("'");
                }
                Console.Write("\\");
                for (int k = 8*n - i; k >= 1; k--)
                {
                    Console.Write("'");
                }
                Console.WriteLine();
            }
            //////////////////////////////////////////////

            //ROW single
            for (int i = 1; i <= 4* n; i++)
            {
                Console.Write("^*");
            }
            Console.WriteLine("^'");
            /////////////////////////////////////////////

            //Console.Write("\\\\");
            //for (int i = 0; i < n-1; i++)
            //{
            //    Console.Write(" ");
            //}
            //Console.Write("\\");
            //for (int k = 1; k <= 6*n+1; k++)
            //{
            //    Console.Write(" ");
            //}
            //Console.Write("//'");
            //Console.WriteLine();
            int before = 0;
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine("{0}\\\\{1}\\{2}//{3}", new string('\'', before), new string(' ', n), new string(' ', (8*n+2) - n - i * 2 - 6), new string('\'', before + 1));
                before++;
            }
            before++;

            ///////ROW BODY

            for (int i = 1; i <= 4*n -2; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("'");
                }
                Console.Write("\\");
                if (i <= n-2)
                {
                    Console.Write("\\");
                    for (int o = 1; o <= n; o++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write("\\");
                    for (int m = 1; m <= (8 * n - n +2) - 2*i-6; m++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write("//");
                    Console.Write("'");
                    for (int l = 1; l <= i; l++)
                    {
                        Console.Write("'");
                    }
                }
                if (i == n-1)
                {
                    for (int j = 1; j <= (5*n + 2) + i; j++)
                    {
                        Console.Write("~");
                    }
                    Console.Write("/");
                    Console.Write("'");
                    for (int l = 1; l <= i; l++)
                    {
                        Console.Write("'");
                    }
                }

                if (i>= n)
                {
                    for (int m = 1; m <= (8 * n-1)- 2* i; m++)
                    {
                        if (i == 2 * n - 2)
                        {
                            for (int x = 1; x < 4*n + 2; x++)
                            {
                                Console.Write("_");
                                break;
                            }
                        }
                        else if (i == 2 * n - 1)
                        {
                            for (int y = 1; y < 4 * n; y++)
                            {
                                Console.Write(".");
                                break;
                            }
                        }
                        else if (i == 4* n -2)
                        {
                            Console.Write("___");
                            break;
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                   
                    Console.Write("/");
                    Console.Write("'");
                    for (int l = 1; l <= i; l++)
                    {
                        Console.Write("'");
                    }
                }

                Console.WriteLine();
            }
            ////////////////////////////////////////////
            //// STEM

            for (int i = 1; i <= 2*n +1; i++)
            {
                for (int j = 1; j <= 4*n -1; j++)
                {
                    Console.Write("'");
                }
                Console.Write("|||");
                for (int j = 1; j <= 4 * n - 1; j++)
                {
                    Console.Write("'");
                }
                Console.Write("'");
                Console.WriteLine();
            }

            ///////////////////////////////////////////
            /////BOTTOM

            for (int i = 1; i < 8*n +2; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine("'");
            Console.Write("'");
            for (int i = 1; i < 8 * n; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("''");
        }
    }
}
