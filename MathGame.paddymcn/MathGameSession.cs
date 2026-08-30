namespace MathGame;

public class MathGameSession
{
    public int Score { get; set; } = 0;
    public int Answer { get; set; } = 0;
    public int GameNumber { get; set; } = 0;
    
    public List<string> GameHistory = new List<string>();

    // Constructor
    public MathGameSession()
    {
        
    }

    // Method
    public string AskQuestion(string type)
    {
        int rand1;
        int rand2;
        switch (type)
        {
            case "addition":
                rand1 = randomNumber(0, 100);
                rand2 = randomNumber(0, 100);
                Answer = rand1 + rand2;
                return $"What is {rand1} + {rand2}";
                break;

            case "substraction":
                rand1 = randomNumber(0, 100);
                rand2 = randomNumber(0, 100);
                Answer = rand1 - rand2;
                return $"What is {rand1} - {rand2}";
                break;

            case "multiplication":
                rand1 = randomNumber(0, 100);
                rand2 = randomNumber(0, 100);
                Answer = rand1 * rand2;
                return $"What is {rand1} * {rand2}";
                break;

            case "division":
                int divisor = randomNumber(1, 10);     
                int quotient = randomNumber(1, 10);     
                int dividend = divisor * quotient;      
                Answer = quotient;
                return $"What is {dividend} / {divisor}";
                break;
            default:
                Console.WriteLine("No type returned.");
                break;
        }
        return type;
    }

    public void CheckAnswer()
    {
        Console.WriteLine("Enter your answer:");
        string input = Console.ReadLine();
        int userAnswer;
        
        while (!int.TryParse(input, out userAnswer))
        {
            Console.WriteLine("That's not a valid number. Please enter your answer again:");
            input = Console.ReadLine();
        }

        if (userAnswer == Answer)
        {
            Console.WriteLine("Answer is correct.");
            Score++;
        }
        else
        {
            Console.WriteLine("Wrong answer.");
        }
    }
    int randomNumber(int min, int max)
    {
        var random = new Random();
        var rNum = random.Next(min, max);
        return rNum;
    }
}
    