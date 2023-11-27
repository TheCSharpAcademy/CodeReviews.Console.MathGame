namespace Branch_Console;

internal class Helpers
{
    internal static DateTime GetDate()
    {
        return DateTime.UtcNow;
    }

    internal static int ConsoleWidth()
    {
        return Console.WindowWidth;
    }

    internal static string GetName()
    {
        var result = Console.ReadLine();
        while (string.IsNullOrEmpty(result))
        {
            Console.WriteLine("Name can't be empty");
            result = Console.ReadLine();
        }
        return result;
    }

    internal static List<int> GetOperands(Difficulty difficulty)
    {
        Random rnd = new();
        List<int> result = new();
        switch (difficulty)
        {
            case Difficulty.Easy:
                result.Add(rnd.Next(1, 9));
                result.Add(rnd.Next(1, 9));
                break;
            case Difficulty.Normal:
                result.Add(rnd.Next(-9, 9));
                result.Add(rnd.Next(-9, 9));
                break;
            case Difficulty.Hard:
                result.Add(rnd.Next(-19, 19));
                result.Add(rnd.Next(-19, 19));
                result.Add(rnd.Next(-19, 19));
                break;
        }
        return result;
    }

    internal static int? GetResult(OperationType mathOperation, List<int> Operands)
    {
        //the operands can have 2 or more operands the number of operations is ListCount - 1 
        //3 operands = 3 - 1 = 2 Operations
        //4 operands = 4 - 1 = 3 Operations and so forth
        // Because our game has constraints on the type of game (addition, subtration, etc) we wont have to worry with order of operations 
        int? result = null;
        switch (mathOperation)
        {
            case OperationType.Addition:
                result = Operands[0];
                for (int i = 1; i < Operands.Count; i++) // the first operand was already attributed we start here at 1
                {
                    result += Operands[i];
                }
                break;
            case OperationType.Subtration:
                result = Operands[0];
                for (int i = 1; i < Operands.Count; i++) // the first operand was already attributed we start here at 1
                {
                    result -= Operands[i];
                }
                break;
            case OperationType.Multiplication:
                result = Operands[0];
                for (int i = 1; i < Operands.Count; i++) // the first operand was already attributed we start here at 1
                {
                    result *= Operands[i];
                }
                break;
            case OperationType.Division:
                result = Operands[0];
                for (int i = 1; i < Operands.Count; i++) // the first operand was already attributed we start here at 1
                {
                    if (Operands[i] == 0 || result % Operands[i] != 0)
                        result = null;
                    else
                        result /= Operands[i];
                }
                break;
        }
        return result;
    }

    internal static int[] GetOperationBounds(Difficulty difficulty)
    {
        var resultUpperBound = 0;
        var resultLowerBound = 0;
        switch (difficulty)
        {
            case Difficulty.Easy:
                resultUpperBound = 20;
                resultLowerBound = 1;
                break;
            case Difficulty.Normal:
                resultUpperBound = 40;
                resultLowerBound = -40;
                break;
            case Difficulty.Hard:
                resultUpperBound = 80;
                resultLowerBound = -80;
                break;
        }
        return new int[] { resultLowerBound, resultUpperBound };
    }

    internal static string GetOperationSymbol(OperationType operationType)
    {
        string operationSymbol = "";
        operationSymbol = operationType switch
        {
            OperationType.Addition => " + ",
            OperationType.Subtration => " - ",
            OperationType.Multiplication => " * ",
            OperationType.Division => " / ",
            _ => "",
        };
        return operationSymbol;
    }

    internal static OperationType GetRandomGameType()
    {
        Random rnd = new Random();
        var toReturn = rnd.Next(1, 4) switch
        {
            1 => OperationType.Addition,
            2 => OperationType.Subtration,
            3 => OperationType.Multiplication,
            4 => OperationType.Division,
            _ => OperationType.Addition,
        };
        return toReturn;
    }

    internal static MathOperation GetOperation(OperationType? gameType, Difficulty difficulty)
    {
        int[] OperationResultBounds = Helpers.GetOperationBounds(difficulty);
        int? operationResult = null;
        List<int> operands = new();
        OperationType opType;
        if (gameType == null)
        {
            opType = Helpers.GetRandomGameType();
        }
        else
        {
            opType = (OperationType)gameType;
        }
        while (operationResult == null || operationResult < OperationResultBounds[0] || operationResult > OperationResultBounds[1])
        {
            operands = Helpers.GetOperands(difficulty);
            operationResult = Helpers.GetResult(opType, operands);
        }
        return new MathOperation() { Operator = opType, OperationDifficulty = difficulty, Operands = operands, OperationResult = (int)operationResult };
    }

    internal static string OperationTitle(OperationType operationType)
    {
        string operationName = "";
        operationName = operationType switch
        {
            OperationType.Addition => "Addition Game.",
            OperationType.Subtration => "Substraction game.",
            OperationType.Multiplication => "Multiplication game.",
            OperationType.Division => "Division game.",
            _ => "",
        };
        return operationName;
    }

    internal static int CalculateScore(Difficulty difficulty, int timerLeft)
    {
        int baseScore = 0;
        int timerBonus = 0;
        baseScore = difficulty switch
        {
            Difficulty.Easy => 1,
            Difficulty.Normal => 2,
            Difficulty.Hard => 3,
            _ => 0,
        };
        if (timerLeft >= 15)
        {
            timerBonus = 1;
        }
        return baseScore + timerBonus;
    }
}