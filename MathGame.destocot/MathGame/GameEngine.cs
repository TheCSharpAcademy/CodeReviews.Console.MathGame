using System.Diagnostics;

namespace MathGame;

internal class GameEngine
{
    internal static Stopwatch stopWatch = new();

    internal void RandomGame(string message)
    {
        Random random = new Random();

        var diffLevel = Validations.GetDifficulty($"{random.Next(1, 4)}");
        var diffModified = (DiffModifier)Enum.Parse(typeof(DiffModifier), diffLevel);
        var numOfQuestions = Validations.GetNumberOfQuestions($"{random.Next(1, 4)}");

        Helpers.StartGame(message);

        var score = 0;
        var idx = random.Next(0, 4);

        for (int i = 0; i < int.Parse(numOfQuestions); i++)
        {
            string[] opList = { "+", "-", "*", "/" };

            var num1 = random.Next(0, 9 + (int)diffModified);
            var num2 = random.Next(0, 9 + (int)diffModified);

            switch (opList[idx])
            {
                case "+":
                    score = Helpers.DisplayProblems(score, num1, num2, opList[idx], (num1, num2) => num1 + num2);
                    break;
                case "-":
                    score = Helpers.DisplayProblems(score, num1, num2, opList[idx], (num1, num2) => num1 - num2);
                    break;
                case "*":
                    score = Helpers.DisplayProblems(score, num1, num2, opList[idx], (num1, num2) => num1 * num2);
                    break;
                case "/":
                    int[] divisionNumbers = Helpers.GetDivisionNumbers((int)diffModified * 5);
                    num1 = divisionNumbers[0];
                    num2 = divisionNumbers[1];
                    score = Helpers.DisplayProblems(score, num1, num2, opList[idx], (num1, num2) => num1 / num2);
                    break;
            }
            idx = random.Next(0, 3);
        }
        Helpers.GameResults(message, diffLevel, numOfQuestions, score);
    }

    internal void DivisionGame(string message)
    {
        Helpers.DisplayDifficulties();
        var diffLevel = Console.ReadLine();
        diffLevel = Validations.GetDifficulty(diffLevel);
        var diffModified = (DiffModifier)Enum.Parse(typeof(DiffModifier), diffLevel);

        Helpers.DisplayQuestionsPrompt();
        var numOfQuestions = Console.ReadLine();
        numOfQuestions = Validations.GetNumberOfQuestions(numOfQuestions);

        Helpers.StartGame(message);

        int[] divisionNumbers = Helpers.GetDivisionNumbers((int)diffModified * 5);

        var score = 0;

        for (int i = 0; i < int.Parse(numOfQuestions); i++)
        {
            var num1 = divisionNumbers[0];
            var num2 = divisionNumbers[1];

            score = Helpers.DisplayProblems(score, num1, num2, "/", (num1, num2) => num1 / num2);

            divisionNumbers = Helpers.GetDivisionNumbers((int)diffModified * 5);
        }

        Helpers.GameResults(message, diffLevel, numOfQuestions, score);
    }

    internal void MultiplicationGame(string message)
    {
        Helpers.DisplayDifficulties();
        var diffLevel = Console.ReadLine();
        diffLevel = Validations.GetDifficulty(diffLevel);
        var diffModified = (DiffModifier)Enum.Parse(typeof(DiffModifier), diffLevel);

        Helpers.DisplayQuestionsPrompt();
        var numOfQuestions = Console.ReadLine();
        numOfQuestions = Validations.GetNumberOfQuestions(numOfQuestions);

        Helpers.StartGame(message);

        Random random = new Random();
        var score = 0;

        for (int i = 0; i < int.Parse(numOfQuestions); i++)
        {
            var num1 = random.Next(0, 9 + ((int)diffModified + 1));
            var num2 = random.Next(0, 9 + ((int)diffModified + 1));

            score = Helpers.DisplayProblems(score, num1, num2, "*", (num1, num2) => num1 * num2);
        }

        Helpers.GameResults(message, diffLevel, numOfQuestions, score);
    }

    internal void SubtractionGame(string message)
    {
        Helpers.DisplayDifficulties();
        var diffLevel = Console.ReadLine();
        diffLevel = Validations.GetDifficulty(diffLevel);
        var diffModified = (DiffModifier)Enum.Parse(typeof(DiffModifier), diffLevel);

        Helpers.DisplayQuestionsPrompt();
        var numOfQuestions = Console.ReadLine();
        numOfQuestions = Validations.GetNumberOfQuestions(numOfQuestions);

        Helpers.StartGame(message);

        Random random = new Random();
        var score = 0;

        for (int i = 0; i < int.Parse(numOfQuestions); i++)
        {
            var num1 = random.Next(0, 9 + ((int)diffModified * 5));
            var num2 = random.Next(0, 9 + ((int)diffModified * 5));

            score = Helpers.DisplayProblems(score, num1, num2, "-", (num1, num2) => num1 - num2);
        }
        Helpers.GameResults(message, diffLevel, numOfQuestions, score);
    }

    internal void AdditionGame(string message)
    {
        Helpers.DisplayDifficulties();
        var diffLevel = Console.ReadLine();
        diffLevel = Validations.GetDifficulty(diffLevel);
        var diffModified = (DiffModifier)Enum.Parse(typeof(DiffModifier), diffLevel);

        Helpers.DisplayQuestionsPrompt();
        var numOfQuestions = Console.ReadLine();
        numOfQuestions = Validations.GetNumberOfQuestions(numOfQuestions);

        Helpers.StartGame(message);

        Random random = new Random();
        var score = 0;

        for (int i = 0; i < int.Parse(numOfQuestions); i++)
        {
            var num1 = random.Next(0, 9 + ((int)diffModified * 5));
            var num2 = random.Next(0, 9 + ((int)diffModified * 5));

            score = Helpers.DisplayProblems(score, num1, num2, "+", (num1, num2) => num1 + num2);
        }
        Helpers.GameResults(message, diffLevel, numOfQuestions, score);
    }

    /* range of numbers for each operation modifier from 0-9 to 0-x, 
    where x is some multiple of 9 calculated from difficulty selection */
    enum DiffModifier
    {
        Easy = 0,
        Medium = 10,
        Hard = 20,
    };
}
