using static System.Formats.Asn1.AsnWriter;

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
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid command! Try again.\n");

                Console.ForegroundColor = ConsoleColor.White;
                Menu(null);
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
Q - Quit the program");
        Console.WriteLine("-------------------");

        ShowMenu();
    }

    static void EndGame(int result)
    {
        Console.Clear();
        Console.WriteLine($"Game over. Final score is {result}\n");

        Console.WriteLine("Press enter to go back");
        var a = Console.ReadLine();
        Console.Clear();

        Menu($"{DateTime.Now.TimeOfDay} - Subtraction game - Score: {result}");
    }

}
