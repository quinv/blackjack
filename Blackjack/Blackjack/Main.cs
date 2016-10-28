using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Blackjack
{
    public class Main
    {
        public MainUI _mainUI;
        public Deck _deck;

        public Main(PictureBox pictureBox)
        {
            _mainUI = new MainUI(pictureBox, this);
            _deck = new Deck(this);
        }
    }
}
