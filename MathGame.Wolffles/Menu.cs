using System;


namespace Math_Game;

internal class Menu
{
    string m_name = "N/A";
    DateTime m_date = DateTime.UtcNow;
    GameEngine m_game = new GameEngine();
 
    internal void InitializeMenuParameters()
    {
        Console.WriteLine("Please type your name");
        m_name = Console.ReadLine();
        m_game.SetDifficulty();
    }

    internal bool StartMenu()
    {

        Console.WriteLine("------------------------------------------------------------------------------------------------------------");
        Console.WriteLine($"Hello {m_name.ToUpper()}. It's {m_date.DayOfWeek}. Welcome to the math game.");
        Console.WriteLine($@" What game would you like to play? Choose from the options below:
            V - History
            F - DiFficulty
            A - Addition
            S - Substraction
            M - Multiplication
            D - Division
            Q - Quit the program");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------");

        string selectedGame = Console.ReadLine();

        switch (selectedGame.Trim().ToLower())
        {
            case "v":
                m_game.log.ReadLog();
                break;
            case "f":
                m_game.SetDifficulty();
                break;
            case "a":
                m_game.AdditionGame();
                break;
            case "s":
                m_game.SubstractionGame();
                break;
            case "m":
                m_game.MultiplicationGame();
                break;
            case "d":
                m_game.DivisionGame();
                break;
            case "q":
                Console.WriteLine("Quitting program...");
                return false;
                break;
            default:
                Console.WriteLine("Invalid Input");
                break;
        }
        return true;
    }
}

