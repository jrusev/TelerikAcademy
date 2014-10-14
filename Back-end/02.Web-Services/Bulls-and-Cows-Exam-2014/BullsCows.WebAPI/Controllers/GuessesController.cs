using System;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;

using BullsCows.Models;
using BullsCows.Data;

namespace BullsCows.WebAPI.Controllers
{
    public class GuessesController : BaseApiController
    {

        public GuessesController()
            : base(new BullsCowsData())
        {
        }

        public GuessesController(IBullsCowsData data)
            : base(data)
        {
        }

        // POST: api/Guesses
        // api/games/{id}/guess 
        // Makes a guess for a game with the provided ID
        [HttpPost]
        [Authorize]
        public IHttpActionResult Post(int id, [FromBody] string number)
        {
            var game = this.data.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }

            if (game.GameState != GameState.RedInTurn && game.GameState != GameState.BlueInTurn)
            {
                return BadRequest("This game is not in playing mode!");
            }

            var userId = this.User.Identity.GetUserId();
            var user = this.data.Users.Find(userId);

            if (user.Games.FirstOrDefault(g => g.Id == id) == null)
            {
                return BadRequest("This is not your game!");
            }

            if (game.GameState == GameState.RedInTurn && game.RedId != userId)
            {
                return BadRequest("Not your turn!");
            }

            if (game.GameState == GameState.BlueInTurn && game.BlueId != userId)
            {
                return BadRequest("Not your turn!");
            }

            var guessNumber = (game.RedId == userId) ? game.BlueNumber : game.RedNumber;

            Result result;
            try
            {
                result = ProcessGuess(number, guessNumber);
            }
            catch (Exception)
            {                
                return BadRequest("Not a valid guess!");
            }

            int bulls = result.BullsCount;
            int cows = result.CowsCount;

            if (result.BullsCount == 4)
            {
                // Number was guessed
                game.GameState = GameState.Finished;
                
                ApplicationUser winner = user;
                ApplicationUser loser = (winner.Id == game.BlueId) ? game.Red : game.Blue;

                // Both players are applied the score of the game
                winner.Wins++;
                loser.Losses++;
                winner.Rank = CalcRank(winner);
                loser.Rank = CalcRank(loser);

                // ...and they both receive a notification:
                var winNotification = new Notification()
                {
                    Message = string.Format("You beat {0} in game \"{1}\"", loser.Email, game.Name),
                    DateCreated = DateTime.Now,
                    Type = NotificationType.GameWon,
                    State = NotificationState.Unread,
                    GameId = game.Id,
                    UserId = winner.Id
                };

                var loseNotification = new Notification()
                {
                    Message = string.Format("{0} beat you in game \"{1}\"", winner.Email, game.Name),
                    DateCreated = DateTime.Now,
                    Type = NotificationType.GameLost,
                    State = NotificationState.Unread,
                    GameId = game.Id,
                    UserId = loser.Id
                };

                this.data.Notifications.Add(winNotification);
                this.data.Notifications.Add(loseNotification);
            }
            else
            {
                // The turn is switched to the other player and s/he receives a notification
                game.GameState = game.GameState == GameState.RedInTurn ? GameState.BlueInTurn : GameState.RedInTurn;

                var notification = new Notification()
                {
                    Message = string.Format("It is your turn in game \"{0}\"", game.Name),
                    DateCreated = DateTime.Now,
                    Type = NotificationType.YourTurn,
                    State = NotificationState.Unread,
                    GameId = game.Id,
                    UserId = (game.GameState == GameState.RedInTurn) ? game.RedId : game.BlueId
                };

                this.data.Notifications.Add(notification);
            }

            var guess = new Guess()
            {
                UserId = userId,
                UserName = user.Email,
                GameId = id,
                Number = number,
                DateMade = DateTime.Now,
                CowsCount = cows,
                BullsCount = bulls
            };

            this.data.Guesses.Add(guess);
            this.data.SaveChanges();

            return Ok(guess);
        }

        private static int CalcRank(ApplicationUser user)
        {
            // USER_RANK = 100 * USER_WINS_COUNT + 15 * USER_LOSSES_COUNT
            return 100 * user.Wins + 15 * user.Losses;
        }

        public Result ProcessGuess(string guess, string numberToGuess)
        {
            int[] num = numberToGuess.Split().Select(n => Convert.ToInt32(n)).ToArray();
            char[] guessed = guess.ToCharArray();
            int bullsCount = 0, cowsCount = 0;

            if (guessed.Length != 4)
            {
                throw new InvalidOperationException();
            }

            for (int i = 0; i < 4; i++)
            {
                int curguess = (int)char.GetNumericValue(guessed[i]);
                if (curguess < 1 || curguess > 9)
                {
                    throw new InvalidOperationException();
                }
                if (curguess == num[i])
                {
                    bullsCount++;
                }
                else
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (curguess == num[j])
                            cowsCount++;
                    }
                }
            }

            return new Result() { BullsCount = bullsCount, CowsCount = cowsCount };
        }

        public struct Result { public int BullsCount, CowsCount; }

    }
}
