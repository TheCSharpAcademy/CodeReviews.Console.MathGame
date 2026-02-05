
namespace MathGame
{
    internal class Helpers
    {
        static List<string> scores = new();
       internal static void ShowScore(int score)
        {
            Console.WriteLine("Your total score is: " + score + " out of 5");
        }
        internal static void ViewScores()
        {
            Console.WriteLine("\n--- Previous Scores ---");

            if (scores.Count == 0)
            {
                Console.WriteLine("No games played yet!");
            }
            else
            {
                for (int i = 0; i < scores.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {scores[i]}");
                }
            }

            Console.WriteLine("-----------------------");
        }
        internal static int[] GetNumbers()
        {
            Random random = new Random();
            int num1 = random.Next(1, 99);
            int num2 = random.Next(1, 99);
            var result = new int[2];

            while (num1 % num2 != 0)
            {
                num1 = random.Next(1, 99);
                num2 = random.Next(1, 99);
            }
            result[0] = num1;
            result[1] = num2;

            return result;
        }

        internal static void AddScore(int score, string game)
        {
            scores.Add($"{game} - {score}/5 - {DateTime.Now:g}");
        }

    }
}
