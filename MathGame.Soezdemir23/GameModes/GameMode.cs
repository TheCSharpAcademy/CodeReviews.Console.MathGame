
using System.Diagnostics;
using mathgame.Model;

namespace mathgame.GameModes;

/// <summary>
/// Base class for all game modes in the math game.
/// </summary>
public abstract class GameMode
{
    /// <summary>
    /// Random number generator used for creating math questions.
    /// </summary>
    protected readonly Random _random = new();

    /// <summary>
    /// Runs the game mode for the specified player.
    /// </summary>
    /// <param name="player">The player participating in the game.</param>
    /// <returns>The player with updated points and time taken.</returns>
    public Player Play(Player player)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        int maxRound = 5, round = 0;
        while (round < maxRound)
        {
            Console.WriteLine($"Testing stopwatch {stopwatch.Elapsed} ");
            var (left, right, answer) = GenerateQuestion();
            bool awaitingAnswer = true;
            while (awaitingAnswer)
            {
                Console.WriteLine($"{GetModeName()} mode:");
                Console.WriteLine($"Solve this: {left} {GetOperatorSymbol()} {right}");
                Console.WriteLine($"You have currently: {player.GetPoints()}");
                Console.WriteLine($"Round {round + 1} of {maxRound}");
                Console.WriteLine("Enter q or quit to quit the game");

                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out int result))
                {
                    if (result == answer) { Console.WriteLine("Correct! You gain a point"); player.GainPoint(); round++; awaitingAnswer = false; }
                    else { Console.WriteLine("Wrong! You lose a point"); player.LosePoint(); }
                }
                else if (input.Equals("q", StringComparison.OrdinalIgnoreCase) || input.Equals("quit", StringComparison.OrdinalIgnoreCase))
                { Console.WriteLine("Exiting the game mode"); Console.WriteLine($"Your Score is {player.GetPoints()}"); Console.WriteLine("Press any key."); return player; }
                else { Console.WriteLine("Please enter a valid command"); }

                Console.Write("Enter a key to continue:"); Console.ReadKey(); Console.Clear();
            }
            Thread.Sleep(1500); Console.Clear();
        }
        stopwatch.Stop();
        player.SetTimeTaken(stopwatch.Elapsed.Minutes, stopwatch.Elapsed.Seconds);
        return player;
    }
    protected abstract (int left, int right, int answer) GenerateQuestion();
    protected abstract string GetModeName();
    protected abstract string GetOperatorSymbol();
}