using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTests
{
    [TestClass]
    public class PokerHandsCheckerTest
    {
        readonly PokerHandsChecker checker = new PokerHandsChecker();

        [TestMethod]
        public void IsValidHandHandlesEmpty()
        {
            var hand = PokerUtils.ReadHand("");
            var result = checker.IsValidHand(hand);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidHandHandlesLessThanFive()
        {
            var hand = PokerUtils.ReadHand("A♠");
            var result = checker.IsValidHand(hand);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidHandHandlesMoreThanFive()
        {
            var hand = PokerUtils.ReadHand("A♠ Q♥ 0♣ J♦ K♥ 2♠");
            var result = checker.IsValidHand(hand);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidHandHandlesDuplicates1()
        {
            var hand = PokerUtils.ReadHand("A♠ A♠ 0♣ J♦ K♥ 2♠");
            var result = checker.IsValidHand(hand);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidHandHandlesDuplicates2()
        {
            var hand = PokerUtils.ReadHand("A♠ A♠");
            var result = checker.IsValidHand(hand);
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsValidHandWithNull()
        {
            var result = checker.IsValidHand(null);
        }

        [TestMethod]
        public void IsValidHandOK1()
        {
            var hand = PokerUtils.ReadHand("A♠ Q♥ 0♣ J♦ K♥");
            var result = checker.IsValidHand(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidHandOK2()
        {
            var hand = PokerUtils.ReadHand("A♠ 2♥ 3♣ 4♦ 5♥");
            var result = checker.IsValidHand(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidHandOK3()
        {
            var hand = PokerUtils.ReadHand("2♠ 2♥ 2♣ 2♦ 5♥");
            var result = checker.IsValidHand(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsStraightFlushOk()
        {
            var hand = PokerUtils.ReadHand("2♠ 3♠ 4♠ 5♠ 6♠");
            var result = checker.IsStraightFlush(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsFourOfAKindOk()
        {
            var hand = PokerUtils.ReadHand("2♠ 2♥ 2♣ 2♦ 6♥");
            var result = checker.IsFourOfAKind(hand);
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void IsFullHouseOk()
        {
            var hand = PokerUtils.ReadHand("2♠ 2♥ 2♣ 3♦ 3♥");
            var result = checker.IsFullHouse(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsStraightOk()
        {
            var hand = PokerUtils.ReadHand("2♠ 3♥ 4♣ 5♦ 6♥");
            var result = checker.IsStraight(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsFlushOk()
        {
            var hand = PokerUtils.ReadHand("2♠ 5♠ 7♠ 9♠ J♠");
            var result = checker.IsFlush(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsThreeOfAKindOk()
        {
            var hand = PokerUtils.ReadHand("2♠ 2♥ 2♣ 3♦ 6♥");
            var result = checker.IsThreeOfAKind(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTwoPairsOk()
        {
            var hand = PokerUtils.ReadHand("2♠ 2♥ 3♣ 3♦ 6♥");
            var result = checker.IsTwoPair(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsOnePairOk()
        {
            var hand = PokerUtils.ReadHand("2♠ 2♥ 3♣ 4♦ 6♥");
            var result = checker.IsOnePair(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsHighCardOk()
        {
            var hand = PokerUtils.ReadHand("A♠ 2♥ 3♣ 9♦ Q♥");
            var result = checker.IsHighCard(hand);
            Assert.IsTrue(result);
        }

        // This test ensures that the hand checker will return true only for one type of hand category,
        // i.e. a hand can be of only one type, for example it cannot be a pair and full house.
        // The test ensures that each method works correctly, without testing each one individually for exclusivity.
        [TestMethod]
        public void HandTypesAreMutuallyExclusive()
        {
            var handTypeChecks = checker.GetHandCheckFunctions();
            handTypeChecks.Add(h => !checker.IsValidHand(h));
            var hands = new[] { "A♠ 2♥ 3♣ 9♦ Q♥", "2♠ 2♥ 3♣ 4♦ 6♥", "2♠ 2♥ 3♣ 3♦ 6♥", "2♠ 2♥ 2♣ 3♦ 6♥", "2♠ 5♠ 7♠ 9♠ J♠", "2♠ 3♥ 4♣ 5♦ 6♥", "2♠ 2♥ 2♣ 3♦ 3♥", "2♠ 2♥ 2♣ 2♦ 6♥", "2♠ 3♠ 4♠ 5♠ 6♠", "2♠ 2♥ 2♣ 2♦ 5♥", "A♠ 2♥ 3♣ 4♦ 5♥", "A♠ Q♥ 0♣ J♦ K♥", "A♠ A♠", "A♠ A♠ 0♣ J♦ K♥ 2♠", "" };

            bool result = true;
            foreach (var hand in hands.Select(h => PokerUtils.ReadHand(h)))
            {
                // How many conditions are true for this hand
                var countTrue = handTypeChecks.Select(p => p(hand)).Where(b => b).Count();
                countTrue = 0;
                foreach (var check in handTypeChecks)
                {
                    if (check(hand))
                    {
                        countTrue += 1;
                    }
                }

                if (countTrue != 1)
                {
                    result = false;
                    break;
                }
            }

            Assert.IsTrue(result);
        }
    }
}