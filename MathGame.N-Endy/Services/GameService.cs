using MathGame.N_Endy.GameCore;
using MathGame.N_Endy.GameEntities;
using MathGame.N_Endy.GameUserInteraction;
using MathGame.N_Endy.Services;

namespace MathGame.N_Endy.Services
{
    public class GameService : IGameService
    {
        private readonly IPlayerService _playerService;
        private readonly IUserInteraction _userInteraction;

        public GameService(IPlayerService playerService, IUserInteraction userInteraction)
        {
            _playerService = playerService;
            _userInteraction = userInteraction;
        }

        public void StartGame()
        {
            // Create player
            var name = _userInteraction.GetPlayerName();
            var player = _playerService.CreatePlayer(name);

            // Display game prompt
            _userInteraction.DisplayGamePrompt(player.Name);
        }
    }
}
