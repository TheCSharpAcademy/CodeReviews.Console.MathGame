using System.Diagnostics;
using MathGame.Enums;
using MathGame.Interfaces;
using MathGame.Models;
using MathGame.UI;

namespace MathGame.Services;

public class GameEngine : IGameEngine
{
    private const int TotalQuestions = 5;

    private readonly QuestionGenerator _generator;
    private readonly ConsoleUI _ui;

    public GameEngine(QuestionGenerator generator, ConsoleUI ui)
    {
        _generator = generator;
        _ui = ui;
    }

    public GameSession Play(GameType game, Difficulty difficulty)
    {
        int score = 0;
        DifficultySettings settings = GetDifficultySettings(difficulty);
        Stopwatch totalSessionTime = Stopwatch.StartNew();

        for (int i = 0; i < TotalQuestions; i++)
        {
            MathQuestion question = _generator.Generate(game, settings);

            _ui.DisplayQuestion(question, i + 1, TotalQuestions, settings.TimeLimitSeconds);

            Stopwatch questionTimer = Stopwatch.StartNew();
            int playerAnswer = _ui.GetPlayerAnswer();
            questionTimer.Stop();

            bool outOfTime = questionTimer.Elapsed.TotalSeconds > settings.TimeLimitSeconds;

            if (outOfTime)
            {
                _ui.DisplayFeedback(correct: false, question.CorrectAnswer);
                question.RecordAnswer(int.MinValue); // flag as false answer
            }
            else
            {
                question.RecordAnswer(playerAnswer);

                if (question.isCorrect)
                {
                    score++;
                    _ui.DisplayFeedback(correct: true);
                }
                else
                {
                    _ui.DisplayFeedback(correct: false, question.CorrectAnswer);
                }
            }
        }

        totalSessionTime.Stop();

        var session = new GameSession(game, score, TotalQuestions, totalSessionTime.Elapsed, difficulty);
        _ui.DisplaySummary(session);
        return session;
    }

    private static DifficultySettings GetDifficultySettings(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                return new DifficultySettings(10, 60);
            case Difficulty.Medium:
                return new DifficultySettings(20, 90);
            case Difficulty.Hard:
                return new DifficultySettings(35, 90);
            
            default:
                return new DifficultySettings(10, 60);
        }
    }
}
