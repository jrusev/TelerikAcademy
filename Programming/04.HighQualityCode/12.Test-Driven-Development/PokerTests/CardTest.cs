using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTests
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void CtorOk()
        {
            var suit = CardSuit.Hearts;
            var face = CardFace.Eight;

            var card = new Card(face, suit);

            Assert.AreEqual(suit, card.Suit);
            Assert.AreEqual(face, card.Face);
        }

        [TestMethod]
        public void ToStringOk()
        {
            var suit = CardSuit.Hearts;
            var face = CardFace.Eight;

            var card = new Card(face, suit);
            var toString = card.ToString();

            Assert.AreEqual(toString, "Eight of Hearts");
        }


    }
}
