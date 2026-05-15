using MathGame.src;

class Player
{
    private readonly String name;
    private Game game = new(); 

    public Player(String name)
    {
        this.name = name;
        this.game.StartGame();
    }
}