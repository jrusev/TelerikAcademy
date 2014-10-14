using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

using BullsCows.Models;

namespace BullsCows.WebAPI.Models
{
    public class GameDetailsModel
    {
        //{
        //    "Id": 1,
        //    "Name": "Battle of the titans",
        //    "DateCreated": "2014-09-22T10:39:37.087",
        //    "Red": "doncho@minkov.it",
        //    "Blue": "minkov@doncho.it",
        //    "YourNumber": 1234,
        //    "YourGuesses": [
        //        {
        //            "Id": 8,
        //            "UserId": "7e1aaf37-d7c3-42e3-8781-e49bce747206",
        //            "Username": "doncho@minkov.it",
        //            "GameId": 1,
        //            "Number": "1234",
        //            "DateMade": "2014-09-22T14:48:01.16",
        //            "CowsCount": 4,
        //            "BullsCount": 0
        //        },
        //    ],
        //    "OpponentGuesses": [
        //        {
        //            "Id": 9,
        //            "UserId": "12d10b41-fdd4-4d61-8ad5-980af83263d8",
        //            "Username": "dodo@minkov.it",
        //            "GameId": 1,
        //            "Number": "5432",
        //            "DateMade": "2014-09-22T14:48:14.753",
        //            "CowsCount": 2,
        //            "BullsCount": 1
        //        },
        //    ],
        //    "YourColor": "red",
        //    "GameState": "RedInTurn"
        //}

        public GameDetailsModel(Game game, string userId)
        {
            this.Id = game.Id;
            this.Name = game.Name;
            this.Blue = game.Blue.Email;
            this.Red = game.Red.Email;
            this.GameState = game.GameState.ToString();
            this.DateCreated = game.DateCreated;

            this.YourNumber = game.BlueId == userId ? game.BlueNumber : game.RedNumber;
            this.YourColor = game.BlueId == userId ? PlayerColor.Blue.ToString().ToLower() : PlayerColor.Red.ToString().ToLower();
            var regGuesses = game.RedGuesses.Select(guess => new GuessModel
            {
                Id = guess.Id,
                UserId = guess.UserId,
                UserName = guess.User.Email,
                GameId = guess.GameId,
                Number = guess.Number,
                DateMade = guess.DateMade,
                CowsCount = guess.CowsCount,
                BullsCount = guess.BullsCount
            });

            var blueGuesses = game.BlueGuesses.Select(guess => new GuessModel
            {
                Id = guess.Id,
                UserId = guess.UserId,
                UserName = guess.User.Email,
                GameId = guess.GameId,
                Number = guess.Number,
                DateMade = guess.DateMade,
                CowsCount = guess.CowsCount,
                BullsCount = guess.BullsCount
            });

            this.YourGuesses = game.BlueId == userId ? blueGuesses : regGuesses;
            this.OpponentGuesses = game.BlueId == userId ? regGuesses : blueGuesses;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Blue { get; set; }

        public string Red { get; set; }

        public string GameState { get; set; }

        public DateTime DateCreated { get; set; }

        public string YourNumber { get; set; }

        public string YourColor { get; set; }

        public IEnumerable<GuessModel> YourGuesses { get; set; }

        public IEnumerable<GuessModel> OpponentGuesses { get; set; }
    }
}