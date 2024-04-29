using MathGame.N_Endy.GameCore;
using MathGame.N_Endy.GameEntities;
using MathGame.N_Endy.Services;
using MathGame.N_Endy.GameUserInteraction;
using MathGame.N_Endy.GameRepository;

IPlayerService playerService = new PlayerService(new Player());
IQuestionService questionService = new QuestionService(new Question());
IUserInteraction userInteraction = new UserInteraction();
IPreviousGame previousGame = new PreviousGame();
GameService gameService = new GameService(playerService, userInteraction, questionService, previousGame);

gameService.StartGame();