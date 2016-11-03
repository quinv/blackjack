using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack
{
    public partial class Form1 : Form
    {
        Main main;
        public Form1()
        {
            InitializeComponent();
            drawingPanel.Width = ClientSize.Width;
            drawingPanel.Height = ClientSize.Height;
            main = new Main(drawingPanel);
            UpdateUI();
        }

        private void DrawCard_Click(object sender, EventArgs e)
        {
            main.playerHand.GetCard(Hand._Deck);
            if (Logics.getTotalValues(main.dealerHand.Cards)[0] <= 21)
            {
                main.dealerHand.GetCard(Hand._Deck);
            }
            UpdateUI();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if (Logics.getTotalValues(main.dealerHand.Cards)[0] <= 21)
            {
                main.dealerHand.GetCard(Hand._Deck);
                UpdateUI();
            }
            DisableButtons();
            //check results
        }

        private void UpdateUI()
        {
            main._mainUI.cardUI.PlaceCards(main.playerHand.Cards, main.dealerHand.Cards, false);
            main._mainUI.scoreUI.setCardValues(Logics.getTotalValues(main.playerHand.Cards), Logics.getTotalValues(main.dealerHand.Cards), false, false);
        }

        private void DisableButtons()
        {
            stop.Enabled = false;
            drawCard.Enabled = false;
        }
    }
}
