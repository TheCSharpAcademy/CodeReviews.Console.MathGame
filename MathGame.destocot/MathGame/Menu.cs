namespace MathGame;

internal class Menu
{
    private readonly GameEngine gameSelection = new();

    internal void ShowMenu()
    {
        var selection = true;

        do
        {
            Console.ResetColor();
            Helpers.DisplayMainMenu();
            var mode = Console.ReadLine();
            mode = Validations.ValidateInt(mode, Helpers.DisplayMainMenu);

            switch (mode.Trim())
            {
                case "0":
                    Helpers.PrintGames();
                    break;
                case "1":
                    gameSelection.AdditionGame("Addition Game");
                    break;
                case "2":
                    gameSelection.SubtractionGame("Subtraction Game");
                    break;
                case "3":
                    gameSelection.MultiplicationGame("Multiplication Game");
                    break;
                case "4":
                    gameSelection.DivisionGame("Division Game");
                    break;
                case "5":
                    gameSelection.RandomGame("Random Game");
                    break;
                case "6":
                    Console.WriteLine("Goodbye");
                    selection = false;
                    break;
                default:
                    Console.WriteLine("invalid entry, press [enter] to try again.");
                    Console.ReadLine();
                    break;
            }

            /*
            switch (mode)
            {
                            case "5":
                                Random random = new Random();
            int[] difficulties = { 0, 40, 90 };
            diff = difficulties[random.Next(0, 3)];
            diffText = "Easy";
            Console.ForegroundColor = ConsoleColor.Green;
            if (diff == 40)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                diffText = "Medium";
            }
            else if (diff == 90)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                diffText = "Hard";
            }

            var randomNumOfQs = random.Next(1, 11);

            gameSelection.RandomGame("Random Game", diffText, diff, randomNumOfQs);
            break;        }*/
        } while (selection);
    }


}
