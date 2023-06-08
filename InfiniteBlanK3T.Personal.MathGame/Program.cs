using System;

namespace MathGame;

class Program
{
    static List<string> pastResults = new();
    static void Main()
    {
        Console.Clear();
        Console.WriteLine("\n-------------------------------");
        Console.Write("\tMath Game");
        Console.WriteLine("\n-------------------------------");
        List<int> lList = Difficulty();

        int numberOfQuestion = 0;
        while (numberOfQuestion < 1 || numberOfQuestion > 100)
        {

            numberOfQuestion = getANumber("Numbers of question from 1 to 100: ");
        }
        Operation(numberOfQuestion, lList);
    }

    static List<int> Difficulty()
    {
        var lList = new List<int>();
        Console.WriteLine("\n-------------------------------");
        Console.WriteLine("Choose a difficulty: ");
        Console.WriteLine("1. Easy - 2 numbers with range from 1 to 10");
        Console.WriteLine("2. Medium - 3 numbers with range from 1 to 10");
        Console.Write("3. Hard - 4 numbers with range from 1 to 10");
        Console.WriteLine("\n-------------------------------");
        Console.Write("Your option: ");
        var difficulty = Console.ReadLine();

        switch (difficulty)
        {
            case "1":
                lList.Add(1);
                lList.Add(2);
                return lList;
            case "2":
                lList.Add(1);
                lList.Add(2);
                lList.Add(3);
                return lList;
            case "3":
                lList.Add(1);
                lList.Add(2);
                lList.Add(3);
                lList.Add(4);
                return lList;
            default:
                Console.WriteLine("Wrong option. Press ENTER to try again.");
                Console.ReadLine();
                Console.Clear();
                return Difficulty();
        }
    }

    static int getANumber(string aString)
    {
        Console.Write(aString);
        string numberInput = Console.ReadLine();
        while (!int.TryParse(numberInput, out _) || Convert.ToInt32(numberInput) == null)
        {
            Console.Write($"Invalid! Try again!{aString}");
            numberInput = Console.ReadLine();
        }
        return Convert.ToInt32(numberInput);
    }

    static void Operation(int aNumberOfQuestion, List<int> aList)
    {
        int lPoint = 0;
        Random random = new();
        if (pastResults.Count > 0)
        {
            Console.Write("Your past results : { ");
            for(int i = 0; i < pastResults.Count; i++)
            {

                if (i == pastResults.Count - 1)
                {
                    Console.Write(pastResults[i] + " } ");
                }
                else if (i == 0)
                    { Console.Write(pastResults[i] + ", "); }
                else { Console.Write(pastResults[i] + ", ");}
                
            }
        }
        Console.WriteLine("\n-------------------------------");
        Console.WriteLine("Choose an operation:");
        Console.WriteLine("\t1. Addition");
        Console.WriteLine("\t2. Subtraction");
        Console.WriteLine("\t3. Multiplication");
        Console.WriteLine("\t4. Division");
        Console.WriteLine("\t5. Random");
        Console.WriteLine("-------------------------------");
        Console.Write("Your option: ");

        var operation = Console.ReadLine();

        DateTime timeStart = DateTime.Now;
        Console.WriteLine($"Time started: {timeStart:H:mm}");
        for (int i = 0; i < aNumberOfQuestion; i++)
        {
            for (int j = 0; j < aList.Count; j++) { aList[j] = random.Next(0, 100); }
            Console.WriteLine("-------------------------------");
            switch (operation)
            {
                case "1":
                    if (Addition(aList))
                        lPoint++;
                    break;
                case "2":
                    if (Subtraction(aList))
                        lPoint++;
                    break;
                case "3":
                    if (Multiplication(aList))
                        lPoint++;
                    break;
                case "4":
                    if (Division(aList))
                        lPoint++;
                    break;
                case "5":
                    int randomOperation = random.Next(1, 5);
                    switch (randomOperation)
                    {
                        case 1:
                            if (Addition(aList))
                                lPoint++;
                            break;
                        case 2:
                            if (Subtraction(aList))
                                lPoint++;
                            break;
                        case 3:
                            if (Multiplication(aList))
                                lPoint++;
                            break;
                        case 4:
                            if (Division(aList))
                                lPoint++;
                            break;
                    }
                    break;

                default:
                    Console.WriteLine("Wrong option. Press Enter to try again.");
                    Console.ReadLine();
                    Console.Clear();
                    Operation(aNumberOfQuestion, aList);
                    return;
            }
        }
        DateTime timeEnd = DateTime.Now;
        TimeSpan timeSpan = timeEnd - timeStart;
        Console.WriteLine("-------------------------------");
        if (timeSpan.TotalSeconds > 60)
        {
            int second = (int) (timeSpan.TotalSeconds % 60);
            int min = (int)(timeSpan.TotalSeconds / 60);
            Console.WriteLine($"Time finished: {min}m:{second}s");
        }
        Console.WriteLine($"Time finished: {(int)timeSpan.TotalSeconds}s");

        string result = $"{lPoint}/{aNumberOfQuestion}";
        Console.WriteLine($"Your Result is {result}");
        
        pastResults.Add(result);

        Console.Write("Press '0' then ENTER to exit. ANY to return");
        var option = Console.ReadLine();
        if (option == "0")
            return;
        Console.Clear();
        Operation(aNumberOfQuestion, aList);
    }

    static bool Addition(List<int> aList)
    {
        int result = 0;

        for (int i = 0; i < aList.Count; i++)
        {
            result += aList[i];
            if (i == aList.Count - 1)
            {
                Console.Write($"{aList[i]} = ?");
            }
            else { Console.Write($"{aList[i]} + "); }
        }
        int answer = getANumber("\nEquals to: ");
        if (answer != result)
        {
            Console.WriteLine($"Wrong!. Right answer: {result}");
            return false;
        }
        Console.WriteLine("Correct!");
        return true;
    }

    static bool Subtraction(List<int> aList)
    {
        int result = 0;

        for (int i = 0; i < aList.Count; i++)
        {
            result -= aList[i];
            if (i == aList.Count - 1)
            {
                Console.Write($"{aList[i]} = ?");
            }
            else { Console.Write($"{aList[i]} - "); }
        }
        int answer = getANumber("\nEquals to: ");

        if (answer != result)
        {
            Console.WriteLine($"Wrong!. Right answer: {result}");
            return false;
        }
        Console.WriteLine("Correct!");
        return true;
    }

    static bool Multiplication(List<int> aList)
    {
        int result = 1;

        for (int i = 0; i < aList.Count; i++)
        {
            result *= aList[i];
            if (i == aList.Count - 1)
            {
                Console.Write($"{aList[i]} = ?");
            }
            else { Console.Write($"{aList[i]} * "); }
        }
        int answer = getANumber("\nEquals to: ");

        if (answer != result)
        {
            Console.WriteLine($"Wrong!. Right answer: {result}");
            return false;
        }
        Console.WriteLine("Correct!");
        return true;
    }

    static bool Division(List<int> aList)
    {
        int result = Convert.ToInt32(Math.Pow(aList[0],2));

        for (int i = 0; i < aList.Count; i++)
        {
            result /= aList[i];
            if (i == aList.Count - 1)
            {
                Console.Write($"{aList[i]} = ?");
            }
            else { Console.Write($"{aList[i]} / "); }
        }
        int answer = getANumber("\nEquals to: ");

        if (answer != result)
        {
            Console.WriteLine($"Wrong!. Right answer: {result}");
            return false;
        }
        Console.WriteLine("Correct!");
        return true;
    }
}