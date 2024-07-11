internal class Program
{
    private static void Main(string[] args)
    {
        List<string> gameList = new List<string>();

        GameSetup();


        void GameSetup()
        {
            Random numberGen = new Random(); 
            int firstNumber = numberGen.Next(1, 101);
            int secondNumber = numberGen.Next(firstNumber);
            int questionAnswer = 0;
            char chosenOperator = ' ';

            Console.WriteLine("Please choose one of the following: \n 1 for +\n 2 for -\n 3 for *\n 4 for /\n or 5 for a random game");
            string userOperatorChoice = Console.ReadLine();

            if (!int.TryParse(userOperatorChoice, out int parsedOperator))
            {
                GameSetup();
            }

            if (parsedOperator > 0 && parsedOperator < 6)
            {
                if (parsedOperator == 4)
                {
                    while (firstNumber % secondNumber != 0)
                    {
                        firstNumber = numberGen.Next(1, 101);
                        secondNumber = numberGen.Next(firstNumber);
                    }
                }

                if (parsedOperator == 5)
                {
                    parsedOperator = numberGen.Next(1, 5);
                }

                switch (parsedOperator)
                {
                    case 1: questionAnswer = firstNumber + secondNumber; chosenOperator = (char)43; break;
                    case 2: questionAnswer = firstNumber - secondNumber; chosenOperator = (char)45; break;
                    case 3: questionAnswer = firstNumber * secondNumber; chosenOperator = (char)42; break;
                    case 4: questionAnswer = firstNumber / secondNumber; chosenOperator = (char)47; break;
                }
            }
            else
            {
                GameSetup();
            }
            QuestionToUser(firstNumber, secondNumber, questionAnswer, chosenOperator);
        }

        void QuestionToUser(int firstNumber, int secondNumber, int questionTotal, char chosenOperator)
        {
            Console.WriteLine($"\nWhat is {firstNumber} {chosenOperator} {secondNumber}?");
            string userAnswer = Console.ReadLine();

            if (!int.TryParse(userAnswer, out int parsedUserAnswer))
            {
                Console.WriteLine("\n\nSorry, you didn't enter a number. Try again\n\n");
                GameSetup();
            }

            gameList.Add($"{firstNumber} {chosenOperator} {secondNumber} = {questionTotal}. You answered {userAnswer}.\n");

            if (parsedUserAnswer == questionTotal)
            {
                Console.WriteLine($"\nThat is correct!\n{firstNumber} {chosenOperator} {secondNumber} = {questionTotal}\n");
            }
            else
            {
                Console.WriteLine("\nSorry that is incorrect. The correct answer was " + questionTotal);
            }
            PlayAgain();
        }

        void PlayAgain()
        {
            Console.WriteLine("\nWould you like to play again?  Y / N");
            string playAgain = Console.ReadLine();
            if (playAgain.ToUpper() == "Y")
            {
                Console.Clear();
                GameSetup();
            }
            else if (playAgain.ToUpper() == "N")
            {
                Console.WriteLine("\nWould you like a list of your games?  Y / N");
                string showGamesList = Console.ReadLine();
                if (showGamesList.ToUpper() == "Y")
                {
                    Console.Clear();
                    DisplayListOfGames();
                }
                Console.WriteLine("\n\nGoodbye.");
            }
            else
            {
                PlayAgain();
            }
        }

        void DisplayListOfGames()
        {
            gameList.ForEach(game => Console.WriteLine(game));
        }
    }
}
