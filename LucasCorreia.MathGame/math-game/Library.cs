public class Library
{
    private Random randNum = new();
    private string[] operadores = { "+", "-", "x", "/" };
    
    public int Jogar(string operador, int maxNum1, int maxNum2)
    {
        int ponto = 0;
        for (int i = 0; i < 5; i++)
        {
            int num1 = 0;
            int num2 = 0;

            string opAtual = operador == "aleatorio" ? operadores[randNum.Next(operadores.Length)] : operador;

            if (opAtual == "/")
            {
                num2 = randNum.Next(1, maxNum2 + 1);
                int multiplicador = randNum.Next(0, maxNum1 + 1);
                num1 = num2 * multiplicador;
            }

            NovasPerguntas(num1, num2, opAtual);

            if (int.TryParse(Console.ReadLine(), out int resposta))
            {
                if (Resposta(num1, num2, opAtual, resposta))
                {
                    ponto++;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Por favor, digite apenas números!\n");
                i--;
            }
        }
        return ponto;
    }

    public void NovasPerguntas(int x, int y, string operador)
    {
        Console.WriteLine("Qual é resultado da conta abaixo ?");
        Console.WriteLine($"{x} {operador} {y}");
    }

    public bool Resposta(int x, int y, string operador, int z)
    {
       return operador switch
       {
           "+" => (x + y) == z,
           "-" => (x - y) == z,
           "/" => (x / y) == z,
           "x" => (x * y) == z,
           _ => false
       };
    }

    public string EscolhaOperador()
    {
        int op = 0;
        bool entradaValida = false;
        
        while(!entradaValida)
        {
            Console.WriteLine("Escolha a operação que quer fazer:");
            Console.WriteLine("1- Somar\n2- Subtrair\n3- Multiplicar\n4- Dividir\n5- Aleatório");

            if (int.TryParse(Console.ReadLine(), out op) && op >= 1 && op <= 5)
            {
                entradaValida = true;
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Opção inválida! Por favor, digite um número de 1 a 5.\n");
                Console.ResetColor();
            }
        }
       
        
        return op switch
        {
            1 => "+",
            2 => "-",
            3 => "x",
            4 => "/",
            5 => "aleatorio",
            _ => throw new ArgumentException("Número escolhido errado!")
        };
    }
}
