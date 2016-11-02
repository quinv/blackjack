using System;
using System.Collections.Generic;
namespace Blackjack
{
    public class Deck
    {
        private List<Card> cards = new List<Card>();
        private List<Card.CardType> types;

        public Deck()
        {
            types = new List<Card.CardType>();
            types.Add(Card.CardType.Clover);
            types.Add(Card.CardType.Diamond);
            types.Add(Card.CardType.Heart);
            types.Add(Card.CardType.Spade);
            createCards();
        }

        private void createCards() {
            cards = new List<Card>();
            List<int> aceValues = new List<int>();
            aceValues.Add(1);
            aceValues.Add(11);
            foreach (Card.CardType t in types)
            {
                cards.Add(new Card(aceValues, t, 1));
            }
            for (int x=2; x<=10; x++)
            {
                foreach (Card.CardType t in types) {
                    cards.Add(new Card(x, t, x));
                }
            }
            for (int x = 11; x <= 13; x++)
            {
                foreach (Card.CardType t in types)
                {
                    cards.Add(new Card(10, t, x));
                }
            }
        }

        public Card drawCard() {
            if (cards.Count == 0) {
                createCards();
            }
            Random r = new Random();
            int ran = r.Next(cards.Count - 1);
            Card c = cards[ran];
            cards.Remove(c);
            return c;
        }
    }
}
