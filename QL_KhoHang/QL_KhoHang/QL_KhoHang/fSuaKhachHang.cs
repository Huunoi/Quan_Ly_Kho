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
    public partial class fSuaKhachHang : Form
    {
        public fSuaKhachHang()
        {
            InitializeComponent();
            LoadViewKhachHang(@"select id,ma,ten,phone,email,diaChi from KhachHang");
        }

        public void LoadViewKhachHang(string sql)
        {
            lsvSuaKhachHang.Items.Clear();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                DbDataReader reader = cmd.ExecuteReader();
                int dem = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dem++;
                        int idIndex = reader.GetOrdinal("id");
                        string idValue = Convert.ToString(reader.GetValue(idIndex));
                        int maIndex = reader.GetOrdinal("ma");
                        string maValue = Convert.ToString(reader.GetValue(maIndex));
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
                        item.SubItems.Add(maValue);
                        item.SubItems.Add(tenValue);
                        item.SubItems.Add(phoneValue);
                        item.SubItems.Add(emailValue);
                        item.SubItems.Add(diaChiValue);
                        lsvSuaKhachHang.Items.Add(item);
                    }
                }
            }
            catch
            {
                MessageBox.Show(@"Không lấy được danh sách khách hàng!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }

        }

        private void lsvSuaKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(ListViewItem item in lsvSuaKhachHang.SelectedItems)
            {
                tbIdCu.Text = item.SubItems[1].Text;
                tbIdMoi.Text = item.SubItems[1].Text;
                tbMaCu.Text= item.SubItems[2].Text;
                tbMaMoi.Text = item.SubItems[2].Text;
                tbTenCu.Text = item.SubItems[3].Text;
                tbTenMoi.Text = item.SubItems[3].Text;
                tbPhoneCu.Text = item.SubItems[4].Text;
                tbPhoneMoi.Text = item.SubItems[4].Text;
                tbEmailCu.Text = item.SubItems[5].Text;
                tbEmailMoi.Text = item.SubItems[5].Text;
                tbDiaChiCu.Text = item.SubItems[6].Text;
                tbDiaChiMoi.Text = item.SubItems[6].Text;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            connection.Open();
            string idCu = tbIdCu.Text;
            string idMoi = tbIdMoi.Text;
            string tenMoi = tbTenMoi.Text;
            string maMoi = tbMaMoi.Text;
            string phoneMoi = tbPhoneMoi.Text;
            string emailMoi = tbEmailMoi.Text;
            string diaChiMoi = tbDiaChiMoi.Text;
            try
            {
                if(idCu != "" && idMoi !="")
                {
                    if(tenMoi !="")
                    {
                        SqlCommand com = new SqlCommand();
                        com.Connection = connection;
                        string sql = @"update KhachHang set ma=N'"+ maMoi + @"',ten=N'" + tenMoi + @"',phone=N'" + phoneMoi + @"',email=N'" + emailMoi + @"',diaChi=N'" + diaChiMoi + @"' where id=N'" + idCu + @"'";
                        com.CommandText = sql;
                        com.ExecuteNonQuery();
                        LoadViewKhachHang(@"select id,ma,ten,phone,email,diaChi from KhachHang");
                    }
                    else
                    {
                        MessageBox.Show(@"Bạn chưa nhập tên khách hàng mới!");
                    }
                }
                else
                {
                    MessageBox.Show(@"Hãy chọn khách hàng cần sửa thông tin!");
                }
            }
            catch
            {
                MessageBox.Show(@"Có lỗi xảy ra! Sửa khách hàng không thành công!");
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
                tbIdCu.Text = null;
                tbMaCu.Text = null;
                tbTenCu.Text = null;
                tbPhoneCu.Text = null;
                tbEmailCu.Text = null;
                tbDiaChiCu.Text = null;
                tbIdMoi.Text = null;
                tbMaMoi.Text = null;
                tbTenMoi.Text = null;
                tbPhoneMoi.Text = null;
                tbEmailMoi.Text = null;
                tbDiaChiMoi.Text = null;
            }
        }
    }
}
