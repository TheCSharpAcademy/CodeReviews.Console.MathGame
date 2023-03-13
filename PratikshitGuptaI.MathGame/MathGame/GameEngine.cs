using MathGame.Models;

namespace MathGame
{
    internal class GameEngine
    {

        internal static void AdditionGame(GameType message,int totalQuestion)
        {
            Console.WriteLine($"{message} Game is Added");
            var random = new Random();
            int score = 0;
            int firstnumber;
            int secondnumber;
            for (int i = 0; i < totalQuestion; i++)
            {
                firstnumber = random.Next(1, 9);
                secondnumber = random.Next(1, 9);
                Console.WriteLine($"{firstnumber} + {secondnumber}");
                var result = Console.ReadLine();
                result=Helpers.ValidateResult(result);
                if (int.Parse(result) == (firstnumber + secondnumber)) { Console.WriteLine("Correct Bruh,One point to Gryffindor"); score++; }
                else Console.WriteLine("Incorrect Re!");

                if (i == totalQuestion-1)
                    Console.Clear(); Console.WriteLine($"Game Over.Your Final Score is {score} out of {totalQuestion};If want to play more,Press any key.....");
            }
            Helpers.AddToHistory(score,message, totalQuestion);
        }
        internal static void SubtractionGame(GameType message, int totalQuestion)
        {
            Console.WriteLine($"{message} Game is Added");
            var random = new Random();
            int score = 0;
            int firstnumber;
            int secondnumber;

            for (int i = 0; i < totalQuestion; i++)
            {
                firstnumber = random.Next(1, 9);
                secondnumber = random.Next(1, 9);
                Console.WriteLine($"{firstnumber} - {secondnumber}");
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);
                if (int.Parse(result) == (firstnumber - secondnumber)) { Console.WriteLine("Correct Bruh,One point to Gryffindor"); score++; }
                else Console.WriteLine("Incorrect Re!");

                if (i == totalQuestion-1) Console.WriteLine($"Game Over.Your Final Score is {score} out of {totalQuestion};If want to play more,Press any key.....");
            }
            Helpers.AddToHistory(score, message,totalQuestion);
        }
        internal static void MultiplicationGame(GameType message, int totalQuestion)
        {
            Console.WriteLine($"{message} Game is Added");
            var random = new Random();
            int score = 0;
            int firstnumber;
            int secondnumber;

            for (int i = 0; i < totalQuestion; i++)
            {
                firstnumber = random.Next(1, 9);
                secondnumber = random.Next(1, 9);
                Console.WriteLine($"{firstnumber} X {secondnumber}");
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);
                if (int.Parse(result) == (firstnumber * secondnumber)) { Console.WriteLine("Correct Bruh,One point to Gryffindor"); score++; }
                else Console.WriteLine("Incorrect Re!");

                if (i == totalQuestion-1) Console.WriteLine($"Game Over.Your Final Score is {score} out of {totalQuestion} ;If want to play more,Press any key.....");
            }
            Helpers.AddToHistory(score, message, totalQuestion);
        }
        internal static void DivisionGame(GameType message, int totalQuestion)
        {
            Console.WriteLine($"{message} Game is Added");
            int score = 0;

            for (int i = 0; i < totalQuestion; i++)
            {
                var divisionNumbers = Helpers.GetDivisionNumbers();
                var firstnumber = divisionNumbers[0];
                var secondnumber = divisionNumbers[1];

                Console.WriteLine($"{firstnumber} / {secondnumber}");
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);
                if (int.Parse(result) == (firstnumber / secondnumber)) { Console.WriteLine("Correct Bruh,One point to Gryffindor"); score++; }
                else Console.WriteLine("Incorrect Re!");

                if (i == totalQuestion - 1) Console.WriteLine($"Game Over.Your Final Score is {score} out of  {totalQuestion};If want to play more,Press any key.....");

            }
            Helpers.AddToHistory(score, message, totalQuestion);

            /*var random = new Random();
            int score = 0;
            int firstnumber;
            int secondnumber;

            for (int i = 0; i < 5; i++)
            {
                firstnumber = random.Next(1, 9);
                secondnumber = random.Next(1, 9);
                Console.WriteLine(message);
                Console.WriteLine($"{firstnumber} / {secondnumber}");
                var result = Console.ReadLine();
                if (int.Parse(result) == (firstnumber / secondnumber)) { Console.WriteLine("Correct Bruh,One point to Gryffindor"); score++; }
                else Console.WriteLine("Incorrect Re!");

                if (i == 4) Console.WriteLine($"Game Over.Your Final Score is {score}");
            }*/
        }

    }
}
