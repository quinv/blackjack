using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Hand
    {
        private List<Card> cards = new List<Card>();
        private Main _main;

        //Get card form deck and place in hand
        public void GetCard()
        {
            cards.Add(_main._deck.drawCard());
        }
    }
}
