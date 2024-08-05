namespace MathGame
{
    public class Difficulty
    {
        public static List<int> Numbers = new List<int>();

        public static void PickDifficulty(string operation, int rounds)
        {
            string operationPick = operation;
            int games = rounds;

            Console.WriteLine("Pick difficulty:\n1. Easy\n2. Medium\n3. Hard");           

            bool again = true;

            do
            {
                again = true;
                string difficulty = Console.ReadLine();

                switch (difficulty)
                {
                    case "1":
                        Console.Clear();
                        DifficultyGenerator(operationPick, games, "Easy");
                        break;
                    case "2":
                        Console.Clear();
                        DifficultyGenerator(operationPick, games, "Medium");
                        break;
                    case "3":
                        Console.Clear();
                        DifficultyGenerator(operationPick, games, "Hard");
                        break;
                    default:
                        Console.WriteLine("Please pick an option between 1 and 3.");
                        again = false;
                        break;
                }
            } while (again == false);            
        }

        public static void DifficultyGenerator(string operationPick, int games, string difficulty)
        {
            int number1 = 0;
            int number2 = 0;

            for (int i = 0; i < games; i++)
            {
                switch (difficulty)
                {
                    case "Easy":
                        {
                            Random random = new Random();
                            number1 = random.Next(1, 101);
                            number2 = random.Next(1, 101);

                            if (operationPick == "Division")
                            {
                                do
                                {
                                    number1 = random.Next(0, 101);
                                    number2 = random.Next(1, 11);
                                } while (number1 % number2 != 0);

                                Numbers.Add(number1);
                                Numbers.Add(number2);
                            }
                        }
                        break;
                    case "Medium":
                        {
                            Random random = new Random();
                            number1 = random.Next(100, 501);
                            number2 = random.Next(100, 501);

                            if (operationPick == "Division")
                            {
                                do
                                {
                                    number1 = random.Next(50, 1001);
                                    number2 = random.Next(2, 51);
                                } while (number1 % number2 != 0);

                                Numbers.Add(number1);
                                Numbers.Add(number2);
                            }
                        }
                        break;
                    case "Hard":
                        {
                            Random random = new Random();
                            number1 = random.Next(500, 1001);
                            number2 = random.Next(500, 1001);

                            if (operationPick == "Division")
                            {
                                do
                                {
                                    number1 = random.Next(500, 100001);
                                    number2 = random.Next(12, 101);
                                } while (number1 % number2 != 0);

                                Numbers.Add(number1);
                                Numbers.Add(number2);
                            }
                        }
                        break;
                }
                if (operationPick == "Substraction" && number2 > number1)
                {
                    Numbers.Add(number2);
                    Numbers.Add(number1);
                }
                else if (operationPick == "Addition" || operationPick == "Multiplication")
                {
                    Numbers.Add(number1);
                    Numbers.Add(number2);
                }
            }
        }
    }
}
