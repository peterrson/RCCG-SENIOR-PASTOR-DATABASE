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
    public partial class Promote : Form
    {
        SqlConnection SqlCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\PETERRSON\Documents\Visual Studio 2010\Projects\ElderNatSecCgo\DB\database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

        public string Surname;
        public string OtherNames;
        public string RCCNO;
        public string YearLastPromoted;
        public string Designation;
        public string Age;
        public string GradeLevel;
        public Promote()
        {
            InitializeComponent();
        }

        private void Promote_Load(object sender, EventArgs e)
        {
            lblRCCNO.Text = RCCNO;
            lblSurname.Text = Surname;
            lblOtherNames.Text = OtherNames;
            txtYearLastPromoted.Text = YearLastPromoted;
            lblCurrentDesignation.Text = Designation;
            lblAge.Text = Age;
            txtGradeLevel.Text = GradeLevel;
        }

        private void btnPromote_Click(object sender, EventArgs e)
        {

            string NewDesignation = "";
            DialogResult me = MessageBox.Show("Are you sure you want to  promote this employee", "RCCG",
         MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (me.ToString() == "Yes")
            {
                if (lblCurrentDesignation.Text == "CGO 2")
                {
                    NewDesignation = "CGO 1";
                }
                else if (lblCurrentDesignation.Text == "CGO 1")
                {
                    NewDesignation = "SEC 2";

                }
                else if (lblCurrentDesignation.Text == "SEC 2")
                {
                    NewDesignation = "SEC 1";
                }
                else if (lblCurrentDesignation.Text == "SEC 1")
                {
                    NewDesignation = "ASST ELDER";
                }
                else if (lblCurrentDesignation.Text == "ASST ELDER")
                {
                    NewDesignation = "ELDER";
                }
                try
                {

                    if (SqlCon.State == ConnectionState.Closed)
                        SqlCon.Open();
                    {
                        SqlCommand SqlCmd = new SqlCommand("UPDATE personal SET YearLastPromoted=@YearLastPromoted, Designation=@Designation, Age=@Age, GradeLevel=@GradeLevel WHERE RCCNO=@RCCNO", SqlCon);
                        SqlCmd.CommandType = CommandType.Text;
                        SqlCmd.Parameters.AddWithValue("@YearLastPromoted", txtYearLastPromoted.Text);
                        SqlCmd.Parameters.AddWithValue("@RCCNO", lblRCCNO.Text.Trim());
                        SqlCmd.Parameters.AddWithValue("@Designation", NewDesignation);
                        SqlCmd.Parameters.AddWithValue("@Age", lblAge.Text.Trim());
                        SqlCmd.Parameters.AddWithValue("@GradeLevel", txtGradeLevel.Text.Trim());
                        SqlCmd.ExecuteNonQuery();
                        MessageBox.Show("Employee promoted successfully");
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

