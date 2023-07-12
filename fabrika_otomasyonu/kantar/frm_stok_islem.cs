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
    public partial class frm_stok_islem : Form
    {
        public frm_stok_islem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_stok_arac_giris gir=new frm_stok_arac_giris();
            gir.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_stok_arac_cikis gir=new frm_stok_arac_cikis();
            gir.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_stok_bekleyen_arac gir=new frm_stok_bekleyen_arac();
            gir.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm_stok_raporlar gir=new frm_stok_raporlar();
            gir.Show();
        }
    }
}
