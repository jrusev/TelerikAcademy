using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Linq;
namespace PokerTests
{
    [TestClass]
    public class PokerHandsCheckerTest
    {
        // MSTEST reinstantiates the class on every 
        // and PokerHandsChecker is immutable
        // so we can use a field
        readonly PokerHandsChecker checker = new PokerHandsChecker();

        // "♣♦♥♠"

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

        [TestMethod]
        public void HandStatesAreExclusive()
        {
            var predicates = checker.PredicatesList;
            predicates.Add(h => !checker.IsValidHand(h));
            var hands = new[] { "A♠ 2♥ 3♣ 9♦ Q♥", "2♠ 2♥ 3♣ 4♦ 6♥", "2♠ 2♥ 3♣ 3♦ 6♥", "2♠ 2♥ 2♣ 3♦ 6♥", "2♠ 5♠ 7♠ 9♠ J♠", "2♠ 3♥ 4♣ 5♦ 6♥", "2♠ 2♥ 2♣ 3♦ 3♥", "2♠ 2♥ 2♣ 2♦ 6♥", "2♠ 3♠ 4♠ 5♠ 6♠", "2♠ 2♥ 2♣ 2♦ 5♥", "A♠ 2♥ 3♣ 4♦ 5♥", "A♠ Q♥ 0♣ J♦ K♥", "A♠ A♠", "A♠ A♠ 0♣ J♦ K♥ 2♠", "" };

            bool ok = true;
            foreach (var hand in hands.Select(h => PokerUtils.ReadHand(h)))
            {

                // basically, how many predicates are true for this hand
                var countTrue = predicates.Select(p => p(hand)).Where(b => b).Count();
                countTrue = 0;
                foreach (var p in predicates)
                {
                    if (p(hand))
                    {
                        countTrue += 1;
                    }
                }

                if (countTrue != 1)
                {
                    ok = false;
                    break;
                }

            }

            Assert.IsTrue(ok);

        }

        // FIXME: doesn't test tiebreak resolution
        [TestMethod]
        public void CompareOk()
        {
            var predicates = checker.PredicatesList;

            var hands = new[] { "A♠ 2♥ 3♣ 9♦ Q♥", "2♠ 2♥ 3♣ 4♦ 6♥", "2♠ 2♥ 3♣ 3♦ 6♥", "2♠ 2♥ 2♣ 3♦ 6♥", "2♠ 5♠ 7♠ 9♠ J♠", "2♠ 3♥ 4♣ 5♦ 6♥", "2♠ 2♥ 2♣ 3♦ 3♥", "2♠ 2♥ 2♣ 2♦ 6♥", "2♠ 3♠ 4♠ 5♠ 6♠", "2♠ 2♥ 2♣ 2♦ 5♥", "A♠ 2♥ 3♣ 4♦ 5♥", "A♠ Q♥ 0♣ J♦ K♥", "A♠ A♠", "A♠ A♠ 0♣ J♦ K♥ 2♠", "" };

            bool ok = true;
            foreach (var hand1 in hands.Select(h => PokerUtils.ReadHand(h)))
                foreach (var hand2 in hands.Select(h => PokerUtils.ReadHand(h)))
                {
                    if (!checker.IsValidHand(hand1) ||
                        !checker.IsValidHand(hand2))
                        continue;

                    // the indices of the two hands in the predicate list
                    int ii, jj;
                    for (ii = 0; ii < predicates.Count; ii++)
                    {
                        if (predicates[ii](hand1))
                            break;
                    }
                    for (jj = 0; jj < predicates.Count; jj++)
                    {
                        if (predicates[jj](hand2))
                            break;
                    }


                    var cmp = checker.CompareHands(hand1, hand2);
                    if (cmp == 0)
                    {
                        if (ii != jj)
                            ok = false;

                        continue;
                    }

                    // the higher the index, the weaker the hand
                    if (cmp == -1)
                    {
                        if (ii < jj)
                            ok = false;

                        continue;
                    }
                    else
                    {
                        if (ii > jj)
                            ok = false;

                        continue;
                    }
                }

            Assert.IsTrue(ok);

        }
    }
}