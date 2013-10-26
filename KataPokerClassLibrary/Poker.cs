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

      if (IsEscaleraReal(listCard))
      {
        return Result.EscaleraReal;
      }

      return Result.Nada;
    }

    private static bool IsEscaleraReal(IEnumerable<Card> listCard)
    {
      var valueBeforeCard = 0;
      foreach (var card in listCard.OrderBy(x => x.Number))
      {
        if (valueBeforeCard == 0 || valueBeforeCard == ((int) card.Number - 1))
          valueBeforeCard = (int) card.Number;
        else
          return false;
      }
      return listCard.Any(x=>x.Number== CardNumber.Ace);
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

    public override bool Equals(object obj)
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
}
