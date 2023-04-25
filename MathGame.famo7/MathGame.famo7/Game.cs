class Game
{
    public List<ParentGame> History { get; set; }
    public Game()
    {
        History = new List<ParentGame>();
    }

    public void AddHistory(ParentGame p)
    {
        History.Add(p);
    }
    public void ViewHistory()
    {
        Console.WriteLine("Game history");
        foreach (var item in History)
        {
            Console.WriteLine($"{item.Date} - {item.Name}: {item.Point}pts");
        }
    }
}

