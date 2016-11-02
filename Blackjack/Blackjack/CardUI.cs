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
    public class CardUI
    {
        private const int IMAGE_WIDTH = 132, IMAGE_HEIGHT = 185, SIZE_MULTIPLIER = 2, PADDING = 20, HEIGHT_DIFFERENCE = 50;
        private const int MAX_CARDS_PER_LINE = 5;
        private const double CARD_DISTANCE_MULTIPLIER = 1.5;
        private Bitmap[,] cards = new Bitmap[13, 4];
        private Bitmap cardBack;
        PictureBox _pictureBox;


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
        public CardUI(PictureBox pictureBox)
        {
            _pictureBox = pictureBox;
            #region loads the cards
            Bitmap deck = Image.FromFile("playingCards/cardDeck.png") as Bitmap;
            cardBack = new Bitmap(IMAGE_WIDTH, IMAGE_HEIGHT);
            Graphics gBack = Graphics.FromImage(cardBack);
            gBack.DrawImage(deck, 0, 0, new Rectangle(IMAGE_WIDTH * 13, IMAGE_HEIGHT * 2, IMAGE_WIDTH, IMAGE_HEIGHT), GraphicsUnit.Pixel);
            cardBack = RescaleCard(cardBack, SIZE_MULTIPLIER * IMAGE_WIDTH, SIZE_MULTIPLIER * IMAGE_HEIGHT);
            for (int i = 0; i < cards.GetLength(0); i++)
            {
                for (int j = 0; j < cards.GetLength(1); j++)
                {
                    cards[i, j] = new Bitmap(IMAGE_WIDTH, IMAGE_HEIGHT);
                    Graphics g = Graphics.FromImage(cards[i, j]);
                    g.DrawImage(deck, 0, 0, new Rectangle(IMAGE_WIDTH * i, IMAGE_HEIGHT * j, IMAGE_WIDTH, IMAGE_HEIGHT), GraphicsUnit.Pixel);
                    cards[i, j] = RescaleCard(cards[i, j], IMAGE_WIDTH * SIZE_MULTIPLIER, IMAGE_HEIGHT * SIZE_MULTIPLIER);
                }
            }
            #endregion
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
            #region puts images for cards in an array
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
            #endregion
            _pictureBox.Invalidate(); //invalidates whats on the picturebox and redraws it with new cards
        }

        public void draw(Graphics g)
        {
            if (playerCardImages == null && dealerCardImages == null)//draws nothing when no cards should be displayed
            {
                return;
            }
            #region draws playercards
            if (playerCardImages != null) { 
                for (int i = 0; i < playerCardImages.Length; i++)
                {
                    g.DrawImage(playerCardImages[i], (int)(PADDING + i%MAX_CARDS_PER_LINE * IMAGE_WIDTH * CARD_DISTANCE_MULTIPLIER), (int)(_pictureBox.Height - IMAGE_HEIGHT * CARD_DISTANCE_MULTIPLIER + (int)(i/MAX_CARDS_PER_LINE)*HEIGHT_DIFFERENCE));
                }
            }
            #endregion
            #region draws dealercards and turns them around if needed
            if (dealerCardImages != null)
            {
                for (int i = 0; i < dealerCardImages.Length; i++)
                {
                    g.DrawImage(areDealerCardsFaceUp ? dealerCardImages[i] : cardBack, (int)(PADDING + i%MAX_CARDS_PER_LINE * IMAGE_WIDTH * CARD_DISTANCE_MULTIPLIER), (int)(i / MAX_CARDS_PER_LINE + 1) * HEIGHT_DIFFERENCE);
                }
            }
            #endregion
        }

        /// <summary>
        /// rescales card to the right size
        /// </summary>
        /// <param name="image">image of the card to resize</param>
        /// <param name="maxWidth">max width of the card</param>
        /// <param name="maxHeight">max height of the card</param>
        /// <returns>rescaled card image</returns>
        private Bitmap RescaleCard(Image image, int maxWidth, int maxHeight)
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
