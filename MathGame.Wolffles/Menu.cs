using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_Game;

internal class Menu
{
    string m_name = "N/A";
    DateTime m_date = DateTime.UtcNow;
    GameEngine m_game = new GameEngine();
 
    internal void initializeMenuParameters()
    {
        Console.WriteLine("Please type your name");
        m_name = Console.ReadLine();
        m_game.setDifficulty();
    }

    internal bool startMenu()
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
                Console.WriteLine("V");
                break;
            case "f":
                m_game.setDifficulty();
                break;
            case "a":
                m_game.additionGame();
                break;
            case "s":
                m_game.substractionGame();
                break;
            case "m":
                m_game.multiplicationGame();
                break;
            case "d":
                m_game.divisionGame();
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

