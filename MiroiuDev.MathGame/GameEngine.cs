namespace MiroiuDev.MathGame;

enum Difficulty
{
    Easy,
    Medium,
    Hard
}

internal class GameEngine
{
    internal int NumberOfQuestions { get; set; } = 5;
    internal Difficulty Difficulty { get; set; } = Difficulty.Easy;

    internal void PlayGame(GameType type, Func<(int, int), int> operation, Func<(int, int)> generateNumber)
    {
        var start = DateTime.Now;
        var score = 0;

        for (int i = 0; i < NumberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine($"{type} Game");

            var numbers = generateNumber();

            int result = operation(numbers);

            var input = Helpers.ValidateResult();

            var answer = int.Parse(input);

            if (answer == result)
            {
                Console.WriteLine("You answered correctly! Type any key for the next question");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect! Type any key for the next question");
                Console.ReadLine();
            }
        }

        Helpers.AddToHistory(new Game
        {
            Date = DateTime.Now,
            Score = score,
            Type = type
        });

        var end = DateTime.Now;

        var elapsed = (int) (end - start).TotalSeconds;

        Console.WriteLine($"Game over. It took you {elapsed}s to finish. Your final score is {score}. Press any key to return to main menu.");

        Console.ReadLine();
    }

    internal int GetDifficulty() => Difficulty switch
    {
        Difficulty.Easy => 9,
        Difficulty.Medium => 50,
        Difficulty.Hard => 100,
        _ => 9,
    };
}
