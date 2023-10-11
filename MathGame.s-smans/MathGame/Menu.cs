namespace MathGame;

internal class Menu
{
    private Helper _helper = new Helper();

    internal void StartGame()
    {
        bool gameInProcess = true;
        GameEngine engine = new GameEngine(_helper);

        do
        {
            Console.Clear();
            PrintIntroduction();

            string userInput = Console.ReadLine();

            switch (userInput.Trim().ToUpper())
            {
                case "H":
                    _helper.History();
                    break;
                case "I":
                    _helper.QuestionCount();
                    break;
                case "A":
                    engine.Addition();
                    break;
                case "S":
                    engine.Subtraction();
                    break;
                case "M":
                    engine.Multiplication();
                    break;
                case "D":
                    engine.Division();
                    break;
                case "R":
                    engine.Random();
                    break;
                case "L":
                    _helper.ChangeDifficulty();
                    break;
                case "Q":
                    Console.WriteLine("Goodbye!");
                    gameInProcess = false;
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        } while (gameInProcess);
    }

    private void PrintIntroduction()
    {
        Console.WriteLine("Welcome to the Math Game! Where your knowledge in mathematics will be tested");
        Console.WriteLine("Choose from the options below which math operand you want to test your skills with:");
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine(" H - History");
        Console.WriteLine(" L - Current Level Difficulty: " + (Difficulty)_helper.DifficultyLevel);
        Console.WriteLine(" I - Question Amount Currently: " + _helper.QuestionAmount);
        Console.WriteLine(" A - Addition");
        Console.WriteLine(" S - Subraction");
        Console.WriteLine(" M - Multiplication");
        Console.WriteLine(" D - Division");
        Console.WriteLine(" R - Random");
        Console.WriteLine(" Q - Quit");
        Console.WriteLine();
    }
}