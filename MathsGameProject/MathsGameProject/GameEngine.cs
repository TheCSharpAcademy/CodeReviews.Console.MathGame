namespace MathsGameProject
{
    internal static class GameEngine
    {
        private static int Game(int round, Enums.Dificulty dificultyLevel, Enums.GameTypes gameType)
        {
            int answer = 0;
            bool goodAnswer = MathsGameProject;
            int correct = 0;

            var result = Helpers.GetNumbers(gameType);
            int firstNumber = result[0];
            int secondNumber = result[1];

            string operationSymbol = gameType switch
            {
                Enums.GameTypes.addition => "+",
                Enums.GameTypes.subtraction => "-",
                Enums.GameTypes.multiplication => "*",
                Enums.GameTypes.division => "/",
                _ => "?"
            };
            do
            {
                goodAnswer = true;

                Console.Clear();
                Console.WriteLine($"rounds: {round} of {ConfigurationSettings.Rounds}      Dificulty Level: {dificultyLevel}      Operation: {gameType}      Game Type: {ConfigurationSettings.GameType}\n\n");
                Console.WriteLine($"The result of {firstNumber} {operationSymbol} {secondNumber} is ?");


                Console.Write("answer: ");
                var tupleAnswer = Helpers.GetGoodAnswer();
                goodAnswer = tupleAnswer.Item1;
                answer = tupleAnswer.Item2;
            } while (!goodAnswer);

            int correctAnswer = gameType switch
            {
                Enums.GameTypes.addition => firstNumber + secondNumber,
                Enums.GameTypes.subtraction => firstNumber - secondNumber,
                Enums.GameTypes.multiplication => firstNumber * secondNumber,
                Enums.GameTypes.division => firstNumber / secondNumber,
                _ => 0
            };

            if (answer == correctAnswer)
            {
                correct = 1;
                Console.WriteLine("   Correct!");
                Thread.Sleep(500);

            }
            else
            {
                Console.WriteLine($"   Incorrect! The correct answer is {correctAnswer}");
                Thread.Sleep(1000);
            }

            return (correct);

        }

        internal static void PlayGame()
        {
            int score = 0;
            Enums.GameTypes gameType = ConfigurationSettings.GameType;
            var time = DateTime.Now;
            for (int round = 1; round < ConfigurationSettings.Rounds + 1; round++)
            {
                if (ConfigurationSettings.GameType == Enums.GameTypes.Random)
                {
                    gameType = (Enums.GameTypes)(new Random()).Next(1, 5);
                }
                score += Game(round, ConfigurationSettings.DificultyLevel, gameType);
            }

            TimeSpan difference = DateTime.Now - time;
            string timeUsed = string.Format("{0:D2}:{1:D2}", difference.Minutes, difference.Seconds);
            Helpers.AddToHistroy(score, timeUsed);

            Console.WriteLine("\n\nRound completed ");
            Console.WriteLine($"you have answerd correclty {score} out of {ConfigurationSettings.Rounds}");
            Console.WriteLine($"your time taken has been {timeUsed}"); 
            Console.WriteLine(("\npress any key to return to the Main Menu"));
            Console.ReadKey();
        }
    }
}
