using System;
using System.Collections.Generic;
namespace Blackjack
{
    public class Card
    {
        public enum CardType { Diamond, Clover, Heart, Spade };

        private List<int> values;
        private CardType type;
        private int id;

        public Card(List<int> v, CardType t, int i)
        {
            values = v;
            type = t;
            id = i;
        }

        public Card(int v, CardType t, int i)
        {
            values = new List<int>();
            values.Add(v);
            type = t;
            id = i;
        }

        public int getPossibleValues()
        {
            return values.Count;
        }

        public List<int> getValues()
        {
            return values;
        }

        public CardType getType()
        {
            return type;
        }
    }
}
