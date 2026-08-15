MathOperations mathGame = new();
while (true)
{
    string userInput = string.Empty;
    Console.Clear();
    while (mathGame.IsValid)
    {
        Console.WriteLine("Choose  an operations :[A]ddition, [S]ubtraction, [M]ultiplication, [D]ivision, [H]istory");
        userInput = Console.ReadLine()!;
        mathGame.Game(userInput);

    }

    mathGame.SaveMenu();

    Console.Write("Do you want to play again? Y/N :");
    userInput = Console.ReadLine()!;

    if (userInput != null)
    {
        if (userInput.ToLower() == "n")
            break;
        else
            mathGame.IsValid = true;
    }

    Console.WriteLine("Press enter to continue...");
    ConsoleKeyInfo key = Console.ReadKey(true);
    while (key.Key != ConsoleKey.Enter) { }
}


public class MathOperations
{
    public int Score { get; private set; } = 0;
    public bool IsValid { get; set; } = true;
    private int _result = 0;
    private List<SaveScore> saveScore = new List<SaveScore>();

    private void GetResult(string userInput)
    {
        Random random = new Random();
        int number1 = random.Next(1, 101);
        int number2 = random.Next(1, 101);

        switch (userInput.ToLower())
        {
            case "a" or "addition":
                Console.Write($"What is the answer for: {number1} + {number2} ");
                _result = number1 + number2;
                IsValid = false;
                break;
            case "s" or "subtraction":
                Console.Write($"What is the answer for: {number1} - {number2} ");
                _result = number1 - number2;
                IsValid = false;
                break;
            case "m" or "Multiplication":
                Console.Write($"What is the answer for: {number1} * {number2} ");
                _result = number1 * number2;
                IsValid = false;
                break;
            case "d" or "division":
                while (number1 % number2 != 0)
                {
                    number1 = random.Next(1, 101);
                    number2 = random.Next(1, 101);
                }
                Console.Write($"What is the answer for: {number1} / {number2} ");
                _result = number1 / number2;
                IsValid = false;
                break;
            case "h" or "history":
                VisualizeSaveHistory();
                IsValid = true;
                break;
            default:
                Console.Clear();
                IsValid = true;
                break;
        }
    }
    public void SaveMenu()
    {
        Console.WriteLine("Do you want to save your score?Y/N: ");
        string input = Console.ReadLine()!;

        if (input.ToLower() == "y")
        {
            Console.Write("Enter your name: ");
            input = Console.ReadLine()!;

            if (input != null)
            {
                SaveScore save = new SaveScore(Score, input);
                saveScore.Add(save);
                Score = 0;
            }
        }

    }
    public void VisualizeSaveHistory()
    {
        Console.Write("Do you want to print the score board Y/N: ");
        string input = Console.ReadLine()!;
        if (input != null)
        {
            if (input.ToLower() == "y")
            {
                if (saveScore.Any())
                {
                    foreach (SaveScore save in saveScore)
                    {
                        save.PrintSscore();
                    }
                }
                else
                {
                    Console.WriteLine("No save scored registred!");
                }
            }
        }
    }
    public void Game(string userInput)
    {
        int rounds = 1;

        while (rounds <= 5)
        {
            GetResult(userInput);
            string guess = string.Empty;
            if (IsValid)
            {
                break;
            }
            guess = Console.ReadLine()!;

            if (int.TryParse(guess, out int value))
            {
                if (_result == value)
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
                Console.WriteLine($"Your score is : Score: {Score}");
            }

        }
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