using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraningPractice_02.Rating_DBDataSetTableAdapters;

namespace TraningPractice_02
{
    public partial class Game : Form
    {
        int counter = 0;
        public Game()
        {
            InitializeComponent();
        }
        void label_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;

            if(label != null)
            {
                int number = int.Parse(label.Text);

                if (number != 51) { 
                    if (number == counter + 1)
                    {
                        label.BackColor = Color.White;
                        label.Enabled = false;
                        counter++;
                        lblMistake.Text = "";
                        lblLater.Text = "последнее нажатое число: " + counter;
                    }
                    else
                    {
                        lblMistake.Text = "Вы выбрали неверное число! Будьте внимательны!";
                    }
                }

                else 
                {
                    timer1.Stop();
                    var result = MessageBox.Show("Вы прошли игру!", "Поздравляем", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    btnExit.Visible = true;
                    btnRating.Visible = true;
                    ((DataRowView)((Registration)Owner.Owner).ratingUsersBindingSource[0])[3] = label1.Text;
                    Validate();
                    ((Registration)Owner.Owner).ratingUsersBindingSource.EndEdit();
                    ((Registration)Owner.Owner).tableAdapterManager.UpdateAll(((Registration)Owner.Owner).rating_DBDataSet);
                }
            }
        }

        private void btnRating_Click(object sender, EventArgs e)
        {
            Rating rating = new Rating();
            rating.Show();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private int m, s, ms;
        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Show();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ms++;
            s = ms / 10;
            m = s / 60;
            label1.Text = m + ":" + s % 60 + "." + ms % 10;
        }
    }
}
