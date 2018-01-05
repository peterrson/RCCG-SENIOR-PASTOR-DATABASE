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
    public partial class Award : Form
    {
        SqlConnection SqlCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\PETERRSON\Documents\Visual Studio 2010\Projects\ElderNatSecCgo\DB\database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

        public string Surname;
        public string OtherNames;
        public string RCCNO;
        public string YearLastPromoted;
        public string Designation;
        public string Age;
        public string GradeLevel;
        public string YearEmployed;
        public string YearAwarded;
        public Award()
        {
            InitializeComponent();
        }

        private void Award_Load_1(object sender, EventArgs e)
        {
            lblRCCNO.Text = RCCNO;
            lblSurname.Text = Surname;
            lblOtherNames.Text = OtherNames;
            txtYearLastPromoted.Text = YearLastPromoted;
            lblCurrentDesignation.Text = Designation;
            lblAge.Text = Age;
            txtGradeLevel.Text = GradeLevel;
            lblye.Text = YearEmployed;
            txtyaw.Text = YearAwarded;
        }

        private void btnAward_Click_1(object sender, EventArgs e)
        {

            string NewYearAwarded = "";
            DialogResult me = MessageBox.Show("Are you sure you want to  AWARD this Pastor", "RCCG",
         MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (me.ToString() == "Yes")
            {
                if (lblye.Text == "1998")
                {
                    NewYearAwarded = "2018";
                }
                try
                {

                    if (SqlCon.State == ConnectionState.Closed)
                        SqlCon.Open();
                    {
                        SqlCommand SqlCmd = new SqlCommand("UPDATE personal SET YearLastPromoted=@YearLastPromoted, Designation=@Designation, Age=@Age, GradeLevel=@GradeLevel, YearEmployed=@YearEmployed, YearAwarded=@YearAwarded WHERE RCCNO=@RCCNO", SqlCon);
                        SqlCmd.CommandType = CommandType.Text;
                        SqlCmd.Parameters.AddWithValue("@YearLastPromoted", txtYearLastPromoted.Text);
                        SqlCmd.Parameters.AddWithValue("@RCCNO", lblRCCNO.Text.Trim());
                        SqlCmd.Parameters.AddWithValue("@Designation", lblCurrentDesignation.Text.Trim());
                        SqlCmd.Parameters.AddWithValue("@Age", lblAge.Text.Trim());
                        SqlCmd.Parameters.AddWithValue("@GradeLevel", txtGradeLevel.Text.Trim());
                        SqlCmd.Parameters.AddWithValue("@YearEmployed", lblye.Text.Trim());
                        SqlCmd.Parameters.AddWithValue("@YearAwarded", NewYearAwarded);
                        SqlCmd.ExecuteNonQuery();
                        MessageBox.Show("Employee Awarded successfully");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message");
                }
                finally
                {
                    SqlCon.Close();
                }
            }
        }
    }
}
    


