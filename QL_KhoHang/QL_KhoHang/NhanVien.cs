using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KhoHang
{
    class NhanVien
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KP2LC3K\SQLEXPRESS;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
        public string id { get; set; }
        public string ten { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string diaChi { get; set; }

        public void getNhanVienByTen(string name)
        {
            conn.Open();
            try
            {
                if (name != "")
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = @"select top(1) *from NhanVien where ten = N'" + name + @"'";
                    DbDataReader reader = cmd.ExecuteReader();
                    try
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int idIndex = reader.GetOrdinal("id");
                                id = Convert.ToString(reader.GetValue(idIndex));
                                ten = name;
                                int phoneIndex = reader.GetOrdinal("phone");
                                phone = Convert.ToString(reader.GetValue(phoneIndex));
                                int emailIndex = reader.GetOrdinal("email");
                                email = Convert.ToString(reader.GetValue(emailIndex));
                                int diaChiIndex = reader.GetOrdinal("diaChi");
                                diaChi = Convert.ToString(reader.GetValue(diaChiIndex));

                            }
                        }
                    }
                    finally
                    {
                        reader.Dispose();
                    }
                    
                }
            }
            catch { }
            finally
            {
                conn.Close();
            }
            
            
        }

    }
}
