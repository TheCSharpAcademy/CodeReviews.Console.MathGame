using System.Diagnostics;

Console.Write("Write your name: ");


string name = Console.ReadLine();
bool gameRunning = true;
List<string> gameHistory = new List<string>();


while (gameRunning)
{
    gameRunning = Menu(name, gameRunning, gameHistory);
}
bool Menu(string name, bool gameRunning, List<string> gameHistory)
{
    Console.WriteLine($"Hi {name}. Welcome to the math game.");
    Console.WriteLine("Choose your game: \n");
    Console.WriteLine("1. Addition");
    Console.WriteLine("2. Subtraction");
    Console.WriteLine("3. Multiply");
    Console.WriteLine("4. Division");
    Console.WriteLine("5. Show history");
    Console.WriteLine("6. End game");
    Stopwatch stopwatch = new Stopwatch();
    int game = 0;
    bool isGameSuccess = false;

    while (!isGameSuccess)
    {
        isGameSuccess = int.TryParse(Console.ReadLine(), out game);
        if (isGameSuccess)
        {
            if (game < 1 || game > 6)
            {
                isGameSuccess = false;
                Console.WriteLine("You have chosen a number outside the interval 1-6");
            }
            else
            {
            }
        }
        else
        {
            Console.WriteLine("You have to choose a number between 1 and 6");
        }
    }

    int numberOfQuestions = 0;
    bool isQuestionSucess = false;
    int difficulty = 0;
    bool isDifficultySucces = false;

    if (game == 5 || game == 6)
    {
        isQuestionSucess = true;
        isDifficultySucces = true;
    }

    while (!isQuestionSucess)
    {
        Console.Write("Choose number of questions.");
        isQuestionSucess = int.TryParse(Console.ReadLine(), out numberOfQuestions);
        if (isQuestionSucess)
        {
            if (numberOfQuestions < 1)
            {
                isQuestionSucess = false;
                Console.WriteLine("You have to pick a number higher than 0.");
            }
        }
        else
        {

            Console.WriteLine("You have to choose a number.");
        }

    }

    while (!isDifficultySucces)
    {
        Console.Write("Pick your dificulty from 1-3: ");
        isDifficultySucces = int.TryParse(Console.ReadLine(), out difficulty);
        if (isDifficultySucces)
        {
            if (difficulty < 1 || difficulty > 3)
            {
                isDifficultySucces = false;
                Console.WriteLine("You have to choose a number between 1 and 3");
            }
        }
        else
        {
            Console.WriteLine("You have to choose a number");
        }

    }
    switch (game)
    {
        case 1:
            Console.WriteLine($"You chose addition and {numberOfQuestions} questions");
            stopwatch.Start();
            gameHistory.Add($"Addition({difficulty}): {numberOfQuestions} questions - {Addition(numberOfQuestions, difficulty)} correct answers in {stopwatch.Elapsed}");
            stopwatch.Stop();
            stopwatch.Reset();
            break;
        case 2:
            stopwatch.Start();
            Console.WriteLine($"You chose subtraction and {numberOfQuestions} questions");
            gameHistory.Add($"Subtraction({difficulty}): {numberOfQuestions}  questions - {Subtraction(numberOfQuestions, difficulty)} correct answers in {stopwatch.Elapsed}");
            stopwatch.Stop();
            stopwatch.Reset();
            break;
        case 3:
            stopwatch.Start();
            Console.WriteLine($"You chose multiplication and {numberOfQuestions} questions");
            gameHistory.Add($"Multiplication({difficulty}): {numberOfQuestions}  questions - {Multiplication(numberOfQuestions, difficulty)} correct answers in {stopwatch.Elapsed}");
            stopwatch.Stop();
            stopwatch.Reset();
            break;
        case 4:
            stopwatch.Start();
            Console.WriteLine($"You chose division and {numberOfQuestions} questions");
            gameHistory.Add($"Division({difficulty}): {numberOfQuestions}  questions - {Division(numberOfQuestions, difficulty)} correct answers in {stopwatch.Elapsed}");
            stopwatch.Stop();
            stopwatch.Reset();
            break;
        case 5:
            Console.WriteLine("History: ");
            ShowHistory(gameHistory);
            break;
        case 6:
            Console.WriteLine("Game ended.");
            gameRunning = false;
            break;
    }
    Console.Clear();
    return gameRunning;
}
int Addition(int numberOfQuestions, int difficulty)
{
    int maxNum = 0;
    switch (difficulty)
    {
       case 1:
            maxNum = 10;
            break;
        case 2:
            maxNum = 50;
            break;
        case 3:
            maxNum = 100;
            break;
    }
    Random random = new Random();
    int correctAnswers = 0;
    for (int i = 0; i < numberOfQuestions; i++)
    {
        int number1 = random.Next(1, maxNum);
        int number2 = random.Next(1, maxNum);
        Console.Write($"{number1} + {number2} = ");
        int answer = 0;
        bool sucess = int.TryParse(Console.ReadLine(), out answer);
        while (!sucess)
        {
            Console.WriteLine("You have to pick a number");
            sucess = int.TryParse(Console.ReadLine(), out answer);
        }
        if (answer == number1 + number2)
        {
            Console.WriteLine("Correct!");
            correctAnswers++;
        }
        else
        {
            Console.WriteLine("Wrong!");
        }
    }
    Console.WriteLine(Result(correctAnswers, numberOfQuestions));
    return correctAnswers;
}

int Subtraction(int numberOfQuestions, int difficulty)
{
    int maxNum = 0;
    switch (difficulty)
    {
        case 1:
            maxNum = 10;
            break;
        case 2:
            maxNum = 50;
            break;
        case 3:
            maxNum = 100;
            break;
    }
    Random random = new Random();
    int correctAnswers = 0;
    for (int i = 0; i < numberOfQuestions; i++)
    {
        int number1 = random.Next(1, maxNum);
        int number2 = random.Next(1, maxNum);

        while (number1 - number2 < 0)
        {
            number1 = random.Next(1, maxNum);
            number2 = random.Next(1, maxNum);
        }

        Console.Write($"{number1} - {number2} = ");
        int answer = 0;
        bool sucess = int.TryParse(Console.ReadLine(), out answer);
        while (!sucess)
        {
            Console.WriteLine("You have to pick a number");
            sucess = int.TryParse(Console.ReadLine(), out answer);
        }
        if (answer == number1 - number2)
        {
            Console.WriteLine("Correct!");
            correctAnswers++;
        }
        else
        {
            Console.WriteLine("Wrong!");
        }
    }
    Console.WriteLine(Result(correctAnswers, numberOfQuestions));
    return correctAnswers;
}

int Multiplication(int numberOfQuestions, int difficulty)
{
    int maxNum = 0;
    switch (difficulty)
    {
        case 1:
            maxNum = 10;
            break;
        case 2:
            maxNum = 50;
            break;
        case 3:
            maxNum = 100;
            break;
    }
    Random random = new Random();
    int correctAnswers = 0;
    for (int i = 0; i < numberOfQuestions; i++)
    {
        int number1 = random.Next(1, maxNum);
        int number2 = random.Next(1, maxNum);
        Console.Write($"{number1} * {number2} = ");
        int answer = 0;
        bool sucess = int.TryParse(Console.ReadLine(), out answer);
        while (!sucess)
        {
            Console.WriteLine("You have to pick a number");
            sucess = int.TryParse(Console.ReadLine(), out answer);
        }
        if (answer == number1 * number2)
        {
            Console.WriteLine("Correct!");
            correctAnswers++;
        }
        else
        {
            Console.WriteLine("Wrong!");
        }
    }
    Console.WriteLine(Result(correctAnswers, numberOfQuestions));
    return correctAnswers;
}

int Division(int numberOfQuestions, int difficulty)
{
    int maxNum = 0;
    switch (difficulty)
    {
        case 1:
            maxNum = 10;
            break;
        case 2:
            maxNum = 50;
            break;
        case 3:
            maxNum = 100;
            break;
    }
    Random random = new Random();
    int correctAnswers = 0;
    for (int i = 0; i < numberOfQuestions; i++)
    {
        int number1 = random.Next(1, maxNum);
        int number2 = random.Next(1, maxNum);

        while (number1 % number2 != 0)
        {
            number1 = random.Next(1, maxNum);
            number2 = random.Next(1, maxNum);
        }

        Console.Write($"{number1} / {number2} = ");

        int answer = 0;
        bool sucess = int.TryParse(Console.ReadLine(), out answer);
        while (!sucess)
        {
            Console.WriteLine("You have to pick a number");
            sucess = int.TryParse(Console.ReadLine(), out answer);
        }
        if (answer == number1 / number2)
        {
            Console.WriteLine("Correct!");
            correctAnswers++;
        }
        else
        {
            Console.WriteLine("Wrong!");
        }
    }
    Console.WriteLine(Result(correctAnswers, numberOfQuestions));
    return correctAnswers;
}
string Result(int correctAnswers, int numberOfQuestions)
{
    return $"You got {correctAnswers} out of {numberOfQuestions} correct";
}

void ShowHistory(List<string> gameHistory)
{
    Console.WriteLine("------------------------------");
    if (gameHistory.Count == 0)
    {
        Console.WriteLine("No earlier games");
    }
    else
    {
        foreach (string game in gameHistory)
        {
            Console.WriteLine(game);
        }
    }
    Console.WriteLine("------------------------------");
    Console.WriteLine("Press a button to go to menu.");
    Console.ReadLine();
}
