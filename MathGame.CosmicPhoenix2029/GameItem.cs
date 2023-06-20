namespace MathGame;

public class GameItem
{
    //only allow subclases to get and set the properties:
    private Random randomNumber = new();
    public string Difficulty { get; set; }
    public string GameMode { get; set; }
    public string Question { get; private set; }
    public int PlayerAnswer { get; private set; }
    public int CorrectAnswer { get; private set; }

    //no set is required:
    public int NumOne { get; private set; }
    public int NumTwo { get; private set; }
    public int NumThree { get; private set; }
    public int NumFour { get; private set; }

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
        //for the division logic, I have overridden the Nums to ensure the result is between 0-100
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
                NumOne = randomNumber.Next(25, 50);
                NumTwo = randomNumber.Next(1, 10);
                Question = $"Rounded down to the nearest whole number, what is {NumOne} / {NumTwo}";
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
                Question = $"Rounded down to the nearest whole number, what is {NumOne} / {NumTwo} / {NumThree}";
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
                Question = $"Rounded down to the nearest whole number, what is {NumOne} / {NumTwo} / {NumThree} / {NumFour}";
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
        //additional logic for division questions 
        if (GameMode.Equals("D"))
        {
            switch (Difficulty)
            {
                case "E":
                    NumOne = randomNumber.Next(10, 100);
                    NumTwo = randomNumber.Next(1, 5);
                    return EasyQuestion();
                case "M":
                    NumOne = randomNumber.Next(25, 100);
                    NumTwo = randomNumber.Next(1, 10);
                    NumThree = randomNumber.Next(1, 5);
                    return MediumQuestion();
                case "H":
                    NumOne = randomNumber.Next(50, 100);
                    NumTwo = randomNumber.Next(1, 5);
                    NumThree = randomNumber.Next(1, 3);
                    NumFour = randomNumber.Next(1, 3);
                    return HardQuestion();
                default:
                    NumOne = randomNumber.Next(25, 100);
                    NumTwo = randomNumber.Next(1, 10);
                    NumThree = randomNumber.Next(1, 5);
                    return MediumQuestion();
            }
        }
        else
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
}