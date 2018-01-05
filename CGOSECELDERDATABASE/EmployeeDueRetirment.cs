using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CGOSECELDERDATABASE
{
    public partial class EmployeeDueRetirementList : Form
    {
        public DataTable dt = new DataTable();
        public EmployeeDueRetirementList()
        {
            InitializeComponent();
        }

        private void EmployeeDueRetirementList_Load(object sender, EventArgs e)
        {
            RetireeGrid.DataSource = dt;
        }
        private void RetireeGrid_DoubleClick(object sender, EventArgs e)
        {
            if (RetireeGrid.CurrentRow.Index != -1)
            {
                this.Hide();
                Retire ss = new Retire();
                ss.Surname = RetireeGrid.CurrentRow.Cells[0].Value.ToString();
                ss.OtherNames = RetireeGrid.CurrentRow.Cells[1].Value.ToString();
                ss.RCCNO = RetireeGrid.CurrentRow.Cells[2].Value.ToString();
                ss.YearLastPromoted = RetireeGrid.CurrentRow.Cells[3].Value.ToString();
                ss.Designation = RetireeGrid.CurrentRow.Cells[4].Value.ToString();
                ss.Age = RetireeGrid.CurrentRow.Cells[5].Value.ToString();
                ss.GradeLevel = RetireeGrid.CurrentRow.Cells[6].Value.ToString();
                ss.ShowDialog();
            }
        }
    }
}
