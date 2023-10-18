using System;

namespace MathGame.SadePauw
{
    public static class Questions
    {
        public static bool AddQuestion(int difficulty)
        {
            int a,b,result;
            a = SetDifficulty(difficulty, out b);
            result = a + b;
            Console.WriteLine("\nPlease provide me the answer: ");
            Console.WriteLine($"{a} + {b} =");
            var answer = Console.ReadLine();
            return GetResult(answer, result.ToString());
        }
        public static bool SubtractQuestion(int difficulty)
        {
            int a,b,result;
            a = SetDifficulty(difficulty, out b);
            result = a - b;
            Console.WriteLine("\nPlease provide me the answer: ");
            Console.WriteLine($"{a} - {b} =");
            var answer = Console.ReadLine();
            return GetResult(answer, result.ToString());
        }
        public static bool MultiplyQuestion(int difficulty)
        {
            int a,b,result;
            a = SetDifficulty(difficulty, out b);
            result = a * b;
            Console.WriteLine("\nPlease provide me the answer: ");
            Console.WriteLine($"{a} * {b} =");
            var answer = Console.ReadLine();
            return GetResult(answer, result.ToString());
        }
        public static bool DivideQuestion(int difficulty)
        {
            int a,b,result;
            while (true)
            {
                a = SetDifficulty(difficulty, out b);
                if (a == b) {continue;}
                if (a % b != 0) continue;
                result = a / b;
                break;
            }
            Console.WriteLine("\nPlease provide me the answer: ");
            Console.WriteLine($"{a} / {b} =");
            var answer = Console.ReadLine();
            return GetResult(answer, result.ToString());
        }
        public static bool RandomQuestion(int difficulty)
        {
            var rnd = new Random();
            switch (rnd.Next(1, 4))
            {
                case 1:
                    return AddQuestion(difficulty);
                case 2:
                    return SubtractQuestion(difficulty);
                case 3:
                    return MultiplyQuestion(difficulty);
                case 4:
                    return DivideQuestion(difficulty);
            }
            return false;
        }
        private static int SetDifficulty(int difficulty, out int b)
        {
            int a;
            var rnd = new Random();
            switch (difficulty)
            {
                case 1:
                    a = rnd.Next(1, 10);
                    b = rnd.Next(1, 10);
                    break;
                case 2:
                    a = rnd.Next(1, 100);
                    b = rnd.Next(1, 100);
                    break;
                case 3:
                    a = rnd.Next(1, 1000);
                    b = rnd.Next(1, 1000);
                    break;
                default:
                    a = rnd.Next(1, 10);
                    b = rnd.Next(1, 10);
                    break;
            }
            return a;
        }
        private static bool GetResult(string answer, string result)
        {
            if (answer == result)
            {
                Console.WriteLine($"Congratulations! {answer} was the correct!");
                return true;
            }
            Console.WriteLine("Too bad!");
            return false;
        }
    }
}