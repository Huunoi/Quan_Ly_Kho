using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KhoHang
{
    public partial class fSuaNhanVien : Form
    {
        public fSuaNhanVien()
        {
            InitializeComponent();
            LoadViewSuaNhanVien(@"select id,ten,phone,email,diaChi from NhanVien");
        }

        public void LoadViewSuaNhanVien(string sql)
        {
            lsvSuaNhanVien.Items.Clear();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                DbDataReader reader = cmd.ExecuteReader();
                int dem = 0;
                try
                {
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            dem++;
                            int idIndex = reader.GetOrdinal("id");
                            string idValue = Convert.ToString(reader.GetValue(idIndex));
                            int tenIndex = reader.GetOrdinal("ten");
                            string tenValue = Convert.ToString(reader.GetValue(tenIndex));
                            int phoneIndex = reader.GetOrdinal("phone");
                            string phoneValue = Convert.ToString(reader.GetValue(phoneIndex));
                            int emailIndex = reader.GetOrdinal("email");
                            string emailValue = Convert.ToString(reader.GetValue(emailIndex));
                            int diaChiIndex = reader.GetOrdinal("diaChi");
                            string diaChiValue = Convert.ToString(reader.GetValue(diaChiIndex));
                            ListViewItem item = new ListViewItem(dem.ToString());
                            item.SubItems.Add(idValue);
                            item.SubItems.Add(tenValue);
                            item.SubItems.Add(phoneValue);
                            item.SubItems.Add(emailValue);
                            item.SubItems.Add(diaChiValue);
                            lsvSuaNhanVien.Items.Add(item);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show(@"Không lấy được danh sách nhân viên!");
                }
                finally
                {
                    reader.Dispose();
                }
            }
            catch
            {
                MessageBox.Show(@"Có lỗi khi load view Nhân viên!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }
        private void lsvSuaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(ListViewItem item in lsvSuaNhanVien.SelectedItems)
            {
                tbIdCu.Text = item.SubItems[1].Text;
                tbIdMoi.Text = item.SubItems[1].Text;
                tbTenCu.Text = item.SubItems[2].Text;
                tbTenMoi.Text = item.SubItems[2].Text;
                tbPhoneCu.Text = item.SubItems[3].Text;
                tbPhoneMoi.Text = item.SubItems[3].Text;
                tbEmailCu.Text = item.SubItems[4].Text;
                tbEmailMoi.Text = item.SubItems[4].Text;
                tbDiaChiCu.Text = item.SubItems[5].Text;
                tbDiaChiMoi.Text = item.SubItems[5].Text;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            connect.Open();
            string idNVCu = tbIdCu.Text;
            string idNVMoi = tbIdMoi.Text;
            string tenNVMoi = tbTenMoi.Text;
            string phoneNVMoi = tbPhoneMoi.Text;
            string emailNVMoi = tbEmailMoi.Text;
            string diaChiNVMoi = tbDiaChiMoi.Text;
            try
            {
                if(idNVCu != "" && idNVMoi != "")
                {
                    SqlCommand com = new SqlCommand();
                    string sql = @"update NhanVien set id= N'" + idNVMoi + @"',ten= N'" + tenNVMoi + @"',phone= N'" + phoneNVMoi + @"',email= N'" + emailNVMoi + @"',diaChi= N'" + diaChiNVMoi + @"' where id= N'" + idNVCu + @"'";
                    com.CommandText = sql;
                    com.Connection = connect;
                    int rowCount = com.ExecuteNonQuery();
                    LoadViewSuaNhanVien(@"select id,ten,phone,email,diaChi from NhanVien");
                }
                else
                {
                    MessageBox.Show(@"Bạn phải nhập mã cũ của nhân viên cần sửa và điền thông tin mới!");
                }
            }
            catch
            {
                MessageBox.Show(@"Có lỗi xảy ra! không sửa được nhân viên!");
            }
            finally
            {
                connect.Close();
                connect.Dispose();
                connect = null;
            }
        }
    }
}
