using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Logics
    {
        public static List<int> getTotalValues(List<Card> cards)
        {
            List<int> values = new List<int>();
            foreach (Card c in cards)
            {
                List<int> cValues = c.getValues();
                List<int> tempValues = values;
                values.Clear();
                foreach (int value in cValues)
                {
                    if (tempValues.Count == 0)
                    {
                        values.Add(value);
                    }
                    else
                    {
                        foreach (int v in tempValues)
                        {
                            values.Add(v + value);
                        }
                    }
                }
            }

            return values;
        }
    }
}
