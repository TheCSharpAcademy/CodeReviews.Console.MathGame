using Spectre.Console;

namespace MathGame.Louis_dub.Calculation;

internal class RandomCalculation : IBaseCalculation
{
    public static int RandomOperation(int mode)
    {
        int score = 0;
        Func<int, int>[] operations = {
            AdditionCalculation.Sum, SubtractionCalculation.Sub, MultiplicationCalculation.Mul, DivisionCalculation.Div
        };
        Random op = new();

        for (int i = 0; i < 5; i++)
            score += operations[op.Next(0, 4)](mode);
        return score;
    }
    public int EasyMode()
    {
        int score = RandomOperation(10);
        string strScore = $"{score} / 5";

        var newOperation = new Operation(DataBase.Operations.Count + 1, "Randokm", "Easy", strScore);
        DataBase.Operations.Add(newOperation);
        AnsiConsole.Markup($"Your score : [bold]{strScore}[/]\n");
        return score;
    }

    public int MediumMode()
    {
        int score = RandomOperation(100);
        string strScore = $"{score} / 5";

        var newOperation = new Operation(DataBase.Operations.Count + 1, "Randokm", "Medium", strScore);
        DataBase.Operations.Add(newOperation);
        AnsiConsole.Markup($"Your score : [bold]{strScore}[/]\n");
        return score;
    }

    public int HardMode()
    {
        int score = RandomOperation(1000);
        string strScore = $"{score} / 5";

        var newOperation = new Operation(DataBase.Operations.Count + 1, "Randokm", "Hard", strScore);
        DataBase.Operations.Add(newOperation);
        AnsiConsole.Markup($"Your score : [bold]{strScore}[/]\n");
        return score;
    }
}