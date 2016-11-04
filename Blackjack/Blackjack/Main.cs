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
    public class Main
    {
        public MainUI _mainUI;
        public BlackjackController _blackjackController;
        public Form1 _form;

        public Main(Form1 form)
        {
            _form = form;
            _mainUI = new MainUI(this);
            _blackjackController = new BlackjackController(this);
        }
    }
}
