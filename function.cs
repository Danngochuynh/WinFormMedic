using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms; 
using System.Data.SqlClient; 

namespace DoAnLapTrinhUngDung
{
    internal class function
    {
        public static bool isEligibleForDiscountGlobal = false;
        public static double discountRate = 0.0;
        public SqlConnection getConnection()
        {
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "data source = Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ASUS\\Documents\\pharmacy.mdf;Integrated Security=True;Connect Timeout=30";
            //return conn;
            //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\pharmacy.mdf;Integrated Security=True;Connect Timeout=30");
            //return conn;
            return new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\pharmacy.mdf;Integrated Security=True;Connect Timeout=30");
        }
        public DataSet getData(String query)
        {
            //SqlConnection conn = getConnection();
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = conn;
            //cmd.CommandText = query;
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //return ds;
            SqlConnection conn = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi chi tiết
                MessageBox.Show("Lỗi khi thực hiện truy vấn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }
        public void setData(String query, String msg)
        {
            //SqlConnection con = getConnection();
            //SqlCommand cmd = new SqlCommand();
            //con.Open();
            //cmd.CommandText = query;
            //cmd.ExecuteNonQuery();
            //con.Close();
            //MessageBox.Show(msg, " Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand(query, con); // Gán connection và query cho SqlCommand
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show(msg, "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
        public static void SetDiscountRate(double rate)
        {
            isEligibleForDiscountGlobal = true;
            discountRate = rate;
        }

        // Phương thức reset giảm giá
        public static void ResetDiscount()
        {
            isEligibleForDiscountGlobal = false;
            discountRate = 0.0;
        }
    }
}
