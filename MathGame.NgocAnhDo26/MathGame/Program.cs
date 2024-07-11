// See https://aka.ms/new-console-template for more information
using MathGame;
using static System.Formats.Asn1.AsnWriter;

Menu menu = new Menu();
Game game;
bool isRunning = true;

while (isRunning)
{
    Console.Clear();
    menu.Print();
    var choice = menu.ChooseOption();
    int difficulty = 1, questions = 1, score = 0;
    var timer = DateTime.Now;

    switch (choice)
    {
        case 1:
            difficulty = menu.ChooseDifficulty();
            questions = menu.ChooseQuestions();
            Console.Clear();

            Console.WriteLine($"Addition Game - Difficulty Level {difficulty}");
            game = new AdditionGame(difficulty, questions);
            timer = DateTime.Now;
            score = game.Start();
            Console.WriteLine($"\nYour final score is: {score}!");
            Console.WriteLine($"Time taken: {(DateTime.Now - timer).Seconds} seconds.");
            break;
        case 2:
            difficulty = menu.ChooseDifficulty();
            questions = menu.ChooseQuestions();
            Console.Clear();

            Console.WriteLine($"Subtraction Game - Difficulty Level {difficulty}");
            game = new SubtractionGame(difficulty, questions);
            timer = DateTime.Now;
            score = game.Start();
            Console.WriteLine($"\nYour final score is: {score}!");
            Console.WriteLine($"Time taken: {(DateTime.Now - timer).Seconds} seconds.");
            break;
        case 3:
            difficulty = menu.ChooseDifficulty();
            questions = menu.ChooseQuestions();
            Console.Clear();

            Console.WriteLine($"Multiply Game - Difficulty Level {difficulty}");
            game = new MultiplyGame(difficulty, questions);
            timer = DateTime.Now;
            score = game.Start();
            Console.WriteLine($"\nYour final score is: {score}!");
            Console.WriteLine($"Time taken: {(DateTime.Now - timer).Seconds} seconds.");
            break;
        case 4:
            difficulty = menu.ChooseDifficulty();
            questions = menu.ChooseQuestions();
            Console.Clear();

            Console.WriteLine($"Division Game - Difficulty Level {difficulty}");
            game = new DivisionGame(difficulty, questions);
            timer = DateTime.Now;
            score = game.Start();
            Console.WriteLine($"\nYour final score is: {score}!");
            Console.WriteLine($"Time taken: {(DateTime.Now - timer).Seconds} seconds.");
            break;
        case 5:
            questions = menu.ChooseQuestions();
            Console.Clear();
            game = new RandomGame(difficulty, questions);
            timer = DateTime.Now;
            score = game.Start();
            Console.WriteLine($"\nYour final score is: {score}!");
            Console.WriteLine($"Time taken: {(DateTime.Now - timer).Seconds} seconds.");
            break;
        case 6:
            Console.Clear();
            Console.WriteLine("\tGame History\n");
            for (int i = 0; i < Menu.History.Count; i++)
                Console.WriteLine($"{i + 1}. {Menu.History[i]}");
            break;
        case 7:
            Console.WriteLine("The game ends here...");
            isRunning = false;
            break;
    }

    Console.Write("\nPress any key to continue...");
    Console.ReadKey();
}


