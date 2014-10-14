using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

using BullsCows.Models;

namespace BullsCows.WebAPI.Models
{
    public class GameShortModel
    {
        //  {
        //      "Id": 6,
        //      "Name": "The Empire strikes back!",
        //      "Blue": "No blue player yet",
        //      "Red": "dodo@minkov.it",
        //      "GameState": "WaitingForOpponent",
        //      "DateCreated": "2014-09-23T06:41:51.5816277+03:00"
        //  } 

        public GameShortModel()
        {
        }

        public GameShortModel(Game game)
        {
            this.Id = game.Id;
            this.Name = game.Name;
            this.Blue = (game.GameState == BullsCows.Models.GameState.WaitingForOpponent) ? "No blue player yet" : game.Blue.Email;
            this.Red = game.Red.Email;
            this.GameState = game.GameState.ToString();
            this.DateCreated = game.DateCreated;
        }

        public static Expression<Func<Game, GameShortModel>> FromGame
        {
            get
            {
                return game => new GameShortModel
                {
                    Id = game.Id,
                    Name = game.Name,
                    Blue = (game.GameState == BullsCows.Models.GameState.WaitingForOpponent) ? "No blue player yet" : game.Blue.Email,
                    Red = game.Red.Email,
                    GameState = game.GameState.ToString(),
                    DateCreated = game.DateCreated
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Blue { get; set; }

        public string Red { get; set; }

        public string GameState { get; set; }

        public DateTime DateCreated { get; set; }
    }
}