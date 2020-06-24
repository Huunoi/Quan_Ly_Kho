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
        public string tenTaiKhoan { get; set; }
        public string matKhauTk { get; set; }
        private TaiKhoan taiKhoanHienTai = new TaiKhoan();
        private void LayThongTinTaiKhoan()
        {
            //taiKhoanHienTai.taiKhoan = tenTaiKhoan;
            //taiKhoanHienTai.matKhau = matKhauTk;
            SqlConnection conn1 = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn1;
            string sql = @"select *from TaiKhoan where taiKhoan=N'" + tenTaiKhoan + @"' and matKhau=N'" + matKhauTk + @"'";
            cmd.CommandText = sql;
            DbDataReader reader = cmd.ExecuteReader();
            try
            {
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        int idIndex = reader.GetOrdinal("id");
                        taiKhoanHienTai.id = Convert.ToInt32(reader.GetValue(idIndex));
                        int tkIndex = reader.GetOrdinal("taiKhoan");
                        taiKhoanHienTai.taiKhoan = Convert.ToString(reader.GetValue(tkIndex));
                        int mkIndex = reader.GetOrdinal("matKhau");
                        taiKhoanHienTai.matKhau = Convert.ToString(reader.GetValue(mkIndex));
                        int idNVIndex = reader.GetOrdinal("idNhanVien");
                        taiKhoanHienTai.idNhanVien = Convert.ToString(reader.GetValue(idNVIndex));
                        int quyenIndex = reader.GetOrdinal("quyen");
                        taiKhoanHienTai.quyen = Convert.ToString(reader.GetValue(quyenIndex));
                        break;
                    }
            }
            catch
            {
                MessageBox.Show("Lỗi khi xác minh thông tin tài khoản");
            }
            finally
            {
                reader.Dispose();
            }
            conn1.Close();
        }
        public SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
        public fHome()
        {
            InitializeComponent();
            LayThongTinTaiKhoan();
            LoadTaiKhoan();
            if(taiKhoanHienTai.quyen=="Quản trị")
            {
                btnVaoQuanTri.Enabled = true;
            }
            if(taiKhoanHienTai.quyen=="Nhân viên")
            {
                btnVaoQuanTri.Enabled = false;
            }

            //var time = DateTime.Now;
            //MessageBox.Show(time.ToString());

        }


        //*************Phiếu nhập ***********************
        private List<ChiTietHoaDon> lsChiTietHoaDon = new List<ChiTietHoaDon>();
        
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
        private List<ChiTietPhieuXuat> lsChiTietPhieuXuat = new List<ChiTietPhieuXuat>();
        private void cbKhachHang_Click(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            conn1.Open();
            List<KhachHang> ls = new List<KhachHang>();
            try
            {
                string sql = @"select id,ma,ten,phone,email,diaChi from KhachHang where ma is not null and ma != N''";
                SqlCommand cmdKH = new SqlCommand();
                cmdKH.CommandText = sql;
                cmdKH.Connection = conn1;
                DbDataReader readerKH = cmdKH.ExecuteReader();
                try
                {
                    if(readerKH.HasRows)
                    {
                        while(readerKH.Read())
                        {
                            KhachHang kh = new KhachHang();
                            int idIndex = readerKH.GetOrdinal("id");
                            kh.id = Convert.ToInt32(readerKH.GetValue(idIndex));
                            int maIndex = readerKH.GetOrdinal("ma");
                            kh.ma = Convert.ToString(readerKH.GetValue(maIndex));
                            int tenIndex = readerKH.GetOrdinal("ten");
                            kh.ten = Convert.ToString(readerKH.GetValue(tenIndex));
                            int phoneIndex = readerKH.GetOrdinal("phone");
                            kh.phone = Convert.ToString(readerKH.GetValue(phoneIndex));
                            int emailIndex = readerKH.GetOrdinal("email");
                            kh.email = Convert.ToString(readerKH.GetValue(emailIndex));
                            int diaChiIndex = readerKH.GetOrdinal("diaChi");
                            kh.diaChi = Convert.ToString(readerKH.GetValue(diaChiIndex));
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
                    readerKH.Dispose();
                }
            }
            catch
            {
                MessageBox.Show(@"có lỗi xảy ra không load được dữ liệu về khách hàng!");
            }
            finally
            {
                conn1.Close();
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
                    string sql = @"select giaXuat from ChiTietPhieuNhap where idMatHang = N'"+idMatHang+ @"' and trangThai > 0 group by giaXuat";
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
                        if(item.maHang==tg.maHang && item.giaXuat==tg.giaXuat)//nếu đã có
                        {
                            daCoMatHang = true;
                            int sl = item.soLuong + tg.soLuong;
                            if(sl<=0)//nếu tổng số thêm vào nhỏ hơn hoặc bằng 0 thì xóa mặt hàng khỏi hóa đơn
                            {
                                lsChiTietPhieuXuat.Remove(tg);
                            }
                            else if(sl<=tk.soLuongTon)// nếu tổng số lượng thêm vào >0 và <= số lượng tồn kho
                            {
                                tg.soLuong = sl;
                                tg.thanhTien = tg.giaXuat * tg.soLuong;
                                break;
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
                int tongTien = 0;
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
                    tongTien = tongTien + i.thanhTien;
                }
                conn.Close();
                tbTongXuat.Text = tongTien.ToString();
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

        private void btnLapPhieuXuat_Click(object sender, EventArgs e)
        {
            SqlConnection connPX = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            connPX.Open();
            int id=-1;
            string tenNV = tbNguoiLapPhieuXuat.Text;
            //lấy thông tin người lập phiếu
            NhanVien nv = new NhanVien();
            nv.getNhanVienByTen(tenNV);
            //Lấy thông tin về khách hàng 
            //lấy ra id khách hàng
            if (chkbKhachHangMoi.Checked == true && tbKhachHangMoi.Text !="")
            {
                string ten = tbKhachHangMoi.Text;
                string sdt = tbPhoneKhachHangMoi.Text;
                string diaChi = tbDiaChiKhachHangMoi.Text;
                string email = tbEmailKhachHangMoi.Text;
                //kiểm tra khách hàng nhập vào đã có trong database hay chưa
                //tức kiểm tra tên và số điện thoại
                SqlCommand cmd = new SqlCommand();
                string sql = @"select top(1) *from KhachHang where ten=N'" + ten + @"' and phone = N'" + sdt + @"'";
                cmd.CommandText = sql;
                cmd.Connection = connPX;
                DbDataReader reader = cmd.ExecuteReader();
                KhachHang kh = new KhachHang();
                try
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            
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
                            break;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show(@"lỗi xảy ra khi kiểm tra thông tin khách hàng "+ten);
                }
                finally
                {
                    reader.Dispose();
                }
                if (kh.ten != null)//đã có khách này trong data
                {
                    //MessageBox.Show(@"có kh");
                    //lấy ra id
                    id = kh.id;
                }
                else
                {
                    //MessageBox.Show(@"dell có ");
                    //thêm khách vào data và lấy ra id
                    string sqltg = @"insert into KhachHang(ten,phone,email,diaChi) values(N'"+ten+@"',N'"+sdt+@"',N'"+email+@"',N'"+diaChi+@"')";
                    cmd.CommandText = sqltg;
                    cmd.ExecuteNonQuery();
                    string sqltg2 = @"select top(1) *from KhachHang where ten=N'" + ten + @"' and phone = N'" + sdt + @"'";
                    cmd.CommandText = sqltg2;
                    //cmd.Connection = conn;
                    DbDataReader reader2 = cmd.ExecuteReader();
                    KhachHang kh2 = new KhachHang();
                    try
                    {
                        if (reader2.HasRows)
                        {
                            while (reader2.Read())
                            {

                                int idIndex = reader2.GetOrdinal("id");
                                kh2.id = Convert.ToInt32(reader2.GetValue(idIndex));
                                int maIndex = reader2.GetOrdinal("ma");
                                kh2.ma = Convert.ToString(reader2.GetValue(maIndex));
                                int tenIndex = reader2.GetOrdinal("ten");
                                kh2.ten = Convert.ToString(reader2.GetValue(tenIndex));
                                int phoneIndex = reader2.GetOrdinal("phone");
                                kh2.phone = Convert.ToString(reader2.GetValue(phoneIndex));
                                int emailIndex = reader2.GetOrdinal("email");
                                kh2.email = Convert.ToString(reader2.GetValue(emailIndex));
                                int diaChiIndex = reader2.GetOrdinal("diaChi");
                                kh2.diaChi = Convert.ToString(reader2.GetValue(diaChiIndex));
                                break;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show(@"lỗi xảy ra khi thêm khách hàng " + ten);
                    }
                    finally
                    {
                        reader2.Dispose();
                    }
                    //lấy ra id kh2 vừa thêm và gán vào id
                    id = kh2.id;
                }
                
            }
            if (chkbKhachHangMoi.Checked == false && cbKhachHang.Text!="")
            {
                var Khach = cbKhachHang.Tag as KhachHang;
                id = Khach.id;
            }
            if(id==-1 || nv.id=="" || lsChiTietPhieuXuat.Count ==0)
            {
                MessageBox.Show(@"thông tin khách hàng, người lập phiếu và nội dung phiếu không được bỏ trống");
            }
            else
            {
                //lấy ngày giờ hiện tại
                var time = DateTime.Now;
                //thêm hóa đơn mới vào data
                SqlCommand cmd1 = new SqlCommand();
                string sql1 = @"insert into PhieuXuat(ngay,idKhachHang,idNhanVien) values(N'" + time.ToString() + @"',N'" + id.ToString() + @"',N'" + nv.id.ToString() + @"')";
                cmd1.CommandText = sql1;
                cmd1.Connection = connPX;
                cmd1.ExecuteNonQuery();
                //Lấy ra id hóa đơn vừa thêm
                int idPhieu = -1;
                sql1 = @"select *from PhieuXuat where ngay=N'" + time.ToString() + @"' and idKhachHang=N'" + id.ToString() + @"' and idNhanVien=N'" + nv.id.ToString() + @"'";
                cmd1.CommandText = sql1;
                DbDataReader reader1 = cmd1.ExecuteReader();
                try
                {
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            int idIndex = reader1.GetOrdinal("id");
                            idPhieu = Convert.ToInt32(reader1.GetValue(idIndex));
                            break;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi khi lấy id Phiếu xuất");
                }
                finally
                {
                    reader1.Dispose();
                }
                //thêm nội dung phiếu xuất vào database
                foreach (var item in lsChiTietPhieuXuat)
                {
                    ThemNoiDungPhieuXuat(item, idPhieu);
                }
                lsvPhieuXuat.Items.Clear();
                lsChiTietPhieuXuat.Clear();
                cbKhachHang.Text = "";
                //tbNguoiLapPhieuXuat.Text = "";
                tbTongXuat.Text = "";
                MessageBox.Show(@"Lập phiếu nhập thành công!");
                connPX.Close();
            }
            
        }
        private void ThemNoiDungPhieuXuat(ChiTietPhieuXuat item,int idPhieuXuat)
        {
            //Lấy ra danh sách các lô hàng của mặt hàng item.tenHang với giá xuât item.giaXuat và còn trong kho(trangThai>0)
            SqlConnection connetion = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            connetion.Open();
            SqlCommand command = new SqlCommand();
            string lenh = @"select *from ChiTietPhieuNhap where idMatHang =N'"+item.maHang+@"' and giaXuat=N'"+item.giaXuat.ToString()+@"' order by id";
            command.Connection = connetion;
            command.CommandText = lenh;
            DbDataReader read = command.ExecuteReader();
            List<ChiTietPhieuNhap> ls = new List<ChiTietPhieuNhap>();
            try
            {
                if(read.HasRows)
                {
                    while(read.Read())
                    {
                        ChiTietPhieuNhap tg = new ChiTietPhieuNhap();
                        int idIndex = read.GetOrdinal("id");
                        tg.id = Convert.ToInt32(read.GetValue(idIndex));
                        int idHangIndex = read.GetOrdinal("idMatHang");
                        tg.idMatHang = Convert.ToString(read.GetValue(idHangIndex));
                        int idPhieuNhapIndex = read.GetOrdinal("idPhieuNhap");
                        tg.idPhieuNhap = Convert.ToInt32(read.GetValue(idPhieuNhapIndex));
                        int giaNhapIndex = read.GetOrdinal("giaNhap");
                        tg.giaNhap = Convert.ToInt32(read.GetValue(giaNhapIndex));
                        int giaXuatIndex = read.GetOrdinal("giaXuat");
                        tg.giaXuat = Convert.ToInt32(read.GetValue(giaXuatIndex));
                        int soLuongIndex = read.GetOrdinal("soLuong");
                        tg.soLuong = Convert.ToInt32(read.GetValue(soLuongIndex));
                        int trangThaiIndex = read.GetOrdinal("trangThai");
                        tg.trangThai = Convert.ToInt32(read.GetValue(trangThaiIndex));
                        ls.Add(tg);
                    }
                }
            }
            catch
            {
                MessageBox.Show(@"lỗi khi lấy danh sách ct phiếu nhập của mặt hàng " + item.tenHang + @" với giá xuất " + item.giaXuat.ToString());
            }
            finally
            {
                read.Dispose();
            }
            //thêm bản ghi vào Bảng ChiTietPhieuXuat
            foreach(var i in ls)
            {
                if (i.trangThai >= item.soLuong)
                {
                    //thêm vào ctpx
                    lenh = @"insert into ChiTietPhieuXuat(idMatHang,idPhieuXuat,idChiTietPhieuNhap,soLuong) values(N'" + item.maHang + @"',N'" + idPhieuXuat.ToString() + @"',N'" + i.id.ToString() + @"',N'" + item.soLuong.ToString() + @"')";
                    command.CommandText = lenh;
                    command.ExecuteNonQuery();
                    //cập nhật lại trạng thái cho bản ghi ctpn có id là i.id
                    i.trangThai = i.trangThai - item.soLuong;
                    lenh = @"update ChiTietPhieuNhap set trangThai = N'" + i.trangThai.ToString() + @"' where id=N'" + i.id.ToString()+@"'";
                    command.CommandText = lenh;
                    command.ExecuteNonQuery();
                    break;
                }
                else
                {
                    //thêm vào ctpx
                    lenh = @"insert into ChiTietPhieuXuat(idMatHang,idPhieuXuat,idChiTietPhieuNhap,soLuong) values(N'" + item.maHang + @"',N'" + idPhieuXuat.ToString() + @"',N'" + i.id.ToString() + @"',N'" + i.trangThai.ToString() + @"')";
                    command.CommandText = lenh;
                    command.ExecuteNonQuery();
                    item.soLuong = item.soLuong - i.trangThai;
                    //cập nhật trạng thái
                    lenh = @"update ChiTietPhieuNhap set trangThai = N'0' where id=N'" + i.id.ToString() + @"'";
                    command.CommandText = lenh;
                    command.ExecuteNonQuery();
                }

            }

            connetion.Close();
            connetion.Dispose();
        }
        private void tbKhachHangMoi_Click(object sender, EventArgs e)
        {
            tbKhachHangMoi.Text = "";
        }

        private void tbPhoneKhachHangMoi_Click(object sender, EventArgs e)
        {
            tbPhoneKhachHangMoi.Text = "";
        }

        private void tbDiaChiKhachHangMoi_Click(object sender, EventArgs e)
        {
            tbDiaChiKhachHangMoi.Text = "";
        }

        private void tbEmailKhachHangMoi_Click(object sender, EventArgs e)
        {
            tbEmailKhachHangMoi.Text = "";
        }

        private void chkbKhachHangMoi_CheckedChanged(object sender, EventArgs e)
        {
            if(chkbKhachHangMoi.Checked ==true)
            {
                //MessageBox.Show("đã đánh dấu");
                tbKhachHangMoi.Enabled = true;
                tbPhoneKhachHangMoi.Enabled = true;
                tbDiaChiKhachHangMoi.Enabled = true;
                tbEmailKhachHangMoi.Enabled = true;
            }
            else
            {
                //MessageBox.Show("chưa đánh dấu");
                tbKhachHangMoi.Enabled = false;
                tbPhoneKhachHangMoi.Enabled = false;
                tbDiaChiKhachHangMoi.Enabled = false;
                tbEmailKhachHangMoi.Enabled = false;
            }
        }

        private void cbKhachHang_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                KhachHang kh = cb.SelectedValue as KhachHang;
                cbKhachHang.Tag = kh;
            }
        }
        //************************Tài khoản***************************
        private void LoadTaiKhoan()
        {
            //lấy ra thông tin nhân viên ứng với tài khoản
            NhanVien nv = new NhanVien();
            nv.getNhanVienById(taiKhoanHienTai.idNhanVien);
            //set du liệu vào các mục bên tab Thông tin tài khoản
            tbTenTaiKhoan.Text = taiKhoanHienTai.taiKhoan;
            tbQuyen.Text = taiKhoanHienTai.quyen;
            tbTenNhanVienTabTTTK.Text = nv.ten;
            tbMaNhanVienTabTTTK.Text = nv.id;
            tbPhoneTabTTTK.Text = nv.phone;
            tbEmailTabTTTK.Text = nv.email;
            tbDiaChiTabTTTK.Text = nv.diaChi;

            //set tbNguoiLapPhieuNhap Và tbNguoiLapPhieuXuat
            tbNguoiLapPhieuNhap.Text = nv.ten;
            tbNguoiLapPhieuNhap.Enabled = false;
            tbNguoiLapPhieuXuat.Text = nv.ten;
            tbNguoiLapPhieuXuat.Enabled = false;
        }

        private void btnVaoQuanTri_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
