List<decimal> listResults = new List<decimal>();

Console.WriteLine("Welcome to the Maths Game" + System.Environment.NewLine +
"Please enter your selection from the menu below:" + System.Environment.NewLine +
"0: Exit" + System.Environment.NewLine +
"1: Addition" + System.Environment.NewLine +
"2: Subtraction" + System.Environment.NewLine +
"3: Multiplication" + System.Environment.NewLine +
"4: Division" + System.Environment.NewLine +
"5: Show all results");

var isNumber = int.TryParse(Console.ReadLine(), out int n);
while (!isNumber)
{
    Console.WriteLine("You have not entered in a valid number, please try again:");
    isNumber = int.TryParse(Console.ReadLine(), out n);
}
var menuIn = n;

while (menuIn < 0 || menuIn > 5)
{
    Console.WriteLine("You have not entered a valid in the menu please try again!");
    Console.WriteLine("Welcome to the Maths Game" + System.Environment.NewLine +
    "Please enter your selection from the menu below:" + System.Environment.NewLine +
    "0: Exit" + System.Environment.NewLine +
    "1: Addition" + System.Environment.NewLine +
    "2: Subtraction" + System.Environment.NewLine +
    "3: Multiplication" + System.Environment.NewLine +
    "4: Division" + System.Environment.NewLine +
    "5: Show all results");
    menuIn = int.Parse(Console.ReadLine());
}


while (menuIn != 0)
{
    switch (menuIn)
    {

        case 1:
            Console.WriteLine("You have chosen 1 - addition from the menu");
            decimal addValue1 = GetInput();
            decimal addValue2 = GetInput();
            decimal resultAdd = Addition(addValue1, addValue2);
            listResults.Add(resultAdd);
            Console.WriteLine($"The result is:{resultAdd}");
            break;
        case 2:
            Console.WriteLine("You have chosen 2 - subtraction from the menu");
            decimal subValue1 = GetInput();
            decimal subValue2 = GetInput();
            decimal resultSub = Subtraction(subValue1, subValue2);
            listResults.Add(resultSub);
            Console.WriteLine($"The result is:{resultSub}");
            break;
        case 3:
            Console.WriteLine("You have chosen 3 - multiplication from the menu");
            decimal multValue1 = GetInput();
            decimal multValue2 = GetInput();
            decimal resultMult = Multiplication(multValue1, multValue2);
            listResults.Add(resultMult);
            Console.WriteLine($"The result is:{resultMult}");
            break;
        case 4:
            Console.WriteLine("You have chosen 4 - division from the menu");
            decimal divValue1 = GetInput();
            decimal divValue2 = GetInput();
            decimal resultDiv = Math.Round(Division(divValue1, divValue2), 3);
            listResults.Add(resultDiv);
            Console.WriteLine($"The result is:{resultDiv}");
            break;


        case 5:
            Console.WriteLine("You have chosen 5 - the results of the game are");
            for (int i = 0; i < listResults.Count; i++)
            {
                Console.WriteLine($"The result of game {i}:{listResults[i]}");
            }
            break;
    }
    Console.WriteLine("Please enter your selection from the menu below:" + System.Environment.NewLine +
    "0: Exit" + System.Environment.NewLine +
    "1: Addition" + System.Environment.NewLine +
    "2: Subtraction" + System.Environment.NewLine +
    "3: Multiplication" + System.Environment.NewLine +
    "4: Division" + System.Environment.NewLine +
    "5: Show all results");
    menuIn = int.Parse(Console.ReadLine());

}

Console.WriteLine("You have chosen 0 - exit the Maths Game");
Console.WriteLine("The game has now ended.");

static decimal GetInput()
{
    Console.WriteLine("Enter in a number:");
    var isNumber = decimal.TryParse(Console.ReadLine(), out decimal n);

    while (!isNumber)
    {
        Console.WriteLine("You have not entered in a valid number, please try again:");
        isNumber = decimal.TryParse(Console.ReadLine(), out n);

    }
    decimal output = n;
    Console.WriteLine($"You have entered in a value of :{output}");
    return output;
}
static decimal Addition(decimal value1, decimal value2)
{
    decimal output = value1 + value2;
    return output;
}

static decimal Subtraction(decimal value1, decimal value2)
{
    decimal output = value1 - value2;
    return output;
}

static decimal Division(decimal value1, decimal value2)
{
    decimal output = value1 / value2;
    return output;
}

static decimal Multiplication(decimal value1, decimal value2)
{
    decimal output = value1 * value2;
    return output;
}