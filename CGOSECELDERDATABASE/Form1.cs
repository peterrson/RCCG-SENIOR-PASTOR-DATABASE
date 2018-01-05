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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form2 ss = new Form2();
            (ss).Show();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlConnection SqlCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\PETERRSON\Documents\Visual Studio 2010\Projects\ElderNatSecCgo\DB\database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            this.Hide();
            Form2 ss = new Form2();
            (ss).Show();
            try
            {
                if (SqlCon.State == ConnectionState.Closed)
                    SqlCon.Open();
                {
                    SqlCommand SqlCmd = new SqlCommand("adminAddorEdit", SqlCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@mode", "Add");
                    SqlCmd.Parameters.AddWithValue("@adminid", 0);
                    SqlCmd.Parameters.AddWithValue("@name", txtname.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@username", txtusername.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@password", txtpassword.Text.Trim());
                    SqlCmd.Parameters.AddWithValue("@age", txtage.Text.Trim());
                    SqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Saved Successfully");
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Left += 1;
            if (label6.Left > 800)
            {
                timer1.Stop();
                timer2.Start();
                label7.Show();
                label8.Hide();
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label6.Left -= 1;
            if (label6.Left < 1)
            {
                timer2.Stop();
                timer1.Start();
                label8.Show();
                label7.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label7.Hide();
            label8.Hide();

        }
    }
}
