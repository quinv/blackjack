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
            main = new Main(this);
            //click events are initialized after the creation of the methods
            this.drawCard.Click += new System.EventHandler(main._blackjackController.DrawCard);
            this.ChangeGameState.Click += new System.EventHandler(main._blackjackController.ChangeGameState);
        }

        
    }
}
