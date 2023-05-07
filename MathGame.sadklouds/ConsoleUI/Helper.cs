using MathGameLibrary.sadklouds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI;

internal static class Helper
{
    public static void MainMenu(string name)
    {
        Console.WriteLine("\n------------------------------------");
        Console.WriteLine($"Welcome {name} to math games!");
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Choose from the games below");
        Console.WriteLine();
        Console.WriteLine("A) Addition");
        Console.WriteLine("S) Subtraction");
        Console.WriteLine("M) Multiplication");
        Console.WriteLine("D) Division");
        Console.WriteLine("V) View Game History");
        Console.WriteLine("E) Exit Game");
        Console.WriteLine();
        Console.Write("Select an option: ");
    }

    public static void ViewGameSessions()
    {
        Console.WriteLine();
        Console.WriteLine("Game History");
        Console.WriteLine("---------------------");
        Console.WriteLine();

        var history = GameEngine.GameHistory;

        Console.WriteLine("--------------------------------------------------------------------------------------------------");
        foreach (var session in history)
        {
            Console.WriteLine($"SessionDate: {session.SessionDate}, Game Type: {session.GameType}, Score: {session.Score}, TimeTaken: {session.TimeTaken.ToString(@"hh\:mm\:ss")}");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
        }

        Console.Write("\nPress any key to return to menu: ");
        Console.WriteLine();
    }

    public static string GetName(string message)
    {
        Console.Write(message);
        string output = Console.ReadLine();
        return output;
    }

    public static int GetNumberOfQuestions()
    {
        int numberOfQuestions = 0;
        do
        {
            Console.Write("How many questions do you want?: ");
            string userInput = Console.ReadLine();

            bool parse = int.TryParse(userInput, out numberOfQuestions);
            if (parse == false)
            {
                Console.WriteLine("Invalid Input");
            }
        } while (numberOfQuestions <= 0);

        return numberOfQuestions;
    }
}

