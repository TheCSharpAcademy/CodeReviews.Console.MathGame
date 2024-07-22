using System;
using System.Diagnostics;
using MathGame;

public enum DifficultyLevel
{
    Easy = 45,
    Medium = 30,
    Hard = 15
}

class Program
{
    static async Task Main()
    {
        GameLogic gameLogic = new();
        DifficultyLevel difficulty = DifficultyLevel.Easy;
        Random rnd = new();
        int firstNum;
        int secondNum;
        int score = 0;
        bool gameOver = false;

        Console.WriteLine("Welcome to the Math Game!");

        while (!gameOver)
        {
            firstNum = rnd.Next(1, 101);
            secondNum = rnd.Next(1, 101);

            Console.WriteLine("\n");
            Console.WriteLine($"Difficulty: {difficulty}");
            Console.WriteLine($"Current score: {score}");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Random Mode");
            Console.WriteLine("6. Change Difficulty");
            Console.WriteLine("7. View History");
            Console.WriteLine("8. Exit");

            Console.Write("Enter your choice: ");

            try {
                int choice = int.Parse(Console.ReadLine());
    
                switch (choice)
                {
                    case 1:
                        score = await GameSelection(firstNum, secondNum, '+', gameLogic, difficulty, score);
                        break;
                    
                    case 2:
                        score = await GameSelection(firstNum, secondNum, '-', gameLogic, difficulty, score);
                        break;

                    case 3:
                        score = await GameSelection(firstNum, secondNum, '*', gameLogic, difficulty, score);
                        break;

                    case 4:
                        while (firstNum % secondNum != 0)
                        {
                            firstNum = rnd.Next(1, 101);
                            secondNum = rnd.Next(1, 101);
                        }
                        
                        score = await GameSelection(firstNum, secondNum, '/', gameLogic, difficulty, score);
                        break;

                    case 5:
                        int numberOfQuestions = 1;
                        Console.WriteLine("Please enter the number of questions you would like to attempt:");

                        while (!int.TryParse(Console.ReadLine(), out numberOfQuestions))
                        {
                            Console.WriteLine("Please enter the number of questions you want to attempt as an integer number");
                        }

                        while (numberOfQuestions > 0)
                        {
                            int randomOperation = rnd.Next(1, 5);

                            switch (randomOperation)
                            {
                                case 1:
                                    firstNum = rnd.Next(1, 101);
                                    secondNum = rnd.Next(1, 101);
                                    score = await GameSelection(firstNum, secondNum, '+', gameLogic, difficulty, score);
                                    break;
                                case 2:
                                    firstNum = rnd.Next(1, 101);
                                    secondNum = rnd.Next(1, 101);
                                    score = await GameSelection(firstNum, secondNum, '-', gameLogic, difficulty, score);
                                    break;
                                case 3:
                                    firstNum = rnd.Next(1, 101);
                                    secondNum = rnd.Next(1, 101);
                                    score = await GameSelection(firstNum, secondNum, '*', gameLogic, difficulty, score);
                                    break;
                                default:
                                    while (firstNum % secondNum != 0)
                                    {
                                        firstNum = rnd.Next(1, 101);
                                        secondNum = rnd.Next(1, 101);
                                    }
                                    
                                    score = await GameSelection(firstNum, secondNum, '/', gameLogic, difficulty, score);
                                    break;
                            }
                            numberOfQuestions--;
                            Console.WriteLine($"Questions remaining: {numberOfQuestions}");
                        }

                        Console.WriteLine("All questions complete!");

                        break;

                    case 6:
                        difficulty = ChangeDifficulty();
                        Console.WriteLine($"Difficulty changed to {difficulty}");
                        break;

                    case 7:
                        gameLogic.GameHistory.ForEach(Console.WriteLine);
                        break;

                    case 8:
                        Console.WriteLine($"Thanks for playing! Your final score is {score}");
                        gameOver = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } catch (FormatException)
            {
                Console.WriteLine("Invalid input, please try again.");
            }
        }
    }

    static int ValidateResult(int result, int userAnswer, int score)
    {
        if (result == userAnswer)
        {
            Console.WriteLine("Correct! You earned a point!");
            score++;
        }
        else
        {
            Console.WriteLine($"Incorrect! The correct answer is {result}");
        }

        return score;
    }

    static async Task<int> GameSelection(int firstNum, int secondNum, char operation, GameLogic gameLogic, DifficultyLevel difficulty, int score)
    {
        int result = gameLogic.MathOperation(firstNum, secondNum, operation);

        Console.WriteLine($"What is {firstNum} {operation} {secondNum}?");
        try 
        {
            int userAnswer = await GetAnswer(difficulty);
            score = ValidateResult(result, userAnswer, score);
            return score;
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Integers only.");

        }
        catch (NullReferenceException)
        {
            Console.WriteLine($"Times up! The correct answer is {result}");
        }

        return score;
    }

    static async Task<int> GetAnswer(DifficultyLevel difficulty)
    {
        int answer = 0;
        bool validInput = false;
        DateTime endTime = DateTime.Now.AddSeconds((int)difficulty);
        Stopwatch timer = new();
        
        while (!validInput && DateTime.Now < endTime)
        {
            timer.Start();
            if (Console.KeyAvailable)
            {
                try
                {
                    string input = Console.ReadLine();
                    answer = int.Parse(input);
                    timer.Stop();
                    TimeSpan ts = timer.Elapsed;
                    Console.WriteLine($"Time taken: {ts.Seconds} seconds");
                    validInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                }
            }
            await Task.Delay(100);
        }

        return answer;
    }


    static DifficultyLevel ChangeDifficulty()
    {
        Console.WriteLine("Select difficulty level:");
        Console.WriteLine("1. Easy");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Hard");

        try
        {
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    return DifficultyLevel.Easy;
                case 2:
                    return DifficultyLevel.Medium;
                case 3:
                    return DifficultyLevel.Hard;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    return DifficultyLevel.Easy;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please try again.");
            return DifficultyLevel.Easy;
        }
    }
}

