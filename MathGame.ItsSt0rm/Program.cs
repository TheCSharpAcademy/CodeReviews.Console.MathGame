using System.Diagnostics;

int game = 1;
int difficult = 20;
string welcomeLine = "\nWelcome to the Math Game, please write the number of the option that you want to choose";
string menuOptions = @"
1. Addition
2. Substraction 
3. Multiplication
4. Division
5. Previous games
6. Change difficult (Normal by default)
7. Random mode
0. Exit
";
string line;
List<string> gamesHistory = new List<string>();

Console.WriteLine(welcomeLine);
Console.WriteLine(menuOptions);

while (!String.IsNullOrEmpty(line = Console.ReadLine()))
{
    int selectedOption = int.Parse(line);
    int correctAnswers;
    bool randomMode = false;

    if (selectedOption < 0 || selectedOption > 7)
    {
        Console.WriteLine("----------- You must choose a valid option -----------");
    }

    if (selectedOption == 0)
    {
        break;
    }

    if (selectedOption == 5)
    {
        Console.WriteLine("----------- Previous Games -----------\n");

        foreach (var gameRecord in gamesHistory)
        {
            Console.WriteLine(gameRecord);
        }
    }

    if (selectedOption == 6)
    {
        difficult = 0;
        Console.WriteLine("Select difficulty\n1. Easy\n2. Normal\n3. Hard");

        while (difficult == 0)
        {
            int.TryParse(Console.ReadLine(), out int responseDifficult);

            switch (responseDifficult)
            {
                case 1:
                    difficult = 10;
                    Console.WriteLine("----------- Easy difficult setted -----------");
                    break;

                case 2:
                    difficult = 20;
                    Console.WriteLine("----------- Normal difficult setted -----------");
                    break;

                case 3:
                    difficult = 30;
                    Console.WriteLine("----------- Hard difficult setted -----------");
                    break;

                default:
                    Console.WriteLine("----------- You must choose a valid option -----------");
                    break;
            }
        }
    }

    if (selectedOption == 7)
    {
        randomMode = true;
        selectedOption = 1;
    }

    if (selectedOption > 0 && selectedOption < 5)
    {
        Console.WriteLine("\nWrite the number of questions that you want in the game");
        int.TryParse(Console.ReadLine(), out int numberQuestions);

        Console.WriteLine($"----------- Game {game} -----------");

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        correctAnswers = 0;

        for (int i = 0; i < numberQuestions; i++)
        {
            int firstNumber = new Random().Next(1, difficult);
            int secondNumber = new Random().Next(1, difficult);

            if (randomMode) selectedOption = new Random().Next(1, 5);

            switch (selectedOption)
            {
                case 1:
                    if (AdditionGame(firstNumber, secondNumber))
                    {
                        correctAnswers++;
                    }
                    break;
                case 2:
                    if (SubstractionGame(firstNumber, secondNumber))
                    {
                        correctAnswers++;
                    }
                    break;
                case 3:
                    if (MultiplicationGame(firstNumber, secondNumber))
                    {
                        correctAnswers++;
                    }
                    break;
                case 4:
                    if (DivisionGame(firstNumber, secondNumber))
                    {
                        correctAnswers++;
                    }
                    break;
            }
        }

        stopwatch.Stop();
        TimeSpan elapsedTime = stopwatch.Elapsed;

        Console.WriteLine("\n"); // Friendly linespacing.

        if (correctAnswers == numberQuestions)
        {
            Console.WriteLine("\n----------- Congratulations, you won! -----------");
        }
        else
        {
            Console.WriteLine("\n----------- Sorry, you lost -----------");
        }

        gamesHistory.Add($"Game {game}: {correctAnswers} / {numberQuestions} | Time elapsed: {elapsedTime.ToString(@"mm\:ss")}");
        game++;

        Console.WriteLine($"\n----------- Results: {correctAnswers} / {numberQuestions} | Time elapsed: {elapsedTime.ToString(@"mm\:ss")} -----------");

    }

    Console.WriteLine(welcomeLine);
    Console.WriteLine(menuOptions);
}


Console.WriteLine("----------- Thanks for playing -----------");

// Methods for game logic

bool AdditionGame(int firstNumber, int secondNumber)
{
    bool isCorrect = false;

    Console.WriteLine($"{firstNumber} + {secondNumber} = ?");
    int.TryParse(Console.ReadLine(), out int responseAddition);

    if (responseAddition == firstNumber + secondNumber)
    {
        isCorrect = true;
        Console.WriteLine("----------- Correct! -----------");
    }
    else
    {
        Console.WriteLine("----------- Incorrect! -----------");
    }

    return isCorrect;
}

bool SubstractionGame(int firstNumber, int secondNumber)
{
    bool isCorrect = false;

    Console.WriteLine($"{firstNumber} - {secondNumber} = ?");
    int.TryParse(Console.ReadLine(), out int responseAddition);

    if (responseAddition == firstNumber - secondNumber)
    {
        isCorrect = true;
        Console.WriteLine("----------- Correct! -----------");
    }
    else
    {
        Console.WriteLine("----------- Incorrect! -----------");
    }

    return isCorrect;
}

bool MultiplicationGame(int firstNumber, int secondNumber)
{
    bool isCorrect = false;

    Console.WriteLine($"{firstNumber} * {secondNumber} = ?");
    int.TryParse(Console.ReadLine(), out int responseAddition);

    if (responseAddition == firstNumber * secondNumber)
    {
        isCorrect = true;
        Console.WriteLine("----------- Correct! -----------");
    }
    else
    {
        Console.WriteLine("----------- Incorrect! -----------");
    }

    return isCorrect;
}

bool DivisionGame(int firstNumber, int secondNumber)
{
    bool isCorrect = false;

    while (firstNumber % secondNumber != 0 || secondNumber == 0)
    {
        firstNumber = new Random().Next(0, 100);
        secondNumber = new Random().Next(1, difficult);
    }

    Console.WriteLine($"{firstNumber} / {secondNumber} = ?");
    int.TryParse(Console.ReadLine(), out int responseDivision);

    if (responseDivision == firstNumber / secondNumber)
    {
        isCorrect = true;
        Console.WriteLine("----------- Correct! -----------");
    }
    else
    {
        Console.WriteLine("----------- Incorrect! -----------");
    }

    return isCorrect;
}