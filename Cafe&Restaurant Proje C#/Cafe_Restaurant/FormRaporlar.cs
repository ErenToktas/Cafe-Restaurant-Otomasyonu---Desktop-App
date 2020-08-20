using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Cafe_Restaurant
{
    public partial class FormRaporlar : Form
    {
        public FormRaporlar()
        {
            InitializeComponent();
        }

        private void FormRaporlar_Load(object sender, EventArgs e)
        {

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

        private void btnZraporu_Click(object sender, EventArgs e)
        {
            chRapor.Palette = ChartColorPalette.None;
            chRapor.Series[0].EmptyPointStyle.Color = Color.Transparent;
            chRapor.Series[0].Color = Color.GreenYellow;
            ClassUrunler u = new ClassUrunler();
            lvİstatistik.Items.Clear();
            u.urunlerİstatistiklereGoreListele(lvİstatistik, dtBaslangic, dtBitis);
            gbİstatistik.Text = "TÜM ÜRÜNLER";

            if (lvİstatistik.Items.Count > 0)
            {
                chRapor.Series["Satislar"].Points.Clear();
                for (int i = 0; i < lvİstatistik.Items.Count; i++)
                {
                    chRapor.Series["Satislar"].Points.AddXY(lvİstatistik.Items[i].SubItems[0].Text, lvİstatistik.Items[i].SubItems[1].Text);
                }
            }
            else
            {
                MessageBox.Show("Gösterilebilecek bir istatistik yok. Başka bir istatistik seçiniz");
            }
        }

        private void Istatistik(string gfName,int KatId, Color renk)
        {
            chRapor.Palette = ChartColorPalette.None;
            chRapor.Series[0].EmptyPointStyle.Color = Color.Transparent;
            chRapor.Series[0].Color = renk;
            ClassUrunler u = new ClassUrunler();
            lvİstatistik.Items.Clear();
            u.urunlerİstatistiklereGoreListeleUrunId(lvİstatistik, dtBaslangic, dtBitis, KatId);
            gbİstatistik.Text = gfName;

            if (lvİstatistik.Items.Count > 0)
            {
                chRapor.Series["Satislar"].Points.Clear();
                for (int i = 0; i < lvİstatistik.Items.Count; i++)
                {
                    chRapor.Series["Satislar"].Points.AddXY(lvİstatistik.Items[i].SubItems[0].Text, lvİstatistik.Items[i].SubItems[1].Text);
                }
            }
            else
            {
                MessageBox.Show("Gösterilebilecek bir istatistik yok. Başka bir istatistik seçiniz");
            }
        }

        private void btnAnaYemekler_Click(object sender, EventArgs e)
        {
            Istatistik("Ana Yemekler Grafiği",3,Color.Red);
        }

        private void btnİcecekler8_Click(object sender, EventArgs e)
        {
            Istatistik("İçecekler Grafiği", 8, Color.Orange);

        }

        private void btnTatlilar7_Click(object sender, EventArgs e)
        {
            Istatistik("Tatlılar Grafiği", 7, Color.Yellow);

        }

        private void btnSalata6_Click(object sender, EventArgs e)
        {
            Istatistik("Salatalar Grafiği", 6, Color.Green);

        }

        private void btnFastFood5_Click(object sender, EventArgs e)
        {
            Istatistik("Fast Food Grafiği", 5, Color.Purple);

        }

        private void btnCorba1_Click(object sender, EventArgs e)
        {
            Istatistik("Çorbalar Grafiği", 1, Color.Blue);

        }

        private void btnMakarnalar4_Click(object sender, EventArgs e)
        {
            Istatistik("Makarnalar Grafiği", 4, Color.Gray);

        }

        private void btnAraSicak2_Click(object sender, EventArgs e)
        {
            Istatistik("Ara Sıcaklar Grafiği", 2, Color.Black);

        }
    }
}
