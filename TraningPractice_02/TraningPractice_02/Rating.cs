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
    public partial class Rating : Form
    {
        public Rating()
        {
            InitializeComponent();
        }
        private void Rating_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "rating_DBDataSet.RatingUsers". При необходимости она может быть перемещена или удалена.
            this.ratingUsersTableAdapter.Fill(this.rating_DBDataSet.RatingUsers);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {            
            Registration registration = new Registration();
            registration.Show();
        }
    }
}
