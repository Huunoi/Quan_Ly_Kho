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
    public partial class fSuaMatHang : Form
    {
        public fSuaMatHang()
        {
            InitializeComponent();
            LoadViewSuaMatHang();
        }

        private void cbDonViTinhMoi_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            conn.Open();
            List<DonVi> ls = new List<DonVi>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"select DonVi.id,DonVi.ten from DonVi";
                DbDataReader reader = cmd.ExecuteReader();
                try
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int idIndex = reader.GetOrdinal("id");
                            int idValue = Convert.ToInt32(reader.GetValue(idIndex));
                            int tenIndex = reader.GetOrdinal("ten");
                            string tenValue = Convert.ToString(reader.GetValue(tenIndex));
                            ls.Add(new DonVi() { id = idValue, ten = tenValue });
                        }
                    }
                }
                finally
                {
                    reader.Dispose();
                }
            }
            catch
            {
                MessageBox.Show("không lấy được dữ liệu đơn vị!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            cbDonViTinhMoi.DataSource = ls;
            cbDonViTinhMoi.DisplayMember = "ten";
        }

        private void cbDonViTinhMoi_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                DonVi dv = cb.SelectedValue as DonVi;
                cbDonViTinhMoi.Tag = dv.id;
            }
        }

        private void LoadViewSuaMatHang()
        {
            dtgvSuaMatHang.Rows.Clear();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            conn.Open();
            List<MatHang> ls = new List<MatHang>();
            try
            {
                string sql = @"select MatHang.id,MatHang.ten,MatHang.idDonVi,DonVi.ten as 'tenDV'"
                            + @"from MatHang,DonVi where MatHang.idDonVi=DonVi.id";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                DbDataReader reader = cmd.ExecuteReader();
                try
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int idIndex = reader.GetOrdinal("id");//lấy ra thứ tự của cột id
                            string idValue = Convert.ToString(reader.GetValue(idIndex));
                            int tenIndex = reader.GetOrdinal("ten");
                            string tenValue = Convert.ToString(reader.GetValue(tenIndex));
                            int idDonViIndex = reader.GetOrdinal("idDonVi");
                            int idDonViValue = Convert.ToInt32(reader.GetValue(idDonViIndex));
                            int tenDonViIndex = reader.GetOrdinal("tenDV");
                            string tenDonViValue = Convert.ToString(reader.GetValue(tenDonViIndex));
                            ls.Add(new MatHang() { id = idValue, ten = tenValue, idDonVi = idDonViValue, tenDonVi = tenDonViValue });
                        }
                    }
                }
                catch { }
                finally
                {
                    reader.Dispose();
                }
            }
            catch
            {
                MessageBox.Show("Không load được view mặt hàng!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }

            //đổ dữ liệu vào dataGirdView
            int count = 1;
            foreach (MatHang mh in ls)
            {
                dtgvSuaMatHang.Rows.Add(count, mh.id, mh.ten, mh.tenDonVi);
                count++;
            }
        }

        private void dtgvSuaMatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            tbIdMatHangCu.Text = dtgvSuaMatHang.Rows[numrow].Cells[1].Value.ToString();
            tbIdMatHangMoi.Text = dtgvSuaMatHang.Rows[numrow].Cells[1].Value.ToString();
            tbTenMatHangCu.Text = dtgvSuaMatHang.Rows[numrow].Cells[2].Value.ToString();
            tbTenMatHangMoi.Text = dtgvSuaMatHang.Rows[numrow].Cells[2].Value.ToString();
            tbDonViTinhCu.Text = dtgvSuaMatHang.Rows[numrow].Cells[3].Value.ToString();
            cbDonViTinhMoi.Text= dtgvSuaMatHang.Rows[numrow].Cells[3].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            connect.Open();
            try
            {
                string idCu = tbIdMatHangCu.Text;
                string idMoi = tbIdMatHangMoi.Text;
                string ten = tbTenMatHangMoi.Text;
                string tenDonVi = cbDonViTinhMoi.Text;
                string idDonVi="";
                int idDonViMoi = LayIdDonViTheoTen(tenDonVi);
                if (cbDonViTinhMoi.Tag != null)
                {
                    idDonVi = cbDonViTinhMoi.Tag.ToString();
                    if (idCu != "" && idMoi != "")
                    {
                        string sql = @"update MatHang set id=N'" + idMoi + @"', ten=N'" + ten + @"', idDonVi= N'" + idDonVi + @"' where id=N'" + idCu + @"'";
                        SqlCommand com = connect.CreateCommand();
                        com.CommandText = sql;
                        int dem = com.ExecuteNonQuery();
                        MessageBox.Show(@"sửa mặt hàng thàng công!");
                    }
                }
                else if(idDonViMoi != -1)
                {
                    idDonVi = Convert.ToString(idDonViMoi);
                    if (idCu != "" && idMoi != "")
                    {
                        string sql = @"update MatHang set id=N'" + idMoi + @"', ten=N'" + ten + @"', idDonVi= N'" + idDonVi + @"' where id=N'" + idCu + @"'";
                        SqlCommand com = connect.CreateCommand();
                        com.CommandText = sql;
                        int dem = com.ExecuteNonQuery();
                        MessageBox.Show(@"sửa mặt hàng thàng công!");
                    }
                }
                else
                {
                    MessageBox.Show(@"đơn vị không hợp lệ. hãy thêm đơn vị mới hoặc chọn lại");
                }
                //MessageBox.Show(cbDonViTinhMoi.Tag.ToString());
                //MessageBox.Show(tbTenMatHangCu.Text.ToString());
                //MessageBox.Show(cbDonViTinhMoi.Tag.ToString());
                LoadViewSuaMatHang();
            }
            catch
            {
                MessageBox.Show(@"Không thể sửa mặt hàng!");
            }
            finally
            {
                connect.Close();
                connect.Dispose();
                connect = null;
                tbIdMatHangCu.Text = null;
                tbIdMatHangMoi.Text = null;
                tbTenMatHangCu.Text = null;
                tbTenMatHangMoi.Text = null;
                tbDonViTinhCu.Text = null;
                cbDonViTinhMoi.Text = null;
                cbDonViTinhMoi.Tag = null;
            }
        }

        //*****tìm id đơn vị theo tên đơn vị
        private int LayIdDonViTheoTen(string ten)
        {
            int id = -1;
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            conn.Open();
            try
            {
                string sql = @"select top(1) id,ten from DonVi where ten =N'"+ ten +@"'";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                DbDataReader reader = cmd.ExecuteReader();
                try
                {
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            int idIndex = reader.GetOrdinal("id");
                            id = Convert.ToInt32(reader.GetValue(idIndex));
                        }
                    }
                }
                catch
                {
                    MessageBox.Show(@"Đơn vị không tồn tại");
                }
                finally
                {
                    reader.Dispose();
                }
            }
            catch
            {

            }
            finally
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
            return id;
        }


    }
}
