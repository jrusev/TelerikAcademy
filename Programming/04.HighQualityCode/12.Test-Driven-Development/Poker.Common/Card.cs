namespace Poker
{
    using System;

    public class Card : ICard, IComparable<ICard>
    {
        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }

        public int CompareTo(ICard other)
        {
            if (other == null)
            {
                return 1;
            }

            return this.Face.CompareTo(other.Face);
        }

        public override int GetHashCode()
        {
            // With 'unchecked' we allow the result to overflow without causing an error,
            // because we don't really care about the result as a number.
            unchecked
            {
                int result = 17;
                result = (result * 23) + this.Face.GetHashCode();
                result = (result * 23) + this.Suit.GetHashCode();
                return result;
            }
        }

        public override string ToString()
        {
            return this.Face + " of " + this.Suit;
        }
    }
}
