using Kolejarz.MathGame.GameEngine.PuzzleProviders;
using System.Diagnostics;

namespace Kolejarz.MathGame.GameEngine;

public class Game
{
    private DifficultyLevel _difficultyLevel;
    private PuzzleProvider _puzzleProvider;
    private readonly List<(DifficultyLevel Level, Guess Guess)> _guesses = new();

    public IEnumerable<(DifficultyLevel Level, Guess Guess)> Guesses => _guesses;

    public void SetDifficulty(DifficultyLevel difficulty)
    {
        _difficultyLevel = difficulty;
        _puzzleProvider = difficulty switch
        {
            DifficultyLevel.Easy => new EasyPuzzleProvider(),
            DifficultyLevel.Intermediate => new IntermediatePuzzleProvider(),
            DifficultyLevel.Hard => new HardPuzzleProvider(),
            _ => throw new ArgumentException($"{nameof(difficulty)}={difficulty} is not recognized as valid {nameof(DifficultyLevel)}")
        };
    }

    public Puzzle GetPuzzle(Operation operation) => _puzzleProvider.GetPuzzle(operation);

    public Guess Answer(Puzzle puzzle, int userAnswer, TimeSpan timeTaken)
    {
        var guess = new Guess(puzzle, userAnswer, timeTaken);
        _guesses.Add((_difficultyLevel, guess));
        return guess;
    }
}

public enum DifficultyLevel
{
    Easy,
    Intermediate,
    Hard
}
