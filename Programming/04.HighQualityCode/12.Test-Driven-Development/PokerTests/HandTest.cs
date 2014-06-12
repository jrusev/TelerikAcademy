using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;
namespace PokerTests
{
    [TestClass]
    public class HandTest
    {
        [TestMethod]
        public void CtorOk()
        {
            var card1 = new Card(CardFace.Jack, CardSuit.Clubs);
            var card2 = new Card(CardFace.Nine, CardSuit.Diamonds);
            var card3 = new Card(CardFace.Four, CardSuit.Spades);
            var card4 = new Card(CardFace.Two, CardSuit.Hearts);
            var card5 = new Card(CardFace.Queen, CardSuit.Hearts);

            var hand = new Hand(new List<ICard> { card1, card2, card3, card4, card5 });

            Assert.AreEqual(card1, hand.Cards[1 - 1]);
            Assert.AreEqual(card2, hand.Cards[2 - 1]);
            Assert.AreEqual(card3, hand.Cards[3 - 1]);
            Assert.AreEqual(card4, hand.Cards[4 - 1]);
            Assert.AreEqual(card5, hand.Cards[5 - 1]);

        }

        [TestMethod]
        public void ToStringOk()
        {
            var card1 = new Card(CardFace.Jack, CardSuit.Clubs);
            var card2 = new Card(CardFace.Nine, CardSuit.Diamonds);
            var card3 = new Card(CardFace.Four, CardSuit.Spades);
            var card4 = new Card(CardFace.Two, CardSuit.Hearts);
            var card5 = new Card(CardFace.Queen, CardSuit.Hearts);

            var hand = new Hand(new List<ICard> { card1, card2, card3, card4, card5 });

            var toString = hand.ToString();

            Assert.AreEqual(toString, @"Jack of Clubs, Nine of Diamonds, Four of Spades, Two of Hearts, Queen of Hearts");
        }
    }
}