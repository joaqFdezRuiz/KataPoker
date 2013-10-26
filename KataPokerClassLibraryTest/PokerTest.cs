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
      var listCard = new List<Card>();
      listCard.Add(new Card(CardNumber.Ace, CardColor.Clover));
      listCard.Add(new Card(CardNumber.Two, CardColor.Clover));
      listCard.Add(new Card(CardNumber.Three, CardColor.Clover));
      listCard.Add(new Card(CardNumber.Four, CardColor.Clover));
      listCard.Add(new Card(CardNumber.Five, CardColor.Clover));
      Assert.AreEqual(Poker.Result.EscaleraReal , poker.HandVerifier(listCard));
    }

    [Test]
    public void ResultEscaleraColor()
    {
      var poker = new Poker();
      var listCard = new List<Card>();
      listCard.Add(new Card(CardNumber.Two, CardColor.Clover));
      listCard.Add(new Card(CardNumber.Three, CardColor.Clover));
      listCard.Add(new Card(CardNumber.Four, CardColor.Clover));
      listCard.Add(new Card(CardNumber.Five, CardColor.Clover));
      listCard.Add(new Card(CardNumber.Six, CardColor.Clover));
      Assert.AreEqual(Poker.Result.EscaleraColor, poker.HandVerifier(listCard));
    }

    [Test]
    public void ResultPoker()
    {
      var poker = new Poker();
      var listCard = new List<Card>();
      listCard.Add(new Card(CardNumber.Two, CardColor.Clover));
      listCard.Add(new Card(CardNumber.Two, CardColor.Diamonds));
      listCard.Add(new Card(CardNumber.Two, CardColor.Hearts));
      listCard.Add(new Card(CardNumber.Two, CardColor.Spades));
      listCard.Add(new Card(CardNumber.Six, CardColor.Clover));
      Assert.AreEqual(Poker.Result.Poker, poker.HandVerifier(listCard));
    }

    [Test]
    public void ResultFull()
    {
      var poker = new Poker();
      var listCard = new List<Card>();
      listCard.Add(new Card(CardNumber.Two, CardColor.Clover));
      listCard.Add(new Card(CardNumber.Two, CardColor.Diamonds));
      listCard.Add(new Card(CardNumber.Two, CardColor.Hearts));
      listCard.Add(new Card(CardNumber.Six, CardColor.Spades));
      listCard.Add(new Card(CardNumber.Six, CardColor.Clover));
      Assert.AreEqual(Poker.Result.Full, poker.HandVerifier(listCard));
    }

    [Test]
    public void ResultColor()
    {
      var poker = new Poker();
      var listCard = new List<Card>();
      listCard.Add(new Card(CardNumber.Two, CardColor.Hearts));
      listCard.Add(new Card(CardNumber.Nine, CardColor.Hearts));
      listCard.Add(new Card(CardNumber.K, CardColor.Hearts));
      listCard.Add(new Card(CardNumber.J, CardColor.Hearts));
      listCard.Add(new Card(CardNumber.Seven, CardColor.Hearts));
      Assert.AreEqual(Poker.Result.Color, poker.HandVerifier(listCard));
    }

  }

  
}
