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
        } while (selection);
    }


}
