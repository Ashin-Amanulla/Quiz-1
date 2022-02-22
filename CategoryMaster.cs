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
    public partial class CategoryMaster : Form
    {
        public CategoryMaster()
        {
            InitializeComponent();
        }
        private void Populate()
        {
            dgv_CategoryMaster.Rows.Clear();
            DataSet masterData = DataLayer.GetCategoryMaster();
            foreach (DataRow row in masterData.Tables[0].Rows)
            {
                dgv_CategoryMaster.Rows.Add();
                dgv_CategoryMaster.Rows[dgv_CategoryMaster.Rows.Count - 1].Cells[0].Value = row["Id"];
                dgv_CategoryMaster.Rows[dgv_CategoryMaster.Rows.Count - 1].Cells[1].Value = row["CategoryName"];
                PrepareRow(dgv_CategoryMaster.CurrentRow.Index);
            }
            dgv_CategoryMaster.Rows.Add();
            PrepareRow(dgv_CategoryMaster.CurrentRow.Index);
        }

        private void PrepareRow(int index)
        {

            dgv_CategoryMaster.Rows[index].Cells[2].Value = "Edit";
            dgv_CategoryMaster.Rows[index].Cells[3].Value = "Delete";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

       
        private void DisableEdit(int row, bool Disable)
        {
            if (!Disable && (row == dgv_CategoryMaster.Rows.Count - 1))
            {
                dgv_CategoryMaster.Rows.Add();
                PrepareRow(dgv_CategoryMaster.Rows.Count - 1);
            }
            dgv_CategoryMaster.Rows[row].Cells[1].ReadOnly = Disable;
            dgv_CategoryMaster.Rows[row].Cells[1].Style.BackColor = Disable ? Color.White : Color.Tan;

        }
        private void DeleteRow(int index)
        {
            dgv_CategoryMaster.Rows.RemoveAt(index);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (validateGridView())
            {
                DataLayer.clearData("CategoryMaster");
                foreach (DataGridViewRow row in dgv_CategoryMaster.Rows)
                {
                    DataLayer.InsertCategoryMasterData(row);
                }
                Populate();
                MessageBox.Show("Sucessfully Saved Data", "Success");

            }
        }
        private bool validateGridView()
        {
            foreach (DataGridViewRow row in dgv_CategoryMaster.Rows)
            {

                if (row.Cells[1].Value == null || row.Cells[1].Value.ToString() == string.Empty)
                {
                    MessageBox.Show("Enter Value of Category at Row " + (row.Index + 1), "Validation Failed");
                    row.Cells[1].Style.BackColor = Color.Red;
                    return false;
                }
            }
            return true;
        }

     
        private void dgv_CategoryMaster_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            DisableEdit(e.RowIndex, true);
        }

        private void dgv_CategoryMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 2: DisableEdit(dgv_CategoryMaster.CurrentCell.RowIndex, false); break;
                case 3: DeleteRow(dgv_CategoryMaster.CurrentCell.RowIndex); break;
            }
        }

        private void CategoryMaster_Load(object sender, EventArgs e)
        {
            Populate();
        }
    }
}
