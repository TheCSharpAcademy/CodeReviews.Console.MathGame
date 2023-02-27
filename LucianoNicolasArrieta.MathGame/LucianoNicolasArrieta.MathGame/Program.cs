using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using static System.Formats.Asn1.AsnWriter;

class MathGame
{
    static void Main(string[] args)
    {
        MathGame mg = new MathGame();
        ScoreTable st = new ScoreTable();

        int option = 0;

        while (option != 7)
        {
            mg.PrintMenu();
            option = Convert.ToInt32(Console.ReadLine());
            
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
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid difficulty, try again.");
                        break;
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
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid difficulty, try again.");
                        break;
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
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid difficulty, try again.");
                        break;
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
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid difficulty, try again.");
                        break;
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
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid difficulty, try again.");
                        break;
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
1: easy,
2: medium,
3: hard");
        int difficulty = Convert.ToInt32(Console.ReadLine());

        return difficulty;
    }
}

abstract class Game
{
    protected Random r = new Random();
    Stopwatch sw = Stopwatch.StartNew();
    protected int difficulty, numberOfQuestions, answeredQuestions, maxNumber, answerValue, score, correctAnswer, userAnswer;

    public Game(int numberQ, int dif)
    {
        this.numberOfQuestions = numberQ;
        if (dif == 1)
        {
            this.difficulty = dif;
            this.maxNumber = 20;
            this.answerValue = 1;
        }
        else if (dif == 2)
        {
            this.difficulty = dif;
            this.maxNumber = 50;
            this.answerValue = 2;
        }
        else if (dif == 3)
        {
            this.difficulty = dif;
            this.maxNumber = 100;
            this.answerValue = 3;
        }
        else
        {
            throw new Exception();
        }
    }

    abstract public void CreateAndAnswerArithmeticEq();

    public void CheckResult()
    {
        if (correctAnswer == userAnswer)
        {
            correctAnswer++;
            score += answerValue;
        }
    }
    public Score RunGame()
    {
        sw.Start();
        while (answeredQuestions < numberOfQuestions)
        {
            this.CreateAndAnswerArithmeticEq();
            this.CheckResult();

            answeredQuestions++;
        }
        sw.Stop();
        TimeSpan ts = sw.Elapsed;
        sw.Restart();
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.Write("Please type your name: ");
        string name = Console.ReadLine();

        Score finalScore = new Score(score, name, elapsedTime);
        return finalScore;
    }
}

class AdditionGame : Game
{
    public AdditionGame(int numberQ, int dif) : base(numberQ, dif)
    {
    }

    public override void CreateAndAnswerArithmeticEq()
    {
        int addend1 = r.Next(0, maxNumber);
        int addend2 = r.Next(0, maxNumber);

        correctAnswer = addend1 + addend2;
        Console.WriteLine($"{addend1} + {addend2}");
        userAnswer = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");
    }
}

class SubtractionGame : Game
{
    public SubtractionGame(int numberQ, int dif) : base(numberQ, dif)
    {
    }

    public override void CreateAndAnswerArithmeticEq()
    {
        int minuend = r.Next(0, maxNumber);
        int subtrahend = r.Next(0, maxNumber);

        correctAnswer = minuend - subtrahend;
        Console.WriteLine($"{minuend} - {subtrahend}");
        userAnswer = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");
    }
}

class MultiplicationGame : Game
{
    public MultiplicationGame(int numberQ, int dif) : base(numberQ, dif)
    {
    }

    public override void CreateAndAnswerArithmeticEq()
    {
        int factor1 = r.Next(0, 10);
        int factor2 = r.Next(0, maxNumber);

        correctAnswer = factor1 * factor2;
        Console.WriteLine($"{factor1} * {factor2}");
        userAnswer = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");
    }
}

class DivisionGame : Game
{
    public DivisionGame(int numberQ, int dif) : base(numberQ, dif)
    {
    }

    public override void CreateAndAnswerArithmeticEq()
    {
        int dividend = r.Next(0, 100);
        int divisor = r.Next(0, maxNumber);

        correctAnswer = dividend / divisor;
        Console.WriteLine($"{dividend} / {divisor}");
        userAnswer = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");
    }
}

class RandomGame : Game
{
    public RandomGame(int numberQ, int dif) : base(numberQ, dif)
    {
    }

    public override void CreateAndAnswerArithmeticEq()
    {
        int choosenOperation = r.Next(0, 3);

        switch (choosenOperation)
        {
            case 0:
                // Addition
                int number1 = r.Next(0, maxNumber);
                int number2 = r.Next(0, maxNumber);

                correctAnswer = number1 + number2;
                Console.WriteLine($"{number1} + {number2}");
                userAnswer = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
                break;
            case 1:
                // Subtraction
                number1 = r.Next(0, maxNumber);
                number2 = r.Next(0, maxNumber);

                correctAnswer = number1 - number2;
                Console.WriteLine($"{number1} - {number2}");
                userAnswer = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
                break;
            case 2:
                // Multiplication
                number1 = r.Next(0, 10);
                number2 = r.Next(0, maxNumber);

                correctAnswer = number1 * number2;
                Console.WriteLine($"{number1} * {number2}");
                userAnswer = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
                break;
            case 3:
                // Division
                number1 = r.Next(0, 100);
                number2 = r.Next(0, maxNumber);

                correctAnswer = number1 / number2;
                Console.WriteLine($"{number1} / {number2}");
                userAnswer = Convert.ToInt32(Console.ReadLine());
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

    public Score(int value, string name, string time)
    {
        this.Value = value;
        this.Name = name;
        this.Time = time;
    }

    public void PrintScoreMessage()
    {
        Console.WriteLine($"¡Congratulations {Name}! You finished the game in {Time} and you scored: {Value}pts");
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
            Console.WriteLine("{0} - {1} - {2}", score.Name, score.Time, score.Value);
        }
    }
}