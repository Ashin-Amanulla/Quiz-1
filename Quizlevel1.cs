using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quiz.Library.Models;
using Newtonsoft.Json;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Data.SQLite;
using System.Diagnostics;

namespace Quiz
{
    public partial class Quizlevel1 : Form
    {
        public Quizlevel1()
        {
            InitializeComponent();
        }

        #region Global Variables
        /// <summary>
        /// Instance variable <c>x</c> represents the storing question data.
        /// </summary>
        List<QuestionViewDto> questions = new List<QuestionViewDto>();
        /// <summary>
        /// Instance variable <c>x</c>storing the color when radion button is selected.
        /// </summary>
        Color radioButtonSelected = Color.Coral;
        /// <summary>
        /// Instance variable <c>x</c>storing the color when radion button is not selected.
        /// </summary>
        Color radioButtonNormal = Color.SteelBlue;
        #endregion

        #region Form Events
        private void QuizLevel1_Load(object sender, EventArgs e)
        {
            
            using (var con = new SQLiteConnection("Data Source=Library/DB/memory.db"))
            {
                con.Open();
            }

            GetDataFromDatabase();
            PrepareForm();
            populateQuestion(1);
        }
        private void Quizlevel1_FormClosing(object sender, FormClosingEventArgs e)
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

        #region Helper Methods
        /// <summary>
        ///  This method stores data in the questions variable from the database
        /// </summary>
        private void GetDataFromDatabase()
        {
            DataSet x = DataLayer.DisplayData();
            int i = 1;
            foreach (DataRow row in x.Tables[0].Rows)
            {
                List<string> choice = new List<string>();
                choice.Add(row["choice1"].ToString());
                choice.Add(row["choice2"].ToString());
                if (row["type"].ToString() != "TrueOrFalse")
                {
                    choice.Add(row["choice3"].ToString());
                    choice.Add(row["choice4"].ToString());
                }
                QuestionViewDto question = new QuestionViewDto {
                    Id = i,
                    Question = row["question"].ToString(),
                    type = row["type"].ToString(),
                    Choices = choice,
                    CorrectChoice = row["correctchoice"].ToString(),
                    Image = ByteToImage(DataLayer.LoadImage(Int32.Parse(row["id"].ToString())))

                    };
                questions.Add(question);
                i++;
            }

        }
        /// <summary>
        ///  this method hides the radio button 
        /// </summary>
        private void PrepareChoice()
        {
            rb_choice1.Visible = false;
            rb_choice2.Visible = false;
            rb_choice3.Visible = false;
            rb_choice4.Visible = false;
        }
        /// <summary>
        ///  this method hides the finish button and adds tab buttons to the form
        /// </summary>
        private void PrepareForm()
        {
            btn_Finish.Visible = false;
            for (int i = 1; i <= questions.Count; i++)
            {
                AddTabButton(i);

            }
        }
        /// <summary>
        ///  this method clears the radio button selection
        /// </summary>
        private void ResetRadioButton()
        {
            rb_choice1.BackColor = radioButtonNormal;
            rb_choice1.Checked = false;
            rb_choice2.BackColor = radioButtonNormal;
            rb_choice2.Checked = false;
            rb_choice3.BackColor = radioButtonNormal;
            rb_choice3.Checked = false;
            rb_choice4.BackColor = radioButtonNormal;
            rb_choice4.Checked = false;

        }
        /// <summary>
        ///  this method controls the visiblity of next and previous buttons
        ///  according tho the question number
        /// </summary>
        /// <param name="questionNumber">the current question number.</param>
        private void PrepareTraverseButtons(int questionNumber)
        {
            if (questionNumber == 1)
            {
                btn_Previous.Visible = false;
            }
            else if (questionNumber == questions.Count)
            {
                btn_Next.Visible = false;
            }
            else
            {
                btn_Previous.Visible = true;
                btn_Next.Visible = true;
            }
        }
        /// <summary>
        ///  this method adds new tabbutton and its click event
        /// </summary>
        /// <param name=""="index">the index of new button.</param>
        private void AddTabButton(int index)
        {
            Button button = new Button();
            button.Height = 30;
            button.Width = 57;
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.GhostWhite;
            button.ForeColor = Color.Black;
            button.Text = index.ToString();
            button.Tag = index.ToString();
            button.Name = "tabButton" + index.ToString();
            button.AccessibleName = i.ToString();
            button.Font = new Font("Georgia", 12);
            tabButtonpanel.Controls.Add(button);
            button.Click += new EventHandler(TabButton_Click);
        }
        /// <summary>
        ///  this method checks if the Quiz is finished 
        ///  and makes Finish button visible if finished
        ///  </summary>
        private void CheckFinish()
        {
            if (questions.Where(x => x.RadioButtonIndex == 0).Count() == 0)
            {
                btn_Finish.Visible = true;
            }
        }
        /// <summary>
        /// This method valid byte array to Image
        /// </summary>
        /// <param name="imageBytes">the byte array data for image</param>
        /// <returns>image if valid byte array else null </returns>
        public Image ByteToImage(byte[] imageBytes)
        {
            if (imageBytes != null && imageBytes.Length > 0)
            {             // Convert byte[] to Image
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = new Bitmap(ms);
                return image;
            }
            else
                return null;
        }
        #endregion

        #region Button Events 
        private void button1_Click(object sender, EventArgs e)
        {
            populateQuestion(Int32.Parse(lbl_Question.Tag.ToString()) - 1);
        }
        private void btn_Next_Click(object sender, EventArgs e)
        {
            populateQuestion(Int32.Parse(lbl_Question.Tag.ToString()) + 1);
        }
        private void TabButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ResetRadioButton();
            populateQuestion(Int32.Parse(button.Text));

        }
        private void btn_Finish_Click(object sender, EventArgs e)
        {
            QuizResult quizResult = new QuizResult(questions, this);
            quizResult.Show();
            this.Hide();
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            Home fm = new Home();
            fm.Show();
            this.Dispose();
            this.Close();
        }
        #endregion

        #region RadioButton Events
        private void ChoiceChange(object sender, EventArgs e)
        {

            RadioButton choice = sender as RadioButton;
            if (choice.Checked)
            {
                choice.BackColor = radioButtonSelected;
                var currentQuestion = questions.FirstOrDefault(x => x.Id == Int32.Parse(lbl_Question.Tag.ToString()));
                currentQuestion.RadioButtonIndex = Int32.Parse(choice.Tag.ToString());
                currentQuestion.CurrentChoice = choice.Text;
                Button currentTab = (Button)this.Controls.Find("tabButton" + currentQuestion.Id, true).FirstOrDefault();
                currentTab.BackColor = Color.Yellow;
               
                
            }
            else
            {
                choice.BackColor = radioButtonNormal;
            }
            CheckFinish();
        }
        #endregion

        #region Main Methods
        /// <summary>
        /// This method populates the question and  answers.
        /// </summary>
        private void populateQuestion(int questionNumber)
        {
            
                PrepareChoice();
                PrepareTraverseButtons(questionNumber);

                var question = questions.Where(x => x.Id == questionNumber).FirstOrDefault();
                lbl_Question.Text = question.Question;
                lbl_Question.Tag = question.Id;
                lbl_QuestionNumber.Text = "Question " + question.Id;
                int i = 0;
                foreach (var choice in question.Choices)
                {
                    i++;
                    var radioButton = new RadioButton();
                    switch (i)
                    {
                        case 1: radioButton = this.rb_choice1; break;
                        case 2: radioButton = this.rb_choice2; break;
                        case 3: radioButton = this.rb_choice3; break;
                        case 4: radioButton = this.rb_choice4; break;
                    }

                    radioButton.Text = choice;
                    radioButton.Visible = true;
                    radioButton.Checked = false;
                    if (question.RadioButtonIndex == Int32.Parse(radioButton.Tag.ToString()))
                    {
                        radioButton.Checked = true;
                        radioButton.BackColor = radioButtonSelected;
                    }

                }
                if (question.Image == null)
                {
                    pictureBox1.Visible = false;
                    TableLayoutColumnStyleCollection styles = this.tableLayoutPanel3.ColumnStyles;
                    styles[0].SizeType = SizeType.Percent;
                    styles[0].Width = 20;
                }
                else
                {
                    pictureBox1.Visible = true;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    TableLayoutColumnStyleCollection styles = this.tableLayoutPanel3.ColumnStyles;
                    styles[0].SizeType = SizeType.Percent;
                    styles[0].Width = 80;
                    var imageLibrarypath = ConfigurationSettings.AppSettings["ImageLibPath"].ToString();
                    pictureBox1.Image = question.Image;
                }
            



        }


        #endregion

    }
}
