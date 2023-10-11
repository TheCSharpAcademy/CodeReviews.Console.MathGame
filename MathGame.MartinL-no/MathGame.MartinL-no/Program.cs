using MathGame.MartinL_no.Services;

namespace MathGame.MartinL_no;

class Program
{
    static void Main(string[] args)
    {
        var dummyGames = Helpers.GetDummyGameResults();
        var service = new MathGameService(dummyGames);
        var application = new MathGameApplication(service);
        application.Execute();
    }
}