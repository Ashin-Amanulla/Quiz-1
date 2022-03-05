using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Quiz
{
    public partial class QuestionList : Form
    {
        public QuestionList()
        {
            InitializeComponent();
            
        }

        #region Form Events
        private void QuestionList_Load(object sender, EventArgs e)
        {
            populate();
        }
        private void QuestionList_FormClosing(object sender, FormClosingEventArgs e)
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
        private void populate()
        {
            dgv_QuestionDisplay.Rows.Clear();
            var data = DataLayer.DisplayData(true);
            var typeMasterData = DataLayer.GetTypeMaster();
            var categoryMasterData = DataLayer.GetCategoryMaster();

            foreach (DataRow row in typeMasterData.Tables[0].Rows)
            {
                (dgv_QuestionDisplay.Columns[3] as DataGridViewComboBoxColumn).Items.Add(row[1].ToString());
            }

            foreach (DataRow row in categoryMasterData.Tables[0].Rows)
            {
                (dgv_QuestionDisplay.Columns[2] as DataGridViewComboBoxColumn).Items.Add(row[1].ToString());
            }
            int i = 1;
            foreach (DataRow row in data.Tables[0].Rows)
            {
                dgv_QuestionDisplay.Rows.Add();
                dgv_QuestionDisplay.Rows[dgv_QuestionDisplay.Rows.Count - 1].Cells[12].Value = row["Id"];
                dgv_QuestionDisplay.Rows[dgv_QuestionDisplay.Rows.Count - 1].Cells[0].Value = i;
                dgv_QuestionDisplay.Rows[dgv_QuestionDisplay.Rows.Count - 1].Cells[1].Value = row["Question"];
                dgv_QuestionDisplay.Rows[dgv_QuestionDisplay.Rows.Count - 1].Cells[4].Value = ByteToImage(DataLayer.LoadImage(Int32.Parse(row["id"].ToString())));
                dgv_QuestionDisplay.Rows[dgv_QuestionDisplay.Rows.Count - 1].Cells[2].Value = row["category"];
                dgv_QuestionDisplay.Rows[dgv_QuestionDisplay.Rows.Count - 1].Cells[3].Value = row["type"];
                dgv_QuestionDisplay.Rows[dgv_QuestionDisplay.Rows.Count - 1].Cells[5].Value = row["choice1"];
                dgv_QuestionDisplay.Rows[dgv_QuestionDisplay.Rows.Count - 1].Cells[6].Value = row["choice2"];
                dgv_QuestionDisplay.Rows[dgv_QuestionDisplay.Rows.Count - 1].Cells[7].Value = row["choice3"];
                dgv_QuestionDisplay.Rows[dgv_QuestionDisplay.Rows.Count - 1].Cells[8].Value = row["choice4"];
                dgv_QuestionDisplay.Rows[dgv_QuestionDisplay.Rows.Count - 1].Cells[9].Value = row["correctchoice"];
                i++;
                PrepareRow(dgv_QuestionDisplay.Rows.Count - 1);


            }
            dgv_QuestionDisplay.Rows.Add();
            PrepareRow(dgv_QuestionDisplay.Rows.Count - 1);

        }
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
        public byte[] ImageToByte(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            if (image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // Convert Image to byte[]
                    image.Save(ms, format);
                    byte[] imageBytes = ms.ToArray();
                    return imageBytes;
                }
            }
            return null;
        }
        private void SelectImage(int rowIndex, int columnIndex)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Image photo = new Bitmap(dialog.FileName);
                dgv_QuestionDisplay[columnIndex, rowIndex].Value = Bitmap.FromFile(dialog.FileName);

            }
        }
        private void PreviewImage()
        {
            try
            {
                using (Form form = new Form())
                {
                    Bitmap img = (Bitmap)dgv_QuestionDisplay.CurrentRow.Cells[4].Value;

                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.Size = img.Size;
                    form.AutoSize = true;


                    PictureBox pb = new PictureBox();
                    pb.Dock = DockStyle.Fill;
                    pb.Image = img;

                    form.Controls.Add(pb);
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could not load image");
            }
        }
        private void ProcessImage()
        {
            if (!dgv_QuestionDisplay.CurrentCell.ReadOnly)
            {
                SelectImage(dgv_QuestionDisplay.CurrentCell.RowIndex, dgv_QuestionDisplay.CurrentCell.ColumnIndex);
            }
            else if (dgv_QuestionDisplay.CurrentCell.Value != null)
            {
                PreviewImage();
            }
        }
        private bool ValidateGridView()
        {
            foreach (DataGridViewRow row in dgv_QuestionDisplay.Rows)
            {

                if (row.Cells[1].Value == null || row.Cells[1].Value.ToString() == string.Empty)
                {
                    MessageBox.Show("Enter Value of Question at Row " + (row.Index + 1), "Validation Failed");
                    row.Cells[1].Style.BackColor = Color.Red;
                    return false;
                }
                if (row.Cells[2].Value == null || row.Cells[2].Value.ToString() == string.Empty)
                {
                    MessageBox.Show("Select Value of Catogory at Row " + (row.Index + 1), "Validation Failed");
                    return false;
                }
                if (row.Cells[3].Value == null || row.Cells[3].Value.ToString() == string.Empty)
                {
                    MessageBox.Show("Select Value of type at Row " + (row.Index + 1), "Validation Failed");
                    return false;
                }
                if (row.Cells[5].Value == null || row.Cells[5].Value.ToString() == string.Empty)
                {
                    MessageBox.Show("Enter Value of Choice1 at Row " + (row.Index + 1), "Validation Failed");
                    return false;
                }
                if (row.Cells[6].Value == null || row.Cells[6].Value.ToString() == string.Empty)
                {
                    MessageBox.Show("Enter Value of Choice2 at Row " + (row.Index + 1), "Validation Failed");
                    return false;
                }
                if ((row.Cells[7].Value == null || row.Cells[7].Value.ToString() == string.Empty) && row.Cells[3].Value.ToString() != "TrueOrFalse")
                {
                    MessageBox.Show("Enter Value of Choice3 at Row " + (row.Index + 1), "Validation Failed");
                    return false;
                }
                if ((row.Cells[8].Value == null || row.Cells[8].Value.ToString() == string.Empty) && row.Cells[3].Value.ToString() != "TrueOrFalse")
                {
                    MessageBox.Show("Enter Value of Choice4 at Row " + (row.Index + 1), "Validation Failed");
                    return false;
                }
                if ((row.Cells[9].Value == null || row.Cells[9].Value.ToString() == string.Empty))
                {
                    MessageBox.Show("Enter Value of Correct Choice at Row " + (row.Index + 1), "Validation Failed");
                    return false;
                }

            }
            return true;
        }
        private void DisableEdit(int row, bool Disable)
        {
            if (!Disable && (row == dgv_QuestionDisplay.Rows.Count - 1))
            {
                dgv_QuestionDisplay.Rows.Add();
                PrepareRow(dgv_QuestionDisplay.Rows.Count - 1);
            }
            for (int i = 1; i <= 9; i++)
            {
                dgv_QuestionDisplay.Rows[row].Cells[i].ReadOnly = Disable;
                dgv_QuestionDisplay.Rows[row].Cells[i].Style.BackColor = Disable ? Color.White : Color.Tan;
            }
        }
        private void PrepareRow(int index)
        {
            if (dgv_QuestionDisplay.Rows[index].Cells[0].Value == string.Empty || dgv_QuestionDisplay.Rows[index].Cells[0].Value == null)
                dgv_QuestionDisplay.Rows[index].Cells[0].Value = index + 1;
            dgv_QuestionDisplay.Rows[index].Cells[10].Value = "Edit";
            dgv_QuestionDisplay.Rows[index].Cells[11].Value = "Delete";

        }
        private void DeleteRow(int index)
        {
            dgv_QuestionDisplay.Rows.RemoveAt(index);
        }

        #endregion

        #region Button Events
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (ValidateGridView())
            {
                DataLayer.clearData("Quiz");
                foreach (DataGridViewRow row in dgv_QuestionDisplay.Rows)
                {
                    byte[] pic = ImageToByte((Image)row.Cells[4].Value, System.Drawing.Imaging.ImageFormat.Jpeg);
                    DataLayer.InsertData(row, pic);
                }
                populate();
                MessageBox.Show("Sucessfully Saved Data", "Success");
            }


        }
        private void btn_back_Click(object sender, EventArgs e)
        {
            AdminPanel fm = new AdminPanel();
            fm.Show();
            this.Dispose();
        }
        #endregion

        #region Data Grid View Events
        private void dgv_QuestionDisplay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                dgv_QuestionDisplay.Rows[e.RowIndex].Cells[0].Value = dgv_QuestionDisplay.Rows[e.RowIndex].Cells[0].Value ?? e.RowIndex.ToString();
                switch (e.ColumnIndex)
                {
                    case 4:
                        ProcessImage();
                        break;
                    case 10:
                        DisableEdit(dgv_QuestionDisplay.CurrentCell.RowIndex, false);
                        break;
                    case 11:
                        DeleteRow(dgv_QuestionDisplay.CurrentCell.RowIndex);
                        break;

                }
            }
            
        }
        private void dgv_QuestionDisplay_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            DisableEdit(e.RowIndex, true);
        }
        #endregion





    }
}
