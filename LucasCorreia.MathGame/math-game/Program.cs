using System.Diagnostics;

public class Program
{
    public static void Main()
    {
        int op = 0;
        int pontos = 0;
        Libary lb = new();
        double tempo_jogo = 0;
        List<int> rodadas = [];
        List<double> tempo_rodadas = [];
        do
        {
            Console.WriteLine("===============================\nBem vindo ao Jogo Matématico.\n===============================");
            Console.WriteLine("\nEscolha uma opção abaixo:");
            Console.WriteLine("1- Jogo fácil\n2- Jogo intermédiario\n3- Jogo Difícil\n4- Listar Pontuações\n0- Sair do jogo");
            op = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (op)
            {
                case 1:
                    tempo_jogo = Time.MedirTempo(() => pontos = lb.Easy());
                    rodadas.Add(pontos);
                    tempo_rodadas.Add(tempo_jogo);
                    break;
                case 2:
                    pontos = lb.Inter();
                    rodadas.Add(pontos);
                    break;
                case 3:
                    pontos = lb.Dificult();
                    rodadas.Add(pontos);
                    break; 
                case 4:
                    Console.WriteLine("=====================\n=PONTUAÇÃO DOS JOGOS=\n=====================");
                    for (int i = 0; i < rodadas.Count; i++)
                    {
                        Console.WriteLine($"Rodada {i + 1}° -> {rodadas[i]} pontos | Tempo -> {(int)tempo_rodadas[i]} segundos");
                    }
                    Console.ReadLine();
                    Console.WriteLine();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }while(op != 0);
        
    }
}