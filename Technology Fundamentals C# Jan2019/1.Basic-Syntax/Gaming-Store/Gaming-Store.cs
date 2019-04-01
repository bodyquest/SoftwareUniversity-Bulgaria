using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            double remaining = balance;

            double OutFall4 = 39.99;
            double CsOG = 15.99;
            double ZplinterZell = 19.99;
            double Honored2 = 59.99;
            double RoverWatch = 29.99;
            double RoverWatchOrigins = 39.99;

            
            string game = Console.ReadLine();
            while (game != "Game Time")
            {
                if (game == "OutFall 4")
                {
                    if (remaining - OutFall4 >= 0)
                    {
                        remaining -= OutFall4;
                        Console.WriteLine($"Bought {game}");
                    }
                    else if (remaining - OutFall4 < 0)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }

                else if (game == "CS: OG")
                {
                    if (remaining - CsOG >= 0)
                    {
                        remaining -= CsOG;
                        Console.WriteLine($"Bought {game}");
                    }
                    else if (remaining - CsOG < 0)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }

                else if (game == "Zplinter Zell")
                {
                    if (remaining - ZplinterZell >= 0)
                    {
                        remaining -= ZplinterZell;
                        Console.WriteLine($"Bought {game}");
                    }
                    else if (remaining - ZplinterZell < 0)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }

                else if (game == "Honored 2")
                {
                    if (remaining - Honored2 >= 0)
                    {
                        remaining -= Honored2;
                        Console.WriteLine($"Bought {game}");
                    }
                    else if (remaining - Honored2 < 0)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }

                else if (game == "RoverWatch")
                {
                    if (remaining - RoverWatch >= 0)
                    {
                        remaining -= RoverWatch;
                        Console.WriteLine($"Bought {game}");
                    }
                    else if (remaining - RoverWatch < 0)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }

                else if (game == "RoverWatch Origins Edition")
                {
                    if (remaining - RoverWatchOrigins >= 0)
                    {
                        remaining -= RoverWatchOrigins;
                        Console.WriteLine($"Bought {game}");
                    }
                    else if (remaining - RoverWatchOrigins < 0)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }

                else
                {
                    Console.WriteLine("Not Found");
                }

                if (remaining == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }

                game = Console.ReadLine();
            }

            Console.WriteLine($"Total spent: ${balance - remaining:f2}. Remaining: ${remaining:f2}");
        }
    }
}
