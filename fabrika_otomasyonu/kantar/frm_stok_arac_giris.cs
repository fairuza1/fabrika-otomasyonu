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
    public partial class frm_stok_arac_giris : Form
    {
        public frm_stok_arac_giris()
        {
            InitializeComponent();
        }
        public void listelesofor()
        {
            // sql command komutu sql e sorgu yapmaya yarar ve değişikliği bu sayede yapabilmeyi sağlar
            // sql adapter ise sql e deki verileri çekmeye ve verileri yazmaya yarar
            SqlCommand komut = new SqlCommand("select * from tbl_sofor where durum =1 ",baglanti.baglan());
            if(baglanti.baglan().State !=ConnectionState.Open ) 
            {
                // baglantı durumu(state) kapalımı anlamında yazdım bu satırı kapalı ise açmak için metot yazdım
                baglanti.baglan().Open();
            }
            //satır satır okutacağım sql datareader ile
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                //durumu 1 olanları getirecek ve combobox a yazacak 
                cmb_ad_soyad.Items.Add(dr[0]+  "  :  " + dr[1]); 
            }


        }
        public void listeleplaka()
        {
            SqlCommand komut = new SqlCommand("select * from tbl_arac where durum =1 ", baglanti.baglan());
            if (baglanti.baglan().State != ConnectionState.Open)
            {
                // baglantı durumu(state) kapalımı anlamında yazdım bu satırı kapalı ise açmak için metot yazdım
                baglanti.baglan().Open();
            }
            //satır satır okutacağım sql datareader ile
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                //durumu 1 olanları getirecek ve combobox a yazacak 
                cmb_plaka.Items.Add(dr[0]);
            }


        }
        public void listelefirma()
        {
            SqlCommand komut = new SqlCommand("select * from tbl_firma where durum =1 ", baglanti.baglan());
            if (baglanti.baglan().State != ConnectionState.Open)
            {
                // baglantı durumu(state) kapalımı anlamında yazdım bu satırı kapalı ise açmak için metot yazdım
                baglanti.baglan().Open();
            }
            //satır satır okutacağım sql datareader ile
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                //durumu 1 olanları getirecek ve combobox a yazacak 
                cmb_firma_ad.Items.Add(dr[0] + "  :  " + dr[1]);
            }


        }
        public void listeleurun()
        {
            SqlCommand komut = new SqlCommand("select * from tbl_urun where durum =1 ", baglanti.baglan());
            if (baglanti.baglan().State != ConnectionState.Open)
            {
                // baglantı durumu(state) kapalımı anlamında yazdım bu satırı kapalı ise açmak için metot yazdım
                baglanti.baglan().Open();
            }
            //satır satır okutacağım sql datareader ile
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                //durumu 1 olanları getirecek ve combobox a yazacak 
                cmb_urun_ad.Items.Add(dr[0] + "  :  " + dr[1]);
            }


        }
        public void listelememur()
        {
            SqlCommand komut = new SqlCommand("select * from tbl_memur where durum =1 ", baglanti.baglan());
            if (baglanti.baglan().State != ConnectionState.Open)
            {
                // baglantı durumu(state) kapalımı anlamında yazdım bu satırı kapalı ise açmak için metot yazdım
                baglanti.baglan().Open();
            }
            //satır satır okutacağım sql datareader ile
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                //durumu 1 olanları getirecek ve combobox a yazacak 
                cmb_memur_ad_soyad.Items.Add(dr[0] + "  :  " + dr[1]);
            }


        }



        private void frm_stok_arac_giris_Load(object sender, EventArgs e)
        {
            listelesofor();
            listeleplaka();
            listelefirma();
            listeleurun();
            listelememur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            


            if(cmb_ad_soyad.Text=="" || cmb_firma_ad.Text == "" || cmb_memur_ad_soyad.Text == "" || cmb_plaka.Text == "" || cmb_urun_ad.Text == "" || txt_ilk_tart.Text=="" )
            {
                MessageBox.Show("alanları eksiksiz giriniz","bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string[] dizi;
                SqlCommand komut = new SqlCommand("insert into tbl_tanitim(tur,plaka,soforID,firmaID,urunID,ilkTartim,ikinciTartim,netTartim,girisTarih,cıkısTarih,aciklama,durum,kMemurID) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13)  ", baglanti.baglan());
                komut.Parameters.AddWithValue("@p1", 1); //1=stok işlemi 2=sevkiyat işlemi
                komut.Parameters.AddWithValue("@p2",cmb_plaka.Text );
                // burada ise diziyi şu yüzden aldım veri tabanına int bir değer ekleyeceğim ama burda ise hem int hemde string bir ifade var o yüzde diziye aldım bu metodu
                dizi = cmb_ad_soyad.SelectedItem.ToString().Split(':');
                komut.Parameters.AddWithValue("@p3", int.Parse(dizi[0]));
                // burada ise diziyi şu yüzden aldım veri tabanına int bir değer ekleyeceğim ama burda ise hem int hemde string bir ifade var o yüzde diziye aldım bu metodu
                dizi = cmb_firma_ad.SelectedItem.ToString().Split(':');
                komut.Parameters.AddWithValue("@p4", int.Parse(dizi[0]));
                // burada ise diziyi şu yüzden aldım veri tabanına int bir değer ekleyeceğim ama burda ise hem int hemde string bir ifade var o yüzde diziye aldım bu metodu
                dizi = cmb_urun_ad.SelectedItem.ToString().Split(':');
                komut.Parameters.AddWithValue("@p5", int.Parse(dizi[0]));

                komut.Parameters.AddWithValue("@p6", txt_ilk_tart.Text);

                komut.Parameters.AddWithValue("@p7", 0);

                komut.Parameters.AddWithValue("@p8", 0);

                komut.Parameters.AddWithValue("@p9", DateTime.Now);
                
                komut.Parameters.AddWithValue("@p10", DateTime.Now);
                
                komut.Parameters.AddWithValue("@p11", "araç boşaltım için fabrikaya giriş yapıldı");

                komut.Parameters.AddWithValue("@p12", 1);

                // burada ise diziyi şu yüzden aldım veri tabanına int bir değer ekleyeceğim ama burda ise hem int hemde string bir ifade var o yüzde diziye aldım bu metodu
                dizi = cmb_memur_ad_soyad.SelectedItem.ToString().Split(':');
                komut.Parameters.AddWithValue("@p13", int.Parse(dizi[0]));

                if (baglanti.baglan().State != ConnectionState.Open)
                {
                    // baglantı durumu(state) kapalımı anlamında yazdım bu satırı kapalı ise açmak için metot yazdım
                    baglanti.baglan().Open();
                }
                komut.ExecuteNonQuery();
                MessageBox.Show("araç giriş kaydı tamamlandı", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cmb_ad_soyad.Text = "";
                cmb_firma_ad.Text = "";
                cmb_memur_ad_soyad.Text = "";
                cmb_plaka.Text = "";
                cmb_urun_ad.Text = "";
                txt_ilk_tart.Text = "";





            }
        }
    }
}
