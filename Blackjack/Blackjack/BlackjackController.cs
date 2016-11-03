using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Blackjack
{
    public class BlackjackController
    {

        private Main _main;
        private bool turnCards = false;
        private int playerScore = 0, dealerScore = 0;

        private Hand playerHand = new Hand();
        private Hand dealerHand = new Hand();

        private Button btnDrawCard = null, btnChangeGameState = null;
        private string stop = "stop", restart = "restart";
        private string gameState;

        public BlackjackController(Main main)
        {
            _main = main;
            btnDrawCard = main._form.drawCard;
            btnChangeGameState = main._form.ChangeGameState;
            gameState = stop;
            UpdateUI();
        }

        public void DrawCard(object sender, EventArgs e)
        {
            if (Logics.getTotalValues(playerHand.Cards).Min() <= 21)
            {
                playerHand.GetCard(Hand._Deck);

                if (Logics.getTotalValues(dealerHand.Cards).Min() <= 17) // dealer stops at 17
                {
                    dealerHand.GetCard(Hand._Deck);
                }
            }
            if(Logics.getTotalValues(playerHand.Cards).Min() > 21)
            {
                GetWinner();
            }
            UpdateUI();
        }

        public void ChangeGameState(object sender, EventArgs e)
        {

            if (gameState == stop)
            {
                while (Logics.getTotalValues(dealerHand.Cards).Min() <= 17) // dealer keeps getting cards until he reaches 17 or more
                {
                    dealerHand.GetCard(Hand._Deck);
                }

                GetWinner();
            }
            else if(gameState == restart)
            {
                turnCards = false;
                btnDrawCard.Enabled = true;
                dealerHand.Initialize();
                playerHand.Initialize();
                btnChangeGameState.Text = gameState = stop;
            }
            UpdateUI();
        }

        private void UpdateUI()
        {
            _main._mainUI.cardUI.PlaceCards(playerHand.Cards, dealerHand.Cards, turnCards);
            _main._mainUI.scoreUI.setCardValues(Logics.getTotalValues(playerHand.Cards), Logics.getTotalValues(dealerHand.Cards), turnCards);
        }

        private void DisableButtons()
        {
            //stop.Enabled = false;
            //drawCard.Enabled = false;
        }
        

        private int GetBestScore(List<int> scoreList)
        {
            int bestScore = -1;
            foreach (int score in scoreList)
            {
                if(bestScore == -1||(score > bestScore && score <= 21))
                {
                    bestScore = score;
                }
            }
            if(bestScore > 21)
            {
                bestScore = -1;
            }
            return bestScore;
        }

        private void SetScore(int playerPoints, int dealerPoints)
        {
            playerScore += playerPoints;
            dealerScore += dealerPoints;
            _main._mainUI.scoreUI.setScore(playerScore, dealerScore);
        }

        private void GetWinner()
        {
            int bestPlayerScore = GetBestScore(Logics.getTotalValues(playerHand.Cards)),
                bestDealerScore = GetBestScore(Logics.getTotalValues(dealerHand.Cards));

            if (bestPlayerScore > bestDealerScore)
            {
                SetScore(1, 0);
            }
            else if (bestPlayerScore < bestDealerScore)
            {
                SetScore(0, 1);
            }
            else if (bestPlayerScore == bestDealerScore)
            {
                SetScore(0, 0);
            }

            turnCards = true;
            btnDrawCard.Enabled = false;
            btnChangeGameState.Text = gameState = restart;
        }
    }
}
