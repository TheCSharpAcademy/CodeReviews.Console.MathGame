using ConsoleMathGame.Models;

namespace ConsoleMathGame
{
    internal class GameEngine
    {
        Timer timer = new Timer();

        private void GameSetup(out string selectedMode, out int gamesToPlay, out Random random, string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Helpers.ChooseDifficulty();
            selectedMode = Helpers.diffLevel;
            gamesToPlay = Helpers.ChooseGames();
            random = new Random();
            timer.Start();
        }

        internal void AdditionGame(string message)
        {
            string selectedMode;
            int gamesToPlay, score = 0, firstNumber, secondNumber;
            Random random;
            GameSetup(out selectedMode, out gamesToPlay, out random, message);

            for (int i = 0; i < gamesToPlay; i++)
            {
                firstNumber = random.Next(Helpers.diffRange1, Helpers.diffRange2);
                secondNumber = random.Next(Helpers.diffRange1, Helpers.diffRange2);

                Console.WriteLine(firstNumber + " + " + secondNumber);

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect!");
                }
                if (i == (gamesToPlay - 1))
                {
                    Helpers.AddToHistory(score, GameType.Addition, selectedMode, timer.Stop(), gamesToPlay);
                    Console.Clear();
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine($"Game over. Your score was {score}/{gamesToPlay}.");
                    Console.WriteLine("---------------------------------");
                }
            }
        }

        internal void DivisionGame(string message)
        {
            string selectedMode;
            int gamesToPlay, score = 0;
            Random random;
            GameSetup(out selectedMode, out gamesToPlay, out random, message);

            for (int i = 0; i < gamesToPlay; i++)
            {
                var divisionNumbers = Helpers.GetDivisionNumbers();
                Console.WriteLine($"{divisionNumbers[0]} / {divisionNumbers[1]}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == divisionNumbers[0] / divisionNumbers[1])
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect!");
                }
                if (i == (gamesToPlay - 1))
                {
                    Helpers.AddToHistory(score, GameType.Division, selectedMode, timer.Stop(), gamesToPlay);
                    Console.Clear();
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine($"Game over. Your score is {score}/{gamesToPlay}");
                    Console.WriteLine("---------------------------------");
                }

            }
        }

        internal void MultiplicationGame(string message)
        {
            string selectedMode;
            int gamesToPlay, score = 0, firstNumber, secondNumber;
            Random random;
            GameSetup(out selectedMode, out gamesToPlay, out random, message);

            for (int i = 0; i < gamesToPlay; i++)
            {
                firstNumber = random.Next(Helpers.diffRange1, Helpers.diffRange2);
                secondNumber = random.Next(Helpers.diffRange1, Helpers.diffRange2);

                Console.WriteLine(firstNumber + " * " + secondNumber);

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect!");
                }
                if (i == (gamesToPlay - 1))
                {
                    Helpers.AddToHistory(score, GameType.Multiplication, selectedMode, timer.Stop(), gamesToPlay);
                    Console.Clear();
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine($"Game over. Your score was {score}/{gamesToPlay}");
                    Console.WriteLine("---------------------------------");
                }
            }
        }

        internal void SubstractionGame(string message)
        {
            string selectedMode;
            int gamesToPlay, score = 0, firstNumber, secondNumber;
            Random random;
            GameSetup(out selectedMode, out gamesToPlay, out random, message);

            for (int i = 0; i < gamesToPlay; i++)
            {
                firstNumber = random.Next(Helpers.diffRange1, Helpers.diffRange2);
                secondNumber = random.Next(Helpers.diffRange1, Helpers.diffRange2);

                Console.WriteLine(firstNumber + " - " + secondNumber);

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect!");
                }
                if (i == (gamesToPlay - 1))
                {
                    Helpers.AddToHistory(score, GameType.Substraction, selectedMode, timer.Stop(), gamesToPlay);
                    Console.Clear();
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine($"Game over. Your score was {score}/{gamesToPlay}.");
                    Console.WriteLine("---------------------------------");
                }
            }
        }

        internal void RandomizerGame(string message)
        {
            string selectedMode;
            int gamesToPlay, score = 0, firstNumber, secondNumber;
            Random random;
            GameSetup(out selectedMode, out gamesToPlay, out random, message);

            int playedGames = 0;

            while (gamesToPlay != playedGames)
            {
                int randomGame = random.Next(0, 4);

                switch (randomGame)
                {
                    case 0:
                        //Addition game
                        firstNumber = random.Next(Helpers.diffRange1, Helpers.diffRange2);
                        secondNumber = random.Next(Helpers.diffRange1, Helpers.diffRange2);

                        Console.WriteLine(firstNumber + " + " + secondNumber);

                        var result = Console.ReadLine();
                        result = Helpers.ValidateResult(result);

                        if (int.Parse(result) == firstNumber + secondNumber)
                        {
                            Console.WriteLine("Correct!");
                            score++;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect!");
                        }
                        playedGames++;
                        break;
                    case 1:
                        //Substraction game
                        firstNumber = random.Next(Helpers.diffRange1, Helpers.diffRange2);
                        secondNumber = random.Next(Helpers.diffRange1, Helpers.diffRange2);

                        Console.WriteLine(firstNumber + " - " + secondNumber);

                        result = Console.ReadLine();
                        result = Helpers.ValidateResult(result);

                        if (int.Parse(result) == firstNumber - secondNumber)
                        {
                            Console.WriteLine("Correct!");
                            score++;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect!");
                        }
                        playedGames++;
                        break;
                    case 2:
                        //Multiplication game
                        Menu.isMultiplicationOn = true;
                        firstNumber = random.Next(Helpers.diffRange1, Helpers.diffRange2);
                        secondNumber = random.Next(Helpers.diffRange1, Helpers.diffRange2);

                        Console.WriteLine(firstNumber + " * " + secondNumber);

                        result = Console.ReadLine();
                        result = Helpers.ValidateResult(result);

                        if (int.Parse(result) == firstNumber * secondNumber)
                        {
                            Console.WriteLine("Correct!");
                            score++;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect!");
                        }
                        Menu.isMultiplicationOn = false;
                        playedGames++;
                        break;
                    case 3:
                        //Division game
                        Menu.isDivisionOn = true;
                        var divisionNumbers = Helpers.GetDivisionNumbers();
                        firstNumber = divisionNumbers[0];
                        secondNumber = divisionNumbers[1];

                        Console.WriteLine($"{firstNumber} / {secondNumber}");

                        result = Console.ReadLine();
                        result = Helpers.ValidateResult(result);

                        if (int.Parse(result) == firstNumber / secondNumber)
                        {
                            Console.WriteLine("Correct!");
                            score++;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect!");
                        }
                        Menu.isDivisionOn = false;
                        playedGames++;
                        break;

                }

            }
            Helpers.AddToHistory(score, GameType.Randomizer, selectedMode, timer.Stop(), gamesToPlay);
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Game over. Your score was {score}/{gamesToPlay}.");
            Console.WriteLine("---------------------------------");
        }
    }
}
