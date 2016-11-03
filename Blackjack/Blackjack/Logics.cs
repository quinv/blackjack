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
                List<int> tempValues = new List<int>(values);
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
            RemoveDuplicateValues(values);
            return values;
        }

        private static void RemoveDuplicateValues(List<int> values)
        {
            for (int i = values.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < values.Count; j++)
                {
                    if (values[i] == values[j] && j != i)
                    {
                        values.RemoveAt(i);
                        break;
                    }
                }
            }
        }
    }
}
