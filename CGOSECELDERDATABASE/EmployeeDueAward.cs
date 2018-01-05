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
    public partial class EmployeeDueAward : Form
    {
        public DataTable dt = new DataTable();
        public EmployeeDueAward()
        {
            InitializeComponent();
        }
        private void EmployeeDueAward_Load(object sender, EventArgs e)
        {
         AwardGrid.DataSource = dt;
       }

        private void AwardGrid_DoubleClick_1(object sender, EventArgs e)
        {
            if (AwardGrid.CurrentRow.Index != -1)
            {
                this.Hide();
                Award ss = new Award();
                ss.Surname = AwardGrid.CurrentRow.Cells[0].Value.ToString();
                ss.OtherNames = AwardGrid.CurrentRow.Cells[1].Value.ToString();
                ss.RCCNO = AwardGrid.CurrentRow.Cells[2].Value.ToString();
                ss.YearLastPromoted = AwardGrid.CurrentRow.Cells[3].Value.ToString();
                ss.Designation = AwardGrid.CurrentRow.Cells[4].Value.ToString();
                ss.Age = AwardGrid.CurrentRow.Cells[5].Value.ToString();
                ss.GradeLevel = AwardGrid.CurrentRow.Cells[6].Value.ToString();
                ss.YearEmployed = AwardGrid.CurrentRow.Cells[7].Value.ToString();
                ss.YearAwarded = AwardGrid.CurrentRow.Cells[8].Value.ToString();
                ss.ShowDialog();
            }
        }
    }
}
