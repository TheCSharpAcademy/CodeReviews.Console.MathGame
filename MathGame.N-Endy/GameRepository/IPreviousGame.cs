namespace MathGame.N_Endy.GameRepository
{
    public interface IPreviousGame
    {
        void SaveGame(string name, int score);
        void LoadPreviousGame();
    }
}