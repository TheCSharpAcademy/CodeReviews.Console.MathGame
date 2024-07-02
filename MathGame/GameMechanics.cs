using System;
using System.Linq;
using System.Diagnostics;

namespace MathGame
{
    
    internal class GameMechanics
    {
        bool RandomGame;
        private History history = new History();
        Random random = new Random();
        public void AdditionGame(int difficulty)
        {
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Empty button returns back.");
            int num1 = 0;
            int num2 = 0;
            while (true)
            {
                if (difficulty == 0)
                {
                    num1 = random.Next(51);
                    num2 = random.Next(51);
                }
                if (difficulty == 1)
                {
                    num1 = random.Next(151);
                    num2 = random.Next(151);
                }
                
                Console.WriteLine($"{num1} + {num2}?");
                string ans = Console.ReadLine();
                if (ans == "")
                {
                    RandomGame = false;
                    break;
                }

                if (Int32.Parse(ans) == num1 + num2)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("You answered correctly!");
                    history.AddGame($"{DateTime.UtcNow}: Addition - Correct (Time: {stopwatch.Elapsed})");
                    stopwatch.Reset();
                    if (RandomGame)
                    {
                        
                        return;
                    }
                    stopwatch.Start();
                    Console.WriteLine("\n");
                   
                }
                else
                {
                    while (Int32.Parse(ans) != num1 + num2)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("Incorrect answer, please try again!");
                        history.AddGame($"{DateTime.UtcNow}: Addition - Incorrect (Time: {stopwatch.Elapsed})");
                        stopwatch.Reset();
                        stopwatch.Start();
                        ans = Console.ReadLine();
                        if (ans == "")
                        {
                            RandomGame = false;
                            break;
                        }
                    }
                    if (ans == "")
                    {
                        RandomGame = false;
                        break;
                    }
                    
                    else{
                        Console.WriteLine("\n");
                        Console.WriteLine("You answered correctly!");
                        history.AddGame($"{DateTime.UtcNow}: Addition - Correct (Time: {stopwatch.Elapsed})");
                        stopwatch.Reset();
                        if (RandomGame)
                        {
                            RandomGame = false;
                            return;
                        }
                        stopwatch.Start();
                        Console.WriteLine("\n");
                    }                      
                }
            }    
        }

        public void SubtractionGame(int difficulty)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Empty button returns back.");
            int num1 = 0;
            int num2 = 0;
            while (true)
            {
                if (difficulty == 0)
                {
                    num1 = random.Next(51);
                    num2 = random.Next(51);
                }
                if (difficulty == 1)
                {
                    num1 = random.Next(151);
                    num2 = random.Next(151);
                }

                Console.WriteLine($"{num1} - {num2}?");
                string ans = Console.ReadLine();
                if (ans == "")
                {
                    RandomGame = false;
                    break;
                }

                if (Int32.Parse(ans) == num1 - num2)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("You answered correctly!");
                    history.AddGame($"{DateTime.UtcNow}: Subtraction - Correct (Time: {stopwatch.Elapsed})");
                    stopwatch.Reset();
                    if (RandomGame)
                    {
                        
                        return;
                    }
                    stopwatch.Start();
                    Console.WriteLine("\n");

                }
                else
                {
                    while (Int32.Parse(ans) != num1 - num2)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("Incorrect answer, please try again!");
                        history.AddGame($"{DateTime.UtcNow}: Subtraction - Incorrect (Time: {stopwatch.Elapsed})");
                        stopwatch.Reset();
                        stopwatch.Start();
                        ans = Console.ReadLine();
                        if (ans == "")
                        {
                            RandomGame = false;
                            break;
                        }
                    }
                    if (ans == "")
                    {
                        RandomGame = false;
                        break;
                    }

                    else
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("You answered correctly!");
                        history.AddGame($"{DateTime.UtcNow}: Subtraction - Correct (Time: {stopwatch.Elapsed})");
                        stopwatch.Reset();
                        if (RandomGame)
                        {
                            
                            return;
                        }
                        stopwatch.Start();
                        Console.WriteLine("\n");
                    }
                }
            }

            
        }

        public void DivisionGame(int difficulty)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Empty button returns back.");
            int num1 = 0; 
            int num2 = 0;

            while (true)
            {
                if (difficulty == 0)
                {
                    num1 = random.Next(1, 50);
                    num2 = random.Next(1, 50);
                    
                }
                if (difficulty == 1)
                {
                    num1 = random.Next(1, 100);
                    num2 = random.Next(1, 100);
                    
                }
                while (num1 % num2 != 0)
                {
                    if (difficulty == 0)
                    {
                        num1 = random.Next(1, 51);
                        num2 = random.Next(1, 51);
                    }
                    else
                    {
                        num1 = random.Next(1, 101);
                        num2 = random.Next(1, 101);
                    }
                }


                Console.WriteLine($"{num1} / {num2}?");
                string ans = Console.ReadLine();
                if (ans == "")
                {
                    RandomGame = false;
                    break;
                }

                if (Int32.Parse(ans) == num1 / num2)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("You answered correctly!");
                    history.AddGame($"{DateTime.UtcNow}: Division - Correct (Time: {stopwatch.Elapsed})");
                    stopwatch.Reset();
                    stopwatch.Start();
                    Console.WriteLine("\n");

                }
                else
                {
                    while (Int32.Parse(ans) != num1 / num2)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("Incorrect answer, please try again!");
                        history.AddGame($"{DateTime.UtcNow}: Division - InCorrect (Time: {stopwatch.Elapsed})");
                        stopwatch.Reset();
                        stopwatch.Start();
                        ans = Console.ReadLine();
                        if (ans == "")
                        {
                            RandomGame = false;
                            break;
                        }
                    }
                    if (ans == "")
                    {
                        RandomGame = false;
                        break;
                    }

                    else
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("You answered correctly!");
                        history.AddGame($"{DateTime.UtcNow}: Division - Correct (Time: {stopwatch.Elapsed})");
                        stopwatch.Reset();
                        if (RandomGame)
                        {
                            RandomGame = false;
                            return;
                        }
                        stopwatch.Start();
                        Console.WriteLine("\n");
                    }
                }
            }

            
        }

        public void MultiplicationGame(int difficulty)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine("Empty button returns back.");
            int num1 = 0;
            int num2 = 0;
            while (true)
            {
                if (difficulty == 0)
                {
                    num1 = random.Next(11);
                    num2 = random.Next(11);
                }
                if (difficulty == 1)
                {
                    num1 = random.Next(21);
                    num2 = random.Next(21);
                }

                Console.WriteLine($"{num1} * {num2}?");
                string ans = Console.ReadLine();
                if (ans == "")
                {
                    RandomGame = false;
                    break;
                }

                if (Int32.Parse(ans) == num1 * num2)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("You answered correctly!");
                    history.AddGame($"{DateTime.UtcNow}: Multiplication - Correct (Time: {stopwatch.Elapsed})");
                    stopwatch.Reset();
                    if (RandomGame)
                    {
                        
                        return;
                    }
                    stopwatch.Start();
                    
                    Console.WriteLine("\n");

                }
                else
                {
                    while (Int32.Parse(ans) != num1 * num2)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("Incorrect answer, please try again!");
                        history.AddGame($"{DateTime.UtcNow}: Multiplication - Incorrect (Time: {stopwatch.Elapsed})");
                        stopwatch.Reset();
                        stopwatch.Start();
                        ans = Console.ReadLine();
                        if (ans == "")
                        {
                            RandomGame = false;
                            break;
                        }
                    }
                    if (ans == "")
                    {
                        RandomGame = false;
                        break;
                    }

                    else
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("You answered correctly!");
                        history.AddGame($"{DateTime.UtcNow}: Multiplication - Correct (Time: {stopwatch.Elapsed})");
                        stopwatch.Reset();
                        if (RandomGame)
                        {
                            RandomGame = false;
                            return;
                        }
                        stopwatch.Start();
                        Console.WriteLine("\n");
                    }
                }
            }

            
        }

        public void Print()
        {
            history.PrintHistory();
            return;
        }

        public void RandomFunction(int diff, bool r)
        {
            RandomGame = r;
            while (true)
            {
                if (!RandomGame)
                {
                    break;
                }
                int x = random.Next(4);
                switch (x)
                {
                    case 0:
                        RandomGame = true;
                        additionGame(diff);
                        break;
                    case 1:
                        RandomGame = true;
                        subtractionGame(diff);
                        break;
                    case 2:
                        RandomGame = true;
                        divisionGame(diff); break;
                    case 3:
                        RandomGame = true;
                        multiplicationGame(diff); break;
                }
            }
            
        }      
    }
}
