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

        public int CompareHands(IHand hand1, IHand hand2)
        {
            throw new NotImplementedException();
        }

        internal List<Func<IHand, bool>> GetHandCheckFunctions()
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
}
