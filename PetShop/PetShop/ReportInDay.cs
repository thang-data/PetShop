using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShop
{
    public partial class ReportInDay : Form
    {
        string tentk;

        public string message
        {
            get { return tentk; }
            set { tentk = value; }

        }
        public ReportInDay()
        {
            InitializeComponent();
        }

        private void ReportInDay_Load(object sender, EventArgs e)
        {
            EmpName.Text = tentk;
            // TODO: This line of code loads data into the 'DataSetReport.BillTbl' table. You can move, or remove it, as needed.

        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            this.BillTblTableAdapter.Fill(this.DataSetReport.BillTbl, dtInDay.Text);

            this.reportViewer1.RefreshReport();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.message = EmpName.Text;
            hm.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

            Products Obj = new Products();
            Obj.message = EmpName.Text;
            Obj.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Customer Obj = new Customer();
            Obj.message = EmpName.Text;
            Obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Billings bl = new Billings();
            bl.message = EmpName.Text;
            bl.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Employees em = new Employees();
            em.message = EmpName.Text;
            em.Show();
            this.Hide();
        }
    }
}
