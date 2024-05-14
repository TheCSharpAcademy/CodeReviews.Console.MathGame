using Patryk_MM.MathGame;

Console.WriteLine("Welcome to \"Math Game\"!");

char[] validInputs = ['A', 'S', 'M', 'D', 'E', 'H', 'Q', 'R'];
List<GameInstance> gameHistory = new List<GameInstance>();
PrintMenu();

while (true) {
    char input;
    do {
        Console.Write("Choose the option (press Q for displaying menu): ");
        input = (char)Console.ReadKey().Key;
        Console.WriteLine();
        if (!validInputs.Contains(input)) {
            Console.WriteLine("\nPlease provide a valid option from the menu.\n");
        }
    } while (!validInputs.Contains(input));

    var game = new GameInstance(DateTime.Now, '\0', 10);
    switch (input) {
        case 'A':
        case 'S':
        case 'M':
        case 'D':
        case 'R':
            int numberOfRounds = 0;
            Console.Write("How many round would you like to play? ");
            while (!int.TryParse(Console.ReadLine(), out numberOfRounds) || numberOfRounds < 1 || numberOfRounds > 30) {
                Console.Write("Please input a number between 1 and 30: ");
            }
            char operation = GetOperationChar(input);
            game = new GameInstance(DateTime.Now, operation, numberOfRounds);
            game.HandleGame(operation);
            gameHistory.Add(game);
            break;
        case 'H':
            PrintHistory(gameHistory);
            break;
        case 'Q':
            PrintMenu();
            break;
        case 'E':
            Console.WriteLine("Thank you for playing the game!");
            return;
    }
}

static void PrintMenu() {
    Console.WriteLine("Menu:");
    Console.WriteLine("A - Addition");
    Console.WriteLine("S - Subtraction");
    Console.WriteLine("M - Multiplication");
    Console.WriteLine("D - Division");
    Console.WriteLine("R - Random operations");
    Console.WriteLine("----------------------");
    Console.WriteLine("H - View game history");
    Console.WriteLine("----------------------");
    Console.WriteLine("E - Exit the game\n");
}

static void PrintHistory(List<GameInstance> gameHistory) {
    if (gameHistory.Count == 0) {
        Console.WriteLine("Your game history is empty.");
    } else {
        Console.WriteLine("Game history: ");
        foreach (var entry in gameHistory) {
            Console.WriteLine($"{entry.StartTime} | Game mode: {entry.GameMode} | Score: {entry.Score}/{entry.MaxScore}");
        }
    }
    Console.WriteLine();
}

static char GetOperationChar(char input) {
    switch (input) {
        case 'A': return '+';
        case 'S': return '-';
        case 'M': return '*';
        case 'D': return '/';
        case 'R': return 'r';
        default: throw new ArgumentException();
    }
}