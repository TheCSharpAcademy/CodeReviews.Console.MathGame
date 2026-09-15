using Math_Game.Enums;
using Math_Game.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
[assembly: InternalsVisibleTo("MathGameTests")]

namespace Math_Game.Application;

internal class Quiz
{
    IMathQuizUserInteractor _userInteractor;
    QuestionGenerator _questionGenerator;
    public List<Question> Questions = new List<Question>();
    public int Points { get; private set; }
    public double Time { get; private set; }
    public Quiz(IMathQuizUserInteractor userInteractor, QuestionGenerator questionGenerator)
    {
        _userInteractor = userInteractor;
        _questionGenerator = questionGenerator;
    }
    public void StartGame(Difficulty difficulty, MenuOptions quizMode)
    {
        for(int i = 1; i <= 5; i++)
        {
            Questions.Add(_questionGenerator.Generate(difficulty, quizMode));
        }
        int _points = 0;
        var _time = Stopwatch.StartNew();
        foreach(var _question in Questions)
        {
            _userInteractor.DisplayMessage(_question.Text);
            if(_userInteractor.PromptForAnswer() == _question.Result)
            {
                _points++;
                _userInteractor.DisplayCorrect();
            }
            else { _userInteractor.DisplayIncorrect(_question.Result); }
        }
        _time.Stop();
        Time = (int)_time.Elapsed.TotalSeconds;
        Points = _points;
        _userInteractor.DisplayMessage("");
        _userInteractor.DisplayMessage($"Final result: {Points} points. Time: {Time} seconds");
    }
}
