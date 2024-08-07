using MathGame;

class Application
{
    private static void Main(String[] args)
    {

        try
        {
            SetUpGame();
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
        }
        
    }

    private static string GetOperation(string oper)
    {
        switch (oper)
        {
            case "M":
                return "*";
            case "S":
                return "-";
            case "D":
                return "/";
            case "A":
                return "+";
            default:
                throw new InvalidOperationException("Invalid operation");
        }
    }
    private static string GetOperationName(string oper)
    {
        switch (oper)
        {
            case "M":
                return "Multiplation";
            case "S":
                return "Substraction";
            case "D":
                return "Division";
            case "A":
                return "Addition";
            default:
                throw new InvalidOperationException("Invalid operation");
        }
    }
    private static void WhoWins(Game game, int questionAnswered)
    {
        if (game.CheckWinner(questionAnswered))
        {
            Console.WriteLine("\nGood job, You are the winner :)");
        }
        else
        {
            Console.WriteLine("Game over! You have lost *_* :(");
        }
    }
    private static void DisplayMenu()
    {
        Console.WriteLine("\nWhat game would you like to play? Choose from the options below:  ");
        Console.WriteLine("V - View Previous Games");
        Console.WriteLine("A - Addition");
        Console.WriteLine("S - Substraction");
        Console.WriteLine("D - Division");
        Console.WriteLine("M - Multiplication");
        Console.WriteLine("R - Random Game");
        Console.WriteLine("--------------------------------------------------");
        Console.Write("");
    }
    private static int GetQuestionNumber()
    {
        Console.Write("\nHow many questions to ask? ");
        int.TryParse(Console.ReadLine(), out int questionNumber);
        return questionNumber;
    }
  
    private static void GameCycle(Game game, Operations operations, int questionToAsk)
    {
        int questions = questionToAsk;
        int result = 0;
        string operation = "";
        int stepToQuestion = 0;

        Random random = new Random();

        DisplayMenu();
        string oper = Console.ReadKey().KeyChar.ToString().ToUpper();

        while (stepToQuestion < questions)
        {
            int randomNumber1 = game.GetRandomNumberBasedOnLevelDifficulty();
            int randomNumber2 = game.GetRandomNumberBasedOnLevelDifficulty();
            switch (oper)
            {
                case "M":
                    try
                    {
                        operation = GetOperation(oper);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.Error.WriteLine(ex.Message);
                    }
                    result = operations.Multiplication(randomNumber1, randomNumber2);
                    game.CheckRecord(randomNumber1, operation, randomNumber2, result);
                   
                    break;
                case "A":
                    try
                    {
                        operation = GetOperation(oper);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.Error.WriteLine(ex.Message);
                    }
                    result = operations.Addition(randomNumber1, randomNumber2);
                    game.CheckRecord(randomNumber1, operation, randomNumber2, result);
                   
                    break;
                case "S":
                    try
                    {
                        operation = GetOperation(oper);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.Error.WriteLine(ex.Message);
                    }
                    result = operations.Substraction(randomNumber1, randomNumber2);
                    game.CheckRecord(randomNumber1, operation, randomNumber2, result);

                    break;
                case "D":
                    try
                    {
                        operation = GetOperation(oper);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.Error.WriteLine(ex.Message);
                    }
                    int dividend = random.Next(0, 100);
                    result = operations.Division(randomNumber1, dividend);
                    if (result != 0)
                    {
                        game.CheckRecord(randomNumber1, operation, dividend, result);
                    }
                    break;
                case "V":
                    game.VisualizeHistory();
                    stepToQuestion = questionToAsk;
                    break;
                case "Q":
                    Environment.Exit(0);
                    break;
                case "R":
                    oper = game.GetRandomOperator();
                    break;
                default:
                    throw new InvalidOperationException("Invalid operation");
            }
            stepToQuestion++;
            if (stepToQuestion == questions)
            {
                WhoWins(game, questions);
            }
        }
        if (oper != "V" && oper != "R" && oper != "Q")
            SaveRecord(oper, game);
    }
    private static void SetUpGame()
    {
        int cycles = 3;
        int stepToCycles = 0;
        Operations operations = new Operations();
        Game game = new Game();
        int questionToAsk = GetQuestionNumber();

        while (stepToCycles < cycles)
        {
            GameCycle(game, operations, questionToAsk);
            game.IncreaseLevel();
            stepToCycles++;
        }  
    }
    private static void SaveRecord(string oper, Game game)
    {
        try
        {
            string operation = "";
            string formatedRecord = "";

            operation = GetOperationName(oper);
            formatedRecord = game.FormatRecord(operation, game.score);
            game.Save(formatedRecord);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
      
    }
}