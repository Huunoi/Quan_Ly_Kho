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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = new TaiKhoan();
            string taiKhoan = tbTaiKhoan.Text;
            string matKhau = tbMatKhau.Text;
            SqlConnection connLogin = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            connLogin.Open();
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = connLogin;
            string sqlLogin = @"select *from TaiKhoan where taiKhoan=N'"+taiKhoan+@"' and matKhau=N'"+matKhau+@"'";
            cmdLogin.CommandText = sqlLogin;
            DbDataReader readerLogin = cmdLogin.ExecuteReader();
            try
            {
                if(readerLogin.HasRows)
                    while(readerLogin.Read())
                    {
                        int idIndex = readerLogin.GetOrdinal("id");
                        tk.id = Convert.ToInt32(readerLogin.GetValue(idIndex));
                        int tkIndex = readerLogin.GetOrdinal("taiKhoan");
                        tk.taiKhoan = Convert.ToString(readerLogin.GetValue(tkIndex));
                        int mkIndex = readerLogin.GetOrdinal("matKhau");
                        tk.matKhau = Convert.ToString(readerLogin.GetValue(mkIndex));
                        int idNVIndex = readerLogin.GetOrdinal("idNhanVien");
                        tk.idNhanVien = Convert.ToString(readerLogin.GetValue(idNVIndex));
                        int quyenIndex = readerLogin.GetOrdinal("quyen");
                        tk.quyen = Convert.ToString(readerLogin.GetValue(quyenIndex));
                        break;
                    }
            }
            catch
            {
                MessageBox.Show("Lỗi khi xác minh thông tin tài khoản");
            }
            finally
            {
                readerLogin.Dispose();
            }
            if(tk.taiKhoan !="" && tk.taiKhoan!= null && tk.matKhau != "" && tk.matKhau!=null)
            {
                fHome f = new fHome();
                f.tenTaiKhoan = tk.taiKhoan;
                f.matKhauTk = tk.matKhau;
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu");
            }
            
        }
    }
}
