namespace Helens_Abduction
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int energy = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            char[,] array = new char[size, size];

            int[] parisCoordinates = new int[2];
            int[] helensCoordinates = new int[2];
            bool isAlive = true;
            FillMatrix(size, array, parisCoordinates, helensCoordinates);

            var moveCommand = Console.ReadLine().Split(' ').ToArray();
            while (energy > 0)
            {
                string direction = moveCommand[0].ToLower();
                int row = int.Parse(moveCommand[1]);
                int col = int.Parse(moveCommand[2]);
                if (row < 0 || col < 0 || row >= array.GetLength(0) || col >= array.GetLength(1))
                {
                    continue;
                }
                else
                {
                    if (direction == "up")
                    {
                        energy -= 1;
                        if (parisCoordinates[0] - 1 != row)
                        {
                            if (parisCoordinates[0] - 1 >= 0)
                            {
                                parisCoordinates[0] -= 1;
                                array[row, col] = 'S';
                                if (parisCoordinates[0] == helensCoordinates[0] && parisCoordinates[1] == helensCoordinates[1])
                                {
                                    array[parisCoordinates[0], parisCoordinates[1]] = '-';
                                    break;
                                }

                                if (energy <= 0)
                                {
                                    array[parisCoordinates[0], parisCoordinates[1]] = 'X';
                                    isAlive = false;
                                    break;
                                }
                            }
                        }
                        else if (parisCoordinates[0] - 1 == row)
                        {
                            if (parisCoordinates[0] - 1 >= 0 && parisCoordinates[1] != col)
                            {
                                parisCoordinates[0] -= 1;
                                array[row, col] = 'S';
                                if (parisCoordinates[0] == helensCoordinates[0] && parisCoordinates[1] == helensCoordinates[1])
                                {
                                    array[parisCoordinates[0], parisCoordinates[1]] = '-';
                                    break;
                                }
                                if (energy <= 0)
                                {
                                    array[parisCoordinates[0], parisCoordinates[1]] = 'X';
                                    isAlive = false;
                                    break;
                                }
                            }
                            else if (parisCoordinates[0] - 1 >= 0 && parisCoordinates[1] == col)
                            {
                                energy -= 2;
                                parisCoordinates[0] -= 1;
                                if (energy <= 0)
                                {
                                    array[parisCoordinates[0], parisCoordinates[1]] = 'X';
                                    isAlive = false;
                                    break;
                                }
                            }
                        }
                    }
                    else if (direction == "down")
                    {
                        energy -= 1;
                        if (parisCoordinates[0] + 1 != row)
                        {
                            if (parisCoordinates[0] + 1 < array.GetLength(0))
                            {
                                energy -= 1;
                                parisCoordinates[0] += 1;
                                array[row, col] = 'S';
                                if (parisCoordinates[0] == helensCoordinates[0] && parisCoordinates[1] == helensCoordinates[1])
                                {
                                    array[parisCoordinates[0], parisCoordinates[1]] = '-';
                                    break;
                                }
                                if (energy <= 0)
                                {
                                    array[parisCoordinates[0], parisCoordinates[1]] = 'X';
                                    isAlive = false;
                                    break;
                                }
                            }
                        }
                        else if (parisCoordinates[0] + 1 == row)
                        {
                            if (parisCoordinates[0] + 1 < array.GetLength(0) && parisCoordinates[1] != col)
                            {
                                energy -= 1;
                                parisCoordinates[0] += 1;
                                array[row, col] = 'S';
                                if (parisCoordinates[0] == helensCoordinates[0] && parisCoordinates[1] == helensCoordinates[1])
                                {
                                    array[parisCoordinates[0], parisCoordinates[1]] = '-';
                                    break;
                                }
                                if (energy <= 0)
                                {
                                    array[parisCoordinates[0], parisCoordinates[1]] = 'X';
                                    isAlive = false;
                                    break;
                                }
                            }
                            else if (parisCoordinates[0] + 1 < array.GetLength(0) && parisCoordinates[1] == col)
                            {
                                energy -= 2;
                                parisCoordinates[0] += 1;
                                if (energy <= 0)
                                {
                                    array[parisCoordinates[0], parisCoordinates[1]] = 'X';
                                    break;
                                }
                            }
                        }
                    }
                    else if (direction == "left")
                    {
                        energy -= 1;
                        if (parisCoordinates[1] - 1 != col)
                        {
                            if (parisCoordinates[1] - 1 >= 0)
                            {
                                parisCoordinates[1] -= 1;
                                array[row, col] = 'S';
                                if (parisCoordinates[0] == helensCoordinates[0] && parisCoordinates[1] == helensCoordinates[1])
                                {
                                    array[parisCoordinates[0], parisCoordinates[1]] = '-';
                                    break;
                                }

                                if (energy <= 0)
                                {
                                    array[parisCoordinates[0], parisCoordinates[1]] = 'X';
                                    isAlive = false;
                                    break;
                                }
                            }
                        }
                        else if (parisCoordinates[1] - 1 == col)
                        {
                            if (parisCoordinates[1] - 1 >= 0 && parisCoordinates[0] != row)
                            {
                                parisCoordinates[1] -= 1;
                                array[row, col] = 'S';
                                if (parisCoordinates[0] == helensCoordinates[0] && parisCoordinates[1] == helensCoordinates[1])
                                {
                                    array[parisCoordinates[0], parisCoordinates[1]] = '-';
                                    break;
                                }
                                if (energy <= 0)
                                {
                                    array[parisCoordinates[0], parisCoordinates[1]] = 'X';
                                    isAlive = false;
                                    break;
                                }
                            }
                            else if (parisCoordinates[1] - 1 >= 0 && parisCoordinates[0] == row)
                            {
                                energy -= 2;
                                parisCoordinates[1] -= 1;
                                if (energy <= 0)
                                {
                                    array[parisCoordinates[0], parisCoordinates[1]] = 'X';
                                    isAlive = false;
                                    break;
                                }
                            }
                        }
                    }
                    else if (direction == "right")
                    {
                        energy -= 1;
                        if (parisCoordinates[1] + 1 != col)
                        {
                            if (parisCoordinates[1] + 1 < array.GetLength(0))
                            {
                                parisCoordinates[1] += 1;
                                array[row, col] = 'S';

                                if (parisCoordinates[0] == helensCoordinates[0] && parisCoordinates[1] == helensCoordinates[1])
                                {
                                    array[parisCoordinates[0], parisCoordinates[1]] = '-';
                                    break;
                                }

                                if (energy <= 0)
                                {
                                    array[parisCoordinates[0], parisCoordinates[1]] = 'X';
                                    isAlive = false;
                                    break;
                                }
                            }
                        }
                        else if (parisCoordinates[1] + 1 == col)
                        {
                            if (parisCoordinates[1] + 1 < array.GetLength(1) && parisCoordinates[0] != row)
                            {
                                parisCoordinates[1] += 1;
                                array[row, col] = 'S';

                                if (parisCoordinates[0] == helensCoordinates[0] && parisCoordinates[1] == helensCoordinates[1])
                                {
                                    array[parisCoordinates[0], parisCoordinates[1]] = '-';
                                    break;
                                }
                                if (energy <= 0)
                                {
                                    array[parisCoordinates[0], parisCoordinates[1]] = 'X';
                                    isAlive = false;
                                    break;
                                }
                            }
                            else if (parisCoordinates[1] + 1 < array.GetLength(1) && parisCoordinates[0] == row)
                            {
                                energy -= 2;
                                parisCoordinates[1] += 1;
                                if (energy <= 0)
                                {
                                    array[parisCoordinates[0], parisCoordinates[1]] = 'X';
                                    isAlive = false;
                                    break;
                                }
                            }
                        }
                    }

                    moveCommand = Console.ReadLine().Split(' ').ToArray();
                }
            }

            //TO PRINT
            if (!isAlive)
            {
                Console.WriteLine($"Paris died at {parisCoordinates[0]};{parisCoordinates[1]}.");
                PrintArray(array);
            }
            else
            {
                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
                PrintArray(array);
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

        private static void FillMatrix(int size, char[,] array, int[] parisCoordinates, int[] helensCoordinates)
        {
            for (int i = 0; i < size; i++)
            {
                string input = Console.ReadLine();
                var inputRow = input.ToCharArray();
                for (int j = 0; j < size; j++)
                {
                    array[i, j] = inputRow[j];
                    if (inputRow[j] == 'P')
                    {
                        parisCoordinates[0] = i;
                        parisCoordinates[1] = j;
                    }
                    if (inputRow[j] == 'H')
                    {
                        helensCoordinates[0] = i;
                        helensCoordinates[1] = j;
                    }
                }
            }
        }
    }
}
