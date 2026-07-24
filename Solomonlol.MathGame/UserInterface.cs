using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using static STUDY.MathGame.Enums;

namespace STUDY.MathGame
{
    internal class UserInterface
    {
        static bool endGame = false;
        internal void MainMenu()
        {
            
            while (!endGame)
            {
                Console.Clear();
                Console.WriteLine($"Enter the operation type(1-3):\n1:{Menu.StartGame}\n2:{Menu.GameHistory}\n3:{Menu.Exit}");

                if (int.TryParse(Console.ReadLine(), out int choose) && choose >= 1 && choose < 4)
                {
                    var operation = choose switch
                    {
                        1 => Menu.StartGame,
                        2 => Menu.GameHistory,
                        3 => Menu.Exit
                    };
                    Console.Clear();
                    switch(operation)
                    {
                        case Menu.StartGame:
                            StartGame();
                            break;
                        case Menu.GameHistory:
                            GameHistory();
                            break;
                        case Menu.Exit:
                            endGame = true;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid operation!\nPress any key to continue.");
                    Console.ReadKey();
                }
            }
        }

        internal void StartGame()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Enter the operation type(0-4):\n1:{(char)Operation.Addition}\n2:{(char)Operation.Substraction}\n3:{(char)Operation.Multiplication}\n4:{(char)Operation.Division}\n0:{Operation.Exit}");


                if (int.TryParse(Console.ReadLine(), out int choose) && choose >= 0 && choose < 5)
                {
                    var operation = choose switch
                    {
                        1 => Operation.Addition,
                        2 => Operation.Substraction,
                        3 => Operation.Multiplication,
                        4 => Operation.Division,
                        0 => Operation.Exit
                    };
                    Console.Clear();
                    if (operation != Operation.Exit)
                    {
                        Console.WriteLine($"Enter the difficulty level(1-3):\n1:{Difficulty.Easy}\n2:{Difficulty.Medium}\n3:{Difficulty.Hard}");

                        if (int.TryParse(Console.ReadLine(), out choose) && choose >= 1 && choose < 4)
                        {
                            var diff = choose switch
                            {
                                1 => Difficulty.Easy,
                                2 => Difficulty.Medium,
                                3 => Difficulty.Hard,
                            };
                            Console.Clear();
                            Console.WriteLine("Enter the number of games:");
                            if (int.TryParse(Console.ReadLine(), out choose) && choose > 0)
                            {
                                MathGame game = new MathGame(diff, operation);
                                game.Game(choose);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input format!\nPress any key to continue.");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input format!\nPress any key to continue.");
                            Console.ReadKey();
                        }
                    }
                    else break;
                }
                else
                {
                    Console.WriteLine("Invalid operation!\nPress any key to continue.");
                    Console.ReadKey();
                }
            }
        }

        internal void GameHistory()
        {
            Console.Clear();
            GameList.Show();
            MainMenu();
        }
    }
}
