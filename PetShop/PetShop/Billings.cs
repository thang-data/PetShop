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
    public partial class Billings : Form
    {
        
        public Billings()
        {
            InitializeComponent();
            
            GetCustomers();
            DisplayProduct();
            DisplayTransaction();
            txtPrName.Enabled = false;
            txtPrice.Enabled = false;
            
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-16TE5IR;Initial Catalog=PetShopDb;Integrated Security=True");
        
        private void GetCustomers()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select CusID from CustomerTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CusID", typeof(int));
            dt.Load(Rdr);
            cmbCusID.ValueMember = "CusID";
            cmbCusID.DataSource = dt;
            Con.Close();
        }
        private void DisplayProduct()
        {
            Con.Open();
            string Query = "select * from ProductTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProductDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        int Key = 0, Stock = 0;
        private void GetCustName()
        {
            Con.Open();
            string Query = "Select CusName from CustomerTbl where CusID = '" + cmbCusID.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                CusNameTb.Text = dr["CusName"].ToString();

            }
            Con.Close();
        }
        private void UpdateStock()
        {
            try
            {
                int NewQty = Stock - Convert.ToInt32(txtQuantity.Text);
                Con.Open();
                SqlCommand cmd = new SqlCommand("Update ProductTbl set PrQty = @PQ where PrID = @Pkey", Con);
                cmd.Parameters.AddWithValue("@PQ", NewQty);
                cmd.Parameters.AddWithValue("@Pkey", Key);
                cmd.ExecuteNonQuery();
                Con.Close();
                DisplayProduct();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int n = 0,grdTotal=0;

        private void btnAddToBill_Click(object sender, EventArgs e)
        {
            if(txtQuantity.Text == ""|| Convert.ToInt32(txtQuantity.Text) > Stock)
            {
                MessageBox.Show("No Enough in house");
            }
            else if(txtQuantity.Text == "" || Key == 0)
            {
                MessageBox.Show("No data found");
            }
            else
            {
                int total = Convert.ToInt32(txtQuantity.Text) * Convert.ToInt32(txtPrice.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dgvProduct);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = txtPrName.Text;
                newRow.Cells[2].Value = txtQuantity.Text;
                newRow.Cells[3].Value = txtPrice.Text;
                newRow.Cells[4].Value = total;
                grdTotal = grdTotal + total;
                dgvProduct.Rows.Add(newRow);
                n++;
                lbRS.Text = "RS" + grdTotal;
                UpdateStock();
                Reset();
            }
        }

        private void cmbCusID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCustName();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void ProductDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPrName.Text = ProductDGV.SelectedRows[0].Cells[1].Value.ToString();
            Stock = Convert.ToInt32(ProductDGV.SelectedRows[0].Cells[3].Value.ToString());
            txtPrice.Text = ProductDGV.SelectedRows[0].Cells[4].Value.ToString();

            if (txtPrName.Text == " ")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ProductDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            InsertBill();
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        private void DisplayTransaction()
        {
            Con.Open();
            string Query = "Select BNum [STT], BDate[Ngày], CusId [Mã số],CusName [Họ tên], EmpName [Nhân viên],Amt[Tổng tiền] from BillTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvTransaction.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void InsertBill()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into BillTbl(BDate,CusId, CusName, EmpName,Amt) values(@BB,@BCD,@BCN,@BE,@BA)", Con);
                cmd.Parameters.Add("@BB", DateTime.Today.Date);
                cmd.Parameters.Add("@BCD", cmbCusID.SelectedValue.ToString());
                cmd.Parameters.Add("@BCN", CusNameTb.Text);
                cmd.Parameters.Add("@BE", EmpName.Text);
                cmd.Parameters.Add("@BA", grdTotal);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công!");
                Con.Close();
                DisplayTransaction();
                //clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Reset()
        {
            txtPrName.Text = "";
            txtQuantity.Text = "";
            Stock = 0;
            Key = 0;
        }

        int proid, prodqty, prodprice, tottal, pos = 60;

        private void label4_Click(object sender, EventArgs e)
        {
            Customer ct = new Customer();
            ct.message = EmpName.Text;
            ct.Show();
            this.Hide();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.message = EmpName.Text;
            hm.Show();
            this.Hide();
        }

        private void EmpName_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Employees em = new Employees();
            em.message = EmpName.Text;
            em.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Products pr = new Products();
            pr.message = EmpName.Text;
            pr.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.message = EmpName.Text;
            hm.Show();
            this.Hide();
        }

        string prodname;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Vtekapt PetShop", new Font("Fira-code", 12, FontStyle.Bold), Brushes.OrangeRed, new Point(80));
            e.Graphics.DrawString("STT Sảnphẩm Sốlượng  Giábán Tổngtiền", new Font("Fira-code", 10, FontStyle.Bold), Brushes.Orange, new Point(10, 40));
            foreach(DataGridViewRow row in dgvProduct.Rows)
            {
                proid = Convert.ToInt32(row.Cells["colID"].Value);
                prodname = "" + row.Cells["colProduct"].Value;
                prodprice = Convert.ToInt32(row.Cells["colPrice"].Value);
                prodqty = Convert.ToInt32(row.Cells["colQty"].Value);
                tottal = Convert.ToInt32(row.Cells["colTotal"].Value);
                e.Graphics.DrawString("" + proid, new Font("Fira-code", 8, FontStyle.Bold), Brushes.Blue, new Point(26, pos));
                e.Graphics.DrawString("" + prodname, new Font("Fira-code", 8, FontStyle.Bold), Brushes.Blue, new Point(45, pos));
                e.Graphics.DrawString("" + prodprice, new Font("Fira-code", 8, FontStyle.Bold), Brushes.Blue, new Point(120, pos));
                e.Graphics.DrawString("" + prodqty, new Font("Fira-code", 8, FontStyle.Bold), Brushes.Blue, new Point(170, pos));
                e.Graphics.DrawString("" + tottal, new Font("Fira-code", 8, FontStyle.Bold), Brushes.Blue, new Point(235, pos));
                pos = pos + 20;
            }
            e.Graphics.DrawString("Tổng thành tiền" + grdTotal, new Font("Fira-code", 12, FontStyle.Bold), Brushes.Blue, new Point(50, pos + 50));
            e.Graphics.DrawString("      Hẹn gặp lại quý khách     ", new Font("Fira-code", 12, FontStyle.Bold), Brushes.OrangeRed, new Point(10, pos + 85));
            dgvProduct.Rows.Clear();
            dgvProduct.Refresh();
            pos = 100;
            grdTotal = 0;
            n = 0;
        }

        string tentk;
        public string message
        {
            get { return tentk; }
            set { tentk = value; }

        }
        private void Billings_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'petShopDbDataSet.CustomerTbl' table. You can move, or remove it, as needed.
            this.customerTblTableAdapter.Fill(this.petShopDbDataSet.CustomerTbl);
            EmpName.Text = tentk;

        }

    }
}
