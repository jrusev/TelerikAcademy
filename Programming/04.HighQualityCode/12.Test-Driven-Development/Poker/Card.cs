using System;

namespace Poker
{
    public class Card : ICard, IComparable<ICard>
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }



        public int CompareTo(ICard other)
        {
            if (other == null)
                return 1;
            return this.Face.CompareTo(
                   other.Face);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;
                result = result * 23 + this.Face.GetHashCode();
                result = result * 23 + this.Suit.GetHashCode();
                return result;
            }
        }

        // value semantics

        public bool Equals(Card value)
        {
            if (value == null)
                return false;

            return this.Face.Equals(value.Face) &&
                   this.Suit.Equals(value.Suit);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Card))
            {
                return false;
            }
            return this.Equals((Card)obj);
        }

        public override string ToString()
        {
            return // "Card: " + 
                this.Face + " of " + this.Suit;
        }
    }
}
