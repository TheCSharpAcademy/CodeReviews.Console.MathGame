namespace MathGame.Kriz_J.GameSections;

public class Addition : GameSection
{
    public override void GameLoop()
    {
        while (!QuitPressed)
        {
            PrintGameMenu();
            ReadAndRouteUserInput();
        }
    }

    private void ReadAndRouteUserInput()
    {
        var input = char.ToUpper(Console.ReadKey().KeyChar);

        switch (input)
        {
            case 'Q':
                QuitPressed = true;
                break;
            case '\r' or ' ':
                StartGame();
                break;
            default:
                Settings.ChangeDifficultyOrMode(input);
                break;
        }
    }

    private void StartGame()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("\t");
        GameHelperMethods.GameCountDown();
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();

        var score = 0;
        var random = new Random();
        for (int i = 0; i < 15; i++)
        {
            var a = random.Next(Settings.IntegerBounds.Lower, Settings.IntegerBounds.Upper);
            var b = random.Next(Settings.IntegerBounds.Lower, Settings.IntegerBounds.Upper);
            Console.Write($"\t{a} + {b} = ");

            if (!int.TryParse(Console.ReadLine(), out var c))
                return;

            if (a + b == c)
            {
                //Console.Write("\tCorrect!");
                score++;
            }
            //else
            //Console.Write("\tINCORRECT!");
            //Console.Write($"{Environment.NewLine}");
        }

        Console.WriteLine();
        if (score < 3)
            Console.WriteLine("\tYou can do better <3");
        else
            Console.WriteLine($"\tNot bad... {score}/{15}");
        Console.ReadKey();
    }

    public override void PrintGameMenu()
    {
        GameHelperMethods.PrintGameMenu(
            StylizedTexts.Addition,
            "Each question will be an addition problem of two terms.",
            Settings.Difficulty,
            Settings.Mode);
    }
}