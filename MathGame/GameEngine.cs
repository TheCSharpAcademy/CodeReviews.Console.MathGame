using System.Reflection.PortableExecutable;

namespace MathGame
{
    internal class GameEngine
    {
        public string PlayerName { get; private set; }
        public int PlayerScore { get; private set; }
        private Random Rand { get; init; }
        public List<(DateTime Date, char operation, int Score)> GamesHistoryList { get; private set; }

        public GameEngine()
        {
            Rand = new Random();
            PlayerScore = 0;
            GamesHistoryList = new List<(DateTime, char, int)>();
        }
        public void Start()
        {
            PlayerName = Helpers.GetName();
            do
            {
                Print.Menu();
                char actionInput = Helpers.GetActionInput();
                switch(actionInput)
                {
                    case 'a':
                        Addition();
                        break;
                    case 's':
                        Subtraction();
                        break;
                    case 'm':
                        Multiplication();
                        break;
                    case 'd':
                        Divison();
                        break;
                    case 'h':
                        History();
                        break;
                    case 'q':
                        return;
                }
            }while (true);


        }
        private void Addition()
        {
            char operation = '+';

            while (true)
            {
                int firstNumber = Rand.Next(1, 9);
                int secondNumber = Rand.Next(1, 9);
                int expectedResult = firstNumber + secondNumber;
                Print.Operation(firstNumber, secondNumber, operation);
                int answer = Helpers.GetAnswer();
                if (answer == expectedResult)
                {
                    PlayerScore++;
                }
                else
                {
                    Console.WriteLine("\nWrong answer :c");
                    this.GamesHistoryList.Add((DateTime.Now,  operation, PlayerScore));
                    PlayerScore = 0;
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    return;
                }
            }
        }

        private void Subtraction()
        {
            char operation = '-';

            while(true)
            {
                int firstNumber = Rand.Next(1, 9);
                int secondNumber = Rand.Next(1, 9);
                int expectedResult = firstNumber - secondNumber;
                Print.Operation(firstNumber, secondNumber, operation);
                int answer = Helpers.GetAnswer();
                if (answer == expectedResult)
                {
                    PlayerScore++;
                }
                else
                {
                    Console.WriteLine("Wrong answer :c");
                    this.GamesHistoryList.Add((DateTime.Now, operation, PlayerScore));
                    PlayerScore = 0;
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    return;
                }
            }
        }

        private void Multiplication()
        {
            char operation = '*';

            while (true)
            {
                int firstNumber = Rand.Next(1, 9);
                int secondNumber = Rand.Next(1, 9);
                int expectedResult = firstNumber * secondNumber;
                Print.Operation(firstNumber, secondNumber, operation);
                int answer = Helpers.GetAnswer();
                if (answer == expectedResult)
                {
                    PlayerScore++;
                }
                else
                {
                    Console.WriteLine("Wrong answer :c");
                    this.GamesHistoryList.Add((DateTime.Now, operation, PlayerScore));
                    PlayerScore = 0;
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return;
                }
            }
        }

        private void Divison()
        {
            char operation = '/';

            while (true)
            {
                int firstNumber, secondNumber;
                do
                {
                    firstNumber = Rand.Next(1, 100);
                    secondNumber = Rand.Next(1, 9);
                } while (firstNumber % secondNumber != 0);
                int expectedResult = firstNumber / secondNumber;
                Print.Operation(firstNumber, secondNumber, operation);
                int answer = Helpers.GetAnswer();
                if (answer == expectedResult)
                {
                    PlayerScore++;
                }
                else
                {
                    Console.WriteLine("Wrong answer :c");
                    this.GamesHistoryList.Add((DateTime.Now, operation, PlayerScore));
                    PlayerScore = 0;
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return;
                }
            }
        }

        private void History()
        {
            Print.History(this.GamesHistoryList);
        }
    }
}
