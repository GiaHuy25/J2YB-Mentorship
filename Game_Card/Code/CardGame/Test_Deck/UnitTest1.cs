using CardGameLogic.Models;
using CardGameLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test_Deck
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void isTrueDeck_Test()
        {
            Deck deck = new Deck();
            deck.Number_of_cards = 52;
            //data
            //logic method
            var result = CommonServices.IsTrueDeck(deck);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void isEachSuitHave13Card_Test()
        {
            Deck deck = new Deck();
            var result = CommonServices.isEachSuitHave13Card(deck);
            Assert.IsTrue(result);
        }
    }
}
