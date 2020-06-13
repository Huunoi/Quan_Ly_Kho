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
    public partial class fDonVi : Form
    {
        public fDonVi()
        {
            InitializeComponent();
            LoadViewDonVi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            connect.Open();
            try
            {
                SqlCommand com = connect.CreateCommand();
                com.CommandText = @"insert into DonVi(ten) values(N'"+tbTenDonVi.Text+@"')";
                int dem = com.ExecuteNonQuery();
                MessageBox.Show("thêm đơn vị thành công!");
                LoadViewDonVi();
            }
            catch
            {
                MessageBox.Show(@"không thể thêm bản ghi!");
            }
            finally
            {
                connect.Close();
                connect.Dispose();
                connect = null; 
            }
        }
        public void LoadViewDonVi()
        {
            lsvDonVi.Items.Clear();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            conn.Open();
            List<DonVi> ls = new List<DonVi>();
            try
            {
                string sql = @"select id,ten from DonVi";
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
                            int idValue = Convert.ToInt32(reader.GetValue(idIndex));
                            int tenIndex = reader.GetOrdinal("ten");
                            string tenValue = Convert.ToString(reader.GetValue(tenIndex));
                            ls.Add(new DonVi() { id = idValue, ten = tenValue});
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
                MessageBox.Show("Không load được view đơn vị!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
            //đổ dữ liệu từ ls vào lsvMatHang
            int chay = 0;
            foreach (DonVi i in ls)
            {
                chay++;
                ListViewItem itemTG = new ListViewItem(chay.ToString());
                itemTG.SubItems.Add(i.id.ToString());
                itemTG.SubItems.Add(i.ten);
                lsvDonVi.Items.Add(itemTG);
            }
        }
    }
}
