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
    public partial class Dashboard : Form
    {
        DataTable employeeListDT = new DataTable();
        DataTable retireeListDT = new DataTable();
        DataTable awardListDt =  new DataTable();
        DataTable awardListDt2 = new DataTable();
        DataTable awardListDt3 = new DataTable();
        DataTable awardListDt4 = new DataTable();
        DataTable awardListDt5 = new DataTable();

        public Dashboard()
        {
      InitializeComponent();
  }

  private void Dashboard_Load(object sender, EventArgs e)
  {
 SqlConnection SqlCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\PETERRSON\Documents\Visual Studio 2010\Projects\ElderNatSecCgo\DB\database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
 SqlDataAdapter sda = new SqlDataAdapter("select Surname, OtherNames, RCCNO, YearLastPromoted, Designation, Age, GradeLevel from personal WHERE YearLastPromoted IS NOT NULL AND YearLastPromoted!= ''", SqlCon);
 DataTable dt = new DataTable();
 sda.Fill(dt);

 SqlDataAdapter retirementDA = new SqlDataAdapter("select Surname, OtherNames, RCCNO, YearLastPromoted, Designation, Age, GradeLevel, YearEmployed from personal WHERE Age=70 And Designation !='Retired'", SqlCon);
 DataTable retirementDT = new DataTable();
 retirementDA.Fill(retirementDT);

 SqlDataAdapter awardDA = new SqlDataAdapter("select Surname, OtherNames, RCCNO, YearLastPromoted, Designation, Age, GradeLevel, YearEmployed, YearAwarded from personal WHERE YearEmployed=1998 AND YearAwarded!= '2018'", SqlCon);
 DataTable awardDt = new DataTable();
 awardDA.Fill(awardDt);

 SqlDataAdapter awardDA1 = new SqlDataAdapter("select Surname, OtherNames, RCCNO, YearLastPromoted, Designation, Age, GradeLevel, YearEmployed, YearAwarded from personal WHERE YearEmployed = 1993 AND YearEmployed!= ''", SqlCon);
 DataTable awardDt1 = new DataTable();
 awardDA1.Fill(awardDt1);

 employeeListDT.Columns.Add("Surname");
 employeeListDT.Columns.Add("OtherNames");
 employeeListDT.Columns.Add("RCCNO");
 employeeListDT.Columns.Add("YearLastPromoted");
 employeeListDT.Columns.Add("Designation");
 employeeListDT.Columns.Add("Age");
 employeeListDT.Columns.Add("GradeLevel");

 retireeListDT.Columns.Add("Surname");
 retireeListDT.Columns.Add("OtherNames");
 retireeListDT.Columns.Add("RCCNO");
 retireeListDT.Columns.Add("YearLastPromoted");
 retireeListDT.Columns.Add("Designation");
 retireeListDT.Columns.Add("Age");
 retireeListDT.Columns.Add("GradeLevel");

 awardListDt.Columns.Add("Surname");
 awardListDt.Columns.Add("OtherNames");
 awardListDt.Columns.Add("RCCNO");
 awardListDt.Columns.Add("YearLastPromoted");
 awardListDt.Columns.Add("Designation");
 awardListDt.Columns.Add("Age");
 awardListDt.Columns.Add("GradeLevel");
 awardListDt.Columns.Add("YearEmployed");
 awardListDt.Columns.Add("YearAwarded");

 awardListDt2.Columns.Add("Surname");
 awardListDt2.Columns.Add("OtherNames");
 awardListDt2.Columns.Add("RCCNO");
 awardListDt2.Columns.Add("YearLastPromoted");
 awardListDt2.Columns.Add("Designation");
 awardListDt2.Columns.Add("Age");
 awardListDt2.Columns.Add("YearEmployed");

 awardListDt3.Columns.Add("Surname");
 awardListDt3.Columns.Add("OtherNames");
 awardListDt3.Columns.Add("RCCNO");
 awardListDt3.Columns.Add("YearLastPromoted");
 awardListDt3.Columns.Add("Designation");
 awardListDt3.Columns.Add("Age");
 awardListDt3.Columns.Add("YearEmployed");

 awardListDt4.Columns.Add("Surname");
 awardListDt4.Columns.Add("OtherNames");
 awardListDt4.Columns.Add("RCCNO");
 awardListDt4.Columns.Add("YearLastPromoted");
 awardListDt4.Columns.Add("Designation");
 awardListDt4.Columns.Add("Age");
 awardListDt4.Columns.Add("YearEmployed");

 awardListDt5.Columns.Add("Surname");
 awardListDt5.Columns.Add("OtherNames");
 awardListDt5.Columns.Add("RCCNO");
 awardListDt5.Columns.Add("YearLastPromoted");
 awardListDt5.Columns.Add("Designation");
 awardListDt5.Columns.Add("Age");
 awardListDt5.Columns.Add("YearEmployed");

 int AwardCount = 0;
 int AwardCount2 = 0;
 int AwardCount3 = 0;
 int AwardCount4 = 0;
 int AwardCount5 = 0;
 int RetirementCount = 0;
 int PromotionCount = 0;
 int CurrentYear = DateTime.Now.Year;

 for (int i = 0; i <= dt.Rows.Count - 1; i++)
 {
     int YearLastPromoted = Convert.ToInt32(dt.Rows[i]["YearLastPromoted"]);
     int YearDueForPromotion = YearLastPromoted + 5;

     if (CurrentYear >= YearDueForPromotion)
     {
         PromotionCount += 1;
         DataRow row = employeeListDT.NewRow();

         row["Surname"] = dt.Rows[i]["Surname"];
         row["OtherNames"] = dt.Rows[i]["OtherNames"];
         row["RCCNO"] = dt.Rows[i]["RCCNO"];
         row["YearLastPromoted"] = dt.Rows[i]["YearLastPromoted"];
         row["Designation"] = dt.Rows[i]["Designation"];
         row["Age"] = dt.Rows[i]["Age"];
         row["GradeLevel"] = dt.Rows[i]["GradeLevel"];

         employeeListDT.Rows.Add(row);
     }
     btnPromotionDue.Text = "Pastors Due For Promotion" + " (" + PromotionCount.ToString() + ")";
 }

for (int a = 0; a <= retirementDT.Rows.Count - 1; a++)
{
    int Age = Convert.ToInt32(retirementDT.Rows[a]["Age"]);
    int YearDueForRetirement = Age;
    if (Age == 70)
    {
        RetirementCount += 1;
        DataRow row = retireeListDT.NewRow();

        row["Surname"] = retirementDT.Rows[a]["Surname"];
        row["OtherNames"] = retirementDT.Rows[a]["OtherNames"];
        row["RCCNO"] = retirementDT.Rows[a]["RCCNO"];
        row["YearLastPromoted"] = retirementDT.Rows[a]["YearLastPromoted"];
        row["Designation"] = retirementDT.Rows[a]["Designation"];
        row["Age"] = retirementDT.Rows[a]["Age"];
        row["GradeLevel"] = retirementDT.Rows[a]["GradeLevel"];

        retireeListDT.Rows.Add(row);
    }
    btnRetirementDue.Text = "Pastors Due For Retirement" + " (" + RetirementCount.ToString() + ")";
}

for (int f = 0; f <= awardDt.Rows.Count - 1; f++)
{
    int YearEmployed = Convert.ToInt32(awardDt.Rows[f]["YearEmployed"]);
    int YearDueForAward = YearEmployed;
    if (YearEmployed == 1998)
        {
            AwardCount += 1;
            DataRow row = awardListDt.NewRow();

            row["Surname"] = awardDt.Rows[f]["Surname"];
            row["OtherNames"] = awardDt.Rows[f]["OtherNames"];
            row["RCCNO"] = awardDt.Rows[f]["RCCNO"];
            row["YearLastPromoted"] = awardDt.Rows[f]["YearLastPromoted"];
            row["Designation"] = awardDt.Rows[f]["Designation"];
            row["Age"] = awardDt.Rows[f]["Age"];
            row["GradeLevel"] = awardDt.Rows[f]["GradeLevel"];
            row["YearEmployed"] = awardDt.Rows[f]["YearEmployed"];
            row["YearAwarded"] = awardDt.Rows[f]["YearAwarded"];

            awardListDt.Rows.Add(row);
        }
     btnAward.Text = "Pastors Due For Award 20 years" + " (" + AwardCount.ToString() + ")";
}

for (int c = 0; c <= awardListDt2.Rows.Count - 1; c++)
      {
    int YearEmployed = Convert.ToInt32(awardDt1.Rows[c]["YearEmployed"]);
       int YearDueForAward = YearEmployed + 25;
       
       if (CurrentYear == YearDueForAward)
   {
     AwardCount2 += 1;
     DataRow row = awardListDt2.NewRow();
     
     row["Surname"] = awardDt1.Rows[c]["Surname"];
     row["OtherNames"] = awardDt1.Rows[c]["OtherNames"];
     row["RCCNO"] = awardDt1.Rows[c]["RCCNO"];
     row["YearLastPromoted"] = awardDt1.Rows[c]["YearLastPromoted"];
     row["Designation"] = awardDt1.Rows[c]["Designation"];
     row["Age"] = awardDt1.Rows[c]["Age"];
     row["GradeLevel"] = awardDt1.Rows[c]["GradeLevel"];
     row["YearEmployed"] = awardDt1.Rows[c]["YearEmployed"];
     row["YearAwarded"] = awardDt1.Rows[c]["YearAwarded"];
     
      awardListDt2.Rows.Add(row);    
  }
      btnAward25.Text = "Pastors Due Award for 25 years" + " (" + AwardCount2.ToString() + ")";
  }
// for (int d = 0; d <= dt.Rows.Count - 1; d++)
// {
//     int YearEmployed = Convert.ToInt32(dt.Rows[d]["YearEmployed"]);
//     int YearDueForAward = (CurrentYear - YearEmployed);
//
//     if (YearDueForAward == 30)
//     {
// AwardCount3 += 1;
// DataRow row = awardListDt3.NewRow();
//
// row["Surname"] = dt.Rows[d]["Surname"];
// row["OtherNames"] = dt.Rows[d]["OtherNames"];
// row["RCCNO"] = dt.Rows[d]["RCCNO"];
// row["YearLastPromoted"] = dt.Rows[d]["YearLastPromoted"];
// row["Designation"] = dt.Rows[d]["Designation"];
// row["Age"] = dt.Rows[d]["Age"];
// row["YearEmployed"] = dt.Rows[d]["YearEmployed"];
//
// awardListDt3.Rows.Add(row);
//     }
//     btnAward30.Text = "Pastors Due Award for 30 years" + " (" + AwardCount3.ToString() + ")";
// }
//
//for (int z = 0; z <= dt.Rows.Count - 1; z++)
//{
//    int YearEmployed = Convert.ToInt32(dt.Rows[z]["YearEmployed"]);
//    int YearDueForAward = (CurrentYear - YearEmployed);
//
//    if (YearDueForAward == 35)
//    {
//        AwardCount4 += 1;
//        DataRow row = awardListDt4.NewRow();
//
//        row["Surname"] = dt.Rows[z]["Surname"];
//        row["OtherNames"] = dt.Rows[z]["OtherNames"];
//        row["RCCNO"] = dt.Rows[z]["RCCNO"];
//        row["YearLastPromoted"] = dt.Rows[z]["YearLastPromoted"];
//        row["Designation"] = dt.Rows[z]["Designation"];
//        row["Age"] = dt.Rows[z]["Age"];
//        row["YearEmployed"] = dt.Rows[z]["YearEmployed"];
//
//        awardListDt4.Rows.Add(row);
//    }
//    btnAward35.Text = "Pastors Due Award for 35 years" + " (" + AwardCount4.ToString() + ")";
//}
//      for (int y = 0; y <= dt.Rows.Count - 1; y++)
//      {
//          int YearEmployed = Convert.ToInt32(dt.Rows[y]["YearEmployed"]);
//          int YearDueForAward = (CurrentYear - YearEmployed);
//
//          if (YearDueForAward == 40)
//          {
//              AwardCount5 += 1;
//              DataRow row = awardListDt5.NewRow();
//
//              row["Surname"] = dt.Rows[y]["Surname"];
//              row["OtherNames"] = dt.Rows[y]["OtherNames"];
//              row["RCCNO"] = dt.Rows[y]["RCCNO"];
//              row["YearLastPromoted"] = dt.Rows[y]["YearLastPromoted"];
//              row["Designation"] = dt.Rows[y]["Designation"];
//              row["Age"] = dt.Rows[y]["Age"];
//              row["YearEmployed"] = dt.Rows[y]["YearEmployed"];
//
//              awardListDt5.Rows.Add(row);
//          }
//          btnAward40.Text = "Pastors Due Award for 40 years" + " (" + AwardCount5.ToString() + ")";
//      }
  }
  private void btnPromotionDue_Click_1(object sender, EventArgs e)
  {
      EmployeeDuePromotion list = new EmployeeDuePromotion();
      list.dt = employeeListDT;
      list.ShowDialog();
  }

  private void btnRetirementDue_Click(object sender, EventArgs e)
  {
      EmployeeDueRetirementList list = new EmployeeDueRetirementList();
      list.dt = retireeListDT;
      list.ShowDialog();
  }

  private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
  {
      Form4 n = new Form4();
      n.ShowDialog();
  }

  private void toolStripMenuItem1_Click(object sender, EventArgs e)
  {
      Form3 n = new Form3();
      n.ShowDialog();
  }

  private void btnAward_Click(object sender, EventArgs e)
  {
      EmployeeDueAward list = new EmployeeDueAward();
      list.dt = awardListDt;
      list.ShowDialog();
  }

  private void btnAward25_Click(object sender, EventArgs e)
  {
      EmployeeDueAward list = new EmployeeDueAward();
      list.dt = awardListDt2;
      list.ShowDialog();
  }

  private void btnAward30_Click(object sender, EventArgs e)
  {
      EmployeeDueAward list = new EmployeeDueAward();
      list.dt = awardListDt3;
      list.ShowDialog();
  }

  private void btnAward35_Click(object sender, EventArgs e)
  {

      EmployeeDueAward list = new EmployeeDueAward();
      list.dt = awardListDt4;
      list.ShowDialog();
  }

  private void btnAward40_Click(object sender, EventArgs e)
  {
      EmployeeDueAward list = new EmployeeDueAward();
      list.dt = awardListDt5;
      list.ShowDialog();
  }

  private void listOfRetireeToolStripMenuItem_Click(object sender, EventArgs e)
  {
      EmployeeDueRetirementList list = new EmployeeDueRetirementList();
      list.dt = retireeListDT;
      list.ShowDialog();
  }
    }
}
