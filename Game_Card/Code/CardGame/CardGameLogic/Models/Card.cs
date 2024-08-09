using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLogic.Models
{
    public enum Suit
    {
        Heart,  // Cơ
        Spade,  // Rô
        Diamond, // Chuồn
        Club    // Bích
    }

    public enum Value
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 1
    }
    public class Card
    {
        public Suit CardSuit { get; set; }
        public Value CardValue { get; set; }
        public Card(Suit Suit, Value Value) {
            CardSuit = Suit;
            CardValue = Value;
        }

    }
}
