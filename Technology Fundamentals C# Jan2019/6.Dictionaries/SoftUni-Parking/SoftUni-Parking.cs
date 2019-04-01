using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_Parking
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, string> registration = new Dictionary<string, string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var array = Console.ReadLine().Split(' ').ToArray();
                string command = array[0];
                string username = array[1];
                string licensePlate = string.Empty;
                if (array.Length == 3)
                {
                    licensePlate = array[2];
                }

                if (command == "register")
                {
                    if (!registration.ContainsKey(username))
                    {
                        registration[username] = licensePlate;
                        Console.WriteLine($"{username} registered {licensePlate} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
                    }
                }
                else if (command == "unregister")
                {
                    if (!registration.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        registration.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                }
            }

            foreach (var item in registration)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
