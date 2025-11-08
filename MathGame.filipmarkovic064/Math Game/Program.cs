using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        List<String> history = new List<String>();
        mainMenu(history);
    }
    static public int getInput()
    //Try catch to catch all invalid input (non-int)
    {
        int answer = 0;
        try 
        {
            answer = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException e) 
        {
            Console.WriteLine(e);
        }
        return answer;

    }
    static public void mainMenu(List<String> history)
    {
        Console.Clear();
        Console.WriteLine("Welcome, choose your option!\n");
        Console.WriteLine("Type anything else to play\n");
        Console.WriteLine("Type H for Match History\n");
        Console.WriteLine("Type Q to exit");
        String command = Console.ReadLine();

        if (command == "Q" || command == "q")
        {
            Environment.Exit(0);
        }
        else if (command == "H" || command == "h")
        {
            getHistory(history);
        }
        else
        {
            play(history);
        }
    }
    static public void play(List<String> history)
    //Allowing the user to choose the amount of questions and randomizing the operations/numbers they get
    {
        Console.Clear();
        Random rand = new Random();
        char[] symbols = ['+', '-', '*', '/'];
        Console.WriteLine("How many questions would you like?");
        int amountOfQuestions = getInput();
        int points = 0;
        for (int i = 1; i < amountOfQuestions + 1; i++)
        {
            Console.Clear();
            int a = rand.Next(1, 100);
            int b = rand.Next(1, 10);
            int op = rand.Next(0, 4);
            while(op == 3 && (a % b) != 0){
                b = rand.Next(1, 20);
            }
            Console.WriteLine($"Question #{i}");
            Console.WriteLine($"What's {a} {symbols[op]} {b}");
            int answer = getInput();
            if (answer == calculate(a,b,op))
            {
                Console.WriteLine("Correct, press any key to continue!");
                Console.ReadKey();
                points++;
            }
            else
            {
                Console.WriteLine($"Wrong, the correct answer is {calculate(a,b,op)}");
                Console.WriteLine("Press any key to continue!");
                Console.ReadKey();
            }
        }
        Console.WriteLine($"Game Over. You scored {points} out of the possible {amountOfQuestions} points, press any key to go back to the main menu!");
        String score= $"{points} / {amountOfQuestions} points";
        history.Add(score);
        Console.ReadKey();
        mainMenu(history);
    }
    static public int calculate(int a, int b,  int opIndex)
    {
        //Calculation logic, no need to check if dividend is 0 because the numbers dont go below 1
        int answer = 0;
        char[] symbols = ['+', '-', '*', '/'];
        char operation = symbols[opIndex];
        switch (operation)
        {
            case '+':
                answer = a + b;
                break;
            case '-':
                answer = a - b;
                break;
            case '*':
                answer = a * b;
                break;
            case '/':
                answer = a / b;
                break;
        }
        return answer;
    }
    static public void getHistory(List<String> history)
    {
        //Saving the match history in a list which i then print out
        Console.Clear();
        Console.WriteLine("History!");
        for(int i = history.Count; i > 0; i--)
        {
            Console.WriteLine($"Game #{i}: {history[i-1]}");
        }
        Console.WriteLine("Press any button to go back to Main Menu");
        Console.ReadKey();

        mainMenu(history);
    }
}