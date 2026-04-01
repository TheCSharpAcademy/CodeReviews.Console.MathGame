namespace MathGame;

public class GameEngine
{
    public int AdditionGame()
    {
        Console.Clear();
        int result = 0;
        Random random = new();

        for (int i = 0; i < 5; i++)
        {
            int num1 = random.Next(1, 11);
            int num2 = random.Next(1, 11);
        
            int correctAnswer = num1 + num2;
        
            Console.WriteLine($"What's {num1} + {num2}?");
        
            string? userAnswer = Console.ReadLine();

            // check for invalid input
            while (string.IsNullOrEmpty(userAnswer) || !int.TryParse(userAnswer, out _))
            {
                Console.WriteLine("Please enter a number");
                userAnswer = Console.ReadLine();
            }

            if (correctAnswer == int.Parse(userAnswer))
            {
                Console.WriteLine("Correct!");
                result++;
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }
        }
        
        Console.WriteLine($"You got  {result} correct.");
        return result;
    }
    
    public int SubtractionGame()
    {
        Console.Clear();
        int result = 0;
        Random random = new();

        for (int i = 0; i < 5; i++)
        {
            int num1 = random.Next(1, 11);
            int num2 = random.Next(1, 11);
        
            int correctAnswer = num1 - num2;
        
            Console.WriteLine($"What's {num1} - {num2}?");
        
            string? userAnswer = Console.ReadLine();

            // check for invalid input
            while (string.IsNullOrEmpty(userAnswer) || !int.TryParse(userAnswer, out _))
            {
                Console.WriteLine("Please enter a number");
                userAnswer = Console.ReadLine();
            }

            if (correctAnswer == int.Parse(userAnswer))
            {
                Console.WriteLine("Correct!");
                result++;
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }
        }
        
        Console.WriteLine($"You got  {result} correct.");
        return result;
    }
    
    public int MultiplicationGame()
    {
        Console.Clear();
        int result = 0;
        Random random = new();

        for (int i = 0; i < 5; i++)
        {
            int num1 = random.Next(1, 11);
            int num2 = random.Next(1, 11);
        
            int correctAnswer = num1 * num2;
        
            Console.WriteLine($"What's {num1} * {num2}?");
        
            string? userAnswer = Console.ReadLine();

            // check for invalid input
            while (string.IsNullOrEmpty(userAnswer) || !int.TryParse(userAnswer, out _))
            {
                Console.WriteLine("Please enter a number");
                userAnswer = Console.ReadLine();
            }

            if (correctAnswer == int.Parse(userAnswer))
            {
                Console.WriteLine("Correct!");
                result++;
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }
        }
                
        Console.WriteLine($"You got  {result} correct.");
        return result;
    }
    
    public int DivisionGame()
    {
        Console.Clear();
        int result = 0;
        Random random = new();

        for (int i = 0; i < 5; i++)
        {
            int[] numbers = Helpers.GetDivisionNumbers();
        
            int correctAnswer = numbers[0] / numbers[1];
        
            Console.WriteLine($"What's {numbers[0]} / {numbers[1]}?");
        
            string? userAnswer = Console.ReadLine();

            // check for invalid input
            while (string.IsNullOrEmpty(userAnswer) || !int.TryParse(userAnswer, out _))
            {
                Console.WriteLine("Please enter a number");
                userAnswer = Console.ReadLine();
            }

            if (correctAnswer == int.Parse(userAnswer))
            {
                Console.WriteLine("Correct!");
                result++;
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }
        }
                
        Console.WriteLine($"You got  {result} correct.");
        return result;
    }
}