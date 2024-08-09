using CardGameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLogic.Services
{
    public static class CommonServices
    {
        public static bool CardAppearOneInDeck(Deck deck)
        {
            foreach(var card in deck.Cards)
            {
                isUnique(card,deck);
            }
            return true;
        }

        private static bool isUnique(Card card, Deck deck)
        {
            foreach (var item in deck.Cards)
            {
                if (item.CardValue == card.CardValue && item.CardSuit == card.CardSuit)
                    return false;
            }
            return true;
        }

        public static int isEachSuitHave13Card(Deck deck)
        {
            int countCard= 0;
            int result = 0;
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Card card in deck.Cards) { 
                    if(card.CardSuit == suit)
                    {
                        countCard++;
                    }
                }
                if (countCard == 13)
                {
                    result++;
                }
                countCard = 0;
            }
            return result;
        }

        public static int IsTrueDeck(Deck deck)
        {
           int count = deck.Cards.Count;
           return count;
        }
        public static void Shuffle(Deck deck)
        {
            var rng = new Random();
            deck.Cards = deck.Cards.OrderBy(card => rng.Next()).ToList();
        }
    }
}
