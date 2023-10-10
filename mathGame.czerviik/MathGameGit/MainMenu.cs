using System;

namespace mathGame.czerviik;

public class MainMenu
{
	public GameTypes Game { get; private set; }
    public bool Repeat { get; private set; }
    public int Difficulty { get; private set; }
    private Scoreboard scoreboard;

    public MainMenu(Scoreboard scoreboard)
	{
		Game = new GameTypes();
        this.scoreboard = scoreboard;
	}

	public void Display()
	{
        Console.Clear();
        Console.WriteLine(@"Welcome to the math game! Select your game:
A - Addition
S - Subtraction
M - Multiplication
D - Division
R - Random
H - Games history
Q - Quit");
    }

    public void ChooseGame()
		{
			string chosenGame = Console.ReadLine();
            Repeat = false;

			switch (chosenGame.ToUpper())
            {
                case "A":
                    Game = GameTypes.Addition;
                    break;
                case "S":
                    Game = GameTypes.Subtraction;
                    break;
                case "M":
                    Game = GameTypes.Multiplication;
                    break;
                case "D":
                    Game = GameTypes.Division;
                    break;
                case "R":
                    Game = GameTypes.Random;
                    break;
                case "H":
                    GameHistory.Instance.ShowGameLogs();
                    Repeat = true;
                    break;
                case "Q":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("You entered an invalid character!");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadKey();
                    Repeat = true;
                    break;
            }     
    }
    public void ChooseDifficulty()
    {
        bool isValidInput = false;
        int tempDifficulty;

        do
        {
            Console.Clear();
            Console.WriteLine(@"Choose a difficulty:
1 - easy
2 - medium
3 - hard");
            string input = Console.ReadLine();
            if (int.TryParse(input, out tempDifficulty))
            {
                if (tempDifficulty < 4 && tempDifficulty > 1)
                {
                    Difficulty = tempDifficulty;
                    isValidInput = true;
                }
                else
                    ErrorMessage("difficulty");
            }
            else
                ErrorMessage("difficulty");
        } while (!isValidInput);
    }

    public void ChooseRounds()
    {
        bool isValidInput = false;
        int tempRounds;

        do
        {
            Console.Clear();
            Console.WriteLine("Choose number of rounds: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out tempRounds))
            {
                if (tempRounds > 0 && tempRounds < 256)
                {
                    scoreboard.Rounds = tempRounds;
                    isValidInput = true;
                }
                else
                    ErrorMessage("number of rounds");
            }
            else
                ErrorMessage("number of rounds");
        } while (!isValidInput);
        Console.Clear();

    }
    private void ErrorMessage(string type)
    {
        Console.WriteLine("You didn't enter a valid {0}!",type);
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}