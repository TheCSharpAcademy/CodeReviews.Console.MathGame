public class Libary
{
    private Random randNum = new();

    private string[] operadores = {"+", "-", "x", "/"};
    public int Easy()
    {
        int ponto = 0;
        for (int i = 0; i < 5; i++)
        {
            string operador = operadores[randNum.Next(operadores.Length)];
            int num1 = randNum.Next(11);
            int num2 = randNum.Next(11);
            NovasPerguntas(num1,num2,operador);
            int resposta = Convert.ToInt32(Console.ReadLine());
            bool resultado = Resposta(num1,num2,operador,resposta);
            if (resultado)
            {
                ponto++;
            }
        }

        return ponto;
    }

    public int Inter()
    {
        int ponto = 0;
        for (int i = 0; i < 5; i++)
        {
            string operador = operadores[randNum.Next(operadores.Length)];
            int num1 = randNum.Next(51);
            int num2 = randNum.Next(51);
            NovasPerguntas(num1,num2,operador);
            int resposta = Convert.ToInt32(Console.ReadLine());
            bool resultado = Resposta(num1,num2,operador,resposta);
            if (resultado)
            {
                ponto++;
            }
        }

        return ponto;
    }

    public int Dificult()
    {
        int ponto = 0;
        for (int i = 0; i < 5; i++)
        {
            string operador = operadores[randNum.Next(operadores.Length)];
            int num1 = randNum.Next(101);
            int num2 = randNum.Next(101);
            NovasPerguntas(num1,num2,operador);
            int resposta = Convert.ToInt32(Console.ReadLine());
            bool resultado = Resposta(num1,num2,operador,resposta);
            if (resultado)
            {
                ponto++;
            }
        }

        return ponto;
    }

    public void NovasPerguntas(int x, int y, string operador)
    {
        if (operador == "/" && x % y != 0 )
        {
            operador = operadores[randNum.Next(3)];
        }
        Console.WriteLine("Qual é resultado da conta abaixo ?");
        Console.WriteLine($"{x} {operador} {y}");    
    }

    public bool Resposta(int x, int y, string operador, int z)
    {
        switch (operador)
        {
            case "+":
                if ((x + y) == z)
                {
                    return true;
                }
                break;
            case "-":
                if ((x - y) == z)
                {
                    return true;
                }
                break;
            case "/":
                if ((x / y) == z)
                    {
                        return true;
                    }
                    break;
            case "x":
                if ((x * y) == z)
                {
                    return true;
                }
                break;
        }

        return false;
    }
}