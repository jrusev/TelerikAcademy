namespace TicTacToe.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using TicTacToe.Data;
    using TicTacToe.Models;
    using System;
    using TicTacToe.Web.DataModels;
    using System.Text;
    using TicTacToe.GameLogic;
    using TicTacToe.Web.Infrastructure;

    [Authorize]
    public class GamesController : BaseApiController
    {
        private IGameResultValidator resultValidator;
        private IUserIdProvider userIdProvider;

        public GamesController(
            ITicTacToeData data,
            IGameResultValidator resultValidator,
            IUserIdProvider userIdProvider)
            : base(data)
        {
            this.resultValidator = resultValidator;
            this.userIdProvider = userIdProvider;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            // new GameInfoDataModel()
            return Ok(this.data.Games.All().Select(GameInfoDataModel.FromGame));
        }

        [HttpPost]
        public IHttpActionResult Create()
        {
            var currentUserId = this.userIdProvider.GetUserId();

            var newGame = new Game
            {
                FirstPlayerId = currentUserId,
            };

            this.data.Games.Add(newGame);
            this.data.SaveChanges();

            return Ok(newGame.Id);
        }

        [HttpPost]
        public IHttpActionResult Join()
        {
            var currentUserId = this.userIdProvider.GetUserId();

            var game = this.data.Games
                .All()
                .Where(g => g.State == GameState.WaitingForSecondPlayer && g.FirstPlayerId != currentUserId)
                .FirstOrDefault();

            if (game == null)
            {
                return NotFound();
            }

            game.SecondPlayerId = currentUserId;
            game.State = GameState.TurnX;
            this.data.SaveChanges();

            return Ok(game.Id);
        }

        [HttpGet]
        public IHttpActionResult Status(string gameId)
        {
            var currentUserId = this.userIdProvider.GetUserId();
            var idAsGuid = new Guid(gameId);

            var game = this.data.Games.All()
                .Where(x => x.Id == idAsGuid)
                .Select(x => new { x.FirstPlayerId, x.SecondPlayerId })
                .FirstOrDefault();
            if (game == null)
            {
                return this.NotFound();
            }

            if (game.FirstPlayerId != currentUserId &&
                game.SecondPlayerId != currentUserId)
            {
                return this.BadRequest("This is not your game!");
            }

            var gameInfo = this.data.Games.All()
                .Where(g => g.Id == idAsGuid)
                .Select(GameInfoDataModel.FromGame)
                .FirstOrDefault();

            return Ok(gameInfo);
        }

        /// <param name="row">1,2 or 3</param>
        /// <param name="col">1,2 or 3</param>
        [HttpPost]
        public IHttpActionResult Play(PlayRequestDataModel request)
        {
            var currentUserId = this.userIdProvider.GetUserId();

            if (request == null || !ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var idAsGuid = new Guid(request.GameId);

            var game = this.data.Games.Find(idAsGuid);
            if (game == null)
            {
                return this.BadRequest("Invalid game id!");
            }

            if (game.FirstPlayerId != currentUserId &&
                game.SecondPlayerId != currentUserId)
            {
                return this.BadRequest("This is not your game!");
            }

            if (game.State != GameState.TurnX &&
                game.State != GameState.TurnO)
            {
                var message = string.Format("The game is not currently playing! Game state is '{0}'", game.State);
                return this.BadRequest(message);
            }

            if ((game.State == GameState.TurnX &&
                game.FirstPlayerId != currentUserId)
                ||
                (game.State == GameState.TurnO &&
                game.SecondPlayerId != currentUserId))
            {
                return this.BadRequest("It's not your turn!");
            }

            var positionIndex = (request.Row - 1) * 3 + request.Col - 1;
            if (game.Board[positionIndex] != '-')
            {
                return this.BadRequest("Invalid position!");
            }

            // Update games state and board
            var boardAsStringBuilder = new StringBuilder(game.Board);
            boardAsStringBuilder[positionIndex] = game.State == GameState.TurnX ? 'X' : 'O';
            game.Board = boardAsStringBuilder.ToString();

            game.State = game.State == GameState.TurnX ? GameState.TurnO : GameState.TurnX;

            var gameResult = resultValidator.GetResult(game.Board);
            switch (gameResult)
            {
                case GameResult.WonByX:
                    game.State = GameState.WonByX;
                    game.FirstPlayer.Wins++;
                    game.SecondPlayer.Losses++;
                    break;
                case GameResult.WonByO:
                    game.State = GameState.WonByO;
                    game.SecondPlayer.Wins++;
                    game.FirstPlayer.Losses++;
                    break;
                case GameResult.Draw:
                    game.State = GameState.Draw;
                    break;
                default:
                    break;
            }

            this.data.SaveChanges();

            return this.Ok(new GameInfoDataModel(game));
        }
    }
}