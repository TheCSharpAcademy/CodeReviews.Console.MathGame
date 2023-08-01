using MathGame.MartinL_no.Models;

namespace MathGame.MartinL_no.Services
{
    internal class MathGameService
    {
        private readonly Random _random;
        private Difficulty _difficulty;
        private int _numberOfQuestions;
        private readonly List<GameResult> _gameResults;

        internal MathGameService(List<GameResult> gameResults = null, int numberOfQuestions = 3)
        {
            _random = new Random();
            _difficulty = Difficulty.Easy;
            _numberOfQuestions = numberOfQuestions;
            _gameResults = gameResults ?? new List<GameResult>();
        }

        internal List<GameResult> GetGameResults()
        {
            return _gameResults;
        }

        internal Game GetAddition()
        {
            var endValue = GetEndOfRangeForInputValues();
            var valueOne = _random.Next(1, endValue);
            var valueTwo = _random.Next(1, endValue);

            return new Game(DateTime.Now, GameType.Addition, valueOne, valueTwo);
        }

        internal Game GetSubtraction()
        {
            var endValue = GetEndOfRangeForInputValues();
            var valueOne = _random.Next(1, endValue);
            var valueTwo = _random.Next(1, endValue);

            return new Game(DateTime.Now, GameType.Subtraction, valueOne, valueTwo);
        }

        internal Game GetMultiplication()
        {
            var endValue = GetEndOfRangeForInputValues();
            var valueOne = _random.Next(1, endValue);
            var valueTwo = _random.Next(1, endValue);

            return new Game(DateTime.Now, GameType.Multiplication, valueOne, valueTwo);
        }

        internal Game GetDivision()
        {
            var (valueOne, valueTwo) = GetNumberPairThatEqualsWholeNumberWhenDivided();

            return new Game(DateTime.Now, GameType.Division, valueOne, valueTwo);
        }

        internal Game GetRandomGame()
        {
            var gameTypes = (GameType[])Enum.GetValues(typeof(GameType));
            int randomIndex = _random.Next(0, gameTypes.Length);
            var gameType = gameTypes[randomIndex];

            switch (gameType)
            {
                case GameType.Addition:
                    return GetAddition();
                case GameType.Subtraction:
                    return GetSubtraction();
                case GameType.Multiplication:
                    return GetMultiplication();
                case GameType.Division:
                    return GetDivision();
                default:
                    throw new NotImplementedException();
            }
        }

        internal void AnswerEquation(Game game, int answer)
        {
            if (game.Attempts < _numberOfQuestions - 1)
            {
                if (game.Answer == answer) game.Score++;

                var endValue = GetEndOfRangeForInputValues();
                game.ValueOne = _random.Next(1, endValue);
                game.ValueTwo = _random.Next(1, endValue);
            }
            else EndGame(game);

            game.Attempts++;
        }

        internal void AnswerDivisionEquation(Game game, int answer)
        {
            if (game.Attempts < _numberOfQuestions - 1)
            {
                if (game.Answer == answer) game.Score++;

                var (valueOne, valueTwo) = GetNumberPairThatEqualsWholeNumberWhenDivided();
                game.ValueOne = valueOne;
                game.ValueTwo = valueTwo;
            }
            else EndGame(game);

            game.Attempts++;
        }

        private void EndGame(Game game)
        {
            game.IsGameOver = true;
            var duration = game.StartTime - DateTime.Now;
            _gameResults.Add(new GameResult(DateTime.Now, duration, game.Type, _difficulty, _numberOfQuestions, game.Score));
        }

        internal void ChangeDifficulty(int level)
        {
            switch (level)
            {
                case 1:
                    _difficulty = Difficulty.Easy;
                    break;
                case 2:
                    _difficulty = Difficulty.Medium;
                    break;
                case 3:
                    _difficulty = Difficulty.Hard;
                    break;
            }
        }

        internal void ChangeNumberOfQuestions(int numberOfQuestions)
        {
            if (numberOfQuestions < 1 || numberOfQuestions > 9) return;

            _numberOfQuestions = numberOfQuestions;
        }

        private int GetEndOfRangeForInputValues()
        {
            var difficultyMultiplier = 1;
            switch(_difficulty)
            {
                case Difficulty.Easy:
                    break;
                case Difficulty.Medium:
                    difficultyMultiplier = 2;
                    break;
                case Difficulty.Hard:
                    difficultyMultiplier = 3;
                    break;
            }

            return Convert.ToInt32(20 * difficultyMultiplier);
        }

        private (int, int) GetNumberPairThatEqualsWholeNumberWhenDivided()
        {
            var valueOne = _random.Next(1, GetEndOfRangeForInputValues());
            var valueTwo = _random.Next(1, GetEndOfRangeForInputValues());

            while (valueOne % valueTwo != 0)
            {
                valueOne = _random.Next(1, GetEndOfRangeForInputValues());
                valueTwo = _random.Next(1, GetEndOfRangeForInputValues());
            };

            return (valueOne, valueTwo);
        }
    }
}