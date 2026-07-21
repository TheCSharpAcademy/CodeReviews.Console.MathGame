using MathGame.Enums;
using MathGame.Models;

namespace MathGame.Services;

internal interface IGameService
{
    bool IsFinished { get; set; }
    void StartGame(GameMode gameMode, Difficulty difficulty);
    MathQuestion GetCurrentQuestion();
    bool SubmitAnswer(int answer);
    GameEntry EndGame();
}
