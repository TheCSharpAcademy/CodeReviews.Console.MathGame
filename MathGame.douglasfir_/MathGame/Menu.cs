using MathGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame; 

internal static class Menu
{
    internal static void PrintHeader()
    {
        Console.WriteLine("=====================================================================================================");
        Console.WriteLine(@"
        ███╗   ███╗ █████╗ ████████╗██╗  ██╗     ██████╗ ██╗   ██╗███████╗███████╗████████╗
        ████╗ ████║██╔══██╗╚══██╔══╝██║  ██║    ██╔═══██╗██║   ██║██╔════╝██╔════╝╚══██╔══╝
        ██╔████╔██║███████║   ██║   ███████║    ██║   ██║██║   ██║█████╗  ███████╗   ██║   
        ██║╚██╔╝██║██╔══██║   ██║   ██╔══██║    ██║▄▄ ██║██║   ██║██╔══╝  ╚════██║   ██║   
        ██║ ╚═╝ ██║██║  ██║   ██║   ██║  ██║    ╚██████╔╝╚██████╔╝███████╗███████║   ██║   
        ╚═╝     ╚═╝╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝     ╚══▀▀═╝  ╚═════╝ ╚══════╝╚══════╝   ╚═╝   
");
        Console.WriteLine("=====================================================================================================");
    }
    internal static void PrintMainMenu()
    {

        Console.Clear();
        PrintHeader();
        Console.Write(@$"                   
                        Quiz your knowledge with one of the options below:
                                    
                                    A - {QuestionType.Addition}
                                    S - {QuestionType.Subtraction}
                                    M - {QuestionType.Multiplication}
                                    D - {QuestionType.Division}
                                    E - Endless Survival
                                    V - View Previous Games
                                    Q - Quit the program
        ");
        Console.WriteLine();
        Console.WriteLine("=====================================================================================================\n");
    }

    internal static void PrintDifficultySelectionMenu()
    {
        string menuTitle = "Select Difficulty";
        Console.Clear();
        PrintHeader();
        Console.WriteLine($"                                              {menuTitle}                                           ");
        Console.WriteLine("=====================================================================================================");
        Console.Write(@$"                   
                                    
                                                E - {DifficultyLevel.Easy}
                                                M - {DifficultyLevel.Medium}
                                                H - {DifficultyLevel.Hard}
                                                I - {DifficultyLevel.Insane}
        ");
        Console.WriteLine();
        Console.WriteLine("=====================================================================================================\n");
    }

    internal static void PrintInnerGameMenu(string title)
    {
        string menuTitle = title;
        Console.Clear();
        PrintHeader();
        Console.WriteLine($"                                              {menuTitle}                                           ");
        Console.WriteLine("=====================================================================================================");
        Console.WriteLine();
    }
    internal static void PrintGameHistoryMenu(List<MiniGame> gameHistory)
    {
        string menuTitle = "GAME HISTORY";
        Console.Clear();
        PrintHeader();
        Console.WriteLine($"                                              {menuTitle}                                           ");
        Console.WriteLine("=====================================================================================================");
        foreach (var game in gameHistory)
        {
            string gameType = game.gameType is GameType.Survival ? game.gameType.ToString() : game.questionType.ToString();
            string date = game.Date.ToString();
            Console.WriteLine($"TimeStamp: {date}     \tGame: {gameType}    \tScore: {game.Score}   \t Difficulty: {game.difficultyLevel}");
        }
        Console.WriteLine();
        Console.WriteLine("=====================================================================================================\n");
        Console.WriteLine($"Press any key to return to the main menu");
        Console.ReadKey();
    }

    internal static void PrintEndInnerGameScreen(string title, int score)
    {
        Console.Clear();
        PrintInnerGameMenu(title);
        Console.WriteLine($"Game over. Your final score is {score}");
        Console.WriteLine($"Press any key to return to the main menu");
        Console.ReadKey();
    }

    internal static void PrintQuestionGenerationPrompt()
    {
        Console.WriteLine($"Generating new question...");
        System.Threading.Thread.Sleep(900);
    }
}
