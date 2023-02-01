using MathGame.Models;

namespace MathGame
{
    internal class Menu
    {
        GameEngine engine= new();
        Helpers helper = new();
        internal void GameMenu(string? name, DateTime date,int totalQuestion)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($"Hello {name.ToUpper()},Today is {date.DayOfWeek}.So today we are going to play a game");
            var isGameOn = true;
            do
            {
                Console.WriteLine("Select any of the operation of game");
                Console.WriteLine("Below is the list:" +
                    "V:View Previous Games" +
                    "A:Addition," +
                    "S:Subtraction," +
                    "M:Multiplication," +
                    "D:Division,Q:Quit");
                Console.WriteLine("------------------------");

                var gameSelected = Console.ReadLine();
                switch (gameSelected.Trim().ToLower())
                {
                    case "v": Helpers.GetGames(); break;
                    case "a": GameEngine.AdditionGame(GameType.Addition,totalQuestion); break;
                    case "s": GameEngine.SubtractionGame(GameType.Subtraction, totalQuestion); break;
                    case "m": GameEngine.MultiplicationGame(GameType.Multiplication, totalQuestion); break;
                    case "d": GameEngine.DivisionGame(GameType.Division, totalQuestion); break;
                    case "q": isGameOn = false; break;
                    default:
                        Console.WriteLine("Right something worthwhile braahh!!");
                        break;
                }

            } while (isGameOn);
        }

    }
}
