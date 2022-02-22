using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Environment.Exit(0);
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Quizlevel1 ql = new Quizlevel1();
            ql.Show();
            this.Hide();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (tb_Password.Text == string.Empty || tb_username.Text == string.Empty)
            {
                MessageBox.Show("Username or Password Empty", "Error");
            }
            else if (DataLayer.Login(tb_username.Text, DataLayer.CreateMD5(tb_Password.Text)))
            {
                AdminPanel ap = new AdminPanel();
                ap.Show();
                this.Hide();
            }
            else {
                MessageBox.Show("Username or Password Wrong", "Error");
            }
        }
    }
}
