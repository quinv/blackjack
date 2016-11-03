using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Hand
    {
        private static Deck _deck = new Deck();
        private List<Card> cards = new List<Card>();

        public Hand()
        {
            for(int i = 0; i < 2; i++)
            {
                GetCard(_deck);
            }
        }

        public void GetCard(Deck _deck)
        {
            if(_deck == null)
            {
                _deck = new Deck();
            }
            cards.Add(_deck.drawCard());
            Console.WriteLine("get card");
        }
    }
}
