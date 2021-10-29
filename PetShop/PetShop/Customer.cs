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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
            DisplayCustomer();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-16TE5IR;Initial Catalog=PetShopDb;Integrated Security=True");
        private void DisplayCustomer()
        {
            Con.Open();
            string Query = "Select CusID [STT], CusName[Họ tên], CusAdd [Địa chỉ],CusPhone [SDT] from CustomerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CustomerDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void clear()
        {
            CusNameTb.Clear();
            CusAddTb.Clear();
            CusPhoneTb.Clear();
        }
        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (CusNameTb.Text == " " || CusAddTb.Text == " " || CusPhoneTb.Text == " ")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into CustomerTbl(CusName,CusAdd, CusPhone) values(@CN,@CA,@CP)", Con);
                    cmd.Parameters.Add("@CN", CusNameTb.Text);
                    cmd.Parameters.Add("@CA", CusAddTb.Text);
                    cmd.Parameters.Add("@CP", CusPhoneTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công!");
                    Con.Close();
                    DisplayCustomer();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int Key = 0;
        private void CustomerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CusNameTb.Text = CustomerDGV.SelectedRows[0].Cells[1].Value.ToString();
            CusAddTb.Text = CustomerDGV.SelectedRows[0].Cells[2].Value.ToString();
            CusPhoneTb.Text = CustomerDGV.SelectedRows[0].Cells[3].Value.ToString();

            if (CusNameTb.Text == " ")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CustomerDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            if (CusNameTb.Text == " " || CusAddTb.Text == " " || CusPhoneTb.Text == " ")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update CustomerTbl set CusName =@CN,CusAdd =@CA, CusPhone =@CP where CusID = @CKey", Con);
                    cmd.Parameters.Add("@CN", CusNameTb.Text);
                    cmd.Parameters.Add("@CA", CusAddTb.Text);
                    cmd.Parameters.Add("@CP", CusPhoneTb.Text);
                    cmd.Parameters.Add("@CKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                    Con.Close();
                    DisplayCustomer();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from CustomerTbl where CusID = @CusKey", Con);
                    cmd.Parameters.Add("@Cuskey", Key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!");
                    Con.Close();
                    DisplayCustomer();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        string tentk;
        public string message
        {
            get { return tentk; }
            set { tentk = value; }

        }
        private void Customer_Load(object sender, EventArgs e)
        {
            EmpName.Text = tentk;
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

        private void label5_Click(object sender, EventArgs e)
        {
            Billings bl = new Billings();
            bl.message = EmpName.Text;
            bl.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.message = EmpName.Text;
            hm.Show();
            this.Hide();
        }
    }
}
