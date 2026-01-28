namespace MathGame
{
    internal class GameEngine
    {       internal void Addition()
        {
            Random random = new Random();
            var score = 0;

            for (int i = 0; i < 5; i++)
            {
                var num1 = random.Next(1, 10);
                var num2 = random.Next(1, 10);
                Console.WriteLine(num1 + " + " + num2 + " = ?");
                var result = int.Parse(Console.ReadLine());
                if (result == num1 + num2)
                {
                    Console.WriteLine("Correct!");
                    score++;

                }
                else
                {
                    Console.WriteLine("Incorrect! The correct answer is " + (num1 + num2));
                }
            }
            Helpers.ShowScore(score);
            Helpers.AddScore(score, "Addition");


        }
        internal void Subtraction()
        {
            Random random = new Random();
            var score = 0;

            for (int i = 0; i < 5; i++)
            {
                var num1 = random.Next(1, 10);
                var num2 = random.Next(1, 10);
                Console.WriteLine(num1 + " - " + num2 + " = ?");
                var result = int.Parse(Console.ReadLine());
                if (result == num1 - num2)
                {
                    Console.WriteLine("Correct!");
                    score++;

                }
                else
                {
                    Console.WriteLine("Incorrect! The correct answer is " + (num1 - num2));
                }
            }
            Helpers.ShowScore(score);
            Helpers.AddScore(score, "Subtraction");
        }
        internal void Multiplication()
        {
            Random random = new Random();
            var score = 0;

            for (int i = 0; i < 5; i++)
            {
                var num1 = random.Next(1, 10);
                var num2 = random.Next(1, 10);
                Console.WriteLine(num1 + " * " + num2 + " = ?");
                var result = int.Parse(Console.ReadLine());
                if (result == num1 * num2)
                {
                    Console.WriteLine("Correct!");
                    score++;

                }
                else
                {
                    Console.WriteLine("Incorrect! The correct answer is " + (num1 * num2));
                }
            }
            Helpers.ShowScore(score);
            Helpers.AddScore(score, "Multiplication");
        }

        internal void Division()
        {
            var score = 0;


            for (int i = 0; i < 5; i++)
            {
                int[] nums = Helpers.getNumbers();
                Console.WriteLine(nums[0] + " / " + nums[1] + " = ?");
                var result = int.Parse(Console.ReadLine());
                if (result == nums[0] / nums[1])
                {
                    Console.WriteLine("Correct!");
                    score++;

                }
                else
                {
                    Console.WriteLine("Incorrect! The correct answer is " + (nums[0] / nums[1]));
                }
            }
            Helpers.ShowScore(score);
            Helpers.AddScore(score, "Division");
        }
    }
}
