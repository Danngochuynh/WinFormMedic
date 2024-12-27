using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLapTrinhUngDung
{
    
    public partial class Form1 : Form
    {
        function fn = new function();
        String query;
        DataSet ds;
        private bool isPasswordHidden = false; //Bắt đầu với mật khẩu hiển thị
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            query = "select * from users";
            ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count == 0)
            {
                if (txtUsername.Text == "root" && txtPassword.Text == "root")
                {
                    frmAdmin admin = new frmAdmin();
                    admin.Show();
                    this.Hide();
                }
            }
            else
            {
                query = "select * from users where username = '" + txtUsername.Text + "' and pass = '" + txtPassword.Text + "'";
                ds = fn.getData(query);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    String role = ds.Tables[0].Rows[0][1].ToString();
                    if (role == "Admin")
                    {
                        frmAdmin admin = new frmAdmin(txtUsername.Text);
                        admin.Show();
                        this.Hide();
                    }
                    else if (role == "User")
                    {
                        frmUsers user = new frmUsers();
                        user.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Tên Người Dùng Hoặc Mật Khẩu Sai!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //if (txtUsername.Text == "Admin1" && txtPassword.Text == "Pass")
            //{
            //    frmAdmin frmAdmin = new frmAdmin();
            //    frmAdmin.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("Lỗi UserName hoặc Password", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnTailai_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear(); 
        }

        private void btnAnMatKhau_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*'; 
            btnHienMatKhau.BringToFront();    
            btnAnMatKhau.SendToBack();        
            isPasswordHidden = true;
        }

        private void btnHienMatKhau_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '\0';  
            btnAnMatKhau.BringToFront();      
            btnHienMatKhau.SendToBack();      
            isPasswordHidden = false;
        }
    }
}
