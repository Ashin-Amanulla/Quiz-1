using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Quiz
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        #region Form Events
        private void LoginPage_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Do you really want to exit?", "Dialog Title", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Process.GetCurrentProcess().Kill();
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }

        }
        #endregion

        #region Button Events
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
        private void button1_Click_1(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }
        #endregion
    }
}
