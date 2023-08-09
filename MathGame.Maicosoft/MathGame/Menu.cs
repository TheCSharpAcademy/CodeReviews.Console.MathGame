using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal class Menu
    {
        internal static string type = "5";
        internal static void ShowMenu()
        {    

            while (type == "5")
            {
                Console.WriteLine("Type the number of the game you want to play:\n" +
                    "1. Addition\n" +
                    "2. Subtraction\n" +
                    "3. Multiply\n" +
                    "4. Divide\n" +
                    "5. High Score\n");
                type = Console.ReadLine()?.Trim();
            
                switch (type)
                {
                    case "1":
                        Console.Clear();
                        Calculation.Addition();
                        break;
                    case "2":
                        Console.Clear();
                        Calculation.Subtraction();
                        break;
                    case "3":
                        Console.Clear();
                        Calculation.Multiply();
                        break;
                    case "4":
                        Console.Clear();
                        Calculation.Divide();
                        break;
                    case "5":
                        Console.Clear();
                        if (Score.Scores.Count == 0)
                        {
                            Console.WriteLine("No games have been played yet\n");
                            Menu.ShowMenu();
                        }
                        else
                        {
                            Console.Clear();
                            GameLogic.HighScore();
                        }
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("No valid choice, try again");
                        ShowMenu();
                        break;
                }
            }
        }
    }
}
