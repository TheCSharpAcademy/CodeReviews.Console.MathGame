namespace MathGame
{

    internal class TaskUtils
    {
        public static void AdditionGame(int dificulty, ref List<string> answers, int rounds)
        {
            DateTime start = DateTime.UtcNow;
            for (int i = 0; i < rounds; i++)
            {
                Random rand = new Random();
                if (dificulty == 0)
                {
                    var rand1 = rand.Next(0, 10);
                    var rand2 = rand.Next(0, 10);
                    Console.WriteLine($"What is the answer?: {rand1} + {rand2}?");
                    var answer = Console.ReadLine();
                    answer = Helpers.Validation2(answer);
                    if (int.Parse(answer) == (rand1 + rand2))
                    {
                        Console.WriteLine("Correct!");
                        answers.Add($"The question was: {rand1} + {rand2}, and your answer {answer} was correct!");
                    }
                    else
                    {
                        Console.WriteLine("Not correct:(");
                        answers.Add($"The question was: {rand1} + {rand2}, and your answer {answer} was incorrect!");
                    }

                }
                else
                {
                    var rand1 = rand.Next(0, 250);
                    var rand2 = rand.Next(0, 250);
                    Console.WriteLine($"What is the answer?: {rand1} + {rand2}?");
                    var answer = Console.ReadLine();
                    Helpers.Validation2(answer);
                    if (int.Parse(answer) == (rand1 + rand2))
                    {
                        Console.WriteLine("Correct!");
                        answers.Add($"The question was: {rand1} + {rand2}, and your answer {answer} was correct!");
                    }
                    else
                    {
                        Console.WriteLine("Not correct:(");
                        answers.Add($"The question was: {rand1} + {rand2}, and your answer {answer} was incorrect!");
                    }
                }
            }
            DateTime end = DateTime.UtcNow;
            var totalSpan = end - start;
            Console.WriteLine($"You took {totalSpan.TotalSeconds} seconds to end the game!");
        }
        public static void SubGame(int dificulty, ref List<string> answers, int rounds)
        {
            DateTime start = DateTime.UtcNow;
            for (int i = 0; i < rounds; i++)
            {
                Random rand = new Random();
                if (dificulty == 0)
                {
                    var rand1 = rand.Next(0, 10);
                    var rand2 = rand.Next(0, 10);
                    Console.WriteLine($"What is the answer?: {rand1} - {rand2}?");
                    var answer = Console.ReadLine();
                    Helpers.Validation2(answer);
                    if (int.Parse(answer) == (rand1 - rand2))
                    {
                        Console.WriteLine("Correct!");
                        answers.Add($"The question was: {rand1} - {rand2}, and your answer {answer} was correct!");
                    }
                    else
                    {
                        Console.WriteLine("Not correct:(");
                        answers.Add($"The question was: {rand1} - {rand2}, and your answer {answer} was incorrect!");
                    }

                }
                else
                {
                    var rand1 = rand.Next(0, 250);
                    var rand2 = rand.Next(0, 250);
                    Console.WriteLine($"What is the answer?: {rand1} - {rand2}?");
                    var answer = Console.ReadLine();
                    Helpers.Validation2(answer);
                    if (int.Parse(answer) == (rand1 - rand2))
                    {
                        Console.WriteLine("Correct!");
                        answers.Add($"The question was: {rand1} - {rand2}, and your answer {answer} was correct!");
                    }
                    else
                    {
                        Console.WriteLine("Not correct:(");
                        answers.Add($"The question was: {rand1} - {rand2}, and your answer {answer} was incorrect!");
                    }
                }
            }
            DateTime end = DateTime.UtcNow;
            var totalSpan = end - start;
            Console.WriteLine($"You took {totalSpan.TotalSeconds} seconds to end the game!");
        }
        public static void MultiplitionGame(int dificulty, ref List<string> answers, int rounds)
        {
            DateTime start = DateTime.UtcNow;
            for (int i = 0; i < rounds; i++)
            {
                Random rand = new Random();
                if (dificulty == 0)
                {
                    var rand1 = rand.Next(0, 10);
                    var rand2 = rand.Next(0, 10);
                    Console.WriteLine($"What is the answer?: {rand1} * {rand2}?");
                    var answer = Console.ReadLine();
                    Helpers.Validation2(answer);
                    if (int.Parse(answer) == (rand1 * rand2))
                    {
                        Console.WriteLine("Correct!");
                        answers.Add($"The question was: {rand1} * {rand2}, and your answer {answer} was correct!");
                    }
                    else
                    {
                        Console.WriteLine("Not correct:(");
                        answers.Add($"The question was: {rand1} * {rand2}, and your answer {answer} was incorrect!");
                    }

                }
                else
                {
                    var rand1 = rand.Next(0, 250);
                    var rand2 = rand.Next(0, 250);
                    Console.WriteLine($"What is the answer?: {rand1} * {rand2}?");
                    var answer = Console.ReadLine();
                    Helpers.Validation2(answer);
                    if (int.Parse(answer) == (rand1 * rand2))
                    {
                        Console.WriteLine("Correct!");
                        answers.Add($"The question was: {rand1} * {rand2}, and your answer {answer} was correct!");
                    }
                    else
                    {
                        Console.WriteLine("Not correct:(");
                        answers.Add($"The question was: {rand1} * {rand2}, and your answer {answer} was incorrect!");
                    }
                }
            }
            DateTime end = DateTime.UtcNow;

            var totalSpan = end - start;
            Console.WriteLine($"You took {totalSpan.TotalSeconds} seconds to end the game!");
        }
        public static void DivisionGame(int dificulty, ref List<string> answers, int rounds)
        {
            DateTime start = DateTime.UtcNow;
            for (int i = 0; i < rounds; i++)
            {
                Random rand = new Random();
                if (dificulty == 0)
                {
                    var rand1 = rand.Next(0, 10);
                    var rand2 = rand.Next(1, 10);
                    do
                    {
                        rand1 = rand.Next(1, 10);
                        rand2 = rand.Next(1, 10);
                    } while (!Helpers.Validation(rand1, rand2));

                    Console.WriteLine($"What is the answer?: {rand1} : {rand2}?");
                    var answer = Console.ReadLine();
                    Helpers.Validation2(answer);
                    if (int.Parse(answer) == (rand1 / rand2))
                    {
                        Console.WriteLine("Correct!");
                        answers.Add($"The question was: {rand1} / {rand2}, and your answer {answer} was correct!");
                    }
                    else
                    {
                        Console.WriteLine("Not correct:(");
                        answers.Add($"The question was: {rand1} / {rand2}, and your answer {answer} was incorrect!");
                    }

                }
                else
                {
                    var rand1 = rand.Next(0, 100);
                    var rand2 = rand.Next(1, 100);
                    do
                    {
                        rand1 = rand.Next(0, 100);
                        rand2 = rand.Next(1, 100);
                    } while (!Helpers.Validation(rand1, rand2));

                    Console.WriteLine($"What is the answer?: {rand1} / {rand2}?");
                    var answer = Console.ReadLine();
                    Helpers.Validation2(answer);
                    if (int.Parse(answer) == (rand1 / rand2))
                    {
                        Console.WriteLine("Correct!");
                        answers.Add($"The question was: {rand1} / {rand2}, and your answer {answer} was correct!");
                    }
                    else
                    {
                        Console.WriteLine("Not correct:(");
                        answers.Add($"The question was: {rand1} / {rand2}, and your answer {answer} was incorrect!");
                    }
                }
            }
            DateTime end = DateTime.UtcNow;
            var totalSpan = end - start;
            Console.WriteLine($"You took {totalSpan.TotalSeconds} seconds to end the game!");
        }
        public static void RandomGame(int difficulty, ref List<string> answers, int rounds)
        {
            var rand = new Random();
            var number = rand.Next(1, 5);
            switch (number)
            {
                case 1:
                    AdditionGame(difficulty, ref answers, rounds);
                    break;
                case 2:
                    SubGame(difficulty, ref answers, rounds);
                    break;
                case 3:
                    MultiplitionGame(difficulty, ref answers, rounds);
                    break;
                case 4:
                    DivisionGame(difficulty, ref answers, rounds);
                    break;
            }
        }


    }
}

