namespace Problem3
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char[,] galaxy = new char[size, size];

            int[] stevenCoordinates = new int[2];
            int[] blackHoles = new int[4] { -1, -1, -1, -1};

            int energy = 0;

            for (int row = 0; row < galaxy.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                var rowArray = input.ToCharArray();
                for (int col = 0; col < galaxy.GetLength(1); col++)
                {
                    galaxy[row, col] = rowArray[col];
                    if (galaxy[row, col] == 'S')
                    {
                        stevenCoordinates[0] = row;
                        stevenCoordinates[1] = col;
                    }
                    if (galaxy[row, col] == 'O' && blackHoles[0] != -1)
                    {
                        blackHoles[2] = row;
                        blackHoles[3] = col;
                    }
                    else if(galaxy[row, col] == 'O' && blackHoles[0] == -1)
                    {
                        blackHoles[0] = row;
                        blackHoles[1] = col;
                    }
                }
            }

            string move = Console.ReadLine().ToLower();
            bool gone = false;

            // to do : CHECK IF LOST !!!
            while (energy < 50)
            {
                int row = stevenCoordinates[0];
                int col = stevenCoordinates[1];
                if (gone == true)
                {
                    break;
                }

                if (move == "up")
                {
                    if (stevenCoordinates[0] - 1 >= 0)
                    {
                        if (row - 1 >= 0)
                        {
                            // IF STAR
                            if (char.IsDigit(galaxy[row - 1, col]))
                            {
                                int digit = galaxy[row - 1, col] - '0';
                                stevenCoordinates[0] = row - 1;
                                stevenCoordinates[1] = col;
                                galaxy[row - 1, col] = 'S';

                                RemoveOriginalStevenPosition(galaxy);

                                energy += digit;
                                if (energy >= 50)
                                {
                                    break;
                                }
                            }

                            //IF BLACK HOLE
                            else if (galaxy[row - 1, col] == 'O')
                            {
                                if (row - 1 == blackHoles[0] && col == blackHoles[1])
                                {
                                    stevenCoordinates[0] = blackHoles[2];
                                    stevenCoordinates[1] = blackHoles[3];

                                    galaxy[row - 1, col] = '-';
                                    galaxy[blackHoles[2], blackHoles[3]] = 'S';

                                    RemoveOriginalStevenPosition(galaxy);
                                }
                                else if (row - 1 == blackHoles[2] && col == blackHoles[3])
                                {
                                    stevenCoordinates[0] = blackHoles[0];
                                    stevenCoordinates[1] = blackHoles[1];

                                    galaxy[row - 1, col] = '-';
                                    galaxy[blackHoles[0], blackHoles[1]] = 'S';

                                    RemoveOriginalStevenPosition(galaxy);
                                }
                            }

                            else
                            {
                                galaxy[row - 1, col] = 'S';
                                RemoveOriginalStevenPosition(galaxy);
                                stevenCoordinates[0] = row - 1;
                                stevenCoordinates[1] = col;
                            }
                        }

                        //IF into VOID
                        else if (row -1 < 0)
                        {
                            galaxy[row, col] = '-';
                            gone = true;
                            break;
                        }
                    }
                }
                else if (move == "down")
                {
                    if (stevenCoordinates[0] + 1 < size)
                    {
                        if(row + 1 < size)
                        {
                            // IF STAR
                            if (char.IsDigit(galaxy[row + 1, col]))
                            {
                                int digit = galaxy[row + 1, col] - '0';
                                stevenCoordinates[0] = row + 1;
                                stevenCoordinates[1] = col;

                                RemoveOriginalStevenPosition(galaxy);
                                galaxy[row + 1, col] = 'S';

                                energy += digit;
                                if (energy >= 50)
                                {
                                    break;
                                }
                            }

                            //IF BLACK HOLE
                            else if (galaxy[row + 1, col] == 'O')
                            {
                                if (row + 1 == blackHoles[0] && col == blackHoles[1])
                                {
                                    stevenCoordinates[0] = blackHoles[2];
                                    stevenCoordinates[1] = blackHoles[3];

                                    galaxy[row + 1, col] = '-';
                                    galaxy[blackHoles[2], blackHoles[3]] = 'S';

                                    RemoveOriginalStevenPosition(galaxy);
                                }
                                else if (row + 1 == blackHoles[2] && col == blackHoles[3])
                                {
                                    stevenCoordinates[0] = blackHoles[0];
                                    stevenCoordinates[1] = blackHoles[1];

                                    galaxy[row + 1, col] = '-';
                                    galaxy[blackHoles[0], blackHoles[1]] = 'S';

                                    RemoveOriginalStevenPosition(galaxy);
                                }
                            }

                            else
                            {
                                galaxy[row + 1, col] = 'S';
                                RemoveOriginalStevenPosition(galaxy);
                                stevenCoordinates[0] = row + 1;
                                stevenCoordinates[1] = col;
                            }
                        }

                        //IF into VOID
                        else if (row + 1 >= size)
                        {
                            galaxy[row, col] = '-';
                            gone = true;
                            break;
                        }
                    }
                }
                else if (move == "left")
                {
                    if (stevenCoordinates[1] - 1 >= 0)
                    {
                        if (col-1 >= 0)
                        {
                            // IF STAR
                            if (char.IsDigit(galaxy[row, col - 1]))
                            {
                                int digit = galaxy[row, col - 1] - '0';
                                stevenCoordinates[0] = row;
                                stevenCoordinates[1] = col - 1;

                                RemoveOriginalStevenPosition(galaxy);
                                galaxy[row, col - 1] = 'S';

                                energy += digit;
                                if (energy >= 50)
                                {
                                    break;
                                }
                            }

                            //IF BLACK HOLE
                            else if (galaxy[row, col - 1] == 'O')
                            {
                                if (row == blackHoles[0] && col - 1 == blackHoles[1])
                                {
                                    stevenCoordinates[0] = blackHoles[2];
                                    stevenCoordinates[1] = blackHoles[3];

                                    galaxy[row, col - 1] = '-';
                                    galaxy[blackHoles[2], blackHoles[3]] = 'S';

                                    RemoveOriginalStevenPosition(galaxy);
                                }
                                else if (row == blackHoles[2] && col - 1 == blackHoles[3])
                                {
                                    stevenCoordinates[0] = blackHoles[0];
                                    stevenCoordinates[1] = blackHoles[1];

                                    galaxy[row, col - 1] = '-';
                                    galaxy[blackHoles[0], blackHoles[1]] = 'S';

                                    RemoveOriginalStevenPosition(galaxy);
                                }
                            }

                            else
                            {
                                galaxy[row, col - 1] = 'S';
                                RemoveOriginalStevenPosition(galaxy);
                                stevenCoordinates[0] = row;
                                stevenCoordinates[1] = col - 1;
                            }
                        }

                        //IF into VOID
                        else if (col- 1 < 0)
                        {
                            galaxy[row, col] = '-';
                            gone = true;
                            break;
                        }
                    }
                }
                else if (move == "right")
                {
                    if (stevenCoordinates[1] + 1 <= size)
                    {
                        if (col+1 < size)
                        {
                            // IF STAR
                            if (char.IsDigit(galaxy[row, col + 1]))
                            {
                                int digit = galaxy[row, col + 1] - '0';
                                stevenCoordinates[0] = row;
                                stevenCoordinates[1] = col + 1;

                                RemoveOriginalStevenPosition(galaxy);
                                galaxy[row, col + 1] = 'S';

                                energy += digit;
                                if (energy >= 50)
                                {
                                    break;
                                }
                            }

                            //IF BLACK HOLE
                            else if (galaxy[row, col + 1] == 'O')
                            {
                                if (row == blackHoles[0] && col + 1 == blackHoles[1])
                                {
                                    stevenCoordinates[0] = blackHoles[2];
                                    stevenCoordinates[1] = blackHoles[3];

                                    galaxy[row, col + 1] = '-';
                                    galaxy[blackHoles[2], blackHoles[3]] = 'S';

                                    RemoveOriginalStevenPosition(galaxy);
                                }
                                else if (row == blackHoles[2] && col + 1 == blackHoles[3])
                                {
                                    stevenCoordinates[0] = blackHoles[0];
                                    stevenCoordinates[1] = blackHoles[1];

                                    galaxy[row, col + 1] = '-';
                                    galaxy[blackHoles[0], blackHoles[1]] = 'S';

                                    RemoveOriginalStevenPosition(galaxy);
                                }
                            }

                            else
                            {
                                galaxy[row, col + 1] = 'S';
                                RemoveOriginalStevenPosition(galaxy);
                                stevenCoordinates[0] = row;
                                stevenCoordinates[1] = col + 1;
                            }
                        }

                        //IF into VOID
                        else if (col + 1 >= size)
                        {
                            galaxy[row, col] = '-';
                            gone = true;
                            break;
                        }
                    }
                }

                move = Console.ReadLine().ToLower();
            }

            // TO PRINT
            if (gone)
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
                Console.WriteLine($"Star power collected: {energy}");
                PrintArray(galaxy);
            }
            else
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                Console.WriteLine($"Star power collected: {energy}");
                PrintArray(galaxy);
            }
        }

        private static void RemoveOriginalStevenPosition(char[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == 'S')
                    {
                        array[i, j] = '-';
                    }
                }
            }
        }

        private static void PrintArray(char[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
