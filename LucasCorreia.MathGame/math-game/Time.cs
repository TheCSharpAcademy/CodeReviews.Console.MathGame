using System.Diagnostics;

public class Time
{
    public static double MedirTempo(Action acao)
    {
        Stopwatch tempo = Stopwatch.StartNew();

        acao();

        tempo.Stop();

        return tempo.Elapsed.TotalSeconds;
    }
}