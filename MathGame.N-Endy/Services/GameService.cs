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
            // Ask user for number of games to play
            int numberOfGames;
            _userInteraction.ShowMessage("How many games would you like to play?: ");
            while (!int.TryParse(_userInteraction.GetUserChoice(), out numberOfGames))
            {
                _userInteraction.ShowMessage("Please enter a valid number of games.");
            }

            // Create player
            var name = _userInteraction.GetPlayerName();
            var player = _playerService.CreatePlayer(name);
            _userInteraction.ShowMessage($"Welcome to the Math Game {player.Name}");

            for (var i = numberOfGames; i > 0; i--)
            {
                // Display game prompt
                _userInteraction.DisplayGamePrompt(player.Name);

                // Get user choice
                // Display Question
                var mathQuestion = GetQuestion(_userInteraction.GetUserChoice());
                _userInteraction.DisplayQuestion(mathQuestion);

                // Get user answer
                var userAnswer = _userInteraction.GetUserChoice();
                int userAnswerToInt;

                // Check if answer is correct
                if (int.TryParse(userAnswer, out userAnswerToInt) && _questionService.CheckAnswer() == userAnswerToInt)
                {
                    // Update player score
                    _playerService.UpdatePlayerScore(player.Name, player.Score + 1);
                    _userInteraction.ShowMessage("Correct!");
                }
                else
                {
                    _userInteraction.ShowMessage("Incorrect!");
                }
            }

            bool willPlayAgain = PlayAgain();
            if (willPlayAgain)
                StartGame();
            else
                EndGame();
        }

        public Question GetQuestion(string userChoice)
        {
            Question question = null;
            switch (userChoice)
            {
                case "1":
                    question = _questionService.GenerateQuestion("+");
                    break;
                case "2":
                    question = _questionService.GenerateQuestion("-");
                    break;
                case "3":
                    question = _questionService.GenerateQuestion("*");
                    break;
                case "4":
                    question = _questionService.GenerateQuestion("/");
                    break;
                case "5":
                    break;
                default:
                    _userInteraction.Exit();
                    break;
            }

            return question;
        }

        public bool PlayAgain()
        {
            _userInteraction.ShowMessage("Would you like to play again? (y/other keys)");
            var userChoice = _userInteraction.GetUserChoice();
            return userChoice.ToLower() == "y";
        }

        public void EndGame()
        {
            _userInteraction.Exit();
        }
    }
}
