using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_Game;

internal class GameEngine
{
    private int m_totalScore = 0;
    private int m_roundScore = 0;
    private int m_minRange = 1;
    private int m_maxRange = 10;

    private int m_difficulty = 1;
    private int m_mulGamePoints = 3;
    private int m_divGamePoints = 5;
    private int m_addGamePoints = 1;
    private int m_subGamePoints = 2;

    private int generateRandom()
    {
        Random randomGen = new Random();
        return randomGen.Next(m_minRange, m_maxRange * m_difficulty);
    }

    private int getUserInputAsInt()
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

    private void getUserAnswer(int currentQuestion, int points)
    {
        int userAnswer;
                
        int userInput = getUserInputAsInt();

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

    private void endRound()
    {

        m_totalScore += m_roundScore;
        Console.WriteLine(@$"Round is over. You scored {m_roundScore} points this round. Your total score this session is {m_totalScore}.
     
Press any key to continue back to menu.");
        m_roundScore = 0;
        Console.ReadKey();
        Console.Clear();   
    }

    public void setDifficulty()
    {
        Console.WriteLine("To change te difficulty enter a number between 1 and 100");
        int a = getUserInputAsInt();

        if (a <= 100 && a > 0)
        {
            m_difficulty = a;
            return;
        }

        m_difficulty = 1;
        Console.WriteLine("Wrong value entered. Difficulty defaulted to 1");
        
        return;
    }
 
    public void additionGame()
    {
        Timer timer = new Timer();     
        Console.WriteLine("Addition Game");
        
        int a, b;

        for (int i = 0; i < 5; ++i)
        {
            a = generateRandom();
            b = generateRandom();

            Console.WriteLine($"{a} + {b}?");

            int currentQuestion = a + b;
            getUserAnswer(currentQuestion, m_addGamePoints);
        }

        timer.stopTimer();
        timer.printTimeElapsed();

        endRound();
        return;
    }

    public void substractionGame()
    {
        Timer timer = new Timer();
        Console.WriteLine("Substraction Game");
                  
        int a, b;

        for (int i = 0; i < 5; ++i)
        {
            a = generateRandom();
            b = generateRandom();
            
            Console.WriteLine($"{a} - {b}?");

            int currentQuestion = a - b;
            getUserAnswer(currentQuestion, m_subGamePoints);

        }

        timer.stopTimer();
        timer.printTimeElapsed();

        endRound();
        return;
    }
  
    public void multiplicationGame()
    {
        Timer timer = new Timer();
        Console.WriteLine("Substraction Game");


        int a, b;

        for (int i = 0; i < 5; ++i)
        {
            a = generateRandom();
            b = generateRandom();

            Console.WriteLine($"{a} * {b}?");

            int currentQuestion = a * b;
            getUserAnswer(currentQuestion, m_mulGamePoints);
        }

        timer.stopTimer();
        timer.printTimeElapsed();

        endRound();
        return;
    }

    public void divisionGame()
    {
        Timer timer = new Timer();
        Console.WriteLine("Division Game");

        int a, b;

        for (int i = 0; i < 5; ++i)
        {
            a = generateRandom();
            do
            {              
                b = generateRandom();
                //Console.WriteLine("Division not valid... Regenerating...");
            }
            while((a % b)!=0 || a==b);

            Console.WriteLine($"{a} / {b}?");

            int currentQuestion = a / b;
            getUserAnswer(currentQuestion,m_divGamePoints);
        }

        timer.stopTimer();
        timer.printTimeElapsed();

        endRound();
        return;
    }
}
