using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

using BullsCows.Data;
using BullsCows.WebAPI.Models;
using BullsCows.Models;

namespace BullsCows.WebAPI.Controllers
{
    public class GamesController : BaseApiController
    {
        const int defaultPageSize = 10;
        private readonly Random Rand = new Random();

        public GamesController()
            : base(new BullsCowsData())
        {
        }

        public GamesController(IBullsCowsData data)
            : base(data)
        {
        }

        // GET api/games
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Get(0);
        }

        // GET api/games?page=P
        [HttpGet]
        public IHttpActionResult Get(int page)
        {
            IQueryable<Game> games;
            if (User.Identity.IsAuthenticated)
            {
                var userId = this.User.Identity.GetUserId();
                var publicGames = GetAllSorted();
                games = FilterActiveGames(userId, publicGames);    
            }
            else
            {
                games = GetAllSorted();           
            }

            var models = games
                .Skip(page * defaultPageSize)
                .Take(defaultPageSize)
                .Select(GameShortModel.FromGame);
            return Ok(models);
        }

        // GET api/games/{id}
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetById(int id)
        {
            // The authenticated user must be either blue or red player in the game
            // Returns the game details about a game that is currently played,
            // (i.e. is not available for joining and is not finished)

            var game = this.data.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }

            var userId = this.User.Identity.GetUserId();

            if (game.BlueId != userId && game.RedId != userId)
            {
                return BadRequest("You are not part of this game!");
            }

            if (game.GameState == GameState.Finished || game.GameState == GameState.WaitingForOpponent)
            {
                return BadRequest("This game is not currently played!");
            }

            var gameModel = new GameShortModel(game);
            return Ok(gameModel);
        }

        // POST: api/Games
        // Creates a new game, providing a name of the game and user-number.
        // The authenticated user is automatically marked as red player.
        // { "name": "The Empire strikes back!", "number": "5976" }
        [HttpPost]
        [Authorize]
        public IHttpActionResult Post(CreateGameModel request)
        {
            var userId = this.User.Identity.GetUserId();

            if (request == null || !ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var game = new Game()
            {
                Name = request.Name,
                RedId = userId,
                RedNumber = request.Number,
                GameState = GameState.WaitingForOpponent,
                DateCreated = DateTime.Now
            };

            this.data.Games.Add(game);
            this.data.Users.Find(userId).Games.Add(game);

            this.data.SaveChanges();

            var gameModel = new GameDetailsModel(game, userId);
            return this.CreatedAtRoute("DefaultApi", new { id = gameModel.Id }, gameModel);
        }

        // PUT: api/games/{Id} 
        [HttpPut]
        [Authorize]
        public IHttpActionResult Put(int id, [FromBody] string number)
        {

            var game = this.data.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }

            if (game.GameState != GameState.WaitingForOpponent)
            {
                return BadRequest("This game is not available to join!");
            }

            var userId = this.User.Identity.GetUserId();

            if (game.RedId == userId) // Red is the creator
            {
                return BadRequest("You cannot join your own game!");
            }

            var blueUser = this.data.Users.Find(userId);
            blueUser.Games.Add(game);
            game.BlueNumber = number;
            game.BlueId = userId;

            // The red player (the creator) receives a message that a blue player has joined his game.

            // The first player in turn is decided randomly at the server.
            bool isRedTurn = Rand.Next(2) == 0; // generates either 0 or 1
            game.GameState = isRedTurn ? GameState.RedInTurn : GameState.BlueInTurn;

            // The selected player in turn receives a notification that their turn has come up.            

            this.data.SaveChanges();

            string message = string.Format("You joined game \"{0}\"", game.Name);
            return this.Ok(new
                {
                    result = message
                });
        }

        #region Helpers

        private IQueryable<Game> FilterActiveGames(string userId, IQueryable<Game> sorted)
        {
            // Get games that either:
            //  The authenticated user is part of and are not finished yet
            //  Are available for joining, meaning that a blue player has yet to join the game
            return sorted.Where(
                g => g.BlueId == userId || g.RedId == userId || g.GameState == GameState.WaitingForOpponent);
        }

        private IQueryable<Game> GetAllSorted()
        {
            return this.data.Games.All()
                .Where(g => g.GameState != GameState.Finished)
                .OrderBy(g => g.GameState)
                .ThenBy(g => g.Name)
                .ThenBy(g => g.DateCreated)
                .ThenBy(g => g.Red.Email);
        }

        #endregion
    }
}
