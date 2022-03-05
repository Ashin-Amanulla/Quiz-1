using Quiz.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;

namespace Quiz
{
    public partial class QuizResult : Form
    {
        #region Global Variables
        Quizlevel1 QuizInterfaceInstance;
        List<QuestionViewDto> results = new List<QuestionViewDto>();
        #endregion

        #region Form Events
        public QuizResult(List<QuestionViewDto> questionsResult,Quizlevel1 obj)
        {
            InitializeComponent();
            results = questionsResult;
            QuizInterfaceInstance = obj;
        }
        private void QuizResult_Load(object sender, EventArgs e)
        {
            PopulateForm();
           
        }
        private void QuizResult_FormClosing(object sender, FormClosingEventArgs e)
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
        private void btn_Repeat_Click(object sender, EventArgs e)
        {
            Quizlevel1 quiz = new Quizlevel1();
            quiz.Show();
            this.Dispose();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Home fm = new Home();
            fm.Show();
            this.Dispose();
        }
        #endregion

        #region Main Methods
        /// <summary>
        /// This method populates the gridview with the result data.
        /// </summary>
        private void PopulateForm()
        {
            var imageLibrarypath = ConfigurationSettings.AppSettings["ImageLibPath"].ToString();
            var correctResultImage = ConfigurationSettings.AppSettings["CorrectResultImage"].ToString();
            var incorrectResultImage = ConfigurationSettings.AppSettings["IncorrectResultImage"].ToString();
            lbl_score.Text = results.Where(x => x.CorrectChoice == x.CurrentChoice).Count() + "out of " + results.Count + "Correct";
            foreach (var result in results)
            {
                if (result.CorrectChoice == result.CurrentChoice)
                {
                    result.ResultImage = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + imageLibrarypath + correctResultImage);
                }
                else
                {
                    result.ResultImage = (Bitmap)Bitmap.FromFile(AppDomain.CurrentDomain.BaseDirectory + imageLibrarypath + incorrectResultImage);
                }
                dgv_result.AutoGenerateColumns = true;
                dgv_result.Rows.Add(result.Id, result.Question, result.CorrectChoice, result.CurrentChoice, result.ResultImage);
            }
        }
        #endregion

      
    }
}
