using MathGameRecap.Models;
using static MathGameRecap.Common.Enums;
namespace MathGameRecap.Services
{
    internal class GameEngine
    {

        private readonly Random random = new();
        private readonly Dictionary<GameType, BaseGame> gameRunner = new()
        {
            [GameType.Add] = new AdditionGame(),
            [GameType.Subtract] = new SubtractionGame(),
            [GameType.Multiply] = new MultiplicationGame(),
            [GameType.Divide] = new DivisionGame(),
            [GameType.Random] = new RandomGame()
        };

        public void RunGame(GameType operation, Difficulty difficulty)
        {
            var game = gameRunner[operation].RunGame(difficulty);
            MockDatabase.AddGame(game);
        }


    }
}
