// See https://aka.ms/new-console-template for more information
using static System.Formats.Asn1.AsnWriter;

class MathGame
{
    static void Main()
    {
        int menuSelect = 0;
        bool exit = false;
        List <string> scores = new List<string>();

        while (exit == false)
        {
            Console.WriteLine("Welcome to the Math Game");
            Console.WriteLine("Menu");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Game History\n");
            Console.WriteLine("Please type in the number of choice or type exit to be done.");
            string menuInput = Console.ReadLine();
            bool inputNum = int.TryParse(menuInput, out menuSelect);

            ValidInput(inputNum);
            if (menuSelect == 5 && inputNum)
            {
                GameHistory(scores);
            }
            else if (inputNum)
            {
                scores.Add(ProblemSet(menuSelect));
            }
            else if(menuInput.ToLower() == "exit")
            {
                exit = true;
            }
            

        }
            

        

    }

    static string ProblemSet(int type)
    {
        int numProblems = 1;
        bool problemCheck;
        int score = 0;
        int num1 = 0;
        int num2 = 0;
        int problemInput;
        bool validInput;
        Random random = new Random();
        
        string scoreString = "";

        Console.WriteLine("Please choose number of problems.");
        validInput = int.TryParse(Console.ReadLine(), out numProblems);

        ValidInput(validInput);
        
        for (int i = 0; i < numProblems; i++)
        {
            switch (type)
            {
                case 1:
                    // Addition
                    num1 = random.Next(1, 100);
                    num2 = random.Next(1, 100);
                    Console.WriteLine($"{num1} + {num2}");
                    problemCheck = int.TryParse(Console.ReadLine(), out problemInput);
                    if (problemCheck)
                    {
                        if (problemInput == (num1 + num2))
                        {
                            Console.WriteLine("Correct!");
                            score++;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect");
                    }
                     
                    break;

                case 2:
                    // Subtraction
                    num1 = random.Next(1, 100);
                    num2 = random.Next(1, 100);
                    Console.WriteLine($"{num1} - {num2}");
                    problemCheck = int.TryParse(Console.ReadLine(), out problemInput);
                    if (problemCheck)
                    {
                        if (problemInput == (num1 - num2))
                        {
                            Console.WriteLine("Correct!");
                            score++;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect");
                    }
                    break;
                case 3:
                    // Multiplication
                    num1 = random.Next(1, 100);
                    num2 = random.Next(1, 100);
                    Console.WriteLine($"{num1} * {num2}");
                    problemCheck = int.TryParse(Console.ReadLine(), out problemInput);
                    if (problemCheck)
                        if (problemCheck)
                        {
                            if (problemInput == (num1 * num2))
                            {
                                Console.WriteLine("Correct!");
                                score++;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect");
                            }
                        }
                        else
                    {
                        Console.WriteLine("Incorrect");
                    }

                    break;
                case 4:
                    // Division
                    num1 = random.Next(1, 100);
                    num2 = random.Next(1, 100);
                    while((num1/num2) != (decimal)((decimal)num1 /(decimal) num2))
                    {
                        num1 = random.Next(1, 100);
                        num2 = random.Next(1, 100);
                    }
                    Console.WriteLine($"{num1} / {num2}");
                    problemCheck = int.TryParse(Console.ReadLine(), out problemInput);
                    if (problemCheck)
                    {
                        if (problemInput == (num1 / num2))
                        {
                            Console.WriteLine("Correct!");
                            score++;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Incorrect");
                    }
                    break;
                
            }
        }
        scoreString = $"{score}/{numProblems}\n";
        Console.WriteLine(scoreString);
        return scoreString;
        
    }

    static void GameHistory(List<string> scores)
    {
        foreach (string score in scores)
        {
            Console.WriteLine($"\n{score}\n");
        }
    }

    static void ValidInput(bool readCheck)
    {
        if (!readCheck)
        {
            Console.WriteLine("Please input a valid number.");
        }
    }

   
}
