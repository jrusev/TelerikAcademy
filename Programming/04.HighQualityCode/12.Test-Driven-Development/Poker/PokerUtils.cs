using System;
using System.Linq;
using System.Collections.Generic;
namespace Poker
{
    internal static class PokerUtils
    {
        static internal CardFace ReadFace(char ch)
        {
            switch (ch)
            {
                case '2':
                    return CardFace.Two;
                case '3':
                    return CardFace.Three;
                case '4':
                    return CardFace.Four;
                case '5':
                    return CardFace.Five;
                case '6':
                    return CardFace.Six;
                case '7':
                    return CardFace.Seven;
                case '8':
                    return CardFace.Eight;
                case '9':
                    return CardFace.Nine;
                case '0':
                    return CardFace.Ten;
                case 'J':
                    return CardFace.Jack;
                case 'Q':
                    return CardFace.Queen;
                case 'K':
                    return CardFace.King;
                case 'A':
                    return CardFace.Ace;
                default:
                    throw new ArgumentException("ch = " + ch);
            }
        }

        static internal CardSuit ReadSuit(char ch)
        {

            switch (ch)
            {
                case 'C':
                case '♣':
                    return CardSuit.Clubs;
                case 'D':
                case '♦':
                    return CardSuit.Diamonds;
                case 'H':
                case '♥':
                    return CardSuit.Hearts;
                case 'S':
                case '♠':
                    return CardSuit.Spades;
                default:
                    throw new ArgumentException("ch = " + ch);
            }
        }

        static internal Card ReadCard(string str)
        {
            return new Card(ReadFace(str[0]), ReadSuit(str[1]));
        }

        static internal Hand ReadHand(string str)
        {
            return new Hand(str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(s => (ICard)ReadCard(s)).ToList());
        }



        static public CardFace? GetNextHigherFace(this CardFace face)
        {
            if (face == CardFace.Ace)
                return null;

            var asInt = (int)face;
            return (CardFace)(face + 1);
        }

        static public CardFace? GetNextLowerFace(this CardFace face)
        {
            if (face == CardFace.Two)
                return null;

            var asInt = (int)face;
            return (CardFace)(face + 1);
        }

        public static IEnumerable<ICard> CardsAscending(this IHand hand)
        {

            return hand.Cards.OrderBy(c => c.Face);

        }

        public static ICard HighestCard(this IHand hand)
        {


            return hand.Cards.Max();

        }

        public static ICard LowestCard(this IHand hand)
        {


            return hand.Cards.Max();

        }

        public static IEnumerable<IGrouping<CardFace, ICard>> CardsByFace(this IHand hand)
        {

            return hand.Cards.GroupBy(c => c.Face);

        }

        public static bool HasXOfKind(this IHand hand, int x)
        {
            return hand.CardsByFace().Any(g => g.Count() == x);
        }

        public static int TimesXOfKind(this IHand hand, int x)
        {
            return hand.CardsByFace().Where(g => g.Count() == x).Count();
        }

        public static IEnumerable<IGrouping<CardFace, ICard>>
        GetXOfKind(this IHand hand, int x)
        {
            return hand.CardsByFace().Where(g => g.Count() == x);
        }


        public static bool AreCardsConsecutive(this IHand hand)
        {
            ICard card1 = null;
            foreach (var card2 in hand.CardsAscending())
            {

                if (card1 != null &&
                    card1.Face.GetNextHigherFace() != card2.Face)
                {
                    return false;
                }
                card1 = card2;
            }
            return true;
        }

        public static bool AreCardsSameSuit(this IHand hand)
        {
            return hand.Cards.GroupBy(c => c.Suit).Count() == 1;
        }

        public static int CompareFace(this ICard card1, ICard card2)
        {
            // By definition, any object compares greater than (or follows) null, and two null references compare equal to each other.

            if (card1 == null)
            {
                if (card2 == null)
                    return 0;

                return -1;
            }
            if (card2 == null)
                return 1;

            return card1.Face.CompareTo(
                   card2.Face);

        }



    }

}