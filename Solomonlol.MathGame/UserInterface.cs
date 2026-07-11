using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using static STUDY.MathGame.Enums;

namespace STUDY.MathGame
{
    internal class UserInterface
    {   
        internal void MainMenu()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine($"Введите тип опрерации(1-4):\n1:{(char)Operation.Addition}\n2:{(char)Operation.Substraction}\n3:{(char)Operation.Multiplication}\n4:{(char)Operation.Division}");


                if (int.TryParse(Console.ReadLine(), out int choose) && choose >= 1 && choose < 5)
                {
                    var operation = choose switch
                    {
                        1 => Operation.Addition,
                        2 => Operation.Substraction,
                        3 => Operation.Multiplication,
                        4 => Operation.Division
                    };
                    Console.Clear();
                    Console.WriteLine($"Введите уровень сложности(1-3):\n1:{Difficulty.Easy}\n2:{Difficulty.Medium}\n3:{Difficulty.Hard}");

                    if (int.TryParse(Console.ReadLine(), out choose) && choose >= 1 && choose < 4)
                    {
                        var diff = choose switch
                        {
                            1 => Difficulty.Easy,
                            2 => Difficulty.Medium,
                            3 => Difficulty.Hard,
                        };
                        Console.Clear();
                        Console.WriteLine("Введите количество игр:");
                        if (int.TryParse(Console.ReadLine(), out choose))
                        {
                            MathGame game = new MathGame(diff, operation);
                            game.Game(choose);
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат ввода!\nНажмите любую клавишу для прожолжения.");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный формат ввода!\nНажмите любую клавишу для прожолжения.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Неверная операция!\nНажмите любую клавишу для продолжения.");
                    Console.ReadKey();
                }
            }
        }
    }
}
