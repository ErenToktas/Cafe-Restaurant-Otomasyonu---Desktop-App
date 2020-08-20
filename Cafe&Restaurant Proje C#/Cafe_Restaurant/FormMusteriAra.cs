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
    public partial class FormMusteriAra : Form
    {
        public FormMusteriAra()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinize Emin Misiniz ?", "Uyarı !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnGeriMenu_Click(object sender, EventArgs e)
        {
            FormMenu frm = new FormMenu();
            this.Close();
            frm.Show();
        }

        private void btnYeniMusteri_Click(object sender, EventArgs e)
        {
            FormMusteriEkleme m = new FormMusteriEkleme();
            ClassGenel._musteriEkleme = 1;
            m.Show();
        }

        private void FormMusteriAra_Load(object sender, EventArgs e)
        {
            ClassMusteriler c = new ClassMusteriler();
            c.musterileriGetir(lvMusteriler);
        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {

        }

        private void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {
            if (lvMusteriler.SelectedItems.Count>0)
            {
                FormMusteriEkleme frm = new FormMusteriEkleme();
                ClassGenel._musteriEkleme = 1;
                ClassGenel._musteriId = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);        

                this.Close();
                frm.Show();
            }
        }

        private void txtMusteriAdi_TextChanged(object sender, EventArgs e)
        {
            ClassMusteriler c = new ClassMusteriler();
            c.musterigetirAd(lvMusteriler, txtMusteriAdi.Text);
        }

        private void txtSoyad_TextChanged(object sender, EventArgs e)
        {
            ClassMusteriler c = new ClassMusteriler();
            c.musterigetirSoyad(lvMusteriler,txtSoyad.Text);
        }

        private void txtTelefon_TextChanged(object sender, EventArgs e)
        {
            ClassMusteriler c = new ClassMusteriler();
            c.musterigetirTlf(lvMusteriler, txtTelefon.Text);
        }

        private void btnAdisyonBul_Click(object sender, EventArgs e)
        {
            if (txtAdisyonId.Text!="")
            {
                ClassGenel._AdisyonId = txtAdisyonId.Text;
                ClassPaketler c = new ClassPaketler();

                bool sonuc = c.getCheckOpenAdditionID(Convert.ToInt32(txtAdisyonId.Text));
                if (sonuc)
                {
                    FormBill frm = new FormBill();
                    ClassGenel._ServisTurNo = 2;
                    frm.Show();
                }
                else
                {
                    MessageBox.Show(txtAdisyonId.Text + "No lu adisyon bulunamadı.");
                }
            }
            else
            {
                MessageBox.Show("Aramak istediğiniz adisyonu yazınız");

            }
        }

        private void btnSiparisler_Click(object sender, EventArgs e)
        {
            FormSiparisKontrol frm = new FormSiparisKontrol();
            this.Close();
            frm.Show();
        }
    }
}
