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
    public partial class TypeMaster : Form
    {
        public TypeMaster()
        {
            InitializeComponent();
        }

        private void TypeMaster_Load(object sender, EventArgs e)
        {
            Populate();


        }
        private void Populate()
        {
            dgv_typeMaster.Rows.Clear();
            DataSet masterData = DataLayer.GetTypeMaster();
            foreach (DataRow row in masterData.Tables[0].Rows)
            {
                dgv_typeMaster.Rows.Add();
                dgv_typeMaster.Rows[dgv_typeMaster.Rows.Count - 1].Cells[0].Value = row["Id"];
                dgv_typeMaster.Rows[dgv_typeMaster.Rows.Count - 1].Cells[1].Value = row["TypeName"];
                PrepareRow(dgv_typeMaster.CurrentRow.Index);
            }
            dgv_typeMaster.Rows.Add();
            PrepareRow(dgv_typeMaster.CurrentRow.Index);
        }

        private void PrepareRow(int index)
        {
            
            dgv_typeMaster.Rows[index].Cells[2].Value = "Edit";
            dgv_typeMaster.Rows[index].Cells[3].Value = "Delete";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgv_typeMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 2: DisableEdit(dgv_typeMaster.CurrentCell.RowIndex, false); break;
                case 3: DeleteRow(dgv_typeMaster.CurrentCell.RowIndex); break;
            }
        }

        private void DisableEdit(int row, bool Disable)
        {
            if (!Disable && (row == dgv_typeMaster.Rows.Count - 1))
            {
                dgv_typeMaster.Rows.Add();
                PrepareRow(dgv_typeMaster.Rows.Count - 1);
            }
            dgv_typeMaster.Rows[row].Cells[1].ReadOnly = Disable;
            dgv_typeMaster.Rows[row].Cells[1].Style.BackColor = Disable ? Color.White : Color.Tan;
           
        }
        private void DeleteRow(int index)
        {
            dgv_typeMaster.Rows.RemoveAt(index);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (validateGridView())
            {
                DataLayer.clearData("TypeMaster");
                foreach (DataGridViewRow row in dgv_typeMaster.Rows)
                {
                    DataLayer.InsertTypeMasterData(row);
                }
                Populate();
               MessageBox.Show("Sucessfully Saved Data", "Success");
                
            }
        }
        private bool validateGridView()
        {
            foreach (DataGridViewRow row in dgv_typeMaster.Rows)
            {

                if (row.Cells[1].Value == null || row.Cells[1].Value.ToString() == string.Empty)
                {
                    MessageBox.Show("Enter Value of Type at Row " + (row.Index + 1), "Validation Failed");
                    row.Cells[1].Style.BackColor = Color.Red;
                    return false;
                }
            }
            return true;
        }

        private void dgv_typeMaster_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            DisableEdit(e.RowIndex, true);
        }
    }
}
