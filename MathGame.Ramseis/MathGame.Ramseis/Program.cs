// Program loop

List<string> scores = new List<string>();

while (true)
{
    ShowMenu();
}

void ShowMenu()
{
    // Display main menu, get user input, and set game state
    Console.Clear();
    Console.Write(@"
---- Math Game ----

Options:  1 - Addition
          2 - Subtraction
          3 - Multiplication
          4 - Division

          5 - High Scores

          6 - Exit

Select: ");
    int input = getInput();
    if (input == 1)
    {
        addPage();
    }
    else if (input == 2)
    {
        subPage();
    }
    else if (input == 3)
    {
        mulPage();
    }
    else if (input == 4)
    {
        divPage();
    }
    else if (input == 5)
    {
        scorePage();
    }
    else if (input == 6)
    {
        Environment.Exit(0);
    }
    else
    {
        Console.Clear();
        Console.Write("Input error; Select from the displayed list only. Press any key to continue...");
        Console.ReadKey();
    }
}
void addPage()
{
    // Play addition game
    bool screen = true;
    int level = -1;
    int quantity = -1;
    int score = 0;
    while (screen)
    {
        Console.Clear();
        Console.Write("++++ Addition Game ++++\n\n Select difficulty (1 - 3): ");
        level = getInput();
        if (level == 1 | level == 2 | level == 3)
        {
            screen = false;
        }
    }
    screen = true;
    while (screen)
    {
        Console.Clear();
        Console.Write("++++ Addition Game ++++\n\n Select number of questions: ");
        quantity = getInput();
        if (quantity > 0)
        {
            screen = false;
        }
        else
        {
            Console.Write("\n\nNumber of questions must be an integer greater than 0!\nPress any key to try again...");
            Console.ReadKey();
        }
    }
    Random random = new Random();
    Console.Clear();
    Console.Write("++++ Addition Game ++++\n\n++++    Level {level}    ++++\n");
    DateTime start = DateTime.Now;
    for (int i = 0; i < quantity; i++)
    {
        int a = random.Next(1, (int)Math.Pow(10, level));
        int b = random.Next(1, (int)Math.Pow(10, level));
        int c = a + b;
        if (a > 99)
        {
            Console.Write($"\n   {a}");
        }
        else if (a > 9)
        {
            Console.Write($"\n    {a}");
        }
        else
        {
            Console.Write($"\n     {a}");
        }
        if (b > 99)
        {
            Console.Write($"\n + {b}");
        }
        else if (b > 9)
        {
            Console.Write($"\n  + {b}");
        }
        else
        {
            Console.Write($"\n   + {b}");
        }
        Console.Write("\n  = ");
        int answer = getInput();
        if (answer == c)
        {
            Console.Write("\n Correct!");
            score = score + (int)Math.Pow(10, level + 1);
        }
        else
        {
            Console.Write($"\nIncorrect! The answer was {c}!\n");
        }
    }
    DateTime end = DateTime.Now;
    TimeSpan spent = end - start;
    score = score / (int)Math.Ceiling(spent.TotalSeconds);
    scores.Add($"{DateTime.Now} - Addition: Score = {score} in {spent.TotalSeconds:0.00} seconds on level {level} with {quantity} questions");
    Console.Clear();
    Console.Write($"++++ Addition Game ++++\n\nGame Over! Score = {score}!\n\nTime taken = {spent.TotalSeconds:0.00} seconds\n\nPress any key to continue...");
    Console.ReadKey();
}
void subPage()
{
    // Play subtraction game
    bool screen = true;
    int level = -1;
    int quantity = -1;
    int score = 0;
    while (screen)
    {
        Console.Clear();
        Console.Write("---- Subtraction Game ----\n\n Select difficulty (1 - 3): ");
        level = getInput();
        if (level == 1 | level == 2 | level == 3)
        {
            screen = false;
        }
    }
    screen = true;
    while (screen)
    {
        Console.Clear();
        Console.Write("---- Subtraction Game ----\n\n Select number of questions: ");
        quantity = getInput();
        if (quantity > 0)
        {
            screen = false;
        }
        else
        {
            Console.Write("\n\nNumber of questions must be an integer greater than 0!\nPress any key to try again...");
            Console.ReadKey();
        }
    }
    Random random = new Random();
    Console.Clear();
    Console.Write("---- Subtraction Game ----\n\n----    Level {level}    ----\n");
    DateTime start = DateTime.Now;
    for (int i = 0; i < quantity; i++)
    {
        int a = random.Next(1, (int)Math.Pow(10, level));
        int b = random.Next(1, (int)Math.Pow(10, level));
        if (b > a)
        {
            int holder = a;
            a = b;
            b = holder;
        }
        int c = a - b;
        if (a > 99)
        {
            Console.Write($"\n   {a}");
        }
        else if (a > 9)
        {
            Console.Write($"\n    {a}");
        }
        else
        {
            Console.Write($"\n     {a}");
        }
        if (b > 99)
        {
            Console.Write($"\n - {b}");
        }
        else if (b > 9)
        {
            Console.Write($"\n  - {b}");
        }
        else
        {
            Console.Write($"\n   - {b}");
        }
        Console.Write("\n  = ");
        int answer = getInput();
        if (answer == c)
        {
            Console.Write("\n Correct!");
            score = score + (int)Math.Pow(10, level + 1);
        }
        else
        {
            Console.Write($"\nIncorrect! The answer was {c}!\n");
        }
    }
    DateTime end = DateTime.Now;
    TimeSpan spent = end - start;
    score = score / (int)Math.Ceiling(spent.TotalSeconds);
    scores.Add($"{DateTime.Now} - Subtraction: Score = {score} in {spent.TotalSeconds:0.00} seconds on level {level} with {quantity} questions");
    Console.Clear();
    Console.Write($"---- Subtraction Game ----\n\nGame Over! Score = {score}!\n\nTime taken = {spent.TotalSeconds:0.00} seconds\n\nPress any key to continue...");
    Console.ReadKey();
}
void mulPage()
{
    // Play Multiplication game
    bool screen = true;
    int level = -1;
    int quantity = -1;
    int score = 0;
    while (screen)
    {
        Console.Clear();
        Console.Write("**** Muliplication Game ****\n\n Select difficulty (1 - 3): ");
        level = getInput();
        if (level == 1 | level == 2 | level == 3)
        {
            screen = false;
        }
    }
    screen = true;
    while (screen)
    {
        Console.Clear();
        Console.Write("**** Muliplication Game ****\n\n Select number of questions: ");
        quantity = getInput();
        if (quantity > 0)
        {
            screen = false;
        }
        else
        {
            Console.Write("\n\nNumber of questions must be an integer greater than 0!\nPress any key to try again...");
            Console.ReadKey();
        }
    }
    Random random = new Random();
    Console.Clear();
    Console.Write("**** Muliplication Game ****\n\n****    Level {level}    ****\n");
    DateTime start = DateTime.Now;
    for (int i = 0; i < quantity; i++)
    {
        int a = random.Next(1, (int)Math.Pow(10, level));
        int b = random.Next(1, (int)Math.Pow(10, level));
        if (b > a)
        {
            int holder = a;
            a = b;
            b = holder;
        }
        int c = a * b;
        if (a > 99)
        {
            Console.Write($"\n   {a}");
        }
        else if (a > 9)
        {
            Console.Write($"\n    {a}");
        }
        else
        {
            Console.Write($"\n     {a}");
        }
        if (b > 99)
        {
            Console.Write($"\n * {b}");
        }
        else if (b > 9)
        {
            Console.Write($"\n  * {b}");
        }
        else
        {
            Console.Write($"\n   * {b}");
        }
        Console.Write("\n  = ");
        int answer = getInput();
        if (answer == c)
        {
            Console.Write("\n Correct!");
            score = score + (int)Math.Pow(10, level + 1);
        }
        else
        {
            Console.Write($"\nIncorrect! The answer was {c}!\n");
        }
    }
    DateTime end = DateTime.Now;
    TimeSpan spent = end - start;
    score = score / (int)Math.Ceiling(spent.TotalSeconds);
    scores.Add($"{DateTime.Now} - Multiplication: Score = {score} in {spent.TotalSeconds:0.00} seconds on level {level} with {quantity} questions");
    Console.Clear();
    Console.Write($"**** Muliplication Game ****\n\nGame Over! Score = {score}!\n\nTime taken = {spent.TotalSeconds:0.00} seconds\n\nPress any key to continue...");
    Console.ReadKey();
}
void divPage()
{
    // Play division game
    bool screen = true;
    int level = -1;
    int quantity = -1;
    int score = 0;
    while (screen)
    {
        Console.Clear();
        Console.Write("//// Division Game ////\n\n Select difficulty (1 - 3): ");
        level = getInput();
        if (level == 1 | level == 2 | level == 3)
        {
            screen = false;
        }
    }
    screen = true;
    while (screen)
    {
        Console.Clear();
        Console.Write("//// Division Game ////\n\n Select number of questions: ");
        quantity = getInput();
        if (quantity > 0)
        {
            screen = false;
        }
        else
        {
            Console.Write("\n\nNumber of questions must be an integer greater than 0!\nPress any key to try again...");
            Console.ReadKey();
        }
    }
    Random random = new Random();
    Console.Clear();
    Console.Write($"//// Division Game ////\n\n////    Level {level}    ////\n");
    DateTime start = DateTime.Now;
    for (int i = 0; i < quantity; i++)
    {
        int c = random.Next(1, (int)Math.Pow(10, level));
        int b = random.Next(1, (int)Math.Pow(2, level));
        int a = c * b;
        if (b > a)
        {
            int holder = a;
            a = b;
            b = holder;
        }
        if (a > 99)
        {
            Console.Write($"\n   {a}");
        }
        else if (a > 9)
        {
            Console.Write($"\n    {a}");
        }
        else
        {
            Console.Write($"\n     {a}");
        }
        if (b > 99)
        {
            Console.Write($"\n / {b}");
        }
        else if (b > 9)
        {
            Console.Write($"\n  / {b}");
        }
        else
        {
            Console.Write($"\n   / {b}");
        }
        Console.Write("\n  = ");
        int answer = getInput();
        if (answer == c)
        {
            Console.Write("\n Correct!");
            score = score + (int)Math.Pow(10, level + 1);
        }
        else
        {
            Console.Write($"\nIncorrect! The answer was {c}!\n");
        }
    }
    DateTime end = DateTime.Now;
    TimeSpan spent = end - start;
    score = score / (int)Math.Ceiling(spent.TotalSeconds);
    scores.Add($"{DateTime.Now} - Division: Score = {score} in {spent.TotalSeconds:0.00} seconds on level {level} with {quantity} questions");
    Console.Clear();
    Console.Write($"//// Division Game ////\n\nGame Over! Score = {score}!\n\nTime taken = {spent.TotalSeconds:0.00} seconds\n\nPress any key to continue...");
    Console.ReadKey();
}
void scorePage()
{
    Console.Clear();
    Console.Write("#### Score History ####\n\n");
    foreach (string score in scores)
    {
        Console.WriteLine(score);
    }
    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}
int getInput()
{
    int.TryParse(Console.ReadLine().Trim(), out int input);
    return input;
}