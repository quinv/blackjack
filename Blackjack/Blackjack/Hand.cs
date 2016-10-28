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
        private Deck deck = new Deck();

        public void GetCard()
        {
            cards.Add(deck.drawCard());
        }
    }
}
