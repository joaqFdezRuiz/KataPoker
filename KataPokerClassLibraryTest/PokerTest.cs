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
    public void ListWithTwoCardsEqualsReturnException()
    {
      var poker = new Poker();
      var listCard = new List<Card>
        {
          new Card(CardNumber.Ace, CardColor.Diamonds),
          new Card(CardNumber.Ace, CardColor.Diamonds)
        };
      var exception = Assert.Throws<ArgumentException>(() => poker.HandVerifier(listCard));
      Assert.That(exception, Has.Message.EqualTo("dos cartas iguales"));
    }

  }

  
}
