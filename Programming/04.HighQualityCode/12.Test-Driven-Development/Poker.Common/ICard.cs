using System;
namespace Poker
{
    public interface ICard : IComparable<ICard>
    {
        CardFace Face { get; }
        CardSuit Suit { get; }
        string ToString();
    }
}
