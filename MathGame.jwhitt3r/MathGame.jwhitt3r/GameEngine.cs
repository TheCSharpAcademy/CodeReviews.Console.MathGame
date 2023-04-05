namespace MathGame.jwhitt3r
{
    /// <summary>
    /// GameEngine employs a singleton pattern to ensure that only one game and one unqiue score
    /// object is created at any given time. https://csharpindepth.com/articles/singleton version 6 singleton pattern
    /// used.
    /// </summary>
    public sealed class GameEngine
    {
        /// <summary>
        /// gameScores tracks all correct answers that have occured each game.
        /// </summary>
        private Score gameScores = new Score();
        private static readonly Lazy<GameEngine> lazy = new Lazy<GameEngine>(() => new GameEngine());

        /// <summary>
        /// Generate a static GameEngine constructor which is the original object that was made. 
        /// </summary>
        public static GameEngine Instance { get { return lazy.Value; } }

        private GameEngine() {}
        
        /// <summary>
        /// NewGame initiates a brand new game by kick starting the Main Menu and managing the returned
        /// Userinput.
        /// </summary>
        public void NewGame()
        {
            
            while (true)
            {
                char val = Menu.GenerateMenu();
                if (val == '+' || val == '-' || val == '/' || val == '*')
                {
                    // Using a discard variable as we don't really need to hold a game object. 
                    _ = new Game(val, gameScores, Menu.GenerateDifficultyMenu());
                }
                
                if (val == 'e')
                {
                    gameScores.PrintScores();
                }
            }
        }
    }
}
