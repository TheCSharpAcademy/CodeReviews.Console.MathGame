namespace MathGame.Ryleyy {
    public class Game {
        // Timer _gameTimer = new Timer();
        int _score = 0;
        int _questionLimit = 10;
        int _questionCount = 0;
        bool _gameOver = false;
        bool _randomFlag = false;
        private List<string> History { get; } = [];
        MenuOptions _currentGameMode;
        Difficulty _currentDifficulty = Difficulty.Easy;
        private enum Difficulty
        {
            Easy = 1,
            Medium,
            Hard,
            Insane
        }

        private enum MenuOptions
        {
            Addition = 1,
            Subtraction,
            Multiplication,
            Division,
            Random,
            ChangeDifficulty,
            History,
            Exit
        }
        
        public void StartMenu() {
            Console.WriteLine("------ Welcome to the Math Game! ------");
            Console.WriteLine($"Difficulty: {_questionLimit} {_currentDifficulty} Questions");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Random");
            Console.WriteLine("6. Change Difficulty");
            Console.WriteLine("7. History");
            Console.WriteLine("8. Exit");
            Console.WriteLine("---------------------------------------");

            _gameOver = false;

            int userInput;
            while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < 1 || userInput > 8) {
                Console.WriteLine("Invalid input. Please try again.");
            }
            MenuOptions userChoice = (MenuOptions) userInput;

            Console.Clear();
            switch (userChoice)
            {
                case MenuOptions.Addition:
                    _currentGameMode = MenuOptions.Addition;
                    RunGame('+');
                    return;
                case MenuOptions.Subtraction:
                    _currentGameMode = MenuOptions.Subtraction;
                    RunGame('-');
                    return;
                case MenuOptions.Multiplication:
                    _currentGameMode = MenuOptions.Multiplication;
                    RunGame('*');
                    return;
                case MenuOptions.Division:
                    _currentGameMode = MenuOptions.Division;
                    RunGame('/');
                    return;
                case MenuOptions.Random:
                    _currentGameMode = MenuOptions.Random;
                    RandomOperation();
                    return;
                case MenuOptions.ChangeDifficulty:
                    ChangeDifficulty();
                    return;
                case MenuOptions.History:
                    ShowHistory();
                    return;
                case MenuOptions.Exit:
                    Environment.Exit(0);
                    return;
            }
        }

        private void RandomOperation() {
            Random random = new Random();
            char[] operations = {'+', '-', '*', '/'};
            _randomFlag = true;
            while (!_gameOver && _questionCount < _questionLimit)
            {
                char operation = operations[random.Next(0, 4)];
                RunGame(operation);
            }
            GameOver();
        }

        private void RunGame(char operation) {
            while (!_gameOver && _questionCount < _questionLimit)
            {
                Random random = new Random();
                int firstNumber = 0;
                int secondNumber = 0;
                _questionCount++;
                switch (_currentDifficulty)
                {
                    case Difficulty.Easy:
                        firstNumber = random.Next(0, 10);
                        secondNumber = random.Next(0, 10);
                        break;
                    case Difficulty.Medium:
                        firstNumber = random.Next(0, 30);
                        secondNumber = random.Next(0, 30);
                        break;
                    case Difficulty.Hard:
                        firstNumber = random.Next(0, 50);
                        secondNumber = random.Next(0, 50);
                        break;
                    case Difficulty.Insane:
                        firstNumber = random.Next(0, 100);
                        secondNumber = random.Next(0, 100);
                        break;
                }
                if (operation == '/')
                {
                    while (secondNumber == 0 || secondNumber == 1 || firstNumber % secondNumber != 0 || firstNumber == secondNumber)
                    {
                        switch (_currentDifficulty)
                        {
                            case Difficulty.Easy:
                                firstNumber = random.Next(0, 10);
                                secondNumber = random.Next(1, 10);
                                break;
                            case Difficulty.Medium:
                                firstNumber = random.Next(1, 30);
                                secondNumber = random.Next(2, 30);
                                break;
                            case Difficulty.Hard:
                                firstNumber = random.Next(1, 50);
                                secondNumber = random.Next(2, 50);
                                break;
                            case Difficulty.Insane:
                                firstNumber = random.Next(1, 100);
                                secondNumber = random.Next(2, 100);
                                break;
                        }
                    }
                }

                Console.Write($"{firstNumber} {operation} {secondNumber} = ");
                int answer;
                while (!int.TryParse(Console.ReadLine(), out answer))
                {
                    Console.Clear();
                    Console.Write($"{firstNumber} {operation} {secondNumber} = ");
                }

                int correctAnswer = DoOperation(firstNumber, operation, secondNumber);
                if (answer == correctAnswer)
                {
                    Console.Clear();
                    _score++;
                    History.Add($"{firstNumber} {operation} {secondNumber} = {answer} \u2713");
                }
                else
                {
                    Console.Clear();
                    History.Add($"{firstNumber} {operation} {secondNumber} = {correctAnswer} X | Your answer: {answer}");
                }
                if (_randomFlag)
                {
                    break;
                }
            }
            if (!_randomFlag)
            {
                GameOver();
            };
        }

        private void GameOver()
        {
            _gameOver = true;
            _randomFlag = false;
            Console.WriteLine($"Game Over! Score: {_score}/{_questionLimit}");
            Console.WriteLine("---------------------");
            History.Add($"{_currentDifficulty} {_currentGameMode} Score: {_score}/{_questionLimit}\n---------------------");
            _score = 0;
            _questionCount = 0;
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine(); // Wait for user input
            Console.Clear();
            StartMenu();
        }

        private void ShowHistory() {
            Console.WriteLine("------ History ------");
            foreach (var item in History) {
                Console.WriteLine(item);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine(); // Wait for user input
            Console.Clear();
            StartMenu();
        }

        private void ChangeDifficulty() {
            Console.WriteLine("------ Difficulty ------");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");
            Console.WriteLine("4. Insane");
            Console.WriteLine("5. Change Number of Questions");
            Console.WriteLine("------------------------");

            // Validate user input
            int userInput;
            while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < 1 || userInput > 5) {
                Console.Clear();
                Console.WriteLine("------ Difficulty ------");
                Console.WriteLine("1. Easy");
                Console.WriteLine("2. Medium");
                Console.WriteLine("3. Hard");
                Console.WriteLine("4. Insane");
                Console.WriteLine("5. Change Number of Questions");
            }
            if (userInput != 5) // Change difficulty
            {
                _currentDifficulty = (Difficulty) userInput;
            }
            else // Change number of questions
            {
                Console.Clear();
                Console.Write("Enter the number of questions you would like to answer: ");
                while (!int.TryParse(Console.ReadLine(), out _questionLimit) || _questionLimit < 1) {
                    Console.Clear();
                    Console.WriteLine("Enter a value greater than 1.");
                }
            }

            Console.Clear();
            StartMenu();
        }

        private int DoOperation(int firstNumber, char operation, int secondNumber) {
            switch (operation) {
                case '+':
                    return firstNumber + secondNumber;
                case '-':
                    return firstNumber - secondNumber;
                case '*':
                    return firstNumber * secondNumber;
                case '/':
                    return firstNumber / secondNumber;
            }
            return 0;
        }
    }
}