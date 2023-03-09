using ConsoleMathGame.Models;
using System.Drawing;
using System.Net.Sockets;

namespace ConsoleMathGame
{
    internal class GameEngine
    {
        Timer timer = new Timer();

        internal void AdditionGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("---------------------------------");

            Helpers.ChooseDifficulty();
            var selectedMode = Helpers.diffLevel;
            GameMode selectedMode2 = (GameMode)Enum.Parse(typeof(GameMode), selectedMode);

            int gamesToPlay = Helpers.ChooseGames();
            timer.Start();

            var random = new Random();
            var score = 0;
            int firstNumber;
            int secondNumber;

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
                if (i == (gamesToPlay-1))
                {
                    Helpers.AddToHistory(score, GameType.Addition, selectedMode2, timer.Stop(), gamesToPlay);
                    Console.Clear();
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine($"Game over. Your score was {score}/{gamesToPlay}.");
                    Console.WriteLine("---------------------------------");
                }
            }
        }

        internal void DivisionGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("---------------------------------");

            Helpers.ChooseDifficulty();
            var selectedMode = Helpers.diffLevel;
            GameMode selectedMode2 = (GameMode)Enum.Parse(typeof(GameMode), selectedMode);

            int gamesToPlay = Helpers.ChooseGames();
            timer.Start();

            var score = 0;

            for (int i = 0; i < gamesToPlay; i++)
            {

                var divisionNumbers = Helpers.GetDivisionNumbers();
                var firstNumber = divisionNumbers[0];
                var secondNumber = divisionNumbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");

                var result = Console.ReadLine();
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
                if (i == (gamesToPlay-1))
                {
                    Helpers.AddToHistory(score, GameType.Division, selectedMode2, timer.Stop(), gamesToPlay);
                    Console.Clear();
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine($"Game over. Your score is {score}/{gamesToPlay}");
                    Console.WriteLine("---------------------------------");
                }

            }
        }

        internal void MultiplicationGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("---------------------------------");

            Helpers.ChooseDifficulty();

            var selectedMode = Helpers.diffLevel;
            GameMode selectedMode2 = (GameMode)Enum.Parse(typeof(GameMode), selectedMode);

            int gamesToPlay = Helpers.ChooseGames();

            timer.Start();

            var random = new Random();
            var score = 0;
            int firstNumber;
            int secondNumber;

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
                    Helpers.AddToHistory(score, GameType.Multiplication, selectedMode2, timer.Stop(), gamesToPlay);
                    Console.Clear();
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine($"Game over. Your score was {score}/{gamesToPlay}");
                    Console.WriteLine("---------------------------------");
                }
            }
        }

        internal void SubstractionGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("---------------------------------");

            Helpers.ChooseDifficulty();
            var selectedMode = Helpers.diffLevel;
            GameMode selectedMode2 = (GameMode)Enum.Parse(typeof(GameMode), selectedMode);

            int gamesToPlay = Helpers.ChooseGames();
            timer.Start();

            var random = new Random();
            var score = 0;
            int firstNumber;
            int secondNumber;

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
                    Helpers.AddToHistory(score, GameType.Substraction, selectedMode2, timer.Stop(), gamesToPlay);
                    Console.Clear();
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine($"Game over. Your score was {score}/{gamesToPlay}.");
                    Console.WriteLine("---------------------------------");
                }
            }
        }

        internal void RandomizerGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("---------------------------------");

            Helpers.ChooseDifficulty();
            var selectedMode = Helpers.diffLevel;
            GameMode selectedMode2 = (GameMode)Enum.Parse(typeof(GameMode), selectedMode);

            int gamesToPlay = Helpers.ChooseGames();
            timer.Start();

            var random = new Random();
            var score = 0;
            int firstNumber;
            int secondNumber;

            int playedGames = 0;

            while (gamesToPlay != playedGames)
            {
                int randomGame = random.Next(0, 4);

                switch(randomGame)
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
            Helpers.AddToHistory(score, GameType.Randomizer, selectedMode2, timer.Stop(), gamesToPlay);
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Game over. Your score was {score}/{gamesToPlay}.");
            Console.WriteLine("---------------------------------");
        }
    }
}
