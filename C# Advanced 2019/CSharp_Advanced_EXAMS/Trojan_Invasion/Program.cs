namespace Trojan_Invasion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            var plates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> spartanPlates = new Queue<int>(plates);
            Stack<int> trojans = null;

            for (int i = 1; i <= number; i++)
            {
                var trojanPower = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                trojans = new Stack<int>(trojanPower);

                if (i % 3 == 0)
                {
                    var extraPlate = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    spartanPlates.Enqueue(extraPlate[0]);
                }

                int plate = spartanPlates.Peek();
                while (trojans.Count > 0)
                {
                    if (spartanPlates.Count > 0)
                    {
                        if (trojans.Peek() > plate)
                        {
                            int warrior = trojans.Peek();
                            trojans.Pop();
                            warrior -= plate;
                            if (warrior > 0)
                            {
                                trojans.Push(warrior);
                            }

                            if (spartanPlates.Count == 0)
                            {
                                break;
                            }
                            else
                            {
                                spartanPlates.Dequeue();
                            }
                        }
                        else if (trojans.Peek() < plate)
                        {
                            plate -= trojans.Peek();
                            trojans.Pop();
                        }
                        else if (trojans.Peek() == plate)
                        {
                            trojans.Pop();
                            if (spartanPlates.Count == 0)
                            {
                                break;
                            }
                            else
                            {
                                spartanPlates.Dequeue();
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (spartanPlates.Count == 0)
                {
                    break;
                }
            }

            if (spartanPlates.Count == 0)
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
            }
            else
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
            }

            if (trojans.Count > 0)
            {
                Console.Write("Warriors left: ");
                Console.WriteLine(string.Join(", ", trojans));
            }
            if (spartanPlates.Count > 0)
            {
                Console.Write("Plates left: ");
                Console.WriteLine(string.Join(", ", spartanPlates));
            }
        }
    }
}
