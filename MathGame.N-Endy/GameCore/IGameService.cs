namespace MathGame.N_Endy.GameCore
{
    public interface IGameService
    {
        void StartGame();
        void ApplyUserChoice();
        void PlayAgain();
        void EndGame();
    }
}