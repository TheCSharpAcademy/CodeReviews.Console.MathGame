namespace MiroiuDev.MathGame;

internal class Menu
{
    private readonly GameEngine _engine = new();
    internal void ShowMenu(string name, DateTime date)
    {
        bool isGameOn = true;

        Console.WriteLine($"Hello {name}. It's {date}. This is a mathematical game. Press any key to play the game.");

        Console.ReadLine();

        do
        {
            Console.Clear();
            Console.WriteLine("----------------------------------");
            Console.WriteLine($@"What game would you like to play today? Choose from the options below:
A - Addition
S - Substraction
M - Multiplication
D - Division
R - Random
H - Game History
N - Settings
L - Dificulty
Q - Quit the program
");
            Console.WriteLine("----------------------------------");

            var choice = Console.ReadLine()?.Trim()?.ToLower();

            var difficulty = _engine.GetDifficulty();

            switch (choice)
            {
                case "a":
                    _engine.PlayGame(GameType.Addition, Games.AdditionGame, () => Helpers.GetTwoRandomNumbers(1, difficulty));
                    break;
                case "s":
                    _engine.PlayGame(GameType.Substraction, Games.SubstractionGame, () => Helpers.GetTwoRandomNumbers(1, difficulty));
                    break;
                case "m":
                    _engine.PlayGame(GameType.Multiplication, Games.MultiplicationGame, () => Helpers.GetTwoRandomNumbers(1, difficulty));
                    break;
                case "d":
                    _engine.PlayGame(GameType.Division, Games.DivisionGame, () => Helpers.GetDivisionNumbers(difficulty));
                    break;
                case "r":
                    _engine.PlayGame(GameType.Random, Games.RandomGame, () => Helpers.GetTwoRandomNumbers(1, difficulty));
                    break;
                case "h":
                    Helpers.PrintGames();
                    break;
                case "l":
                    bool invalid = true;

                    do
                    {

                        Console.Clear();
                        Console.WriteLine($@"Choose a difficulty:
E - Easy
M - Medium
H - Hard
");

                        var level = Console.ReadLine();

                        if (level is null || level == "") continue;

                        level = level.ToLower();

                        switch (level)
                        {
                            case "e":
                                _engine.Difficulty = Difficulty.Easy;
                                Console.WriteLine($"You chose Easy. Press any key to return to main menu.");
                                break;
                            case "m":
                                _engine.Difficulty = Difficulty.Medium;
                                Console.WriteLine($"You chose Medium. Press any key to return to main menu.");

                                break;
                            case "h":
                                _engine.Difficulty = Difficulty.Hard;
                                Console.WriteLine($"You chose Hard. Press any key to return to main menu.");

                                break;
                            default:
                                Console.WriteLine("Invalid choice. Press any key to try again.");
                                Console.ReadLine();
                                continue;
                        }

                        Console.ReadLine();
                        invalid = false;
                    } while (invalid);
                    break;
                case "n":
                    bool loop = true;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("How many questions would you like to answer?");

                        var numberOfQuestions = Helpers.ValidateResult();

                        int answer = int.Parse(numberOfQuestions);

                        _engine.NumberOfQuestions = answer;

                        Console.WriteLine($"You chose to answer {answer} questions. Press any key to return to main menu.");
                        Console.ReadLine();

                        loop = false;
                    } while (loop);

                    break;
                case "q":
                    Console.Clear();
                    Console.WriteLine("Thank you for playing! Goodbye.");

                    isGameOn = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any key to return to main menu.");
                    Console.ReadLine();
                    break;
            }
        } while (isGameOn);
    }
}
