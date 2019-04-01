using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketBattle
{
    class BasketBattle
    {
        static void Main()
        {
            string first = Console.ReadLine();
            int rounds = int.Parse(Console.ReadLine());
            bool simeonFirst = false;
            bool nakovFirst = false;
            int winningRound = 0;

            int simPoints = 0;
            int nakPoints = 0;
            string winner = String.Empty;
            
            if (first == "Simeon")                      // If one of them is mentioned, then he is first
            {
                simeonFirst = true;
            }
            else if (first == "Nakov")
            {
                nakovFirst = true;
            }

            for (int i = 1; i <= rounds; i++)
            {
                int firstPoints = int.Parse(Console.ReadLine());        //READ first Shot and check who's turn// At the end of the cycle the two change places 
                string firstShot = Console.ReadLine();

                if (simeonFirst)
                {
                    if (firstShot== "success" && simPoints + firstPoints <=500)
                    {
                        simPoints += firstPoints;
                    }
                    if (simPoints == 500)
                    {
                        winner = "Simeon";
                        winningRound = i;
                        break;
                    }
                    
                    int secondPoints = int.Parse(Console.ReadLine());               // read second shot
                    string secondShot = Console.ReadLine();

                    if (secondShot == "success" && nakPoints + secondPoints <= 500)
                    {
                        nakPoints += secondPoints;
                        if (nakPoints == 500)
                        {
                            winner = "Nakov";
                            winningRound = i;
                            break;
                        }
                    }
                }

                if (nakovFirst)
                {
                    if (firstShot == "success" && nakPoints + firstPoints <= 500)
                    {
                        nakPoints += firstPoints;
                    }
                    if (nakPoints == 500)
                    {
                        winner = "Nakov";
                        winningRound = i;
                        break;
                    }
                    int secondPoints = int.Parse(Console.ReadLine());               // read second shot
                    string secondShot = Console.ReadLine();

                    if (secondShot == "success" && simPoints + secondPoints <= 500)
                    {
                        simPoints += secondPoints;
                        if (simPoints == 500)
                        {
                            winner = "Simeon";
                            winningRound = i;
                            break;
                        }
                    }
                }
                simeonFirst = !simeonFirst;                 //change places on next shot !!!
                nakovFirst = !nakovFirst;
            }



            if (winner == "Simeon")
            {
                Console.WriteLine(winner);
                Console.WriteLine(winningRound);
                Console.WriteLine(nakPoints);
            }
            else if (winner == "Nakov")
            {
                Console.WriteLine(winner);
                Console.WriteLine(winningRound);
                Console.WriteLine(simPoints);
            }
            else if (simPoints == nakPoints)
            {
                Console.WriteLine("DRAW");
                Console.WriteLine(nakPoints);
            }
            else
            {
                if (simPoints > nakPoints)
                {
                    Console.WriteLine("Simeon");
                    Console.WriteLine(simPoints - nakPoints);
                }
                else
                {
                    Console.WriteLine("Nakov");
                    Console.WriteLine(nakPoints - simPoints);
                }
            }
        }
    }
}
