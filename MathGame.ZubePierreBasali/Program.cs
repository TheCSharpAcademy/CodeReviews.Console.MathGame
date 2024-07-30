namespace MathGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? readResult = "";
            int numberOfGames = 5;
            int option;
            int difficulty = 1;
            int gameType = 1;
            bool replay;

            GameMenu.DisplayMessage("Hello, Welcome to my Math Game project!");

            do
            {
                option = GameMenu.gameOption();

                switch (option)
                {
                    case 1:
                        GameMenu.LaunchGame(option, difficulty, gameType,numberOfGames);
                        replay = GameMenu.Replay();
                        if (!replay) readResult = "exit";
                        break;
                    case 2:
                        difficulty = GameMenu.GameDifficulty();
                        break;
                    case 3:
                        numberOfGames = GameMenu.NumberOfGames();
                        break;
                    case 4:
                        gameType = GameMenu.GameType();
                        break;
                    case 5:
                        numberOfGames = 5;
                        difficulty = 1;
                        gameType = 1;
                        break;
                    case 6:
                        GameMenu.DisplayMessage($"Your Highest score for thhis session is: {Games.HighestScore}");
                        break;
                    case 7:
                        readResult = "exit";
                        break;
                }
            } while (readResult.ToLower() != "exit");

            GameMenu.DisplayMessage("Thank you for playing!");
        }
    }
}
