namespace SinghxRaj.MathGame.MathGame;

internal class MathGameHistory 
{
    public List<MathGame> Games { get; set; } = new List<MathGame>();

    public void ViewHistory()
    {
        if (Games.Count == 0)
        {
            Console.WriteLine("No games played...");
            return;
        }
        int index = 1;
        Games.ForEach(game => 
        {
            Console.WriteLine($"{index++}.Game Time: {game.GameTime}, Number of Points: {game.Points}");
        });
    }

}
