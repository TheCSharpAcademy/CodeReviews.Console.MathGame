using System.Diagnostics;

class MathGame
{
    static void Main(string[] args)
    {
        MathGame mg = new MathGame();
        ScoreTable st = new ScoreTable();

        string input;
        int option = 0;

        while (option != 7)
        {
            mg.PrintMenu();

            input = Console.ReadLine();
            while (!Int32.TryParse(input, out option))
            {
                Console.Write("Error, please enter a number from the menu: ");
                input = Console.ReadLine();
            }

                switch (option)
            {
                case 1:
                    Console.WriteLine("You choose Addition Game");
                    int number = mg.ChooseNumberOfQuestions();
                    int difficulty = mg.ChooseDifficulty();
                    try
                    {
                        AdditionGame additionGame = new AdditionGame(number, difficulty);
                        Score score = additionGame.RunGame();
                        score.PrintScoreMessage();
                        st.AddScore(score);
                    }
                    catch (InvalidDifficultyException)
                    {
                        Console.WriteLine("Invalid difficulty, try again.");
                    }
                    break;
                case 2:
                    Console.WriteLine("You choose Subtraction Game");
                    number = mg.ChooseNumberOfQuestions();
                    difficulty = mg.ChooseDifficulty();
                    try
                    {
                        SubtractionGame subtractionGame = new SubtractionGame(number, difficulty);
                        Score score = subtractionGame.RunGame();
                        score.PrintScoreMessage();
                        st.AddScore(score);
                    }
                    catch (InvalidDifficultyException)
                    {
                        Console.WriteLine("Invalid difficulty, try again.");
                    }
                    break;
                case 3:
                    Console.WriteLine("You choose Multiplication Game");
                    number = mg.ChooseNumberOfQuestions();
                    difficulty = mg.ChooseDifficulty();
                    try
                    {
                        MultiplicationGame multiplicationGame = new MultiplicationGame(number, difficulty);
                        Score score = multiplicationGame.RunGame();
                        score.PrintScoreMessage();
                        st.AddScore(score);
                    }
                    catch (InvalidDifficultyException)
                    {
                        Console.WriteLine("Invalid difficulty, try again.");
                    }
                    break;
                case 4:
                    Console.WriteLine("You choose Division Game");
                    number = mg.ChooseNumberOfQuestions();
                    difficulty = mg.ChooseDifficulty();
                    try
                    {
                        DivisionGame divisionGame = new DivisionGame(number, difficulty);
                        Score score = divisionGame.RunGame();
                        score.PrintScoreMessage();
                        st.AddScore(score);
                    }
                    catch (InvalidDifficultyException)
                    {
                        Console.WriteLine("Invalid difficulty, try again.");
                    }
                    break;
                case 5:
                    Console.WriteLine("You choose Random Operations");
                    number = mg.ChooseNumberOfQuestions();
                    difficulty = mg.ChooseDifficulty();
                    try
                    {
                        RandomGame randomGame = new RandomGame(number, difficulty);
                        Score score = randomGame.RunGame();
                        score.PrintScoreMessage();
                        st.AddScore(score);
                    }
                    catch (InvalidDifficultyException)
                    {
                        Console.WriteLine("Invalid difficulty, try again.");
                    }
                    break;
                case 6:
                    st.PrintScores();
                    break;
                case 7:
                    Console.WriteLine("Thanks for playing, see you!");
                    break;
                default:
                    Console.WriteLine("Invalid Option. Try again.");
                    break;
            }
        }
    }


    public void PrintMenu()
    {
        string menu = @"-------------------------------------------------------------
¡HI! Welcome to Math Game. ¿Which game do you want to play today?:
1. Addition
2. Subtraction
3. Multiplication
4. Division
5. Random Operations
6. Show scoreboard
7. Quit
-------------------------------------------------------------";
        Console.WriteLine(menu);
        Console.Write("Please, choose an option from the menu: ");
    }

    public int ChooseNumberOfQuestions()
    {
        Console.WriteLine("Please, choose the number of questions: ");
        int number = Convert.ToInt32(Console.ReadLine());

        return number;
    }

    public int ChooseDifficulty()
    {
        Console.WriteLine(@"Please, choose the difficulty:
1: Easy,
2: Medium,
3: Hard");
        int difficulty = Convert.ToInt32(Console.ReadLine());

        return difficulty;
    }
}

abstract class Game
{
    protected Random Random { get; }
    Stopwatch Stopwatch { get; }
    private int TotalNumberOfQuestions { get; }
    private int AnsweredQuestions { get; set; }
    private int Score { get; set; }
    protected int CorrectAnswer { get; set; }
    protected int UserAnswer { get; set; }
    protected int MaxNumber { get; }
    private int AnswerValue { get; }
    private int TotalObtainablePoints { get; }

    public Game(int numberQ, int dif)
    {
        this.TotalNumberOfQuestions = numberQ;
        if (dif == 1) // EASY
        {
            this.MaxNumber = 20;
            this.AnswerValue = 1;
        }
        else if (dif == 2) // MEDIUM
        {
            this.MaxNumber = 50;
            this.AnswerValue = 2;
        }
        else if (dif == 3) // HARD
        {
            this.MaxNumber = 100;
            this.AnswerValue = 3;
        }
        else
        {
            throw new InvalidDifficultyException();
        }
        this.TotalObtainablePoints = AnswerValue * TotalNumberOfQuestions;
        this.Random = new Random();
        this.Stopwatch = Stopwatch.StartNew();
    }

    abstract protected void CreateAndAnswerArithmeticEq();

    private void CheckResult()
    {
        if (this.CorrectAnswer == this.UserAnswer)
        {
            this.Score += this.AnswerValue;
        }
    }

    public Score RunGame()
    {
        this.Stopwatch.Start();
        while (this.AnsweredQuestions < this.TotalNumberOfQuestions)
        {
            this.CreateAndAnswerArithmeticEq();
            this.CheckResult();

            this.AnsweredQuestions++;
        }
        this.Stopwatch.Stop();
        TimeSpan ts = this.Stopwatch.Elapsed;
        Stopwatch.Restart();
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.Write("Please type your name: ");
        string name = Console.ReadLine();

        Score finalScore = new Score(this.Score, name, elapsedTime, this.TotalObtainablePoints);
        return finalScore;
    }
}

class AdditionGame : Game
{
    public AdditionGame(int numberQ, int dif) : base(numberQ, dif)
    {
    }

    protected override void CreateAndAnswerArithmeticEq()
    {
        int addend1 = this.Random.Next(0, this.MaxNumber);
        int addend2 = this.Random.Next(0, this.MaxNumber);

        this.CorrectAnswer = addend1 + addend2;
        Console.WriteLine($"{addend1} + {addend2}");
        this.UserAnswer = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");
    }
}

class SubtractionGame : Game
{
    public SubtractionGame(int numberQ, int dif) : base(numberQ, dif)
    {
    }

    protected override void CreateAndAnswerArithmeticEq()
    {
        int minuend = this.Random.Next(0, this.MaxNumber);
        int subtrahend = this.Random.Next(0, this.MaxNumber);

        this.CorrectAnswer = minuend - subtrahend;
        Console.WriteLine($"{minuend} - {subtrahend}");
        this.UserAnswer = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");
    }
}

class MultiplicationGame : Game
{
    public MultiplicationGame(int numberQ, int dif) : base(numberQ, dif)
    {
    }

    protected override void CreateAndAnswerArithmeticEq()
    {
        int factor1 = this.Random.Next(0, 10);
        int factor2 = this.Random.Next(0, this.MaxNumber);

        this.CorrectAnswer = factor1 * factor2;
        Console.WriteLine($"{factor1} * {factor2}");
        this.UserAnswer = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");
    }
}

class DivisionGame : Game
{
    public DivisionGame(int numberQ, int dif) : base(numberQ, dif)
    {
    }

    protected override void CreateAndAnswerArithmeticEq()
    {
        int dividend, divisor;

        do
        {
            dividend = this.Random.Next(0, 100);
            divisor = this.Random.Next(1, this.MaxNumber);
        } while (dividend % divisor != 0);

        this.CorrectAnswer = dividend / divisor;
        Console.WriteLine($"{dividend} / {divisor}");
        this.UserAnswer = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");
    }
}

class RandomGame : Game
{
    public RandomGame(int numberQ, int dif) : base(numberQ, dif)
    {
    }

    protected override void CreateAndAnswerArithmeticEq()
    {
        int choosenOperation = this.Random.Next(0, 4);

        switch (choosenOperation)
        {
            case 0:
                // Addition
                int number1 = this.Random.Next(0, this.MaxNumber);
                int number2 = this.Random.Next(0, this.MaxNumber);

                this.CorrectAnswer = number1 + number2;
                Console.WriteLine($"{number1} + {number2}");
                this.UserAnswer = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
                break;
            case 1:
                // Subtraction
                number1 = this.Random.Next(0, this.MaxNumber);
                number2 = this.Random.Next(0, this.MaxNumber);

                this.CorrectAnswer = number1 - number2;
                Console.WriteLine($"{number1} - {number2}");
                this.UserAnswer = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
                break;
            case 2:
                // Multiplication
                number1 = this.Random.Next(0, 10);
                number2 = this.Random.Next(0, this.MaxNumber);

                this.CorrectAnswer = number1 * number2;
                Console.WriteLine($"{number1} * {number2}");
                this.UserAnswer = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
                break;
            case 3:
                // Division
                number1 = this.Random.Next(0, 100);
                number2 = this.Random.Next(0, this.MaxNumber);

                this.CorrectAnswer = number1 / number2;
                Console.WriteLine($"{number1} / {number2}");
                this.UserAnswer = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
                break;
        }
    }
}

class Score
{
    public int Value { get; }
    public string Name { get; }
    public string Time { get; }
    public int TotalObtainablePoints { get; }

    public Score(int value, string name, string time, int obtainablePoints)
    {
        this.Value = value;
        this.Name = name;
        this.Time = time;
        this.TotalObtainablePoints = obtainablePoints;
    }

    public void PrintScoreMessage()
    {
        Console.WriteLine($"¡Congratulations {Name}! You finished the game in {Time} and scored: {Value} pts out of {TotalObtainablePoints}");
        // "¡Congratulations {Name}! You finished the game in {Time} and scored: {Value} pts out of {TotalObtainablePoints}"
    }
}

class ScoreTable
{
    List<Score> scores = new List<Score>();

    public void AddScore(Score score)
    {
        scores.Add(score);
    }

    public void PrintScores()
    {
        Console.WriteLine("Name - Time - Score");
        foreach (Score score in scores)
        {
            Console.WriteLine("{0} - {1} - {2}/{3}", score.Name, score.Time, score.Value, score.TotalObtainablePoints);
        }
    }
}

class InvalidDifficultyException : Exception
{
}