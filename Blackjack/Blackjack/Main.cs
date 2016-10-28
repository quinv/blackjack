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
        public Deck _deck;
        public Hand _hand;

        protected Hand playerHand = new Hand();
        protected Hand dealerHand = new Hand();

        public Main(PictureBox pictureBox)
        {
            _mainUI = new MainUI(pictureBox, this);
            _deck = new Deck(this);
        }
    }
}
