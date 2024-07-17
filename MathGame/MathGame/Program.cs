using System;
using System.Diagnostics;
using System.Timers;
//Math Game

//Declaring variables
bool exitGame = false;
int[] numbers =  new int[2];
string[,] gameHistory = new string[1,5];
gameHistory[0, 0] = "Player"; gameHistory[0, 1] = "Game"; gameHistory[0, 2] = "Difficulty"; gameHistory[0, 3] = "Points"; gameHistory[0,4] = "Time";
int gameHistoryRecordCounter = 1;
int points;
int lastGamePoints;
int questionNumbers = 5;
string timePassed;
string currentGameName;
string lastGameName;
string playerNickname = "Player";
string selectedDifficulty = "easy";
Stopwatch stopWatch = new Stopwatch();

Main();   


void Main()
{
    GameStart();
    do
    {
        switch (Menu())
        {
            case "1":
                currentGameName = "Addition Game";
                GameGreeting();
                AdditionGame();
                ShowSingleGameStats();
                GameStatsRecord();
                break;

            case "2":
                currentGameName = "Substraction Game";
                GameGreeting();
                SubstractionGame();
                ShowSingleGameStats();
                GameStatsRecord();
                break;

            case "3":
                currentGameName = "Multiplication Game";
                GameGreeting();
                MultiplicationGame();
                ShowSingleGameStats();
                GameStatsRecord();

                break;

            case "4":
                currentGameName = "Division Game";
                GameGreeting();
                DivisionGame();
                ShowSingleGameStats();
                GameStatsRecord();
                break;

            case "5":
                currentGameName = "Random Game";
                GameGreeting();
                RandomGame();
                ShowSingleGameStats();
                GameStatsRecord();
                break;

            case "6":
                HistoryOfGames();
                break;

            case "7":
                GameStart();
                break;

            case "8":
                ChooseDifficulty();
                break;

            case "9":
                ChangeQuestionNumber();
                break;

            case "10":
                FinishGame();
                break;

            default:
                Console.WriteLine("Please enter correct menu option");
                Thread.Sleep(750);
                break;
        }
    } while (exitGame == false);
}

string Menu()
{
        Console.Clear();
        Console.WriteLine($"Hello, Dear {playerNickname}. \nYour current difficulty: {selectedDifficulty}. \nMenu:");
        Console.WriteLine("1. Addition Game \n2. Substraction Game \n3. Multiplication Game \n4. Division Game \n5. Random Game \n6. Games history \n7. Change player \n8. Change Difficulty \n9. Change number of questions \n10. Exit");
        string readResult = Console.ReadLine() ?? "wrong";
         
            if (readResult == "1" || readResult == "2" || readResult == "3" || readResult == "4" || readResult == "5" || readResult == "6" || readResult == "7" || readResult == "8" || readResult == "9" || readResult == "10")
            {
                return readResult;
            } 
            else
            {
                return ("");
            }
}

void GameStart()
{
    selectedDifficulty = "easy";
    Console.Clear();   
    Console.WriteLine("Welcome to Math Game");
    Thread.Sleep(1000);
    Console.WriteLine("Please, enter your nickname (max 16 characters):");
    playerNickname = Console.ReadLine();
    if (playerNickname.Length>16) playerNickname = playerNickname.Remove(16);
    if (playerNickname.Length < 1) playerNickname = "Unknown Player";
}

void AdditionGame()
{
    stopWatch.Reset();
    stopWatch.Start();
    points = 0;
    for (int i = 0; i < questionNumbers; i++)
    {
        numbers = TwoNumberGenerator();
        Console.Clear();
        Console.Write($" {numbers[0]} + {numbers[1]} = ");
        int answer = 0;      
        int.TryParse(Console.ReadLine(), out answer);
        if (answer == numbers[0] + numbers[1])
        {
            points++;
        }
    }
    stopWatch.Stop();
    TimeSpan ts = stopWatch.Elapsed;
    timePassed = String.Format ("{0:00}:{1:00}.{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds/10);
    lastGamePoints = points;
    lastGameName = "Addition";
}

void SubstractionGame()
{
    stopWatch.Reset();
    stopWatch.Start();
    points = 0;
    for (int i = 0; i < questionNumbers; i++)
    {
        numbers = TwoNumberGenerator();
        Console.Clear();
        Console.Write($" {numbers[0]} - {numbers[1]} = ");
        int answer = 0;
        int.TryParse(Console.ReadLine(), out answer);
        if (answer == numbers[0] - numbers[1])
        {
            points++;
        }
    }
    stopWatch.Stop();
    TimeSpan ts = stopWatch.Elapsed;
    timePassed = String.Format("{0:00}:{1:00}.{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
    lastGamePoints = points;
    lastGameName = "Substraction";
}

void MultiplicationGame()
{
    stopWatch.Reset();
    stopWatch.Start();
    points = 0;
    for (int i = 0; i < questionNumbers; i++)
    {
        numbers = TwoNumberGenerator();
        Console.Clear();
        Console.Write($" {numbers[0]} * {numbers[1]} = ");
        int answer = 0;
        int.TryParse(Console.ReadLine(), out answer);
        if (answer == numbers[0] * numbers[1])
        {
            points++;
        }
    }
    stopWatch.Stop();
    TimeSpan ts = stopWatch.Elapsed;
    timePassed = String.Format("{0:00}:{1:00}.{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
    lastGamePoints = points;
    lastGameName = "Multiplication";
}

void DivisionGame()
{
    stopWatch.Reset();
    stopWatch.Start();
    points = 0;
    for (int i = 0; i < questionNumbers; i++)
    {
        bool correctDivision = false;
        do
        {
            numbers = TwoNumberGenerator();
            if (numbers[0] % numbers[1] == 0)
            {
                correctDivision = true;
            }

        } while (correctDivision == false);
        Console.Clear();
        Console.Write($" {numbers[0]} / {numbers[1]} = ");
        int answer = 0;
        int.TryParse(Console.ReadLine(), out answer);
        if (answer == numbers[0] / numbers[1])
        {
            points++;
        }
    }
    stopWatch.Stop();
    TimeSpan ts = stopWatch.Elapsed;
    timePassed = String.Format("{0:00}:{1:00}.{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
    lastGamePoints = points;
    lastGameName = "Division";
}

//History of games array display
void HistoryOfGames()
{
    Console.Clear();
    for (int i = 0; i < gameHistory.GetLength(0); i++)
    {
        for (int j = 0; j < gameHistory.GetLength(1); j++)
        {
            //error because of empty lines in array
            Console.Write(gameHistory[i,j].PadRight(20));
        }
        Console.WriteLine("");
    }
    Console.WriteLine("\nPress any key to go back to menu.");
    Console.ReadKey();    
}

// method to store played game info 
void GameStatsRecord()
{
    if (gameHistoryRecordCounter + 1 > gameHistory.GetLength(0))
    {
        string[,] newArray = new string[gameHistoryRecordCounter + 1, gameHistory.GetLength(1)];
        for (int i = 0; i < gameHistory.GetLength(0); i++)
        {
            for (int j = 0; j < gameHistory.GetLength(1); j++)
            {
                newArray[i, j] = gameHistory[i, j];
            }
            
        }
        gameHistory = newArray;

        gameHistory[gameHistoryRecordCounter, 0] = playerNickname;
        gameHistory[gameHistoryRecordCounter, 1] = lastGameName;
        gameHistory[gameHistoryRecordCounter, 2] = selectedDifficulty;
        gameHistory[gameHistoryRecordCounter, 3] = ($"{lastGamePoints}/{questionNumbers}");
        gameHistory[gameHistoryRecordCounter, 4] = timePassed;

        gameHistoryRecordCounter++;
    }
}

void RandomGame()
{
    stopWatch.Reset();
    stopWatch.Start();
    Random random = new Random();
    int randomGamePoints = 0;
    int randomQuestions = questionNumbers;
    long randomTimer = 0;

    for (int i = 0; i < randomQuestions; i++)
    {
        questionNumbers = 1;
        switch (random.Next(1, 5))
        
        {
            case 1:
                AdditionGame();
                randomGamePoints += points;
                randomTimer += stopWatch.ElapsedMilliseconds;
                break;

            case 2:
                SubstractionGame();
                randomGamePoints += points;
                randomTimer += stopWatch.ElapsedMilliseconds;
                break;

            case 3:
                MultiplicationGame();
                randomGamePoints += points;
                randomTimer += stopWatch.ElapsedMilliseconds;
                break;
            case 4:
                DivisionGame();
                randomGamePoints += points;
                randomTimer += stopWatch.ElapsedMilliseconds;
                break;
        }
    }
    TimeSpan tsr = TimeSpan.FromMilliseconds (randomTimer);
    timePassed = String.Format("{0:00}:{1:00}.{2:00}", tsr.Minutes, tsr.Seconds, tsr.Milliseconds / 10);
    points = randomGamePoints;
    lastGamePoints = randomGamePoints;
    lastGameName = "Random Game";
    questionNumbers = randomQuestions;
}

void ShowSingleGameStats()
{
    Console.WriteLine($"Your total points: {points}.\nYour Time:{timePassed}  \nPress any key to go back to menu.");
    Console.ReadKey();
}

//method asking players confirmation to exit the game 
bool FinishGame ()
{
    do
    {
        Console.Clear ();
        Console.WriteLine("Do you want to close the Game? All your history will be deleted (y/n)");
        string readResult = Console.ReadLine();

        if (readResult == "y")
        {
            exitGame = true;
            return true;
        }
        else if (readResult == "n")
        {
            return false;
        }
    } while (true);
}

// method to create 2 random numbers for games for chosen difficulty
int[] TwoNumberGenerator()
{
    Random random = new Random();
    switch (selectedDifficulty)
    {
        case "easy":
            return [random.Next(1, 11), random.Next(1, 11)];    

        case "normal":
            return [random.Next(1, 51), random.Next(1, 51)];
        
        case "hard":
            return [random.Next(1, 101), random.Next(2, 101)];
        
        default:
            return [random.Next(1, 11), random.Next(1, 11)];
    }
}

void ChooseDifficulty()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Select your difficulty: \n1. Easy \n2. Normal \n3. Hard");
        string formattedInput = Console.ReadLine().ToLower().Trim();
        if (formattedInput.Contains("easy") || formattedInput == "1")
        {
            selectedDifficulty = "easy";
            return;
        }
        else if (formattedInput.Contains("normal") || formattedInput == "2")
        {
            selectedDifficulty = "normal";
            return;
        }
        else if (formattedInput.Contains("hard") || formattedInput == "3")
        {
            selectedDifficulty = "hard";
            return;
        }
        else
        {
            Console.WriteLine("Please, enter correct difficulty name or difficulty number.");
            Thread.Sleep (700);
        }
    }
}

//method to switch number of questions in games (from 1 to 20)
void ChangeQuestionNumber()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine($"Current number of questions is {questionNumbers} \nPlease, enter how many questions you want to answer in each game (from 1 to 20):");
        string readResult = Console.ReadLine();

        if (int.TryParse(readResult, out int result) == true && result < 21 && result > 0)
        {
            questionNumbers = result;
            return;
        }
        else
        {
            Console.WriteLine("Please, enter correct number from 1 to 20.");
            Thread.Sleep(700);
        }
    }
}

void GameGreeting()
{
    lastGamePoints = 0;
    Console.Clear();
    Console.WriteLine($"Welcome to {currentGameName} Game.\nPress any key to start.");
    Console.ReadKey();
}