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
    public partial class Login : Form
    {
      
        public Login()
        {
            InitializeComponent();
            string tk = txtUser.Text;
            
        }
        
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-16TE5IR;Initial Catalog=PetShopDb;Integrated Security=True");

        private void lbReset_Click(object sender, EventArgs e)
        {
            txtUser.Text = "";
            txtPass.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string tk = txtUser.Text;
                string mk = txtPass.Text;
                string sql = "select* from EmployeeTbl where EmpName = '" + tk + "'and EmpPass = '" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, Con);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    Home hm = new Home();
                    hm.message = txtUser.Text;
                    hm.Show();
                    this.Hide();
                    /*bl.ShowDialog();*/


                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
