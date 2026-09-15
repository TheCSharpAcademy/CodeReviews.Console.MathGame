using Math_Game.Application;
using Math_Game.Tools;
using Tools;

namespace Math_Game;

internal class Program
{
    static void Main(string[] args)
    {
        IRandom _random = new RandomWrapper(new Random());
        MathQuizUserInteractor _userInteractor = new(new Validator(), new ConsoleUserInteractor());
        GameResults _gameResults = new();
        App app = new(_userInteractor, new Quiz(_userInteractor, new QuestionGenerator(_random)), _gameResults);

        app.Run();
        bool _isGameFinished = app.IsGameFinished;
        while (!_isGameFinished)
        {
            app = new App(_userInteractor, new Quiz(_userInteractor, new QuestionGenerator(_random)), _gameResults);
            app.Run();
            _isGameFinished = app.IsGameFinished;
        }
        _userInteractor.Quit();
    }
}
