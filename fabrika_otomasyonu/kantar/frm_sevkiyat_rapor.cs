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
    public partial class frm_sevkiyat_rapor : Form
    {
        public frm_sevkiyat_rapor()
        {
            InitializeComponent();
        }
        public void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select ID,plaka,girisTarih,ilkTartim,ikinciTartim,netTartim,cıkısTarih from tbl_tanitim where durum=2 and tur=2", baglanti.baglan());

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void frm_sevkiyat_rapor_Load(object sender, EventArgs e)
        {
            listele();
        }
    }
}
