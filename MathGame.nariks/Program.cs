List<string> gameHistory = new List<string>();
gameHistory.Add("Question\t\t| Solution\t| Your Answer");

StartGame();
Console.WriteLine("\n>> Game Over !!!");
Console.WriteLine(">> Press Enter to continue...");    

void DisplayMenu()
{
    Console.Clear();
    Console.WriteLine("Welcome to the Math Game. Enter your choice:");
    Console.WriteLine("1 - Addition Game");
    Console.WriteLine("2 - Subtraction Game");
    Console.WriteLine("3 - Multiplication Game");
    Console.WriteLine("4 - Division Game");
    Console.WriteLine("5 - View previous games");
    Console.WriteLine("6 - End Game\n");
}

void StartGame()
{
    do
    {
        int difficulty = 0;
        int quizLength = 1;
        string operation = "";

        do
        {
            DisplayMenu();
            int gameChoice = ReadUserInput();
            operation = ChooseOperation(gameChoice);

            if (operation == "")
            {
                return;
            }
            else if (operation == "show")
            {
                ShowHistory();
                goto PlayAgain;
            }
                
            do
                {
                    difficulty = ChooseDiffictulty();
                    if (difficulty != 6)
                        quizLength = ChooseQuizLength();
                } while (difficulty!= 6 && quizLength == 6);            // Go back to difficulty menu
                

            } while (difficulty == 6);                                  // Go back to main menu

        PlayGame(operation, difficulty, quizLength);

        PlayAgain:
        continue;

    } while (PlayAgain());
}

string ChooseOperation(int gameChoice)
{
    switch (gameChoice)
    {
        case 1:
            return "addition";

        case 2:
            return "subtraction";

        case 3:
            return "multiplication";

        case 4:
            return "division";

        case 5:
            return "show";

        case 6:
        default:
            return "";
    }
}

int ChooseDiffictulty()
{
    DisplayHeading("Difficulty Menu");
    Console.WriteLine(">> Choose a difficulty level from 1 (Easy) - 5 (Hard)");
    Console.WriteLine(">> Or enter 6 to go back to main menu\n");
    
    return ReadUserInput();
}

int ChooseQuizLength()
{
   DisplayHeading("Quiz Length");
    Console.WriteLine("Choose number of quiz questions: 1 - 5");
    Console.WriteLine("Or enter 6 to go back to main menu\n");

    return ReadUserInput();
    
}

void PlayGame(string game, int difficulty = 1, int quizLength = 1)
{
    int score = 0;
    int solution = 0;
    
    Dictionary<string, string> operation = new Dictionary<string, string> 
                                            { {"addition", "+"}, {"subtraction", "-"}, {"multiplication", "*"}, {"division", "/"} };
    
    string message = $"{game.ToUpper()} selected";
    DisplayHeading(message);
    
    int minValue = SetDifficultyLevel(difficulty);

    for(int i = 0; i < quizLength; i++)
    {
        int[] operands = new int[2];
        operands = GetRandomNumbers(minValue, game, difficulty);
        solution = CalculateResult(game, operands[0], operands[1]);

        string question =  $"( {operands[0]} {operation[game]} {operands[1]} )";
        Console.WriteLine($"Qn{i+1}: What is {question} ?");
        
        int playerAnswer = GetPlayerSolution();
        
        gameHistory.Add(question + "\t\t| " + solution + "\t\t| " + playerAnswer);

        if (playerAnswer == solution)
        {
            Console.WriteLine("That's correct. \u2705\n");  
            score++;  
        }
        else
        {
            Console.WriteLine("That's not correct. \u274c\n");
        }
            
    }
    Console.WriteLine($"Game Over ! You scored {score} out of {quizLength} points\n");
}

int SetDifficultyLevel (int difficulty)
{
    switch(difficulty)
    {
        case 1:
            return 1;
        
        case 2:
            return 20;

        case 3:
            return 40;

        case 4:
            return 60;

        case 5:
            return 80;

        default:
            return 0;
    }

}

int ReadUserInput()
{
    string? readResult = "";
    int userChoice = 0;
    bool validEntry = false;

    do
    {
        Console.WriteLine("Enter a number from 1 to 6");
        readResult = Console.ReadLine();
        validEntry = int.TryParse(readResult, out userChoice);
        
        if (userChoice < 1 || userChoice > 6)
            validEntry = false;
                
    } while (!validEntry);

    return userChoice;

}

bool PlayAgain()
{
    Console.WriteLine("Would you like to play again (Y/N)?");
    string? readResult = Console.ReadLine(); 
    if (readResult != null)
        return (readResult.ToLower() == "y");
    else
        return false;
}

int GetPlayerSolution()
{
    int answer = 0;
    bool validEntry = false;
        
    do
    {
        string? readResult = Console.ReadLine();
        validEntry = int.TryParse(readResult, out answer);
        if (!validEntry)
            Console.WriteLine("Only numbers can be accepted as valid answer.");

    } while (!validEntry);

    return answer;
}

void ShowHistory()
{
    Console.Clear();
    Console.WriteLine("Game History\n");

    if (gameHistory.Count() == 1)
    {
        Console.WriteLine("No Games played yet!");
        return;
    }
    
    foreach (string game in gameHistory)
    {
        Console.WriteLine(game);
    }

    Console.WriteLine("\nPress Enter to continue");
    Console.ReadLine();
}

void DisplayHeading (string message)
{
    Console.Clear();
    Console.WriteLine(message);
    Console.WriteLine("--------------------\n");
}

int CalculateResult(string game, int operand1, int operand2)
{
    switch(game)
        {
            case "addition":
                return operand1 + operand2;

            case "subtraction":
                return operand1 - operand2;
                
            case "multiplication":
                return operand1 * operand2;

            case "division":
                return operand1 / operand2;
            
            default:
                return 0;
        }
}

int[] GetRandomNumbers( int minValue, string game, int difficulty)
{
    const int stepSize = 21;
    Random randomNumber = new Random();
    int[] operands = new int[2];
    int minValue2 = (difficulty > 2) ? 1 : stepSize;

    operands[0] = randomNumber.Next(minValue, minValue + stepSize);
    operands[1] = randomNumber.Next(minValue2, minValue + stepSize);
    while (game == "division" && (operands[0] % operands[1] != 0)) 
    {
        operands[1] = randomNumber.Next(1, minValue + stepSize);
    }

    return operands; 

}