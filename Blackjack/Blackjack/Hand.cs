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

        public void GetCard(Main main)
        {
            cards.Add(main._deck.drawCard());
        }
    }
}
