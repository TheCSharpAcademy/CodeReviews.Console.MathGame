using System.Diagnostics;
using MathGame.Mateusz_Platek.Questions;
using MathGame.Mateusz_Platek.Saves;

namespace MathGame.Mateusz_Platek;

public static class GameManager
{
    private static void GetAnswer(Question question)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        string? input = Console.ReadLine();
        stopwatch.Stop();
        if (int.TryParse(input, out int number))
        {
            SaveManager.AddSave(new Save(question, number, stopwatch.Elapsed));
            if (question.Result == number)
            {
                Console.WriteLine("Correct answer");
            }
            else
            {
                Console.WriteLine("Wrong answer");
            }
            Console.WriteLine($"Time: {stopwatch.Elapsed.Seconds}s:{stopwatch.Elapsed.Milliseconds}ms");
        }
        else
        {
            Console.WriteLine("Wrong input");
        }
    }

    private static void PlayRound()
    {
        int operation = Menu.GetOperation();
        switch (operation)
        {
            case 1:
                AdditionQuestion additionQuestion = QuestionManager.GetAdditionQuestion();
                Console.WriteLine($"{additionQuestion.Value1} + {additionQuestion.Value2} = ?");
                GetAnswer(additionQuestion);
                break;
            case 2:
                SubtractionQuestion subtractionQuestion = QuestionManager.GetSubtractionQuestion();
                Console.WriteLine($"{subtractionQuestion.Value1} - {subtractionQuestion.Value2} = ?");
                GetAnswer(subtractionQuestion);
                break;
            case 3:
                MultiplicationQuestion multiplicationQuestion = QuestionManager.GetMultiplicationQuestion();
                Console.WriteLine($"{multiplicationQuestion.Value1} * {multiplicationQuestion.Value2} = ?");
                GetAnswer(multiplicationQuestion);
                break;
            case 4:
                DivisionQuestion divisionQuestion = QuestionManager.GetDivisionQuestion();
                Console.WriteLine($"{divisionQuestion.Value1} / {divisionQuestion.Value2} = ?");
                GetAnswer(divisionQuestion);
                break;
            default:
                Console.WriteLine("Wrong input");
                break;
        }
    }

    private static void PlayRandomRound()
    {
        Random random = new Random();
        int number = random.Next(1, 5);
        switch (number)
        {
            case 1:
                AdditionQuestion additionQuestion = QuestionManager.GetAdditionQuestion();
                Console.WriteLine($"{additionQuestion.Value1} + {additionQuestion.Value2} = ?");
                GetAnswer(additionQuestion);
                break;
            case 2:
                SubtractionQuestion subtractionQuestion = QuestionManager.GetSubtractionQuestion();
                Console.WriteLine($"{subtractionQuestion.Value1} - {subtractionQuestion.Value2} = ?");
                GetAnswer(subtractionQuestion);
                break;
            case 3:
                MultiplicationQuestion multiplicationQuestion = QuestionManager.GetMultiplicationQuestion();
                Console.WriteLine($"{multiplicationQuestion.Value1} * {multiplicationQuestion.Value2} = ?");
                GetAnswer(multiplicationQuestion);
                break;
            case 4:
                DivisionQuestion divisionQuestion = QuestionManager.GetDivisionQuestion();
                Console.WriteLine($"{divisionQuestion.Value1} / {divisionQuestion.Value2} = ?");
                GetAnswer(divisionQuestion);
                break;
        }
    }

    private static void PlayManyRounds()
    {
        int roundType = Menu.GetRoundType();
        int numberOfQuestions = Menu.GetNumberOfQuestions();
        switch (roundType)
        {
            case 1:
                for (int i = 0; i < numberOfQuestions; i++)
                {
                    PlayRound();
                }
                break;
            case 2:
                for (int i = 0; i < numberOfQuestions; i++)
                {
                    PlayRandomRound();
                }
                break;
            default:
                Console.WriteLine("Wrong input");
                break;
        }
    }

    private static void SelectDifficultyLevel()
    {
        int difficultyLevel = Menu.GetDifficultyLevel();
        switch (difficultyLevel)
        {
            case 1:
                QuestionManager.InitLists(DifficultyLevel.Easy);
                Console.WriteLine("Selected difficulty level: Easy");
                break;
            case 2:
                QuestionManager.InitLists(DifficultyLevel.Medium);
                Console.WriteLine("Selected difficulty level: Medium");
                break;
            case 3:
                QuestionManager.InitLists(DifficultyLevel.Hard);
                Console.WriteLine("Selected difficulty level: Hard");
                break;
            default:
                Console.WriteLine("Wrong input");
                break;
        }
    }

    public static void RunGame()
    {
        bool exit = false;
        while (!exit)
        {
            int option = Menu.GetOption();
            switch (option)
            {
                case 1:
                    PlayRound();
                    break;
                case 2:
                    PlayRandomRound();
                    break;
                case 3:
                    PlayManyRounds();
                    break;
                case 4:
                    SaveManager.ShowSaves();
                    break;
                case 5:
                    SelectDifficultyLevel();
                    break;
                case 6:
                    exit = true;
                    Console.WriteLine("Goodbye");
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    break;
            }
        }
    }
}