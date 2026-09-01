Console.WriteLine("Hello.The MathGame have 5 questions for each math opeartion, you need to answer. For each correct answer you will receive 1 point.");

List<string> gamesHistory = [];
bool stillWantToPlay = true;

while (stillWantToPlay)
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("1.Addition\n2.Subtraction\n3.Multiplication\n4.Division\n5.Game history\n6.Exit");
    Console.WriteLine("Choice:");
    string choice = Console.ReadLine();
    int parsed = int.Parse(choice);

    switch (parsed)
    {
        case 1:
            PlayGame("+", gamesHistory);
            break;
        case 2:
            PlayGame("-", gamesHistory);
            break;
        case 3:
            PlayGame("*", gamesHistory);
            break;
        case 4:
            PlayGame("/", gamesHistory);
            break;
        case 5:
            ShowGameHistory(gamesHistory);
            break;
        case 6:
            stillWantToPlay = false;
            break;
    }
}

void ShowGameHistory(List<string> gamesHistory)
{
    foreach (string game in gamesHistory)
    {
        Console.WriteLine(game);
    }
}

void PlayGame(string operationSign, List<string> gamesHistory)
{
    var random = new Random();
    int questionCounter = 0;
    int points = 0;
    int askedQuestions = 2;

    for (int i = 1; i <= askedQuestions; i++)
    {
        int number1;
        int number2;

        do
        {
            number1 = random.Next(0, 101);
            number2 = random.Next(0, 101);
        } while (number1 % number2 == 0);

        int result = 0;
        switch (operationSign)
        {
            case "+":
                result = number1 + number2;
                break;
            case "-":
                result = number1 - number2;
                break;
            case "*":
                result = number1 * number2;
                break;
            case "/":
                result = number1 / number2;
                break;
        }

        Console.WriteLine(i + " question:");
        Console.WriteLine(number1 + operationSign + number2 + " ?");
        string answear = Console.ReadLine();
        int.TryParse(answear, out int answearParsed);
        bool isUserRight = result == answearParsed ? true : false;

        if (isUserRight)
        {
            Console.WriteLine("Correct! 1 point was added");
            points++;
        }
        else
        {
            Console.WriteLine("Not this time. The correct answer is " + result);
        }
        questionCounter++;
    }

    gamesHistory.Add("Result " + points + "/" + askedQuestions);

    Console.WriteLine("You answered all questions.");
    Console.WriteLine("result: " + points + "/" + askedQuestions);
}



   


