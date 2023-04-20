namespace MathGame.barakisbrown.Problems
{
    internal class RandomGame : IProblem
    {
        private readonly Random _random = new();
        private readonly char[] operation_list = { '+', '-', '*', '/' };

        Model IProblem.Calc(Diffuclty_Levels levels)
        {
            bool quit = false;
            int score = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Random Game");
                Console.WriteLine("Each game will be a different type of game");
                Console.WriteLine("Ranging from Additon to Divison");
                Console.WriteLine();

                int randomOption = _random.Next(0, operation_list.Length);
                char opUsed = operation_list[randomOption];
                int actualAnswer = 0;
                int left;
                int right;

                if (opUsed == '/')
                {
                    left = _random.Next(0, 101);
                    right = _random.Next(1, (int)levels + 1);
                }
                else
                {
                    left = _random.Next(0, (int)levels + 1);
                    right = _random.Next(0, (int)levels + 1);
                }

                Console.WriteLine($"Welcome to the {Enum.GetName(typeof(GameType), randomOption)}");
                
                var problem = string.Format("{0} {1} {2}", left, opUsed, right);
                Console.WriteLine(problem);

                switch(opUsed)
                {
                    case '+':
                        actualAnswer = left + right;
                        break;
                    case '-':
                        actualAnswer = left - right;
                        break;
                    case '*':
                        actualAnswer = left * right;
                        break;
                    case '/':
                        actualAnswer = left / right;
                        break;
                }

                Console.Write("Guess => ");

                var guess = Console.ReadLine();
                guess = Helpers.ValidateResults(guess, "Guess => ");
                int userAnswer = Helpers.ConvertToInt(guess);

                bool correct = (userAnswer == actualAnswer);

                if (correct)
                {
                    score++;
                    Console.WriteLine("Congrats. You guess the right answer");
                }
                else
                {
                    Console.WriteLine($"Sorry, Your answer was incorrect. The actualy answer was {actualAnswer} ");
                }

                Console.Write("Play Again (Y/N)");


                char key = Console.ReadKey(true).KeyChar;

                if (key == 'n' || key == 'N')
                    quit = true;

            } while (!quit);

            return new Model
            {
                Type = GameType.RandomOperations,
                Levels = levels,
                Score = score,
                Date = DateTime.Now
            };
        }
    }
}
