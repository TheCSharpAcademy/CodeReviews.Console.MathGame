MathOperations mathGame = new();
List<SaveScore> saveScore = new List<SaveScore>();
while (true)
{
    mathGame.Game();
    SaveMenu();

    Console.Write("Do you want to play again? Y/N :");
    string userInput = Console.ReadLine()!;

    if (userInput != null)
    {
        if (userInput.ToLower() == "n")
            break;
    }
    Console.WriteLine("Press enter to continue...");
    ConsoleKeyInfo key = Console.ReadKey(true);
    while (key.Key != ConsoleKey.Enter) { }
    ;
}



void SaveMenu()
{
    Console.WriteLine("Do you want to save your score?Y/N: ");
    string input = Console.ReadLine()!;

    if (input.ToLower() == "y")
    {
        Console.Write("Enter your name: ");
        input = Console.ReadLine()!;

        if (input != null)
        {
            SaveScore save = new SaveScore(mathGame.Score, input);
            saveScore.Add(save);
        }
    }
    Console.Write("Do you want to print the score board Y/N: ");
    input = Console.ReadLine()!;
    if (input != null)
    {
        if (input.ToLower() == "y")
        {
            foreach (SaveScore save in saveScore)
            {
                save.PrintSscore();
            }
        }
    }
}

public class MathOperations
{
    public int Score { get; private set; }
    private int GetResult(string operation)
    {
        Random random = new Random();
        int number1 = random.Next(1, 101);
        int number2 = random.Next(1, 101);
        switch (operation.ToLower())
        {
            case "a" or "addition":
                Console.Write($"What is the answer for: {number1} + {number2} ");
                return number1 + number2;
            case "s" or "subtraction":
                Console.Write($"What is the answer for: {number1} - {number2} ");
                return Math.Abs(number1 - number2);
            case "m" or "Multiplication":
                Console.Write($"What is the answer for: {number1} * {number2} ");
                return number1 * number2;
            case "d" or "division":
                while (number1 % number2 != 0)
                {
                    number1 = random.Next(1, 101);
                    number2 = random.Next(1, 101);
                }
                Console.Write($"What is the answer for: {number1} / {number2} ");
                return number1 / number2;
            default:
                Console.WriteLine("Invalid Operation1!");
                return -1;
        }
    }
    public void Game()
    {
        Console.WriteLine("Choose  an operations :[A]ddition, [S]ubtraction, [M]ultiplication, or [D]ivision.");
        string userInput = Console.ReadLine()!;
        int rounds = 1;
        Score = 0;

        while (rounds <= 5)
        {
            int result = GetResult(userInput);
            if (result != -1)
            {
                string guess = Console.ReadLine()!;
                if (int.TryParse(guess, out int value))
                {
                    if (result == value)
                    {
                        rounds++;
                        Score++;
                        Console.WriteLine("Correct!!");
                    }
                    else
                    {
                        Console.WriteLine("Wrong!!");
                        rounds++;
                    }
                }
            }
        }
        Console.WriteLine($"Your score is : Score: {Score}");
    }
}
public class SaveScore
{
    private string playerName;
    private int playerScore;
    public SaveScore(int score, string name)
    {
        playerScore = score;
        playerName = name;
    }

    public void PrintSscore()
    {
        Console.WriteLine("-----------------------------");
        Console.WriteLine($"{playerName}:  {playerScore}");
    }
}