namespace MathGame
{
    internal class Menu
    {
        public static List<string> History = new List<string>();

        public void Print()
        {
            Console.WriteLine("\tMATH GAME - MENU");
            Console.WriteLine();
            Console.WriteLine("1. Addition Game");
            Console.WriteLine("2. Subtraction Game");
            Console.WriteLine("3. Multiply Game");
            Console.WriteLine("4. Division Game");
            Console.WriteLine("5. Random Game");
            Console.WriteLine("6. Review questions");
            Console.WriteLine("7. Exit");
            Console.WriteLine();
        }

        public int ChooseOption()
        {
            int choice;
            Console.Write("<*> Your choice is: ");

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input! Please try again.");
                    continue;
                }

                if (choice < 1 || choice > 7)
                {
                    Console.WriteLine("Invalid choice! Please try again.");
                    continue;
                }
                else
                    break;
            }

            return choice;
        }

        public int ChooseDifficulty()
        {
            int difficulty;
            Console.WriteLine("\n<*> Choose your level of difficulty: ");
            Console.WriteLine("    1. Easy");
            Console.WriteLine("    2. Medium");
            Console.WriteLine("    3. Hard");
            Console.WriteLine("    4. Very Hard (maybe)");
            Console.WriteLine();
            Console.Write("Your choice is: ");

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out difficulty))
                {
                    Console.WriteLine("Invalid input! Please try again.");
                    continue;
                }

                if (difficulty < 1 || difficulty > 4)
                {
                    Console.WriteLine("Invalid difficulty! Please try again.");
                    continue;
                }
                else
                    break;
            }

            return difficulty;
        }

        public int ChooseQuestions()
        {
            int n;
            Console.WriteLine("\n<*> How many questions do you want? ");
            Console.Write("Number of questions: ");

            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Invalid input! Please try again.");
                continue;
            }

            return n;
        }



}
}
