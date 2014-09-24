using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.GameLogic;

namespace TicTacToe.Tests
{
    [TestClass]
    public class GameResultValidatorTests
    {
        private readonly GameResultValidator validator = new GameResultValidator();

        [TestMethod]
        public void EmptyBoard_ShouldReturnNotFinished()
        {
            string board = GetBoard(new[]
            {
                "---",
                "---",
                "---",
            });

            var result = validator.GetResult(board);

            Assert.AreEqual(GameResult.NotFinished, result);
        }

        [TestMethod]
        public void NoWinner_ShouldReturnDraw()
        {
            string board = GetBoard(new[]
            {
                "XXO",
                "OOX",
                "XOX",
            });

            var result = validator.GetResult(board);

            Assert.AreEqual(GameResult.Draw, result);
        }

        [TestMethod]
        public void WinByX_ShouldReturnWonByX()
        {
            string board = GetBoard(new[]
            {
                "XO-",
                "OX-",
                "--X",
            });

            var result = validator.GetResult(board);

            Assert.AreEqual(GameResult.WonByX, result);
        }

        [TestMethod]
        public void WinByXFullBoard_ShouldReturnWonByX()
        {
            string board = GetBoard(new[]
            {
                "XOO",
                "OOX",
                "XXX",
            });

            var result = validator.GetResult(board);

            Assert.AreEqual(GameResult.WonByX, result);
        }

        #region Exceptions

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvalidBoardLength_ShouldThrowExeption()
        {
            var result = validator.GetResult("-");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void OtherSymbols_ShouldThrowExeption()
        {
            string board = GetBoard(new[]
            {
                "---",
                "-*-",
                "---",
            });

            var result = validator.GetResult(board);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MoreOThanX_ShouldThrowExeption()
        {
            // The board doesn't care whose turn is it!
            string board = GetBoard(new[]
            {
                "XOX",
                "OX-",
                "-X-",
            });

            var result = validator.GetResult(board);
        }

        #endregion

        private string GetBoard(string[] matrix)
        {
            var board = "";
            foreach (var item in matrix)
            {
                board += item;
            }

            return board;
        }
    }
}
