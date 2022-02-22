namespace Quiz
{
    partial class QuestionList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_QuestionDisplay = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.questionNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.question = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.Choice1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.choice2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.choice3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.choice4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correctChoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_QuestionDisplay)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_QuestionDisplay
            // 
            this.dgv_QuestionDisplay.AllowUserToAddRows = false;
            this.dgv_QuestionDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_QuestionDisplay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_QuestionDisplay.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgv_QuestionDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_QuestionDisplay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.questionNo,
            this.question,
            this.category,
            this.Type,
            this.Image,
            this.Choice1,
            this.choice2,
            this.choice3,
            this.choice4,
            this.correctChoice,
            this.edit,
            this.delete,
            this.Id});
            this.dgv_QuestionDisplay.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_QuestionDisplay.Location = new System.Drawing.Point(3, 3);
            this.dgv_QuestionDisplay.Name = "dgv_QuestionDisplay";
            this.dgv_QuestionDisplay.Size = new System.Drawing.Size(1398, 646);
            this.dgv_QuestionDisplay.TabIndex = 0;
            this.dgv_QuestionDisplay.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_QuestionDisplay_CellClick);
            this.dgv_QuestionDisplay.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_QuestionDisplay_RowLeave);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackgroundImage = global::Quiz.Properties.Resources._2314950;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgv_QuestionDisplay, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, -1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1404, 725);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btn_back
            // 
            this.btn_back.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_back.Location = new System.Drawing.Point(993, 3);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(217, 34);
            this.btn_back.TabIndex = 2;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.Location = new System.Drawing.Point(1216, 3);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(179, 34);
            this.btn_save.TabIndex = 1;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 223F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 184F));
            this.tableLayoutPanel2.Controls.Add(this.btn_save, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_back, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 682);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1398, 40);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // questionNo
            // 
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.White;
            this.questionNo.DefaultCellStyle = dataGridViewCellStyle25;
            this.questionNo.HeaderText = "Question Number";
            this.questionNo.Name = "questionNo";
            this.questionNo.ReadOnly = true;
            // 
            // question
            // 
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.White;
            this.question.DefaultCellStyle = dataGridViewCellStyle26;
            this.question.HeaderText = "Question";
            this.question.Name = "question";
            this.question.ReadOnly = true;
            // 
            // category
            // 
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.White;
            this.category.DefaultCellStyle = dataGridViewCellStyle27;
            this.category.HeaderText = "Category";
            this.category.Name = "category";
            this.category.ReadOnly = true;
            this.category.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.category.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Type
            // 
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.White;
            this.Type.DefaultCellStyle = dataGridViewCellStyle28;
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Image
            // 
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle29.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle29.NullValue")));
            this.Image.DefaultCellStyle = dataGridViewCellStyle29;
            this.Image.HeaderText = "Image";
            this.Image.Name = "Image";
            this.Image.ReadOnly = true;
            this.Image.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Image.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Choice1
            // 
            dataGridViewCellStyle30.BackColor = System.Drawing.Color.White;
            this.Choice1.DefaultCellStyle = dataGridViewCellStyle30;
            this.Choice1.HeaderText = "Choice1";
            this.Choice1.Name = "Choice1";
            this.Choice1.ReadOnly = true;
            this.Choice1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Choice1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // choice2
            // 
            dataGridViewCellStyle31.BackColor = System.Drawing.Color.White;
            this.choice2.DefaultCellStyle = dataGridViewCellStyle31;
            this.choice2.HeaderText = "Choice2";
            this.choice2.Name = "choice2";
            this.choice2.ReadOnly = true;
            // 
            // choice3
            // 
            dataGridViewCellStyle32.BackColor = System.Drawing.Color.White;
            this.choice3.DefaultCellStyle = dataGridViewCellStyle32;
            this.choice3.HeaderText = "Choice3";
            this.choice3.Name = "choice3";
            this.choice3.ReadOnly = true;
            // 
            // choice4
            // 
            dataGridViewCellStyle33.BackColor = System.Drawing.Color.White;
            this.choice4.DefaultCellStyle = dataGridViewCellStyle33;
            this.choice4.HeaderText = "Choice4";
            this.choice4.Name = "choice4";
            this.choice4.ReadOnly = true;
            // 
            // correctChoice
            // 
            dataGridViewCellStyle34.BackColor = System.Drawing.Color.White;
            this.correctChoice.DefaultCellStyle = dataGridViewCellStyle34;
            this.correctChoice.HeaderText = "Correct Choice";
            this.correctChoice.Name = "correctChoice";
            this.correctChoice.ReadOnly = true;
            // 
            // edit
            // 
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle35.BackColor = System.Drawing.Color.White;
            this.edit.DefaultCellStyle = dataGridViewCellStyle35;
            this.edit.HeaderText = "";
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.edit.Text = "Edit";
            this.edit.UseColumnTextForButtonValue = true;
            // 
            // delete
            // 
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle36.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle36.ForeColor = System.Drawing.Color.Black;
            this.delete.DefaultCellStyle = dataGridViewCellStyle36;
            this.delete.HeaderText = "";
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.delete.Text = "Delete";
            this.delete.UseColumnTextForButtonValue = true;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // QuestionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1403, 722);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "QuestionList";
            this.Text = "QuestionList";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.QuestionList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_QuestionDisplay)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_QuestionDisplay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.DataGridViewTextBoxColumn questionNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn question;
        private System.Windows.Forms.DataGridViewComboBoxColumn category;
        private System.Windows.Forms.DataGridViewComboBoxColumn Type;
        private System.Windows.Forms.DataGridViewImageColumn Image;
        private System.Windows.Forms.DataGridViewTextBoxColumn Choice1;
        private System.Windows.Forms.DataGridViewTextBoxColumn choice2;
        private System.Windows.Forms.DataGridViewTextBoxColumn choice3;
        private System.Windows.Forms.DataGridViewTextBoxColumn choice4;
        private System.Windows.Forms.DataGridViewTextBoxColumn correctChoice;
        private System.Windows.Forms.DataGridViewButtonColumn edit;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
    }
}