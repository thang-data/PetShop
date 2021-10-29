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
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
            DisplayProducts();
            cmbCategory.SelectedIndex = 0;
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-16TE5IR;Initial Catalog=PetShopDb;Integrated Security=True");
        private void DisplayProducts()
        {
            Con.Open();
            string Query = "Select PrID [STT], PrName[Họ tên], PrCat [Thể loại],PrQty [Số lượng], PrPrice [Giá tiền] from ProductTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            productDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void clear()
        {
            txtName.Clear();
            txtPrice.Clear();
            txtQuanlity.Clear();
            cmbCategory.SelectedIndex = 0;
        }
        int Key = 0;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == " " || cmbCategory.SelectedIndex == -1 || txtPrice.Text == " " || txtQuanlity.Text == " ")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ProductTbl(PrName,PrCat, PrQty, PrPrice) values(@EN,@EC,@EQ,@EPr)", Con);
                    cmd.Parameters.Add("@EN", txtName.Text);
                    cmd.Parameters.Add("@EC", cmbCategory.SelectedItem.ToString());
                    cmd.Parameters.Add("@EQ", txtQuanlity.Text);

                    cmd.Parameters.Add("@EPr", txtPrice.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công!");
                    Con.Close();
                    DisplayProducts();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void productDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txtName.Text = productDGV.SelectedRows[0].Cells[1].Value.ToString();
            cmbCategory.Text = productDGV.SelectedRows[0].Cells[2].Value.ToString();
            txtQuanlity.Text = productDGV.SelectedRows[0].Cells[3].Value.ToString();
            txtPrice.Text = productDGV.SelectedRows[0].Cells[4].Value.ToString();
            
            if (txtName.Text == " ")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(productDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from ProductTbl where PrID = @PKey", Con);
                    cmd.Parameters.Add("@PKey", Key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!");
                    Con.Close();
                    DisplayProducts();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == " " || cmbCategory.SelectedIndex == -1 || txtPrice.Text == " " || txtQuanlity.Text == " ")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update ProductTbl set PrName =@PN,PrCat =@PC, PrQty =@PQ, PrPrice =@PR where PrID = @PKey", Con);
                    cmd.Parameters.Add("@PN", txtName.Text);
                    cmd.Parameters.Add("@PC", cmbCategory.SelectedItem.ToString());
                    cmd.Parameters.Add("@PQ", txtQuanlity.Text);
                    cmd.Parameters.Add("@PR", txtPrice.Text);
                    
                    cmd.Parameters.Add("@PKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                    Con.Close();
                    DisplayProducts();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

            Home hm = new Home();
            hm.message = EmpName.Text;
            hm.Show();
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
            Home hm = new Home();
            hm.message = EmpName.Text;
            hm.Show();
            this.Hide();
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
        private void Products_Load(object sender, EventArgs e)
        {
            EmpName.Text = tentk;

        }
    }
}
