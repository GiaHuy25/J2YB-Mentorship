using CardGameLogic.Models;
using CardGameLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Test_Deck
{
    [TestClass]
    public class UnitTest1
    {
        // Make sure card have full value 
        [TestMethod]
        public void isTrueCard_Test()
        {
            Card card = new Card(Suit.Heart, Value.Ace);
            Assert.AreEqual(Suit.Heart, card.CardSuit);
            Assert.AreEqual(Value.Ace, card.CardValue);
        }
        // 1 Deck have 52 cards
        [TestMethod]
        public void isTrueDeck_Test()
        {
            var deck = new Deck();
            Assert.AreEqual(52, CommonServices.IsTrueDeck(deck));
        }
        // 1 suit have 13 cards
        [TestMethod]
        public void isEachSuitHave13Card_Test()
        {
            var deck = new Deck();
            Assert.AreEqual(4, CommonServices.isEachSuitHave13Card(deck));
        }
        //Each card appears only once in deck
       [TestMethod]
        public void CardAppearOneInDeck_Test()
        {
            var deck = new Deck();
            Assert.IsTrue(CommonServices.CardAppearOneInDeck(deck));
        }
        [TestMethod]
        public void Shuffel_Test()
        {
            var deck = new Deck();
            var originalOrder = deck.Cards.ToList();
            CommonServices.Shuffle(deck);
            Assert.AreNotEqual(originalOrder, deck.Cards);
        }
    }
}
