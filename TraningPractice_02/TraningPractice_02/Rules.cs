using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraningPractice_02
{
    public partial class Rules : Form
    {
        public Rules()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            game.Owner = this;
            Hide();
            game.Show();
        }

        private void Rules_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Show();
        }
    }
}
