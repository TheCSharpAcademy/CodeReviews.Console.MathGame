using MathGame.N_Endy.GameEntities;
using MathGame.N_Endy.GameCore;

namespace MathGame.N_Endy.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly Player _player;

        public PlayerService(Player player)
        {
            _player = player;
        }

        public Player CreatePlayer(string name)
        {
            _player.Name = name;
            return _player;
        }

        public void UpdatePlayerScore(int score)
        {
            _player.Score = score;
        }
    }
}