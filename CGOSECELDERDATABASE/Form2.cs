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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            SqlConnection SqlCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\PETERRSON\Documents\Visual Studio 2010\Projects\ElderNatSecCgo\DB\database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlDataAdapter sda = new SqlDataAdapter("select count(*)from admin where username='" + txtusername.Text + "' and password='" + txtpassword.Text + "'", SqlCon);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Form3 ss = new Form3();
                (ss).Show();
            }
            else
            {
                MessageBox.Show("Please Check Username or Password");
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Left += 1;
            if (label3.Left > 18)
            {
                timer1.Stop();
                timer2.Start();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            label3.Left -= 1;
            if (label3.Left < 1)
            {
                timer2.Stop();
                timer1.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ss = new Form1();
            (ss).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 ss = new Form3();
            (ss).Show();
        }

    }
}


