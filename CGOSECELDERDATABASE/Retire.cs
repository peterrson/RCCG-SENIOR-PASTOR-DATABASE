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
    public partial class Retire : Form
    {
        SqlConnection SqlCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\PETERRSON\Documents\Visual Studio 2010\Projects\ElderNatSecCgo\DB\database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

        public string Surname;
        public string OtherNames;
        public string RCCNO;
        public string YearLastPromoted;
        public string Designation;
        public string Age;
        public string GradeLevel;
        public Retire()
        {
            InitializeComponent();
        }
        private void Retire_Load_1(object sender, EventArgs e)
        {
            lblRCCNO.Text = RCCNO;
            lblSurname.Text = Surname;
            lblOtherNames.Text = OtherNames;
            lblylp.Text = YearLastPromoted;
            lblCurrentDesignation.Text = Designation;
            lblDateofBirth.Text = Age;
            lblgl.Text = GradeLevel;
        }

        private void btnRetire_Click_1(object sender, EventArgs e)
        {

            string NewDesignation = "";
            DialogResult me = MessageBox.Show("Are you sure you want to  Retire this employee", "RCCG",
         MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (me.ToString() == "Yes")
            {
                
                NewDesignation = "RETIRED";
                
                              
                try
                {

                    if (SqlCon.State == ConnectionState.Closed)
                        SqlCon.Open();
                    {
                        SqlCommand SqlCmd = new SqlCommand("UPDATE personal SET YearLastPromoted=@YearLastPromoted, Designation=@Designation, Age=@Age, GradeLevel=@GradeLevel WHERE RCCNO=@RCCNO", SqlCon);
                        SqlCmd.CommandType = CommandType.Text;
                        SqlCmd.Parameters.AddWithValue("@YearLastPromoted", lblylp.Text.Trim());
                        SqlCmd.Parameters.AddWithValue("@RCCNO", lblRCCNO.Text.Trim());
                        SqlCmd.Parameters.AddWithValue("@Designation", NewDesignation);
                        SqlCmd.Parameters.AddWithValue("@Age", lblDateofBirth.Text.Trim());
                        SqlCmd.Parameters.AddWithValue("@GradeLevel", lblgl.Text);
                        SqlCmd.ExecuteNonQuery();
                        MessageBox.Show("Employee Retired successfully");
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

