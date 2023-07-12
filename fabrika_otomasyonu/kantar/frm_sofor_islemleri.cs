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
    public partial class frm_sofor_islemleri : Form
    {
        public frm_sofor_islemleri()
        {
            InitializeComponent();
        }
        public void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select ID,adSoyad,tc,adres,tel from tbl_sofor where durum=1 ", baglanti.baglan());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            txt_ad.Text = "";
            txt_adres.Text = "";
            txt_tc.Text = "";
            txt_telefon.Text = "";
        }
        public void silinenler()
        {
            SqlDataAdapter da = new SqlDataAdapter("select ID,adSoyad,tc,tel,adres from tbl_sofor where durum=0 ", baglanti.baglan());
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView2.DataSource = table;

        }

        private void frm_sofor_islemleri_Load(object sender, EventArgs e)
        {
            listele();
            silinenler();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_ad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_tc.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_adres.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_telefon.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
 
    
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_ad.Text == "" || txt_tc.Text == "" || txt_telefon.Text == "" || txt_adres.Text == "" ) 
            {
                MessageBox.Show("ad/id/tc/telefon/adres alanını boş girdiniz");

            }
            else
            {
                SqlCommand komut = new SqlCommand("insert into tbl_sofor (adSoyad,tc,adres,tel) values(@p1,@p2,@p3,@p4)", baglanti.baglan());
                komut.Parameters.AddWithValue("@p1", txt_ad.Text);
                komut.Parameters.AddWithValue("@p2",txt_tc.Text);
                komut.Parameters.AddWithValue("@p3", txt_adres.Text);
                komut.Parameters.AddWithValue("@p4", txt_telefon.Text);


                if (baglanti.baglan().State != ConnectionState.Open)
                {

                    baglanti.baglan().Open();
                    //eger veri tabanı baglantısı kapalı ise açacak açık ise hiç if e girmeyecek
                }
                komut.ExecuteNonQuery();//kayıt gerçekleşmiş olacak 
                MessageBox.Show("şoför kaydı başarı ile eklendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txt_ad.Text == "" || txt_tc.Text == "" || txt_telefon.Text == "" || txt_adres.Text == "")
            {
                MessageBox.Show("ad/id/tc/telefon/adres alanını boş girdiniz");

            }
            else
            {
                SqlCommand komut = new SqlCommand("update tbl_sofor set adSoyad=@p1,tc=@p2,adres=@p3,tel=@p5 where ID =@p4 ", baglanti.baglan());
                komut.Parameters.AddWithValue("@p1", txt_ad.Text);
                komut.Parameters.AddWithValue("@p2", txt_tc.Text);
                komut.Parameters.AddWithValue("@p3", txt_adres.Text);
                komut.Parameters.AddWithValue("@p5", txt_telefon.Text);
                komut.Parameters.AddWithValue("@p4", txt_id.Text);
                //@p1 demesi şu anlama gelir 1 sutun 
                //p2 demesi ise ıd anlamına gelecek

                if (baglanti.baglan().State != ConnectionState.Open)
                {

                    baglanti.baglan().Open();
                    //eger veri tabanı baglantısı kapalı ise açacak açık ise hiç if e girmeyecek
                }
                komut.ExecuteNonQuery();//kayıt gerçekleşmiş olacak 
                MessageBox.Show("şoför güncelleme başarı ile tamamlandı", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            listele();
            silinenler();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (false)
            {
                MessageBox.Show("ad/id/tc/telefon/adres alanını boş girdiniz");

            }
            else
            {
                SqlCommand komut = new SqlCommand("update tbl_sofor set durum=@p1 where ID =@p2 ", baglanti.baglan());
                komut.Parameters.AddWithValue("@p1", 0);
                komut.Parameters.AddWithValue("@p2", txt_id.Text);

                if (baglanti.baglan().State != ConnectionState.Open)
                {

                    baglanti.baglan().Open();
                    //eger veri tabanı baglantısı kapalı ise açacak açık ise hiç if e girmeyecek
                }
                komut.ExecuteNonQuery();//kayıt gerçekleşmiş olacak 
                MessageBox.Show("ürün silme başarı ile tamamlandı", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            listele();
            silinenler();
        }

        private void txt_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (false)
            {
                MessageBox.Show("silinecek kaydınızı getirin");

            }
            else
            {
                SqlCommand komut = new SqlCommand("update tbl_sofor set durum=@p1 where ID =@p2 ", baglanti.baglan());
                komut.Parameters.AddWithValue("@p1", 1);
                komut.Parameters.AddWithValue("@p2", txt_id.Text);

                if (baglanti.baglan().State != ConnectionState.Open)
                {

                    baglanti.baglan().Open();
                    //eger veri tabanı baglantısı kapalı ise açacak açık ise hiç if e girmeyecek
                }
                komut.ExecuteNonQuery();//kayıt gerçekleşmiş olacak 
                MessageBox.Show("ürün silme başarı ile tamamlandı", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            silinenler();
            listele();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_id.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txt_ad.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txt_tc.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txt_adres.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            txt_telefon.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
