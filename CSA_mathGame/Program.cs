string[] menuOptions = { "CSharpAcademy - MathGame\n", "1 - Start", "2 - Random mode", "3 - Scoreboard", "4 - Exit", "Enter menu option # & press enter:" };
//program terminator
bool exit = false;

//scoring
int currentScore = 0;
int[] highScores = new int[10];
Array.Fill(highScores, 0);
//counter for current game number, used to store score in highScores array and reset when it reaches the end of the array.
int gameCounter = 0;

const int RANDOMQUESTIONAMOUNT = 5;

//pre-set question data
int[,] questionData = new int[5, 3]
{
    //value1, value2, sign 0-3 (+ - * /)
    {50, 10, 3},
    {7, 8, 2},
    {6, 2, 1},
    {5, 3, 0},
    {12, 2, 3},
};


//main loop
while (!exit)
{
    showMainMenu();
    readUserMenuInput();
}

//Show main menu.
void showMainMenu()
{
    foreach (string s in menuOptions)
    {
        Console.WriteLine(s);
    }
}

//Read user input and execute corresponding action.
void readUserMenuInput()
{
    switch (Console.ReadLine())
    {
        case "1":
            startGame();
            break;
        case "2":
            startRandomGame();
            break;
        case "3":
            ShowScoreboard();
            break;
        case "4":
            //Change exit bool/flag to true to exit the program.
            exit = true;
            break;
        default:
            Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            readUserMenuInput();
            break;
    }
}

//Show question and calc answer based on given values and symbol, return answer.
int ShowQuestion(int value1, int value2, int symbol, int questionNumber)
{
    //set symbol string based, calc answer, ask question, and return answer
    string symbolString = "";
    int calculatedAnswer = -1;
    string userAnswer = "";
    int userAnswerNumber = 0;

    switch(symbol)
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

void ShowScoreboard()
{
    Console.Clear();
    Console.WriteLine("--- SCOREBOARD (last 10 games) ---\n");
    for (int i = 0; i < highScores.Length; i++)
    {
        Console.WriteLine($"{highScores[i]} points");
    }
    Console.WriteLine("\n{ PRESS ENTER TO RETURN THE MAIN MENU }");
    Console.ReadLine();
    Console.Clear();
}

void startGame()
{
    Console.Clear();
    int consoleInput;
    int solution;
    //Ask questions from the bank
    for(int i = 0; i< questionData.GetLength(0); i++)
    {
        solution = ShowQuestion(questionData[i, 0], questionData[i, 1], questionData[i,2], i+1);        
        if(int.TryParse(Console.ReadLine(), out consoleInput))
        {
            if(consoleInput == solution)
            {
                currentScore++;
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            //go back to the previous loop iteration.
            i = i-1;
        }

    }
    EndGame();
}

void startRandomGame()
{
    Console.Clear();
    //used to so that a new question is not generated when bad input is detected & we restart the loop.
    bool generateRandoms = true;
    int consoleInput;
    int solution;
    int[] randomQuestionData = new int[3];

    for (int i = 0; i < RANDOMQUESTIONAMOUNT; i++)
    {
        if (generateRandoms)
        {
            randomQuestionData = GetRandomQuestionData();
        }
        solution = ShowQuestion(randomQuestionData[0], randomQuestionData[1], randomQuestionData[2], i + 1);
        if (int.TryParse(Console.ReadLine(), out consoleInput))
        {
            if (consoleInput == solution)
            {
                currentScore++;
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect.");
            }
            generateRandoms = true;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            generateRandoms = false;
            //repeat this iteration of the loop.
            i = i-1;
        }
    }
    EndGame();
}

void EndGame()
{
    //Store score
    highScores[gameCounter] = currentScore;
    gameCounter++;
    //reset game counter
    if (gameCounter >= highScores.Length)
    {
        gameCounter = 0;
    }
    //End of game
    Console.WriteLine($"\nGAME OVER! Your score is {currentScore}.\n");
    Console.WriteLine("{ PRESS ENTER TO RETURN THE MAIN MENU }");
    Console.ReadLine();
    Console.Clear();
}

int[] GetRandomQuestionData()
{
    //determine sign
    int sign = Random.Shared.Next(0, 4);
    int value1 = 0;
    int value2 = 0;
    if (sign == 3)
    {
        while (true)
        {
            value1 = Random.Shared.Next(1, 100);
            value2 = Random.Shared.Next(1, 100);

            if((value1 % value2) == 0)
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