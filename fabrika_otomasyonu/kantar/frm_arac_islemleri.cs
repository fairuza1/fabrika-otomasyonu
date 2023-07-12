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
    public partial class frm_arac_islemleri : Form
    {
        public frm_arac_islemleri()
        {
            InitializeComponent();
        }

        public void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select plaka,cinsi,kapasite from tbl_arac where durum=1  ", baglanti.baglan());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            txt_cinsi.Text = "";
            txt_kapasite.Text = "";
            txt_plaka.Text = "";
            
        }

        private void frm_arac_islemleri_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_plaka.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_cinsi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_kapasite.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_plaka.Text == ""||txt_cinsi.Text==""||txt_kapasite.Text=="")
            {
                MessageBox.Show("plaka/cins/kapasite alanını boş girdiniz");

            }
            else
            {
                SqlCommand com = new SqlCommand("insert into tbl_arac (plaka,cinsi,kapasite) values(@p1,@p2,@p3)", baglanti.baglan());
                com.Parameters.AddWithValue("@p1", txt_plaka.Text);
                com.Parameters.AddWithValue("@p2", txt_cinsi.Text);
                com.Parameters.AddWithValue("@p3", txt_kapasite.Text);

                if (baglanti.baglan().State != ConnectionState.Open)
                {

                    baglanti.baglan().Open();
                    //eger veri tabanı baglantısı kapalı ise açacak açık ise hiç if e girmeyecek
                }
                com.ExecuteNonQuery();//kayıt gerçekleşmiş olacak 
                MessageBox.Show("ürün kaydı başarı ile eklendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txt_plaka.Text == "" || txt_cinsi.Text == "" || txt_kapasite.Text == "")
            {
                MessageBox.Show("ad alanını boş girdiniz");

            }
            else
            {
                SqlCommand komut = new SqlCommand("update tbl_arac set cinsi=@p1,kapasite=@p2 where plaka =@p3 ", baglanti.baglan());
                komut.Parameters.AddWithValue("@p1", txt_cinsi.Text);
                komut.Parameters.AddWithValue("@p2", txt_kapasite.Text);
                komut.Parameters.AddWithValue("@p3", txt_plaka.Text);
                //@p1 demesi ise cinsi anlama gelir 1 sutun 
                //@p2 demesi ise kapasite anlamına gelecek
                //@p3 demesi ise plaka anlamına gelir
                if (baglanti.baglan().State != ConnectionState.Open)
                {

                    baglanti.baglan().Open();
                    //eger veri tabanı baglantısı kapalı ise açacak açık ise hiç if e girmeyecek
                }
                komut.ExecuteNonQuery();//kayıt gerçekleşmiş olacak 
                MessageBox.Show("ürün güncelleme başarı ile tamamlandı", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (txt_plaka.Text == "" || txt_cinsi.Text == "" || txt_kapasite.Text == "")
            {
                MessageBox.Show("silinecek kaydınızı getirin");

            }
            else
            {
                SqlCommand komut = new SqlCommand("update tbl_arac set durum=@p1 where plaka=@p2 ", baglanti.baglan());
                komut.Parameters.AddWithValue("@p1", 0);
                komut.Parameters.AddWithValue("@p2", txt_plaka.Text);

                if (baglanti.baglan().State != ConnectionState.Open)
                {

                    baglanti.baglan().Open();
                    //eger veri tabanı baglantısı kapalı ise açacak açık ise hiç if e girmeyecek
                }
                komut.ExecuteNonQuery();//kayıt gerçekleşmiş olacak 
                MessageBox.Show("araç silme başarı ile tamamlandı", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            listele();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listele();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txt_plaka.Text == "" || txt_cinsi.Text == "" || txt_kapasite.Text == "")
            {
                MessageBox.Show("plaka/cins/kapasite alanını boş girdiniz");

            }
            else
            {
                SqlCommand com = new SqlCommand("insert into tbl_arac (plaka,cinsi,kapasite) values(@p1,@p2,@p3)", baglanti.baglan());
                com.Parameters.AddWithValue("@p1", txt_plaka.Text);
                com.Parameters.AddWithValue("@p2", txt_cinsi.Text);
                com.Parameters.AddWithValue("@p3", txt_kapasite.Text);

                if (baglanti.baglan().State != ConnectionState.Open)
                {

                    baglanti.baglan().Open();
                    //eger veri tabanı baglantısı kapalı ise açacak açık ise hiç if e girmeyecek
                }
                com.ExecuteNonQuery();//kayıt gerçekleşmiş olacak 
                MessageBox.Show("ürün kaydı başarı ile eklendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            listele();
        }
    }
}
