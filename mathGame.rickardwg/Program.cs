using MathGame.Extensions;
using MathGame.Menus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder();
builder.Services.AddCustomServices();
using var host = builder.Build();

var mainMenu = host.Services.GetRequiredService<IMainMenu>();
mainMenu.Display();