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
    public partial class Form3 : Form
    {
        SqlConnection SqlCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\PETERRSON\Documents\Visual Studio 2010\Projects\ElderNatSecCgo\DB\database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        int personalid = 0;
        string gender;
        public Form3()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 ss = new Form2();
            (ss).ShowDialog();
        }
        private void btnsave_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (SqlCon.State == ConnectionState.Closed)
                    SqlCon.Open();
                if (btnsave.Text == "Save")
                {
                    SqlCommand SqlCmd = new SqlCommand("personalAddorEdit", SqlCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@mode", "Add");
                    SqlCmd.Parameters.AddWithValue("@personalid", 0);
                    SqlCmd.Parameters.AddWithValue("@surname", txtsur.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@othernames", txton.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@designation", txtdes.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@rccno", txtrcc.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@yearlastpromoted", txtylp.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@dateofbirth", txtdb.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@Age", txtage.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@stateoforigin", txtso.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@yearemployed", txtde.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@presentlocation", txtpl.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@dateoflastPosting", txtdlp.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@languagesspoken", txtls.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@gender", gender);
                    SqlCmd.Parameters.AddWithValue("@gradelevel", txtgl.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@yearawarded", txtya.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@phonenumber", txtpn.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@email", txtmail.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@ordinationstatus", txtos.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@maritalstatus", txtms.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@nationality", txtnat.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@hometown", txtht.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@typeofmarriage", txttm.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@dateofmarriage", txtdm.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@residentialaddress", txtra.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@pensionname", txtpen.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@rsapin", txtrsa.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@state", txtstate.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@country", txtcountry.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@relationship", txtRel.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@telephonenumber", txtTel.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateJoinRCCG", txtDJR.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateBornAgain", txtDBA.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@Region", txtReg.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@PresentProvince", txtPP.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateOrdainedAsAssistantPastor", txtDOAP.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateOrdainedAsFullPastor", txtDOFP.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@PrimarySchool", txtpri.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateStartPrimary", dtpp.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateEndPrimary", dtppp.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@Secondary", txtsec.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateStartSecondary", dtps.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateEndSecondary", dtpss.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@HigherEducationInstitution", txtHEI.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateStartHigherEducation", dtph.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateEndHigherEducation", dtphh.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@OtherCertificates", txtots.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateStartBaptismalClass", dtpb.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateEndBaptismalClass", dtpbb.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateStartWorkersInTraining", dtpw.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateEndWorkersInTraining", dtpww.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateStartSOD", dtpsd.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateEndSOD", dtpsdd.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@YearStartRCBC", dtprr.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateEndRCBC", dtprr.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateStartRCM", dtprc.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateEndRCM", dtprcc.Text.Trim());
                    SqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Saved Successfully");
                    Reset();
                    FillDataGridView();
                }
                else
                {
                    SqlCommand SqlCmd = new SqlCommand("personalAddorEdit", SqlCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@mode", "Edit");
                    SqlCmd.Parameters.AddWithValue("@personalid", personalid);
                    SqlCmd.Parameters.AddWithValue("@surname", txtsur.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@othernames", txton.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@designation", txtdes.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@rccno", txtrcc.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@yearlastpromoted", txtylp.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@dateofbirth", txtdb.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@Age", txtage.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@stateoforigin", txtso.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@yearemployed", txtde.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@presentlocation", txtpl.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@dateoflastPosting", txtdlp.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@languagesspoken", txtls.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@gender", gender);
                    SqlCmd.Parameters.AddWithValue("@gradelevel", txtgl.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@yearawarded", txtya.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@phonenumber", txtpn.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@email", txtmail.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@ordinationstatus", txtos.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@maritalstatus", txtms.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@nationality", txtnat.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@hometown", txtht.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@typeofmarriage", txttm.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@dateofmarriage", txtdm.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@residentialaddress", txtra.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@pensionname", txtpen.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@rsapin", txtrsa.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@state", txtstate.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@country", txtcountry.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@relationship", txtRel.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@telephonenumber", txtTel.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateJoinRCCG", txtDJR.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateBornAgain", txtDBA.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@Region", txtReg.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@PresentProvince", txtPP.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateOrdainedAsAssistantPastor", txtDOAP.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateOrdainedAsFullPastor", txtDOFP.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@PrimarySchool", txtpri.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateStartPrimary", dtpp.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateEndPrimary", dtppp.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@Secondary", txtsec.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateStartSecondary", dtps.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateEndSecondary", dtpss.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@HigherEducationInstitution", txtHEI.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateStartHigherEducation", dtph.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateEndHigherEducation", dtphh.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@OtherCertificates", txtots.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateStartBaptismalClass", dtpb.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateEndBaptismalClass", dtpbb.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateStartWorkersInTraining", dtpw.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateEndWorkersInTraining", dtpww.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateStartSOD", dtpsd.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateEndSOD", dtpsdd.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@YearStartRCBC", dtprr.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateEndRCBC", dtprr.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateStartRCM", dtprc.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@DateEndRCM", dtprcc.Text.Trim());
                    SqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfully");
                    Reset();
                    FillDataGridView();
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
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (SqlCon.State == ConnectionState.Closed)
                    SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand("personalDeletion", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@personalid", personalid);
                SqlCmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully");
                Reset();
                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }
        private void btnreset_Click_1(object sender, EventArgs e)
        {
            Reset();
        }

        void FillDataGridView()
        {

            if (SqlCon.State == ConnectionState.Closed)
                SqlCon.Open();
            {
                SqlDataAdapter SqlDa = new SqlDataAdapter("personalSearchorView", SqlCon);
                SqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                SqlDa.SelectCommand.Parameters.AddWithValue("@RCCNO", txtsearch.Text.Trim());
                DataTable dtbl = new DataTable();
                SqlDa.Fill(dtbl);
                dgvv3.DataSource = dtbl;
                dgvv3.Columns[0].Visible = false;
                SqlCon.Close();
            }
        }
        private void dgvv3_DoubleClick_1(object sender, EventArgs e)
        {
            if (dgvv3.CurrentRow.Index != -1)
            {
                personalid = Convert.ToInt32(dgvv3.CurrentRow.Cells[0].Value.ToString());
                txtsur.Text = dgvv3.CurrentRow.Cells[1].Value.ToString();
                txton.Text = dgvv3.CurrentRow.Cells[2].Value.ToString();
                txtdes.Text = dgvv3.CurrentRow.Cells[3].Value.ToString();
                txtrcc.Text = dgvv3.CurrentRow.Cells[4].Value.ToString();
                txtylp.Text = dgvv3.CurrentRow.Cells[5].Value.ToString();
                txtdb.Text = dgvv3.CurrentRow.Cells[6].Value.ToString();
                txtage.Text = dgvv3.CurrentRow.Cells[7].Value.ToString();
                txtso.Text = dgvv3.CurrentRow.Cells[8].Value.ToString();
                txtde.Text = dgvv3.CurrentRow.Cells[9].Value.ToString();
                txtpl.Text = dgvv3.CurrentRow.Cells[10].Value.ToString();
                txtdlp.Text = dgvv3.CurrentRow.Cells[11].Value.ToString();
                txtls.Text = dgvv3.CurrentRow.Cells[12].Value.ToString();
                radioButton1.Text = dgvv3.CurrentRow.Cells[13].Value.ToString();
                radioButton2.Text = dgvv3.CurrentRow.Cells[13].Value.ToString();
                txtgl.Text = dgvv3.CurrentRow.Cells[14].Value.ToString();
                txtya.Text = dgvv3.CurrentRow.Cells[15].Value.ToString();
                txtpn.Text = dgvv3.CurrentRow.Cells[16].Value.ToString();
                txtmail.Text = dgvv3.CurrentRow.Cells[17].Value.ToString();
                txtos.Text = dgvv3.CurrentRow.Cells[18].Value.ToString();
                txtms.Text = dgvv3.CurrentRow.Cells[19].Value.ToString();
                txtnat.Text = dgvv3.CurrentRow.Cells[20].Value.ToString();
                txtht.Text = dgvv3.CurrentRow.Cells[21].Value.ToString();
                txttm.Text = dgvv3.CurrentRow.Cells[22].Value.ToString();
                txtdm.Text = dgvv3.CurrentRow.Cells[23].Value.ToString();
                txtra.Text = dgvv3.CurrentRow.Cells[24].Value.ToString();
                txtpen.Text = dgvv3.CurrentRow.Cells[25].Value.ToString();
                txtrsa.Text = dgvv3.CurrentRow.Cells[26].Value.ToString();
                txtstate.Text = dgvv3.CurrentRow.Cells[27].Value.ToString();
                txtcountry.Text = dgvv3.CurrentRow.Cells[28].Value.ToString();
                txtName.Text = dgvv3.CurrentRow.Cells[30].Value.ToString();
                txtRel.Text = dgvv3.CurrentRow.Cells[31].Value.ToString();
                txtTel.Text = dgvv3.CurrentRow.Cells[32].Value.ToString();
                txtAddress.Text = dgvv3.CurrentRow.Cells[33].Value.ToString();
                txtDJR.Text = dgvv3.CurrentRow.Cells[35].Value.ToString();
                txtDBA.Text = dgvv3.CurrentRow.Cells[36].Value.ToString();
                txtReg.Text = dgvv3.CurrentRow.Cells[37].Value.ToString();
                txtPP.Text = dgvv3.CurrentRow.Cells[38].Value.ToString();
                txtDOAP.Text = dgvv3.CurrentRow.Cells[39].Value.ToString();
                txtDOFP.Text = dgvv3.CurrentRow.Cells[40].Value.ToString();
                txtpri.Text = dgvv3.CurrentRow.Cells[42].Value.ToString();
                dtpp.Text = dgvv3.CurrentRow.Cells[43].Value.ToString();
                dtppp.Text = dgvv3.CurrentRow.Cells[44].Value.ToString();
                txtsec.Text = dgvv3.CurrentRow.Cells[45].Value.ToString();
                dtps.Text = dgvv3.CurrentRow.Cells[46].Value.ToString();
                dtpss.Text = dgvv3.CurrentRow.Cells[47].Value.ToString();
                txtHEI.Text = dgvv3.CurrentRow.Cells[48].Value.ToString();
                dtph.Text = dgvv3.CurrentRow.Cells[49].Value.ToString();
                dtphh.Text = dgvv3.CurrentRow.Cells[50].Value.ToString();
                txtots.Text = dgvv3.CurrentRow.Cells[51].Value.ToString();
                dtpb.Text = dgvv3.CurrentRow.Cells[52].Value.ToString();
                dtpbb.Text = dgvv3.CurrentRow.Cells[53].Value.ToString();
                dtpw.Text = dgvv3.CurrentRow.Cells[54].Value.ToString();
                dtpww.Text = dgvv3.CurrentRow.Cells[55].Value.ToString();
                dtpsd.Text = dgvv3.CurrentRow.Cells[56].Value.ToString();
                dtpsdd.Text = dgvv3.CurrentRow.Cells[57].Value.ToString();
                dtpr.Text = dgvv3.CurrentRow.Cells[58].Value.ToString();
                dtprr.Text = dgvv3.CurrentRow.Cells[59].Value.ToString();
                dtprc.Text = dgvv3.CurrentRow.Cells[60].Value.ToString();
                dtprcc.Text = dgvv3.CurrentRow.Cells[61].Value.ToString();
                btnsave.Text = "Update";
                btnDelete.Enabled = true;
            }
        }
        void Reset()
        {
            txtsur.Text = txton.Text = txtdes.Text = txtrcc.Text =
            txtylp.Text = txtdb.Text = txtage.Text = txtso.Text =
            txtde.Text = txtpl.Text = txtdlp.Text = txtls.Text =
            radioButton1.Text = radioButton2.Text = txtgl.Text = txtya.Text =
            txtpn.Text = txtmail.Text = txtos.Text = txtms.Text =
            txtnat.Text = txtht.Text = txttm.Text = txtdm.Text =
            txtra.Text = txtpen.Text = txtrsa.Text = txtstate.Text =
            txtcountry.Text = txtName.Text = txtAddress.Text =
            txtRel.Text = txtTel.Text = txtDJR.Text = txtDBA.Text =
             txtReg.Text = txtPP.Text = txtDOAP.Text = txtDOFP.Text =
             txtpri.Text = dtpp.Text = dtppp.Text = txtsec.Text =
             dtps.Text = dtpss.Text = txtHEI.Text = dtph.Text =
             dtphh.Text = txtots.Text = dtpb.Text = dtpbb.Text = dtpw.Text =
             dtpww.Text = dtpsd.Text = dtpsdd.Text = dtpr.Text =
             dtprr.Text = dtprc.Text = txtage.Text = dtprcc.Text = "";
            btnsave.Text = "Save";
            personalid = 0;
            btnDelete.Enabled = false;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (SqlCon.State == ConnectionState.Closed)
                    SqlCon.Open();
                {
                    SqlDataAdapter Sqlda = new SqlDataAdapter("personalSearchorView", SqlCon);
                    Sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    Sqlda.SelectCommand.Parameters.AddWithValue("@RCCNO", txtsearch.Text.Trim());
                    DataTable dtbl = new DataTable();
                    Sqlda.Fill(dtbl);
                    dgvv3.DataSource = dtbl;
                    dgvv3.Columns[0].Visible = false;
                    txtsearch.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Reset();
            //FillDataGridView();                                           
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 ss = new Form2();
            (ss).ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form4 ss = new Form4();
            //ss.Surname = txtsur.Text;
            (ss).ShowDialog();
        }

    }
}







