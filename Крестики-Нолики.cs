using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] board = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            void DrawBoard()
            {
                Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
                Console.WriteLine("----------");
                Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
                Console.WriteLine("----------");
                Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}\n\n");
            }

            bool WinOrNo()
            {
                return (board[0] == board[1] && board[1] == board[2]) ||
                       (board[3] == board[4] && board[4] == board[5]) ||
                       (board[6] == board[7] && board[7] == board[8]) ||
                       (board[0] == board[3] && board[3] == board[6]) ||
                       (board[1] == board[4] && board[4] == board[7]) ||
                       (board[2] == board[5] && board[5] == board[8]) ||
                       (board[0] == board[4] && board[4] == board[8]) ||
                       (board[2] == board[4] && board[4] == board[6]);
            }


            void play()
            {
                string player = "x";
                byte total = 0;
                bool er = false;
                while (true)
                {
                    Console.Clear();
                    DrawBoard();
                    if (er)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный ввод");
                        Console.ResetColor();
                        er = false;
                    }

                    if (total == 9)
                    {
                        Console.WriteLine("Ничья");
                        break;
                    }

                    if (WinOrNo())
                    {
                        if (player == "x")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Игрок 'о' выйграл!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Игрок 'x' выйграл!");
                            Console.ResetColor();
                        }

                        break;
                    }

                    else
                    {
                        Console.WriteLine($"Ход игрока {player}");
                        string xod = Console.ReadLine();
                        bool found = false;
                        foreach (string cell in board)
                        {
                            if (cell == xod)
                            {

                                found = true;
                                break;
                            }
                        }

                        if (found)
                        {

                            if (player == "x")
                            {
                                board[Convert.ToByte(xod) - 1] = "x";
                                player = "o";
                            }
                            else
                            {
                                board[Convert.ToByte(xod) - 1] = "o";
                                player = "x";
                            }

                            total++;
                        }

                        else
                        {
                            er = true;
                        }
                    }
                }
                Console.WriteLine("Сыграем еще? Enter - да, любая клавиша для выхода");
                string again = Console.ReadLine().ToLower();
                if (again == "")
                {
                    for (byte i = 1; i < 10; i++)
                    {
                        board[i - 1] = Convert.ToString(i);
                    }
                    play();

                }
                else
                {
                    Console.WriteLine("Пока");
                }
            }

            play();
        }
        }
    }
}
