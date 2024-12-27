using DoAnLapTrinhUngDung.TroChoi;
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

namespace DoAnLapTrinhUngDung
{
    public partial class frmNhapThongTinNguoiMuaThuoc : Form
    {
        function fun = new function();
        private bool daChoiXong = false;
        public frmNhapThongTinNguoiMuaThuoc()
        {
            InitializeComponent();
        }
        public bool isEligibleForDiscount { get; private set; } = false;
        private void btnNhap_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text;
            string gioiTinh = rbtNam.Checked ? "Nam" : "Nữ";
            string soDienThoai = txtSoDienThoai.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;
            string diaChi = txtQueQuan.Text; 
            long mobile;

            if (!long.TryParse(soDienThoai, out mobile))
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int tuoi = DateTime.Now.Year - ngaySinh.Year;
            if (ngaySinh > DateTime.Now.AddYears(-tuoi)) tuoi--;
            if ((gioiTinh == "Nữ" && tuoi > 55) || (gioiTinh == "Nam" && tuoi > 60))
            {
                function.isEligibleForDiscountGlobal = true;
            }
            else
            {
                function.isEligibleForDiscountGlobal = false;
            }
            if (tuoi < 12)
            {
                frmTroChoiTracNghiem frmTracNghiem = new frmTroChoiTracNghiem();
                this.Close();
                frmTracNghiem.ShowDialog();
                if (frmTracNghiem.IsCompleted)
                {
                    function.discountRate = frmTracNghiem.Score == 3 ? 0.3 : 0.1;
                }
            }
            string query = "SELECT COUNT(*) FROM Customers WHERE PhoneNumber = @soDienThoai";
            using (SqlConnection conn = fun.getConnection())
            using (SqlCommand checkCmd = new SqlCommand(query, conn))
            {
                conn.Open();
                checkCmd.Parameters.AddWithValue("@soDienThoai", soDienThoai);
                int userExists = (int)checkCmd.ExecuteScalar();

                if (userExists > 0)
                {
                    MessageBox.Show("Khách Hàng Đã Tồn Tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    query = "INSERT INTO Customers (FullName, Gender, PhoneNumber, BirthDate, Address) " +
                            "VALUES (@hoTen, @gioiTinh, @soDienThoai, @ngaySinh, @diaChi)";
                    using (SqlCommand insertCmd = new SqlCommand(query, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@hoTen", hoTen);
                        insertCmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                        insertCmd.Parameters.AddWithValue("@soDienThoai", soDienThoai);
                        insertCmd.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                        insertCmd.Parameters.AddWithValue("@diaChi", diaChi); // Đổi tên cho phù hợp với bảng Customers

                        if (insertCmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Nhập Thông Tin Thành Công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Nhập Thông Tin Thất Bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

        }
        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            txtQueQuan.Clear();
            rbtNam.Checked = true;
            dtpNgaySinh.Value = DateTime.Now;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
