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
                throw new InvalidOperationException("\nInvalid operation try again");
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
                throw new InvalidOperationException("\nInvalid operation");
        }
    }
    private static bool IsWinner(Game game, int questionAnswered)
    {
        if (game.CheckWinner(questionAnswered))
        {
            Console.WriteLine("\nGood job, You are the winner :)");
            return true;
        }
        else
        {
            Console.WriteLine("Game over! You have lost *_* :(");
            return false;
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
        Console.WriteLine("Q - Quit");
        Console.WriteLine("--------------------------------------------------");
        Console.Write("");
    }
    private static string AskUserToSelectOption(){
         DisplayMenu();
         return Console.ReadKey().KeyChar.ToString().ToUpper();
    }
    private static int GetQuestionNumber()
    {
        Console.Write("\nHow many questions to ask? ");
        int.TryParse(Console.ReadLine(), out int questionNumber);
        return questionNumber;
    }
    private static string DisplayErrorMessageAndResetGame(string errorMessage){
        Console.Error.WriteLine(errorMessage);
        return AskUserToSelectOption();
    }
  
    private static void GameCycle(Game game, Operations operations, int questionToAsk, string oper)
    {
        int questions = questionToAsk;
        int result = 0;
        string operation = "";
        int stepToQuestion = 0;

        Random random = new Random();

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
                        oper = DisplayErrorMessageAndResetGame(ex.Message);
                       
                    }
                    result = operations.Multiplication(randomNumber1, randomNumber2);
                    try
                    {
                    game.CheckRecord(randomNumber1, operation, randomNumber2, result);
                    }
                    catch (Exception ex)
                    {
                       oper =DisplayErrorMessageAndResetGame(ex.Message);
                    }
                    break;
                case "A":
                    try
                    {
                        operation = GetOperation(oper);
                    }
                    catch (InvalidOperationException ex)
                    {
                        oper = DisplayErrorMessageAndResetGame(ex.Message);
                    }
                    result = operations.Addition(randomNumber1, randomNumber2);
                    try{
                        game.CheckRecord(randomNumber1, operation, randomNumber2, result);
                    }
                    catch(Exception ex){
                        oper = DisplayErrorMessageAndResetGame(ex.Message);
                    }
                    break;
                case "S":
                    try
                    {
                        operation = GetOperation(oper);
                    }
                    catch (InvalidOperationException ex)
                    {
                        oper = DisplayErrorMessageAndResetGame(ex.Message);
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
                        oper= DisplayErrorMessageAndResetGame(ex.Message);
                    }
                    int dividend = random.Next(0, 100);
                    result = operations.Division(randomNumber1, dividend);
                    if (result != 0)
                    {
                        try
                        {
                             game.CheckRecord(randomNumber1, operation, dividend, result);
                        }
                        catch (Exception ex)
                        {
                           oper= DisplayErrorMessageAndResetGame(ex.Message);
                        } 
                    }
                    break;
                case "V":
                    game.VisualizeHistory();
                    stepToQuestion = questionToAsk;
                    oper = AskUserToSelectOption();
                    break;
                case "Q":
                    Environment.Exit(0);
                    break;
                case "R":
                    oper = game.GetRandomOperator();
                    break;
                default:
                    Console.Write("\nInvalid operator, Press any key to try again ");
                    Console.ReadLine();
                    oper = AskUserToSelectOption();
                    break;

            }
            stepToQuestion++;
            if (stepToQuestion == questions)
            {
                if(IsWinner(game, questions)){
                    Console.Write("Press any key to continue");
                    Console.ReadLine();
                }
            }
        }
        if (oper != "V" && oper != "R" && oper != "Q")
            SaveRecord(oper, game);
    }
    private static void SetUpGame()
    {
        Operations operations = new Operations();
        Game game = new Game();
        int questionToAsk = GetQuestionNumber();
        string oper;
        do
        {
            oper = AskUserToSelectOption();
            GameCycle(game, operations, questionToAsk, oper);
            game.IncreaseLevel();
        } while (oper != "Q"); 
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