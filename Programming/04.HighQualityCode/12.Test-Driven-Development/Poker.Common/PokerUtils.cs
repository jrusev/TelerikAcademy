namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class PokerUtils
    {
        public static CardFace? GetNextHigherFace(this CardFace face)
        {
            if (face == CardFace.Ace)
            {
                return null;
            }

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

        public static IEnumerable<IGrouping<CardFace, ICard>> CardsByFace(this IHand hand)
        {
            return hand.Cards.GroupBy(c => c.Face);
        }

        public static bool IsFaceRepeated(this IHand hand, int times)
        {
            return hand.CardsByFace().Any(g => g.Count() == times);
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

        //public static int CompareFace(this ICard card1, ICard card2)
        //{
        //    if (card1 == null)
        //    {
        //        if (card2 == null)
        //        {
        //            // Two null references compare equal to each other.
        //            return 0;
        //        }

        //        return -1;
        //    }

        //    if (card2 == null)
        //    {
        //        return 1;
        //    }

        //    return card1.Face.CompareTo(card2.Face);
        //}

        internal static CardFace ReadFace(char ch)
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

        internal static CardSuit ReadSuit(char ch)
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

        internal static Card ReadCard(string str)
        {
            return new Card(ReadFace(str[0]), ReadSuit(str[1]));
        }

        internal static Hand ReadHand(string str)
        {
            return new Hand(
                str.Split(
                new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries).Select(s => (ICard)ReadCard(s)).ToList());
        }

        internal static int CompareSequences<T>(IEnumerable<T> seq1, IEnumerable<T> seq2, Func<T, int> f)
        {
            var en1 = seq1.GetEnumerator();
            var en2 = seq2.GetEnumerator();
            while (en1.MoveNext() && en2.MoveNext())
            {
                var cmp = f(en1.Current).CompareTo(f(en2.Current));
                if (cmp != 0)
                {
                    return cmp;
                }
            }

            return 0;
        }
    }
}