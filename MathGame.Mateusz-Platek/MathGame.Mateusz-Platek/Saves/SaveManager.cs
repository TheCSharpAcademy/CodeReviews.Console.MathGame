namespace MathGame.Mateusz_Platek.Saves;

public static class SaveManager
{
    private static List<Save> saves = new List<Save>();

    public static void AddSave(Save save)
    {
        saves.Add(save);
    }

    public static void ShowSaves()
    {
        Console.WriteLine("History: ");
        foreach (Save save in saves)
        {
            Console.WriteLine(save);
        }
    }
}