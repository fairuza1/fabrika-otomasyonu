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
    public partial class frm_tanimlama : Form
    {
        public frm_tanimlama()
        {
            InitializeComponent();
        }

        private void frm_tanimlama_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_urun_islemleri giris=new frm_urun_islemleri();
            giris.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_arac_islemleri gir = new frm_arac_islemleri();
            gir.Show(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_sofor_islemleri gir=new frm_sofor_islemleri();
            gir.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm_kantar_islemleri gir = new frm_kantar_islemleri();
            gir.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frm_firma_islemleri gir=new frm_firma_islemleri();
            gir.Show();
        }
    }
}
