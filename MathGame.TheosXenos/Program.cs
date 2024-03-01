int chosenMenuOption;

do
{
    var userChoice = Game.ShowMenu();

    if (!(int.TryParse(userChoice, out chosenMenuOption) && chosenMenuOption is > 0 and < 7))
    {
        Console.WriteLine("Invalid choice, please try again.");
        return;
    }

    if (chosenMenuOption == 1)
    {
        bool retryGame;

        do
        {
            Game.Multiplication();
            retryGame = Game.AskReturnToMenu();
        } while (retryGame);
    }
    else if (chosenMenuOption == 2)
    {
        bool retryGame;

        do
        {
            Game.Division();
            retryGame = Game.AskReturnToMenu();
        } while (retryGame);
    }
    else if (chosenMenuOption == 3)
    {
        bool retryGame;

        do
        {
            Game.Addition();
            retryGame = Game.AskReturnToMenu();
        } while (retryGame);
    }
    else if (chosenMenuOption == 4)
    {
        bool retryGame;

        do
        {
            Game.Subtraction();
            retryGame = Game.AskReturnToMenu();
        } while (retryGame);
    }
    else if (chosenMenuOption == 5)
    {
        Game.ShowHistory();
    }
    else if (chosenMenuOption == 6)
    {
        return;
    }
} while (chosenMenuOption > 0 && chosenMenuOption < 6);
