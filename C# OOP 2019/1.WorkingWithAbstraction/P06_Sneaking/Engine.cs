namespace P06_Sneaking
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine
    {
        static char[][] room;

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            room = new char[n][];
            InitializeRoom(n);

            var moves = Console.ReadLine().ToCharArray();
            int[] playerCoordinates = new int[2];

            FindInitialPlayerPosition(playerCoordinates);

            for (int i = 0; i < moves.Length; i++)
            {
                for (int row = 0; row < room.Length; row++)
                {
                    MoveEnemies(row);
                }

                int[] enemyCoordinates = new int[2];
                FindEnemyPosition(playerCoordinates, enemyCoordinates);

                int playerRow = playerCoordinates[0];
                int playerCol = playerCoordinates[1];

                KillPlayer(playerCoordinates, enemyCoordinates);

                room[playerCoordinates[0]][playerCoordinates[1]] = '.';

                MovePlayer(moves, playerCoordinates, i);

                room[playerCoordinates[0]][playerCoordinates[1]] = 'S';

                FindEnemyPosition(playerCoordinates, enemyCoordinates);

                TryToKillNikoladze(playerCoordinates, enemyCoordinates);
            }
        }

        private static void TryToKillNikoladze(int[] playerCoordinates, int[] enemyCoordinates)
        {
            if (room[enemyCoordinates[0]][enemyCoordinates[1]] == 'N' && playerCoordinates[0] == enemyCoordinates[0])
            {
                room[enemyCoordinates[0]][enemyCoordinates[1]] = 'X';
                Console.WriteLine("Nikoladze killed!");

                PrintRoom();

                Environment.Exit(0);
            }
        }

        private static void KillPlayer(int[] playerCoordinates, int[] enemyCoordinates)
        {
            if (playerCoordinates[1] < enemyCoordinates[1] && room[enemyCoordinates[0]][enemyCoordinates[1]] == 'd' && enemyCoordinates[0] == playerCoordinates[0])
            {
                room[playerCoordinates[0]][playerCoordinates[1]] = 'X';

                Console.WriteLine($"Sam died at {playerCoordinates[0]}, {playerCoordinates[1]}");

                PrintRoom();

                Environment.Exit(0);
            }
            else if (enemyCoordinates[1] < playerCoordinates[1] && room[enemyCoordinates[0]][enemyCoordinates[1]] == 'b' && enemyCoordinates[0] == playerCoordinates[0])
            {
                room[playerCoordinates[0]][playerCoordinates[1]] = 'X';
                Console.WriteLine($"Sam died at {playerCoordinates[0]}, {playerCoordinates[1]}");

                PrintRoom();

                Environment.Exit(0);
            }
        }

        private static void FindEnemyPosition(int[] playerCoordinates, int[] enemyCoordinates)
        {
            for (int j = 0; j < room[playerCoordinates[0]].Length; j++)
            {
                if (room[playerCoordinates[0]][j] != '.' && room[playerCoordinates[0]][j] != 'S')
                {
                    enemyCoordinates[0] = playerCoordinates[0];
                    enemyCoordinates[1] = j;
                }
            }
        }

        private static void PrintRoom()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }

                Console.WriteLine();
            }
        }

        private static void MovePlayer(char[] moves, int[] playerCoordinates, int i)
        {
            switch (moves[i])
            {
                case 'U':
                    playerCoordinates[0]--;
                    break;
                case 'D':
                    playerCoordinates[0]++;
                    break;
                case 'L':
                    playerCoordinates[1]--;
                    break;
                case 'R':
                    playerCoordinates[1]++;
                    break;
                default:
                    break;
            }
        }

        private static void MoveEnemies(int row)
        {
            for (int col = 0; col < room[row].Length; col++)
            {
                char currentPosition = room[row][col];
                if (currentPosition == 'b')
                {
                    if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                    {
                        room[row][col] = '.';
                        room[row][col + 1] = 'b';
                        col++;
                    }
                    else
                    {
                        room[row][col] = 'd';
                    }
                }
                else if (currentPosition == 'd')
                {
                    if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                    {
                        room[row][col] = '.';
                        room[row][col - 1] = 'd';
                    }
                    else
                    {
                        room[row][col] = 'b';
                    }
                }
            }
        }

        private static void FindInitialPlayerPosition(int[] samPosition)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                    }
                }
            }
        }

        private static void InitializeRoom(int n)
        {
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                room[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];
                }
            }
        }
    }
}
