using System;
using System.Collections.Generic;
using System.Linq;
namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        internal const bool ThrowIfInvalidHand = false;

        public bool IsValidHand(IHand hand)
        {
            if (hand == null)
                throw new ArgumentNullException("hand");

            // we want to handle repeating faces or hands with less cards differently
            if (hand.Cards.Distinct().Count() != 5)
            {
                if (ThrowIfInvalidHand)
                    throw new ArgumentException("not a valid poker hand:" + hand);
                return false;
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!IsValidHand(hand))
                return false;

            return hand.AreCardsSameSuit() &&
                   hand.AreCardsConsecutive();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
                return false;

            return hand.IsFaceRepeated(4);
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!IsValidHand(hand))
                return false;

            return hand.IsFaceRepeated(2) &&
                   hand.IsFaceRepeated(3);
        }

        public bool IsFlush(IHand hand)
        {
            if (!IsValidHand(hand))
                return false;

            return hand.AreCardsSameSuit() &&
                  !hand.AreCardsConsecutive();
        }

        public bool IsStraight(IHand hand)
        {
            if (!IsValidHand(hand))
                return false;

            return hand.AreCardsConsecutive() &&
                  !hand.AreCardsSameSuit();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
                return false;

            return hand.IsFaceRepeated(3) &&
                  !hand.IsFaceRepeated(2); ;
        }

        public bool IsTwoPair(IHand hand)
        {
            if (!IsValidHand(hand))
                return false;

            return hand.TimesXOfKind(2) == 2;
        }

        public bool IsOnePair(IHand hand)
        {

            if (!IsValidHand(hand))
                return false;

            return hand.TimesXOfKind(2) == 1 &&
                  !hand.IsFaceRepeated(3);

        }

        public bool IsHighCard(IHand hand)
        {
            if (!IsValidHand(hand))
                return false;

            return !hand.IsFaceRepeated(2) &&
                   !hand.IsFaceRepeated(3) &&
                   !hand.IsFaceRepeated(4) &&
                   !hand.AreCardsSameSuit() &&
                   !hand.AreCardsConsecutive();
        }

        internal List<Func<IHand, bool>> PredicatesList
        {
            get
            {
                return new List<Func<IHand, bool>> 
                { 
                    IsStraightFlush,
                    IsFourOfAKind,
                    IsFullHouse,
                    IsFlush,
                    IsStraight,
                    IsThreeOfAKind,
                    IsTwoPair,
                    IsOnePair,
                    IsHighCard
                };
            }
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            if (firstHand == null)
            {
                if (secondHand == null)
                    return 0;
                return -1;
            }

            if (secondHand == null)
            {
                return 1;
            }

            if (!IsValidHand(firstHand))
            {
                if (!IsValidHand(secondHand))
                    return 0;
                return -1;
            }

            if (!IsValidHand(secondHand))
            {
                return 1;
            }

            foreach (var predicate in this.PredicatesList)
            {
                var isFirst = predicate(firstHand);
                var isSecond = predicate(secondHand);
                if (isFirst && isSecond)
                {
                    if (predicate == this.IsStraightFlush ||
                       predicate == this.IsStraight ||
                        predicate == this.IsFlush ||
                        predicate == this.IsHighCard)
                    {
                        return firstHand.HighestCard().Face.CompareTo(
                               secondHand.HighestCard().Face);
                    }

                    var x = 0;
                    if (predicate == this.IsFourOfAKind)
                        x = 4;

                    if (predicate == this.IsThreeOfAKind)
                        x = 3;

                    if (predicate == this.IsTwoPair ||
                        predicate == this.IsOnePair)
                        x = 2;

                    var seq1 = firstHand.GetXOfKind(x).OrderByDescending(g => g.Key).SelectMany(g => g);
                    var seq2 = secondHand.GetXOfKind(x).OrderByDescending(g => g.Key).SelectMany(g => g);

                    return PokerUtils.CompareSequences(seq1, seq2, c => (int)c.Suit);
                }

                if (isFirst)
                {
                    return 1;
                }

                if (isSecond)
                {
                    return -1;
                }
            }

            throw new ApplicationException("assertion failed");
        }
    }
}
