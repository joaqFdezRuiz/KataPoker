using System;
using System.Collections.Generic;
using System.Linq;

namespace KataPokerClassLibrary
{
  public class Poker
  {
    private const int NumeroCartasMano = 5;
    public enum Result { EscaleraReal, EscaleraColor, Poker, Full, Color, Escalera, Trio, DoblesParejas, Pareja, Nada };
    
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

      if (IsEscalera(listCard) && listCard.Distinct(new CardsEqualsColor()).Count()==1)
        return Result.EscaleraColor;

      if (listCard.Distinct(new CardsEqualsNumber()).Count() == 2)
        return MaxCardsEqualsNumber(listCard, 3) ? Result.Full : Result.Poker;

      if (listCard.Distinct(new CardsEqualsColor()).Count() == 1)
        return Result.Color;

      if (IsEscalera(listCard))
        return Result.Escalera;

      if (listCard.Distinct(new CardsEqualsNumber()).Count() == 3)
        return MaxCardsEqualsNumber(listCard, 2) ? Result.DoblesParejas : Result.Trio;

      return listCard.Distinct(new CardsEqualsNumber()).Count() == 4 ? Result.Pareja : Result.Nada;
    }

    private static bool MaxCardsEqualsNumber(IEnumerable<Card> listCard, int maxCont)
    {
      return listCard.GroupBy(x => new { number = x.Number }).Select(y => new { number = y.Key.number, cont = y.Count() }).Max(z => z.cont) == maxCont;
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
}
