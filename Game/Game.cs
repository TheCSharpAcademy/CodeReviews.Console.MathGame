class Game
{
    static List<GameRoundLog> logs = new List<GameRoundLog>();

    public static void RunGameLoop()
    {
        do
        {
            int menuOption = Menu.DisplayMainMenu();

            switch (menuOption)
            {
                case 1:
                    GameRoundLog additionLog = GameRound.Play([GameRound.AdditionGame]);
                    logs.Add(additionLog);

                    break;
                case 2:
                    GameRoundLog subtractLogs = GameRound.Play([GameRound.SubtractionGame]);
                    logs.Add(subtractLogs);

                    break;
                case 3:
                    GameRoundLog multiplyLogs = GameRound.Play([GameRound.MultiplicationGame]);
                    logs.Add(multiplyLogs);

                    break;
                case 4:
                    GameRoundLog divideLogs = GameRound.Play([GameRound.DivisionGame]);
                    logs.Add(divideLogs);

                    break;
                case 5:
                    GameRoundLog randomLogs = GameRound.Play([
                        GameRound.AdditionGame,
                        GameRound.DivisionGame,
                        GameRound.MultiplicationGame,
                        GameRound.SubtractionGame
                    ]);

                    logs.Add(randomLogs);

                    break;
                case 6:
                    Util.PrintLogs(logs);
                    break;
                case 7:
                    GameConfig.difficulty = Menu.ReadDifficultyInput();

                    break;
                case 8:
                    GameConfig.numQuestionsPerGame = Menu.ReadNumQuestionsPerGame();

                    break;
                case 9:
                    Console.WriteLine($"Thanks for playing the Math game. Exiting...");
                    return;
                default:
                    Console.WriteLine("Please choose a valid menu option.");
                    continue;
            }
        }
        while (true);
    }
}