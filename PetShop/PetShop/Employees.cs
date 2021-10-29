using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace PetShop
{
    public partial class Employees : Form
    {

        public Employees()
        {
            InitializeComponent();
            DisplayEmployee();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-16TE5IR;Initial Catalog=PetShopDb;Integrated Security=True");
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void DisplayEmployee()
        {
            Con.Open();
            string Query = "Select EmpNum [STT], EmpName[Họ tên], EmpAdd [Địa chỉ],EmpDOB [Ngày sinh], EmpPhone [SDT] from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query,Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmployeeDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void clear()
        {
            EmpNameTb.Clear();
            EmpAddTb.Clear();
            EmpPhoneTb.Clear();
            PasswordTb.Clear();
        }
        private void Savebtn_Click(object sender, EventArgs e)
        {
          
        }
        int Key = 0;
        private void Savebtn_Click_1(object sender, EventArgs e)
        {
            if(EmpNameTb.Text == " " || EmpPhoneTb.Text == " " || PasswordTb.Text == " ")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into EmployeeTbl(EmpName,EmpAdd, EmpPhone, EmpDOB,EmpPass) values(@EN,@EA,@EP,@ED,@EPa)",Con);
                    cmd.Parameters.Add("@EN", EmpNameTb.Text);
                    cmd.Parameters.Add("@EA", EmpAddTb.Text);
                    cmd.Parameters.Add("@EP", EmpPhoneTb.Text);
                    cmd.Parameters.Add("@ED", EmpDOBTb.Value.Date);
                    cmd.Parameters.Add("@EPa", PasswordTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công!");
                    Con.Close();
                    DisplayEmployee();
                    clear();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void EmployeeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpNameTb.Text = EmployeeDGV.SelectedRows[0].Cells[1].Value.ToString();
            EmpAddTb.Text = EmployeeDGV.SelectedRows[0].Cells[2].Value.ToString();
            EmpDOBTb.Text = EmployeeDGV.SelectedRows[0].Cells[3].Value.ToString();
            EmpPhoneTb.Text = EmployeeDGV.SelectedRows[0].Cells[4].Value.ToString();
            PasswordTb.Text = EmployeeDGV.SelectedRows[0].Cells[5].Value.ToString();
            if(EmpNameTb.Text == " ")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(EmployeeDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == " " || EmpPhoneTb.Text == " " || PasswordTb.Text == " ")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update EmployeeTbl set EmpName =@EN,EmpAdd =@EA, EmpPhone =@EP, EmpDOB =@ED,EmpPass =@EPa where EmpNum = @EKey", Con);
                    cmd.Parameters.Add("@EN", EmpNameTb.Text);
                    cmd.Parameters.Add("@EA", EmpAddTb.Text);
                    cmd.Parameters.Add("@EP", EmpPhoneTb.Text);
                    cmd.Parameters.Add("@ED", EmpDOBTb.Value.Date);
                    cmd.Parameters.Add("@EPa", PasswordTb.Text);
                    cmd.Parameters.Add("@EKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                    Con.Close();
                    DisplayEmployee();
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
            if (Key ==0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from EmployeeTbl where EmpNum = @EmpKey", Con);
                    cmd.Parameters.Add("@Empkey", Key);
                    
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!");
                    Con.Close();
                    DisplayEmployee();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Customer Obj = new Customer();
            Obj.message = EmpName.Text;
            Obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Products Obj = new Products();
            Obj.message = EmpName.Text;
            Obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.message = EmpName.Text;
            hm.Show();
            this.Hide();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

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
        string tentk;
        public string message
        {
            get { return tentk; }
            set { tentk = value; }

        }
       
        private void Employees_Load(object sender, EventArgs e)
        {
            EmpName.Text = tentk;
        }
    }
}
    
