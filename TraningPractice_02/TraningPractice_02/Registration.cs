using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraningPractice_02
{
    public partial class Registration : Form
    {
       public Registration()
        {
            InitializeComponent();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            ratingUsersBindingSource.Filter = $"Name = '{nameTextBox.Text}' and Surname = '{surnameTextBox.Text}'";
            if (ratingUsersBindingSource.Count == 0)
            {
                MessageBox.Show("Приветствуем новых пользователей!");
                ratingUsersBindingSource.AddNew();
                ((DataRowView)ratingUsersBindingSource[ratingUsersBindingSource.Count - 1])[1] = nameTextBox.Text;
                ((DataRowView)ratingUsersBindingSource[ratingUsersBindingSource.Count - 1])[2] = surnameTextBox.Text;
                ((DataRowView)ratingUsersBindingSource[ratingUsersBindingSource.Count - 1])[3] = -1;

                Validate();
                ratingUsersBindingSource.EndEdit();
                tableAdapterManager.UpdateAll(rating_DBDataSet);
            }
            else
            {
                MessageBox.Show("И снова здравствуй!");
            }
            Rules rules = new Rules();
            rules.Owner = this;
            Hide();
            rules.Show();
        }
        private void TextBoxesCheck(object sender, EventArgs e)
        {         
            if (((TextBox)sender).Text.Length > 0 && !"йцукенгшщзхъфывапролджэячсмитьбюё".Contains( ((TextBox)sender).Text.ToLower().Last() ))
            {
                int lastIndex = ((TextBox)sender).Text.Length - 1;
                ((TextBox)sender).Text = ((TextBox)sender).Text.Remove(lastIndex, 1);
                ((TextBox)sender).Select(lastIndex,0);
            }

            btnContinue.Enabled = nameTextBox.Text.Length > 0 && surnameTextBox.Text.Length > 0;
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "rating_DBDataSet.RatingUsers". При необходимости она может быть перемещена или удалена.
            this.ratingUsersTableAdapter.Fill(this.rating_DBDataSet.RatingUsers);
        }
    }
}
