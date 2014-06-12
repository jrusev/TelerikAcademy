using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != 5)
                return false;

            // duplicate cards?
            if (hand.Cards.Duplicates().Count() != 0)
                return false;

            return true;
        }

        // notes:
        // * if the hand contains any cards of the same face,
        // the cards can't be of the same suit
        // * if the cards are of the same suit, the hand
        // can't contain same face
        // * the methods don't check IsValidHand()

        bool EnsureValidHand(IHand hand, bool throwArgumentException)
        {
            if (!IsValidHand(hand))
            {
                if (throwArgumentException)
                    throw new ArgumentException("not a valid poker hand:" + hand);
                return false;
            }
            return true;
        }

        internal const bool THROW_ARG_EX = false;

        public bool IsStraightFlush(IHand hand)
        {
            if (!EnsureValidHand(hand, THROW_ARG_EX))
                return false;

            return hand.AreCardsSameSuit() &&
                   hand.AreCardsConsecutive();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!EnsureValidHand(hand, THROW_ARG_EX))
                return false;

            return hand.HasXOfKind(4);
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!EnsureValidHand(hand, THROW_ARG_EX))
                return false;

            return hand.HasXOfKind(2) &&
                   hand.HasXOfKind(3);

        }

        public bool IsFlush(IHand hand)
        {
            if (!EnsureValidHand(hand, THROW_ARG_EX))
                return false;

            return hand.AreCardsSameSuit() &&
                  !hand.AreCardsConsecutive();
        }

        public bool IsStraight(IHand hand)
        {
            if (!EnsureValidHand(hand, THROW_ARG_EX))
                return false;

            return hand.AreCardsConsecutive() &&
                  !hand.AreCardsSameSuit();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!EnsureValidHand(hand, THROW_ARG_EX))
                return false;
            // can't be 2x2, 3, 4, same suit, or consecutive

            return hand.HasXOfKind(3) &&
                  !hand.HasXOfKind(2); ;
        }

        public bool IsTwoPair(IHand hand)
        {
            if (!EnsureValidHand(hand, THROW_ARG_EX))
                return false;
            // can't be 3, 4, same suit, or consecutive

            return hand.TimesXOfKind(2) == 2;
        }

        public bool IsOnePair(IHand hand)
        {

            if (!EnsureValidHand(hand, THROW_ARG_EX))
                return false;
            // can't be 4, same suit, or consecutive

            return hand.TimesXOfKind(2) == 1 &&
                  !hand.HasXOfKind(3);

        }

        public bool IsHighCard(IHand hand)
        {
            if (!EnsureValidHand(hand, THROW_ARG_EX))
                return false;

            return !hand.HasXOfKind(2) &&
                   !hand.HasXOfKind(3) &&
                   !hand.HasXOfKind(4) &&
                   !hand.AreCardsSameSuit() &&
                   !hand.AreCardsConsecutive();

        }

        internal List<Func<IHand, bool>>
            PredicatesList
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
            // "null is smaller than a non-null object by definition"
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

            // we could also map each hand type to an integer
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
        
                        // x of kind
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

                    return Utils.CompareSequences(seq1, seq2, c => (int)c.Suit);
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
