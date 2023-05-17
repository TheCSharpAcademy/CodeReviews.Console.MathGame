using System;

namespace Math_Game;

internal class GameEngine
{
    private int m_totalScore;
    private int m_roundScore;
    private int m_minRange = 1;
    private int m_maxRange = 10;

    private int m_difficulty = 1;
    private int m_mulGamePoints = 3;
    private int m_divGamePoints = 5;
    private int m_addGamePoints = 1;
    private int m_subGamePoints = 2;

    internal GameLog log = new GameLog();
    

    private int GenerateRandom()
    {
        Random randomGen = new Random();
        return randomGen.Next(m_minRange, m_maxRange * m_difficulty);
    }

    private int GetUserInputAsInt()
    {
        int userInt;
        bool validateInput;          
        
        do
        {
            Console.WriteLine("Enter a valid integer: ");
            validateInput = int.TryParse(Console.ReadLine(), out userInt);

        } while (!validateInput);

        return userInt;
    }

    private void GetUserAnswe(int currentQuestion, int points)
    {            
        int userInput = GetUserInputAsInt();

        if (currentQuestion==userInput)
        {
            m_roundScore += points;
            Console.WriteLine($"Correct! Current score is {m_roundScore}");
            
            return;
        }
        else
        {
            Console.WriteLine("Wrong! Enter any key for next question.");
            Console.ReadKey();
            return;
        }
    }

    private void EndRound()
    {

        m_totalScore += m_roundScore;

        Console.WriteLine(@$"Round is over. You scored {m_roundScore} points this round. Your total score this session is {m_totalScore}.
     
Press any key to continue back to menu.");
        m_roundScore = 0;
        Console.ReadKey();
        Console.Clear();   
    }

    public void SetDifficulty()
    {
        Console.WriteLine("To change te difficulty enter a number between 1 and 100");
        int a = GetUserInputAsInt();

        if (a <= 100 && a > 0)
        {
            m_difficulty = a;
            return;
        }

        m_difficulty = 1;
        Console.WriteLine("Wrong value entered. Difficulty defaulted to 1");
        
        return;
    }
 
    public void AdditionGame()
    {
        Timer timer = new Timer();     
        Console.WriteLine("Addition Game");
        
        int a, b;

        for (int i = 0; i < 5; ++i)
        {
            a = GenerateRandom();
            b = GenerateRandom();

            Console.WriteLine($"{a} + {b}?");

            int currentQuestion = a + b;
            GetUserAnswe(currentQuestion, m_addGamePoints);
        }

        timer.StopTimer();
        timer.PrintTimeElapsed();
        log.LogEntry('+', m_roundScore);
        EndRound();
        return;
    }

    public void SubstractionGame()
    {
        Timer timer = new Timer();
        Console.WriteLine("Substraction Game");
                  
        int a, b;

        for (int i = 0; i < 5; ++i)
        {
            a = GenerateRandom();
            b = GenerateRandom();
            
            Console.WriteLine($"{a} - {b}?");

            int currentQuestion = a - b;
            GetUserAnswe(currentQuestion, m_subGamePoints);

        }

        timer.StopTimer();
        timer.PrintTimeElapsed();

        log.LogEntry('-', m_roundScore);
        EndRound();
        return;
    }
  
    public void MultiplicationGame()
    {
        Timer timer = new Timer();
        Console.WriteLine("Substraction Game");


        int a, b;

        for (int i = 0; i < 5; ++i)
        {
            a = GenerateRandom();
            b = GenerateRandom();

            Console.WriteLine($"{a} * {b}?");

            int currentQuestion = a * b;
            GetUserAnswe(currentQuestion, m_mulGamePoints);
        }

        timer.StopTimer();
        timer.PrintTimeElapsed();
        log.LogEntry('*', m_roundScore);
        EndRound();
        return;
    }

    public void DivisionGame()
    {
        Timer timer = new Timer();
        Console.WriteLine("Division Game");

        int a, b;

        for (int i = 0; i < 5; ++i)
        {
            a = GenerateRandom();
            do
            {              
                b = GenerateRandom();
            }
            while((a % b)!=0 || a==b);

            Console.WriteLine($"{a} / {b}?");

            int currentQuestion = a / b;
            GetUserAnswe(currentQuestion,m_divGamePoints);
        }

        timer.StopTimer();
        timer.PrintTimeElapsed();
        log.LogEntry('/', m_roundScore);
        EndRound();
        return;
    }
}
