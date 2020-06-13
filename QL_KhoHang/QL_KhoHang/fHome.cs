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
    public partial class fHome : Form
    {
        public SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
        public fHome()
        {
            InitializeComponent();
        }


        //*************Phiếu nhập ***********************
        private List<ChiTietHoaDon> lsChiTietHoaDon = new List<ChiTietHoaDon>();
        private List<ChiTietPhieuXuat> lsChiTietPhieuXuat = new List<ChiTietPhieuXuat>();
        private void btnAddNhap_Click(object sender, EventArgs e)
        {
            try
            {
                MatHang mh = cbMatHangNhap.Tag as MatHang;
                int soLuong = Convert.ToInt32(nudSoLuongNhap.Value);
                int giaNhap = Convert.ToInt32(tbGiaNhap.Text);
                int giaXuat = Convert.ToInt32(tbGiaXuat.Text);
                //Thêm bản ghi mặt hàng vào dah sách ci tiết hóa đơn
                ChiTietHoaDon item = new ChiTietHoaDon();
                item.maHang = mh.id;
                item.tenHang = mh.ten;
                item.donVi = mh.tenDonVi;
                item.giaNhap = giaNhap;
                item.giaXuat = giaXuat;
                item.soLuong = soLuong;
                item.thanhTien = giaNhap * soLuong;
                if(lsChiTietHoaDon.Count == 0)
                {
                    lsChiTietHoaDon.Add(item);
                }
                else
                {
                    foreach(ChiTietHoaDon tg in lsChiTietHoaDon)
                    {
                        if(item.tenHang == tg.tenHang)
                        {
                            int sluong = item.soLuong + tg.soLuong;
                            if(sluong <= 0)
                            {
                                //xóa mặt hàng khỏi hóa đơn
                                lsChiTietHoaDon.Remove(tg);
                            }
                            else
                            {
                                tg.soLuong = sluong;
                            }
                        }
                    }
                }
                lsvPhieuNhap.Items.Clear();
                int chay = 0;
                int sum = 0;
                foreach(ChiTietHoaDon tg in lsChiTietHoaDon)
                {
                    chay++;
                    ListViewItem itemTG = new ListViewItem(chay.ToString());
                    itemTG.SubItems.Add(tg.maHang);
                    itemTG.SubItems.Add(tg.tenHang);
                    itemTG.SubItems.Add(tg.giaNhap.ToString());
                    itemTG.SubItems.Add(tg.giaXuat.ToString());
                    itemTG.SubItems.Add(tg.soLuong.ToString());
                    itemTG.SubItems.Add(tg.donVi);
                    itemTG.SubItems.Add(tg.thanhTien.ToString());
                    lsvPhieuNhap.Items.Add(itemTG);
                    sum = sum + tg.thanhTien;
                }
                tbTongNhap.Text = sum.ToString();
                

            }
            catch
            {
                MessageBox.Show(@"Không convert được dữ liệu nhập vào hoặc bạn còn đang để trống thông tin!");
            }

        }

        private void cbNhaCungCap_Click(object sender, EventArgs e)
        {
            conn.Open();
            List<NhaCungCap> ls = new List<NhaCungCap>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                string sql = @"select *from NhaCungCap";
                cmd.CommandText = sql;
                cmd.Connection = conn;
                DbDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        NhaCungCap ncc = new NhaCungCap();
                        int idIndex = reader.GetOrdinal("id");
                        ncc.id = Convert.ToString(reader.GetValue(idIndex));
                        int tenIndex = reader.GetOrdinal("ten");
                        ncc.ten = Convert.ToString(reader.GetValue(tenIndex));
                        int phoneIndex = reader.GetOrdinal("phone");
                        ncc.phone = Convert.ToString(reader.GetValue(phoneIndex));
                        int emailIndex = reader.GetOrdinal("email");
                        ncc.email = Convert.ToString(reader.GetValue(emailIndex));
                        int diaChiIndex = reader.GetOrdinal("diaChi");
                        ncc.diaChi = Convert.ToString(reader.GetValue(diaChiIndex));
                        ls.Add(ncc);
                    }
                }
            }
            catch
            {
                MessageBox.Show(@"Load danh sách nhà cung cấp thất bại!");
            }
            finally
            {
                conn.Close();
            }
            cbNhaCungCap.DataSource = ls;
            cbNhaCungCap.DisplayMember="ten";
        }

        private void cbMatHangNhap_Click(object sender, EventArgs e)
        {
            conn.Open();
            List<MatHang> ls = new List<MatHang>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                string sql = @"select MatHang.id,MatHang.ten,MatHang.idDonVi,DonVi.ten as tenDV from MatHang,DonVi where MatHang.idDonVi=DonVi.id";
                cmd.CommandText = sql;
                cmd.Connection = conn;
                DbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MatHang mh = new MatHang();
                        int idIndex = reader.GetOrdinal("id");
                        mh.id = Convert.ToString(reader.GetValue(idIndex));
                        int tenIndex = reader.GetOrdinal("ten");
                        mh.ten = Convert.ToString(reader.GetValue(tenIndex));
                        int idDonViIndex = reader.GetOrdinal("idDonVi");
                        mh.idDonVi = Convert.ToInt32(reader.GetValue(idDonViIndex));
                        int tenDVIndex = reader.GetOrdinal("tenDV");
                        mh.tenDonVi = Convert.ToString(reader.GetValue(tenDVIndex));
                        ls.Add(mh);
                    }
                }
            }
            catch
            {
                MessageBox.Show(@"Load danh sách mặt hàng thất bại!");
            }
            finally
            {
                conn.Close();
            }
            cbMatHangNhap.DataSource = ls;
            cbMatHangNhap.DisplayMember = "ten";
        }

        private void cbMatHangNhap_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if(cb.SelectedValue != null)
            {
                MatHang mh = cb.SelectedValue as MatHang;
                cbMatHangNhap.Tag = mh;
            }
        }

        private void btnLapPhieuNhap_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                NhaCungCap ncc = cbNhaCungCap.Tag as NhaCungCap;
                NhanVien nv = new NhanVien();
                if(tbNguoiLapPhieuNhap.Text != "" && lsChiTietHoaDon.Count !=0)
                {
                    nv.getNhanVienByTen(tbNguoiLapPhieuNhap.Text);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    string sql=@"insert into PhieuNhap(ngay,idNhaCungCap,idNhanVien) values(null,N'"+ncc.id+@"',N'"+nv.id+@"')";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    //lấy id phieu nhập vừa thêm
                    sql = @"select top(1) id from PhieuNhap where ngay is null and idNhaCungCap =N'" + ncc.id + @"' and idNhanVien = N'" + nv.id + @"'";
                    cmd.CommandText = sql;
                    DbDataReader reader = cmd.ExecuteReader();
                    int idPhieu=-1;
                    try
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int index = reader.GetOrdinal("id");
                                idPhieu = Convert.ToInt32(reader.GetValue(index));
                            }
                        }
                    }
                    finally
                    {
                        reader.Dispose();
                    }
                    //cập nhật ngày tháng lập phiếu vào phiếu vừa lập
                    sql = @"update PhieuNhap set ngay = getdate() where id = "+idPhieu.ToString();
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    //thêm chi tiết phiếu nhập
                    foreach(ChiTietHoaDon item in lsChiTietHoaDon)
                    {
                        sql = @"insert into ChiTietPhieuNhap(idMatHang,idPhieuNhap,soLuong,giaNhap,giaXuat,trangThai) values(N'"+item.maHang+ @"',N'" + idPhieu.ToString() + @"',N'" + item.soLuong.ToString() + @"',N'" + item.giaNhap.ToString() + @"',N'"+item.giaXuat.ToString()+@"',N'" + item.soLuong.ToString() + @"')";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                    }
                    //làm trống lsvPhieuNhap và lsChiTietHoaDon
                    lsvPhieuNhap.Items.Clear();
                    lsChiTietHoaDon.Clear();
                    MessageBox.Show(@"Lập phiếu nhập thành công!");

                }
                else
                {
                    if(tbNguoiLapPhieuNhap.Text =="")
                    {
                        MessageBox.Show(@"Hãy nhập tên người lập phiếu");
                    }
                    else
                    {
                        MessageBox.Show(@"Hãy thêm nội dung phiếu nhập!");
                    }
                    
                }
                
            }
            catch
            {
                MessageBox.Show(@"có lỗi xảy ra! Lập phiếu thất bại.");
            }
            finally
            {
                conn.Close();
            }

        }

        private void cbNhaCungCap_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if(cb.SelectedValue != null)
            {
                NhaCungCap ncc = cb.SelectedValue as NhaCungCap;
                cbNhaCungCap.Tag = ncc;
            }
        }

        //****************Phiếu xuất**********************
        private void cbKhachHang_Click(object sender, EventArgs e)
        {
            conn.Open();
            List<KhachHang> ls = new List<KhachHang>();
            try
            {
                string sql = @"select id,ma,ten,phone,email,diaChi from KhachHang where ma is not null and ma != N''";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                DbDataReader reader = cmd.ExecuteReader();
                try
                {
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            KhachHang kh = new KhachHang();
                            int idIndex = reader.GetOrdinal("id");
                            kh.id = Convert.ToInt32(reader.GetValue(idIndex));
                            int maIndex = reader.GetOrdinal("ma");
                            kh.ma = Convert.ToString(reader.GetValue(maIndex));
                            int tenIndex = reader.GetOrdinal("ten");
                            kh.ten = Convert.ToString(reader.GetValue(tenIndex));
                            int phoneIndex = reader.GetOrdinal("phone");
                            kh.phone = Convert.ToString(reader.GetValue(phoneIndex));
                            int emailIndex = reader.GetOrdinal("email");
                            kh.email = Convert.ToString(reader.GetValue(emailIndex));
                            int diaChiIndex = reader.GetOrdinal("diaChi");
                            kh.diaChi = Convert.ToString(reader.GetValue(diaChiIndex));
                            ls.Add(kh);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show(@"Không lấy được dữ liệu khách hàng thường xuyên!");
                }
                finally
                {
                    reader.Dispose();
                }
            }
            catch
            {
                MessageBox.Show(@"có lỗi xảy ra không load được dữ liệu về khách hàng!");
            }
            finally
            {
                conn.Close();
            }
            cbKhachHang.DataSource = ls;
            cbKhachHang.DisplayMember = "ten";
        }

        private void cbMatHangXuat_Click(object sender, EventArgs e)
        {
            conn.Open();
            List<MatHang> ls = new List<MatHang>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                string sql = @"select MatHang.id,MatHang.ten,MatHang.idDonVi,DonVi.ten as tenDV from MatHang,DonVi where MatHang.idDonVi=DonVi.id";
                cmd.CommandText = sql;
                cmd.Connection = conn;
                DbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MatHang mh = new MatHang();
                        int idIndex = reader.GetOrdinal("id");
                        mh.id = Convert.ToString(reader.GetValue(idIndex));
                        int tenIndex = reader.GetOrdinal("ten");
                        mh.ten = Convert.ToString(reader.GetValue(tenIndex));
                        int idDonViIndex = reader.GetOrdinal("idDonVi");
                        mh.idDonVi = Convert.ToInt32(reader.GetValue(idDonViIndex));
                        int tenDVIndex = reader.GetOrdinal("tenDV");
                        mh.tenDonVi = Convert.ToString(reader.GetValue(tenDVIndex));
                        ls.Add(mh);
                    }
                }
            }
            catch
            {
                MessageBox.Show(@"Load danh sách mặt hàng thất bại!");
            }
            finally
            {
                conn.Close();
            }
            cbMatHangXuat.DataSource = ls;
            cbMatHangXuat.DisplayMember = "ten";
        }

        private void cbMatHangXuat_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if(cb.SelectedValue != null)
            {
                MatHang mh = cb.SelectedValue as MatHang;
                cbMatHangXuat.Tag = mh;
            }
        }

        private void cbGiaXuat_Click(object sender, EventArgs e)
        {
            conn.Open();
            string tenHang = cbMatHangXuat.Text;
            List<int> ls = new List<int>();
            if (tenHang != "")//kiểm tra xem đã nhập mặt hàng hay chưa
            {
                try
                {
                    MatHang mh = cbMatHangXuat.Tag as MatHang;// lấy thông tin mặt hàng đã được nhập từ cbMatHangNhap.Tag
                    //lấy giá xuất của mặt hàng hiện đang có trong kho
                    //cùng một mặt hàng nhưng giá nhập tại các thời điểm( các lô hàng nhập kho) khác nhau sẽ có giá xuất khác nhau
                    //việc chọn này sẽ giúp ta biết chính xác mình muốn xuất đi mặt hàng thuộc lô hàng nào
                    string idMatHang = mh.id;
                    string sql = @"select giaXuat from ChiTietPhieuNhap where idMatHang = N'"+idMatHang+@"' and trangThai > 0";
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    DbDataReader reader = cmd.ExecuteReader();
                    if(reader.HasRows)
                    { 
                        while (reader.Read())
                        {
                            int index = reader.GetOrdinal("giaXuat");
                            int gia = Convert.ToInt32(reader.GetValue(index));
                            ls.Add(gia);
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"Trong kho hiện đang hết "+mh.ten+@"!");
                    }
                    
                }
                catch
                {

                }
                finally
                {
                    conn.Close();
                }
                cbGiaXuat.DataSource = ls;
            }
            else
            {
                MessageBox.Show(@"Hãy nhập tên hàng trước!");
                conn.Close();
            }
        }

        
        private void btnAddXuat_Click(object sender, EventArgs e)
        {
            //Lấy dữ liệu đầu vào
            MatHang mh = cbMatHangXuat.Tag as MatHang;
            int giaXuatHang = Convert.ToInt32(cbGiaXuat.Text);
            int soLuongXuat = Convert.ToInt32(nudSoLuongXuat.Value);
            if(cbMatHangXuat.Text != "" && cbGiaXuat.Text != "" )//Kiểm tra thông tin đã nhập hay chưa
            {
                //Lấy danh sách tồn kho của mặt hàng với giá vừa được nhập vào
                TonKho tk = new TonKho();
                conn.Open();
                string sql = @"select idMatHang,giaXuat,sum(trangThai) as tonKho from ChiTietPhieuNhap where idMatHang =N'"+mh.id+@"' and giaXuat =N'"+giaXuatHang.ToString()+@"' group by idMatHang,giaXuat";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                DbDataReader reader = cmd.ExecuteReader();
                try
                {
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            int idIndex = reader.GetOrdinal("idMatHang");
                            tk.id = Convert.ToString(reader.GetValue(idIndex));
                            int giaIndex = reader.GetOrdinal("giaXuat");
                            tk.gia = Convert.ToInt32(reader.GetValue(giaIndex));
                            int tonKhoIndex = reader.GetOrdinal("tonKho");
                            tk.soLuongTon = Convert.ToInt32(reader.GetValue(tonKhoIndex));

                        }
                    }
                }
                catch
                {
                    MessageBox.Show(@"Lỗi khi kiểm tra tồn kho "+mh.ten);
                }
                finally
                {
                    reader.Close();
                    reader.Dispose();
                }
                //Thêm mat hang vao hoa don
                ChiTietPhieuXuat item = new ChiTietPhieuXuat();
                item.maHang = mh.id;
                item.tenHang = mh.ten;
                item.donVi = mh.tenDonVi;
                item.giaXuat = giaXuatHang;
                item.soLuong = soLuongXuat;
                item.thanhTien = giaXuatHang * soLuongXuat;
                //Nếu hóa đơn chưa có mặt hàng nào
                if(lsChiTietPhieuXuat.Count==0)
                {
                    if(soLuongXuat<=tk.soLuongTon && soLuongXuat > 0)
                    {
                        lsChiTietPhieuXuat.Add(item);
                    }
                    else
                    {
                        MessageBox.Show(@"số lượng tồn kho không đủ hoặc bạn nhập vào số âm khi chưa có mặt hàng này trong phiếu! Hiện tại " + item.tenHang + @" với giá " + item.giaXuat.ToString() + @"chỉ còn " + tk.soLuongTon.ToString() + @" (" + item.donVi + @")");
                    }
                }
                else  //trường hợp hóa đơn đã có nội dung
                {
                    bool daCoMatHang = false;
                    //kiểm tra mặt hàng đã có trong hóa đơn hay chưa
                    foreach(ChiTietPhieuXuat tg in lsChiTietPhieuXuat)
                    {
                        if(item.maHang==tg.maHang)//nếu đã có
                        {
                            daCoMatHang = true;
                            int sl = item.soLuong + tg.soLuong;
                            if(sl<=0)//nếu tổng số thêm vào nhỏ hơn hoặc bằng 0 thì xóa mặt hàng khỏi hóa đơn
                            {
                                lsChiTietPhieuXuat.Remove(tg);
                            }
                            else if(sl<=tk.soLuongTon)// nếu tổng số lượng thêm vào >0 và <= số lượng tồn kho
                            {
                                lsChiTietPhieuXuat.Add(item);
                            }
                            else
                            {
                                MessageBox.Show(@"tồn kho không đủ!");
                            }
                        }
                    }
                    if(daCoMatHang==false)
                    {
                        if (soLuongXuat <= tk.soLuongTon && soLuongXuat > 0)
                        {
                            lsChiTietPhieuXuat.Add(item);
                        }
                        else
                        {
                            MessageBox.Show(@"Tồn kho không đủ hoặc số lượng mặt hàng thêm vào đang âm!");
                        }
                    }
                }
                //Hiển thị nội dung hóa đơn cho người dùng
                int chay = 0;
                lsvPhieuXuat.Items.Clear();
                foreach(ChiTietPhieuXuat i in lsChiTietPhieuXuat)
                {
                    chay++;
                    ListViewItem itemTG = new ListViewItem(chay.ToString());
                    itemTG.SubItems.Add(i.maHang);
                    itemTG.SubItems.Add(i.tenHang);
                    itemTG.SubItems.Add(i.soLuong.ToString());
                    itemTG.SubItems.Add(i.donVi);
                    itemTG.SubItems.Add(i.giaXuat.ToString());
                    itemTG.SubItems.Add(i.thanhTien.ToString());
                    lsvPhieuXuat.Items.Add(itemTG);
                }
                conn.Close();
                //sau khi thêm xong tiến hành làm trống lại các mục
                cbMatHangXuat.Text = "";
                cbGiaXuat.Text = "";
                nudSoLuongXuat.Value = 0;
            }
            else
            {
                MessageBox.Show(@"Hãy nhập tên mặt hàng và chọn giá hàng!");
            }
            
        }
    }
}
