using System.Diagnostics;

void DisplayScore (int score)
{
    Console.Clear();
    Console.WriteLine($"FINAL SCORE : {score}\n\n");
    Console.Write("Press any key to continue...");
    Console.ReadLine();
}

int CalculateScore (Stopwatch timeToAnswer)
{
    int max_time = 5000;
    int aux = 100000;

    if (timeToAnswer.ElapsedMilliseconds<max_time)
    {
        int returner = aux / (int)timeToAnswer.ElapsedMilliseconds;
        return returner;
    }
    else { return aux / max_time; }
}

bool Sum (int _min, int _max)
{
    Random random= new Random();
    int number1 = random.Next(_min, _max + 1);
    int number2 = random.Next(_min, _max + 1);

    Console.WriteLine($"{number1} + {number2} = ?");

    if (int.TryParse(Console.ReadLine(), out int answer))
    {
        if (answer == number1 + number2)
        {
            return true;
        }
    }
    return false;
}

bool Subtraction(int _min, int _max)
{
    Random random = new Random();
    int number1 = random.Next(_min, _max + 1);
    int number2 = random.Next(number1, _max + 1);
    int subResult = number2 - number1;

    Console.WriteLine($"{number2} - {number1} = ?");
    if (int.TryParse(Console.ReadLine(), out int answer))
    {
        if (answer == subResult)
        {
            return true;
        }
        else { return false; }
    }
    return false;
}

bool Division( int _min, int _max)
{
    Random random = new Random();
    int number1;
    int number2;

    do
    {
        number1 = random.Next(_min, _max + 1);
        number2 = random.Next(number1 + 1, _max + 1);
    }
    while (number2 % number1 != 0);

    Console.WriteLine($"{number2} / {number1} = ?");

    if (int.TryParse(Console.ReadLine(), out int answer) && answer == number2/number1)
    {
        return true;
    }
    else { return false; }
}

bool Multiplication(int _min, int _max)
{
    Random random = new Random();
    int number1 = random.Next(_min, _max + 1);
    int number2 = random.Next(_min, _max + 1);

    Console.WriteLine($"{number1} * {number2} = ?");

    if (int.TryParse(Console.ReadLine(), out int answer))
    {
        if (answer == number1 * number2)
        {
            return true;
        }
    }
    return false;
}

int Game (string gameType, int _numberOfRounds, int _min, int _max)
{
    int score = 0;
    int aux;
    Random random= new Random();

    Stopwatch timeToAnswer;
    bool right = false;
    bool started = false;

    while (_numberOfRounds > 0)
    {
        Console.Clear();
        Console.WriteLine($"{gameType.ToUpper()} GAME - SCORE: {score}");

        if (right && started)
        {
            Console.WriteLine("\nRIGHT");
        }
        else if (!right && started) { Console.WriteLine("\nWRONG"); }
        else { Console.WriteLine(); }

        Console.WriteLine("-------------------\n");

        started = true;
        timeToAnswer = Stopwatch.StartNew();
        switch (gameType)
        {
            case "SUM":
                right = Sum(_min, _max);
                timeToAnswer.Stop();
                break;
            case "SUBTRACTION":
                right= Subtraction(_min, _max);
                timeToAnswer.Stop();
                break;
            case "DIVISION":
                right= Division(_min, _max);
                timeToAnswer.Stop();
                break;
            case "MULTIPLICATION":
                right= Multiplication(_min, _max);
                timeToAnswer.Stop();
                break;
            case "RANDOM":
                switch(aux = random.Next(0,4))
                {
                    case 0:
                        right = Sum(_min, _max); break;
                    case 1:
                        right = Subtraction(_min, _max); break;
                    case 2:
                        right = Division(_min, _max); break;
                    case 3:
                        right = Multiplication(_min, _max); break;
                }
                timeToAnswer.Stop();
                break;
        }
        if (right) { score = score + CalculateScore(timeToAnswer); }

        _numberOfRounds--;
    }
    DisplayScore(score);
    return score;
}

void GameSelect(int _numberOfRounds, int _min, int _max, List<Game> _games)
{
    int gameScore;
    string? gameMode;

    Console.Clear();

    while(true) {
        Console.WriteLine("Select an operation to start\n\t- S - sum\n\t- s - subtraction\n\t- d - division\n\t- m - multiplication\n\t- r - random\n\ne - to exit to the menu\n");

        switch (gameMode = Console.ReadLine())
        {
            case "S":
                gameScore = Game("SUM", _numberOfRounds,_min, _max);
                _games.Add(new Game("Sum", gameScore));
                
                break;
            case "s":
                gameScore = Game("SUBTRACTION", _numberOfRounds, _min, _max);
                _games.Add(new Game("Subtraction", gameScore));
                break;
            case "d":
                gameScore = Game("DIVISION", _numberOfRounds, _min, _max);
                _games.Add(new Game("Division", gameScore));
                break;
            case "m":
                gameScore = Game("MULTIPLICATION", _numberOfRounds, _min, _max);
                _games.Add(new Game("Multiplication", gameScore));
                break;
            case "r":
                gameScore = Game("RANDOM", _numberOfRounds, _min, _max);
                _games.Add(new Game("Random", gameScore));
                break;
            case "e":
                Console.Clear();
                return;
            default:
                Console.WriteLine("Invalid character!");
                break;
        }
    }
}

void Settings(ref int min, ref int max, ref int numberOfRounds)
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("SETTINGS");
        Console.WriteLine("--------\n");

        Console.WriteLine($"Minimum value:\t\t\t{min}");
        Console.WriteLine($"Maximum value:\t\t\t{max}");
        Console.WriteLine($"Number of rounds per game:\t{numberOfRounds}");
        Console.WriteLine("\n");
        Console.WriteLine("Press:\n\tm to edit the minimum\n\tM to edit the maximum\n\tn to edit the number of rounds");
        Console.WriteLine("e - to exit");

        switch (Console.ReadLine())
        {
            case "m":
                EnterNewValue(ref min);
                break;
            case "M":
                EnterNewValue(ref max);
                break;
            case "n":
                EnterNewValue(ref numberOfRounds);
                break;
            case "e":
                return;

            default:
                break;
        }
    }
}

void EnterNewValue(ref int valueToChange)
{
    string? input;
    do
    {
        Console.Clear();
        Console.WriteLine("SETTINGS");
        Console.WriteLine("--------\n");
        Console.WriteLine();
        Console.Write("Enter the new value:\t");
        input = Console.ReadLine();
    }
    while (!(int.TryParse(input, out _)));

    _ = int.TryParse(input, out valueToChange);
}

List<Game> games = new List<Game>();
int numberOfRounds = 5;
int min = 1;
int max = 100;
string? mode;

do
{
    Console.WriteLine("MATH GAME\n\n");
    Console.WriteLine("Choose one of the following options: \n\t- n to start a new game \n\t- s to access the settings\n\t- v to view previous games\n\t- e to exit the game");

    switch (mode = Console.ReadLine())
    {
        case "n":
            GameSelect(numberOfRounds, min, max, games);
            Console.Clear();
            break;
        case "s":
            Settings(ref min, ref max, ref numberOfRounds);
            Console.Clear();
            break;
        case "v":
            ViewPreviousGames(games);
            Console.Clear();
            break;
        default:
            break;
    }
}
while (mode != "e");

void ViewPreviousGames(List<Game> _games)
{
    Console.Clear();
    Console.WriteLine("PREVIOUS GAMES");
    Console.WriteLine("--------------");
    Console.WriteLine("Game Type\t\tScore");

    for (int i = _games.Count(); i > 0; i--)
    {
        Console.WriteLine($"{_games[i - 1].gameType}\t\t\t{_games[i - 1].score}");
    }

    Console.WriteLine("\n Press any key to return to the menu");
    Console.ReadLine();
    Console.Clear();
    return;
}


class Game
{
    public string gameType;
    public int score;

    public Game(string gameType, int score)
    {
        this.gameType = gameType;
        this.score = score;
    }

    public string GetGameType()
    {
        return gameType;
    }

    public int GetScore()
    { 
        return score; 
    }
}