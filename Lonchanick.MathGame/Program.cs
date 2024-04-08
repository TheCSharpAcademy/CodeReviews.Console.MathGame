
List<string> operations = new();

do
{
    Console.Clear();
    Console.WriteLine("\tMenu");
    Console.WriteLine("1) Sum");
    Console.WriteLine("2) Rest");
    Console.WriteLine("3) Mult");
    Console.WriteLine("4) Div");
    Console.WriteLine("5) Show log Operations");
    Console.WriteLine("0) exit");
    string aux = Console.ReadLine();

    switch (int.Parse(aux))
    {
        case 1:
            Console.WriteLine("\tSum");
            Sum();
            break;
        case 2:
            Console.WriteLine("\tRest");
            Rest();
            break;
        case 3:
            Console.WriteLine("\tMult");
            Mult();
            break;
        case 4:
            Console.WriteLine("\tDivition");
            Divition();
            break;
        case 5:
            Console.WriteLine("Log operations!");
            if(operations is not null)
            {
                foreach (var opp in operations)
                    Console.WriteLine($" {opp}");

                Console.ReadLine();
            }else
                Console.WriteLine("There is no operations yet!");

            break;

        case 0:
            return;

        default:
            Console.WriteLine("Invalid option");
            break;
    }


} while (true);

 void Divition()
{
    Console.Clear();
    Console.WriteLine("\tDivition");
    bool flag = true;
    int dividend;
    int divisor;
    do
    {
        dividend = GetValidInteger("Dividend");
        divisor= GetValidInteger("Divisor");

        if (Checker(dividend, divisor))
        {
            Console.WriteLine("Done!");
            operations.Add($"{dividend} / {divisor} = {dividend/divisor}");
            flag = false;
        }
        else
            Console.WriteLine("Keep trying!");
        
        Console.ReadLine();
        Console.WriteLine();

    } while (flag);
}

bool Checker(int dividend, int divisor)
{
    if(dividend >100 || divisor > 100)
    {
        Console.WriteLine("Division members can't be > than 100");
        Console.ReadLine();
        return false;
    }
    //var quotient = 
    if((dividend%divisor) > 0)
    {
        Console.WriteLine("Quotient can't be > 0");
        return false;
    }

    return true;

}

void Sum()
{
    Console.Clear();
    Console.WriteLine("\tSum");
    int n1;
    int n2;
    n1 = GetValidInteger("first member");
    n2 = GetValidInteger("second member");

    operations.Add($"{n1} + {n2} = {n1+n2}");

    Console.WriteLine("Done!");
    Console.ReadLine();

}

void Rest()
{
    Console.Clear();

    Console.WriteLine("\tRest");
    int n1;
    int n2;
    n1 = GetValidInteger("first member");
    n2 = GetValidInteger("second member");

    operations.Add($"{n1} - {n2} = {n1-n2}");
    Console.WriteLine("Done!");
    Console.ReadLine();
}

void Mult()
{
    Console.Clear();

    Console.WriteLine("\tMult");
    int n1;
    int n2;
    n1 = GetValidInteger("first member");
    n2 = GetValidInteger("second member");

    operations.Add($"{n1} * {n2} = {n1*n2}");
    Console.WriteLine("Done!");
    Console.ReadLine();
}

int GetValidInteger(string param)
{
    string aux = "";
    int result;

    while(!int.TryParse(aux, out result))
    {
        Console.Write($"Type {param}: ");
        aux = Console.ReadLine();
    }

    return result;
}


