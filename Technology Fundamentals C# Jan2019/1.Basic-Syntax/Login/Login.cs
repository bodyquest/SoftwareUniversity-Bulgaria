using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();
            int count = 0;
            while (count < 4)
            {
                count++;
                string input = Console.ReadLine();
                StringBuilder reversed = new StringBuilder();
                for (int i = input.Length-1; i >= 0; i--)
                {
                    reversed.Append(input[i]);
                    
                }
                if (pass == reversed.ToString())
                {
                    Console.WriteLine($"User {pass} logged in.");
                    break;
                }
                else
                {
                    if (count >= 4)
                    {
                        Console.WriteLine($"User {pass} blocked!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password. Try again.");
                    }
                }
            }
        }
    }
}
