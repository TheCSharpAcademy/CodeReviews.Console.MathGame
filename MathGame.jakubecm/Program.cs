bool exitFlag = false;
string playerName = "player";


Console.WriteLine($"Greetings, {playerName}! Choose your name, or press enter to keep the default name: ");
var userInput = Console.ReadLine();

if (userInput.ToString() != "")
{
    playerName = userInput;
}

while (!exitFlag)
{
    Console.WriteLine($"\nCurrent player: {playerName}");
    Console.WriteLine("Choose action:");
    Console.Write("\t1. Addition game\n\t2. Subtraction game\n\t3. Multiplication game\n\t4. Division game\n\t4. View game history\n\t5. Exit program\n");
    var selectedGame = Console.ReadLine();

    Console.WriteLine(selectedGame);
}

