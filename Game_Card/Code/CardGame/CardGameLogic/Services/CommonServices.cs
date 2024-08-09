using CardGameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLogic.Services
{
    public static class CommonServices
    {
        public static bool isEachSuitHave13Card(Deck deck)
        {
            return true;
        }

        public static bool IsTrueDeck(Deck deck)
        {
            if(deck.Number_of_cards == 52)
                 return true;
            else return false;
        }
    }
}
