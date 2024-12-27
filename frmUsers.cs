using DoAnLapTrinhUngDung.User;
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
    public partial class frmUsers : Form
    {
        private bool isEligibleToBuy = false;
        public frmUsers()
        {
            InitializeComponent();
        }
        private void btnBanThuoc_Click(object sender, EventArgs e)
        {
            uS_SellMedicine1.Visible = true;
            uS_SellMedicine1.BringToFront();
            //if (!kiemTra) // kiemTra xác định nếu chưa nhập thông tin
            //{
            //    frmNhapThongTinNguoiMuaThuoc frmNhap = new frmNhapThongTinNguoiMuaThuoc();
            //    if (frmNhap.ShowDialog() == DialogResult.OK)
            //    {
            //        kiemTra = true; // Đã nhập thông tin thành công
            //        uS_SellMedicine1.Visible = true;
            //        uS_SellMedicine1.BringToFront();
            //    }
            //}
            //else
            //{
            //    // Chuyển thẳng đến trang bán thuốc nếu đã nhập thông tin
            //    uS_SellMedicine1.Visible = true;
            //    uS_SellMedicine1.BringToFront();
            //}
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide(); 
        }

        private void btnDashBord_Click(object sender, EventArgs e)
        {
            uS_DashBord1.Visible = true;
            uS_DashBord1.BringToFront();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            uS_DashBord1.Visible = false;
            uS_AddMedicine1.Visible = false;
            uS_ViewMedicine1.Visible = false;
            uS_UpdateMedicine1.Visible = false;
            uS_SellMedicine1.Visible = false;
            uS__CheckValidityMedicine1.Visible = false;
            btnDashBord.PerformClick(); 
        }

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            uS_AddMedicine1.Visible= true;
            uS_AddMedicine1.BringToFront();
        }

        private void uS_AddMedicine1_Load(object sender, EventArgs e)
        {

        }

        private void btnXemThuoc_Click(object sender, EventArgs e)
        {
            uS_ViewMedicine1.Visible = true;
            uS_ViewMedicine1.BringToFront();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSuaDoiThuoc_Click(object sender, EventArgs e)
        {
            uS_UpdateMedicine1.Visible = true;
            uS_UpdateMedicine1.BringToFront();
        }

        private void btnKiemTraHanSuDungThuoc_Click(object sender, EventArgs e)
        {
            uS__CheckValidityMedicine1.Visible = true;
            uS__CheckValidityMedicine1.BringToFront();
        }

       

        private void btnNhapThongTin_Click(object sender, EventArgs e)
        {
            frmNhapThongTinNguoiMuaThuoc frmNhap = new frmNhapThongTinNguoiMuaThuoc();
            if (frmNhap.ShowDialog() == DialogResult.OK)
            {
                // Hiển thị trang bán thuốc sau khi nhập thông tin thành công
                uS_SellMedicine1.Visible = false;
                uS_SellMedicine1.BringToFront();
            }
        }

        private void uS_SellMedicine1_Load(object sender, EventArgs e)
        {

        }
    }
}
