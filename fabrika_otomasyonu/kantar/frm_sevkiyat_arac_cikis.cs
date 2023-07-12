using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace kantar
{
    public partial class frm_sevkiyat_arac_cikis : Form
    {
        public frm_sevkiyat_arac_cikis()
        {
            InitializeComponent();
        }
        public void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select ID,plaka,girisTarih,ilkTartim from tbl_tanitim where durum=1 and tur=2", baglanti.baglan());

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            txt_plaka.Text = "";
            txt_son_tartim.Text = "";
            txt_tartim_no.Text = "";

        }
        private void frm_sevkiyat_arac_cikis_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_plaka.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_tartim_no.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_plaka.Text == "" || txt_son_tartim.Text == "" || txt_tartim_no.Text == "")
            {
                MessageBox.Show(" boş alanları giriniz");

            }
            else
            {
                SqlCommand komut = new SqlCommand("update tbl_tanitim set durum=@p1,ikinciTartim=@p2,netTartim=@p2-ilkTartim,cıkısTarih=@p3 where ID =@p4 and tur=2  ", baglanti.baglan());
                komut.Parameters.AddWithValue("@p1", 2);
                komut.Parameters.AddWithValue("@p2", txt_son_tartim.Text);
                komut.Parameters.AddWithValue("@p3", DateTime.Now);
                komut.Parameters.AddWithValue("@p4", txt_tartim_no.Text);

                //@p1 demesi şu anlama gelir 1 sutun 
                //p2 demesi ise ıd anlamına gelecek

                if (baglanti.baglan().State != ConnectionState.Open)
                {

                    baglanti.baglan().Open();
                    //eger veri tabanı baglantısı kapalı ise açacak açık ise hiç if e girmeyecek
                }
                komut.ExecuteNonQuery();//kayıt gerçekleşmiş olacak 
                MessageBox.Show("Sevkiyat için Araç Çıkıs işlemi başarı ile tamamlandı", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            listele();
        }
    }
}
