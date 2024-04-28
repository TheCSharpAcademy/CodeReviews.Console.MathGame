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
        private readonly IQuestionService _questionService;

        public GameService(IPlayerService playerService, IUserInteraction userInteraction, IQuestionService questionService)
        {
            _playerService = playerService;
            _userInteraction = userInteraction;
            _questionService = questionService;
        }

        public void StartGame()
        {
            // Create player
            var name = _userInteraction.GetPlayerName();
            var player = _playerService.CreatePlayer(name);

            // Display game prompt
            _userInteraction.DisplayGamePrompt(player.Name);

            ApplyUserChoice(_userInteraction.GetPlayerChoice());
        }

        public void ApplyUserChoice(string userChoice)
        {
            switch (userChoice)
            {
                case "1":
                    return _questionService.GenerateQuestion("+");
                case "2":
                    return _questionService.GenerateQuestion("-");
                case "3":
                    return _questionService.GenerateQuestion("*");
                case "4":
                    return _questionService.GenerateQuestion("/");
                case "5":
                default:
            }
        }

        public void PlayAgain()
        {

        }

        public void EndGame()
        {
            _userInteraction.Exit();
        }
    }
}
