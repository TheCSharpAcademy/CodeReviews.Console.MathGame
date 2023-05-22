using MathGameLibrary.Data;

namespace MathGameLibrary.Logic;
public class Game
{
    public Operator GameType { get; set; }
    public Difficulty GameDifficulty { get; set; }
    public TimeSpan GameTime { get; set; }
    public int NumberOfQuestions { get; set; }
    public int CorrectAnswers { get; set; }
    public int Number1 { get; private set; }
    public int Number2 { get; private set; }
    public char OperatorSymbol { get; private set; }
    public int IntRange
    {
        get
        {
            return GameDifficulty switch
            {
                Difficulty.Easy => 10,
                Difficulty.Normal => 100,
                Difficulty.Hard => 200,
                _ => 100
            };
        }
            
    }
    public double Score 
    {
        get 
        {
            return (double)CorrectAnswers / NumberOfQuestions;

        }
    }

    public Game()
    {
        CorrectAnswers = 0;
        
    }

    public string GenerateProblem()
    {
        Random random = new();
        Number1 = random.Next(IntRange) + 1;
        Number2 = random.Next(IntRange) + 1;
        OperatorSymbol = GetSymbol();

        if (GameType == Operator.Divide)
        {
            while (Number1 % Number2 != 0)
            {
                Number1 = random.Next(IntRange) + 1;
                Number2 = random.Next(IntRange) + 1;
            }
        }
        return $"{Number1} {OperatorSymbol} {Number2} = ";
    }

    public bool CheckGuess(int guessNumber)
    {
        bool isCorrect = false;
        if (guessNumber == GetAnswer())
        {
            isCorrect = true;
            CorrectAnswers++;
        }
        return isCorrect;
    }

    public int GetAnswer()
    {
        return OperatorSymbol switch
        {
            '-' => Number1 - Number2,
            '*' => Number1 * Number2,
            '/' => Number1 / Number2,
            _ => Number1 + Number2,
        };
    }

    private char GetSymbol()
    {
        return GameType switch
        {
            Operator.Subtract => '-',
            Operator.Multiply => '*',
            Operator.Divide => '/',
            Operator.Random => GetRandomSymbol(),
            _ => '+'
        };
    }

    private static char GetRandomSymbol()
    {
        Random rand = new();
        int operation = rand.Next(4);
        return operation switch 
        {
            0 => '+',
            1 => '-',
            2 => '*',
            _ => '/',
        };

    }
}
