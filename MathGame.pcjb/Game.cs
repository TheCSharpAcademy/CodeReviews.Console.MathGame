using MathGame.pcjb.Models;

internal class Game
{
    private GameType type = GameType.None;
    private GameDifficulty difficulty = GameDifficulty.Normal;
    private DateTime startedAt;
    private int presentedQuestions = 0;
    private readonly int maxQuestions = 3;
    private int score = 0;
    private readonly List<GameResult> history = new();

    internal void Run()
    {
        var state = GameState.Menu;
        do
        {
            state = state switch
            {
                GameState.Menu => Menu(),
                GameState.Difficulty => Difficulty(),
                GameState.NewGame => NewGame(),
                GameState.Question => Question(),
                GameState.Score => Score(),
                GameState.History => History(),
                GameState.Quit => Quit(),
                _ => GameState.Menu,
            };

        } while (state != GameState.Exit);
    }

    private GameState Menu()
    {
        var selection = Screen.ShowMenu(difficulty);
        switch (selection)
        {
            case 'A':
                type = GameType.Addition;
                return GameState.NewGame;
            case 'S':
                type = GameType.Subtraction;
                return GameState.NewGame;
            case 'M':
                type = GameType.Multiplication;
                return GameState.NewGame;
            case 'D':
                type = GameType.Division;
                return GameState.NewGame;
            case 'H':
                type = GameType.None;
                return GameState.History;
            case 'L':
                return GameState.Difficulty;
            case 'Q':
                type = GameType.None;
                return GameState.Quit;
            default:
                type = GameType.None;
                return GameState.Menu;
        }
    }

    private GameState NewGame()
    {
        presentedQuestions = 0;
        score = 0;
        startedAt = DateTime.Now;
        return GameState.Question;
    }

    private GameState Question()
    {
        presentedQuestions++;
        var question = MathQuestionFactory.CreateQuestion(type, difficulty);
        question.ActualAnswer = Screen.ShowQuestion(question);
        if (question.HasCorrrectAnswer())
        {
            score++;
        }
        Screen.ShowResult(question);
        if (presentedQuestions < maxQuestions)
        {
            return GameState.Question;
        }
        else
        {
            return GameState.Score;
        }
    }

    private GameState Score()
    {
        var duration = DateTime.Now.Subtract(startedAt);
        var result = new GameResult(type, difficulty, score, duration);
        history.Add(result);
        Screen.ShowScore(result);
        return GameState.Menu;
    }

    private GameState History()
    {
        Screen.ShowHistory(history);
        return GameState.Menu;
    }

    private GameState Difficulty()
    {
        var selection = Screen.ShowDifficultySelection();
        switch (selection)
        {
            case 'E':
                difficulty = GameDifficulty.Easy;
                return GameState.Menu;
            case 'N':
                difficulty = GameDifficulty.Normal;
                return GameState.Menu;
            case 'H':
                difficulty = GameDifficulty.Hard;
                return GameState.Menu;
            default:
                return GameState.Difficulty;
        }
    }

    private GameState Quit()
    {
        Screen.ShowQuit();
        return GameState.Exit;
    }
}