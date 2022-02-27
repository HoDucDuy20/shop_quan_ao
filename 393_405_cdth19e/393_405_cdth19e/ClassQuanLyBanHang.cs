using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _393_405_cdth19e
{
    class ClassQuanLyBanHang
    {
        SqlConnection con = new SqlConnection();
        void ketNoi()
        {
            con.ConnectionString = @"Data Source=IDEAPAD-L340\HODUCDUY;Initial Catalog=ShopQuanAo;Integrated Security=True";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public ClassQuanLyBanHang()
        {
            ketNoi();
        }
        public DataSet layDuLieu(string sql)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds);
            return ds;
        }
        public int CapNhatDuLieu(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            return cmd.ExecuteNonQuery();
        }
    }
}
