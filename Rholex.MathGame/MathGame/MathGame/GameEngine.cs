using MathGame.Model;
namespace MathGame
{
    internal class GameEngine
    {
        Random random = new Random();
        internal void AdditionGame(string name, GameDifficulty difficulty, int rounds)
        {
            Console.Clear();

            int score = 0;

            for (int i = 1; i <= rounds; i++)
            {
                int[] numbers = Helpers.GetNumbers(GameType.Addition, difficulty);

                Console.WriteLine($"{name}: {numbers[0]} + {numbers[1]}");
                var answer = Console.ReadLine();
                answer = Helpers.ValidateResult(answer);

                if (int.Parse(answer) == numbers[0] + numbers[1])
                {
                    Console.WriteLine("Your answer was correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("You answer was incorrect!");
                }
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine($"Game Over! Your score is: {score}pts out of {rounds}pts.");
            Console.WriteLine("Press any key to return to Main Menu.");
            Helpers.AddToRecords(score, GameType.Addition, rounds, difficulty);
            Console.Clear();
        }

        internal void SubtractionGame(string name, GameDifficulty difficulty, int rounds)
        {
            Console.Clear();

            int score = 0;
            
            for (int i = 1; i<= rounds; i++)
            {
                int[] numbers = Helpers.GetNumbers(GameType.Subtraction, difficulty);
                Console.WriteLine($"{name}: {numbers[0]} - {numbers[1]}");
                var answer = Console.ReadLine();
                answer = Helpers.ValidateResult(answer);

                if (int.Parse(answer) == numbers[0] - numbers[1])
                {
                    Console.WriteLine("Your answer was correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("You answer was incorrect!");
                }
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine($"Game Over! Your score is: {score}pts out of {rounds}pts.");
            Console.WriteLine("Press any key to return to Main Menu.");
            Helpers.AddToRecords(score, GameType.Subtraction, rounds, difficulty);
            Console.Clear();
        }

        internal void MultiplicationGame(string name, GameDifficulty difficulty, int rounds)
        {
            Console.Clear();

            int score = 0;

            for (int i = 1; i <= rounds; i++) 
            { 
                int[] numbers = Helpers.GetNumbers(GameType.Multiplication, difficulty);
                Console.WriteLine($"{name}: {numbers[0]} * {numbers[1]}");
                var answer = Console.ReadLine();
                answer = Helpers.ValidateResult(answer);

                if (int.Parse(answer) == numbers[0] * numbers[1])
                {
                        Console.WriteLine("Your answer was correct!");
                        score++;
                }
                else
                {
                    Console.WriteLine("You answer was incorrect!");
                }
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine($"Game Over! Your score is: {score}pts out of {rounds}pts.");
            Console.WriteLine("Press any key to return to Main Menu.");
            Helpers.AddToRecords(score, GameType.Multiplication, rounds, difficulty);
            Console.Clear();
        }

        internal void DivisionGame(string name, GameDifficulty difficulty, int rounds)
        {
            Console.Clear();

            int score = 0;
            for (int i = 1; i < rounds; i++)
            {
                int[] numbers = Helpers.GetNumbers(GameType.Division, difficulty);
                Console.WriteLine($"{name}: {numbers[0]} / {numbers[1]}");
                var answer = Console.ReadLine();
                answer = Helpers.ValidateResult(answer);

                if (int.Parse(answer) == numbers[0] / numbers[1])
                {
                    Console.WriteLine("Your answer was correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("You answer was incorrect!");
                }
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine($"Game Over! Your score is: {score}pts out of {rounds}pts.");
            Console.WriteLine("Press any key to return to Main Menu.");
            Helpers.AddToRecords(score, GameType.Division, rounds, difficulty);
            Console.Clear();
        }   
    }
}
