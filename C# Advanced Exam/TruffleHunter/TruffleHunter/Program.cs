using System;
using System.Collections.Generic;
using System.Linq;

namespace TruffleHunter
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            while (fieldSize < 3 || fieldSize > 10)
            {
                fieldSize = int.Parse(Console.ReadLine());
            }
            int bCount = 0;
            int sCount = 0;
            int wCount = 0;
            int boarsTruffleCount = 0;
            char[,] playingField = new char[fieldSize, fieldSize];
            for (int i = 0; i < fieldSize; i++)
            {
                List<string> line = Console.ReadLine().Split().ToList();
                List<char> niggers = new List<char>();
                foreach (var character in line)
                {
                    niggers.Add(character[0]);
                }
                for (int k = 0; k < fieldSize; k++)
                {
                    playingField[i, k] = niggers[k];
                }
                //var line = Console.ReadLine().ToCharArray();

            }
            string command = Console.ReadLine();
            while (command != "Stop the hunt")
            {
                List<string> tokens = command.Split().ToList();
                string toExecute = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                if (toExecute == "Collect")
                {
                    if (row >= 0 && row <= fieldSize - 1 && col >= 0 && col <= fieldSize - 1)
                    {
                        if (playingField[row, col] == 'B')
                        {
                            bCount++;
                            playingField[row, col] = '-';
                        }
                        else if (playingField[row, col] == 'S')
                        {
                            sCount++;
                            playingField[row, col] = '-';
                        }
                        else if ((playingField[row, col] == 'W'))
                        {
                            wCount++;
                            playingField[row, col] = '-';
                        }

                    }

                }
                else if (toExecute == "Wild_Boar")
                {
                    string path = tokens[3];
                    if (path == "up")
                    {
                        while (row >= 0 && row <= fieldSize - 1 && col >= 0 && col <= fieldSize - 1)
                        {
                            if (playingField[row, col] == 'B' || playingField[row, col] == 'S' || playingField[row, col] == 'W')
                            {
                                playingField[row, col] = '-';
                                boarsTruffleCount++;
                            }
                            row += 2;

                        }
                    }
                    else if (path == "down")
                    {
                        while (row >= 0 && row <= fieldSize - 1 && col >= 0 && col <= fieldSize - 1)
                        {
                            if (playingField[row, col] == 'B' || playingField[row, col] == 'S' || playingField[row, col] == 'W')
                            {
                                playingField[row, col] = '-';
                                boarsTruffleCount++;
                            }
                            row -= 2;

                        }
                    }
                    else if (path == "right")
                    {
                        while (row >= 0 && row <= fieldSize - 1 && col >= 0 && col <= fieldSize - 1)
                        {
                            if (playingField[row, col] == 'B' || playingField[row, col] == 'S' || playingField[row, col] == 'W')
                            {
                                playingField[row, col] = '-';
                                boarsTruffleCount++;
                            }
                            col += 2;

                        }
                    }
                    else if (path == "left")
                    {
                        while (row >= 0 && row <= fieldSize - 1 && col >= 0 && col <= fieldSize - 1)
                        {
                            if (playingField[row, col] == 'B' || playingField[row, col] == 'S' || playingField[row, col] == 'W')
                            {
                                playingField[row, col] = '-';
                                boarsTruffleCount++;
                            }
                            col -= 2;

                        }
                    }

                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Peter manages to harvest {bCount} black, {sCount} summer, and {wCount} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarsTruffleCount} truffles.");
            for (int i = 0; i < playingField.GetLength(0); i++)
            {
                for (int k = 0; k < playingField.GetLength(1); k++)
                {
                    if (k == playingField.GetLength(1) - 1)
                    {
                        Console.Write(String.Join(" ", playingField[i, k]));
                    }
                    else
                    {
                        Console.Write(String.Join(" ", playingField[i, k]) + " ");
                    }

                }

                Console.WriteLine();

            }

        }
    }
}
