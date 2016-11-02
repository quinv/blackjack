using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Blackjack
{
    public class Main
    {
        public MainUI _mainUI;

        public Main(PictureBox pictureBox)
        {
            _mainUI = new MainUI(pictureBox);

            //TODO
            List<Card> playerDeck = new List<Card>();
            List<Card> dealerDeck = new List<Card>();
            Deck deck = new Deck();
            for (int i = 0; i < 9; i++)
            {
                playerDeck.Add(deck.drawCard());
                dealerDeck.Add(deck.drawCard());
            }
            _mainUI.cardUI.PlaceCards(playerDeck, dealerDeck, false);
        }
    }
}
