using System.Reflection.Metadata.Ecma335;
using MathGame.src;
using MathGame.src.enums;

class Question
{
    private readonly char[] allowedSymbols = ['+', '-', '*', '/'];
    private int operand1;
    private int operand2;
    private char symbol;
    private static List<String> questions = [];
    private Gamelevel gameLevel = GameLevel.gameLevel;

    private void GenerateOperands()
    {
        switch (gameLevel)
        {
            case Gamelevel.Beginner:
                operand1 = Random.Shared.Next(1, 30);//similfy 
                operand2 = Random.Shared.Next(1, 10);
                break;
            case Gamelevel.Intermediate:
                operand1 = Random.Shared.Next(30, 70);
                operand2 = Random.Shared.Next(11, 20);
                break;
            case Gamelevel.Pro:
                operand1 = Random.Shared.Next(70, 100);
                operand2 = Random.Shared.Next(20, 30);
                break;
            default: break;
        }
    }

    public List<String> GetUserAnsweredQuestions()
    {
        return questions;
    }

    public String GenerateQuestion()
    {
        symbol = allowedSymbols[Random.Shared.Next(allowedSymbols.Length)];

        do
        {
            GenerateOperands();
        } while (symbol == '/' && operand1 % operand2 != 0);


        return $"{operand1} {symbol} {operand2} =";
    }

    public bool EvaluateAnswer(int userAnswer)
    {
        int answer = 0;
        switch (symbol)
        {
            case '+':
                answer = operand1 + operand2;
                break;
            case '-':
                answer = operand1 - operand2;
                break;
            case '*':
                answer = operand1 * operand2;
                break;
            case '/':
                answer = operand1 / operand2;
                break;
            default:
                answer = 0;
                break;
        }
        questions.Add($"{operand1} {symbol} {operand2} = " + userAnswer);

        if (userAnswer == answer) return true;

        return false;
    }

    public int QuestionsCount()
    {
        return GameLevel.gameLevel switch
        {
            Gamelevel.Beginner => 5,
            Gamelevel.Intermediate => 7,
            Gamelevel.Pro => 10,
            _ => 0
        };

    }
}