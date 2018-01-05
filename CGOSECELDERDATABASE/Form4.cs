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
    public partial class Form4 : Form
    {
        SqlConnection SqlCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\PETERRSON\Documents\Visual Studio 2010\Projects\ElderNatSecCgo\DB\database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        // int personalid = 0;
        public Form4()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 ss = new Form3();
            (ss).ShowDialog();
        }
        void FillDataGridView()
        {
            if (SqlCon.State == ConnectionState.Closed)
                SqlCon.Open();
            {
                SqlDataAdapter sda = new SqlDataAdapter("personalSerachorView", SqlCon);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@RCCNO", txtsearch.Text.Trim());
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                dgvv3.DataSource = dtbl;
                dgvv3.Columns[0].Visible = false;
                SqlCon.Close();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dtbl = new DataTable();
            if (textBox2.Text.Length > 0)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from personal where RCCNO like '" + textBox2.Text + "%'", SqlCon);
                sda.Fill(dtbl);
            }
            else if (txtsearch.Text.Length > 0)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from personal where DESIGNATION like '" + txtsearch.Text + "%'", SqlCon);
                sda.Fill(dtbl);
            }
            else if (textBox1.Text.Length > 0)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from personal where SURNAME like '" + textBox1.Text + "%'", SqlCon);
                sda.Fill(dtbl);
            }
            dgvv3.DataSource = dtbl;
            dgvv3.Columns[0].Visible = false;
        }
        private void label72_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            txtsearch.Text = "";
        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            txtsearch.Text = "";
            textBox2.Text = "";
        }
        private void btnview_Click_1(object sender, EventArgs e)
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            label70.Left += 1;
            if (label70.Left > 800)
            {
                timer1.Stop();
                timer2.Start();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            label70.Left -= 1;
            if (label70.Left < 1)
            {
                timer2.Stop();
                timer1.Start();
            }

        }
    }
}







