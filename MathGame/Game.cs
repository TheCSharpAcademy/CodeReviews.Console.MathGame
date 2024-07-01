namespace MathGame;

public class Game
{
    private int[][][] _gameLevels;
    private int _currentDifficultyLevel;
    private int _currentNumberOfQuestions;
    private DateTime? _gameTimer;
    private const int MAX_LEVEL_OF_DIFFUCULTY = 5;
    private readonly Random _rnd = new Random();
    private readonly List<Stat> _stats = new List<Stat>();

    public Game()
    {
        this._currentDifficultyLevel = 0;
        this._currentNumberOfQuestions = 10;
        this._gameTimer = null;
    }

    public void Run()
    {
        this.PrepareGameData(5, 10);
        this.DisplayWelcomeMessage();
        this.DisplayMenu();
        this.HotkeyHandler();
    }

    private void DisplayWelcomeMessage()
    {
        Console.WriteLine($"Welcome to the math game!");
    }
    
    private void DisplayEndGameMessage()
    {
        Console.WriteLine($"Current game was end. Press |m| for display menu.");
    }

    private void DisplayMenu()
    {
        Console.WriteLine($"Menu:{Environment.NewLine}" +
                          $"+ | addition game{Environment.NewLine}" +
                          $"- | subtraction game{Environment.NewLine}" +
                          $"* | multiplication game{Environment.NewLine}" +
                          $"/ | division game{Environment.NewLine}" +
                          $"r | random game{Environment.NewLine}" +
                          $"p | pick the number of questions{Environment.NewLine}" +
                          $"d | change level of difficulty{Environment.NewLine}" +
                          $"s | display stats{Environment.NewLine}" +
                          $"m | display menu{Environment.NewLine}" +
                          $"q | quite game{Environment.NewLine}");
    }

    private void HotkeyHandler()
    {
        bool quite = false;
        do
        {
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
            switch (key.KeyChar)
            {
                case '+':
                    Console.WriteLine($"Start addition game!");
                    this.StartAdditionGame();
                    break;
                case '-':
                    Console.WriteLine($"Start subtraction game!");
                    this.StartSubtractionGame();
                    break;
                case '*':
                    Console.WriteLine($"Start multiplication game!");
                    this.StartMultiplicationGame();
                    break;
                case '/':
                    Console.WriteLine($"Start division game!");
                    this.StartDivisionGame();
                    break;
                case 'r':
                    Console.WriteLine($"Start random game!");
                    this.StartRandomGame();
                    break;
                case 'p':
                    this.DisplayCurrentNumberOfQuestions();
                    this.ChangeNumberOfQuestions();
                    break;
                case 'd':
                    this.DisplayCurrentLevelOfDifficulty();
                    this.ChangeLevelOfDifficulty();
                    break;
                case 's':
                    Console.WriteLine($"Your session game stats!");
                    this.DisplayStats();
                    break;
                case 'm':
                    this.DisplayMenu();
                    break;
                case 'q':
                    Console.WriteLine($"Bye, bye!");
                    quite = true;
                    break;
                default:
                    Console.WriteLine($"Wrong command! Try again enter hotkey! Display menu: m");
                    break;
            }
        } while (!quite);
    }

    private int InputNumberHandler()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                return number;
            }
            Console.WriteLine("Need input a number!");
        }
    }   

    private void StartAdditionGame()
    {
        int[][] pairs = this.SelectRandomPairsForGame(this._currentNumberOfQuestions);
        this.StartSaveStats("Addition", pairs.Length);
        this.ToggleCurrentGameTimer();
        for (int i = 0; i < pairs.Length; i++)
        {
            this.DisplayGameData(i + 1, pairs.Length, pairs[i][0], pairs[i][1], "+");
            int answer = this.InputNumberHandler();
            bool answerResult = answer == pairs[i][0] + pairs[i][1];
            
            this.SaveCorrectAnswer(answerResult);
            this.DisplayReplyState(answerResult);
        }
        this.ToggleCurrentGameTimer();

        this.DisplayEndGameMessage();
    }
    
    private void StartSubtractionGame()
    {
        int[][] pairs = this.SelectRandomPairsForGame(this._currentNumberOfQuestions);
        this.StartSaveStats("Subtraction", pairs.Length);
        this.ToggleCurrentGameTimer();
        for (int i = 0; i < pairs.Length; i++)
        {
            this.DisplayGameData(i + 1, pairs.Length, pairs[i][0] + pairs[i][1], pairs[i][1], "-");
            int answer = this.InputNumberHandler();
            bool answerResult = answer == pairs[i][0];

            this.SaveCorrectAnswer(answerResult);
            this.DisplayReplyState(answerResult);
        }
        this.ToggleCurrentGameTimer();

        this.DisplayEndGameMessage();
    }
    
    private void StartMultiplicationGame()
    {
        int[][] pairs = this.SelectRandomPairsForGame(this._currentNumberOfQuestions);
        this.StartSaveStats("Multiplication", pairs.Length);
        this.ToggleCurrentGameTimer();
        for (int i = 0; i < pairs.Length; i++)
        {
            this.DisplayGameData(i + 1, pairs.Length, pairs[i][0], pairs[i][1], "*");
            int answer = this.InputNumberHandler();
            bool answerResult = answer == pairs[i][0] * pairs[i][1];

            this.SaveCorrectAnswer(answerResult);
            this.DisplayReplyState(answerResult);
        }
        this.ToggleCurrentGameTimer();

        this.DisplayEndGameMessage();
    }
    
    private void StartDivisionGame()
    {
        int[][] pairs = this.SelectRandomPairsForGame(this._currentNumberOfQuestions);
        this.StartSaveStats("Division", pairs.Length);
        this.ToggleCurrentGameTimer();
        for (int i = 0; i < pairs.Length; i++)
        {
            this.DisplayGameData(i + 1, pairs.Length, pairs[i][0] * pairs[i][1], pairs[i][1], "/");
            int answer = this.InputNumberHandler();
            
            bool answerResult = answer == pairs[i][0];
            this.SaveCorrectAnswer(answerResult);
            this.DisplayReplyState(answerResult);
        }
        this.ToggleCurrentGameTimer();

        this.DisplayEndGameMessage();
    }

    private void StartRandomGame()
    {
        int[][] pairs = this.SelectRandomPairsForGame(this._currentNumberOfQuestions);
        this.StartSaveStats("Random", pairs.Length);
        this.ToggleCurrentGameTimer();
        for (int i = 0; i < pairs.Length; i++)
        {
            int gameType = this._rnd.Next(0,4);
            int answer = -1;
            bool answerResult = false;

            switch (gameType)
            {
                case 0:
                    this.DisplayGameData(i + 1, pairs.Length, pairs[i][0], pairs[i][1], "+");
                    answer = this.InputNumberHandler();
                    answerResult = answer == pairs[i][0] + pairs[i][1];
                    break;
                case 1:
                    this.DisplayGameData(i + 1, pairs.Length, pairs[i][0] + pairs[i][1], pairs[i][1], "-");
                    answer = this.InputNumberHandler();
                    answerResult = answer == pairs[i][0];
                    break;
                case 2:
                    this.DisplayGameData(i + 1, pairs.Length, pairs[i][0], pairs[i][1], "*");
                    answer = this.InputNumberHandler();
                    answerResult = answer == pairs[i][0] * pairs[i][1];
                    break;
                case 3:
                    this.DisplayGameData(i + 1, pairs.Length, pairs[i][0] * pairs[i][1], pairs[i][1], "/");
                    answer = this.InputNumberHandler();
                    answerResult = answer == pairs[i][0];
                    break;
            }

            this.SaveCorrectAnswer(answerResult);
            this.DisplayReplyState(answerResult);
        }
        this.ToggleCurrentGameTimer();

        this.DisplayEndGameMessage();
    }

    private void StartSaveStats(string gameName, int totalQuestions)
    {
        this._stats.Add(new Stat() { GameName = gameName, TotalQuestions = totalQuestions, CorrectAnswers = 0, DifficultyLevel = _currentDifficultyLevel});
    }
    
    private void SaveCorrectAnswer(bool answer)
    {
        if (answer)
        {
            this._stats[^1].CorrectAnswers++;
        }
    }

    private void ToggleCurrentGameTimer()
    {
        if (this._gameTimer == null)
        {
            this._gameTimer = DateTime.Now;
        }
        else
        {
            DateTime now = DateTime.Now;
            this._stats[^1].GameTime = now.Subtract((DateTime)this._gameTimer);
            this._gameTimer = null;
        }
    }

    private void ChangeLevelOfDifficulty()
    {
        int level = 0;
        do
        {
            Console.Write($"Enter level 1-{MAX_LEVEL_OF_DIFFUCULTY}: ");
            level = InputNumberHandler() - 1;
        } while (level < 0 || level >= MAX_LEVEL_OF_DIFFUCULTY);

        this._currentDifficultyLevel = level;
        this.DisplayCurrentLevelOfDifficulty();
    }
    
    private void DisplayCurrentLevelOfDifficulty()
    {
        Console.WriteLine($"Current level of difficulty: {this._currentDifficultyLevel + 1}");
    }

    private void DisplayStats()
    {
        foreach (var stat in this._stats)
        {
            Console.WriteLine($"Game: {stat.GameName}, difficulty:{stat.DifficultyLevel + 1}, answers: {stat.CorrectAnswers}/{stat.TotalQuestions} | time spent: {stat.GameTime}");
        }
    }


    private void ChangeNumberOfQuestions()
    {
        int numberOfQuestions = 0;
        int maxNumberOfQuestions = _gameLevels[this._currentDifficultyLevel].Length / 2;

        do
        {
            Console.Write($"Enter number of questions 1-{maxNumberOfQuestions}: ");
            numberOfQuestions = InputNumberHandler();
        } while (numberOfQuestions < 0 || numberOfQuestions > maxNumberOfQuestions);

        this._currentNumberOfQuestions = numberOfQuestions;
        this.DisplayCurrentNumberOfQuestions();
    }

    private void DisplayCurrentNumberOfQuestions()
    {
        Console.WriteLine($"Current number of questions: {this._currentNumberOfQuestions}");
    }

    private int[][] SelectRandomPairsForGame(int pairsCount = 10)
    {
        int[][] randomPairs = new int[pairsCount][];
        int[] randomIndexes = new int[pairsCount];

        for (int i = 0; i < pairsCount; i++)
        {
            int rndIndex = this._rnd.Next(0, _gameLevels[_currentDifficultyLevel].Length);
            if (!randomIndexes.Contains(rndIndex))
            {
                randomIndexes[i] = rndIndex;
                randomPairs[i] = _gameLevels[_currentDifficultyLevel][rndIndex];
            }
            else
            {
                i--;
            }
        }

        return randomPairs;
    }

    private void DisplayGameData(int currStage, int maxStage, int first, int second, string operation)
    {
        Console.Write($"Stage:{currStage}/{maxStage}| {first} {operation} {second} = ");
    }

    private void DisplayReplyState(bool answer)
    {
        if (answer)
        {
            Console.WriteLine("Correct!");
        }
        else
        {
            Console.WriteLine("Wrong!");
        }
    }

    private void PrepareGameData(int levels, int deltaNumberForGen)
    {
        _gameLevels = new int[levels][][];
        for (int level = 0; level < levels; level++)
        {
            _gameLevels[level] = new int[deltaNumberForGen * deltaNumberForGen][];
            int upperLimit = (level + 1) * deltaNumberForGen;
            int lowerLimit = upperLimit - deltaNumberForGen + 1;
            int pairsCounter = 0;
            
            for (int first = lowerLimit; first <= upperLimit; first++)
            {
                for (int second = lowerLimit; second <= upperLimit; second++)
                {
                    _gameLevels[level][pairsCounter] = new[] { first, second };
                    pairsCounter++;
                }
            }
        }
    }
}