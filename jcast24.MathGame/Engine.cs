namespace jcast24.MathGame;
public class Engine
{
    private List<string> games = new List<string>();
    DateTime date = DateTime.UtcNow;
    
    void AddToHistory(int gameScore, string gameType)
    {
        games.Add($"{DateTime.Now} - {gameType}: {gameScore} pts");
    }

    public void randomGame(int numOfGames)
    {
        Random num = new Random();
        var value = num.Next(0,4);

        switch (value)
        {
            case 0:
                Addition(numOfGames);
                break;
            case 1:
                Subtraction(numOfGames);
                break;
            case 2:
                Division(numOfGames);
                break;
            case 3:
                Multiplication(numOfGames);
                break;
            default:
                Console.WriteLine("Please enter a correct response: ");
                break;
        }
        
    }

    public void GetGames()
    {
        foreach(var game in games)
        {
            Console.WriteLine(game);
        }

        Console.ReadLine();
    }
    
    public void Addition(int numOfGames)
    {
        int score = 0;
        for (int i = 0; i < numOfGames; i++)
        {
            var random = new Random();
            int firstNum = random.Next(1, 9);
            int secondNum = random.Next(1, 9);
            
            int result = firstNum + secondNum;
                    
            Console.WriteLine($"What is the result of {firstNum} + {secondNum}?");
            int getResult = Convert.ToInt32(Console.ReadLine());
        
            if (getResult == result)
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }

            if (i == numOfGames - 1)
            {
                Console.WriteLine($"Final Score: {score}");
                Console.ReadLine();
            }
        }
        AddToHistory(score, "Addition");
    }

    public void Subtraction(int numOfGames)
    {
        int score = 0;
        for (int i = 0; i < numOfGames; i++)
        {
            var random = new Random();
            int firstNum = random.Next(1, 9);
            int secondNum = random.Next(1, 9);
            int result = firstNum - secondNum;
            Console.WriteLine($"What is the result of {firstNum} - {secondNum}?");
            int getResult = Convert.ToInt32(Console.ReadLine());
                        
            if (getResult == result)
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }

            if (i == numOfGames - 1)
            {
                Console.WriteLine($"Final score: {score}");
                Console.ReadLine();
            }
        }
        AddToHistory(score, "Subtraction");
    }

    int[] GetDivisionNumbers()
    {
        var random = new Random();
        int firstNum = random.Next(0, 99);
        int secondNum = random.Next(0, 99);
                
        // if the remainder of the firstNum and secondNum isn't zero
        // get 2 other random numbers
        while (firstNum % secondNum != 0)
        {
            firstNum = random.Next(0, 99);
            secondNum = random.Next(0, 99);
        }
            
        var result = new int[2];
            
        result[0] = firstNum;
        result[1] = secondNum;

        return result;
    }

    public void Division(int numOfGames)
    {
        int score = 0;
        for (int i = 0; i < numOfGames; i++)
        {
            var divArray = GetDivisionNumbers();
            var answer = divArray[0] / divArray[1];
            
            Console.WriteLine($"What is the result of {divArray[0]} / {divArray[1]}?");
            var getResult = Convert.ToInt32(Console.ReadLine());
            
            if (answer == getResult)
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }

            if (i == numOfGames - 1)
            {
                Console.WriteLine($"Final Score: {score}");
                Console.ReadLine();
            }
            
            AddToHistory(score, "Division");
        }
    }
        

    public void Multiplication(int numOfGames)
    {
        int score = 0;
        for (int i = 0; i < numOfGames; i++)
        {
            var random = new Random();
            int firstNum = random.Next(1, 9);
            int secondNum = random.Next(1, 9);
            
            int result = firstNum * secondNum;
                        
            Console.WriteLine($"What is the result of {firstNum} * {secondNum}?");
            int getResult = Convert.ToInt32(Console.ReadLine());
            if (getResult == result)
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }

            if (i == numOfGames - 1)
            {
                Console.WriteLine($"Final score: {score}");
            }
        }
        AddToHistory(score, "Multiplication");
    }
}