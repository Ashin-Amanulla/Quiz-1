using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        #region Form Events
        private void AdminPanel_FormClosing(object sender, FormClosingEventArgs e)
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
        private void button4_Click(object sender, EventArgs e)
        {
            QuestionList ql = new QuestionList();
            ql.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoginPage lp = new LoginPage();
            lp.Show();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TypeMaster tm = new TypeMaster();
            tm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CategoryMaster cm = new CategoryMaster();
            cm.ShowDialog();
        }
        #endregion


    }
}
