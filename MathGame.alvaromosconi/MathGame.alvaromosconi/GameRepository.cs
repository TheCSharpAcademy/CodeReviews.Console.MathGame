namespace MathGame.alvaromosconi
{
    internal static class GameRepository
    {
        private static List<GameRecord> gameRecords= new List<GameRecord>();

        internal static void AddNewGameRecord(GameRecord record)
        {
            gameRecords.Add(record);
        }

        internal static void PrintAllGameRecords()
        {
            Console.Clear();
            Console.WriteLine("");

            foreach (GameRecord record in gameRecords)  
            {
                Console.WriteLine(record.PrintGameRecord());
            }
        }

    }

    internal class GameRecord
    {

        internal string PlayerName { get; set; }
        internal DateTime GameDate { get; set; }

        internal int Score { get; set; }
  
        internal string PrintGameRecord()
        {
            return $"Player: {PlayerName}, Date: {GameDate}, SCORE: {Score} ";
        }
    }

}
