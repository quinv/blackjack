using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Hand
    {
        private static Deck _deck;
        private List<Card> cards = new List<Card>();

        public void GetCard(Main main)
        {
            if(_deck == null)
            {
                _deck = new Deck();
            }
            cards.Add(_deck.drawCard());
        }
    }
}
