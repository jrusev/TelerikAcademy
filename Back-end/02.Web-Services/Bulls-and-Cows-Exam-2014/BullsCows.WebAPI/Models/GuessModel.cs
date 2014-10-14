using System;

using BullsCows.Models;
using System.Linq.Expressions;

namespace BullsCows.WebAPI.Models
{
    public class GuessModel
    {
        public static Expression<Func<Guess, GuessModel>> FromGuess
        {
            get
            {
                return guess => new GuessModel
                {
                    Id = guess.Id,
                    UserId = guess.UserId,
                    UserName = guess.User.Email,
                    GameId = guess.GameId,
                    Number = guess.Number,
                    DateMade = guess.DateMade,
                    CowsCount = guess.CowsCount,
                    BullsCount = guess.BullsCount
                };
            }
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public int GameId { get; set; }

        public string Number { get; set; }

        public DateTime DateMade { get; set; }

        public int CowsCount { get; set; }

        public int BullsCount { get; set; }
    }
}