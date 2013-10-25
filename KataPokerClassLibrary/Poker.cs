using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPokerClassLibrary
{
  public class Poker
  {
    public void HandVerifier(List<Card> listCard)
    {
      if(listCard==null)
        throw new ArgumentException("lista de cartas null");
      if (listCard.Count() != 5)
        throw new ArgumentException("numero de cartas incorrecto");
      

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
    public CardNumber Number { get; set; }
    public CardColor Color { get; set; }

  }
}
