

using Spectre.Console;
using System.Diagnostics;

namespace MathProject
{
    class Program
    {

        public static void Main(string[] args)
        {
            int count = 1;
            var history = new Dictionary<int, int>();

            while(true)
            {
                var choice = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("* * MENU * * ").AddChoices("Quiz me ..", "Previous Scores", "Exit"));
                int points = 0;
                switch (choice)
                {
                    
                    case "Quiz me ..":
                        var timer = new Stopwatch();
                        timer.Start();
                        Console.WriteLine(" what is  5 + 5");
                        int result1 = Convert.ToInt32(Console.ReadLine());
                        points = MathOperation("add", result1, points);

                        Console.WriteLine("What is 10 - 2");
                        int result2 = Convert.ToInt32(Console.ReadLine());
                        points = MathOperation("sub", result2, points);

                        Console.WriteLine("what is  9 * 5");
                        int result3 = Convert.ToInt32(Console.ReadLine());
                        points = MathOperation("mul", result3, points);
                        Console.WriteLine("What is 10 / 10"); 
                        int result4 = Convert.ToInt32(Console.ReadLine());
                        points = MathOperation("div", result4, points);
                        timer.Stop();
                        TimeSpan timeTaken = timer.Elapsed;
                        Console.WriteLine($"Time taken:  {timeTaken}");
                        history.Add(count, points);
                        count++;
                        break;
                    case "Previous Scores":
                        for(int i = 1; i <= history.Count; i++)
                        {
                            Console.WriteLine($"Attempt {i} : points {history[i]} ");
                        }
                        break;
                    case "Exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;  

                }


            }
        }

        static int MathOperation(string operation, int result, int points)
        {
            if(operation == "add" && result == 10 || operation == "sub" && result == 8 || operation == "div" && result == 1 || operation == "mul" && result == 45)
            {
                Console.WriteLine("Correct answer");
                points += 10;
            }

            Console.WriteLine("Wrong answer");

            return points;
            
        }

        
    }
   
}