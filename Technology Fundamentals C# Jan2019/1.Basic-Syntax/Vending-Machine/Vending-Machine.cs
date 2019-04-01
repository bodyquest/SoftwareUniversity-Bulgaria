using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double sum = 0.0;

            double nuts = 2.0;
            double water = 0.7;
            double crisps = 1.5;
            double soda = 0.8;
            double coke = 1.0;

            while (input != "Start")
            {
                double.TryParse(input, out double coins);
                if (coins == 0.1 || coins == 0.2 || coins == 0.5 || coins == 1 || coins == 2)
                {
                    sum += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }

                input = Console.ReadLine();
            }

            string product = Console.ReadLine();
            while (product != "End")
            {
                if (product == "Nuts")
                {
                    if (sum - nuts >= 0)
                    {
                        sum -= nuts;
                        Console.WriteLine($"Purchased {(product).ToLower()}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    
                }

                else if (product == "Water")
                {
                    if (sum - water >= 0)
                    {
                        sum -= water;
                        Console.WriteLine($"Purchased {(product).ToLower()}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }

                }

                else if (product == "Crisps")
                {
                    if (sum - crisps >= 0)
                    {
                        sum -= crisps;
                        Console.WriteLine($"Purchased {(product).ToLower()}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }

                }

                else if (product == "Soda")
                {
                    if (sum - soda >= 0)
                    {
                        sum -= soda;
                        Console.WriteLine($"Purchased {(product).ToLower()}");
                    }

                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }

                }

                else if (product == "Coke")
                {
                    if (sum - coke >= 0)
                    {
                        sum -= coke;
                        Console.WriteLine($"Purchased {(product).ToLower()}");
                    }

                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }


                product = Console.ReadLine();
            }

            Console.WriteLine($"Change: {sum:f2}");
        }
    }
}
