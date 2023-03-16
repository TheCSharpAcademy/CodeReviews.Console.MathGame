namespace ConsoleMathGame;

internal static class Menu
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        String player = Helpers.GetName();
        DateTime date = DateTime.Now;

        Console.WriteLine($"Hello {player} and welcome to the Math Game.");
        Console.WriteLine($"Oh and by the way, today is  {date}");       

        Console.WriteLine("\nPress any key to open the menu.");
        Console.ReadLine();
        Console.Clear();

        GameEngine theGame = new(player);
        Boolean isGameOn = true;

        while (isGameOn)
        {
            Console.WriteLine("What would you like to play? Type the corresponding letter to start...");
            Console.WriteLine("\n\tA - Addition Game\n" +
                "\tS - Subtraction Game\n" +
                "\tM - Multiplication Game\n" +
                "\tD - Division Game\n" +
                "\tR - Random Game\n" +
                "\tF - Frenzy Game\n" +
                "\tV - View Scores\n" +
                "\tQ - Quit Game");

            string choice;
            int level, numberOfQuestions;
            choice = Console.ReadLine();
            switch (choice.ToUpper())
            {
                case "A":
                    Console.Clear();
                    level = Helpers.GetLevel();
                    numberOfQuestions = Helpers.GetNumberOfQuestions();
                    theGame.AdditionGame(level, numberOfQuestions);
                    Console.WriteLine("Press any key to go back to the menu.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "S":
                    Console.Clear();
                    level = Helpers.GetLevel();
                    numberOfQuestions = Helpers.GetNumberOfQuestions();
                    theGame.SubtractionGame(level, numberOfQuestions);
                    Console.WriteLine("Press any key to go back to the menu.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "M":
                    Console.Clear();
                    level = Helpers.GetLevel();
                    numberOfQuestions = Helpers.GetNumberOfQuestions();
                    theGame.MultiplicationGame(level, numberOfQuestions);
                    Console.WriteLine("Press any key to go back to the menu.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "D":
                    Console.Clear();
                    level = Helpers.GetLevel();
                    numberOfQuestions = Helpers.GetNumberOfQuestions();
                    theGame.DivisionGame(level, numberOfQuestions);
                    Console.WriteLine("Press any key to go back to the menu.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "R":
                    Console.Clear();
                    level = Helpers.GetLevel();
                    numberOfQuestions = Helpers.GetNumberOfQuestions();
                    theGame.RandonGame(level, numberOfQuestions);
                    Console.WriteLine("Press any key to go back to the menu.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "F":
                    Console.Clear();
                    level = Helpers.GetLevel();
                    numberOfQuestions = Helpers.GetNumberOfQuestions();
                    theGame.FrenzyGame(level, numberOfQuestions);
                    Console.WriteLine("Press any key to go back to the menu.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "V":
                    Console.Clear();
                    Helpers.ShowScores();
                    Console.WriteLine("Press any key to go back to the menu.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "Q":
                    Console.Clear();
                    Console.WriteLine("Thank you for playing!");
                    isGameOn = false;
                    break;
                case "":
                    Console.WriteLine("we cannot process an empty choice. Try again please.");
                    Console.WriteLine("Press any key to go back to the menu.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Invalid Input! Try Again.");
                    Console.WriteLine("Press any key to go back to the menu.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
            }
        }
    }
}