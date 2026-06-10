using System.Text;

// Menu strings.
string[] menuOptions = { "CSharpAcademy - MathGame\n", "1 - Start", "2 - Random mode", "3 - Scoreboard", "4 - Exit", "Enter menu option # & press enter:" };
string[] menuOperatorOptions = { "Select an operator type\n", "1 - Addition", "2 - Subtraction", "3 - Multiplication", "4 - Division", "5 - Any" };


// Main loop (and game) exit.
bool exit = false;

// Game history tracking
GameInfo currentGameInfo = new GameInfo();
int currentScore = 0;
List<GameInfo> gameHistory = new List<GameInfo>();
int gameCounter = 0;

// Game management
const int RandomQuestionAmount = 5;
int[,] questionBank = new int[5, 3]; // holds question bank once operator type is selected ('standard' mode only).

//pre-set question data
int[,] questionDataAny = new int[5, 3]
{
    //value1, value2, sign 0-3 (+ - * /)
    {50, 10, 3},
    {7, 8, 2},
    {6, 2, 1},
    {5, 3, 0},
    {12, 2, 3},
};

int[,] questionDataAddition = new int[5, 3]
{
    //value1, value2, sign 0-3 (+ - * /)
    { 5, 17, 0 },
    { 23, 8, 0 },
    { 12, 14, 0 },
    { 3, 21, 0 },
    { 19, 6, 0 }
};

int[,] questionDataSubtraction = new int[5, 3]
{
    //value1, value2, sign 0-3 (+ - * /)
    { 3, 7, 1 },
    { 12, 4, 1 },
    { 8, 15, 1 },
    { 21, 9, 1 },
    { 6, 18, 1 }
};

int[,] questionDataMultiplication = new int[5, 3]
{
    //value1, value2, sign 0-3 (+ - * /)
    { 14, 3, 2 },
    { 7, 19, 2 },
    { 22, 5, 2 },
    { 9, 11, 2 },
    { 16, 8, 2 }
};

int[,] questionDataDivision = new int[5, 3]
{
    //value1, value2, sign 0-3 (+ - * /)
    { 24, 6, 3 },
    { 18, 3, 3 },
    { 35, 5, 3 },
    { 81, 9, 3 },
    { 14, 7, 3 }
};


//main loop
while (!exit)
{
    ShowMainMenu();
    NewGame();
    ReadMainMenuInput();
}

//Show main menu.
void ShowMainMenu()
{
    Console.Clear();
    foreach (string s in menuOptions)
    {
        Console.WriteLine(s);
    }
}

//Read user input and execute corresponding action.
void ReadMainMenuInput()
{
    switch (Console.ReadLine())
    {
        case "1":
            ShowOperatorSelectionMenu();
            startGame();
            break;
        case "2":
            startRandomGame(ShowOperatorSelectionMenuRandom());
            break;
        case "3":
            ShowGameHistory();
            break;
        case "4":
            //Change exit bool/flag to true to exit the program.
            exit = true;
            break;
        default:
            Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            ReadMainMenuInput();
            break;
    }
}

void ShowOperatorSelectionMenu()
{
    Console.Clear();
    foreach (string s in menuOperatorOptions)
    {
        Console.WriteLine(s);
    }

    switch (Console.ReadLine())
    {
        case "1":
            questionBank = questionDataAddition;
            currentGameInfo.OperatorType = "Addition";
            break;
        case "2":
            questionBank = questionDataSubtraction;
            currentGameInfo.OperatorType = "Subtraction";
            break;
        case "3":
            questionBank = questionDataMultiplication;
            currentGameInfo.OperatorType = "Multiplication";
            break;
        case "4":
            questionBank = questionDataDivision;
            currentGameInfo.OperatorType = "Division";
            break;
        case "5":
            questionBank = questionDataAny;
            currentGameInfo.OperatorType = "Any";
            break;
        default:
            Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            ReadMainMenuInput();
            break;
    }
}

int ShowOperatorSelectionMenuRandom()
{
    Console.Clear();
    foreach (string s in menuOperatorOptions)
    {
        Console.WriteLine(s);
    }
    while (true)
    {
        switch (Console.ReadLine())
        {
            case "1":
                currentGameInfo.OperatorType = "Addition";
                return 0;
            case "2":
                currentGameInfo.OperatorType = "Subtraction";
                return 1; ;
            case "3":
                currentGameInfo.OperatorType = "Multiplication";
                return 2; ;
            case "4":
                currentGameInfo.OperatorType = "Division";
                return 3; ;
            case "5":
                currentGameInfo.OperatorType = "Any";
                return -1; ;
            default:
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                break;
        }
    }
}

//Show question and calc answer based on given values and symbol, return answer.
int ShowQuestion(int value1, int value2, int symbol, int questionNumber)
{
    //set symbol string based, calc answer, ask question, and return answer
    string symbolString = "";
    int calculatedAnswer = -1;

    switch (symbol)
    {
        case 0:
            symbolString = "+";
            calculatedAnswer = value1 + value2;
            break;
        case 1:
            symbolString = "-";
            calculatedAnswer = value1 - value2;
            break;
        case 2:
            symbolString = "*";
            calculatedAnswer = value1 * value2;
            break;
        case 3:
            symbolString = "/";
            calculatedAnswer = value1 / value2;
            break;
    }
    Console.WriteLine($"Question {questionNumber}: What is {value1} {symbolString} {value2}?");
    return calculatedAnswer;
}

void ShowGameHistory()
{
    Console.Clear();
    Console.WriteLine("--- GAME HISTORY ---\n");

    foreach (GameInfo gi in gameHistory)
    {
        Console.WriteLine(gi.GetGameHistory());
    }

    Console.WriteLine("\n{ PRESS ENTER TO RETURN THE MAIN MENU }");
    Console.ReadLine();
}

void NewGame()
{
    gameCounter++;
    currentScore = 0;
    currentGameInfo.NewGame();
    currentGameInfo.GameNumber = gameCounter;
}

void startGame()
{
    currentGameInfo.Gametype = "Standard";
    int consoleInput;
    int solution;
    //Ask questions from the bank
    for (int i = 0; i < questionBank.GetLength(0); i++)
    {
        solution = ShowQuestion(questionBank[i, 0], questionBank[i, 1], questionBank[i, 2], i + 1);
        if (int.TryParse(Console.ReadLine(), out consoleInput))
        {
            if (consoleInput == solution)
            {
                // + - * /)
                currentScore++;
                currentGameInfo.Questions.Add($"Question {i + 1}: What is {questionBank[i, 0]} {questionBank[i, 2] switch { 0 => "+", 1 => "-", 2 => "*", 3 => "/" }} {questionBank[i, 1]}?");
                currentGameInfo.Answers.Add($"CORRECT!: You answered: {consoleInput}");
                Console.WriteLine("Correct!");
            }
            else
            {
                currentGameInfo.Questions.Add($"Question {i + 1}: What is {questionBank[i, 0]} {questionBank[i, 2] switch { 0 => "+", 1 => "-", 2 => "*", 3 => "/" }} {questionBank[i, 1]}?");
                currentGameInfo.Answers.Add($"INCORRECT: You entered: {consoleInput} | Answer: {solution}");
                Console.WriteLine("Incorrect.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            //go back to the previous loop iteration.
            i = i - 1;
        }

    }
    EndGame();
}

void startRandomGame(int signOverride = -1)
{
    currentGameInfo.Gametype = "Random";
    //used to so that a new question is not generated when bad input is detected & we restart the loop.
    bool generateRandoms = true;
    int consoleInput;
    int solution;
    int[] randomQuestionData = new int[3];

    for (int i = 0; i < RandomQuestionAmount; i++)
    {
        if (generateRandoms)
        {
            randomQuestionData = GetRandomQuestionData(signOverride);
        }
        solution = ShowQuestion(randomQuestionData[0], randomQuestionData[1], randomQuestionData[2], i + 1);
        if (int.TryParse(Console.ReadLine(), out consoleInput))
        {
            if (consoleInput == solution)
            {
                currentScore++;
                currentGameInfo.Questions.Add($"Question {i + 1}: What is {randomQuestionData[0]} {randomQuestionData[2] switch { 0 => "+", 1 => "-", 2 => "*", 3 => "/" }} {randomQuestionData[1]}?");
                currentGameInfo.Answers.Add($"CORRECT!: You answered: {consoleInput}");
                Console.WriteLine("Correct!");
            }
            else
            {
                currentGameInfo.Questions.Add($"Question {i + 1}: What is {randomQuestionData[0]} {randomQuestionData[2] switch { 0 => "+", 1 => "-", 2 => "*", 3 => "/" }} {randomQuestionData[1]}?");
                currentGameInfo.Answers.Add($"INCORRECT: You entered: {consoleInput} | Answer: {solution}");
                Console.WriteLine("Incorrect.");
            }
            generateRandoms = true;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            generateRandoms = false;
            //repeat this iteration of the loop.
            i = i - 1;
        }
    }
    EndGame();
}

void EndGame()
{
    // Store game info
    currentGameInfo.GameEndDate = DateTime.Now;
    currentGameInfo.HighScore = currentScore;
    gameHistory.Add(currentGameInfo.GetClone());
    // End of game
    Console.WriteLine($"\nGAME OVER! Your score is {currentScore}.\n");
    Console.WriteLine("{ PRESS ENTER TO RETURN THE MAIN MENU }");
    Console.ReadLine();
    Console.Clear();
}

int[] GetRandomQuestionData(int signOverride = -1) // Allow forcing a sign.
{
    int sign;
    int value1 = 0;
    int value2 = 0;
    //determine sign
    if (signOverride > -1)
    {
        sign = signOverride;
    }
    else
    {
        sign = Random.Shared.Next(0, 4);
    }

    if (sign == 3)
    {
        while (true)
        {
            value1 = Random.Shared.Next(1, 100);
            value2 = Random.Shared.Next(1, 100);

            if ((value1 % value2) == 0)
            {
                //value found that can be divided without remainder, break loop and return values.
                break;
            }
        }
    }
    else
    {
        value1 = Random.Shared.Next(1, 100);
        value2 = Random.Shared.Next(1, 100);
    }
    return new int[] { value1, value2, sign };
}
public class GameInfo
{
    private int _gameNumber;
    private int _highscore;
    private string _gameType;
    private string _operatorType;
    private List<string> _questions;
    private List<string> _answers;
    private DateTime _gameStartDate;
    private DateTime _gameEndDate;

    public int GameNumber { set { _gameNumber = value; } }
    public int HighScore { set { _highscore = value; } }
    public string Gametype { set { _gameType = value; } }
    public List<string> Questions { get { return _questions; } set { _questions = value; } }
    public List<string> Answers { get { return _answers; } set { _answers = value; } }
    public DateTime GameStartDate { set { _gameStartDate = value; } }
    public DateTime GameEndDate { set { _gameEndDate = value; } }
    public string OperatorType { set { _operatorType = value; } }

    public void NewGame()
    {
        _highscore = 0;
        _gameNumber = 0;
        _gameType = "";
        _questions = new List<string>();
        _answers = new List<string>();
        _gameStartDate = DateTime.Now;
        _gameEndDate = _gameStartDate;
    }

    public GameInfo GetClone()
    {
        GameInfo info = new GameInfo();
        info.GameNumber = _gameNumber;
        info.HighScore = _highscore;
        info.Gametype = _gameType;
        info.Questions = _questions;
        info.Answers = _answers;
        info.GameStartDate = _gameStartDate;
        info.GameEndDate = _gameEndDate;
        info.OperatorType = _operatorType;
        return info;
    }

    public string GetGameHistory()
    {
        StringBuilder history = new StringBuilder();
        history.AppendLine($"Game #{_gameNumber}:");
        history.AppendLine($"Score: {_highscore}");
        history.AppendLine($"Game Type: {_gameType}");
        history.AppendLine($"Operator Type: {_operatorType}");
        history.AppendLine($"Game Time (hh:mm:ss): {((TimeSpan)(_gameEndDate - _gameStartDate)).ToString(@"hh\:mm\:ss")}");
        history.AppendLine($"");
        history.AppendLine($"Questions and answers:");
        history.AppendLine("");
        for (int i = 0; i < _questions.Count; i++)
        {
            history.AppendLine($"{_questions[i].ToString()}");
            history.AppendLine($"{_answers[i].ToString()}");
            history.AppendLine("");
        }
        return history.ToString();
    }
}