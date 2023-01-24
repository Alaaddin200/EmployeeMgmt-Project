using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeMgmt
{
    public partial class Salaries : Form
    {
        Functions Con;
        public Salaries()
        {
            InitializeComponent();
            Con = new Functions();
            ShowSalaries();
            GetEmployees();
        }
        private void GetEmployees()
        {
            string Query = "select * from EmployeeTb1";
            EmpCb.DisplayMember = Con.GetData(Query).Columns("EmpName").ToString();
            EmpCb.ValueMember = Con.GetData(Query).Columns["EmpId"].ToString();
            EmpCb.DataSource = Con.GetData(Query);

        }

        int DSal = 0;
        string period = "";
        private void GetSalary()
        {
            string Query = "select EmpSal from EmployeeTb1 where EmpId={0}";
            Query = string.Format(Query,EmpCb.SelectedValue.ToString());
            
            foreach(DataRow dr in Con.GetDate(Query).Rows)
            {

                DSal = Convert.ToInt32(dr["EmpSal"].ToString());

            }
            
            //MessageBox.Show("" + DSal);
            //EmpCb.DataSource = Con.GetData(Query);

        }

        private void ShowSalaries()
        {
            string Query = "Select * from SalaryTb1";
            SalaryList.DataSource = Con.GetData(Query);
        }

        private void Salaries_Load(object sender, EventArgs e)
        {

        }

        private void SalaryLbl_Click(object sender, EventArgs e)
        {
            Salaries Obj = new Salaries();
            Obj.Show();
            this.Hide();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {

        }

        private void EmpCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetSalary();
        }
    }
}
