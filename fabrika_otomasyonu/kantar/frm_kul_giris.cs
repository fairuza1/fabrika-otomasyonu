using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kantar
{
    public partial class frm_kul_giris : Form
    {
        public frm_kul_giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txt_kul_ad.Text=="a")
            {
                MessageBox.Show("kullanıcı adını giriniz");
                txt_kul_ad.Focus();
            }
            else if(txt_kul_sifre.Text=="a")
            {
                MessageBox.Show("şifreyi giriniz");
                txt_kul_sifre.Focus();
            }
            else if(txt_kul_ad.Text==""&&txt_kul_sifre.Text=="")
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("kullanıcı adı veya şifre yanlış");
                txt_kul_ad.Clear();
                txt_kul_sifre.Clear();
                txt_kul_ad.Focus();
                    }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frm_kul_giris_Load(object sender, EventArgs e)
        {

        }
    }
}
