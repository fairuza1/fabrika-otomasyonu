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
    public partial class frm_ana : Form
    {
        public frm_ana()
        {
            InitializeComponent();
        }

        private void frm_ana_Load(object sender, EventArgs e)
        {
            frm_kul_giris giris= new frm_kul_giris();
            giris.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_tanimlama giris= new frm_tanimlama();
            giris.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           frm_sevkiyat_islem giris=new frm_sevkiyat_islem();
            giris.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_stok_islem giris = new frm_stok_islem();
            giris.Show();
        }
    }
}
