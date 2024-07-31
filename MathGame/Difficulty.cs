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
            string difficulty = Console.ReadLine();

            switch(difficulty)
            {
                case "1":
                    Console.Clear();
                    Easy(operationPick, games);
                    break;
                case "2":
                    Console.Clear();
                    Medium(operationPick, games);
                    break;
                case "3":
                    Console.Clear();
                    Hard(operationPick, games);
                    break;
            }
        }

        public static void Easy(string operationPick, int games)
        {
            for(int i = 0; i < games; i++)
            {
                Random random = new Random();
                int number1 = random.Next(1, 101);
                int number2 = random.Next(1, 101);

                if (operationPick == "Divison")
                {
                    do
                    {
                        number1 = random.Next(0, 101);
                        number2 = random.Next(1, 11);
                    } while (number1 % number2 != 0);

                    Numbers.Add(number1);
                    Numbers.Add(number2);
                }
                else if (operationPick == "Substraction" && number2 > number1)
                {
                    Numbers.Add(number2);
                    Numbers.Add(number1);
                }
                else
                {
                    Numbers.Add(number1);
                    Numbers.Add(number2);
                }                
            }           
        }

        public static void Medium(string operationPick, int games)
        {
            for (int i = 0; i < games; i++)
            {
                Random random = new Random();
                int number1 = random.Next(100, 501);
                int number2 = random.Next(100, 501);

                if (operationPick == "Divison")
                {
                    do
                    {
                        number1 = random.Next(50, 1001);
                        number2 = random.Next(2, 51);
                    } while (number1 % number2 != 0);

                    Numbers.Add(number1);
                    Numbers.Add(number2);
                }
                else if (operationPick == "Substraction" && number2 > number1)
                {
                    Numbers.Add(number2);
                    Numbers.Add(number1);
                }
                else
                {
                    Numbers.Add(number1);
                    Numbers.Add(number2);
                }               
            }
        }
        public static void Hard(string operationPick, int games)
        {
            for (int i = 0; i < games; i++)
            {
                Random random = new Random();
                int number1 = random.Next(500, 1001);
                int number2 = random.Next(500, 1001);

                if (operationPick == "Division")
                {
                    do
                    {
                        number1 = random.Next(500, 100001);
                        number2 = random.Next(12, 101);
                    } while (number1 % number2 != 0);
                }
                else if (operationPick == "Substraction" && number2 > number1)
                {
                    Numbers.Add(number2);
                    Numbers.Add(number1);
                }
                else
                {
                    Numbers.Add(number1);
                    Numbers.Add(number2);
                }              
            }
        }
    }
}
