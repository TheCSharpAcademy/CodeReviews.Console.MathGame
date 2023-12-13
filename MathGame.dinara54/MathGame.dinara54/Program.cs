// Initializing variables
string[] savedGames = new string[100];
int k = 0;
int maxNumber = 100;

Random generateRandom = new Random();
int choice = 0;
int score = 0;

MainMenu();

void MainMenu()
{
    bool exit = false;
    do
    {
        Console.WriteLine("Choose game\n1. addition\n2. subtraction\n3. multiplication\n4. division\n5. show saved games");
        string? readChoice = Console.ReadLine();
        if (readChoice != null)
        {
            if (int.TryParse(readChoice, out choice))
            {
                switch (choice)
                {
                    case 1:
                        PlayAdditionGame();
                        MainMenu();
                        break;
                    case 2:
                        PlaySubtractionGame();
                        MainMenu();
                        break;
                    case 3:
                        PlayMultiplicationGame();
                        MainMenu();
                        break;
                    case 4:
                        PlayDivisionGame();
                        MainMenu();
                        break;
                    case 5:
                        ShowSavedGames();
                        MainMenu();
                        break;
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
                        Console.WriteLine("Please enter a number");
                        break;

                }
            }   
        }

    } while ((choice < 1 && choice > 4 ) || !exit);
}

void PlayAdditionGame()
{   
    bool exit = false;
    do
    {
        int number1 = generateRandom.Next(0, maxNumber + 1);
        int number2 = generateRandom.Next(0, maxNumber + 1);
        int answer = number1 + number2;
        string prompt = $"{number1} + {number2} = ";
        Console.WriteLine(prompt + "?");
        
        exit = AnswerLoop(answer, prompt);
        


    } while (!exit);
    
}

void PlaySubtractionGame()
{
    bool exit = false;
    do
    {
        int number1 = generateRandom.Next(0, maxNumber + 1);
        int number2 = generateRandom.Next(0, maxNumber + 1);
        int answer = number1 - number2;
        string prompt = $"{number1} - {number2} = ";
        Console.WriteLine(prompt + "?");
        
        exit = AnswerLoop(answer, prompt);
    } while (!exit);
}

void PlayMultiplicationGame()
{
    bool exit = false;
    do
    {
        int number1 = generateRandom.Next(0, maxNumber + 1);
        int number2 = generateRandom.Next(0, maxNumber + 1);
        int answer = number1 * number2;
        string prompt = $"{number1} * {number2} = ";
        Console.WriteLine(prompt + "?");
        
        exit = AnswerLoop(answer, prompt);
    } while (!exit);
}

void PlayDivisionGame()
{
    bool exit = false;
    do
    {
        int dividend = generateRandom.Next(0, 100);
        int divisor = dividend;
        do 
        {
            divisor = generateRandom.Next(1, dividend + 1);
        }
        while (dividend % divisor != 0);

        int answer = dividend / divisor;
        string prompt = $"{dividend} / {divisor} = ";
        Console.WriteLine(prompt + "?");
        
        exit = AnswerLoop(answer, prompt);
    } while (!exit);
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
                    savedGames[k] = prompt + $"{userAnswer}: correct";
                    k++;
                    score += 1;
                }
                else
                {
                    Console.WriteLine("Wrong answer");
                    savedGames[k] = prompt + $"{userAnswer}: incorrect";
                    k++;
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
                        break;
                    case "show saved games":
                        ShowSavedGames();
                        break;
                    default:
                        Console.WriteLine("Please enter number");
                        break;
                }
            }
        }
        
    } while (!validEntry);
    return exit;
}

void ShowSavedGames()
{   if (k == 0)
    {
        Console.WriteLine("No saved games!");
    }
    for (int i = 0; i < k; i++)
    {
        Console.WriteLine(savedGames[i]);
    }
}