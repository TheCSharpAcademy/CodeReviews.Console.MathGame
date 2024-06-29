using MathGame.gsharshavardhan.Models;

namespace MathGame.gsharshavardhan;

internal class GameEngine
{
    internal void AdditionGame(string v)
    {

        var random = new Random();
        var score = 0;
        var rounds = 5;
        int firstNumber;
        int secondNumber;

        for (int i = 0; i < rounds; i++)
        {
            Console.Clear();
            Console.WriteLine(v);

            var nextRoundPrompt = i != rounds - 1 ? "Press any key for the next question." : "\nGame over.";

            firstNumber = random.Next(1, 100);
            secondNumber = random.Next(1, 100);

            Console.WriteLine($"{firstNumber} + {secondNumber}");
            var result = Helpers.ParseResult();

            if (result == firstNumber + secondNumber)
            {
                Console.WriteLine($"Right Answer! {nextRoundPrompt}");
                score++;
            }
            else
            {
                Console.WriteLine($"Wrong Answer! {nextRoundPrompt}");
            }

            if (i == rounds - 1) { Console.WriteLine($"Your score is {score}. Press any key to go back to the menu."); }

            Console.ReadKey(true);
        }
        Helpers.AddToGameHistory(GameType.Addition, score);
        Console.Clear();
    }
    internal void SubtractionGame(string v)
    {


        var random = new Random();
        var score = 0;
        var rounds = 5;
        int firstNumber;
        int secondNumber;

        for (int i = 0; i < rounds; i++)
        {
            Console.Clear();
            Console.WriteLine(v);

            var nextRoundPrompt = i != rounds - 1 ? "Press any key for the next question." : "\nGame over.";

            firstNumber = random.Next(1, 100);
            secondNumber = random.Next(1, 100);

            Console.WriteLine($"{firstNumber} - {secondNumber}");
            var result = Helpers.ParseResult();

            if (result == firstNumber - secondNumber)
            {
                Console.WriteLine($"Right Answer! {nextRoundPrompt}");
                score++;
            }
            else
            {
                Console.WriteLine($"Wrong Answer! {nextRoundPrompt}");
            }

            if (i == rounds - 1)
            {
                Console.WriteLine($"Your score is {score}. Press any key to go back to the menu.");

            }
            Console.ReadKey(true);
        }
        Helpers.AddToGameHistory(GameType.Subtraction, score);
        Console.Clear();
    }
    internal void MultiplicationGame(string v)
    {
        Console.WriteLine(v);

        var random = new Random();
        var score = 0;
        var rounds = 5;
        int firstNumber;
        int secondNumber;

        for (int i = 0; i < rounds; i++)
        {
            Console.Clear();
            Console.WriteLine(v);

            var nextRoundPrompt = i != rounds - 1 ? "Press any key for the next question." : "\nGame Over.";

            firstNumber = random.Next(1, 100);
            secondNumber = random.Next(1, 100);

            Console.WriteLine($"{firstNumber} * {secondNumber}");
            var result = Helpers.ParseResult();

            if (result == firstNumber * secondNumber)
            {
                Console.WriteLine($"Right Answer! {nextRoundPrompt}");
                score++;
            }
            else
            {
                Console.WriteLine($"Wrong Answer! {nextRoundPrompt}");
            }

            if (i == rounds - 1)
            {
                Console.WriteLine($"Your score is {score}. Press any key to go back to the menu.");
            }

            Console.ReadKey(true);
        }
        Helpers.AddToGameHistory(GameType.Multiplication, score);
        Console.Clear();
    }
    internal void DivisionGame(string v)
    {
        Console.WriteLine(v);
        var score = 0;
        var rounds = 5;

        for (int i = 0; i < rounds; i++)
        {
            Console.Clear();
            Console.WriteLine(v);

            var nextRoundPrompt = (i != rounds - 1 ? "Press any key for the next question." : "\nGame Over.");

            var divisonNumbers = Helpers.GetDivisionNumbers();
            var firstNumber = divisonNumbers[0];
            var secondNumber = divisonNumbers[1];

            Console.WriteLine($"{firstNumber} / {secondNumber}");
            var result = Helpers.ParseResult();

            if (result == firstNumber / secondNumber)
            {
                Console.WriteLine($"Right Answer! {nextRoundPrompt}");
                score++;
            }
            else
            {
                Console.WriteLine($"Wrong Answer!{nextRoundPrompt}");
            }

            if (i == rounds - 1)
            {
                Console.WriteLine($"Your score is {score}. Press any key to go back to the menu.");
            }
            Console.ReadKey(true);
        }
        Helpers.AddToGameHistory(GameType.Division, score);
        Console.Clear();

    }
}
