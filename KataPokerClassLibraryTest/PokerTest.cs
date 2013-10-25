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
      var poker = new Poker();
      var exception = Assert.Throws<ArgumentException>(() => poker.HandVerifier(null));
      Assert.That(exception, Has.Message.EqualTo("numero de cartas invalido"));
    }

  }

  
}
