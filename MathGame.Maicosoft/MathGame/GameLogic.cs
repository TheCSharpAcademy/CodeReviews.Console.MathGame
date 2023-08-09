using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MathGame;

internal class GameLogic
{
    public static string Name { get; set; }
    public static void StartGame()
    {
        Greeting();
        Menu.ShowMenu();
        AddScore();
        Calculation.score = 0;
        PlayAgain();
        Console.WriteLine("Thank you for playing, press any key to exit");
    }

    private static void AddScore()
    {
        Score score = new Score()
        {
            Name = Name,
            FinalScore = Calculation.score,
            Date = DateTime.Now
        };
        Score.Scores.Add(score);
    }

    private static void Greeting()
    {
        Console.WriteLine("What is your name?");
        Name = Console.ReadLine();
        Console.WriteLine($"Hello {Name}, today it's {DateTime.Now}\n");
    }

    static void PlayAgain()
    {
        Console.WriteLine("Do you want to play again? y/n");
        var playAgain = Console.ReadLine();
        if ( playAgain != null )
        {
            if ( playAgain == "y")
            {
                Menu.type = "5";
                StartGame();
            }
            else 
            {
                HighScore();
            }
        }
    }

    public static void HighScore()
    {
        var highScore = Score.Scores.OrderByDescending(x => x.FinalScore);
        foreach (Score score in highScore)
        {
            Console.WriteLine($"Name\tFinal Score\tDate");
            Console.WriteLine($"{score.Name}\t{score.FinalScore}\t\t{score.Date}\n");
        }            
    }
}
