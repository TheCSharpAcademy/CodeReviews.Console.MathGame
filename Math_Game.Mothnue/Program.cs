/* BEM VINDO AO MEU JOGUINHO SILLY DE MATEMATICA!!!!! BY: MOTHNUE
    
    Se voce quiser entender a logica por tras dos metodos Somar(), Subtrair, etc.. 
    Apenas Leia os comentarios que deixei no metodo Somar(), nao deixei nos outros porque todos eles seguem o mesmo modelo, oque muda seria o operador.
    
    
*/


using System;
using System.Timers;

class Program
{
    //variavel Random para gerar os numeros
    static Random random = new Random();
    static List<string> historyArray = new List<string>();
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Bem vindo ao jogo de matemática. Meu primeiro projeto em C# btw.");
            Menu();
            string userInput = Console.ReadLine().Trim();

            if (userInput == "1")
            {
                Somar();
            }
            else if (userInput == "2")
            {
                Subtrair();
            }
            else if (userInput == "3")
            {
                Multiplicar();
            }
            else if (userInput == "4")
            {
                Dividir();
            } else if (userInput == "9")
            {
                Console.WriteLine("Histórico:");
                foreach (string item in historyArray)
                {
                    Console.WriteLine(item);
                }
            }
            else if (userInput == "0")
            {
                Console.WriteLine("Obrigado por jogar. Até logo!");
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }
    }


    static void Somar()
    {
        int score = 0;

        // Exibe o menu de dificuldade e obtém a escolha do usuário
        MenuDificuldade();
        string input = Console.ReadLine();

        // Obtém a dificuldade com base na escolha do usuário
        int diff = ObterDificuldade(input);

        // Gera 10 perguntas e verifica as respostas do usuário
        for (int i = 0; i < 10; i++)
        {
            // Gera dois números aleatórios dentro da faixa de dificuldade
            int x = random.Next(1, diff);
            int y = random.Next(1, diff);
            int result = x + y;

            // Exibe a pergunta ao usuário
            Console.WriteLine($"{x} + {y} = ?");


            int usr;

            // Loop para garantir que a entrada do usuário seja um número inteiro válido
            while (true)
            {
                Console.Write("Sua resposta: ");
                string userInput = Console.ReadLine();
                historyArray.Add($"{x} + {y} = {result} | Sua resposta: {userInput}");

                // Tenta converter a entrada do usuário para um número inteiro
                if (int.TryParse(userInput, out usr))
                {
                    break; // Sai do loop se a conversão for bem-sucedida
                }
                else
                {
                    Console.WriteLine("Por favor, insira um valor numérico válido.");
                }
            }


            // Verifica se a resposta do usuário está correta e atualiza a pontuação
            if (usr == result)
            {
                score++;
            }
        }

        // Exibe a pontuação final ao usuário
        Console.WriteLine($"Sua pontuação final é {score}");
    }


    static void Subtrair()
    {
        int score = 0;

        MenuDificuldade();
        string input = Console.ReadLine();

        int diff = ObterDificuldade(input);

        for (int i = 0; i < 10; i++)
        {
            int x = random.Next(1, diff);
            int y = random.Next(1, diff);
            int result = x - y;


            Console.WriteLine($"{x} - {y} = ?");


            int usr;
            while (true)
            {
                Console.Write("Sua resposta: ");
                string userInput = Console.ReadLine();
                historyArray.Add($"{x} - {y} = {result}");

                if (int.TryParse(userInput, out usr))
                {
                    break;
                } else
                {
                    Console.WriteLine("Valor incorreto.");
                }
            }


            if (usr == result)
            {
                score++;
            }
        }


        Console.WriteLine($"Your Score is {score}");
    }

    static void Multiplicar()
    {
        int score = 0;


        MenuDificuldade();
        string input = Console.ReadLine();

        int diff = ObterDificuldade(input);


        for (int i = 0; i < 10; i++)
        {
            int x = random.Next(1, diff);
            int y = random.Next(1, diff);
            int result = x * y;


            Console.WriteLine($"{x} x {y} = ?");

            int usr;
            while (true)
            {
                Console.Write("Sua resposta: ");
                string userInput = Console.ReadLine();

                historyArray.Add($"{x} - {y} = {result}");

                if (int.TryParse(userInput, out usr))
                {
                    break;
                } else
                {
                    Console.WriteLine("Valor incorreto.");
                }
            }


            if (usr == result)
            {
                score++;
            }
        }


        Console.WriteLine($"Your Score is {score}");
    }

    static void Dividir()
    {
        int score = 0;


        MenuDificuldade();
        string input = Console.ReadLine();

        int diff = ObterDificuldade(input);


        for (int i = 0; i < 10; i++)
        {
            int x = random.Next(1, diff);
            int y = random.Next(1, diff);
            int result = x / y;


            Console.WriteLine($"{x} / {y} = ?");


            int usr;
            while (true)
            {
                Console.Write("Sua resposta: ");
                string userInput = Console.ReadLine();

                historyArray.Add($"{x} / {y} = {result}");

                if (int.TryParse(userInput, out usr))
                {
                    break;
                } else
                {
                    Console.WriteLine("Valor incorreto.");
                }
            }

            if (usr == result)
            {
                score++;
            }
        }


        Console.WriteLine($"Your Score is {score}");
    }

    static int ObterDificuldade(string input)
    {
        int diff = 0;

        switch (input)
        {
            case "1":
                diff = 10;
                break;
            case "2":
                diff = 20;
                break;
            case "3":
                diff = 30;
                break;
            default:
                Console.WriteLine("Opção de dificuldade inválida. Definindo para Fácil por padrão.");
                diff = 10;
                break;
        }
        return diff;
    }
    static void Menu()
    {
        Console.WriteLine("╔═════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                       Escolha uma opção:                    ║");
        Console.WriteLine("║                                                             ║");
        Console.WriteLine("║   1 - Somar                                                  ║");
        Console.WriteLine("║   2 - Subtrair                                               ║");
        Console.WriteLine("║   3 - Multiplicar                                            ║");
        Console.WriteLine("║   4 - Dividir                                                ║");
        Console.WriteLine("║   9 - Histórico                                              ║");
        Console.WriteLine("║   0 - Sair                                                   ║");
        Console.WriteLine("╚═════════════════════════════════════════════════════════════╝");

    }


    static void MenuDificuldade()
    {
        Console.WriteLine("---------------------------------------------------------------");
        Console.WriteLine("Escolha uma dificuldade para as operações matemáticas:");
        Console.WriteLine("1 - Fácil");
        Console.WriteLine("2 - Médio");
        Console.WriteLine("3 - Difícil");
        Console.WriteLine("---------------------------------------------------------------");
    }

}