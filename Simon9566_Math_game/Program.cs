List<char> operations = new List<char>();
string data = "asmd";
operations.AddRange(data);

Console.WriteLine(@"Hello, what would you like to do today?
[a]dd
[s]ubtract
[m]ultiply
or [d]ivide
2 numbers?");

// History, list of results and how many are stored currently
List<int> history = new List<int>();
int history_count = 0;

// Validation of operations, only single characters in operations list will pass
string operation = Console.ReadLine();
operation = operation.ToLower();
while (!(operation.Length == 1 && operations.Contains(operation.First())))
{
    if (operation.Length != 1)
    {
        Console.WriteLine("Please enter a single letter");
    }
    else
    {
        Console.WriteLine("Please enter a valid operation from the list");
    }
    operation = Console.ReadLine();
}

// Operands for the operations, separate ones for floating point numbers and user inputs
int operand_a = 0;
int operand_c = 0;
float operand_b = 0.0f;
float operand_d = 0.0f;
int result_int = 0;
float result_float = 0.0f;
string user_input1 = "";
string user_input2 = "";
bool isvalid_a = false;
bool isvalid_b = false;
bool isvalid_c = false;
bool isvalid_d = false;

// Validating the user input and assigning them to the correct operands
float ValidateFloatInput(string str)
{
    str = str.Replace(",", ".");
    if (float.TryParse(str, out float tmp))
    {
        return tmp;
    }
    else
    {
        return 0.0f;
    }
}

int ValidateIntInput(string str)
{
    if (int.TryParse(str, out int tmp))
    {
        return tmp;
    }
    else
    {
        Console.WriteLine("The number you entered is invalid");
        return 0;
    }

}

// Validating the first user input
while (operand_a == 0 && operand_b == 0.0f)
{
    Console.WriteLine("Enter the first number");
    user_input1 = Console.ReadLine();

    if (user_input1.Contains(",") || user_input1.Contains("."))
    {
        operand_b = (float)ValidateFloatInput(user_input1);
    }
    else
    {
        operand_a = ValidateIntInput(user_input1);
    }
}

// Asking for the second operand depending on the operation chosen
switch (operation)
{
    case "a":
        Console.WriteLine($"What would you like to add to {user_input1}?");
        user_input2 = Console.ReadLine();
        break;
    case "s":
        Console.WriteLine($"What would you like to subtract from {user_input1}?");
        user_input2 = Console.ReadLine();
        break;
    case "m":
        Console.WriteLine($"What would you like to multiply {user_input1} by?");
        user_input2 = Console.ReadLine();
        break;
    case "d":
        Console.WriteLine($"What would you like to divide {user_input1} by?");
        user_input2 = Console.ReadLine();
        break;
}


// Validating the second user input
while (operand_c == 0 && operand_d == 0.0f)
{
    user_input2 = Console.ReadLine();
    if (user_input2 == "0")
    {
        Console.WriteLine("Are you sure you want to continue with 0?\n y/n");
        string check = Console.ReadLine();
        if (check.ToLower() == "n")
        {
            continue;
        }
        else
        {
            switch (operation)
            {
                case "a":
                    Console.WriteLine($"The result is {user_input1}");
                    break;
                case "s":
                    Console.WriteLine($"The result is {user_input1}");
                    break;
                case "m":
                    Console.WriteLine("The result is 0");
                    break;
                case "d":
                    Console.WriteLine("Unfortunately i cannot do that");
                    break;
            }
        }
    }

    if (user_input2.Contains(",") || user_input2.Contains("."))
    {
        operand_d = (float)ValidateFloatInput(user_input2);
    }
    else
    {
        operand_c = ValidateIntInput(user_input2);
    }
}

// Getting the result and displaying it, ADD THE RESULT TO HISTORY
if (operand_a != 0 && operand_c != 0)
    switch (operation)
    {
        case "a":
            result_int = operand_a + operand_c;
            operand_a = 0;
            operand_c = 0;
            Console.WriteLine($"{result_int}");
            break;
        case "s":
            result_int = operand_a - operand_c;
            operand_a = 0;
            operand_c = 0;
            Console.WriteLine($"{result_int}");
            break;
        case "m":
            result_int = operand_a * operand_c;
            operand_a = 0;
            operand_c = 0;
            Console.WriteLine($"{result_int}");
            break;
        case "d":
            result_float = operand_a / operand_c;
            operand_a = 0;
            operand_c = 0;
            Console.WriteLine($"{result_float}");
            break;
    }