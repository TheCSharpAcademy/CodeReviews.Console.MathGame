using Spectre.Console;

namespace Entities;

public class Game
{
    public int Score {get; private set;}
    private readonly IOperationProvider _operation;
    private readonly GameSettings _gameSettings;
    private readonly IGameTimer _timer;
    private readonly GameMode _mode;
    private readonly Random _rand;
    public Game(IOperationProvider operation, DifficultyLevel difficultyLevel, IGameTimer timer, GameMode gameMode, Random random)
    {
        _operation = operation;
        _mode = gameMode;
        _gameSettings = new GameSettings(difficultyLevel);
        _timer = timer;
        _rand = random;
    }
    public GameResult Start()
    {
        int questionCount = 0;
        AnsiConsole.MarkupLine($"[green]Game Started![/]");

        _timer.Start();

        while(questionCount < _gameSettings.QuestionCount)
        {
            Console.Clear();
            AnsiConsole.Markup($"================== \nScore: {Score} \n==================\n");
            AskQuestion(_rand);
            questionCount++;
        }

        var duration = _timer.Stop();

        Console.Clear();
        AnsiConsole.MarkupLine($"You got {Score}/{_gameSettings.QuestionCount} questions correct! \n"
        + "Press any key to return to the Main menu...");
        Console.ReadLine();
        
        return new GameResult(Score, _operation.DisplayName , _gameSettings.DifficultyLevel, duration);
    }

   
    public void AskQuestion(Random rand)
    {
       
        var question = GetQuestion(rand);

        int a = question.FirstNumber;
        int b = question.SecondNumber;
        string symbol = question.Symbol;

        var answer = AnsiConsole
                    .Ask<int>("What is the solution to this math problem?"
                                + $"\n{a} {symbol} {b} =");

        if(SubmitAnswer(answer, question.Answer))
        {
            AnsiConsole.MarkupLine($"That is correct! {a} {symbol} {b} = [green]{question.Answer}[/] \n Press any key to continue...");
            Console.ReadKey();
        }
        else
        {
            AnsiConsole.MarkupLine($"That is incorrect! {a} {symbol} {b} = {question.Answer} \n Press any key to continue...");
            Console.ReadKey();
        }
    }

    public MathQuestion GetQuestion(Random rand)
    {
        return new MathQuestion(_operation.GetOperation(), rand, _gameSettings);
    }

    public bool SubmitAnswer(int answer, int calculatedAnswer)
    {
        bool isCorrect = answer == calculatedAnswer;
        if(isCorrect)
        {
            Score++;
        }
        return isCorrect;
    }
}

