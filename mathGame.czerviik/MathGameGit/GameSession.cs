using System;
using System.Diagnostics;

namespace mathGame.czerviik;


public class GameSession
{
    private Scoreboard scoreboard;
    private MainMenu mainMenu;
    private bool gameContinue = true;

	public GameSession()
	{
        scoreboard = new();
        mainMenu = new(scoreboard);
    }

    public void Start()
		{
            while (gameContinue)
            {
                do
            {
                scoreboard.ResetScore(); 
                mainMenu.Display();
                mainMenu.ChooseGame();
            } while (mainMenu.Repeat);

            mainMenu.ChooseDifficulty();
            mainMenu.ChooseRounds();

            for (int i = 0; i < scoreboard.Rounds; i++)
            {
                Stopwatch stopwatch = new();
                stopwatch.Start();

                Question currentQuestion = new(mainMenu.Game, mainMenu.Difficulty, scoreboard);
                currentQuestion.CheckAnswer();

                stopwatch.Stop();
                double timeSpan = stopwatch.Elapsed.TotalSeconds;
                scoreboard.AddTime(timeSpan);
            }

            EndGame(scoreboard.Score, mainMenu.Game);
        }
    }

    private void EndGame(int score, GameTypes game)
    {
        string gameName = "";
        bool isValidInput = false;
        switch (game)
        {
            case GameTypes.Addition:
                gameName = "addition game";
                break;
            case GameTypes.Subtraction:
                gameName = "subtraction game";
                break;
            case GameTypes.Multiplication:
                gameName = "multiplication game";
                break;
            case GameTypes.Division:
                gameName = "division game";
                break;
            case GameTypes.Random:
                gameName = "random games";
                break;
        }

        GameHistory.Instance.AddGameLog(gameName, score, scoreboard.Rounds, scoreboard.ShowAverageTime());
        Console.Clear();
        Console.WriteLine("Game over! Your score in {0} is {1}. Average time for one answer: {2} s.", gameName, score, scoreboard.ShowAverageTime());

        do
        {
            Console.WriteLine("Play again? Y/N");
            string playAgain = Console.ReadLine();

            if (playAgain.ToUpper() == "N")
            {
                gameContinue = false;
                isValidInput = true;
            }
            else if (playAgain.ToUpper() == "Y")
                isValidInput = true;
            if (!isValidInput)
            {
                Console.Clear();
                Console.WriteLine("Wrong input.");
            }
        } while (!isValidInput);
    }
	}