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

namespace kantar
{
    public partial class frm_firma_islemleri : Form
    {
        public frm_firma_islemleri()
        {
            InitializeComponent();
        }
        public void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select ID,ad,telefon,adres from tbl_firma where durum=1 ", baglanti.baglan());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            txt_ad.Text = "";
            txt_adres.Text = "";
            txt_telefon.Text = "";
        }
        public void silinenler()
        {
            SqlDataAdapter da = new SqlDataAdapter("select ID,ad,telefon,adres from tbl_firma where durum=0 ", baglanti.baglan());
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView2.DataSource = table;

        }

        private void frm_firma_islemleri_Load(object sender, EventArgs e)
        {
            listele();
            silinenler();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_ad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_adres.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_telefon.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_ad.Text == ""  || txt_telefon.Text == "" || txt_adres.Text == "")
            {
                MessageBox.Show("ad/id/tc/telefon/adres alanını boş girdiniz");

            }
            else
            {
                SqlCommand komut = new SqlCommand("insert into tbl_firma (ad,adres,telefon) values(@p1,@p3,@p4)", baglanti.baglan());
                komut.Parameters.AddWithValue("@p1", txt_ad.Text);
                
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
            if (txt_ad.Text == "" || txt_telefon.Text == "" || txt_adres.Text == "")
            {
                MessageBox.Show("ad/id/tc/telefon/adres alanını boş girdiniz");

            }
            else
            {
                SqlCommand komut = new SqlCommand("update tbl_firma set ad=@p1,adres=@p3,telefon=@p5 where ID =@p4 ", baglanti.baglan());
                komut.Parameters.AddWithValue("@p1", txt_ad.Text);
              
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
                SqlCommand komut = new SqlCommand("update tbl_firma set durum=@p1 where ID =@p2 ", baglanti.baglan());
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (false)
            {
                MessageBox.Show("silinecek kaydınızı getirin");

            }
            else
            {
                SqlCommand komut = new SqlCommand("update tbl_firma set durum=@p1 where ID =@p2 ", baglanti.baglan());
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

        private void button4_Click(object sender, EventArgs e)
        {
            listele();
        }
    }
}
