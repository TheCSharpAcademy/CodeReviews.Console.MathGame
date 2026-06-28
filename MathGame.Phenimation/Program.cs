using System.ComponentModel.DataAnnotations;

string playerName;
string selectedOperation = "addition";
int actualQuestionNumber = 1;
int numberOfQuestions = 5;
int gameNumber = 1;
List<List<string>> playerScores = new List<List<string>>();
string difficultyLevel = "medium";
string selectedGame = "training";
bool isRandom = false;
var aleatoryNumber = new Random();

Start();

void Menu()
{
    string response;
    do{
    Console.WriteLine("Do you want to play again('play'), see your history('history'), or quit('quit') ?");
    response = Console.ReadLine() ?? string.Empty;
    switch (response)
    {
        case "play":
        break;

        case "history":
        if (playerScores.Count == 0)
            {
                Console.WriteLine("Sorry, you haven't played yet");
            }
        else foreach (List<string> game in playerScores)
            {
                foreach (string info in game)
                {
                    Console.Write($"| {info} |");
                }
                Console.WriteLine("");
                Console.WriteLine("---");
            }
        break;

        case "quit":
        Environment.Exit(0);
        break;
    }
    }while(response != "play");
    Play();
}
void Play()
{
    GetGamemode();
    
    GetNumberOfQuestion();
    
    GetDifficulty();

    QuestionRunner();
}
void Start()
{
    Console.WriteLine("Welcome to the Simple Math Game!");
    playerName = GetPlayerName();
    Console.WriteLine($"Hello, {playerName}! Let's start the game.");

    Menu();
    
}

string GetPlayerName()
{
    Console.WriteLine("Please enter your name:");
    playerName = Console.ReadLine() ?? string.Empty;

    while (string.IsNullOrWhiteSpace(playerName))
    {
        Console.WriteLine("Name cannot be empty. Please enter your name:");
        playerName = Console.ReadLine() ?? string.Empty;
    }

    return playerName;
}
string GetOperationSelection()
{
    Console.WriteLine("First, please, choose an operation ! (addition, soustraction, division or multiplication)");
    bool correctChoice = false;
    do{
        selectedOperation = Console.ReadLine() ?? string.Empty;
        switch (selectedOperation)
        {
            case "addition":
            case "division":
            case "soustraction":
            case "multiplication":
            correctChoice = true;
            break;

            default:
                Console.WriteLine($"Sorry {playerName}, you chose a incorrect operation. Try again");
                break;
        }
    }while(!correctChoice);

    return selectedOperation;
}

void QuestionRunner(){
    int points = 0;
    while (actualQuestionNumber <= numberOfQuestions)
    {
        Console.WriteLine($"Question {actualQuestionNumber}:");
        var questionData = CreateQuestion();
        string actualQuestion = questionData.questionText;
        int correctAnswer = questionData.correctAnswer;

        Console.WriteLine(actualQuestion);

        string userAnswer = Console.ReadLine() ?? string.Empty;

        if (userAnswer == correctAnswer.ToString())
        {
            points++;
            Console.WriteLine($"Congratulations {playerName}, your answer is correct! You have now {points} point(s) !");
        }
        else
        {
            Console.WriteLine($"Sorry {playerName}, your answer is incorrect. The correct answer was {correctAnswer}.");
        }
        actualQuestionNumber++;
    }
    playerScores.Add(new List<string> { gameNumber.ToString(), selectedGame, difficultyLevel,points.ToString() });
    gameNumber++;
    actualQuestionNumber = 1;
    Menu();
}

(int correctAnswer, string questionText) CreateQuestion()
{
    if (isRandom)
    {
        int operationSelector = aleatoryNumber.Next(1,5);
        switch (operationSelector)
        {
            case 1:
            selectedOperation = "addition";
            break;

            case 2:
            selectedOperation = "soustraction";
            break;

            case 3:
            selectedOperation = "multiplication";
            break;

            case 4:
            selectedOperation = "division";
            break;
        }
    }
    switch (selectedOperation)
    {
        case "addition":
        case "soustraction":
        case "multiplication":
            return CreateAdditionSoustractionOrMultiplicationQuestion(selectedOperation);

        case "division":
            return CreateDivisionQuestion();

        default:
            return (0, "Invalid operation");
    }
}

(int correctAnswer, string questionText) CreateAdditionSoustractionOrMultiplicationQuestion(string selectedOperation)
{
    int num1 = 0;
    int num2 = 0;
    switch (difficultyLevel)
    {
        case "easy":
            num1 = aleatoryNumber.Next(1, 11);
            num2 = aleatoryNumber.Next(1, 11);
            break;

        case "medium":
            num1 = aleatoryNumber.Next(1, 101);
            num2 = aleatoryNumber.Next(1, 101);
            break;

        case "hard":
            num1 = aleatoryNumber.Next(1, 1001);
            num2 = aleatoryNumber.Next(1, 1001);
            break;

        default:
            num1 = aleatoryNumber.Next(1, 101);
            num2 = aleatoryNumber.Next(1, 101);
            break;
    }
    switch (selectedOperation)
    {
        case "addition":
            int correctAnswer = num1 + num2;
            string questionText = $"{num1} + {num2} = ?";
            return (correctAnswer, questionText);

        case "multiplication":
            correctAnswer = num1 * num2;
            questionText = $"{num1} x {num2} = ?";
            return (correctAnswer, questionText);

        case "soustraction":
            correctAnswer = num1 - num2;
            questionText = $"{num1} - {num2} = ?";
            return (correctAnswer, questionText);

        default:
            return (0, "Invalid operation");
    }
}

(int correctAnswer, string questionText) CreateDivisionQuestion()
{
    
    int num1 = 0;
    int num2;

    switch (difficultyLevel)
    {
        case "easy":
            num1 = aleatoryNumber.Next(2, 11);
            break;

        case "medium":
            num1 = aleatoryNumber.Next(2, 101);
            break;

        case "hard":
            num1 = aleatoryNumber.Next(2, 1001);
            break;

        default:
            num1 = aleatoryNumber.Next(2, 101);
            break;
    }

    int securityIterationNumber = 0;
    do
    {
        if (securityIterationNumber > 100)
        {
            switch (difficultyLevel)
            {
                case "easy":
                    num1 = aleatoryNumber.Next(2, 11);
                    break;

                case "medium":
                    num1 = aleatoryNumber.Next(2, 101);
                    break;

                case "hard":
                    num1 = aleatoryNumber.Next(2, 1001);
                    break;

                default:
                    num1 = aleatoryNumber.Next(2, 101);
                    break;
            }
            securityIterationNumber = 0;
        }
        num2 = aleatoryNumber.Next(2, 11);
        securityIterationNumber++;
    } while (num1 % num2 != 0);

    string questionText = $"{num1} / {num2} = ?";
    int correctAnswer = num1 / num2;
    return (correctAnswer, questionText);
}

void GetGamemode()
{
    isRandom = false;
    do
    {
        Console.WriteLine("in which mode do you want to play ? (training or random)");
        selectedGame = Console.ReadLine() ?? string.Empty;
    }while(selectedGame != "training" && selectedGame != "random");
    
    if (selectedGame == "training")
    {
        selectedOperation = GetOperationSelection();
        Console.WriteLine($"Great {playerName}! You chose the {selectedOperation}!");
    }
    else {isRandom = true;}
}

void GetNumberOfQuestion()
{
    Console.WriteLine("How many questions would you like to answer? (5-10)");

    while (!int.TryParse(Console.ReadLine(), out numberOfQuestions) || numberOfQuestions < 5 ||numberOfQuestions > 10)
    {
    Console.WriteLine("Please enter a valid number between 5 and 10.");
    }
}

void GetDifficulty()
{
    do{
        Console.WriteLine($"Okay, juste a final question, in which difficulty level would you like to play? (easy, medium, hard)");
        difficultyLevel = Console.ReadLine() ?? string.Empty;
    }while(difficultyLevel != "easy" && difficultyLevel != "medium" && difficultyLevel != "hard");
}