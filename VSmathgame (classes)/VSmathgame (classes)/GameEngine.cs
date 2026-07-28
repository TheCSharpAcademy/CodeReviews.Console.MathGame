using VSmathgame__classes_.Models;

namespace VSmathgame__classes_
{

    internal class GameEngine
    {
        //public GameEngine(string name, DateTime date);


        internal void Addition(string message)
        {
            Random dice = new Random();
            int score = 0;

            int a;
            int b;

            for (int i = 0; i < 5; i++)
            {

                bool isValid = false;

                a = dice.Next(1, 21);
                b = dice.Next(1, 21);
                Console.WriteLine(message);
                Console.WriteLine($"What is {a} + {b}?");
                do
                {
                    string? answer = Console.ReadLine();

                    if (int.TryParse(answer, out int correct))
                    {
                        if (correct == a + b)
                        {
                            score++;
                            Console.WriteLine("Correct!\nPress any key to proceed.");
                            Console.ReadLine();
                            isValid = true;
                            Console.Clear();

                        }
                        else
                        {
                            Console.WriteLine("Incorrect, press any key to go to the next question.");
                            Console.ReadLine();
                            isValid = true;
                            Console.Clear();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, enter a valid number");
                        Console.WriteLine($"What is {a} + {b}?");
                        isValid = false;

                    }

                } while (!isValid);

                if (i == 4)
                {
                    Console.WriteLine($"Your final score is {score}");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Addition);


            if (score == 5)
            {
                Console.WriteLine($"You acheived maximum points of {score} congratulations!\nPress any key to return to the main menu.");

            }

        }

        internal void Subtraction(string message)
        {
            Random dice = new Random();
            int score = 0;
            int a = 0;
            int b = 0;

            for (int i = 0; i < 5; i++)
            {
                bool isValid = false;


                a = dice.Next(13, 41);
                b = dice.Next(1, 21);

                do
                {
                    Console.WriteLine(message);
                    Console.WriteLine($"What is {a} - {b}?");

                    string? answer = Console.ReadLine();

                    if (int.TryParse(answer, out int correct))
                    {
                        if (correct == a - b)
                        {
                            score++;
                            Console.WriteLine("Correct!\nPress any key to go to the next question.");
                            Console.Clear();
                            isValid = true;
                        }

                        else
                        {
                            Console.WriteLine("Incorrect, press any key to go to the next question.");
                            Console.Clear();
                            isValid = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please enter a number.");
                        Console.Clear();
                        isValid = false;
                    }

                    if (i == 4)
                    {
                        Console.WriteLine($"Your final score is {score}\nThanks for playing!\nPress any key to return to the main menu.");
                        Console.ReadLine();
                    }
                } while (!isValid);

                Helpers.AddToHistory(score, GameType.Subtraction);

            }
        }

        internal void Multiplication(string message)
        {
            Random dice = new Random();

            int score = 0;
            int a = 0;
            int b = 0;

            for (int i = 0; i < 5; i++)
            {
                bool isValid = true;

                a = dice.Next(1, 21);
                b = dice.Next(1, 21);

                do
                {

                    Console.WriteLine($"What is {a} x {b}?");
                    Console.WriteLine(message);

                    string? answer = Console.ReadLine();

                    if (int.TryParse(answer, out int correct))
                    {
                        if (correct == a * b)
                        {
                            score++;
                            Console.WriteLine("Correct!\nPress any key to go to the next question.");
                            Console.ReadLine();
                            Console.Clear();
                            isValid = true;
                        }

                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Incorrect, press any key to go to the next question.");
                            Console.ReadLine();
                            isValid = false;
                        }


                        if (i == 4)
                        {
                            Console.WriteLine($"Your final score is {score}\n\nPress any key to return to the main menu.");
                            Console.ReadLine();
                        }
                    }
                } while (!isValid);
                Helpers.AddToHistory(score, GameType.Multiplication);
            }
        }

        internal void Division(string message)
        {
            int score = 0;

            for (int i = 0; i < 5; i++)
            {

                bool isValid = false;

                var divisionNumbers = Helpers.getDivisionNumbers();
                var first = divisionNumbers[0];
                var second = divisionNumbers[1];


                do
                {
                    Console.WriteLine(message);

                    Console.WriteLine($"What is {first} ÷ {second}?");

                    string? result = Console.ReadLine();

                    if (int.TryParse(result, out int correct))
                    {

                        if (correct == first / second)
                        {
                            score++;
                            Console.WriteLine("Correct!\nPress any key to go to the next question.");
                            Console.ReadLine();
                            isValid = true;
                            Console.Clear();

                        }

                        else
                        {
                            Console.WriteLine("Incorrect, press any key to go to the next question.");
                            Console.ReadLine();
                            isValid = true;
                            Console.Clear();


                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input please enter a number.");
                        Console.ReadLine();

                        isValid = false;
                        Console.Clear();
                    }

                    Console.ReadLine();



                    if (i == 4)
                    {
                        Console.WriteLine($"Your final score is {score}\nThanks for playing!\nPress any key to return to the main menu.");
                        Console.ReadLine();
                    }

                } while (!isValid);


                if (score == 5)
                {
                    Console.WriteLine($"You acheived maximum points of {score} congratulations!");

                }


                Helpers.AddToHistory(score, GameType.Division);



            }
        }
    }
}
