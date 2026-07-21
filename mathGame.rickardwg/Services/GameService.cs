using MathGame.Enums;
using MathGame.Models;
using MathGame.Repositories;
using System.Diagnostics;

namespace MathGame.Services;

internal class GameService(IQuestionService questionService, IHistoryRepository historyRepository) : IGameService
{
    private readonly IQuestionService _questionService = questionService;
    private readonly IHistoryRepository _historyRepository = historyRepository;

    private const int TotalQuestions = 5;
    private readonly Stopwatch _stopwatch = new();

    public bool IsFinished { get; set; }
    private int _currentQuestionNumber;
    private int _correctAnswers;
    private GameMode _gameMode;
    private Difficulty _difficulty;
    private MathQuestion? _currentQuestion;

    public void StartGame(GameMode gameMode, Difficulty difficulty)
    {
        IsFinished = false;
        _currentQuestionNumber = 0;
        _correctAnswers = 0;
        _gameMode = gameMode;
        _difficulty = difficulty;
        _stopwatch.Restart();
    }

    public MathQuestion GetCurrentQuestion()
    {
        _currentQuestionNumber++;
        _currentQuestion = _questionService.GenerateQuestion(_gameMode, _difficulty);

        if (_currentQuestionNumber == TotalQuestions)
        {
            IsFinished = true;
        }

        return _currentQuestion;
    }

    public bool SubmitAnswer(int answer)
    {
        var result = answer == _currentQuestion!.CorrectAnswer;
        if (result)
        {
            _correctAnswers++;
        }
        return result;
    }

    public GameEntry EndGame()
    {
        _stopwatch.Stop();

        var entry = new GameEntry()
        {
            GameMode = _gameMode,
            Difficulty = _difficulty,
            CorrectAnswers = _correctAnswers,
            TotalQuestions = TotalQuestions,
            TimeTaken = _stopwatch.Elapsed
        };

        _historyRepository.AddGameEntry(entry);
        return entry;
    }
}
