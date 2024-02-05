namespace MathGame.Dejmenek
{
    internal class Question
    {
        private readonly Random rnd = new();
        private int _FirstNumber;
        private int _SecondNumber;
        private int _CorrectAnswer;
        private readonly Operations _Operation;
        private readonly DifficultyLevels _DifficultyLevel;
        public string Title = "";

        public Question(Operations operation, DifficultyLevels difficulty) {
            _Operation = operation;
            _DifficultyLevel = difficulty;
            GenerateRandomNumbers();
            CreateTitle();
            GetResult();
        }

        private void GenerateRandomNumbers() {
            switch (_DifficultyLevel) {
                case DifficultyLevels.Easy:
                    _FirstNumber = rnd.Next(2, 40);
                    _SecondNumber = rnd.Next(2, 40);

                    if (_Operation == Operations.Divide) {
                        while (_FirstNumber % _SecondNumber != 0) {
                            _FirstNumber = rnd.Next(2, 40);
                            _SecondNumber = rnd.Next(2, 40);
                        }
                    }
                    break;
                case DifficultyLevels.Medium:
                    _FirstNumber = rnd.Next(40, 100);
                    _SecondNumber = rnd.Next(40, 100);

                    if (_Operation == Operations.Divide)
                    {
                        while (_FirstNumber % _SecondNumber != 0)
                        {
                            _FirstNumber = rnd.Next(40, 100);
                            _SecondNumber = rnd.Next(40, 100);
                        }
                    }
                    break;
                case DifficultyLevels.Hard:
                    _FirstNumber = rnd.Next(100, 300);
                    _SecondNumber = rnd.Next(100, 300);

                    if (_Operation == Operations.Divide)
                    {
                        while (_FirstNumber % _SecondNumber != 0)
                        {
                            _FirstNumber = rnd.Next(100, 300);
                            _SecondNumber = rnd.Next(100, 300);
                        }
                    }
                    break;
            }
        }

        private void CreateTitle() {
            switch (_Operation)
            {
                case Operations.Add:
                    Title = $"{_FirstNumber} + {_SecondNumber}";
                    break;
                case Operations.Subtract:
                    Title = $"{_FirstNumber} - {_SecondNumber}";
                    break;
                case Operations.Multiply:
                    Title = $"{_FirstNumber} X {_SecondNumber}";
                    break;
                case Operations.Divide:
                    Title = $"{_FirstNumber} / {_SecondNumber}";
                    break;
            }
        }

        private void GetResult() {
            switch (_Operation)
            {
                case Operations.Add:
                    _CorrectAnswer = _FirstNumber + _SecondNumber;
                    break;
                case Operations.Subtract:
                    _CorrectAnswer = _FirstNumber - _SecondNumber;
                    break;
                case Operations.Multiply:
                    _CorrectAnswer = _FirstNumber * _SecondNumber;
                    break;
                case Operations.Divide:
                    _CorrectAnswer = _FirstNumber / _SecondNumber;
                    break;
            }
        }

        public void DisplayQuestion() {
            Console.WriteLine(Title);
        }

        public bool CheckAnswer() {
            string? userInput = Console.ReadLine();
            int answer = ValidateUserAnswer(userInput);
            if (answer == _CorrectAnswer)
            {
                Console.WriteLine("Correct answer!");
                return true;
            }
            else
            {
                Console.WriteLine($"Incorrect answer. The correct answer is {_CorrectAnswer}.");
                return false;
            }
        }

        private static int ValidateUserAnswer(string? input)
        {
            int userAnswer;
            while (!int.TryParse(input, out userAnswer))
            {
                Console.WriteLine($"Enter a positive integer value");
                input = Console.ReadLine();
            }

            return userAnswer;
        }
    }
}
