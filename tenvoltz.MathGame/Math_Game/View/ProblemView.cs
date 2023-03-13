using Math_Game.Model;
using Math_Game.Model.Problems;

namespace Math_Game.View
{
    internal class ProblemView
    {
        private ProblemModel model;

        internal ProblemView(ProblemModel model)
        {
            this.model = model;
        }


        internal void ShowProblem()
        {
            Console.Clear();
            Helpers.PrintDivider();
            Console.WriteLine($"Problem: {model.Problem.Name}");
            Console.WriteLine(model.Problem.Description);
            Helpers.PrintDivider();
            Console.WriteLine(model.Problem.Display());
        }

        internal string PromptAnswer()
        {
            Console.Write($"Answer ({model.Problem.Format}): ");
            string answer = Console.ReadLine();
            Helpers.PrintDivider();
            return answer;
        }

        internal void ShowResult(Result result)
        {
            switch (result)
            {
                case Result.Correct:
                    Console.WriteLine($"Correct!");
                    break;
                case Result.Incorrect:
                    Console.WriteLine($"Incorrect!");
                    break;
                case Result.Invalid:
                    Console.WriteLine("Invalid! Please enter in the correct format");
                    break;
            }
        }

        internal void ShowProgress(int amountLeft)
        {
            Console.WriteLine($"Your score is {model.Score}");
            if(amountLeft == 0)
            {
                Console.WriteLine("There is no problem left");
            }
            else Console.WriteLine($"There are {amountLeft} problems left");
        }

        internal void PromptContinue()
        {
            Helpers.PrintDivider();
            Helpers.PrintContinue();
        }

        internal void ShowDuration(TimeSpan duration)
        {
            Console.WriteLine($"You finished in {duration.ToString(@"hh\:mm\:ss")}");
        }
    }
}
