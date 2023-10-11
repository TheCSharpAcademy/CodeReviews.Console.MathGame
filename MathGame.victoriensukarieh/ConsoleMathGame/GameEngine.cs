using ConsoleMathGame.Models;

namespace ConsoleMathGame;
internal class GameEngine
{
    public string player;
    public GameEngine(String p)
    {
        player = p;
    }
    public void AdditionGame(int level, int numberOfQuestions)
    {        
        Random rnd = new();
        int num1;
        int num2;
        string answer;
        int score = 0;
        int time;
        Helpers.StartTimer();
        for (int i = 0; i < numberOfQuestions; i++)
        {
            num1 = rnd.Next(Convert.ToInt32(Math.Pow(10, level - 1)), Convert.ToInt32(Math.Pow(10, level)));
            num2 = rnd.Next(Convert.ToInt32(Math.Pow(10, level - 1)), Convert.ToInt32(Math.Pow(10, level)));
            
            Console.Write($"{num1} + {num2} = ");
            answer = Console.ReadLine();
            answer = Helpers.ValidateInput(answer);
            if (Convert.ToInt32(answer) == num1 + num2)
            {
                Console.WriteLine("Connect!");
                score++;
            }
            else
            {
                Console.WriteLine("Inconnect!");
            }
        }
        time = Helpers.StopTimer();
        Console.WriteLine($"Your Score is {score}");
        Console.WriteLine($"Your Time is {time} Seconds");
        Helpers.SaveScore(player, Game.GameType.Addition, score, level, numberOfQuestions, time);
    }

    public void SubtractionGame(int level, int numberOfQuestions)
    {       
        Random rnd = new();
        int num1 = 0;
        int num2 = num1 + 1;
        string answer;
        int score = 0;
        int time;
        Helpers.StartTimer();
        for (int i = 0; i < numberOfQuestions; i++)
        {
            while (num1 < num2)
            {
                num1 = rnd.Next(Convert.ToInt32(Math.Pow(10, level - 1)), Convert.ToInt32(Math.Pow(10, level)));
                num2 = rnd.Next(Convert.ToInt32(Math.Pow(10, level - 1)), Convert.ToInt32(Math.Pow(10, level)));
            }
            
            Console.Write($"{num1} - {num2} = ");
            answer = Console.ReadLine();
            answer = Helpers.ValidateInput(answer);
            if (Convert.ToInt32(answer) == num1 - num2)
            {
                Console.WriteLine("Connect!");
                score++;
            }
            else
            {
                Console.WriteLine("Inconnect!");
            }
            num1 = 0;
            num2 = num1 + 1;
        }
        time = Helpers.StopTimer();        
        Console.WriteLine($"Your Score is {score}");
        Console.WriteLine($"Your Time is {time} Seconds");
        Helpers.SaveScore(player, Game.GameType.Subtraction, score, level, numberOfQuestions, time);
    }

    public void MultiplicationGame(int level, int numberOfQuestions)
    {       
        Random rnd = new();
        int num1;
        int num2;
        string answer;
        int score = 0;
        int time;
        Helpers.StartTimer();
        for (int i = 0; i < numberOfQuestions; i++)
        {
            num1 = rnd.Next(Convert.ToInt32(Math.Pow(10, level - 1)), Convert.ToInt32(Math.Pow(10, level)));
            num2 = rnd.Next(Convert.ToInt32(Math.Pow(10, level - 1)), Convert.ToInt32(Math.Pow(10, level)));
           
            Console.Write($"{num1} x {num2} = ");
            answer = Console.ReadLine();
            answer = Helpers.ValidateInput(answer);
            if (Convert.ToInt32(answer) == num1 * num2)
            {
                Console.WriteLine("Connect!");
                score++;
            }
            else
            {
                Console.WriteLine("Inconnect!");
            }
            num1 = 0;
            num2 = num1 + 1;
        }
        time = Helpers.StopTimer();
        Console.WriteLine($"Your Score is {score}");
        Console.WriteLine($"Your Time is {time}  Seconds");
        Helpers.SaveScore(player, Game.GameType.Multiplication, score, level, numberOfQuestions, time);

    }
    public void DivisionGame(int level, int numberOfQuestions)
    {        
        string answer;
        int score = 0;
        int time;
        Helpers.StartTimer();
        for (int i = 0; i < numberOfQuestions; i++)
        {
            int[] numbers = Helpers.NumbersForDivision(level);
           
            Console.Write($"{numbers[0]} / {numbers[1]} = ");
            answer = Console.ReadLine();
            answer = Helpers.ValidateInput(answer);
            if (Convert.ToInt32(answer) == numbers[0] / numbers[1])
            {
                Console.WriteLine("Connect!");
                score++;
            }
            else
            {
                Console.WriteLine("Inconnect!");
            }
        }
        time = Helpers.StopTimer();
        Console.WriteLine($"Your Score is {score}");
        Console.WriteLine($"Your Time is {time}  Seconds");
        Helpers.SaveScore(player, Game.GameType.Division, score, level, numberOfQuestions, time);

    }
    public void RandonGame(int level, int numberOfQuestions)
    {
        Random rnd = new Random();
        int gameNum = rnd.Next(1, 5);
        switch (gameNum)
        {
            case 1:
                AdditionGame(level, numberOfQuestions);
                break;
            case 2:
                SubtractionGame(level, numberOfQuestions);
                break;
            case 3:
                MultiplicationGame(level, numberOfQuestions);
                break;
            case 4:
                DivisionGame(level, numberOfQuestions);
                break;
            default:
                break;

        }
    }
    public void FrenzyGame(int level, int numberOfQuestions)
    {        
        Random rnd = new();
        int num1;
        int num2;
        string answer;
        int score = 0;
        int time;
        Helpers.StartTimer();
        for (int i = 0; i < numberOfQuestions; i++)
        {
            num1 = rnd.Next(Convert.ToInt32(Math.Pow(10, level - 1)), Convert.ToInt32(Math.Pow(10, level)));
            num2 = rnd.Next(Convert.ToInt32(Math.Pow(10, level - 1)), Convert.ToInt32(Math.Pow(10, level)));

            int gameNum = rnd.Next(1, 5);
            string operatorSymbol = "";
            int theRightAnswer = 0;
            switch (gameNum)
            {
                case 1:
                    operatorSymbol = "+";
                    theRightAnswer = num1 + num2;
                    break;
                case 2:
                    operatorSymbol = "-";
                    while (num1 < num2)
                    {
                        num1 = rnd.Next(Convert.ToInt32(Math.Pow(10, level - 1)), Convert.ToInt32(Math.Pow(10, level)));
                        num2 = rnd.Next(Convert.ToInt32(Math.Pow(10, level - 1)), Convert.ToInt32(Math.Pow(10, level)));
                    }
                    theRightAnswer = num1 - num2;
                    break;
                case 3:
                    operatorSymbol = "x";
                    theRightAnswer = num1 * num2;
                    break;
                case 4:
                    operatorSymbol = "/";
                    int[] numbers = Helpers.NumbersForDivision(level);
                    num1 = numbers[0];
                    num2 = numbers[1];

                    theRightAnswer = num1 / num2;
                    break;
                default:
                    break;
            }
            
            Console.Write($"{num1} {operatorSymbol} {num2} = ");
            answer = Console.ReadLine();
            answer = Helpers.ValidateInput(answer);
            if (Convert.ToInt32(answer) == theRightAnswer)
            {
                Console.WriteLine("Connect!");
                score++;
            }
            else
            {
                Console.WriteLine("Inconnect!");
            }
            num1 = 0;
            num2 = num1 + 1;
        }
        time = Helpers.StopTimer();
        Console.WriteLine($"Your Score is {score}");
        Console.WriteLine($"Your Time is {time}  Seconds");
        Helpers.SaveScore(player, Game.GameType.Frenzy, score, level, numberOfQuestions, time);
    }
}