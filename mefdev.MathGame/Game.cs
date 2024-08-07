using System;
namespace MathGame
{
    public class Game
    {

        private int level = 1;
        public int score = 0;
        public List<string> records = new List<string>();
        private Random random = new Random();
        public Game()
        {

        }
        public string GetRandomOperator()
        {
            string[] operationLists = { "M", "A", "D", "S" };
            return operationLists[random.Next(operationLists.Length)];
        }
        public int GetRandomNumberBasedOnLevelDifficulty()
        {
            int difficulty = 10;
            switch (level)
            {
                case 1:
                    return random.Next(0, difficulty);
                case 2:
                    return random.Next(0, difficulty * 5);
                default:
                    return random.Next(0, difficulty * 10);
            }
        }
        public void IncreaseLevel()
        {
            level++;
        }
        private void DisplayRecords()
        {
            Console.WriteLine("\n\tDate\t\tType\t\tScore\n");
            foreach (var record in records)
            {
                Console.WriteLine(record);

            }
            Console.Write("Press any key to continue playing");
            Console.ReadLine();

        }
        public string FormatRecord(string operationName, int score)
        {
            DateTime _date = DateTime.Now;
            var _dateString = _date.ToString("dd/MM/yyyy");
            return $"\n\t{_dateString}\t{operationName}\t{score}\n";
        }
        public void Save(string result)
        {
            records.Add(result);
        }


        public void CheckRecord(int number1, string operation, int number2, int result)
        {

            Console.Write($"\n{number1} {operation} {number2} = ");
            if (int.TryParse(Console.ReadLine(), out int userValue))
            {
                if (userValue.Equals(result))
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                    Console.WriteLine("Wrong!");
            }
            else
            {
                throw new InvalidDataException("Invalid Data");
            }
        }

        public void VisualizeHistory()
        {
            DisplayRecords();
        }
        public bool CheckWinner(int questionAnswerd)
        {
            return questionAnswerd.Equals(score);
        }
    }
}

