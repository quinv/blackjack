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
    public class MainUI
    {
        private int IMAGE_WIDTH = 132, IMAGE_HEIGHT = 185;
        private Bitmap[,] cards = new Bitmap[13, 4];
        private Bitmap cardBack;
        PictureBox _pictureBox;
        Main _main;


        /// <summary>
        /// loads the cards bitmaps from the card deck and stores them in an array
        /// values:
        /// 2 = 0
        /// 3 = 1
        /// ...
        /// j = 9
        /// q = 10
        /// k = 11
        /// a = 12
        /// </summary>
        public MainUI(PictureBox pictureBox, Main main)
        {
            Bitmap deck = Image.FromFile("playingCards/cardDeck.png") as Bitmap;
            cardBack = new Bitmap(IMAGE_WIDTH, IMAGE_HEIGHT);
            Graphics gBack = Graphics.FromImage(cardBack);
            gBack.DrawImage(deck, 0, 0, new Rectangle(IMAGE_WIDTH * 13, IMAGE_HEIGHT * 2, IMAGE_WIDTH, IMAGE_HEIGHT), GraphicsUnit.Pixel);
            for (int i = 0; i < cards.GetLength(0); i++)
            {
                for (int j = 0; j < cards.GetLength(1); j++)
                {
                    cards[i, j] = new Bitmap(IMAGE_WIDTH, IMAGE_HEIGHT);
                    Graphics g = Graphics.FromImage(cards[i, j]);
                    g.DrawImage(deck, 0, 0, new Rectangle(IMAGE_WIDTH * i, IMAGE_HEIGHT * j, IMAGE_WIDTH, IMAGE_HEIGHT), GraphicsUnit.Pixel);
                }
            }
        }

        public void drawCards(List<Card> playerCards, List<Card> dealerCards, bool turnDealerCards)
        {
            _pictureBox.Invalidate();
            Graphics g = _pictureBox.CreateGraphics();
            Image[] playerCardImages = new Image[playerCards.Count];
            for (int i = 0; i < playerCards.Count; i++)
            {
                if(playerCards[i].getID() == 1)
                {

                }
            }
        }
    }
}
