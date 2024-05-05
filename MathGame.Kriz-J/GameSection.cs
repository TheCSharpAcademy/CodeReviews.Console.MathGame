namespace MathGame.Kriz_J;

public abstract class GameSection
{
    public GameSettings Settings { get; set; } = new();

    public bool QuitPressed { get; set; }

    protected GameSection()
    {
        Console.WriteLine();
        Console.WriteLine();

        GameLoop();
    }

    public abstract void GameLoop();

    public abstract void PrintGameMenu();

}