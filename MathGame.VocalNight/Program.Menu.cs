partial class Program
{
    static List<string> pastGames = new List<string>();

    static void ShowMenu()
    {
        var gameSelected = Console.ReadLine();
        int questionNumber;
        int difficulty;

        switch (gameSelected.Trim().ToLower())
        {

            case "a":
                questionNumber = NumberOfQuestions();
                difficulty = PickDifficulty();
                AddtionGame(questionNumber, difficulty);
                break;
            case "s":
                questionNumber = NumberOfQuestions();
                difficulty = PickDifficulty();
                SubtractionGame(questionNumber, difficulty);
                break;
            case "m":
                questionNumber = NumberOfQuestions();
                difficulty = PickDifficulty();
                MultiplicationGame(questionNumber, difficulty);
                break;
            case "d":
                questionNumber = NumberOfQuestions();
                difficulty = PickDifficulty();
                DivisionGame(questionNumber, difficulty);
                break;
            case "r":
                ShowPastGames(pastGames);
                break;
            case "q":
                Console.WriteLine("GoodBye");
                Environment.Exit(1);
                break;
            default:
                Console.WriteLine("Invalid");
                Environment.Exit(1);
                break;

        }
    }

    static void Menu( string result )
    {
        if (result != null)
        {
            pastGames.Add(result);
        }

        Console.WriteLine($@"What game would you like to play today?
A - Addition
S - Subtraction
M - Multiplication
D - Division
R - Show past game results
Q - Quite the program");
        Console.WriteLine("-------------------");

        ShowMenu();
    }

}
