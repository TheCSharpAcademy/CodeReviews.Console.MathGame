namespace MathGame.N_Endy.Services
{
    public class GameService : IGameService
    {
        public void StartGame()
        {
            private readonly IPlayerService _playerService;
            private readonly IUserInteractionService _userInteraction;

            public GameService(IPlayerService playerService, IUserInteractionService userInteraction)
            {
                _playerService = playerService;
                _userInteraction = userInteraction;
            }

            // Create player
            var name = _userInteraction.GetPlayerName();
            var player = _playerService.CreatePlayer(name);

            // Display game prompt
            _userInteraction.DisplayGamePrompt(player.Name);

            // Get player choice
            var choice = _userInteraction.GetPlayerChoice();
        }
    }
}