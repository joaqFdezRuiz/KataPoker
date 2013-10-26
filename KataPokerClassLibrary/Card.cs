using System.Collections.Generic;

namespace KataPokerClassLibrary
{
  public enum CardNumber { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, J, Q, K }
  public enum CardColor { Spades, Diamonds, Clover, Hearts }

  public class Card
  {
    private readonly CardNumber _cardNumber;
    private readonly CardColor _cardColor;

    public Card(CardNumber cardNumber, CardColor cardColor)
    {
      this._cardNumber = cardNumber;
      this._cardColor = cardColor;
    }

    public CardNumber Number
    {
      get { return _cardNumber; }
    }

    public CardColor Color
    {
      get { return _cardColor; }
    }

#pragma warning disable 659
    public override bool Equals(object obj)
#pragma warning restore 659
    {
      if (obj == null || GetType() != obj.GetType())
        return false;
      var cardToCompare = (Card)obj;
      if (cardToCompare.Number == this.Number && cardToCompare.Color == this.Color)
        return true;
      else
        return false;
    }
  }
  internal class CardsEqualsNumber : IEqualityComparer<Card>
  {
    public bool Equals(Card x, Card y)
    {
      return x.Number == y.Number;
    }

    public int GetHashCode(Card obj)
    {
      return obj.Number.GetHashCode();
    }
  }

  internal class CardsEqualsColor : IEqualityComparer<Card>
  {
    public bool Equals(Card x, Card y)
    {
      return x.Color == y.Color;
    }

    public int GetHashCode(Card obj)
    {
      return obj.Color.GetHashCode();
    }
  }
}
