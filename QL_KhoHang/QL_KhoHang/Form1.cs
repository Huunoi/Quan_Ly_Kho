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
    public partial class fAdmin : Form
    {
        public SqlConnection connectString = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
        public fAdmin()
        {
            InitializeComponent();
            LoadViewMatHang();
            LoadViewNhaCungCap(@"select id,ten,phone,email,diaChi from NhaCungCap");
            LoadViewNhanVien(@"select id,ten,phone,email,diaChi from NhanVien");
            LoadViewKhachHang(@"select id,ma,ten,phone,email,diaChi from KhachHang");
        }

        //**************Moden Mặt hàng***************
        public void LoadViewMatHang()
        {
            lsvMatHang.Items.Clear();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            conn.Open();
            List<MatHang> ls = new List<MatHang>();
            try
            {
                string sql = @"select MatHang.id,MatHang.ten,MatHang.idDonVi,DonVi.ten as 'tenDV'"
                            +@"from MatHang,DonVi where MatHang.idDonVi=DonVi.id";
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
                            int idIndex = reader.GetOrdinal("id");//lấy ra thứ tự của cột id
                            string idValue = Convert.ToString(reader.GetValue(idIndex));
                            int tenIndex = reader.GetOrdinal("ten");
                            string tenValue = Convert.ToString(reader.GetValue(tenIndex));
                            int idDonViIndex = reader.GetOrdinal("idDonVi");
                            int idDonViValue = Convert.ToInt32(reader.GetValue(idDonViIndex));
                            int tenDonViIndex = reader.GetOrdinal("tenDV");
                            string tenDonViValue = Convert.ToString(reader.GetValue(tenDonViIndex));
                            ls.Add(new MatHang() { id = idValue, ten=tenValue,idDonVi=idDonViValue,tenDonVi=tenDonViValue });
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
            //đổ dữ liệu từ ls vào lsvMatHang
            int chay = 0;
            foreach (MatHang i in ls)
            {
                chay++;
                ListViewItem itemTG = new ListViewItem(chay.ToString());
                itemTG.SubItems.Add(i.id);
                itemTG.SubItems.Add(i.ten);
                itemTG.SubItems.Add(i.tenDonVi);
                lsvMatHang.Items.Add(itemTG);
            }
        }

        private void cbDonVi_Click(object sender, EventArgs e)
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
                    if(reader.HasRows)
                    {
                        while(reader.Read())
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
            cbDonVi.DataSource = ls;
            cbDonVi.DisplayMember = "ten";
        }

        private void cbDonVi_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if(cb.SelectedValue != null)
            {
                DonVi dv = cb.SelectedValue as DonVi;
                cbDonVi.Tag = dv.id;
            }
        }

        private void btnThemDonVi_Click(object sender, EventArgs e)
        {
            fDonVi f = new fDonVi();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnThemMatHang_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            connect.Open();
            try
            {
                string id = tbIdMatHang.Text;
                string ten = tbTenMatHang.Text;
                string idDonVi = cbDonVi.Tag.ToString();
                string sql = @"insert into MatHang(id,ten,idDonVi) values(N'"+id+@"',N'"+ten+ @"',N'"+idDonVi+@"')";
                SqlCommand com = connect.CreateCommand();
                com.CommandText = sql;
                int dem = com.ExecuteNonQuery();
                MessageBox.Show(@"Thêm thành mặt hàng công!");
                LoadViewMatHang();
            }
            catch
            {
                MessageBox.Show(@"Không thể thêm mặt hàng!");
            }
            finally
            {
                connect.Close();
                connect.Dispose();
                connect = null;
            }
        }

        private void btnSuaMatHang_Click(object sender, EventArgs e)
        {
            fSuaMatHang f = new fSuaMatHang();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnXoaMatHang_Click(object sender, EventArgs e)
        {
            string id = tbIdMatHang.Text;
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            conn.Open();
            int dem = 0;
            try
            {
                if(id != "")
                {
                    string sql = @"delete from MatHang where id=N'"+id+@"'";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    dem = cmd.ExecuteNonQuery();
                    LoadViewMatHang();
                    if(dem ==0)
                    {
                        MessageBox.Show(@"Không thể xóa bản ghi!");
                    }
                }
                else
                {
                    MessageBox.Show("Hãy nhập id!");
                }
                
            }
            catch
            {
                MessageBox.Show(@"Có lỗi xảy ra. Không thể xóa bản ghi!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }

        private void btnSearchMatHang_Click(object sender, EventArgs e)
        {
            lsvMatHang.Items.Clear();
            string tim = tbSearchMatHang.Text;
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            conn.Open();
            List<MatHang> ls = new List<MatHang>();
            try
            {
                string sql = @"select MatHang_DonVi.id, MatHang_DonVi.ten, MatHang_DonVi.idDonVi,MatHang_DonVi.tenDV " 
                                +@"from(select MatHang.id, MatHang.ten, MatHang.idDonVi, DonVi.ten as tenDV from MatHang, DonVi where MatHang.idDonVi = DonVi.id) as MatHang_DonVi" 
                                +@" where MatHang_DonVi.id like N'%"+tim+@"%' or MatHang_DonVi.ten like N'%"+tim+@"%'";
                //string sql = @"select *from(select MatHang.id,MatHang.ten,MatHang.idDonVi,DonVi.ten as tenDV from MatHang,DonVi where MatHang.idDonVi=DonVi.id) as MatHang_DonVi where  MatHang_DonVi.id like N'%1%' or MatHang_DonVi.ten like N'%1%'";
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
                MessageBox.Show("Không tìm được mặt hàng!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
            //đổ dữ liệu từ ls vào lsvMatHang
            int chay = 0;
            foreach (MatHang i in ls)
            {
                chay++;
                ListViewItem itemTG = new ListViewItem(chay.ToString());
                itemTG.SubItems.Add(i.id);
                itemTG.SubItems.Add(i.ten);
                itemTG.SubItems.Add(i.tenDonVi);
                lsvMatHang.Items.Add(itemTG);
            }
        }

        private void lsvMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(ListViewItem item in lsvMatHang.SelectedItems)
            {
                tbIdMatHang.Text = item.SubItems[1].Text;
                tbTenMatHang.Text = item.SubItems[2].Text;
                cbDonVi.Text = item.SubItems[3].Text;
            }
        }

        //**************Modun Nhà Cung Cấp***************************
        public void LoadViewNhaCungCap(string sql)
        {
            lsvNhaCungCap.Items.Clear();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            conn.Open();
            //List<NhaCungCap> ls = new List<NhaCungCap>();
            int dem = 0;
            try
            {
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
                            lsvNhaCungCap.Items.Add(item);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show(@"Không lấy được dữ liệu nhà cung cấp!");
                }
                finally
                {
                    reader.Dispose();
                }
            }
            catch
            {
                MessageBox.Show(@"Đã có lỗi xảy ra!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }

        private void btnSearchNhaCungCap_Click(object sender, EventArgs e)
        {
            string sql = @"select id,ten,phone,email,diaChi from NhaCungCap ";
            if(tbIdNhaCungCap.Text != "" || tbTenNhaCungCap.Text != "" || tbPhoneNhaCungCap.Text != "" || tbPhoneNhaCungCap.Text != "" || tbEmailNhaCungCap.Text != "" || tbDiaChiNhaCungCap.Text != "")
            {
                sql = sql + @" where ";
                if(tbIdNhaCungCap.Text != "")
                {
                    sql = sql + @" id like N'%" + tbIdNhaCungCap.Text +@"%'";
                }
                else if(tbTenNhaCungCap.Text != "")
                {
                    sql= sql + @" ten like N'%" + tbTenNhaCungCap.Text + @"%'";
                }
                else if (tbPhoneNhaCungCap.Text != "")
                {
                    sql = sql + @" phone like N'%" + tbPhoneNhaCungCap.Text + @"%'";
                }
                else if (tbEmailNhaCungCap.Text != "")
                {
                    sql = sql + @" email like N'%" + tbEmailNhaCungCap.Text + @"%'";
                }
                else if (tbDiaChiNhaCungCap.Text != "")
                {
                    sql = sql + @" diaChi like N'%" + tbDiaChiNhaCungCap.Text + @"%'";
                }
            }
            if(tbIdNhaCungCap.Text != "")
            {
                sql = sql + @" or id like N'%" + tbIdNhaCungCap.Text + @"%' ";
            }
            if(tbTenNhaCungCap.Text != "")
            {
                sql = sql+ @" or ten like N'%" + tbIdNhaCungCap.Text + @"%' ";
            }
            if (tbPhoneNhaCungCap.Text != "")
            {
                sql = sql + @" or phone like N'%" + tbPhoneNhaCungCap.Text + @"%' ";
            }
            if (tbEmailNhaCungCap.Text != "")
            {
                sql = sql + @" or email like N'%" + tbEmailNhaCungCap.Text + @"%' ";
            }
            if (tbDiaChiNhaCungCap.Text != "")
            {
                sql = sql + @" or diaChi like N'%" + tbDiaChiNhaCungCap.Text + @"%' ";
            }

            LoadViewNhaCungCap(sql);
        }

        private void btnThemNhaCungCap_Click(object sender, EventArgs e)
        {
            string idNCC = tbIdNhaCungCap.Text;
            string tenNCC = tbTenNhaCungCap.Text;
            string phoneNCC = tbPhoneNhaCungCap.Text;
            string emailNCC = tbEmailNhaCungCap.Text;
            string diaChiNCC = tbDiaChiNhaCungCap.Text;
            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            connect.Open();
            try
            {
                SqlCommand com = new SqlCommand();
                if(idNCC != "" && tenNCC != "")
                {
                    com.CommandText = @"insert into NhaCungCap(id,ten,phone,email,diaChi) values(N'" + idNCC + @"',N'" + tenNCC + @"',N'" + phoneNCC + @"',N'" + emailNCC + @"',N'" + diaChiNCC + @"')";
                    com.Connection = connect;
                    int rowCount = com.ExecuteNonQuery();
                    LoadViewNhaCungCap(@"select id,ten,phone,email,diaChi from NhaCungCap");
                }
                else
                {
                    MessageBox.Show(@"Bạn cần nhập đầy đủ mã và tên nhà cung cấp trước khi thêm nhà cung cấp mới!");
                }
            }
            catch
            {
                MessageBox.Show(@"Có lỗi xảy ra khi thêm mới Nhà cung cấp!");
            }
            finally
            {
                connect.Close();
                connect.Dispose();
                connect = null;
            }
        }

        private void btnSuaNhaCungCap_Click(object sender, EventArgs e)
        {
            fSuaNhaCungCap f = new fSuaNhaCungCap();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnXoaNhaCungCap_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            connect.Open();
            string idNCC = tbIdNhaCungCap.Text;
            try
            {
                if (idNCC != "")
                {
                    SqlCommand com = new SqlCommand();
                    string sql = @"delete from NhaCungCap where id = N'" + idNCC + "'";
                    com.CommandText = sql;
                    com.Connection = connect;
                    int rowCount = com.ExecuteNonQuery();
                    LoadViewNhaCungCap(@"select id,ten,phone,email,diaChi from NhaCungCap");
                }
                else
                {
                    MessageBox.Show(@"Hãy nhập mã nhà cung cấp mà bạn muốn xóa khỏi danh sách");
                }
            }
            catch
            {
                MessageBox.Show(@"có lỗi xảy ra! Xóa thất bại!");
            }
            finally
            {
                connect.Close();
                connect.Dispose();
                connect = null;
            }
        }

        private void lsvNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lsvNhaCungCap.SelectedItems)
            {
                tbIdNhaCungCap.Text = item.SubItems[1].Text;
                tbTenNhaCungCap.Text = item.SubItems[2].Text;
                tbPhoneNhaCungCap.Text = item.SubItems[3].Text;
                tbEmailNhaCungCap.Text = item.SubItems[4].Text;
                tbDiaChiNhaCungCap.Text = item.SubItems[5].Text;
            }
        }

        //**************Modun Nhân viên********************************
        public void LoadViewNhanVien(string sql)
        {
            lsvNhanVien.Items.Clear();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            conn.Open();
            //List<NhaCungCap> ls = new List<NhaCungCap>();
            int dem = 0;
            try
            {
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
                            lsvNhanVien.Items.Add(item);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show(@"Không lấy được dữ liệu nhân viên!");
                }
                finally
                {
                    reader.Dispose();
                }
            }
            catch
            {
                MessageBox.Show(@"Đã có lỗi xảy ra!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }
        private void btnSearchNhanVien_Click(object sender, EventArgs e)
        {
            string sql = @"select id,ten,phone,email,diaChi from NhanVien ";
            if (tbIdNhanVien.Text != "" || tbTenNhanVien.Text != "" || tbPhoneNhanVien.Text != ""  || tbEmailNhanVien.Text != "" || tbDiaChiNhanVien.Text != "")
            {
                sql = sql + @" where ";
                if (tbIdNhanVien.Text != "")
                {
                    sql = sql + @" id like N'%" + tbIdNhanVien.Text + @"%'";
                }
                else if (tbTenNhanVien.Text != "")
                {
                    sql = sql + @" ten like N'%" + tbTenNhanVien.Text + @"%'";
                }
                else if (tbPhoneNhanVien.Text != "")
                {
                    sql = sql + @" phone like N'%" + tbPhoneNhanVien.Text + @"%'";
                }
                else if (tbEmailNhanVien.Text != "")
                {
                    sql = sql + @" email like N'%" + tbEmailNhanVien.Text + @"%'";
                }
                else if (tbDiaChiNhanVien.Text != "")
                {
                    sql = sql + @" diaChi like N'%" + tbDiaChiNhanVien.Text + @"%'";
                }
            }
            if (tbIdNhanVien.Text != "")
            {
                sql = sql + @" or id like N'%" + tbIdNhanVien.Text + @"%' ";
            }
            if (tbTenNhanVien.Text != "")
            {
                sql = sql + @" or ten like N'%" + tbIdNhanVien.Text + @"%' ";
            }
            if (tbPhoneNhanVien.Text != "")
            {
                sql = sql + @" or phone like N'%" + tbPhoneNhanVien.Text + @"%' ";
            }
            if (tbEmailNhanVien.Text != "")
            {
                sql = sql + @" or email like N'%" + tbEmailNhanVien.Text + @"%' ";
            }
            if (tbDiaChiNhanVien.Text != "")
            {
                sql = sql + @" or diaChi like N'%" + tbDiaChiNhanVien.Text + @"%' ";
            }

            LoadViewNhanVien(sql);
        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            string idNV = tbIdNhanVien.Text;
            string tenNV = tbTenNhanVien.Text;
            string phoneNV = tbPhoneNhanVien.Text;
            string emailNV = tbEmailNhanVien.Text;
            string diaChiNV = tbDiaChiNhanVien.Text;
            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            connect.Open();
            try
            {
                SqlCommand com = new SqlCommand();
                if (idNV != "" && tenNV != "")
                {
                    com.CommandText = @"insert into NhanVien(id,ten,phone,email,diaChi) values(N'" + idNV + @"',N'" + tenNV + @"',N'" + phoneNV + @"',N'" + emailNV + @"',N'" + diaChiNV + @"')";
                    com.Connection = connect;
                    int rowCount = com.ExecuteNonQuery();
                    LoadViewNhanVien(@"select id,ten,phone,email,diaChi from NhanVien");
                }
                else
                {
                    MessageBox.Show(@"Bạn cần nhập đầy đủ mã và tên nhân viên trước khi thêm nhân viên mới!");
                }
            }
            catch
            {
                MessageBox.Show(@"Có lỗi xảy ra khi thêm mới Nhân viên!");
            }
            finally
            {
                connect.Close();
                connect.Dispose();
                connect = null;
            }
        }

        private void btnSuaNhanVien_Click(object sender, EventArgs e)
        {
            fSuaNhanVien f = new fSuaNhanVien();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnXoaNhanVien_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            connect.Open();
            string idNV = tbIdNhanVien.Text;
            try
            {
                if(idNV != "")
                {
                    SqlCommand com = new SqlCommand();
                    string sql = @"delete from NhanVien where id = N'"+idNV+@"'";
                    com.CommandText = sql;
                    com.Connection = connect;
                    try
                    {
                        int rowCount = com.ExecuteNonQuery();
                        LoadViewNhanVien(@"select id,ten,phone,email,diaChi from NhanVien");
                    }
                    catch
                    {
                        MessageBox.Show(@"Không thể xóa nhân viên! Có thể nhân viên đang được các bản ghi khác tham chiếu tới hoặc có lỗi xảy ra!");
                    }
                }
                else
                {
                    MessageBox.Show(@"hãy nhập mã nhân viên cần xóa!");
                }
            }
            catch
            {
                MessageBox.Show(@"Xóa bản ghi không thành công!");
            }
            finally
            {
                connect.Close();
                connect.Dispose();
                connect = null;
            }
        }

        private void lsvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(ListViewItem item in lsvNhanVien.SelectedItems)
            {
                tbIdNhanVien.Text = item.SubItems[1].Text;
                tbTenNhanVien.Text = item.SubItems[2].Text;
                tbPhoneNhanVien.Text = item.SubItems[3].Text;
                tbEmailNhanVien.Text = item.SubItems[4].Text;
                tbDiaChiNhanVien.Text = item.SubItems[5].Text;
            }
        }

        //**************Modun Khách hàng**********************************
        public void LoadViewKhachHang(string sql)
        {
            lsvKhachHang.Items.Clear();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                DbDataReader reader = cmd.ExecuteReader();
                int dem = 0;
                if(reader.HasRows)
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
                        lsvKhachHang.Items.Add(item);
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
        private void btnSearhKhachHang_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            connect.Open();
            //string id = tbIdKhachHang.Text;
            string ma = tbMaKhachHang.Text;
            string ten = tbTenKhachHang.Text;
            string phone = tbPhoneKhachHang.Text;
            string email = tbEmailKhachHang.Text;
            string diaChi = tbDiaChiKhachHang.Text;
            string sql = @"select id,ma,ten,phone,email,diaChi from KhachHang ";
            if( ma != "" || ten != "" || phone != "" || email != "" || diaChi != "")
            {
                sql = sql + @" where ";
                if( ma != "")
                {
                    sql = sql + @" ma like N'%" + ma + @"%'";
                }
                else if (ten != "")
                {
                    sql = sql + @" ten like N'%" + ten + @"%'";
                }
                else if (phone != "")
                {
                    sql = sql + @" phone like N'%" + phone + @"%'";
                }
                else if (email != "")
                {
                    sql = sql + @" email like N'%" + email + @"%'";
                }
                else if (diaChi != "")
                {
                    sql = sql + @" diaChi like N'%" + diaChi + @"%'";
                }

                
                if (ma != "")
                {
                    sql = sql + @" or ma like N'%" + ma + @"%'";
                }
                if (ten != "")
                {
                    sql = sql + @" or ten like N'%" + ten + @"%'";
                }
                if (phone != "")
                {
                    sql = sql + @" or phone like N'%" + phone + @"%'";
                }
                if (email != "")
                {
                    sql = sql + @" or email like N'%" + email + @"%'";
                }
                if (diaChi != "")
                {
                    sql = sql + @" or diaChi like N'%" + diaChi + @"%'";
                }
            }
            else
            {
                MessageBox.Show(@"Hãy nhập thông tin cần tìm!");
            }
            LoadViewKhachHang(sql);
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            connectString.Open();
            //string id = tbIdKhachHang.Text;
            string ma = tbMaKhachHang.Text;
            string ten = tbTenKhachHang.Text;
            string phone= tbPhoneKhachHang.Text;
            string email = tbEmailKhachHang.Text;
            string diaChi = tbDiaChiKhachHang.Text;
            try
            {
                if(ten != "")
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = connectString;
                    string sql = @"insert into KhachHang(ma,ten,phone,email,diaChi) values(N'"+ma+ @"',N'" + ten + @"',N'" + phone + @"',N'" + email + @"',N'" + diaChi + @"')";
                    com.CommandText = sql;
                    com.ExecuteNonQuery();
                    LoadViewKhachHang(@"select *from KhachHang");
                }
                else
                {
                    MessageBox.Show(@"Mục tên khách hàng là bắt buộc! Hãy nhập thông tin!");
                }
            }
            catch
            {
                MessageBox.Show(@"Đã có lỗi xảy ra! Thêm khách hàng mới không thành công!");
            }
            finally
            {
                connectString.Close();
                //connectString.Dispose();
            }
        }

        private void btnSuaKhachHang_Click(object sender, EventArgs e)
        {
            fSuaKhachHang f = new fSuaKhachHang();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnXoaKhachHang_Click(object sender, EventArgs e)
        {
            connectString.Open();
            string id = tbIdKhachHang.Text;
            try
            {
                if(id !="")
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = connectString;
                    string sql = @"delete from KhachHang where id =N'"+id+@"'";
                    com.CommandText = sql;
                    com.ExecuteNonQuery();
                    LoadViewKhachHang(@"select id,ma,ten,phone,email,diaChi from KhachHang");
                }
                else
                {
                    MessageBox.Show(@"hãy chọn Khách hàng cần xóa khỏi danh sách!");
                }
            }
            catch
            {
                MessageBox.Show(@"Có lỗi xảy ra! Xóa khách hàng không thành công!");
            }
            finally
            {
                connectString.Close();
                // connectString.Dispose();
                tbIdKhachHang.Text = null;
                tbMaKhachHang.Text = null;
                tbTenKhachHang.Text = null;
                tbPhoneKhachHang.Text = null;
                tbEmailKhachHang.Text = null;
                tbDiaChiKhachHang.Text = null;
            }
        }

        private void lsvKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(ListViewItem item in lsvKhachHang.SelectedItems)
            {
                tbIdKhachHang.Text = item.SubItems[1].Text;
                tbMaKhachHang.Text = item.SubItems[2].Text;
                tbTenKhachHang.Text = item.SubItems[3].Text;
                tbPhoneKhachHang.Text = item.SubItems[4].Text;
                tbEmailKhachHang.Text = item.SubItems[5].Text;
                tbDiaChiKhachHang.Text = item.SubItems[6].Text;
            }
        }
    }
}
