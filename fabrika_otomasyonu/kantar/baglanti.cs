using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace kantar
{
    internal class baglanti
    {
        public static SqlConnection baglan()
        {
            SqlConnection con=new SqlConnection(" Data Source=.;Initial Catalog=otomasyon2;Integrated Security=True ");
           con.Open();
            return con;
        }
    }
}
