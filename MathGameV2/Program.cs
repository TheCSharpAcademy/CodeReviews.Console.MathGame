// The Math Game V2

using System.Diagnostics;

string? userDifficultyChoice;
int questionsAsked = 0;
int userMaxQuestionsInt;
string? userGameChoice;
int num1 = 0;
int num2 = 0;
Random random = new Random();
string randomOperator;
int userAnswerInt = 0;
string gameHistory = "";
int points = 0;
Stopwatch timer = new Stopwatch();
int gameNumber = 0;
string time;
string[] gameStats = { };
bool playAgain;

// With this function, the user will be prompted and will set the difficulty level:
void UserSetDifficulty()
{
    string[] difficultyOptions = { "1", "2", "3" };
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
}

// With this function, the user will be prompted and will set the maximum number of questions to be asked:
void UserSetMaxQuestions()
{
    string? userMaxQuestionsStr;
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
}

// With this function, the user will be asked to select which type of questions they want:
void UserSetGame()
{
    string[] gameOptions = { "1", "2", "3", "4", "5" };
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
}

// With this function, the timer is started:
void StartTimer()
{
    timer.Start();
    Console.WriteLine("Timer started...");
}

// With this function, the random numbers are generated based on the difficulty level earlier set by the user:
void SetRandomOperands()
{

    string[] operators = { "+", "-", "*", "/", };
    int operatorsIndex;

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
}

// With this function, the question with the correct operator and number of digits will be printed to the screen:
void PrintQuestion()
{
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
}

// With this function, the user is providing an answer to the question:
void GetUserAnswer()
{
    string? userAnswerStr;
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
}

// With this function, the user's answer is checked and, if correct, a point is awarded:
void CheckUserAnswer()
{
    int sum;
    int difference;
    int product;
    int quotient;
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
}

// With this function, the post-game report will be printed to the screen:
void PrintPostGameReport()
{
    timer.Stop();
    Console.WriteLine("\nPost-Game Report:");
    Console.WriteLine(gameHistory);
    Console.WriteLine($"Total Points: {points}");
    time = timer.Elapsed.ToString("mm\\:ss\\.ff");
    Console.WriteLine($"Time: {time}\n");
}

// With this function, the stats for the game are collected:
void CollectGameStats()
{
    time = timer.Elapsed.ToString("mm\\:ss\\.ff");

    string[] singleGameStats = { $"Game {gameNumber}", $"Difficulty Level: {userDifficultyChoice}", $"Questions: {questionsAsked}", $"Total Points: {points}", $"Time: {time}" };
    gameStats = gameStats.Concat(singleGameStats).ToArray();
}

// With this function, the user will choose whether to play again, view game history, or quit:
void UserSetPlayAgain()
{
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
}

// Gameplay:

Console.WriteLine("\nWelcome to the Math Game!");
do
{
    playAgain = false;
    points = 0;
    gameHistory = "";
    timer.Reset();

    UserSetDifficulty();
    UserSetMaxQuestions();
    UserSetGame();
    StartTimer();

    questionsAsked = 0;

    while (questionsAsked < userMaxQuestionsInt)
    {
        SetRandomOperands();

        Console.WriteLine($"\nQuestion #{questionsAsked + 1} out of {userMaxQuestionsInt}:");

        PrintQuestion();
        GetUserAnswer();
        CheckUserAnswer();

        questionsAsked++;

        if (questionsAsked == userMaxQuestionsInt)
        {
            PrintPostGameReport();
        }
    }

    gameNumber += 1;

    CollectGameStats();
    UserSetPlayAgain();

} while (playAgain == true);
