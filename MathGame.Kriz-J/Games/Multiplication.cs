﻿using MathGame.Kriz_J.Enums;

namespace MathGame.Kriz_J.Games;

public class Multiplication(List<GameResult> resultKeeper) : Game(resultKeeper)
{
    protected override void Loop()
    {
        while (!Quit)
        {
            PrintMenu(
                StylizedTitles.Multiplication,
                "Each question will be a multiplication problem between two factors.",
                Settings.Difficulty,
                Settings.Mode);

            if (Settings.Mode is Mode.Custom)
                Settings.NumberOfQuestions = 10;

            ReadAndRouteUserSelection();
        }
    }

    protected override void StandardGame()
    {
        GameCountDown();

        var result = GameLogic(Settings.NumberOfQuestions);
        result.SaveGameSettings(Settings);

        GameOverPresentation(result);
    }

    protected override void TimedGame()
    {
        GameCountDown();

        var start = DateTime.Now;
        var result = GameLogic(Settings.NumberOfQuestions);
        var stop = DateTime.Now;
        result.SaveGameSettings(Settings);

        GameOverPresentation(result);
    }

    protected override void CustomGame()
    {
        SetNumberOfQuestions();

        GameCountDown();

        var result = GameLogic(Settings.NumberOfQuestions);
        result.SaveGameSettings(Settings);

        GameOverPresentation(result);
    }

    protected override GameResult GameLogic(int nrOfQuestions)
    {
        var score = 0;
        var generator = new Random();
        var lower = Settings.NumberLimits.Lower;
        var upper = Settings.NumberLimits.Upper;

        for (int i = 0; i < nrOfQuestions; i++)
        {
            var a = generator.Next(lower, upper);
            var b = generator.Next(lower, upper);

            Console.Write($"\t{a} * {b} = ");

            var c = ConsoleHelperMethods.ReadUserInteger();

            if (a * b == c)
                score++;
        }

        return new GameResult(score);
    }
}