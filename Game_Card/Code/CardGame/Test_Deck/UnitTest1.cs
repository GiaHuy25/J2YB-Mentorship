using CardGameLogic.Models;
using CardGameLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
        //test initializes player
        [TestMethod]
        public void CreatePlayers_ShouldReturnCorrectNumberOfPlayers()
        {
            int numberOfPlayers = 3;
            var inputNames = new List<string> { "player1", "player2", "player3" };
            var players = Bacarat.CreatePlayers(inputNames);

            Assert.AreEqual(numberOfPlayers,players.Count);
            Assert.AreEqual(inputNames[0], players[0].Name);
            Assert.AreEqual(inputNames[1], players[1].Name);
            Assert.AreEqual(inputNames[2], players[2].Name);
        }
        //test dealing cards
        [TestMethod]
        public void DrawCard_ShouldAddCardToPlayerHandAndRemoveFromDeck()
        {
            var deck = new Deck();
            var player = new Player("Test");

            Bacarat.DrawCard(player, deck);

            Assert.AreEqual(1, player.Hand.Count); // xem có một lá bài trong tay người chơi không
            Assert.AreEqual(51, deck.Cards.Count); // vì đã có một lá bài được chia
        }
        //scoring test
        [TestMethod]
        public void CalculatePoints_ShouldReturnCorrectPoints()
        {
            var player = new Player("Test");
            player.Hand.AddRange(new List<Card>
            {
                new Card(Suit.Heart, Value.Two),
                new Card(Suit.Spade, Value.Five),
                new Card(Suit.Diamond, Value.Seven)
            });

            int points = Bacarat.CalculatePoints(player);

            Assert.AreEqual(4, points); // 2 + 5 + 7 = 14, and 14 % 10 = 4
        }
        //Test to check the winner
        [TestMethod]
        public void DetermineWinner_ShouldReturnCorrectWinner()
        {
            // Khởi tạo hai người chơi
            var player1 = new Player("Player1");
            player1.Hand.AddRange(new List<Card>
            {
                new Card(Suit.Heart, Value.Two),
                new Card(Suit.Spade, Value.Five),
                new Card(Suit.Diamond, Value.Seven)
            });

            var player2 = new Player("Player2");
            player2.Hand.AddRange(new List<Card>
            {
                new Card(Suit.Club, Value.Three),
                new Card(Suit.Heart, Value.Four),
                new Card(Suit.Spade, Value.Four)
            });

            var players = new List<Player> { player1, player2 };

            // chạy method
            string result = Bacarat.DetermineWinner(players);

            // kiểm tra 
            Assert.AreEqual("Player1 wins!", result); // Player1 has 4 points, Player2 has 1 point
        }

    }
}
