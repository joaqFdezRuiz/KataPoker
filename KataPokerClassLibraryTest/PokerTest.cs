using System;
using System.Collections.Generic;
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
      Assert.That(exception, Has.Message.EqualTo("numero de cartas invalido"));
    }

    [Test]
    public void ListCardDistinctFiveReturnException()
    {
      var listCard = new List<Card>();
      var exception = Assert.Throws<ArgumentException>(() => new Poker().HandVerifier(listCard));
      Assert.That(exception, Has.Message.EqualTo("numero de cartas invalido"));
    }

  }

  
}
