using System.Diagnostics;

List<int> previousGamesData = new();
bool playAgain = true;
int chosenOption;
int chosenDifficulty;
string[] gameOptions = { "Addition", "Substraction", "Multiplication", "Division", "Random" };
char[] operatorSymbols = { '+', '-', '*', '/' };
string[] difficulties = { "Easy", "Medium", "Hard" };
while (playAgain)
{
    try
    {
        chosenOption = chooseOption();
        if (chosenOption == 6)
        {
            ShowPreviousGamesHistory();
            Console.WriteLine("\nPress any key to go back");
            Console.ReadKey();
            Console.Clear();
            continue;
        }
        if (chosenOption == 7)
            break;
        chosenDifficulty = chooseDifficulty();
        if (chosenDifficulty == 4)
        {
            Console.Clear();
            continue;
        }
        playGame(chosenOption, chosenDifficulty);
        Console.WriteLine("Play again? y/n");
        string? answer = Console.ReadLine();
        playAgain = (!string.IsNullOrEmpty(answer)) && (answer[0] == 'y' || answer[0] == 'Y');
        Console.Clear();
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.ToString());
        Console.WriteLine("An exception ocurred. " + ex.Message + '\n');
        break;
    }
}
Console.WriteLine("Thank you for playing.");




int chooseOption()
{
    int option;
    do
    {
        Console.WriteLine(@"---Welcome to the Math Game---
        Choose a game:
        1: Addition
        2: Substraction
        3: Multiplication
        4: Division
        5: Random
        6: History of previous games
        7: Exit game");
        string? result = Console.ReadLine();
        int.TryParse(result, out option);

    } while(option < 1 || option > 6);
    return option;
}

int chooseDifficulty()
{
    int difficulty;
    do
    {
        Console.WriteLine(@"Choose the difficulty:
        1: Easy
        2: Medium
        3: Hard
        4: Go back");
        string? result = Console.ReadLine();
        int.TryParse(result, out difficulty);

    } while (difficulty < 1 || difficulty > 4);
    return difficulty;
}

void playGame(int gameOption, int difficulty)
{
    int operand1, operand2, result;
    int maxRounds = 5 * difficulty;
    int score = 0;
    string difficultyText = difficulties[difficulty - 1];
    int operatorSymbolIndex;

    Random rng = new Random();


    Stopwatch timer = new Stopwatch();
    timer.Start();

    previousGamesData.Add(gameOption);
    previousGamesData.Add(difficulty);

    for (int round = 1; round <= maxRounds; round++)
    {
        getOperandsAndResult(gameOption, difficulty, rng, out operand1, out operand2, out result, out operatorSymbolIndex);
        Console.WriteLine($"{difficultyText} mode - Round {round}/{maxRounds} | Score: {score}" );
        Console.WriteLine($"{operand1} {operatorSymbols[operatorSymbolIndex]} {operand2}");
        int userInput;
        int.TryParse(Console.ReadLine(), out userInput);

        previousGamesData.Add(operand1);
        previousGamesData.Add(operand2);
        previousGamesData.Add(userInput);
        previousGamesData.Add(operatorSymbolIndex);

        if (userInput == result)
        {
            score++;
            Console.WriteLine("Correct!");
        }
        else
        {
            Console.WriteLine("Incorrect. The result was " + result + '\n');
        }
    }

    timer.Stop();
    Console.WriteLine("---Game Over---");
    Console.WriteLine($"Your score: {score} / {maxRounds}. Your time: {timer.Elapsed.TotalSeconds:F2} seconds");

    previousGamesData.Add((int)timer.Elapsed.TotalMilliseconds);
}

void getOperandsAndResult(int gameOption, int difficulty, Random rng, out int operand1, out int operand2, out int result, out int operatorSymbolIndex)
{

    int minNumber = 1;
    int maxNumber = 100;

    if(gameOption == 5)
    {
        gameOption = rng.Next(1, 5);
    }

    switch (gameOption)
    {
        // Addiction and substraction: Easy 10-99, Medium 100-999, Hard 1000-9999
        case 1:
        case 2:
            minNumber = (int)Math.Pow(10, difficulty);
            maxNumber = (int)Math.Pow(10, difficulty + 1) - 1;
            break;
        // Multiplication: Easy 2-16, Medium 8-32, Hard 24-64
        case 3:
            minNumber = difficulty * (int)Math.Pow(2, difficulty);
            maxNumber = 8 * (int)Math.Pow(2, difficulty) - 1;
            break;
        case 4:
            // Division: Easy 6-39, Medium 72-199, Hard 648-999
            minNumber = difficulty * (int)Math.Pow(6, difficulty);
            maxNumber = 40 * (int)(Math.Pow(5, difficulty) / 5) - 1;
            break;
        default:
            throw new ArgumentException("How did you manage to break this?");
    }

    operand1 = rng.Next(minNumber, maxNumber + 1);
    operand2 = rng.Next(minNumber, maxNumber + 1);

    //Handle division
    if (gameOption == 4)
    {
        List<int> divisors = new();
        while (divisors.Count == 0)
        {
            operand1 = rng.Next(minNumber, maxNumber + 1);
            divisors = GetDivisors(operand1);
        }
        operand2 = divisors[rng.Next(divisors.Count)];
    }
    result = getOperationResult(gameOption, operand1, operand2, out operatorSymbolIndex);
}

//Getting the divisors both checks that the number is not prime (to avoid trivial divisions) and makes assigning operand2 way faster
List<int> GetDivisors(int number)
{
    List<int> divisors = new();
    for(int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
    {
        if(number % divisor == 0)
        {
            divisors.Add(divisor);
            int otherDivisor = number / divisor;
            if(otherDivisor != divisor)
            {
                divisors.Add(otherDivisor);
            }
        }
    }
    return divisors;
}

int getOperationResult(int gameOption, int operand1, int operand2, out int operatorSymbolIndex)
{
    int result;
    switch (gameOption)
    {
        case 1:
            result = operand1 + operand2;
            break;
        case 2:
            result = operand1 - operand2;
            break;
        case 3:
            result = operand1 * operand2;
            break;
        case 4:
            result = operand1 / operand2;
            break;
        default:
            throw new ArgumentException("How did you manage to break this?");
    }
    operatorSymbolIndex = gameOption - 1;
    return result;
}

void ShowPreviousGamesHistory()
{
    int data = 0;
    if (previousGamesData.Count == 0)
        return;
    do
    {
        int gameOption = previousGamesData[data];
        int difficulty = previousGamesData[++data];
        Console.WriteLine("\n--------------------------------");
        Console.WriteLine($"{gameOptions[gameOption - 1]} - {difficulties[difficulty - 1]} mode");
        int maxRounds = 5 * difficulty;
        int score = 0;
        for (int round = 1; round <= maxRounds; round++)
        {
            Console.WriteLine($"Round {round}/{maxRounds}");
            int operand1 = previousGamesData[++data];
            int operand2 = previousGamesData[++data];
            int userInput = previousGamesData[++data];
            int operatorSymbolIndex = previousGamesData[++data];
            int result = getOperationResult(operatorSymbolIndex + 1, operand1, operand2, out operatorSymbolIndex);
            Console.WriteLine($"{operand1} {operatorSymbols[operatorSymbolIndex]} {operand2} = {result}");
            bool correct = (userInput == result);
            score += correct ? 1 : 0;
            Console.WriteLine($"You answered: {userInput}. " + (correct ? "Correct!" : "Incorrect. " +  $"Score: {score} / {maxRounds}"));
        }
        double time = (double)previousGamesData[++data]/1000;
        Console.WriteLine($"Final score: {score} / {maxRounds}. Time: {time:F2} seconds");
    } while (++data < previousGamesData.Count);
}