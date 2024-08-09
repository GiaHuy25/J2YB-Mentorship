using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLogic.Models
{
    internal class Card
    {
        public int[] CardSuit { get; set; }
        public int[] CardValue { get; set; }
        public Card() {
            int[] CardSuit = new int[4];
            int[] CardValue = new int[13];
        }

    }
}
