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
            Initialize();
        }

        public void Initialize()
        {
            cards.Clear();
            for (int i = 0; i < 2; i++)
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
            Cards.Add(_deck.drawCard());
        }

        public static Deck _Deck
        {
            get
            {
                return _deck;
            }

            set
            {
                _deck = value;
            }
        }

        public List<Card> Cards
        {
            get
            {
                return cards;
            }
        }
    }
}
