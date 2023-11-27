using System.Drawing;
using System.Threading;
using System.Timers;


namespace Branch_Console;

internal class GameRun : State
{

    private System.Timers.Timer timer;

    internal List<MathOperation> operations;
    internal int RunScore = 0;
    private int operationIndex = 0;
    internal int timeCounter = 20;

    private void SetTimer()
    {
        // Create a timer with a two second interval.
        timer = new System.Timers.Timer(1000);
        // Hook up the Elapsed event for the timer. 
        timer.Elapsed += OnTimedEvent;
        timer.AutoReset = true;
        timer.Enabled = true;
        timeCounter = 20;
    }
    private void OnTimedEvent(Object? source, ElapsedEventArgs e)
    {
        if (timeCounter > 0)
        {
            timeCounter--;
            var point = new Point(Console.CursorLeft, Console.CursorTop);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Timer: {timeCounter.ToString().PadLeft(4, '0')}");
            Console.SetCursorPosition(point.X, point.Y);
        }
    }
    public override void Print()
    {

        SetTimer();
        MathOperation op = operations[operationIndex];
        Console.Clear();
        Console.WriteLine($"Timer: {timeCounter.ToString().PadLeft(4, '0')}");
        Console.WriteLine(Helpers.OperationTitle(op.Operator)); // Title
        Console.WriteLine($"Problem set {operationIndex + 1} of {operations.Count}. Run Score is: {RunScore}.");
        Console.WriteLine($"Question: {op.GetExpression()} ?");
        Console.WriteLine("Type your answer:");
        timer.Start();

    }

    public override State? Process()
    {
        MathOperation op = operations[operationIndex];
        var input = Console.ReadLine();
        int result;
        while (!int.TryParse(input, out result))
        {
            Console.WriteLine("Your answer need to be an Integer. Try again.");
            input = Console.ReadLine();
        }
        timer.Stop();
        timer.Dispose();
        if (timeCounter == 0)
        {
            Console.WriteLine("Your ran out of time. Type any key to continue.");
        }
        else
        {
            if (result == op.OperationResult)
            {
                RunScore += Helpers.CalculateScore(op.OperationDifficulty, timeCounter);
                Console.WriteLine($"Your answer is correct. You get {Helpers.CalculateScore(op.OperationDifficulty, timeCounter)} points. Run Score is: {RunScore}. Type any key to continue.");
            }
            else
            {
                Console.WriteLine("Your answer is incorrect. Type any key to continue.");
            }
        }
        operationIndex++;
        Console.ReadLine();
        if (operationIndex == operations.Count)
        {
            _context.SessionScore += RunScore;
            // Save Game Wrun Info
            _context.gameHistory.Add(new Game()
            {
                UserScore = _context.SessionScore,
                RunScore = RunScore,
                Date = Helpers.GetDate(),
                Type = operations[0].Operator,
                Questions = operations.Count,
                Difficulty = _context._settings.Difficulty
            });
            return new MainMenu();
        }
        else
        {
            return this;
        }
    }
}