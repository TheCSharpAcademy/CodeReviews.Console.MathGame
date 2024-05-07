using Console = System.Console;

namespace MathGame.Kriz_J.GameSections;

public class Addition : GameSection
{
    protected override void SectionLoop()
    {
        while (!Quit)
        {
            PrintMenu(
                StylizedTexts.Addition,
                "Each question will be an addition problem of two terms.",
                Settings.Difficulty,
                Settings.Mode);
            ReadAndRouteUserSelection();
        }
    }

    protected override void StandardGame()
    {
        GameHelperMethods.GameCountDown();

        var score = GameLogic(Settings.NumberOfQuestions);

        PrintScore(score, Settings.NumberOfQuestions);
        Console.Write("\t\t\t. . . Press any key to go back.");
        Console.ReadKey();
    }

    protected override void TimedGame()
    {
        GameHelperMethods.GameCountDown();

        var start = DateTime.Now;
        var score = GameLogic(Settings.NumberOfQuestions);
        var stop = DateTime.Now;

        PrintScore(score, Settings.NumberOfQuestions);
        Console.Write($"\tTime: {(stop - start):mm\\:ss\\.fff}");
        Console.Write("\t\t\t. . . Press any key to go back.");
        Console.ReadKey();
    }

    protected override void CustomGame()
    {
        Console.Write("\tYou have selected custom! How many questions do you wish to try? ");
        Settings.NumberOfQuestions = ConsoleHelperMethods.ReadUserInteger();
        
        GameHelperMethods.GameCountDown();

        var score = GameLogic(Settings.NumberOfQuestions);

        PrintScore(score, Settings.NumberOfQuestions);
        Console.Write("\t\t\t. . . Press any key to go back.");
        Console.ReadKey();
    }

    private int GameLogic(int nrOfQuestions)
    {
        var generator = new Random();
        var lower = Settings.IntegerBounds.Lower;
        var upper = Settings.IntegerBounds.Upper;

        var score = 0;
        for (int i = 0; i < nrOfQuestions; i++)
        {
            var a = generator.Next(lower, upper);
            var b = generator.Next(lower, upper);

            Console.Write($"\t{a} + {b} = ");

            var c = ConsoleHelperMethods.ReadUserInteger();

            if (a + b == c)
                score++;
        }

        return score;
    }

    private static void PrintScore(int score, int nrOfQuestions)
    {
        var percentage = 1.0 * score / nrOfQuestions;

        Console.WriteLine();
        if (score == nrOfQuestions)
            Console.Write($"\tPerfect score! {score}/{nrOfQuestions}.");
        else if (percentage >= 0.8)
            Console.Write($"\tImpressive! {score}/{nrOfQuestions}.");
        else if (percentage >= 0.6)
            Console.Write($"\tPretty good! {score}/{nrOfQuestions}.");
        else if (percentage >= 0.4)
            Console.Write($"\tYou can do better: {score}/{nrOfQuestions}.");
        else
            Console.Write($"\tTry again: {score}/{nrOfQuestions}.");
    }
}