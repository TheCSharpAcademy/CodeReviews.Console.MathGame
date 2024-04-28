using MathGame.N_Endy.GameCore;
using MathGame.N_Endy.GameEntities;
using MathGame.N_Endy.Services;
using MathGame.N_Endy.GameUserInteraction;

IPlayerService playerService = new PlayerService(new Player());
GameService gameService = new GameService(playerService, new UserInteraction());

gameService.StartGame();