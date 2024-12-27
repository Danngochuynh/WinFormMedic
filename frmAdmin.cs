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
    public partial class frmAdmin : Form
    {
        String user = ""; 

        public frmAdmin()
        {
            InitializeComponent();
        }
        public string ID
        {
            get
            {
                return user.ToString();
            }

        } 
        //contructor
        public frmAdmin(string userName)
        {
            InitializeComponent();
            lblUsername.Text = userName;
            user = userName;
            uC_ViewUser1.ID = ID;
            uC_Profile1.ID = ID;

        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(); 
            f1.Show();
            this.Hide(); 
        }

        private void btnDashbord_Click(object sender, EventArgs e)
        {
            uC_BangDieuKhien1.Visible = true;
            uC_BangDieuKhien1.BringToFront();

        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            uC_BangDieuKhien1.Visible = false;
            UC_AddUser1.Visible = false;
            uC_ViewUser1.Visible = false;
            uC_Profile1.Visible = false; 
            btnDashbord.PerformClick();
          

        }

        private void btnUserName_Click(object sender, EventArgs e)
        {
            UC_AddUser1.Visible = true;
            UC_AddUser1.BringToFront();
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void btnViewUser_Click(object sender, EventArgs e)
        {
            uC_ViewUser1.Visible = true;
            uC_ViewUser1.BringToFront();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            uC_Profile1.Visible = true;
            uC_Profile1.BringToFront();
        }
    }
}
