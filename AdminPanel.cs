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
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

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
    }
}
