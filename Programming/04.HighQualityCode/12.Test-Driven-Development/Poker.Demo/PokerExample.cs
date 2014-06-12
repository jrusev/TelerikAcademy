using System;
using System.Collections.Generic;
using System.Linq;
namespace Poker
{
    class PokerExample
    {
        static void Main()
        {
            ICard card = new Card(CardFace.Ace, CardSuit.Clubs);
            Console.WriteLine(card);

            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });
            Console.WriteLine(hand);

            IPokerHandsChecker checker = new PokerHandsChecker();
            Console.WriteLine(checker.IsValidHand(hand));
            Console.WriteLine(checker.IsOnePair(hand));
            Console.WriteLine(checker.IsTwoPair(hand));

            var card1 = new Card(CardFace.Jack, CardSuit.Clubs);
            var card2 = new Card(CardFace.Nine, CardSuit.Diamonds);
            var card3 = new Card(CardFace.Four, CardSuit.Spades);
            var card4 = new Card(CardFace.Two, CardSuit.Hearts);
            var card5 = new Card(CardFace.Queen, CardSuit.Hearts);

            var hand2 = new Hand(new List<ICard> { card1, card2, card3, card4, card5 });
            Console.WriteLine(hand2);
        }
    }
}
