public class Messages
{
    public static void WelcomeMessage()
    {
        Console.WriteLine("Welcome to the simple math game.");
        Console.WriteLine("In this game you are asked questions on one of the 4 basic arithmetic functions and are awarded points accordingly.");
    }

    public static void MenuMessage(int numberOfQuestions)
    {
        Console.WriteLine("-----------------------------------------------------------------------");
        Console.WriteLine($"There are {numberOfQuestions} rounds left");
        Console.WriteLine("What game would you like to play this round? Choose from the below options: ");
        Console.WriteLine("V - View previous games");
        Console.WriteLine("A - Additions");
        Console.WriteLine("S - Subtraction");
        Console.WriteLine("M - Multiplication");
        Console.WriteLine("D - Division");
        Console.WriteLine("R - Random");
        Console.WriteLine("Q - Quite the game");
        Console.WriteLine("-----------------------------------------------------------------------");
    }

    public static void DifficultyMessage()
    {
        Console.WriteLine("-----------------------------------------------------------------------");
        Console.WriteLine("First things first. Choose your difficulty level: ");
        Console.WriteLine("E - Easy");
        Console.WriteLine("M - Medium");
        Console.WriteLine("H - Hard");
        Console.WriteLine("-----------------------------------------------------------------------");
    }

    public static void NumberOfQuestionsMessage()
    {
        Console.WriteLine("-----------------------------------------------------------------------");
        Console.WriteLine("How many questions do you plan to answer?");
        Console.WriteLine("Note that at each question you can exit the game by pressing Q ");
        Console.Write("Number of Questions: ");
        Console.WriteLine("-----------------------------------------------------------------------");
    }

    public static void MenuError()
    {
        Console.Write("This was not one of the choices. Please try again: ");
    }

    public static void WinMessage()
    {
        Console.WriteLine("That's correct");
    }

    public static void LossMessage(int result)
    {
        Console.WriteLine($"You are incorrect. The actual result is {result}");
    }

    public static void EndOfGameMessage()
    {
        Console.WriteLine("-----------------------------------------------------------------------");
        Console.WriteLine("Congrats you finished the game.");
        Console.WriteLine("Here are your results. Press enter to close the game.");
        Console.WriteLine("-----------------------------------------------------------------------");
    }
}