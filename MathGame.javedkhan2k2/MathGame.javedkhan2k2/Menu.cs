namespace MathGame.javedkhan2k2;

internal class Menu
{
    GameEngine gamesClass;

    public Menu(string playerName)
    {
        gamesClass = new GameEngine(playerName);
    }

    internal void ShowMenu(DateTime date)
    {
        Console.Clear();
        Console.WriteLine($"Hello {gamesClass.PlayerName}. It's {date}. This is your math's game. That's great that you're working on improving yourself");
        Console.WriteLine("Press any key to show menu");
        Console.ReadLine();
        Console.WriteLine("\n");

        var isGameOn = true;

        do
        {
            Console.Clear();
            Console.WriteLine(@$"
What game would you like to play today? Choose from the options below:
V - View Previous Games ({Helpers.getGamesNumber()})
C = Change Number of Questions({gamesClass.NumberOfQuestions})
H = Change Game Difficulty({gamesClass.Difficulty})
A - Addition
S - Subtraction
M - Multiplication
D - Division
R = Random Questions
Q - Quit the program");
            Console.WriteLine("---------------------------------------------");

            var gameSelected = Console.ReadLine();

            switch (gameSelected.Trim().ToLower())
            {
                case "v":
                    Helpers.PrintGames();                    
                    break;
                case "c":
                    gamesClass.ChangeQuestions();
                    break;
                case "h":
                    gamesClass.ChangeDifficulty();
                    break;
                case "a":
                    gamesClass.AdditionGame("Addition game");
                    break;
                case "s":
                    gamesClass.SubtractionGame("Subtraction game");
                    break;
                case "m":
                    gamesClass.MultiplicationGame("Multiplication game");
                    break;
                case "d":
                    gamesClass.DivisionGame("Division game");
                    break;
                case "r":
                    gamesClass.RandomGame("Random game");
                    break;
                case "q":
                    gamesClass.EndTime = DateTime.UtcNow;
                    Console.WriteLine($"Goodbye {gamesClass.PlayerName}. You started the Game at {gamesClass.StartTime.ToLongDateString()} and Ended at {gamesClass.EndTime.ToLongDateString()}\n Press any Key");
                    Console.ReadLine();
                    isGameOn = false;
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        } while (isGameOn);
    }
}