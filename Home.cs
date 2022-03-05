using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Quiz
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        #region Form Events
        private void Home_FormClosing(object sender, FormClosingEventArgs e)
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
        private void button1_Click(object sender, EventArgs e)
        {
            Quizlevel1 ql = new Quizlevel1();
            ql.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginPage lp = new LoginPage();
            lp.Show();
            this.Hide();
        }
        #endregion

       
    }
}
