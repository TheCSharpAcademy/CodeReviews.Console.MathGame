using System;

class Program
{

    public static void Main(string[] args)
    {
        List<Operation> previousGames = new List<Operation>();

        bool doUserStillWantToPlay = true;

        Console.WriteLine("Hello there! Welcome to this math game.");
        Console.WriteLine("Available commands: -Score -Menu");
        Console.WriteLine("Do you want to play?");
        Console.WriteLine("Type 'yes' if so. If not, type 'exit'.");

        while (doUserStillWantToPlay)
        {
            switch (Console.ReadLine())
            {
                case "yes":
                    StartGame();
                    break;
                case "exit":
                    doUserStillWantToPlay = false;
                    break;
            }
        }

        void StartGame()
        {
            Random rnd = new Random();
            int a = rnd.Next(1, 100);
            int b = rnd.Next(1, 100);

            int Add(int x, int y)
            {
                return x + y;
            }

            int Substract(int x, int y)
            {
                return x - y;
            }

            int Multiply(int x, int y)
            {
                return x * y;
            }

            int Divide(int x, int y)
            {
                return x / y;
            }

            void Menu()
            {
                Console.WriteLine("Math Game is a game in which you can choose one of the 4 basic operations, and you will have to solve a calc with that operation.");
                Console.WriteLine();
                Console.WriteLine("Choose a math operation");
                Console.WriteLine();
                Console.WriteLine("Addition (Type A)");
                Console.WriteLine("Substraction (Type S)");
                Console.WriteLine("Multiplication (Type M)");
                Console.WriteLine("Division (Type D)");
            }

            void AdditionGame()
            {
                Operation sum = new Operation();
                sum.Result = Add(a, b);
                sum.Calc = ($"{a} + {b}");
                Console.WriteLine("You have 15 seconds to solve this operation:");
                Console.WriteLine(sum.Calc);
                if (Console.ReadLine() == $"{sum.Result}")
                {
                    Console.WriteLine("Nice.");
                    sum.Score++;
                    UpdateStats(sum);
                    do
                    {
                        a = rnd.Next(1, 100);
                        b = rnd.Next(1, 100);
                    } while (a + b == sum.Calc[0]);
                    AdditionGame();
                }
                else
                {
                    Console.WriteLine("Wrong. If you typed a command, ignore this message.");
                    PlayWithoutIntro();
                    sum.Score--;
                }


            }

            void SubstractionGame()
            {
                Operation substraction = new Operation();
                Console.WriteLine("You have 15 seconds to solve this operation:");
                substraction.Result = Substract(a, b);
                substraction.Calc = ($"{a} - {b}");
                Console.WriteLine(substraction.Calc);

                if (Console.ReadLine() == $"{substraction.Result}")
                {
                    Console.WriteLine("Nice.");
                    substraction.Score++;
                    UpdateStats(substraction);
                    do
                    {
                        a = rnd.Next(1, 100);
                        b = rnd.Next(1, 100);
                    } while (a + b == substraction.Calc[0]);
                    SubstractionGame();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Wrong. If you typed a command, ignore this message.");
                    Console.WriteLine();
                    PlayWithoutIntro();
                    substraction.Score--;
                    UpdateStats(substraction);
                }
            }

            void MultiplicationGame()
            {
                Operation multiplication = new Operation();
                Console.WriteLine("You have 15 seconds to solve this operation:");
                multiplication.Result = Multiply(a, b);
                multiplication.Calc = ($"{a} * {b}");
                Console.WriteLine(multiplication.Calc);

                if (Console.ReadLine() == $"{multiplication.Result}")
                {
                    Console.WriteLine("Nice.");
                    multiplication.Score++;

                    do
                    {
                        a = rnd.Next(1, 100);
                        b = rnd.Next(1, 100);
                        UpdateStats(multiplication);
                    } while (a + b == multiplication.Calc[0]);
                    MultiplicationGame();
                }
                else
                {
                    Console.WriteLine("Wrong. If you typed a command, ignore this message.");
                    PlayWithoutIntro();
                    multiplication.Score--;
                    UpdateStats(multiplication);
                }



            }

            void DivisionGame()
            {
                Operation division = new Operation();
                Console.WriteLine("You have 15 seconds to solve this operation:");

                if (a % b != 0 || a == 1 || b == 1 || a == b)
                {
                    do
                    {
                        a = rnd.Next(1, 100);
                        b = rnd.Next(1, 100);
                    } while (a % b != 0 || a == 1 || b == 1 || a == b);
                }

                division.Result = Divide(a, b);
                division.Calc = ($"{a} / {b}");

                Console.WriteLine(division.Calc);

                if (Console.ReadLine() == $"{division.Result}")
                {
                    Console.WriteLine("Nice.");
                    division.Score++;
                    UpdateStats(division);
                    do
                    {
                        a = rnd.Next(1, 100);
                        b = rnd.Next(1, 100);
                    } while (a + b == division.Calc[0]);
                    DivisionGame();
                }
                else
                {
                    Console.WriteLine("Wrong. If you typed a command, ignore this message.");
                    PlayWithoutIntro();
                    division.Score--;
                    UpdateStats(division);
                }
            }

            void UpdateStats(Operation operation)
            {
                previousGames.Add(new Operation
                {
                    Score = operation.Score,
                    Result = operation.Result,
                    Calc = operation.Calc
                });
            }

            void ShowScore()
            {
                if (previousGames.Count != 0)
                {
                    foreach (var items in previousGames)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"This is your score: {items.Score}");
                        Console.WriteLine($"The calc(s) you solved: {items.Calc}");
                        Console.WriteLine($"Its result: {items.Result}");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("You don't have any score.");
                }

            }

            Play();

            void Play()
            {
                Menu();
                switch (Console.ReadLine())
                {

                    case "A":
                        AdditionGame();
                        break;
                    case "S":
                        SubstractionGame();
                        break;
                    case "M":
                        MultiplicationGame();
                        break;
                    case "D":
                        DivisionGame();
                        break;
                    case "Score":
                        ShowScore();
                        break;
                    case "Menu":
                        Menu();
                        break;
                    default:
                        break;

                }
            }

            void PlayWithoutIntro()
            {
                Console.WriteLine("Choose a math operation");
                Console.WriteLine();
                Console.WriteLine("Addition (Type A)");
                Console.WriteLine("Substraction (Type S)");
                Console.WriteLine("Multiplication (Type M)");
                Console.WriteLine("Division (Type D)");
                switch (Console.ReadLine())
                {
                    case "A":
                        AdditionGame();
                        break;
                    case "S":
                        SubstractionGame();
                        break;
                    case "M":
                        MultiplicationGame();
                        break;
                    case "D":
                        DivisionGame();
                        break;
                    case "Score":
                        ShowScore();
                        break;
                    case "Menu":
                        Menu();
                        break;
                    default:
                        Console.WriteLine("Inexistent operation");

                        break;
                }
            }

            if (Console.ReadLine() == "Score")
            {
                ShowScore();
            }

            if (Console.ReadLine() == "Menu")
            {
                Play();
            }

        }
    }

    class Operation
    {
        public int Result { get; set; }
        public string Calc { get; set; }
        public int Score { get; set; }
        
    }


}