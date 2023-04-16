using MathGame.barakisbrown.Problems;

namespace MathGame.barakisbrown;

internal class Game
{
    private readonly List<Model> Problems = new();
    private string ?Name { get; set; }
    private readonly IProblem[] Problem = { new Addition(), new Subtraction(), new Multiplication(), new Division() };
    private Diffuclty_Levels Levels { get; set; } = Diffuclty_Levels.Beginnger;

    public void Begin() 
    {
        MenuOptions Options;
        Model model = new();
        Name = Helpers.GetName();

        do
        {
            int index = 0;
            Console.Clear();
            Options = Helpers.ShowMenu(Name);
            switch(Options)
            {
                case MenuOptions.ChangeDifficulty:
                    ChangeDifficulty();
                    index = -1;
                    break;
                case MenuOptions.ListGamesPlayed:
                    ShowGamesPlayed();
                    index = -1;
                    break;
                case MenuOptions.Addition:
                    index = 0;
                    break;
                case MenuOptions.Subtraction:
                    index = 1;
                    break;
                case MenuOptions.Multiplication:
                    index = 2;
                    break;
                case MenuOptions.Division:
                    index = 3;
                    break;
            }

            if (index >= 0)
            {
                model = Problem[index].Calc(Levels);
                Problems.Add(model);
            }
        } while (Options != MenuOptions.Quit);

        Console.WriteLine($"Thank you for playing {Name} MathGame. Have a good day.");
    }

    private void ShowGamesPlayed()
    {
        Console.Clear();
        Console.WriteLine($"The following are the games you have played so far, {Name}");
        int count = Problems.Count;

        if (count == 0)
            Console.WriteLine("You have not completed any problems so far.  Go do some and come back.");
        else
        {
            Console.WriteLine($"You have completed {count} problems so far.  Here is the list.");
            foreach (var prob in Problems)
            {
                Console.WriteLine(prob.ToString());
            }
            Console.WriteLine("Press any key to return back to the menu");
            Console.ReadKey();
        }
    }

    private void ChangeDifficulty()
    {
        string prompt = $@"
            {Name}, if you want to change the difficulty level of the problems, please select from the following:
            1 -> Beginner
            2 -> Moderate
            3 -> Expert
            
            Chose either (1/2/3):
        ";

        Console.Write(prompt);

        char key = Console.ReadKey(true).KeyChar;
        switch (key)
        {
            case '1':
                Levels = Diffuclty_Levels.Beginnger;
                break;
            case '2':
                Levels = Diffuclty_Levels.Moderate;
                break;
            case '3':
                Levels = Diffuclty_Levels.Expert;
                break;
            default:
                break;
        }
    }
}
