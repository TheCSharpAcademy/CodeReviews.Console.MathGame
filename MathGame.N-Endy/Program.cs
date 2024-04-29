using MathGame.N_Endy.GameCore;
using MathGame.N_Endy.GameEntities;
using MathGame.N_Endy.Services;
using MathGame.N_Endy.GameUserInteraction;

IPlayerService playerService = new PlayerService(new Player());
IQuestionService questionService = new QuestionService(new Question());
GameService gameService = new GameService(playerService, new UserInteraction(), questionService);

gameService.StartGame();