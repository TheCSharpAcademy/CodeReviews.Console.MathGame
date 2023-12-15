// Initializing variables
using System.Collections;
using System.Globalization;

List<string> savedGames = new List<string>();
int difficulty = 0;
int gameMode = -1;
Random generateRandom = new Random();

int score = 0;

MainMenu();

void MainMenu()
{
    bool exit = false;
    int choice = 0;
    do
    {
        Console.WriteLine("Choose game\n1. addition\n2. subtraction\n3. multiplication\n4. division\n5. random game\n6. show saved games\n7. change difficulty");
        switch (difficulty)
        {
            case 0:
                Console.WriteLine("Difficulty setting: Easy");
                break;
            case 1:
                Console.WriteLine("Difficulty setting: Medium");
                break;
            case 2:
                Console.WriteLine("Difficulty setting: Hard");
                break;
            case 3:
                Console.WriteLine("Difficulty setting: Impossible");
                break;
        }
        string? readChoice = Console.ReadLine();
        if (readChoice != null)
        {
            if (int.TryParse(readChoice, out choice))
            {
                switch (choice)
                {
                    case 1:
                        ChooseGameMode();
                        PlayGame(choice);
                        continue;
                    case 2:
                        ChooseGameMode();
                        PlayGame(choice);
                        continue;
                    case 3:
                        ChooseGameMode();
                        PlayGame(choice);
                        continue;
                    case 4:
                        ChooseGameMode();
                        PlayGame(choice);
                        continue;
                    case 5:
                        ChooseGameMode();
                        PlayGame(choice);
                        continue;
                    case 6:
                        ShowSavedGames();
                        continue;
                    case 7:
                        ChangeDifficulty();
                        continue;
                    default:
                        Console.WriteLine("Please enter a number between 1 and 7");
                        continue;
                }
            }
            else
            {
                string command = readChoice.ToLower();
                switch(command)
                {
                    case "exit":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a number or \"exit\".");
                        break;

                }
            }   
        }

    } while ((choice < 1 && choice > 6) || !exit);
}

void PlayGame(int gameType)
{   
    bool exit = false;
    if (gameMode == 0)
    {
        do
        {
            switch(gameType)
            {
                case 1:
                    exit = GenerateAdditionGame();
                    break;
                case 2:
                    exit = GenerateSubtractionGame();
                    break;
                case 3:
                    exit = GenerateMultiplicationGame();
                    break;
                case 4:
                    exit = GenerateDivisionGame();
                    break;
                case 5:
                    exit = GenerateRandomGame();
                    break;
            }
            
        } while (!exit);
    }
    else
    {
        for (int i = 0; i < gameMode; i++)
        {
            switch(gameType)
            {
                case 1:
                    exit = GenerateAdditionGame();
                    break;
                case 2:
                    exit = GenerateSubtractionGame();
                    break;
                case 3:
                    exit = GenerateMultiplicationGame();
                    break;
                case 4:
                    exit = GenerateDivisionGame();
                    break;
                case 5:
                    exit = GenerateRandomGame();
                    break;
            }
        }
    }
}



void ShowScore()
{
    Console.WriteLine($"Score: {score}");
}

bool AnswerLoop(int answer, string prompt)
{
    bool validEntry = false;
    bool exit = false;

    do
    {
        string? readAnswer = Console.ReadLine();
        if (readAnswer != null)
        {
            readAnswer = readAnswer.ToLower();
            if (int.TryParse(readAnswer, out int userAnswer))
            {
                validEntry = true;
                if (userAnswer == answer)
                {
                    Console.WriteLine("Right answer!");
                    savedGames.Add(prompt + $"{userAnswer}:\tcorrect");
                    score += 1;
                }
                else
                {
                    Console.WriteLine("Wrong answer.");
                    savedGames.Add(prompt + $"{userAnswer}:\tincorrect");
                }
            }
            else
            {
                string command = readAnswer;
                switch (command)
                {
                    case "exit":
                        validEntry = true;
                        exit = true;
                        break;
                    case "show score":
                        ShowScore();
                        Console.WriteLine(prompt + "?");
                        break;
                    case "show saved games":
                        ShowSavedGames();
                        Console.WriteLine(prompt + "?");
                        break;
                    case "help":
                        Console.WriteLine("help: lists commands\nshow score: shows score\nshow saved games: lists saved games\nexit: quit to main menu");
                        Console.WriteLine(prompt + "?");
                        break;
                    default:
                        Console.WriteLine("Please enter a number or command.");
                        Console.WriteLine(prompt + "?");
                        break;
                }
            }
        }
        
    } while (!validEntry);
    return exit;
}

void ShowSavedGames()
{   
    if (!savedGames.Any())
    {
        Console.WriteLine("No saved games!");
    }
    else
    {
        foreach (string game in savedGames)
        {
            Console.WriteLine(game);
        }
    }
    Console.WriteLine("Press any key to continue.");
    Console.ReadLine();
}

void ChangeDifficulty()
{   
    bool validEntry = false;
    do
    {
        Console.WriteLine("Choose difficulty:\n0. Easy\n1. Medium\n2. Hard\n3. Impossible");
        string? readResult = Console.ReadLine();
        if (readResult != null)
        {
            if (int.TryParse(readResult, out int difficultyInput))
            {
                if (difficultyInput >= 0 && difficultyInput <= 3)
                {
                    difficulty = difficultyInput;
                    validEntry = true;
                }
                else
                {
                    Console.WriteLine("Please input a number.");
                }
            }

        }
        
    } while (!validEntry);
    
}

void ChooseGameMode()
{
    bool validEntry = false;
    int gameModeInput = -1;
    do
    {
        Console.WriteLine("Choose game mode:\n0. Infinite\n1. Finite");
        string? readResult = Console.ReadLine();
        if (readResult != null)
        {
            if (int.TryParse(readResult, out gameModeInput))
            {
                if (gameModeInput >= 0 && gameModeInput <= 1)
                {
                    validEntry = true;
                }
                else
                {
                    Console.WriteLine("Please input either 0 or 1.");
                }
            }
            else
            {
                Console.WriteLine("Please input a number.");
            }

        }
        
    } while (!validEntry);

    validEntry = false;

    if (gameModeInput == 1)
    {
        do
        {
            Console.WriteLine("Please enter the number of questions");
            string? readResult = Console.ReadLine();
            if (readResult != null)
            {
                if (int.TryParse(readResult, out gameModeInput))
                {
                    if (gameModeInput > 0)
                    {
                        gameMode = gameModeInput;
                        validEntry = true;
                    }
                    else
                    {
                        Console.WriteLine("Please input a number greater than zero.");
                    }
                }
                else
                {
                    Console.WriteLine("Please input a number");
                }

            }
        
        } while (!validEntry);
    }
    else
    {
        gameMode = 0;
    }
}

bool GenerateAdditionGame()
{
    int maxNumber = -1;
    switch (difficulty)
    {
        case 0:
            maxNumber = 10;
            break;
        case 1:
            maxNumber = 20;
            break;
        case 2:
            maxNumber = 50;
            break;
        case 3:
            maxNumber = 100;
            break;
    }
    int number1 = generateRandom.Next(0, maxNumber + 1);
    int number2 = generateRandom.Next(0, maxNumber + 1);
    int answer = number1 + number2;
    string prompt = $"{number1} + {number2} = ";
    Console.WriteLine(prompt + "?");
    bool exit = AnswerLoop(answer, prompt);
    return exit;
}

bool GenerateSubtractionGame()
{
    int maxNumber = -1;
    bool notGreater = false;
    switch (difficulty)
    {
        case 0:
            maxNumber = 10;
            notGreater = true;
            break;
        case 1:
            maxNumber = 20;
            notGreater = true; 
            break;
        case 2:
            maxNumber = 50;
            notGreater = false;
            break;
        case 3:
            maxNumber = 100;
            notGreater = false;
            break;
    }
    int number1 = generateRandom.Next(0, maxNumber + 1);
    int number2 = -1;
    if (notGreater)
        number2 = generateRandom.Next(0, number1 + 1);
    else
        number2 = generateRandom.Next(0, maxNumber + 1);
    int answer = number1 - number2;
    string prompt = $"{number1} - {number2} = ";
    Console.WriteLine(prompt + "?");
    
    bool exit = AnswerLoop(answer, prompt);
    return exit;

}

bool GenerateMultiplicationGame()
{
    int maxNumber = -1;
    switch (difficulty)
    {
        case 0:
            maxNumber = 5;
            break;
        case 1:
            maxNumber = 10;
            break;
        case 2:
            maxNumber = 25;
            break;
        case 3:
            maxNumber = 50;
            break;
    }
    int number1 = generateRandom.Next(0, maxNumber + 1);
    int number2 = generateRandom.Next(0, maxNumber + 1);
    int answer = number1 * number2;
    string prompt = $"{number1} * {number2} = ";
    Console.WriteLine(prompt + "?");
    
    bool exit = AnswerLoop(answer, prompt);
    return exit;
}

bool GenerateDivisionGame()
{
    int maxNumber = -1;
    switch (difficulty)
    {
        case 0:
            maxNumber = 10;
            break;
        case 1:
            maxNumber = 20;
            break;
        case 2:
            maxNumber = 50;
            break;
        case 3:
            maxNumber = 100;
            break;
    }
    int dividend = generateRandom.Next(0, maxNumber);
    int divisor = dividend;
    do 
    {
        divisor = generateRandom.Next(1, dividend + 1);
    }
    while (dividend % divisor != 0);

    int answer = dividend / divisor;
    string prompt = $"{dividend} / {divisor} = ";
    Console.WriteLine(prompt + "?");
    
    bool exit = AnswerLoop(answer, prompt);
    return exit;
}

bool GenerateRandomGame()
{
    bool exit = false;
    int nextGameType = generateRandom.Next(1, 5);
    switch(nextGameType)
    {
        case 1:
            exit = GenerateAdditionGame();
            return exit;
        case 2:
            exit = GenerateSubtractionGame();
            return exit;
        case 3:
            exit = GenerateMultiplicationGame();
            return exit;
        case 4:
            exit = GenerateDivisionGame();
            return exit;
        default:
            throw new ArgumentOutOfRangeException("Generated a number less than 1 or greater than 4");
    }
}