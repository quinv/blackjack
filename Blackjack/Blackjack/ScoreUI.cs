using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Blackjack
{
    public class ScoreUI
    {
        private const int VALUE_START_X = 1020, DEALER_VALUE_START_Y = 50, PLAYER_VALUE_START_Y = 620, MAX_VALUE_HEIGHT = 220;
        private const int SCORE_START_X = 1220, SCORE_START_Y = DEALER_VALUE_START_Y, DIST_BETWEEN = 60;
        private int _playerScore = 0, _dealerScore = 0;
        private string _playerCardValues = "card values:\n0", _dealerCardValues = "card values:\n0";
        private Font gameFont = new Font("Kozuka Mincho Pro H", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private PictureBox _pictureBox;

        public ScoreUI(PictureBox picturebox)
        {
            _pictureBox = picturebox;
        }

        /// <summary>
        /// sets the score for player and dealer
        /// </summary>
        /// <param name="playerScore">times player has won</param>
        /// <param name="dealerScore">times dealer has won</param>
        public void setScore(int playerScore, int dealerScore)
        {
            _playerScore = playerScore;
            _dealerScore = dealerScore;
        }

        /// <summary>
        /// creates 2 strings from the values given to the method
        /// </summary>
        /// <param name="playerCardValues">all possible values for the current player cards</param>
        /// <param name="dealerCardValues">all possible values for the current dealer cards</param>
        /// <param name="valueVisible">are the dealer cards visible should only be used when someone has won</param>
        /// <param name="playerHasWon">should only be used when someone has won</param>
        public void setCardValues(List<int> playerCardValues, List<int> dealerCardValues, bool valueVisible = false)
        {
            _playerCardValues = "value" + (playerCardValues.Count > 1 ? "s:" : playerCardValues.Count > 0 ? ":" : ":\n0");
            foreach(int value in playerCardValues)
            {
                _playerCardValues += "\n" + value;
            }

            if (valueVisible)
            {
                _dealerCardValues = "value" + (dealerCardValues.Count > 1 ? "s: " : playerCardValues.Count > 0 ? ":" : ":\n0");
                foreach (int value in dealerCardValues)
                {
                    _dealerCardValues += "\n" + value;
                }
            }
            else
            {
                _dealerCardValues = "value:\n ?";
            }
        }

        public void draw(Graphics g)
        {
            drawCardValues(g);
            drawWins(g);
        }

        private void drawCardValues(Graphics g)
        {
            g.DrawString(_playerCardValues, gameFont, new SolidBrush(Color.White), VALUE_START_X, PLAYER_VALUE_START_Y);
            g.DrawString(_dealerCardValues, gameFont, new SolidBrush(Color.White), VALUE_START_X, DEALER_VALUE_START_Y);
        }

        private void drawWins(Graphics g)
        {
            g.DrawString("player: " + _playerScore, gameFont, new SolidBrush(Color.White), SCORE_START_X, SCORE_START_Y);
            g.DrawString("dealer: " + _dealerScore, gameFont, new SolidBrush(Color.White), SCORE_START_X , SCORE_START_Y + DIST_BETWEEN);
        }
    }
}
