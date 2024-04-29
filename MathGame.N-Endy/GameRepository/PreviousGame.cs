namespace MathGame.N_Endy.GameRepository
{
    public class PreviousGame : IPreviousGame
    {
        List<string> games = new();

        public void SaveGame(string name, int score)
        {
            string gameToBeSaved = $"{name}, with score of {score} on {DateTime.Now}";
            games.Add(gameToBeSaved);
        }

        public void LoadPreviousGame()
        {
            foreach (var game in games)
            {
                Console.WriteLine(game);
            }
        }
    }
}