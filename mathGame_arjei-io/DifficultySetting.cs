using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MathGame
{
    internal class DifficultySetting
    {
        internal static string ChooseDifficulty()
        {
            string difficulty;
            bool diffMenu = true;
            
            do
            {
                Console.Clear();
                Console.WriteLine(@"----------EASY----------
Single digits. Simple and fun!");
                Console.WriteLine();
                Console.WriteLine(@"----------HARD----------
Double digits. To scratch that brain!");
                Console.WriteLine();
                Console.WriteLine(@"Choose a difficulty and press enter to continue:

E: For easy difficulty

H: For hard difficulty");
                difficulty = Console.ReadLine();
                switch (difficulty.Trim().ToLower())
                {
                    case "e":
                        difficulty = "Easy";
                        diffMenu = false;
                        break;
                    case "h":
                        difficulty = "Hard";
                        diffMenu = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Enter a valid difficulty. ('enter' to return to menu)");
                        Console.ReadLine();
                        break;
                }

            }while (diffMenu);

            return difficulty;


        }
    }
}
