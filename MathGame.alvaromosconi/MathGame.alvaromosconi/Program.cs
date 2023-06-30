using MathGame.alvaromosconi;

SetupNewGame();

void SetupNewGame()
{
    string playerName = GetPlayerName();
    DateTime currentDate = DateTime.UtcNow;
    GameEngine game = new GameEngine();
    new Menu(playerName, currentDate, game);
}

string GetPlayerName()
{
    string playerName;
    do
    {
        Console.Write("Please enter your name: ");
        playerName = Console.ReadLine();
        Console.Clear();

        if (string.IsNullOrWhiteSpace(playerName))
        {
            MessageHelper.ShowErrorMessage("Invalid name. Please enter a valid name.");
        }
    } while (string.IsNullOrWhiteSpace(playerName));

    return playerName;
}
