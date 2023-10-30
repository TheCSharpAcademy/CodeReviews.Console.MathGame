using System.Diagnostics;

namespace MathGame.ManuelE_Osorio;

internal class MathGame
{  
    // Ranges for random number generation.
    private readonly int easyRange = 20;
    private readonly int mediumRange = 50;
    private readonly int hardRange = 100;

    static void Main(string[] args)
    {
        int answer = new();
        int difficultyLevel = 2;
        int numberOfQuestions = 3;
        int gameType = new();
        int gameScore = 0;
        MathGame game = new();
        Stopwatch clock = new();
        List<GameInstance> gameInstances = new();

        Console.WriteLine("Welcome to the Math Game");
        do
        {
        Console.WriteLine("Please select an option:\n" +
        "1: Addition\n" +
        "2: Subtraction\n" +
        "3: Multiplication\n" +
        "4: Division\n" +
        "5: Random\n" +
        "6: Records\n" +
        "7: Configuration\n" +
        "8: Exit");
        try
        {
            gameType = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("You've selected option " + gameType);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }

        switch (gameType)
        {
            case(>0 and <=5):
                
                // Block of code to generate random operations in case user selects option 5.
                Random rnd = new();
                int[] operations = new int[numberOfQuestions];
                if(gameType == 5)
                {
                    for(int i=0; i<numberOfQuestions; i++)
                    {
                        operations[i] = rnd.Next(1,5);
                    }
                }
                else
                {
                    Array.Fill(operations, gameType);
                }
                int[] operators = game.RandomNumberGeneration(difficultyLevel, operations, numberOfQuestions);
                
                gameInstances.Add(new GameInstance(difficultyLevel, numberOfQuestions, operations, operators, gameType));
                clock.Start();
                gameInstances[^1].StartTime = clock.ElapsedMilliseconds;

                // Loop to ask the users the operations based on the properties of GameInstance last object.                
                for (int i=0; i<gameInstances[^1].NumberOfQuestions; i++)
                {
                    Console.Write("What is the result of: ");
                    Console.Write(gameInstances[^1].Operators[i*2]+" ");
                    Console.Write(OperationToStrig(gameInstances[^1].Operations[i]));
                    Console.WriteLine(" "+gameInstances[^1].Operators[i*2+1]+"?");
                    bool j = false;
                    do
                    {
                        try
                        {
                            answer = Convert.ToInt32(Console.ReadLine());
                            j = true;
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message + " Please try again.");
                        }
                    }
                    while(j == false);


                    if(answer != gameInstances[^1].Results[i])
                    {
                        Console.WriteLine("You've entered a wrong answer.");
                    }
                    else
                    {
                        Console.WriteLine("The answer is correct!");
                        gameScore++;
                    }

                }

                clock.Stop();
                gameInstances[^1].FinishTime = clock.ElapsedMilliseconds;
                gameInstances[^1].GameScore = gameScore;
                gameScore = 0;
                Console.Clear();
                break;

            case(6):
                //Display records pending progress.
                foreach(GameInstance gameInstance in gameInstances)
                {
                    Console.WriteLine(gameInstance.SendRecords());
                }
                break;

            case(7):

                // Loop to select difficulty level from 1 to 3.
                do
                {
                    Console.WriteLine("Choose the difficulty level 1=easy, 2=medium, 3=hard");
                    try
                    {
                        difficultyLevel = Convert.ToInt32(Console.ReadLine());
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                    if (difficultyLevel <= 0 || difficultyLevel >= 4)
                    {
                        Console.WriteLine("Please select a correct difficulty level");
                    }
                }
                while(difficultyLevel <= 0 || difficultyLevel>= 4);

                // Loop to select quantity of questions.
                do
                {
                    Console.WriteLine("Select the quantity of questions");
                    try
                    {
                        numberOfQuestions = Convert.ToInt32(Console.ReadLine());
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                    if (numberOfQuestions <= 0)
                    {
                        Console.WriteLine("Please write a valid quantity of questions");
                    }
                }
                while(numberOfQuestions<=0);
                Console.Clear();

                break;
 
            default:
                break;
        }
        }
        while (gameType != 8);

        Console.WriteLine("Thank you for playing the game");
    }

    private static string OperationToStrig(int operationType)
    {
        string operationAsString = "+";

        switch(operationType)
        {
            case(1):
            {
                operationAsString = "+";
                break;
            }
            case(2):
            {
                operationAsString = "-";
                break;
            }
            case(3):
            {
                operationAsString = "*";
                break;
            }
            case(4):
            {
                operationAsString = "/";
                break;
            }
        }
        return operationAsString;
    }

    public int[] RandomNumberGeneration(int difficultyLevel, int[] operations, int numberOfQuestions)
    {
        Random rnd = new();
        int min = 1;
        int max = new();
        int[] numbers = new int[numberOfQuestions*2];

        // Selects the maximum range of the numbers based on the difficulty level.
        switch(difficultyLevel)
        {
            case(1):
            {
                max = easyRange;
                break;
            }
            case(2):
            {
                max = mediumRange;
                break;
            }
            case(3):
            {
                max = hardRange;
                break;
            }
        }
        
        // Loop to generate random numbers. If the operation is division, it checks that the remainder is 0.
        for(int i=0; i < numberOfQuestions; i++)
        {
            if (operations[i] == 4)
            {
                numbers[i*2] = rnd.Next(min+1,max+1);
                do
                {
                   numbers[i*2+1] = rnd.Next(min+1, max);
                }
                while (numbers[i*2]%numbers[i*2+1]!=0);

            }
            else
            {
                numbers[i*2] = rnd.Next(min,max+1);
                numbers[i*2+1] = rnd.Next(min, max+1);
            }
        }

        return numbers;
    }
}