using System.Diagnostics;
namespace MathGame;

public class GameEngine
{
    //gameEngine properties:
    public string GameMode { get; set; }
    public string Difficulty { get; set; }
    public int NumberOfQuestions { get; set; }
    public int Score { get; private set; }
    //using stopwatch to get the time elapsed in game
    public string TimeTaken { get; set; }
    //list to store the game history:
    public List<string> Results { get; set; }

    //construct a new game
    public GameEngine(string gameMode, string difficulty, int numberOfQuestions)
    {
        GameMode = gameMode;
        Difficulty = difficulty;
        NumberOfQuestions = numberOfQuestions;
        Results = new List<string> { };
        Score = 0;
        TimeTaken = "";
    }

    //iterate through the number of questions, passing the GameMode and Difficulty onto the GameItem class
    public string StartGame()
    {
        long startTime = Stopwatch.GetTimestamp();

        for (int i = 0; i < NumberOfQuestions; i++)
        {
            if (GameMode.Equals("R"))
            {
                Random number = new();
                int num = number.Next(1, 4);
                switch (num)
                {
                    case 1: GameMode = "A"; break;
                    case 2: GameMode = "S"; break;
                    case 3: GameMode = "M"; break;
                    case 4: GameMode = "D"; break;
                }

                GameItem question = new(GameMode, Difficulty);
                GameMode = "R";
                string result = question.AskQuestion();
                Results.Add(result);
                if (question.PlayerAnswer == question.CorrectAnswer) { Score++; }
            }

            else
            {
                GameItem question = new(GameMode, Difficulty);
                string result = question.AskQuestion();
                Results.Add(result);
                if (question.PlayerAnswer == question.CorrectAnswer) { Score++; }
            }
        }

        TimeTaken = Stopwatch.GetElapsedTime(startTime).ToString(@"mm\:ss");
        return RecordGame();
    }

    public string RecordGame()
    {
        string gameMode = "";
        string difficulty = "";
        //switch through the gamemodes to add to results
        switch (GameMode)
        {
            case "A": gameMode = "Addition"; break;
            case "S": gameMode = "Subtraction"; break;
            case "M": gameMode = "Multiplication"; break;
            case "D": gameMode = "Division"; break;
            case "R": gameMode = "Random"; break;
        }

        switch (Difficulty)
        {
            case "E": difficulty = "Easy"; break;
            case "M": difficulty = "Medium"; break;
            case "H": difficulty = "Hard"; break;
        }

        string gameResults = $"GameMode: {gameMode}\n"
            + $"Difficulty: {difficulty}\n"
            + $"Number of questions: {NumberOfQuestions}\n"
            + $"Total score: {Score}/{NumberOfQuestions}\n"
            + $"Time taken: {TimeTaken}\n\n"
            + "Listed below are the questions and answers:\n";

        foreach (string result in Results)
        {
            gameResults += result;
        }
        return gameResults;
    }
}