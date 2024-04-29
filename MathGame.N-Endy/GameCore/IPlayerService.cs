using MathGame.N_Endy.GameEntities;

namespace MathGame.N_Endy.GameCore
{
    public interface IPlayerService
    {
        Player CreatePlayer(string name);
        void UpdatePlayerScore(int score);
    }
}