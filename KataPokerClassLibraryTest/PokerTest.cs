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
    public void ResultEscaleraReal()
    {
      var poker = new Poker();
      var listCard = new List<Card>
        {
          new Card(CardNumber.Ace, CardColor.Clover),
          new Card(CardNumber.Two, CardColor.Clover),
          new Card(CardNumber.Three, CardColor.Clover),
          new Card(CardNumber.Four, CardColor.Clover),
          new Card(CardNumber.Five, CardColor.Clover)
        };
      Assert.AreEqual(Poker.Result.EscaleraReal , poker.HandVerifier(listCard));
    }

    [Test]
    public void ResultEscaleraColor()
    {
      var poker = new Poker();
      var listCard = new List<Card>
        {
          new Card(CardNumber.Two, CardColor.Clover),
          new Card(CardNumber.Three, CardColor.Clover),
          new Card(CardNumber.Four, CardColor.Clover),
          new Card(CardNumber.Five, CardColor.Clover),
          new Card(CardNumber.Six, CardColor.Clover)
        };
      Assert.AreEqual(Poker.Result.EscaleraColor, poker.HandVerifier(listCard));
    }

    [Test]
    public void ResultPoker()
    {
      var poker = new Poker();
      var listCard = new List<Card>
        {
          new Card(CardNumber.Two, CardColor.Clover),
          new Card(CardNumber.Two, CardColor.Diamonds),
          new Card(CardNumber.Two, CardColor.Hearts),
          new Card(CardNumber.Two, CardColor.Spades),
          new Card(CardNumber.Six, CardColor.Clover)
        };
      Assert.AreEqual(Poker.Result.Poker, poker.HandVerifier(listCard));
    }

    [Test]
    public void ResultFull()
    {
      var poker = new Poker();
      var listCard = new List<Card>
        {
          new Card(CardNumber.Two, CardColor.Clover),
          new Card(CardNumber.Two, CardColor.Diamonds),
          new Card(CardNumber.Two, CardColor.Hearts),
          new Card(CardNumber.Six, CardColor.Spades),
          new Card(CardNumber.Six, CardColor.Clover)
        };
      Assert.AreEqual(Poker.Result.Full, poker.HandVerifier(listCard));
    }

    [Test]
    public void ResultColor()
    {
      var poker = new Poker();
      var listCard = new List<Card>
        {
          new Card(CardNumber.Two, CardColor.Hearts),
          new Card(CardNumber.Nine, CardColor.Hearts),
          new Card(CardNumber.K, CardColor.Hearts),
          new Card(CardNumber.J, CardColor.Hearts),
          new Card(CardNumber.Seven, CardColor.Hearts)
        };
      Assert.AreEqual(Poker.Result.Color, poker.HandVerifier(listCard));
    }

    [Test]
    public void ResultEscalera()
    {
      var poker = new Poker();
      var listCard = new List<Card>
        {
          new Card(CardNumber.Two, CardColor.Clover),
          new Card(CardNumber.Three, CardColor.Diamonds),
          new Card(CardNumber.Four, CardColor.Clover),
          new Card(CardNumber.Five, CardColor.Hearts),
          new Card(CardNumber.Six, CardColor.Spades)
        };
      Assert.AreEqual(Poker.Result.Escalera, poker.HandVerifier(listCard));
    }
    
    [Test]
    public void ResultTrio()
    {
      var poker = new Poker();
      var listCard = new List<Card>
        {
          new Card(CardNumber.K, CardColor.Clover),
          new Card(CardNumber.K, CardColor.Diamonds),
          new Card(CardNumber.K, CardColor.Spades),
          new Card(CardNumber.Five, CardColor.Hearts),
          new Card(CardNumber.Six, CardColor.Spades)
        };
      Assert.AreEqual(Poker.Result.Trio, poker.HandVerifier(listCard));
    }

    [Test]
    public void ResultDoblesParejas()
    {
      var poker = new Poker();
      var listCard = new List<Card>
        {
          new Card(CardNumber.K, CardColor.Clover),
          new Card(CardNumber.K, CardColor.Diamonds),
          new Card(CardNumber.J, CardColor.Spades),
          new Card(CardNumber.Five, CardColor.Hearts),
          new Card(CardNumber.Five, CardColor.Spades)
        };
      Assert.AreEqual(Poker.Result.DoblesParejas, poker.HandVerifier(listCard));
    }

    [Test]
    public void ResultPareja()
    {
      var poker = new Poker();
      var listCard = new List<Card>
        {
          new Card(CardNumber.K, CardColor.Clover),
          new Card(CardNumber.K, CardColor.Diamonds),
          new Card(CardNumber.J, CardColor.Spades),
          new Card(CardNumber.Four, CardColor.Hearts),
          new Card(CardNumber.Five, CardColor.Spades)
        };
      Assert.AreEqual(Poker.Result.Pareja, poker.HandVerifier(listCard));
    }

    [Test]
    public void ResultNada()
    {
      var poker = new Poker();
      var listCard = new List<Card>
        {
          new Card(CardNumber.K, CardColor.Clover),
          new Card(CardNumber.Ace, CardColor.Diamonds),
          new Card(CardNumber.J, CardColor.Spades),
          new Card(CardNumber.Four, CardColor.Hearts),
          new Card(CardNumber.Five, CardColor.Spades)
        };
      Assert.AreEqual(Poker.Result.Nada, poker.HandVerifier(listCard));
    }
  }

  
}
