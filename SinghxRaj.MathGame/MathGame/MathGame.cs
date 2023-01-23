namespace SinghxRaj.MathGame.MathGame;

abstract class MathGame
{
    public int Points { get; set; } = 0;
    public DateTime GameTime { get; set; } = DateTime.Now;
    public void PlayGame()
    {
        Random random = new();
        bool isPlaying = true;
        do
        {
            int operand1 = random.Next(1, 21);
            int operand2 = random.Next(1, 21);
            string symbol = GetOperator();
            double answer = Math.Round(Compute(operand1, operand2), 2);
            Console.WriteLine($"What is {operand1} {symbol} {operand2}? (Rounded to 2 decimal places)");
            string? guessInput = Console.ReadLine();
            double guess;
            while (!double.TryParse(guessInput, out guess))
            {
                Console.WriteLine("Must be a number. Try again.");
                guessInput = Console.ReadLine();
            }
            if (guess != answer)
            {
                isPlaying = false;
                Console.WriteLine($"Wrong, the correct answer is {answer}");
            }
            else
            {
                Points++;
                Console.WriteLine("Right!");
            }
        } while (isPlaying);
        Console.WriteLine($"Game over. You stored {Points} points in the game.");
    }

    public abstract string GetOperator();

    public abstract double Compute(int operand1, int operand2);
}
