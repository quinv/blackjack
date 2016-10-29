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
            _pictureBox = pictureBox;
            _main = main;
            Bitmap deck = Image.FromFile("playingCards/cardDeck.png") as Bitmap;
            cardBack = new Bitmap(IMAGE_WIDTH, IMAGE_HEIGHT);
            Graphics gBack = Graphics.FromImage(cardBack);
            gBack.DrawImage(deck, 0, 0, new Rectangle(IMAGE_WIDTH * 13, IMAGE_HEIGHT * 2, IMAGE_WIDTH, IMAGE_HEIGHT), GraphicsUnit.Pixel);
            cardBack = ScaleImage(cardBack, 2 * IMAGE_WIDTH, 2 * IMAGE_HEIGHT);
            for (int i = 0; i < cards.GetLength(0); i++)
            {
                for (int j = 0; j < cards.GetLength(1); j++)
                {
                    cards[i, j] = new Bitmap(IMAGE_WIDTH, IMAGE_HEIGHT);
                    Graphics g = Graphics.FromImage(cards[i, j]);
                    g.DrawImage(deck, 0, 0, new Rectangle(IMAGE_WIDTH * i, IMAGE_HEIGHT * j, IMAGE_WIDTH, IMAGE_HEIGHT), GraphicsUnit.Pixel);
                    cards[i, j] = ScaleImage(cards[i, j], IMAGE_WIDTH * 2, IMAGE_HEIGHT * 2);
                }
            }
            _pictureBox.Paint += draw;
        }
        
        Image[] playerCardImages;
        Image[] dealerCardImages;
        bool areDealerCardsFaceUp = false;
        /// <summary>
        /// finds the images to use for the cards and calls method to draw them on the picturebox
        /// </summary>
        /// <param name="playerCards">player hand's card list</param>
        /// <param name="dealerCards">dealer hand's card list</param>
        /// <param name="turnDealerCards">are the cards from the dealer visible</param>
        public void PlaceCards(List<Card> playerCards, List<Card> dealerCards, bool turnDealerCards)
        {
            areDealerCardsFaceUp = turnDealerCards;
            playerCardImages = new Image[playerCards.Count];
            dealerCardImages = new Image[dealerCards.Count];
            Graphics g = _pictureBox.CreateGraphics();
            for (int i = 0; i < playerCards.Count; i++)
            {
                if(playerCards[i].getID() == 1)
                {
                    playerCardImages[i] = cards[12, (int)playerCards[i].getType()];
                }
                else
                {
                    playerCardImages[i] = cards[ playerCards[i].getID() - 2, (int)playerCards[i].getType()];
                }
            }
            for (int i = 0; i < dealerCards.Count; i++)
            {
                if (dealerCards[i].getID() == 1)
                {
                    dealerCardImages[i] = cards[12, (int)dealerCards[i].getType()];
                }
                else
                {
                    dealerCardImages[i] = cards[dealerCards[i].getID() - 2, (int)dealerCards[i].getType()];
                }
            }
            _pictureBox.Invalidate();
        }

        private void draw(object sender, PaintEventArgs e)
        {
            if (playerCardImages == null && dealerCardImages == null)
            {
                return;
            }
            Graphics g = e.Graphics;
            if (playerCardImages != null) { 
                for (int i = 0; i < playerCardImages.Length; i++)
                {
                    g.DrawImage(playerCardImages[i], (int)(20 + i * IMAGE_WIDTH * 1.5), (int)(_pictureBox.Height - IMAGE_HEIGHT * 1.5));
                }
            }
            if (dealerCardImages != null)
            {
                for (int i = 0; i < dealerCardImages.Length; i++)
                {
                    if (areDealerCardsFaceUp)
                    {
                        g.DrawImage(dealerCardImages[i], (int)(20 + i * IMAGE_WIDTH * 1.5), 50);
                    }
                    else
                    {
                        g.DrawImage(cardBack, (int)(20 + i * IMAGE_WIDTH * 1.5), 50);
                    }
                }
            }
        }

        private Bitmap ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            Bitmap bmp = new Bitmap(newImage);

            return bmp;
        }
    }
}
