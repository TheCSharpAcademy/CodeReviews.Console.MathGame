
using ConsoleUI;
using MathGameLibrary;
using MathGameLibrary.sadklouds;

bool exit = false;
string name = Helper.GetName("What is your name? ");


while (exit != true)
{
    Helper.MainMenu(name);
    string input = Console.ReadLine();
    int numberOfQuestions = 0;

    switch (input.ToLower())
    {
        case "a":
            numberOfQuestions = Helper.GetNumberOfQuestions();
            Console.Clear();
            Addition(numberOfQuestions);
            break;
        case "s":
            numberOfQuestions = Helper.GetNumberOfQuestions();
            Console.Clear();
            Subtraction(numberOfQuestions);
            break;
        case "m":
            numberOfQuestions = Helper.GetNumberOfQuestions();
            Console.Clear();
            Multiplication(numberOfQuestions);
            break;
        case "d":
            numberOfQuestions = Helper.GetNumberOfQuestions();
            Console.Clear();
            Division(numberOfQuestions);
            break;
        case "v":
            Console.Clear();
            Helper.ViewGameSessions();
            break;
        case "e":
            exit = true;
            break;
    }
}

void Division(int numberOfQuestions)
{
    int score = 0;
    string gameType = "Divison";
    DateTime startTime = DateTime.Now;
    for (int i = 0; i < numberOfQuestions; i++)
    {
        var numbers = GameEngine.GetDivisionNumbers();
        var firstNumber = numbers.First();
        var secondNumber = numbers.Last();
        int userAwnser;
        bool parsed = false;

        do
        {
            Console.Write($"\nWhats is {firstNumber} / {secondNumber}: ");
            string userInput = Console.ReadLine();
            parsed = int.TryParse(userInput, out userAwnser);

            if (parsed == false)
            {
                Console.WriteLine("Inavlid Input");
            }
        } while (parsed == false);

        if (GameEngine.AnwserValidator(firstNumber, secondNumber, userAwnser, '/') == true)
        {
            Console.WriteLine("Anwser was correct!");
            score++;
        }
        else
        {
            Console.WriteLine("Anwser incorrect!");
        }
    }

    GameEngine.AddToGameHistory(score, gameType, startTime);
}

void Addition(int numberOfQuestions)
{
    int score = 0;
    string gameType = "Addition";
    DateTime startTime = DateTime.Now;
    for (int i = 0; i < numberOfQuestions; i++)
    {
        var numbers = GameEngine.GetNumbers();
        var firstNumber = numbers.First();
        var secondNumber = numbers.Last();
        int userAwnser;
        bool parsed = false;

        do
        {
            Console.Write($"\nWhats is {firstNumber} + {secondNumber}: ");
            string userInput = Console.ReadLine();
            parsed = int.TryParse(userInput, out userAwnser);

            if (parsed == false)
            {
                Console.WriteLine("Inavlid Input");
            }
        } while (parsed == false);

        if (GameEngine.AnwserValidator(firstNumber, secondNumber, userAwnser, '+') == true)
        {
            Console.WriteLine("Anwser was correct!");
            score++;
        }
        else
        {
            Console.WriteLine("Anwser incorrect!");
        }
    }

    GameEngine.AddToGameHistory(score, gameType, startTime);
}

void Multiplication(int numberOfQuestions)
{
    int score = 0;
    string gameType = "Multiplication";
    DateTime startTime = DateTime.Now;
    for (int i = 0; i < numberOfQuestions; i++)
    {
        var numbers = GameEngine.GetNumbers();
        var firstNumber = numbers.First();
        var secondNumber = numbers.Last();
        int userAwnser;
        bool parsed = false;

        do
        {
            Console.Write($"\nWhats is {firstNumber} * {secondNumber}: ");
            string userInput = Console.ReadLine();
            parsed = int.TryParse(userInput, out userAwnser);

            if (parsed == false)
            {
                Console.WriteLine("Inavlid Input");
            }
        } while (parsed == false);

        if (GameEngine.AnwserValidator(firstNumber, secondNumber, userAwnser, '*') == true)
        {
            Console.WriteLine("Anwser was correct!");
            score++;
        }
        else
        {
            Console.WriteLine("Anwser incorrect!");
        }
    }

    GameEngine.AddToGameHistory(score, gameType, startTime);
}

void Subtraction(int numberOfQuestions)
{
    int score = 0;
    string gameType = "Subtraction";
    DateTime startTime = DateTime.Now;
    for (int i = 0; i < numberOfQuestions; i++)
    {
        var numbers = GameEngine.GetNumbers();
        var firstNumber = numbers.First();
        var secondNumber = numbers.Last();
        int userAwnser;
        bool parsed = false;

        do
        {
            Console.Write($"\nWhats is {firstNumber} - {secondNumber}: ");
            string userInput = Console.ReadLine();
            parsed = int.TryParse(userInput, out userAwnser);

            if (parsed == false)
            {
                Console.WriteLine("Inavlid Input");
            }
        } while (parsed == false);

        if (GameEngine.AnwserValidator(firstNumber, secondNumber, userAwnser, '-') == true)
        {
            Console.WriteLine("Anwser was correct!");
            score++;
        }
        else
        {
            Console.WriteLine("Anwser incorrect!");
        }
    }

    GameEngine.AddToGameHistory(score, gameType, startTime);
}