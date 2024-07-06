// See https://aka.ms/new-console-template for more information
using csa_maths_game;

bool quitGame = false;
Game game = new Game(new Random());

while (!quitGame)
{
    Console.Clear();
    Console.WriteLine("Maths Game");
    Console.WriteLine("Select operation\n");
    Console.WriteLine("M - Multiplication");
    Console.WriteLine("A - Addition");
    Console.WriteLine("S - Subtraction");
    Console.WriteLine("D - Division");
    Console.WriteLine("R - Random");
    Console.WriteLine("P - Set number of rounds");
    Console.WriteLine("V - View scores");
    Console.WriteLine("Q - Quit\n");
    ConsoleKeyInfo keyInfo = Console.ReadKey();
    Console.WriteLine();

    switch (keyInfo.KeyChar)
    {
        case 'M':
        case 'm':
            game.Play(new Multiplication());
            break;
        case 'A':
        case 'a':
            game.Play(new Addition());
            break;
        case 'S':
        case 's':
            game.Play(new Subraction());
            break;
        case 'D':
        case 'd':
            game.Play(new Division());
            break;
        case 'R':
        case 'r':
            game.PlayRandom(new List<IOperation> { new Multiplication(), new Division(), new Addition(), new Subraction() });
            break;
        case 'P':
        case 'p':
            game.SetNumberOfRounds();
            break;
        case 'Q':
        case 'q':
            Console.WriteLine("Quit");
            quitGame = true;
            break;
        case 'V':
        case 'v':
            Console.WriteLine("View Scores");
            HighScore.DisplayHighScores();
            break;
        default:
            break;

    }
}
