using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShop
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            finacelb.Enabled = false;
            CountDogs();
            CountCats();
            CountBird();
            Finace();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-16TE5IR;Initial Catalog=PetShopDb;Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {
            Products pr = new Products();
            pr.message = EmpName.Text;
            pr.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Employees em = new Employees();
            em.message = EmpName.Text;
            em.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

            Customer ct = new Customer();
            ct.message = EmpName.Text;
            ct.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void CountDogs()
        {
            string Cat = "Dog";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from ProductTbl where PrCat = '" + Cat + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Dogslb.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }
        private void CountCats()
        {
            string Cat = "Cat";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from ProductTbl where PrCat = '" + Cat + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Catslb.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }
        private void CountBird()
        {
            string Cat = "Bird";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from ProductTbl where PrCat = '" + Cat + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Birdlb.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }
        private void Finace()
        {
            
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(" Select Sum(Amt) from BillTbl ", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            
            finacelb.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }
        private void label5_Click(object sender, EventArgs e)
        {
            Billings bl = new Billings();
            bl.message = EmpName.Text;
            bl.Show();
            this.Hide();
        }
        string tentk;
        public string message
        {
            get { return tentk; }
            set { tentk = value; }

        }
        private void Home_Load(object sender, EventArgs e)
        {
            EmpName.Text = tentk;
        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            ReportInDay rp = new ReportInDay();
            rp.Show();
        }
    }
}
