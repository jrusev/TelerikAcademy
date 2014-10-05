namespace TicTacToe.Web.DataModels
{
    using System;
    using System.Linq.Expressions;
    using TicTacToe.Models;

    public class GameInfoDataModel
    {
        public GameInfoDataModel(Game game)
        {
            this.Id = game.Id;
            this.Board = game.Board;
            this.FirstPlayerName = game.FirstPlayer != null ? game.FirstPlayer.Email : "";
            this.SecondPlayerName = game.SecondPlayer != null ? game.SecondPlayer.Email : "";
            this.State = game.State.ToString();
        }

        public GameInfoDataModel()
        { 
        }

        public static Expression<Func<Game, GameInfoDataModel>> FromGame
        {
            get
            {
                return game => new GameInfoDataModel()
                {
                    Id = game.Id,
                    Board = game.Board,
                    FirstPlayerName = game.FirstPlayer.Email,
                    SecondPlayerName = game.SecondPlayer.Email,
                    State = game.State.ToString()
                };
            }
        }

        public Guid Id { get; set; }

        public string Board { get; set; }

        public string FirstPlayerName { get; set; }

        public string SecondPlayerName { get; set; }

        public string State { get; set; }
    }
}