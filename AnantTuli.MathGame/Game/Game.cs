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
                    GameRoundLog additionLog = GameRound.Play([Operation.Add]);
                    logs.Add(additionLog);

                    break;
                case 2:
                    GameRoundLog subtractLogs = GameRound.Play([Operation.Subtract]);
                    logs.Add(subtractLogs);

                    break;
                case 3:
                    GameRoundLog multiplyLogs = GameRound.Play([Operation.Multiply]);
                    logs.Add(multiplyLogs);

                    break;
                case 4:
                    GameRoundLog divideLogs = GameRound.Play([Operation.Divide]);
                    logs.Add(divideLogs);

                    break;
                case 5:
                    GameRoundLog randomLogs = GameRound.Play([
                        Operation.Add,
                        Operation.Subtract,
                        Operation.Multiply,
                        Operation.Divide
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