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
            main = new Main(drawingPanel);//TODO
        }

        private void DrawCard_Click(object sender, EventArgs e)
        {
            main = new Main(drawingPanel);
        }

        private void Stop_Click(object sender, EventArgs e)
        {

        }
    }
}
