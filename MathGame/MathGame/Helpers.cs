namespace MathGame
{
    internal class Helpers
    {
            internal static bool Validation(int a, int b)
            {
                return a % b == 0;
            }
            internal static string Validation2(string answer)
            {

                while (string.IsNullOrEmpty(answer) || !Int32.TryParse(answer, out _))
                {
                    Console.WriteLine("Only integers is acceptable!");
                    answer = Console.ReadLine();
                }
                return answer;
            }
    }
}
