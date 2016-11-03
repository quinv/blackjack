using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Blackjack
{
    public class MainUI
    {
        public CardUI cardUI;
        public ScoreUI scoreUI;
        public MainUI(Main main)
        {
            PictureBox pictureBox = main._form.drawingPanel;
            cardUI = new CardUI(pictureBox);
            scoreUI = new ScoreUI(pictureBox);
            pictureBox.Paint += draw;
        }

        private void draw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.DarkGreen);
            cardUI.draw(g);
            scoreUI.draw(g);
        }
    }
}
