using ConsoleMathGame.Models;

namespace ConsoleMathGame;
internal class Helpers
{
    public static List<Game> games = new();
    private static System.Timers.Timer aTimer;
    public static int seconds;

    public static int[] NumbersForDivision(int level)
    {
        Random rnd = new();
        int num1 = rnd.Next(Convert.ToInt32(Math.Pow(10, level - 1)), Convert.ToInt32(Math.Pow(10, level + 1)));
        int num2 = rnd.Next(Convert.ToInt32(Math.Pow(10, level - 1)), Convert.ToInt32(Math.Pow(10, level + 1)));
        int[] numbers = new int[2];

        while (num1 % num2 != 0 || num1 == num2 || num2 == 1)
        {
            num1 = rnd.Next(1, 100);
            num2 = rnd.Next(1, 100);
        }
        numbers[0] = num1;
        numbers[1] = num2;
        return numbers;
    }
    public static string ValidateInput(string input)
    {
        while (String.IsNullOrEmpty(input) || !Int32.TryParse(input, out _))
        {
            Console.Beep();
            Console.WriteLine("The input needs to be an integer. Enter the correct input.");
            input = Console.ReadLine();
        }
        return input;
    }

    public static string GetName()
    {
        Console.WriteLine("Hello There Player! \nWhat is your name?");
        string name = Console.ReadLine();
        if (String.IsNullOrEmpty(name))
        {
            name = "Player";
        }

        return name;
    }

    public static int GetLevel()
    {
        Console.WriteLine("Choose the Dificulty of the game.");
        Console.WriteLine("Press 1 for Easy\n" +
            "Press 2 for level MEDIUM\n" +
            "Press 3 for level HARD");
    here: string tempLevel = Console.ReadLine();
        tempLevel = ValidateInput(tempLevel);
        int level = Int32.Parse(tempLevel);
        if (level != 1 && level != 2 && level != 3)
        {
            Console.WriteLine("Wrong Choice Try again.");
            goto here;
        }
        Console.Clear();
        return Int32.Parse(tempLevel);
    }

    public static int GetNumberOfQuestions()
    {
        Console.WriteLine("How many questions do you want to answer?");
        Console.WriteLine("choose a number between 5 and 20");
    here: string questions = Console.ReadLine();
        questions = ValidateInput(questions);
        int level = Int32.Parse(questions);
        if (level < 5 || level > 20)
        {
            Console.WriteLine("Wrong Choice Try again.");
            goto here;
        }
        Console.Clear();
        return Int32.Parse(questions);
    }

    public static void SaveScore(string gamePlayer, Game.GameType gameType, int GameScore, int level, int numberOfQuestions, int time)
    {
        string theLevel;
        switch (level)
        {

            case 1:
                theLevel = "EASY";
                break;
            case 2:
                theLevel = "MEDIUM";
                break;
            case 3:
                theLevel = "HARD";
                break;
            default:
                theLevel = "";
                break;
        }
        games.Add(new Game
        {
            Date = DateTime.Now,
            Player = gamePlayer,
            Type = gameType,
            Score = GameScore,
            Level = theLevel,
            NumberOfQuestion = numberOfQuestions,
            Time = time
        });
    }

    public static void ShowScores()
    {
        if (games.Count == 0)
        {
            Console.WriteLine("No scores saved to display...");
        }
        else
        {
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} \t {game.Type} \t {game.Player} \t LEVEL = {game.Level} \t SCORE = {game.Score} out of {game.NumberOfQuestion} \t Time = {game.Time}");
            }
        }
    }

    public static void StartTimer()
    {
        seconds = 0;
        // Create a timer with a two second interval.
        aTimer = new System.Timers.Timer(1000);
        // Hook up the Elapsed event for the timer. 
        aTimer.Elapsed += OnTimedEvent;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;

    }
    public static int StopTimer()
    {
        aTimer.Stop();
        aTimer.Dispose();
        return seconds;
    }

    private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
    {
        seconds += 1;
    }
}