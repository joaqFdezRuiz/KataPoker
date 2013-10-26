using System;
using System.Collections.Generic;
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
    public void EscaleraReal()
    {
      var poker = new Poker();
      var listCard = new List<Card>();
      listCard.Add(new Card(CardNumber.Ace, CardColor.Clover));
      listCard.Add(new Card(CardNumber.Two, CardColor.Clover));
      listCard.Add(new Card(CardNumber.Three, CardColor.Clover));
      listCard.Add(new Card(CardNumber.Four, CardColor.Clover));
      listCard.Add(new Card(CardNumber.Five, CardColor.Clover));
      Assert.AreEqual(Poker.Result.EscaleraReal , poker.HandVerifier(listCard));
    }

  }

  
}
