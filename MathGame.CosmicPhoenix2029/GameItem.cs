namespace MathGame;

public class GameItem
{
    //only allow subclases to get and set the properties:
    readonly Random randomNumber = new();
    public string Difficulty { get; set; }
    public string GameMode { get; set; }
    public string Question { get; private set; }
    public int PlayerAnswer { get; private set; }
    public int CorrectAnswer { get; private set; }

    //no set is required:
    public int NumOne { get; }
    public int NumTwo { get; }
    public int NumThree { get; }
    public int NumFour { get; }

    //some fields for the Easy, Medium and Hard methods
    bool intCoverted;
    int result;

    public GameItem(string gameMode, string difficulty)
    {
        GameMode = gameMode;
        Difficulty = difficulty;
        NumOne = randomNumber.Next(1, 100);
        NumTwo = randomNumber.Next(1, 100);
        NumThree = randomNumber.Next(1, 100);
        NumFour = randomNumber.Next(1, 100);
        Question = string.Empty;
    }

    //methods for each subclass to use: (askQuestion invokes any of the E, M or H methods, which invokes the Build Answer method)
    string BuildAnswer()
    {
        return $"Question: {Question}\n"
            + $"You Answered: {PlayerAnswer}\n"
            + $"The correct Answer was: {CorrectAnswer}\n";
    }

    string EasyQuestion()
    {
        //switch through each operation and generate the question and answer
        switch (GameMode)
        {
            case "A":
                Question = $"What is {NumOne} + {NumTwo}";
                CorrectAnswer = NumOne + NumTwo;
                break;
            case "S":
                Question = $"What is {NumOne} - {NumTwo}";
                CorrectAnswer = NumOne - NumTwo;
                break;
            case "M":
                Question = $"What is {NumOne} * {NumTwo}";
                CorrectAnswer = NumOne * NumTwo;
                break;
            case "D":
                Question = $"What is {NumOne} / {NumTwo}";
                CorrectAnswer = NumOne / NumTwo;
                break;
        }

        while (!intCoverted)
        {
            Console.WriteLine(Question);
            intCoverted = int.TryParse(Console.ReadLine(), out result);
            Console.Clear();
        }

        PlayerAnswer = result;
        return BuildAnswer();
    }

    string MediumQuestion()
    {
        //switch through each operation and generate the question and answer
        switch (GameMode)
        {
            case "A":
                Question = $"What is {NumOne} + {NumTwo} + {NumThree}";
                CorrectAnswer = NumOne + NumTwo + NumThree;
                break;
            case "S":
                Question = $"What is {NumOne} - {NumTwo} - {NumThree}";
                CorrectAnswer = NumOne - NumTwo - NumThree;
                break;
            case "M":
                Question = $"What is {NumOne} * {NumTwo} * {NumThree}";
                CorrectAnswer = NumOne * NumTwo * NumThree;
                break;
            case "D":
                Question = $"What is {NumOne} / {NumTwo} / {NumThree}";
                CorrectAnswer = NumOne / NumTwo / NumThree;
                break;
        }

        while (!intCoverted)
        {
            Console.WriteLine(Question);
            intCoverted = int.TryParse(Console.ReadLine(), out result);
            Console.Clear();
        }
        PlayerAnswer = result;
        return BuildAnswer();
    }

    string HardQuestion()
    {
        //switch through each operation and generate the question and answer
        switch (GameMode)
        {
            case "A":
                Question = $"What is {NumOne} + {NumTwo} + {NumThree} + {NumFour}";
                CorrectAnswer = NumOne + NumTwo + NumThree + NumFour;
                break;
            case "S":
                Question = $"What is {NumOne} - {NumTwo} - {NumThree} - {NumFour}";
                CorrectAnswer = NumOne - NumTwo - NumThree - NumFour;
                break;
            case "M":
                Question = $"What is {NumOne} * {NumTwo} * {NumThree} * {NumFour}";
                CorrectAnswer = NumOne * NumTwo * NumThree * NumFour;
                break;
            case "D":
                Question = $"What is {NumOne} / {NumTwo} / {NumThree} / {NumFour}";
                CorrectAnswer = NumOne / NumTwo / NumThree / NumFour;
                break;
        }

        while (!intCoverted)
        {
            Console.WriteLine(Question);
            intCoverted = int.TryParse(Console.ReadLine(), out result);
            Console.Clear();
        }
        PlayerAnswer = result;
        return BuildAnswer();
    }

    //public as GameEngine needs to call this method
    public string AskQuestion()
    {
        return Difficulty switch
        {
            "E" => EasyQuestion(),
            "M" => MediumQuestion(),
            "H" => HardQuestion(),
            //the while loop inside menu (line 28) ensures it's not possible to hit the default case, however default to a meduim question
            _ => MediumQuestion(),
        };
    }
}