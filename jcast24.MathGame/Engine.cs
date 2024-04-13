/*
 * TODO: Ask the user how many games they would like to play, keep track of score
 */
namespace jcast24.MathGame;
public class Engine
{
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
            
        }
        Console.WriteLine($"Final score: {score}");
    }

    public void Subtraction()
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
        }
        else
        {
            Console.WriteLine("Incorrect!");
        }
    }

    public static int[] GetDivisionNumbers()
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

    public void Division()
    {
        var divArray = GetDivisionNumbers();
        var answer = divArray[0] / divArray[1];

        Console.WriteLine($"What is the result of {divArray[0]} / {divArray[1]}?");
        int getResult = Convert.ToInt32(Console.ReadLine());

        if (answer == getResult)
        {
            Console.WriteLine("Correct!");
        }
        else
        {
            Console.WriteLine("Incorrect!");
        }
    }
        

    public void Multiplication()
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
        }
        else
        {
            Console.WriteLine("Incorrect!");
        }
            
    }
}