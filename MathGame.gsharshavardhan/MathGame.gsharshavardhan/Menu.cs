namespace MathGame.gsharshavardhan;

internal class Menu
{
    GameEngine engine = new GameEngine();
    internal void ShowMenu(string userName)
    {
        var optionsMenu = @$"What game would you like to play?
                        A - Addition
                        S - Subtraction
                        M - Multiplication
                        D - Division
                        V - View previous games
                        Q - Quit the program";

        var isGameOn = true;

        Helpers.PrintLine();
        Console.WriteLine($"Hi, {userName}! Welcome to the Math Game");

        do
        {
            Console.WriteLine(optionsMenu);
            Helpers.PrintLine();
            var optionInput = Console.ReadLine();
            switch (optionInput.Trim().ToLower())
            {
                case "a":
                    engine.AdditionGame("Addition Game");
                    break;
                case "s":
                    engine.SubtractionGame("Subtraction Game");
                    break;
                case "m":
                    engine.MultiplicationGame("Multiplication Game");
                    break;
                case "d":
                    engine.DivisionGame("Division Game");
                    break;
                case "v":
                    Helpers.ShowPreviousGames();
                    break;
                case "q":
                    Console.WriteLine("Exiting the game...");
                    isGameOn = false;
                    break;
                default:
                    Console.WriteLine("Invalid Input! Try Again.");
                    break;
            }
        }
        while (isGameOn);
    }
}
