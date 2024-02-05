using System.Diagnostics;

namespace MathGame.Dejmenek
{
    internal class Game
    {
        private readonly List<Question> _Questions = new();
        private readonly Stopwatch _Timer = new();
        private TimeSpan _TimeTaken;
        private Operations _Operation;
        private DifficultyLevels _DifficultyLevel;
        private GameModes _GameMode;
        public string FormattedTimeTaken {
            get => _TimeTaken.ToString(@"mm\:ss");
        }
        public int Score;
        public int NumberOfQuestions;

        public Game() { }

        private void CreateQuestions() {
            if (_GameMode == GameModes.Random)
            {
                Random rnd = new();
                Array values = Enum.GetValues(typeof(Operations));
                Operations operation;
                for (int i = 0; i < NumberOfQuestions; i++)
                {
                    operation = (Operations)values.GetValue(rnd.Next(values.Length));
                    _Questions.Add(new Question(operation, _DifficultyLevel));
                }
            }
            else {
                for (int i = 0; i < NumberOfQuestions; i++)
                {
                    _Questions.Add(new Question(_Operation, _DifficultyLevel));
                }
            }
        }

        public void Start() {
            ShowGameModes();
            SelectGameMode();

            if (_GameMode != GameModes.Random) {
                ShowOperations();
                SelectOperation();
            }

            ShowDifficultyLevels();
            SelectDifficultyLevel();

            SelectNumberOfQuestions();
            CreateQuestions();

            _Timer.Start();
            foreach (Question question in _Questions) {
                question.DisplayQuestion();

                if (question.CheckAnswer()) {
                    Score++;
                }
            }
            _Timer.Stop();
            _TimeTaken = _Timer.Elapsed;

            Console.WriteLine($"You scored {Score} out of {NumberOfQuestions} in {FormattedTimeTaken}");
            Thread.Sleep(2000);
            Console.Clear();
        }
        private static void ShowDifficultyLevels()
        {
            Console.WriteLine("Please choose your difficulty level:");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");
        }

        private void SelectDifficultyLevel() {
            string? userInput = Console.ReadLine();
            _DifficultyLevel = ValidateDifficultyLevel(userInput);
        }

        private static DifficultyLevels ValidateDifficultyLevel(string? input)
        {
            DifficultyLevels selectedLevel;
            while (!Enum.TryParse(input, out selectedLevel) || !Enum.IsDefined(typeof(DifficultyLevels), selectedLevel))
            {
                Console.WriteLine($"Invalid choice. Please enter a number between 1 and {Enum.GetValues(typeof(DifficultyLevels)).Length}. Try again.");
                input = Console.ReadLine();
            }

            return selectedLevel;
        }

        private void SelectNumberOfQuestions() {
            Console.WriteLine("How many questions would you like to answer?");
            string? userInput = Console.ReadLine();
            NumberOfQuestions = ValidateSelectNumberOfQuestions(userInput);
        }

        private static int ValidateSelectNumberOfQuestions(string? input) {
            int selectedNumberOfQuestions;
            while (!int.TryParse(input, out selectedNumberOfQuestions) || selectedNumberOfQuestions < 0) {
                Console.WriteLine("Enter a positive integer value for the number of questions");
                input = Console.ReadLine();
            }

            return selectedNumberOfQuestions;
        }
        private static void ShowGameModes()
        {
            Console.WriteLine("Please select a game mode:");
            Console.WriteLine("1. Normal game");
            Console.WriteLine("2. Random game");
        }

        private void SelectGameMode() {
            string? userInput = Console.ReadLine();
            _GameMode = ValidateSelectGameMode(userInput);
        }

        private static GameModes ValidateSelectGameMode(string? input) {
            GameModes selectedMode;
            while (!Enum.TryParse(input, out selectedMode) || !Enum.IsDefined(typeof(GameModes), selectedMode))
            {
                Console.WriteLine($"Invalid choice. Please enter a number between 1 and {Enum.GetValues(typeof(GameModes)).Length}. Try again.");
                input = Console.ReadLine();
            }

            return selectedMode;
        }
        private static void ShowOperations()
        {
            Console.WriteLine("Please choose an operation:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
        }

        private void SelectOperation()
        {
            string? userInput = Console.ReadLine();
            _Operation = ValidateSelectOperation(userInput);
        }

        private static Operations ValidateSelectOperation(string? input) {
            Operations selectedOperation;
            while (!Enum.TryParse(input, out selectedOperation) || !Enum.IsDefined(typeof(Operations), selectedOperation)) {
                Console.WriteLine($"Invalid choice. Please enter a number between 1 and {Enum.GetValues(typeof(Operations)).Length}. Try again.");
                input = Console.ReadLine();
            }

            return selectedOperation;
        }
    }
}
