using MyFirstProgram;
using System.Collections.Generic;

internal class Program
{
    static string PlayerName = string.Empty;
    static string ChallengeSelection = string.Empty;
    static int Difficulty;
    static int Score = 0;

    const string ChallengeOptionsMenu = @"Choose where to prove the haters wrong: 
            A - Addition
            S - Substraction
            M - Multiplication
            D - Division
            Q - Quit";

    static Dictionary<string, string> ChallengeOptions = new Dictionary<string, string>()
        {
            {"A","Addition"},
            {"S","Substraction" },
            {"M","Multiplication" },
            {"D","Division" },
            {"Q","Quit" }
        };

    const string DifficultyMenu = @"Select Difficulty:
            1 - Easy
            2 - Medium
            3 - Hard
            4 - Insane";

    static Dictionary<int, string> DifficultyOptions = new Dictionary<int, string>()
    {
        {1, "Easy" },
        {2, "Medium" },
        {3, "Hard" },
        {4, "Insane" }
    };
    private static void Main(string[] args)
    {
        GetName();
        ShowIntro();

       
        while (true)
        {
            Console.WriteLine("\n~~~Press enter to continue or Q to quit~~~\n");
            var cont = Console.ReadLine();
            if (cont is string && cont.ToUpper() == "Q") {
                Console.WriteLine($"\nThank you for playing {PlayerName}!");
                Console.WriteLine($"Your score was: {Score}");
                Console.WriteLine("Press any enter to exit.");
                Environment.Exit(0);
            } 
            GetChallenge();
            GetDifficulty();
            Problem problem = null;
            switch (ChallengeSelection)
            {
                case "A":
                    problem = new AdditionProblem(Difficulty);
                    break;
                case "S":
                    problem = new SubstractionProblem(Difficulty); 
                    break;
                case "M":
                    problem = new MultiplicationProblem(Difficulty);
                    break;
                case "D":
                    problem = new DivisionProblem(Difficulty);
                    break;
            } 
            Console.WriteLine("\nLET THE MATH GAMES BEGIN!\n");
            while (true)
            {
                problem.GenerateNextProblem();
                Console.WriteLine(problem.ProblemText);
                Console.WriteLine($"{PlayerName} Score: {Score}. You are playing {ChallengeOptions[ChallengeSelection]} in {DifficultyOptions[Difficulty]}.");
                Console.WriteLine("To go back to main menu, select M.");
                var answer = Console.ReadLine();
                if (answer is string && answer.ToUpper() == "M") break;
                if (int.TryParse(answer, out int intAnswer) && problem.CheckAnswer(intAnswer))
                {
                    Console.WriteLine("Correct answer. Good job champ!\n");
                    Score += Difficulty;
                }
                else
                {
                    Console.WriteLine("Wrong answer foo. Maybe them haters are right.\n");
                }
            }
        }

    }

    static void GetName()
    {
        bool nameSuccess = false;
        Console.WriteLine("Name motherfucker, do you have it?");
        while (!nameSuccess)
        {
            var inputName = Console.ReadLine();
            if (inputName is string)
            {
                nameSuccess = true;
                PlayerName = inputName;
            }
            else
            {
                Console.WriteLine("I said Name motherfucker, do you have it?");
            }
        }
    }

    static void ShowIntro()
    {
        DateTime date = DateTime.UtcNow;
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"Hey foo {PlayerName}. It's {date}. People say you suck at math. Prove them wrong");
        Console.WriteLine("----YOUR REPUTATION IS ON THE LINE FOO-----");
    }

    static void GetChallenge()
    {
        bool correctSelection = false;
        Console.WriteLine(ChallengeOptionsMenu);
        while (!correctSelection)
        {
            var sel = Console.ReadLine();
            if (sel is not null && ChallengeOptions.ContainsKey(sel.ToUpper()))
            {
                correctSelection = true;
                ChallengeSelection = sel.ToUpper();
            }

            else Console.WriteLine("Invalid choice foo");
        }

        Console.WriteLine($"You have selected the following challenge: {ChallengeOptions[ChallengeSelection]}");
    }

    static void GetDifficulty()
    {
        Console.WriteLine(DifficultyMenu);
        bool difficultySelectionSuccess = false;

        while (!difficultySelectionSuccess)
        {
            var sel = Console.ReadLine();
            if (int.TryParse(sel, out int trySel))
            {
                if (trySel > 0 && trySel < 5)
                {
                    difficultySelectionSuccess = true;
                    Difficulty = trySel;
                }
            }
            if (!difficultySelectionSuccess) Console.WriteLine("Invalid Choice. Select Again.");
        }
        Console.WriteLine($"You have selected {DifficultyOptions[Difficulty]}");
    }
}
