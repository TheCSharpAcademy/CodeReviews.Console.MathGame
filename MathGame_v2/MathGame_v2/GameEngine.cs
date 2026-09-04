using MathGame_v2.Model;

namespace MathGame_v2
{
    internal class GameEngine
    {
        internal void ChosenGame(string? chosenGame)
        {
            Console.Clear();
            Random random = new();
            int number1;
            int number2;
            int score = 0;

            string? mathOperation = chosenGame.ToLower() switch
            {
                "a" => "+",
                "s" => "-",
                "m" => "*",
                "d" => "/"
            };

            for (int i = 0; i < 5; i++)
            {
                number1 = mathOperation != "/" ? random.Next(1, 9) : random.Next(1, 99);
                number2 = mathOperation != "/" ? random.Next(1, 9) : random.Next(1, 99);

                if(mathOperation == "/")
                {
                    int[] divisibleNumbers = Helper.GetDivisibleNumbers();
                    number1 = divisibleNumbers[0];
                    number2 = divisibleNumbers[1];
                }

                Console.WriteLine($"{number1} {mathOperation} {number2}");
                string? answer = Console.ReadLine();

                answer = Helper.ValidateResult(answer);

                int correctAnswer = 0;

                switch (mathOperation)
                {
                    case "+":
                        correctAnswer = number1 + number2;
                        break;
                    case "-":
                        correctAnswer = number1 - number2;
                        break;
                    case "*":
                        correctAnswer = number1 * number2;
                        break;
                    case "/":
                        correctAnswer = number1 / number2;
                        break;
                }
                
                if (Int32.Parse(answer) == correctAnswer)
                {
                    Console.WriteLine("Correct!");
                    score++;                }
                else
                {
                    Console.WriteLine($"Incorrect! Answer is {correctAnswer}");
                }
                Console.WriteLine("Press any key for the next question.");
                Console.ReadLine();
                if (i == 4)
                {
                    Console.WriteLine($"Your score is {score}/{i + 1}");
                    Helper.AddLog(GameType.Addition, score);
                    Console.WriteLine("Press any key to return to the menu.");
                    Console.ReadLine();
                }
                
            }
        }
        internal void ViewResultsHistory()
        {
            Console.Clear();
            Helper.ViewGameHistory();
            Console.WriteLine("Press any key to return to menu.");
            Console.ReadLine();
        }
    }
}
