

// ASK PLAYER A QUESTION + GET INPUT + ADD POINTS

// PARTIDAS MINIMA 5 PREGUNTAS

// DIVISIONS SHOULD RESULT IN INTEGERS + DIVIDENDS SHOULD BE BETWEEN 0 AND 100

// MENU TO CHOOSE OPERATION

// RECORD FROM PREVIOUS GAMES + VISUALIZE LIST

using System.IO.Pipelines;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.Marshalling;

Random rng = new Random();


int currentPoints = 0;
int currentAnswer = -1;

string? input;

int matchLength = 5;

List<string> previousGamesHistory = new List<string>();
bool mainMenuExit = false;

int mainMenuChosenOption = 0;

//0 - Add, 1 - Substraction, 2 - Mult, 3 - Div, 4 - Random
int chosenOperation = 0;

while (!mainMenuExit)
{
    Console.Clear();

    Console.WriteLine(
    @"  
    --------- 
    MATH GAME
    ---------
");
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1. Play");
    Console.WriteLine("2. Choose Operations");
    Console.WriteLine("3. See Match Record");
    Console.WriteLine("4. Exit");


    mainMenuChosenOption = InputToInt();

    Console.WriteLine($"YOU CHOSE OPTION {mainMenuChosenOption}");
    Console.ReadLine();
    Console.Clear();

    switch (mainMenuChosenOption)
    {
        // PLAY 
        case 1:

            int currentMatch = 0;

            do
            {


                int operationResult = OperationHandler(chosenOperation);
                currentAnswer = InputToInt();


                if (operationResult == currentAnswer)
                {
                    currentPoints++;
                    Console.WriteLine("Correct Answer!! +1 Points!");
                    Console.WriteLine($"Current Points: {currentPoints}");

                    currentMatch++;

                }
                else
                {
                    Console.WriteLine("Wrong Answer!! \n GAME OVER ");

                    RecordPoints(ref currentPoints);
                    currentMatch = matchLength;
                }

            } while (currentMatch < matchLength);

            break;

        // CHOOSE OPERATIONS 

        case 2:

            do
            {
                Console.WriteLine("Choose the game's operations!!");
                Console.WriteLine($"Current Operation chosen: {OperationToString(chosenOperation)}");

                Console.WriteLine("0 - Addition");
                Console.WriteLine("1 - Substraction");
                Console.WriteLine("2 - Multiplication");
                Console.WriteLine("3 - Division");
                Console.WriteLine("4 - Random Operations ");

                chosenOperation = InputToInt();


                // SEE if Option Good
                if (chosenOperation < 0 || chosenOperation > 4)
                {
                    Console.WriteLine("Choose a Valid operation or write just the number");
                }


            } while (chosenOperation < 0 || chosenOperation > 4);

            Console.WriteLine($"YOU CHOSE {OperationToString(chosenOperation)}");

            break;

        // RECORD
        case 3:

            ShowRecord();

            break;
        // EXIT     
        case 4:
            mainMenuExit = true;
            Console.WriteLine("Bye Bye!");
            break;

        default:
            Console.WriteLine($"THERE IS NO OPTION {mainMenuChosenOption}");

            break;
    }

    Console.ReadLine();

}
;


void ShowRecord()
{
    if (previousGamesHistory.Count <= 0)
    {
        Console.WriteLine(" No Record Yet!");
        return;
    }

    foreach (string a in previousGamesHistory)
    {
        Console.WriteLine($"{a}");
    }
}
void RecordPoints(ref int pointsToRecord)
{
    previousGamesHistory.Add($"Points of previous match: {pointsToRecord}");
    pointsToRecord = 0;
}
int OperationHandler(int operationNumber)
{
    int currentOperation = operationNumber;
    bool operationHasBeenChosen = false;

    do
    {
        switch (currentOperation)
        {
            //ADDITION
            case 0:
                operationHasBeenChosen = true;
                return AdditionHandler();
                break;
            //SUBSTRACTION
            case 1:
                operationHasBeenChosen = true;
                return SubstractionHandler();
                break;

            //MULTIPLICATION
            case 2:
                operationHasBeenChosen = true;
                return MultiplicationHandler();
                break;
            //DIVISION
            case 3:
                operationHasBeenChosen = true;
                return DivisionHandler();
                break;
            //RANDOM
            case 4:
                currentOperation = rng.Next(0, 4);
                break;
        }
    } while (!operationHasBeenChosen);
    return -1;
}

string OperationToString(int operationNumber)
{
    string operationName = "";

    switch (operationNumber)
    {
        case 0:
            operationName = "Addition";
            break;
        case 1:
            operationName = "Substraction";
            break;
        case 2:
            operationName = "Multiplication";
            break;
        case 3:
            operationName = "Division";
            break;
        case 4:
            operationName = "Random Operation";
            break;
    }

    return operationName;
}
int AdditionHandler()
{
    int firstOperand = rng.Next(0, 101);
    int secondOperand = rng.Next(0, 101);

    Console.WriteLine("QUESTION:");
    Console.WriteLine($"{firstOperand} + {secondOperand} = ???");

    return firstOperand + secondOperand;
}

int SubstractionHandler()
{
    int firstOperand = rng.Next(0, 101);
    int secondOperand = rng.Next(0, 101);

    while (secondOperand > firstOperand)
    {
        firstOperand = rng.Next(0, 101);
        secondOperand = rng.Next(0, 101);
    }


    Console.WriteLine("QUESTION:");
    Console.WriteLine($"{firstOperand} - {secondOperand} = ???");

    return firstOperand - secondOperand;
}

int MultiplicationHandler()
{
    int firstOperand = rng.Next(0, 101);
    int secondOperand = rng.Next(0, 101);

    Console.WriteLine("QUESTION:");
    Console.WriteLine($"{firstOperand} x {secondOperand} = ???");

    return firstOperand * secondOperand;
}

int DivisionHandler()
{
    int firstOperand = rng.Next(1, 101);
    int secondOperand = rng.Next(1, 101);

    while (firstOperand % secondOperand != 0)
    {
        firstOperand = rng.Next(1, 101);
        secondOperand = rng.Next(0, 101);
    }

    Console.WriteLine("QUESTION:");
    Console.WriteLine($"{firstOperand} / {secondOperand} = ???");

    return firstOperand / secondOperand;
}


int InputToInt()
{
    bool validInput = false;
    int parsedInput = -1;
    do
    {

        input = Console.ReadLine();

        if (input != null)
        {
            validInput = int.TryParse(input, out parsedInput);
        }

    } while (!validInput);

    return parsedInput;
}