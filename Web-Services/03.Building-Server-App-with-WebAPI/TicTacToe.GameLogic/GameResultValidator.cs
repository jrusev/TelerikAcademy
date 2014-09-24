namespace TicTacToe.GameLogic
{
    using System;
    using System.Linq;

    public class GameResultValidator : IGameResultValidator
    {
        private const string ValidCharacters = "XO-";

        public GameResult GetResult(string board)
        {
            if (board.Length != 9)
            {
                throw new InvalidOperationException("Board contains invalid number of characters!");
            }

            if (!board.All(c => ValidCharacters.Contains(c)))
            {
                throw new InvalidOperationException("Board contains invalid characters!");
            }

            int countX = board.Count(c => c == 'X');
            int countO = board.Count(c => c == 'O');

            if (Math.Abs(countX - countO) > 1)
            {
                throw new InvalidOperationException("Invalid board state - one player has made invalid number of turns!");
            }

            var winner = GetWinner(board);

            switch (winner)
            {
                case 'X': return GameResult.WonByX;
                case 'O': return GameResult.WonByO;
                default:
                    if (!board.Contains('-')) return GameResult.Draw;
                    else return GameResult.NotFinished;
            }
        }

        private char GetWinner(string board)
        {
            var wins = new[] { "012", "345", "678", "036", "147", "258", "048", "246" };

            foreach (var win in wins)
            {
                var w = win.ToCharArray().Select(c => c - '0').ToArray();
                var b = board[w[0]];
                if ("XO".Contains(b) && w.All(i => board[i] == b))
                {
                    return b;
                }
            }

            return ' ';
        }
    }
}
