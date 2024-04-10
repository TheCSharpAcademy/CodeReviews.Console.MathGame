using MathGame.Models;


namespace MathGame;

internal partial class GameEngine
{
    private const int GameLength = 5;
    private const int FinalScoreMultiplier = 10;
    Helpers util = new();

    private (int LowerBound, int UpperBound) GetNumberBounds(QuestionType questionType, DifficultyLevel difficultyLevel)
    {
        int lowerBound = 1;
        int upperBound = 10;

        switch (difficultyLevel)
        {
            case DifficultyLevel.Easy:
                upperBound = questionType == QuestionType.Multiplication ? 10 : 10;
                break;
            case DifficultyLevel.Medium:
                upperBound = questionType == QuestionType.Multiplication ? 15 : 20;
                break;
            case DifficultyLevel.Hard:
                upperBound = questionType == QuestionType.Multiplication ? 25 : 50;
                break;
            case DifficultyLevel.Insane:
                upperBound = questionType == QuestionType.Multiplication ? 50 : 100;
                break;
        }

        return (lowerBound, upperBound);
    }
    private string GetOperationSymbol(QuestionType questionType) => questionType switch
    {
        QuestionType.Addition => "+",
        QuestionType.Subtraction => "-",
        QuestionType.Multiplication => "*",
        QuestionType.Division => "/",
        _ => throw new ArgumentException("Invalid GameType"),
    };
    private int CalculateCorrectResult(QuestionType questionType, int firstNumber, int secondNumber) => questionType switch
    {
        QuestionType.Addition => firstNumber + secondNumber,
        QuestionType.Subtraction => firstNumber - secondNumber,
        QuestionType.Multiplication => firstNumber * secondNumber,
        QuestionType.Division => firstNumber / secondNumber,
        _ => throw new ArgumentException("Invalid GameType"),
    };
    public Question GenerateQuestion(QuestionType questionType, DifficultyLevel difficultyLevel)
    {
        var bounds = GetNumberBounds(questionType, difficultyLevel);
        var numbers = util.GetNumbers(questionType, bounds.LowerBound, bounds.UpperBound);
        int firstNumber = numbers[0];
        int secondNumber = numbers[1];
        string operationSymbol = GetOperationSymbol(questionType);
        int correctAnswer = CalculateCorrectResult(questionType, firstNumber, secondNumber);

        return new Question
        {
            FirstNumber = firstNumber,
            SecondNumber = secondNumber,
            OperationSymbol = operationSymbol,
            CorrectAnswer = correctAnswer
        };
    }
    public bool ProcessAnswer(Question question, string userAnswer)
    {
        userAnswer = Helpers.ValidateResult(userAnswer);
        return int.TryParse(userAnswer, out int parsedAnswer) && parsedAnswer == question.CorrectAnswer;
    }
    internal MiniGame RunFixedLengthMode(QuestionType questionType)
    {
        DifficultyLevel difficultyLevel = util.PromptDifficultyLevel();
        MiniGame game = new MiniGame()
        {
            Date = DateTime.Now,
            GameType = GameType.Standard,
            QuestionType = questionType,
            DifficultyLevel = difficultyLevel,
            Score = 0
        };

        int questionsCorrect = 0;
        string menuTitle = $"{game.QuestionType} Quiz";

        for (int i = 0; i < GameLength; i++)
        {
            Question question = GenerateQuestion(game.QuestionType, game.DifficultyLevel);
            Console.Clear();
            Menu.PrintInnerGameMenu($"{game.QuestionType} Quiz");

            Console.WriteLine($"{question.FirstNumber} {question.OperationSymbol} {question.SecondNumber} = ?");
            var userAnswer = Console.ReadLine();
            string validatedInput = Helpers.ValidateResult(userAnswer);
            bool correctAnswer = ProcessAnswer(question, validatedInput);

            if (correctAnswer)
            {
                Console.WriteLine("Correct!");
                questionsCorrect++;
            }
            else
            {
                Console.WriteLine("Incorrect.");
            }

            if (i < GameLength) Menu.PrintQuestionGenerationPrompt(); // Pause between questions
        }

        game.Score = questionsCorrect * FinalScoreMultiplier;
        Menu.PrintEndInnerGameScreen(menuTitle, game.Score);
        return game;
    }
    internal MiniGame RunEndlessMode()
    {
        DifficultyLevel difficultyLevel = util.PromptDifficultyLevel();
        MiniGame game = new MiniGame()
        {
            Date = DateTime.Now,
            GameType = GameType.Survival,
            DifficultyLevel = difficultyLevel,
            Score = 0
        };

        string menuTitle = $"{game.GameType} Quiz";
        QuestionType[] questionTypes = { QuestionType.Addition, QuestionType.Subtraction, QuestionType.Multiplication, QuestionType.Division };
        bool continuePlaying = true;
        int questionsCorrect = 0;

        while (continuePlaying)
        {
            QuestionType randomQuestionType = questionTypes[new Random().Next(questionTypes.Length)];
            Question question = GenerateQuestion(randomQuestionType, game.DifficultyLevel);

            Console.Clear();
            Menu.PrintInnerGameMenu(menuTitle);

            Console.WriteLine($"{question.FirstNumber} {question.OperationSymbol} {question.SecondNumber} = ?");
            var userAnswer = Console.ReadLine();
            string validatedInput = Helpers.ValidateResult(userAnswer);
            bool correctAnswer = ProcessAnswer(question, validatedInput);

            if (correctAnswer)
            {
                Console.WriteLine("Correct!");
                questionsCorrect++;
                Menu.PrintQuestionGenerationPrompt();
            }
            else
            {
                Console.WriteLine("Incorrect.");
                Console.WriteLine("Game Over! Press any key to continue.");
                Console.ReadKey();
                break;
            }
        }

        game.Score = questionsCorrect * FinalScoreMultiplier;
        Menu.PrintEndInnerGameScreen(menuTitle, game.Score);

        return game;
    }

} 
