using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLogic.Models
{
    public class Deck
    {
        public int Id { get; set; }
        public int Number_of_cards { get; set; }
        List<Card> cards { get; set; }

        public Deck()
        {
            Id = 0;
            Number_of_cards = 0;
            cards = new List<Card>();
        }

    }
}
