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
    public partial class fSuaNhaCungCap : Form
    {
        public fSuaNhaCungCap()
        {
            InitializeComponent();
            LoadViewSuaNhaCungCap(@"select id,ten,phone,email,diaChi from NhaCungCap");
        }

        private void lsvSuaNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(ListViewItem item in lsvSuaNhaCungCap.SelectedItems)
            {
                tbIdCu.Text = item.SubItems[1].Text;
                tbIdMoi.Text= item.SubItems[1].Text;
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
            string idCu = tbIdCu.Text;
            string idMoi = tbIdMoi.Text;
            string tenCu = tbTenCu.Text;
            string tenMoi = tbTenMoi.Text;
            string phoneMoi = tbPhoneMoi.Text;
            string emailMoi = tbEmailMoi.Text;
            string diaChiMoi = tbDiaChiMoi.Text;
            try
            {
                if(idCu != "" && idMoi != "")
                {
                    SqlCommand com = new SqlCommand();
                    string sqlString = @"update NhaCungCap set id = N'"+idMoi+@"', ten = N'"+tenMoi+@"', phone = N'"+phoneMoi+@"', email = N'"+emailMoi+@"',diaChi = N'"+diaChiMoi+@"' where id = N'"+idCu+@"'";
                    com.CommandText = sqlString;
                    com.Connection = connect;
                    int rowCount = com.ExecuteNonQuery();
                    LoadViewSuaNhaCungCap(@"select id,ten,phone,email,diaChi from NhaCungCap");
                }
                else
                {
                    MessageBox.Show(@"Hãy nhập đầy đủ thông tin về mã cũ của nhà cung cấp hoặc các thông tin mà bạn muốn sửa đổi!");
                }

            }
            catch
            {
                MessageBox.Show(@"Có lỗi xảy ra khi sửa bản ghi nhà cung cấp!");
            }
            finally
            {
                connect.Close();
                connect.Dispose();
                connect = null;
                tbIdCu.Text = null;
                tbIdMoi.Text = null;
                tbTenCu.Text = null;
                tbTenMoi.Text = null;
                tbPhoneCu.Text = null;
                tbPhoneMoi.Text = null;
                tbEmailCu.Text = null;
                tbEmailMoi.Text = null;
                tbDiaChiCu.Text = null;
                tbDiaChiMoi.Text = null;
            }
        }

        private void LoadViewSuaNhaCungCap(string sql)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            lsvSuaNhaCungCap.Items.Clear();
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
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
                            //thêm dòng vào list view Nhà cung cấp
                            ListViewItem item = new ListViewItem(dem.ToString());
                            item.SubItems.Add(idValue);
                            item.SubItems.Add(tenValue);
                            item.SubItems.Add(phoneValue);
                            item.SubItems.Add(emailValue);
                            item.SubItems.Add(diaChiValue);
                            lsvSuaNhaCungCap.Items.Add(item);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show(@"Không lấy được dữ liệu!");
                }
                finally
                {
                    reader.Dispose();
                }
            }
            catch
            {
                MessageBox.Show(@"Có lỗi xảy ra khi load danh sách Nhà cung cấp!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }
    }
}
