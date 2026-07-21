using MathGame.DataSource;
using MathGame.Menus;
using MathGame.Repositories;
using MathGame.Services;
using MathGame.Views;
using Microsoft.Extensions.DependencyInjection;

namespace MathGame.Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddTransient<IMainMenu, MainMenu>();
        services.AddTransient<IGameMenu, GameMenu>();
        services.AddTransient<IGameView, GameView>();
        services.AddTransient<IGameHistoryView, GameHistoryView>();

        services.AddTransient<IGameService, GameService>();
        services.AddTransient<IQuestionService, QuestionService>();

        services.AddTransient<IHistoryRepository, HistoryRepository>();
        services.AddSingleton<IGameHistoryData, GameHistoryData>();

        return services;
    }
}
