using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_Restaurant
{
    public partial class FormSiparisKontrol : Form
    {
        public FormSiparisKontrol()
        {
            InitializeComponent();
        }

        private void FormSiparisKontrol_Load(object sender, EventArgs e)
        {
            ClassAdisyon c = new ClassAdisyon();
            int butonSayisi = c.paketAdisyonIdbulAdedi();
            c.acikPaketAdisyonlar(lvMusteriler);
            int alt = 1;
            int sol = 50;
            int bol = Convert.ToInt32(Math.Ceiling(Math.Sqrt(butonSayisi)));

            for (int i = 1; i <= butonSayisi; i++)
            {
                Button btn = new Button();

                btn.AutoSize = false;
                btn.Size = new Size(200, 50);

                btn.FlatStyle = FlatStyle.Flat;
                btn.Name = lvMusteriler.Items[i - 1].SubItems[0].Text;
                btn.Text = lvMusteriler.Items[i - 1].SubItems[1].Text;
                btn.Font = new Font(btn.Font.FontFamily.Name, 18);
                btn.Location = new Point(sol, alt);
                this.Controls.Add(btn);


                sol += btn.Width + 5;

                if (i ==2)
                {
                    sol = 1;
                    alt += 50;
                }
                btn.Click += new EventHandler(dinamikmetod);
                btn.MouseEnter += new EventHandler(dinamikmetod2);
            }
        }
        
        protected void dinamikmetod(object sender, EventArgs e)
        {
            ClassAdisyon c = new ClassAdisyon();
            Button dinamikbuton = (sender as Button);
            FormBill frm = new FormBill();
            ClassGenel._ServisTurNo = 2;
            ClassGenel._AdisyonId = Convert.ToString(c.musterininsonadisyonId(Convert.ToInt32(dinamikbuton.Name)));
            frm.Show();
        }
        protected void dinamikmetod2(object sender, EventArgs e)
        {
            Button dinamikbuton = (sender as Button);
            ClassAdisyon c = new ClassAdisyon();
            c.musteriDetaylar(lvMusteriDetaylari, Convert.ToInt32(dinamikbuton.Name));
            sonSiparisTarihi();
            lvSatisDetaylari.Items.Clear();
            ClassSiparis s = new ClassSiparis();
            ClassGenel._ServisTurNo = 2;
            ClassGenel._AdisyonId = Convert.ToString(c.musterininsonadisyonId(Convert.ToInt32(dinamikbuton.Name)));
            lblGenelToplam.Text = s.GenelToplamBul(Convert.ToInt32(dinamikbuton.Name)).ToString() + " TL "; 
            
        }
        void sonSiparisTarihi()
        {
            if (lvMusteriDetaylari.Items.Count>0)
            {
                int s = lvMusteriDetaylari.Items.Count;
                lblSonSiparisTarihi.Text = lvMusteriDetaylari.Items[0].SubItems[3].Text;
                txtToplamTutar.Text = s + "Adet";
            }
        }
        void toplam()
        {
            int kayitSayisi = lvSatisDetaylari.Items.Count;
            decimal toplam = 0;
            for (int i = 0; i < kayitSayisi; i++)
            {
                toplam += Convert.ToDecimal(lvSatisDetaylari.Items[i].SubItems[2].Text) * Convert.ToDecimal(lvSatisDetaylari.Items[i].SubItems[3].Text);

                lblToplamSiparis.Text = toplam.ToString() + " TL ";
            }
        }

        private void lvMusteriDetaylari_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMusteriDetaylari.SelectedItems.Count>0)
            {
                ClassSiparis c = new ClassSiparis();
                c.adisyonpaketsiparisDetaylari(lvSatisDetaylari, Convert.ToInt32(lvMusteriDetaylari.SelectedItems[0].SubItems[4].Text));
                toplam();
            }
        }

        private void btnGeriMenu_Click(object sender, EventArgs e)
        {
            FormMenu frm = new FormMenu();
            this.Close();
            frm.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinize Emin Misiniz ?", "Uyarı !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
