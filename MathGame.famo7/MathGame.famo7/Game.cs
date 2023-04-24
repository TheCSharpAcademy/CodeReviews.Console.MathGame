class Game
{
    public List<ParentGame> history { get; set; }
    public Game()
    {
        history = new List<ParentGame>();
    }

    public void AddHistory(ParentGame p)
    {
        history.Add(p);
    }
    public void ViewHistory()
    {
        Console.WriteLine("Game history");
        foreach (var item in history)
        {
            Console.WriteLine($"{item.Date} - {item.Name}: {item.point}pts");
        }
    }
}

