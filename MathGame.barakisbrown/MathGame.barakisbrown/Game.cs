namespace MathGame.barakisbrown;

internal class Game
{
    private List<Model> Problems = new();
    private string ?Name { get; set; }
    private MenuOptions Options { get; set; }
    private IProblem Problem { get; set; }

    public void Begin() 
    {
        Model model = new();
        Name = Helpers.GetName();

        do
        {
            Console.Clear();
            Options = Helpers.ShowMenu(Name);
            switch(Options)
            {
                case MenuOptions.ChangeDifficulty:
                    ChangeDifficulty();
                    break;
                case MenuOptions.ListGamesPlayed:
                    ShowGamesPlayed();
                    break;
                case MenuOptions.Addition:
                    model.Type = GameType.Addition;
                    Problem = new Problems.Addition();
                    model = Problem.Calc();
                    break;
                case MenuOptions.Subtraction:
                    model.Type = GameType.Subtraction;
                    Problem = new Problems.Subtraction();
                    model = Problem.Calc();
                    break;
                case MenuOptions.Multiplication:
                    model.Type = GameType.Multiplication;
                    Problem = new Problems.Multiplication();
                    break;
                case MenuOptions.Division:
                    model.Type = GameType.Division;
                    Problem = new Problems.Division();
                    break;
            }
        } while (Options != MenuOptions.Quit);

        Console.WriteLine($"Thank you for playing {Name} MathGame. Have a good day.");
    }

    private void ShowGamesPlayed()
    {
        throw new NotImplementedException();
    }

    private void ChangeDifficulty()
    {
        throw new NotImplementedException();
    }
}
