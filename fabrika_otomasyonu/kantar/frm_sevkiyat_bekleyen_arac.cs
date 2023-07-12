using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace kantar
{
    public partial class frm_sevkiyat_bekleyen_arac : Form
    {
        public frm_sevkiyat_bekleyen_arac()
        {
            InitializeComponent();
        }
        public void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select ID,plaka,girisTarih,ilkTartim from tbl_tanitim where durum=1 and tur=2", baglanti.baglan());

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }
        private void frm_sevkiyat_bekleyen_arac_Load(object sender, EventArgs e)
        {
            listele();
        }
    }
}
