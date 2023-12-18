using MathGameLib;
using MathGameLib.Enums;

Console.WriteLine("****** Welcome To Math Game ******");
Console.Write("Please Enter your Name >> ");
Player player = new Player();
player.Name = Console.ReadLine();



player.Score = 0;
player.HighScore = 0;
MathGame game = new MathGame();
Console.Clear();

Console.Write("Please Enter The Question count >> ");
game.QuestionCount = int.Parse(Console.ReadLine().Trim());

string playAgain = "";
Console.Clear();
Console.Write("please Select Game Difficulty (easy,medium,hard,extreme) >>");
string difficulty = Console.ReadLine().ToLower().Trim();
if (difficulty == "easy")
{
    game.Difficulty = DIFFICULTY.EASY;
}
else if (difficulty == "medium")
{
    game.Difficulty = DIFFICULTY.MEDIUM;
}
else if (difficulty == "hard")
{
    game.Difficulty = DIFFICULTY.HARD;
}
else if (difficulty == "extreme")
{
    game.Difficulty = DIFFICULTY.EXTREME;
}
else
{
    Console.WriteLine("Incorrect Difficulty...");
    Thread.Sleep(1000);
}
Console.Clear();
SimulateDelay(3);
do
{
    Console.Clear();

    PrintMenu();
    Console.Write("please Select Game Mode >>");
    string selectedMode = Console.ReadLine().ToLower().Trim();
    Console.Clear();


    switch (selectedMode)
    {
        case "a":
            game.Mode = MODE.ADDITION;
            break;
        case "s":
            game.Mode = MODE.SUBTRACTION;
            break;
        case "m":
            game.Mode = MODE.MULTIPLICATION;
            break;
        case "d":
            game.Mode = MODE.DIVISION;
            break;
        case "r":
            game.Mode = MODE.RONDOM;
            break;
        case "q":
            QuitTheGame();
            break;
        default:
            Console.WriteLine("Incorrect Choice");
            Thread.Sleep(1000);
            continue;
    }
    play();
    Console.Write("Do you want to play again? (y/n)>>");
    playAgain = Console.ReadLine().ToLower().Trim();

    if (playAgain == "n" || playAgain == "no")
    {
        Console.Clear();
        DisplayResultHistory();
    }

} while (playAgain != "n" && playAgain != "no");

void DisplayResultHistory()
{
    Console.WriteLine("***************************************** Result History ***************************************");
    Console.WriteLine($"{"EXPRESSION",-15}{"ANSWER",-11}{"YOUR-ANSWER",-16}{"ANSWER-STATUS",-18}{"Score",-5}{"DIFFICULTY",15}{"DURATION",15}");
    Console.WriteLine("************************************************************************************************");
    int totalScore = 0;
    float totalDuration = 0;
    Console.WriteLine("------------------------------------------------------------------------------------------------");


    foreach (var entry in game.MathExpressions)
    {
        totalDuration += entry.answerDuration;
        int score = 0;

        if (entry.Operation == '+')
        {

            string answerStatus = entry.FirstOperand + entry.SecondOperand == entry.Answer ? "Correct" : "Incorrect";
            int correctAnswer = entry.FirstOperand + entry.SecondOperand;

            if (answerStatus == "Correct")
            {
                score = 1;
                totalScore++;
            }
            Console.WriteLine($" {entry.FirstOperand} {entry.Operation} {entry.SecondOperand,-12}{correctAnswer,-12}{entry.Answer,-14}{answerStatus,10}{score,10}{entry.Difficulty,12}{(entry.answerDuration / 1000 + "." + entry.answerDuration % 1000) + "s",19}");

        }
        else if (entry.Operation == '-')
        {

            string answerStatus = entry.FirstOperand - entry.SecondOperand == entry.Answer ? "Correct" : "Incorrect";
            int correctAnswer = entry.FirstOperand - entry.SecondOperand;

            if (answerStatus == "Correct")
            {
                score = 1;
                totalScore++;
            }
            Console.WriteLine($" {entry.FirstOperand} {entry.Operation} {entry.SecondOperand,-12}{correctAnswer,-12}{entry.Answer,-14}{answerStatus,10}{score,10}{entry.Difficulty,12}{(entry.answerDuration / 1000 + "." + entry.answerDuration % 1000) + "s",19}");

        }
        else if (entry.Operation == '*')
        {

            string answerStatus = entry.FirstOperand * entry.SecondOperand == entry.Answer ? "Correct" : "Incorrect";
            int correctAnswer = entry.FirstOperand * entry.SecondOperand;

            if (answerStatus == "Correct")
            {
                score = 1;
                totalScore++;
            }
            Console.WriteLine($" {entry.FirstOperand} {entry.Operation} {entry.SecondOperand,-12}{correctAnswer,-12}{entry.Answer,-14}{answerStatus,10}{score,10}{entry.Difficulty,12}{(entry.answerDuration / 1000 + "." + entry.answerDuration % 1000) + "s",19}");

        }
        else if (entry.Operation == '/')
        {

            string answerStatus = entry.FirstOperand / entry.SecondOperand == entry.Answer ? "Correct" : "Incorrect";
            int correctAnswer = entry.FirstOperand / entry.SecondOperand;

            if (answerStatus == "Correct")
            {
                score = 1;
                totalScore++;
            }
            Console.WriteLine($" {entry.FirstOperand} {entry.Operation} {entry.SecondOperand,-12}{correctAnswer,-12}{entry.Answer,-14}{answerStatus,10}{score,10}{entry.Difficulty,12}{(entry.answerDuration / 1000 + "." + entry.answerDuration % 1000) + "s",19}");

        }
        Console.WriteLine("------------------------------------------------------------------------------------------------");
    }
    Console.WriteLine("************************************************************************************************");

    Console.WriteLine($"Player Name {player.Name,-10}, Total Score: {totalScore,10}, Total Time: {totalDuration/1000} s");
    Console.WriteLine("Press Any Key to Exit");
    Console.ReadLine();

}

void play()
{
    for (int i = 0; i < game.QuestionCount; i++)
    {
        MathExpression q = game.getQuestion();
        displayDashboard(q);
        var watch = new System.Diagnostics.Stopwatch();

        watch.Start();

        Console.Write($"{q.FirstOperand} {q.Operation} {q.SecondOperand} = ");
        q.Answer = int.Parse(Console.ReadLine().Trim());
        watch.Stop();
        q.answerDuration = watch.ElapsedMilliseconds;


        Console.Clear();
        displayDashboard(q);
        Thread.Sleep(1000);
        Console.Clear();


    }
    player.Score = 0;
}

void QuitTheGame()
{
    Console.WriteLine("Quitting the Game...");
    Environment.Exit(0);
}

void displayDashboard(MathExpression expression)
{

    string? answerStatus = "";
    string currentMode;
    switch (game.Mode)
    {
        case MODE.ADDITION:
            currentMode = "Addition";
            break;
        case MODE.SUBTRACTION:
            currentMode = "Subtraction";
            break;
        case MODE.MULTIPLICATION:
            currentMode = "Multiplication";
            break;
        case MODE.DIVISION:
            currentMode = "Division";
            break;
        default:
            currentMode = "Random";
            break;

    }
    switch (game.Mode)
    {
        case MODE.ADDITION:
            if (expression.Answer != null)
            {
                answerStatus = expression.FirstOperand + expression.SecondOperand == expression.Answer ? "Correct" : "Incorrect";
            }
            break;
        case MODE.SUBTRACTION:
            if (expression.Answer != null)
            {
                answerStatus = expression.FirstOperand - expression.SecondOperand == expression.Answer ? "Correct" : "Incorrect";
            }
            break;
        case MODE.MULTIPLICATION:
            if (expression.Answer != null)
            {
                answerStatus = expression.FirstOperand * expression.SecondOperand == expression.Answer ? "Correct" : "Incorrect";
            }
            break;
        case MODE.DIVISION:
            if (expression.Answer != null)
            {
                answerStatus = expression.FirstOperand / expression.SecondOperand == expression.Answer ? "Correct" : "Incorrect";
            }
            break;
        default:
            if (expression.Operation == '+')
            {
                if (expression.Answer != null)
                {
                    answerStatus = expression.FirstOperand + expression.SecondOperand == expression.Answer ? "Correct" : "Incorrect";
                }
            }
            else if (expression.Operation == '-')
            {
                if (expression.Answer != null)
                {
                    answerStatus = expression.FirstOperand - expression.SecondOperand == expression.Answer ? "Correct" : "Incorrect";
                }

            }
            else if (expression.Operation == '*')
            {
                if (expression.Answer != null)
                {
                    answerStatus = expression.FirstOperand * expression.SecondOperand == expression.Answer ? "Correct" : "Incorrect";
                }
            }
            else
            {
                if (expression.Answer != null)
                {
                    answerStatus = expression.FirstOperand / expression.SecondOperand == expression.Answer ? "Correct" : "Incorrect";
                }

            }
            break;
    }
    if (answerStatus == "Correct")
    {
        player.Score++;
    }

    Console.WriteLine("*************************************************");
    Console.WriteLine($"****************  {currentMode} Mode  ****************");
    Console.WriteLine("*************************************************");
    Console.WriteLine($"Name: {player.Name,-10} Score: {player.Score}/{game.QuestionCount}\tAnswer:{answerStatus} ");
    Console.WriteLine("*************************************************");

}


void PrintMenu()
{
    Console.WriteLine("A - Addition");
    Console.WriteLine("S - Subtraction");
    Console.WriteLine("M - Multiplication");
    Console.WriteLine("D - Division");
    Console.WriteLine("R - Random");
    Console.WriteLine("Q - Quit The Game");
}
void SimulateDelay(int delayInSec)
{
    for (int i = delayInSec; i > 0; i--)
    {
        Console.Write($"Welcome {player.Name} the game starts in {i} Seconds");
        Thread.Sleep(1000);
        Console.Clear();
    }
}

