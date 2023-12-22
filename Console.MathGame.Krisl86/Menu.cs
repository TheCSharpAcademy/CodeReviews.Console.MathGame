using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KristianLepka.MathGame;

struct GameSettings
{
    public char oper;
    public int numberOfQuestions;
    public Difficulty difficulty;
}

class Menu
{
    readonly GameStats stats;

    public Menu(GameStats stats)
    {
        this.stats = stats;
    }

    public void IntroMenu()
    {
        Console.WriteLine("Welcome to my math game!");
        Console.WriteLine("========================");
        Console.WriteLine("========================");
    }

    public void MainMenu()
    {
        Console.WriteLine("'start': configure and start a new game");
        Console.WriteLine("'stats': view statistics for played games");
        Console.WriteLine("'exit': exit the app");

        string input = string.Empty;
        while (input != "exit")
        {
            WriteInputPrompt("main_menu");
            input = Console.ReadLine() ?? string.Empty;
            if (input == "start") 
                StartGameMenu();
            else if (input == "stats")
                Stats();
        }
    }

    void StartGameMenu()
    {
        Console.WriteLine("New game - select difficulty (e, m, h):");
        Console.WriteLine("'e': easy");
        Console.WriteLine("'m': medium");
        Console.WriteLine("'h': hard");
        WriteInputPrompt("difficulty");

        Difficulty dif;
        string difInput = Console.ReadLine() ?? string.Empty;
        if (difInput == "e")
            dif = Difficulty.Easy;
        else if (difInput == "m")
            dif = Difficulty.Medium;
        else if (difInput == "h")
            dif = Difficulty.Hard;
        else
        {
            Console.WriteLine("Input error - invalid difficulty");
            return;
        }

        Console.WriteLine("New game - select operator for math problems (+ - * / 'random')");
        WriteInputPrompt("operator");
        char op;
        string opInput = Console.ReadLine() ?? string.Empty;
        if (opInput == "+")
            op = '+';
        else if (opInput == "-")
            op = '-';
        else if (opInput == "*")
            op = '*';
        else if (opInput == "/")
            op = '/';
        else if (opInput == "random")
            op = 'r';
        else
        {
            Console.WriteLine("Input error - invalid operator");
            return;
        }

        Console.WriteLine("New game - select number of questions (1 - 15)");
        WriteInputPrompt("num_of_questions");
        if (!int.TryParse(Console.ReadLine() ?? string.Empty, out int numOfQuestions)
            || numOfQuestions is < 1 or > 15)
           
        {
            Console.WriteLine("Input error - invalid number of questions");
            return;
        }

        var game = new MathGame(dif, numOfQuestions, op, op == 'r', stats);
        game.Start();
    }

    void Stats()
    {
        int gamesPlayed = stats.Stats.Count;
        Console.WriteLine($"You have played {gamesPlayed} games.");
        if (gamesPlayed > 0)
        {
            Console.WriteLine($"You answered {stats.Stats.Sum(x => x.CorrectAnswers)} out of " +
                $"{stats.Stats.Sum(x => x.NumberOfQuestions)} questions correctly!");
            Console.WriteLine($"You played for total of {stats.Stats.Sum(x => x.PlayTime)} seconds.");

            for (int i = 0; i < stats.Stats.Count; i++)
            {
                var game = stats.Stats[i];
                ConsoleHelper.WriteLineInColor($"\nGame {i + 1}", ConsoleColor.Green);

                Console.WriteLine($"  Difficulty: {game.Difficulty}");

                Console.Write("  Operator: ");
                if (game.RandomOperator)
                    Console.WriteLine("random");
                else
                    Console.WriteLine($"  {game.Operator}");

                Console.WriteLine($"  -> you answered {game.CorrectAnswers}/{game.NumberOfQuestions} " +
                    $"questions correctly.");
                Console.WriteLine($"  -> it took you {game.PlayTime} seconds to finish.");
            }
        }
    }

    void WriteInputPrompt(string text)
        => ConsoleHelper.WriteInColor($"> {text} >> ", ConsoleColor.Green);
}
