using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataPokerClassLibrary;
using NUnit.Framework;

namespace KataPokerClassLibraryTest
{
  [TestFixture]
  class PokerTest
  {
    [Test]
    public void ListCardNullReturnException()
    {
      var exception = Assert.Throws<ArgumentException>(() => new Poker().HandVerifier(null));
      Assert.That(exception, Has.Message.EqualTo("lista de cartas null"));
    }

    [Test]
    public void ListCardDistinctFiveReturnException()
    {
      var poker = new Poker();
      var listCard = new List<Card> {new Card(CardNumber.Ace, CardColor.Diamonds)};
      var exception = Assert.Throws<ArgumentException>(() => poker.HandVerifier(listCard));
      Assert.That(exception, Has.Message.EqualTo("numero de cartas incorrecto"));
    }

    [Test]
    public void ListWithFiveCardsButTwoOrMoreCardsEqualsReturnException()
    {
      var poker = new Poker();
      var listCard = new List<Card>
        {
          new Card(CardNumber.Ace, CardColor.Diamonds),
          new Card(CardNumber.Ace, CardColor.Diamonds),
          new Card(CardNumber.Ace, CardColor.Diamonds),
          new Card(CardNumber.Ace, CardColor.Diamonds),
          new Card(CardNumber.Ace, CardColor.Diamonds)
        };
      var exception = Assert.Throws<ArgumentException>(() => poker.HandVerifier(listCard));
      Assert.That(exception, Has.Message.EqualTo("dos o más cartas iguales"));
    }

    [Test]
    public void ListWithFiveDiferentsCard()
    {
      var poker = new Poker();
      var listCard = new List<Card>
        {
          new Card(CardNumber.Ace, CardColor.Diamonds),
          new Card(CardNumber.Eight, CardColor.Spades),
          new Card(CardNumber.Five, CardColor.Hearts),
          new Card(CardNumber.Four, CardColor.Diamonds),
          new Card(CardNumber.J, CardColor.Clover)
        };
      Assert.AreEqual("mano valida", poker.HandVerifier(listCard));
    }

  }

  
}
