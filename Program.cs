// See https://aka.ms/new-console-template for more information

bool exit =  true;
Random random = new Random();
int answer =0;
int gameNumber = 0;
string[,]history= new string[10,4];
string question = "";

List <string> historyList = new List<string>();

while(exit)
{
    Console.WriteLine("--------------------------------------------");
    Console.WriteLine(@"select one of the below 4 basis operations to start the game:
    A - Addition
    S - Subtraction
    M - Multiplication
    D - Division
    Q - Quit the program
    P - Previous games");
    Console.WriteLine("--------------------------------------------");
    string?result = Console.ReadLine().ToUpper().Trim();

    int firstNumber = random.Next(0,101);
    int secondNumber = random.Next(0,101);
    
    switch (result)
    {
        case "A":
        question = $"{firstNumber} + {secondNumber}";
        answer = firstNumber + secondNumber;
        gameNumber +=1;
        break;

        case "S":
        question = $"{firstNumber} - {secondNumber}";
        gameNumber +=1;
        answer = firstNumber - secondNumber;
        break;

        case "M":
        question = $"{firstNumber} x {secondNumber}";
        gameNumber +=1;
        answer = firstNumber * secondNumber;
        break;

        case "D":
            gameNumber +=1;
            bool wholeNumber = true;
            while (wholeNumber)
            {
                if ((secondNumber !=0) && (firstNumber%secondNumber == 0))
                {
                    wholeNumber = false;
                }

                else
                    {
                        firstNumber = random.Next(0,101);
                        secondNumber = random.Next(0,101);
                    }
            }
            question = $"{firstNumber} / {secondNumber}";
            answer = firstNumber / secondNumber;
            break;

        case "Q":
        exit = false;
        return;

        case "P":
        for (int i = 0; i < gameNumber; i++)
        {
           /* Console.WriteLine($"Game Number: {history[i,0]}");
            Console.WriteLine($"Question: {history[i,1]}");
            Console.WriteLine($"Answer: {history[i,2]}");
            Console.WriteLine($"Guess: {history[i,3]}");
            Console.WriteLine();*/
            Console.WriteLine(historyList[i]);
            Console.WriteLine();
        }
        break;


        default:
        Console.WriteLine("Invalid Input!");
        break;
    }

    if (result != "P")
    {
    Console.WriteLine($"{question}: ");
    bool parseCheck = int.TryParse(Console.ReadLine(), out int guess);
    UpdateHistory(answer, guess);
    if (guess == answer)
        Console.WriteLine("Correct!");
    else
     {  
        Console.WriteLine("Wrong");
        Console.WriteLine($"Correct Answer is {answer}");
     }
    }
Console.WriteLine("\n Press any Key to continue");
Console.ReadLine();
}

void UpdateHistory(int answer, int guess)
{
    
    /*history[gameNumber-1,0] = gameNumber.ToString(); 
    history[gameNumber-1,1] = question;
    history[gameNumber-1,2] = answer.ToString();
    history[gameNumber-1,3] = guess.ToString();*/

    historyList.Add($"Question #{gameNumber.ToString()} is {question}. Your Guess was {guess.ToString()}. The Correct Answer was {answer.ToString()}");
}