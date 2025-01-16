using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;


Random r = new();
string menuInput;
string input;
int problemCount = 5;
bool shouldExit = false;
List<GameResult> scores = new();
Difficulty diff = Difficulty.Easy;

//Main loop of execution
while (!shouldExit)
{
    WriteMenu();
    menuInput = Console.ReadLine() ?? "";
    if (menuInput.ToLower() == "exit") shouldExit = true;
    else if (int.TryParse(menuInput, out int opNumber))
    {
        if (Enum.IsDefined(typeof(mathOperation), opNumber))
        {
            scores.Add(MathGame((mathOperation)opNumber,(int)diff));
        }
        else if (opNumber == 9) DifficultyMenu();
        else if (opNumber == 0) PrintHistory(scores);
        else
        {
            Console.WriteLine("Invalid input.");
            EndPage();
        }
    }
    else
    {
        Console.WriteLine("Invalid input.");
        EndPage();
    }
}

//Launches a math game for a given operation and difficulty. Returns a struct with score, difficulty, and elapsed time for the game.
GameResult MathGame(mathOperation op, int difficulty = 0)
{
    int first = 0;
    int second = 0;
    GameResult results = new((Difficulty)difficulty);
    results.gameTime.Start();
            
    for (int i = 0; i < problemCount; i++)
    {
        mathOperation mathOp = op == mathOperation.Mixed ? (mathOperation)r.Next(1, 4) : op;
        GenerateNumbers(ref first, ref second, mathOp, difficulty);

        Console.Clear();
        int solution = CreateQuestion(first, second, mathOp);

        input = Console.ReadLine() ?? "";

        if (solution.ToString() == input)
        {
            Console.Write("\nYour answer was correct!\n\n");
            results.score++;
        }
        else Console.Write("\nIncorrect solution.\n\n");
        EndPage();
    }
    Console.Clear();
    results.gameTime.Stop();
    Console.Write($"Game complete!\n\n" +
        $"You scored {results.score}/{problemCount} points total!\nYou took {results.gameTime.Elapsed.Minutes} minutes and {results.gameTime.Elapsed.Seconds} seconds to complete the game.\n\n");
    EndPage();
    return results;
}

//Prints a formatted list of the results of previous games and an overall win rate.
void PrintHistory(List<GameResult> scores)
{
    int totalCorrect = 0;
    int totalPossible = scores.Count * problemCount;
    Console.Clear();
    if (scores.Count == 0) 
    { 
        Console.WriteLine("No game history!"); 
        EndPage(); 
        return; 
    }
    Console.WriteLine("Previous Game Scores:");
    Console.WriteLine();
    foreach (GameResult result in scores)
    {
        totalCorrect += result.score;
        Console.WriteLine($"{result.score}/{problemCount}    {100 * result.score / problemCount}%     {result.gameTime.Elapsed.Minutes}m{result.gameTime.Elapsed.Seconds}s     {result.gameDiff}");
    }
    Console.WriteLine();
    Console.WriteLine($"Overall average: {100*totalCorrect/totalPossible}%");
    EndPage();

}

//Helper function to end a console display and wait for input.
void EndPage()
{
    Console.WriteLine("Press Enter to continue...");
    Console.ReadLine();
}

//Writes the text of the main menu
void WriteMenu()
{
    Console.Clear();
    Console.Write(@"Math Game

Choose an operation:

1. Addition
2. Subtraction
3. Multiplication
4. Division
5. Random

Type '9' to change difficulty or '0' to see a summary of past games

Type 'exit' to exit. Warning: Game history will not be saved.

");
}

//Creates a menu to change the difficulty. Difficulty is persistent until changed again or restarted
void DifficultyMenu()
{
    Console.Clear();
    Console.Write(@"Math Game

Choose difficulty level:
1. Easy (default)
2. Intermediate
3. Hard

");

    switch (Console.ReadLine())
    {
        case "1":
            diff = Difficulty.Easy; break;
        case "2":
            diff = Difficulty.Intermediate; break;
        case "3":
            diff = Difficulty.Hard; break;
        default:
            return;
    }
}

//Randomizes two numbers by reference. The bounds of randomization are determined by operation and difficulty.
void GenerateNumbers(ref int firstNum, ref int secondNum, mathOperation op, int difficulty = 0)
{
    //base difficulty: 0-20, 0-20 (greatest first), 0-12, 0-100 / 1-20   division max is 5*2^diff*divisor max
    //mid difficulty:  20-100, 20-100 (greatest first), 0-20, 0-350 / 2-35 
    //hard difficulty: 100-500, 100-500 (greatest first), 10-50, 100-1000 / 2-50
    int[,] lowest =  { {0, 20, 100}, {0, 20, 100}, {0, 0, 10}, {1, 2, 2} };
    int[,] highest = { {20, 100, 500}, {20, 100, 500}, {12, 20, 50}, {20, 35, 50} };
    switch (op)
    {
        case mathOperation.Addition:
            firstNum = r.Next(lowest[(int)op - 1, difficulty], highest[(int)op - 1, difficulty]);
            secondNum = r.Next(lowest[(int)op - 1, difficulty], highest[(int)op - 1, difficulty]);
            break;
        case mathOperation.Subtraction:
            firstNum = r.Next(lowest[(int)op - 1, difficulty], highest[(int)op - 1, difficulty]);
            secondNum = r.Next(lowest[(int)op - 1, difficulty], firstNum);
            break;
        case mathOperation.Multiplication:
            firstNum = r.Next(lowest[(int)op - 1, difficulty], highest[(int)op - 1, difficulty]);
            secondNum = r.Next(lowest[(int)op - 1, difficulty], highest[(int)op - 1, difficulty]);
            break;
        case mathOperation.Division:
            secondNum = r.Next(lowest[(int)op - 1, difficulty], highest[(int)op - 1, difficulty]);                                                                  //divisor
            firstNum = r.Next((int)Math.Pow(2*(int)difficulty,2), (highest[(int)op - 1, difficulty] * 5 * (int)Math.Pow(2,difficulty))/secondNum) * secondNum;      //dividend
            break;
        default:
            throw new NotImplementedException();
    }
}

//Writes a math problem to console and returns the answer.
int CreateQuestion(int a, int b, mathOperation op)
{
    switch (op)
    {
        case mathOperation.Addition:
            Console.Write($" {a} + {b} = \n");
            return a + b;
        case mathOperation.Subtraction:
            Console.Write($" {a} - {b} = \n");
            return a - b;
        case mathOperation.Multiplication:
            Console.Write($" {a} * {b} = \n");
            return a * b;
        case mathOperation.Division:
            Console.Write($" {a} / {b} = \n");       //We only want dividends evenly divisible for integer division
            return a / b;
        default:
            throw new ArgumentException("Invalid operation.");
    }
}


//Enumerator for math operations
public enum mathOperation
{
    Addition = 1,
    Subtraction,
    Multiplication,
    Division,
    Mixed
}

//Enumerator for difficulty settings
public enum Difficulty
{
    Easy,
    Intermediate,
    Hard
}

//struct to hold game score, difficulty, and a timekeeper
public struct GameResult
{
    public GameResult(Difficulty diff = Difficulty.Easy)
    {
        score = 0;
        gameDiff = diff;
        gameTime = new();
    }

    public int score { get; set; }
    public Difficulty gameDiff {  get; set; }
    public Stopwatch gameTime { get; set; }
}
