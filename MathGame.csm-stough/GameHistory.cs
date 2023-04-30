namespace MathGame
{
    internal class GameHistory {
        
        private struct History
        {
            public string gameType;
            public float score;
            public float time;
            public int rounds;
            public string difficulty;

            public History(string gameType, float score, float time, int rounds, string difficulty)
            {
                this.gameType = gameType;
                this.score = score;
                this.time = time;
                this.rounds = rounds;
                this.difficulty = difficulty;
            }
        }

        private static List<History> historyList;

        public static void Init()
        {
            historyList = new List<History>();
        }

        public static void AddGame(string gameType, float score, float time, int rounds, string difficulty)
        {
            historyList.Add(new History(gameType, score, time, rounds, difficulty));
        }

        public static void ShowHistory()
        {
            Console.WriteLine(GetHistoryText());
            Console.ReadLine();
        }

        private static string GetHistoryText()
        {
            string historyText = "";

            historyText += "Game History\n";
            historyText += "-----------------------------------\n";
            historyText += String.Format("  {0, 15} {1, 15} {2, 15} {3, 15} {4, 15}\n\n", "Game Type", "Score", "Time", "Difficulty", "Rounds");

            foreach (History history in historyList)
            {
                historyText += String.Format("- {0, 15} {1, 15} {2, 15} {3, 15} {4, 15}\n", history.gameType, history.score.ToString("0.0"), history.time.ToString("0.0"), history.difficulty, history.rounds.ToString());
            }

            return historyText;
        }
    }
}
