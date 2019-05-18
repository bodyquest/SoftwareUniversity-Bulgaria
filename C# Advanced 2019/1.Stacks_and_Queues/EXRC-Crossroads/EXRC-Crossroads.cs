using System;
using System.Collections;

namespace Crossroads
{
    class Program
    {
        static void Main()
        {
            int duration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            Queue cars = new Queue();

            int carCount = 0;
            string input = Console.ReadLine();
            while (input != "END")
            {
                string car = string.Empty;
                if (input != "green")
                {
                    car = input;
                    cars.Enqueue(car);
                }
                else
                {
                    int green = duration;
                    int window = freeWindow;
                    while (green > 0 && cars.Count > 0)
                    {
                        car = cars.Peek().ToString();

                        if (green > 0 && green >= car.Length)
                        {
                            green -= car.Length;
                            cars.Dequeue();
                            carCount++;
                        }
                        else if (green > 0 && green < car.Length)
                        {
                            if (green + window >= car.Length)
                            {
                                cars.Dequeue();
                                green = 0;
                                carCount++;
                                break;
                            }
                            else
                            {
                                char damageLocation = car[green + window];

                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{cars.Dequeue()} was hit at {damageLocation}.");
                                return;
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carCount} total cars passed the crossroads.");
        }
    }
}
