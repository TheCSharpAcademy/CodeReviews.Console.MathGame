using System;
using System.Globalization;
using System.Security.Cryptography;

namespace MathGame.ManuelE_Osorio;
internal class MathGame
{

    private int easyRange = 20;
    private int mediumRange = 50;
    private int hardRange = 100;

    static void Main(string[] args)
    {
        int difficultyLevel = 2;
        int numberOfQuestions = 3;
        int gameType = new();
        MathGame game = new();
        List<GameInstance> gameInstances = new();

        Console.WriteLine("Welcome to the Math Game");

        do
        {
        Console.WriteLine(@"Please select an option:
        1: Addition
        2: Subtraction
        3: Multiplication
        4: Division
        5: Random
        6: Records
        7: Configuration
        8: Exit");
        
        try
        {
            gameType = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("You've selected option " + gameType);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }

        switch (gameType)
        {
            case(>0 and <=5):
                
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

                int[] numbers = game.RandomNumberGeneration(difficultyLevel, operations, numberOfQuestions);
                break;

            case(6):
                break;

            case(7):
                do
                {
                    Console.WriteLine("Select your difficulty level");
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

                break;
 
            default:
                break;
        }
        }
        while (gameType != 8);

        Console.WriteLine("Thank you for playing the game");
    }

    public int[] RandomNumberGeneration(int difficultyLevel, int[] operations, int numberOfQuestions)
    {
        Random rnd = new();
        int min = 1;
        int max = new();
        int[] numbers = new int[numberOfQuestions*2];

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
        
        for(int i=0; i < numberOfQuestions; i++)
        {
            if (operations[i] == 4)
            {
                numbers[i*2] = rnd.Next(min+1,max+1);
                do
                {
                   numbers[i*2+1] = rnd.Next(min+1, max+1);
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