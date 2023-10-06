namespace MathGame.Cactus;

class Game
{
    private string username;
    private DateTime date;
    private int score = 0;
    private List<Score> scoreHistory = new();

    public Game(string username, DateTime date)
    {
        this.username = username;
        this.date = date;
    }

    public void Run()
    {
        Console.Clear();
        Console.WriteLine($"Hello {username?.ToUpper()}, now time is {date}. Let's start the game.\n");
        Console.WriteLine("Please enter any key to start the game.");
        var key = Console.ReadLine();

        // game menu
        bool isQuit = false;
        do
        {
            Console.Clear();
            Console.WriteLine(Constants.MENU);
            var input = Console.ReadLine();
            var option = input?.Trim().ToUpper();
            switch (option)
            {
                case "A":
                    Add();
                    break;
                case "S":
                    Sub();
                    break;
                case "M":
                    Mul();
                    break;
                case "D":
                    Div();
                    break;
                case "H":
                    PrintScoreHistory();
                    break;
                case "Q":
                    Console.WriteLine("Bye");
                    isQuit = true;
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
            if(!isQuit)
            {
                Console.WriteLine("Please enter any key to continue.");
            }
            else
            {
                Console.WriteLine("Please enter any key to end the game.");
            }
            key = Console.ReadLine();
        } while (!isQuit);
    }

    public void PrintScoreHistory()
    {
        Console.Clear();
        Console.WriteLine(Constants.SCORE_HISTORY);
        Console.WriteLine("----------------------------------------------------------------------");
        scoreHistory.ForEach(s => 
            Console.WriteLine($"Time: {s.Date}, Type:{s.Type}, Score: {s.GetTypeScore()}, Total Score: {s.GetScore()}."));
        Console.WriteLine("----------------------------------------------------------------------");
    }

    public void Add()
    {
        Console.Clear();
        Console.WriteLine(Constants.ADD_GAME);
        Console.WriteLine("Please input the times you want to play:");
        int times;
        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input) || !int.TryParse(input, out times))
        {
            Console.WriteLine(Constants.INVALID_INPUT);
            return; // go back to main menu
        }
        var rand = new Random();
        var addScore = 0;
        for (int i = 0; i < times; i++)
        {
            var num1 = rand.Next(0, 99);
            var num2 = rand.Next(0, 99);
            Console.WriteLine($"Please enter the result of {num1} + {num2}:");
            int res;
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || !int.TryParse(input, out res))
            {
                Console.WriteLine(Constants.INVALID_INPUT);
            }
            else if (res == num1 + num2)
            {
                Console.WriteLine(Constants.CORRECT);
                addScore++;
            }
            else
            {
                Console.WriteLine(Constants.ERROR);
            };
        }
        AddScore(Constants.ADD_GAME, addScore);
        PrintScore(Constants.ADD_GAME, addScore);
    }

    public void Sub()
    {
        Console.Clear();
        Console.WriteLine(Constants.SUB_GAME);
        Console.WriteLine("Please input the times you want to play:");
        int times;
        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input) || !int.TryParse(input, out times))
        {
            Console.WriteLine(Constants.INVALID_INPUT);
            return; // go back to main menu
        }
        var rand = new Random();
        var subScore = 0;
        for (int i = 0; i < times; i++)
        {
            var num1 = rand.Next(0, 99);
            var num2 = rand.Next(0, 99);
            Console.WriteLine($"Please enter the result of {num1} - {num2}:");
            var res = 0;
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || !int.TryParse(input, out res))
            {
                Console.WriteLine(Constants.INVALID_INPUT);
            }
            else if (res == num1 - num2)
            {
                Console.WriteLine(Constants.CORRECT);
                subScore++;
            }
            else
            {
                Console.WriteLine(Constants.ERROR);
            };
        }
        AddScore(Constants.SUB_GAME, subScore);
        PrintScore(Constants.SUB_GAME, subScore);
    }

    public void Mul()
    {
        Console.Clear();
        Console.WriteLine(Constants.MUL_GAME);
        Console.WriteLine("Please input the times you want to play:");
        int times;
        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input) || !int.TryParse(input, out times))
        {
            Console.WriteLine(Constants.INVALID_INPUT);
            return; // go back to main menu
        }
        var rand = new Random();
        var mulScore = 0;
        for (int i = 0; i < times; i++)
        {
            var num1 = rand.Next(0, 10);
            var num2 = rand.Next(0, 10);
            Console.WriteLine($"Please enter the result of {num1} * {num2}:");
            var res = 0;
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || !int.TryParse(input, out res))
            {
                Console.WriteLine(Constants.INVALID_INPUT);
            }
            else if (res == num1 * num2)
            {
                Console.WriteLine(Constants.CORRECT);
                mulScore++;
            }
            else
            {
                Console.WriteLine(Constants.ERROR);
            };
        }
        AddScore(Constants.MUL_GAME, mulScore);
        PrintScore(Constants.MUL_GAME, mulScore);
    }

    public void Div()
    {
        Console.Clear();
        Console.WriteLine(Constants.DIV_GAME);
        Console.WriteLine("Please input the times you want to play:");
        int times;
        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input) || !int.TryParse(input, out times))
        {
            Console.WriteLine(Constants.INVALID_INPUT);
            return; // go back to main menu
        }
        var rand = new Random();
        var divScore = 0;
        var num1 = 0;
        var num2 = 0;
        for (int i = 0; i < times; i++)
        {
            do
            {
                num1 = rand.Next(0, 100);
                num2 = rand.Next(1, 100);
            } while (num1 % num2 != 0);
            Console.WriteLine($"Please enter the result of {num1} / {num2}:");
            var res = 0;
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || !int.TryParse(input, out res))
            {
                Console.WriteLine(Constants.INVALID_INPUT);
            }
            else if (res == num1 / num2)
            {
                Console.WriteLine(Constants.CORRECT);
                divScore++;
            }
            else
            {
                Console.WriteLine(Constants.ERROR);
            };
        }
        AddScore(Constants.DIV_GAME, divScore);
        PrintScore(Constants.DIV_GAME, divScore);
    }

    public void AddScore(string gameType, int s)
    {
        score += s;
        scoreHistory.Add(new Score(date, gameType, s, score));
    }

    public void PrintScore(string gameType, int s)
    {
        Console.WriteLine($"Game Finish! Your {gameType} score is {s} and total score is {score}!");
    }
}