using System;
using System.Collections.Generic;
using System.Linq;

namespace KataPokerClassLibrary
{
  
  public class Poker
  {
    public enum Result
    {
      EscaleraReal,
      EscaleraColor,
      Poker,
      Full,
      Color,
      Escalera,
      Trio,
      DoblesParejas,
      Pareja,
      Nada
    };

    public const int NumeroCartasMano = 5;

    public Result HandVerifier(List<Card> listCard)
    {
      if(listCard==null)
        throw new ArgumentException("lista de cartas null");

      if (listCard.Count() != NumeroCartasMano)
        throw new ArgumentException("numero de cartas incorrecto");

      if (listCard.Select(card => listCard.Count(x => Equals(x, card))).Any(countOfCards => countOfCards > 1))
        throw new ArgumentException("dos o más cartas iguales");

      if (IsEscalera(listCard) && listCard.Any(x => x.Number == CardNumber.Ace))
        return Result.EscaleraReal;

      if (IsEscalera(listCard))
        return Result.EscaleraColor;

      if (listCard.Distinct(new CardsEqualsNumber()).Count() == 2)
        return MaxCardsEqualsNumber(listCard, 3) ? Result.Full : Result.Poker;

      if (listCard.Distinct(new CardsEqualsColor()).Count() == 1)
        return Result.Color;
      
      return Result.Nada;
    }

    private static bool MaxCardsEqualsNumber(IEnumerable<Card> listCard, int maxCont)
    {
      return listCard
          .GroupBy(x => new { numero = x.Number })
          .Select(y => new { numero = y.Key.numero, cont = y.Count() })
          .Max(z => z.cont) == maxCont;
    }

    private static bool IsEscalera(IEnumerable<Card> listCard)
    {
      var valueBeforeCard = 0;
      foreach (var card in listCard.OrderBy(x => x.Number))
      {
        if (valueBeforeCard == 0 || valueBeforeCard == ((int) card.Number - 1))
          valueBeforeCard = (int) card.Number;
        else
          return false;
      }
      return true;
    }
  }

  public enum CardNumber
  {
    Ace,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    J,
    Q,
    K 
  }

  public enum CardColor
  {
    Spades,
    Diamonds,
    Clover,
    Hearts 
  }

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
      var cardToCompare = (Card) obj;
      if (cardToCompare.Number == this.Number && cardToCompare.Color == this.Color)
        return true;
      else
        return false;
    }
  }

  internal class CardsEqualsNumber:IEqualityComparer<Card>
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

  internal class CardsEqualsColor:IEqualityComparer<Card>
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
