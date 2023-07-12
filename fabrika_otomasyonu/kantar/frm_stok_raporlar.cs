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
    public partial class frm_stok_raporlar : Form
    {
        public frm_stok_raporlar()
        {
            InitializeComponent();
        }
        public void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select ID,plaka,girisTarih,ilkTartim,ikinciTartim,netTartim,cıkısTarih from tbl_tanitim where durum=2 and tur=1", baglanti.baglan());

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

            private void frm_stok_raporlar_Load(object sender, EventArgs e)
        {

            listele();
        }
    }
}
