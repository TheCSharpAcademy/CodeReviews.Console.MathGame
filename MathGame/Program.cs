// The Math Game

using System.Diagnostics;

int sum;
int difference;
int product;
int quotient;

string? userGameChoice;
string[] gameOptions = { "1", "2", "3", "4", "5" };
string gameHistory = "";
int points = 0;

int gameNumber = 0;
string[] gameStats = { };

Stopwatch timer = new Stopwatch();
string time;

string? userDifficultyChoice;
string[] difficultyOptions = { "1", "2", "3" };

Console.WriteLine("\nWelcome to the Math Game!");

bool playAgain;

do
{
    string[] operators = { "+", "-", "*", "/", };
    int operatorsIndex;
    string randomOperator;
    points = 0;
    gameHistory = "";
    timer.Reset();
    playAgain = false;
    do
    {
        Console.WriteLine("\n1) Low 2) Medium 3) High");
        Console.WriteLine("Select difficulty level:");
        userDifficultyChoice = Console.ReadLine();
        if (!difficultyOptions.Contains(userDifficultyChoice))
        {
            Console.WriteLine("That is not a valid option. You must enter 1, 2, or 3.");
        }
    } while (!difficultyOptions.Contains(userDifficultyChoice));

    string? userMaxQuestionsStr;
    int userMaxQuestionsInt;
    bool validUserMaxQuestions = false;

    do
    {
        Console.WriteLine("Maximum number of questions:");
        userMaxQuestionsStr = Console.ReadLine();
        if (int.TryParse(userMaxQuestionsStr, out userMaxQuestionsInt))
        {
            if (userMaxQuestionsInt < 1 || userMaxQuestionsInt > 100)
            {
                Console.WriteLine("That is not a valid option. You must enter a number between 1 and 100.");
            }
            else
            {
                validUserMaxQuestions = true;
            }
        }
    } while (validUserMaxQuestions == false);

    do
    {
        Console.WriteLine("\n-------------------------------------");
        Console.WriteLine("1) Addition 2) Subtraction 3) Multiplication 4) Division 5) Random! (+, -, *, and /)");
        Console.WriteLine("Make a selection. Enter 1, 2, 3, 4, or 5:");
        userGameChoice = Console.ReadLine();
        if (!gameOptions.Contains(userGameChoice))
        {
            Console.WriteLine("That is not a valid option. You must enter 1, 2, 3, 4, or 5.");
        }
    } while (!gameOptions.Contains(userGameChoice));

    timer.Start();
    Console.WriteLine("Timer started...");

    int questionsAsked = 0;

    while (questionsAsked < userMaxQuestionsInt)
    {
        Random random = new Random();
        int num1 = 0;
        int num2 = 0;

        Random random2 = new Random();
        operatorsIndex = random2.Next(0, 4);
        randomOperator = operators[operatorsIndex];

        if (userDifficultyChoice == "1")
        {
            num1 = random.Next(11);
            num2 = random.Next(1, 11);
        }
        else if (userDifficultyChoice == "2")
        {
            num1 = random.Next(101);
            num2 = random.Next(1, 101);
        }
        else if (userDifficultyChoice == "3")
        {
            num1 = random.Next(1001);
            num2 = random.Next(1, 1001);
        }

        Console.WriteLine($"\nQuestion #{questionsAsked + 1} out of {userMaxQuestionsInt}:");

        switch (userGameChoice)
        {
            case "1":
                Console.WriteLine($"What is {num1} + {num2}?");
                break;

            case "2":
                Console.WriteLine($"What is {num1} - {num2}?");
                break;

            case "3":
                Console.WriteLine($"What is {num1} x {num2}?");
                break;

            case "4":
                while (num1 % num2 != 0)
                {
                    if (userDifficultyChoice == "1")
                    {
                        num1 = random.Next(11);
                        num2 = random.Next(1, 11);
                    }
                    else if (userDifficultyChoice == "2")
                    {
                        num1 = random.Next(101);
                        num2 = random.Next(1, 101);
                    }
                    else if (userDifficultyChoice == "3")
                    {
                        num1 = random.Next(1001);
                        num2 = random.Next(1, 1001);
                    }
                }
                Console.WriteLine($"What is {num1} / {num2}?");
                break;

            case "5":
                while ((randomOperator == "/") && (num1 % num2 != 0))
                {
                    if (userDifficultyChoice == "1")
                    {
                        num1 = random.Next(11);
                        num2 = random.Next(1, 11);
                    }
                    else if (userDifficultyChoice == "2")
                    {
                        num1 = random.Next(101);
                        num2 = random.Next(1, 101);
                    }
                    else if (userDifficultyChoice == "3")
                    {
                        num1 = random.Next(1001);
                        num2 = random.Next(1, 1001);
                    }
                }
                Console.WriteLine($"What is {num1} {randomOperator} {num2}?");
                break;
        }

        string? userAnswerStr;
        int userAnswerInt = 0;
        bool validUserAnswer = false;

        do
        {
            userAnswerStr = Console.ReadLine();
            if (userAnswerStr != null)
            {
                validUserAnswer = int.TryParse(userAnswerStr, out userAnswerInt);
                if (!validUserAnswer)
                {
                    Console.WriteLine("Invalid entry. Enter an integer.");
                }
            }
        } while (validUserAnswer == false);

        if (userGameChoice == "1" || randomOperator == "+")
        {
            sum = num1 + num2;
            if (sum == userAnswerInt)
            {
                Console.WriteLine("Congratulations. You answered correctly! +1 point");
                points++;
                gameHistory += $"{num1} + {num2} = {sum}...Answered correctly, +1 point\n";
            }
            else
            {
                Console.WriteLine($"Incorrect! The answer is {sum}.");
                gameHistory += $"{num1} + {num2} = {sum}...Answered incorrectly\n";
            }
        }
        else if (userGameChoice == "2" || randomOperator == "-")
        {
            difference = num1 - num2;
            if (difference == userAnswerInt)
            {
                Console.WriteLine("Congratulations. You answered correctly! +1 point");
                points++;
                gameHistory += $"{num1} - {num2} = {difference}...Answered correctly, +1 point\n";
            }
            else
            {
                Console.WriteLine($"Incorrect! The answer is {difference}.");
                gameHistory += $"{num1} - {num2} = {difference}...Answered incorrectly\n";
            }
        }
        else if (userGameChoice == "3" || randomOperator == "*")
        {
            product = num1 * num2;
            if (product == userAnswerInt)
            {
                Console.WriteLine("Congratulations. You answered correctly! +1 point");
                points++;
                gameHistory += $"{num1} * {num2} = {product}...Answered correctly, +1 point\n";
            }
            else
            {
                Console.WriteLine($"Incorrect! The answer is {product}.");
                gameHistory += $"{num1} * {num2} = {product}...Answered incorrectly\n";
            }
        }
        else if (userGameChoice == "4" || randomOperator == "/")
        {
            quotient = num1 / num2;
            if (quotient == userAnswerInt)
            {
                Console.WriteLine("Congratulations. You answered correctly! +1 point");
                points++;
                gameHistory += $"{num1} / {num2} = {quotient}...Answered correctly, +1 point\n";
            }
            else
            {
                Console.WriteLine($"Incorrect! The answer is {quotient}.");
                gameHistory += $"{num1} / {num2} = {quotient}...Answered incorrectly\n";
            }
        }
        questionsAsked++;

        if (questionsAsked == userMaxQuestionsInt)
        {
            timer.Stop();
            Console.WriteLine("\nPost-Game Report:");
            Console.WriteLine(gameHistory);
            Console.WriteLine($"Total Points: {points}");
            time = timer.Elapsed.ToString("mm\\:ss\\.ff");
            Console.WriteLine($"Time: {time}\n");
        }
    }

    gameNumber += 1;
    time = timer.Elapsed.ToString("mm\\:ss\\.ff");

    string[] singleGameStats = { $"Game {gameNumber}", $"Difficulty Level: {userDifficultyChoice}", $"Questions: {questionsAsked}", $"Total Points: {points}", $"Time: {time}" };
    gameStats = gameStats.Concat(singleGameStats).ToArray();

    string? userPlayAgainChoice;
    string[] playAgainOptions = { "1", "2", "3" };

    do
    {
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("1) Play Again 2) View Game History 3) Quit");
        Console.WriteLine("Make a selection. Enter 1, 2, or 3:");
        userPlayAgainChoice = Console.ReadLine();
        if (!playAgainOptions.Contains(userPlayAgainChoice))
        {
            Console.WriteLine("That is not a valid option. You must enter 1, 2, or 3.");
        }
        else if (userPlayAgainChoice == "1")
        {
            playAgain = true;
        }
        else if (userPlayAgainChoice == "2")
        {
            Console.WriteLine("\nYour Game History\n------------------");
            for (int i = 0; i < gameStats.Length; i += 5)
            {
                Console.WriteLine($"{gameStats[i + 0]}\n{gameStats[i + 1]}\n{gameStats[i + 2]}\n{gameStats[i + 3]}\n{gameStats[i + 4]}\n");
            }
        }
        else
        {
            Console.WriteLine("Thanks for playing! Goodbye!");
        }
    } while (!playAgainOptions.Contains(userPlayAgainChoice) || userPlayAgainChoice == "2");

} while (playAgain == true);