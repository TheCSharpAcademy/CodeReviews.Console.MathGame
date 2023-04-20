namespace MathGame.barakisbrown.Problems;

internal class Multiplication : IProblem
{
    private readonly Random _random = new();
    Model IProblem.Calc(Diffuclty_Levels levels)
    {
        int score = 0;
        bool quit = false;
        do
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Multiplication Game");
            int left = _random.Next(0, (int)levels + 1);
            int right = _random.Next(0, (int)levels + 1);
            int actualAnswer = left * right;
            var problem = string.Format("{0} * {1}", left, right);

            Console.WriteLine(problem);
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
            Type = GameType.Multiplication,
            Levels = levels,
            Score = score,
            Date = DateTime.Now
        };
    }
}
