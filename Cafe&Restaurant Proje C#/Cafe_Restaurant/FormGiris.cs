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
    public partial class FormGiris : Form
    {
        public FormGiris()
        {
            InitializeComponent();
            
        }
        
        private void lblKullaniciAdi_Click(object sender, EventArgs e)
        {

        }

        private void comboKullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassPersoneller p = (ClassPersoneller)comboKullanici.SelectedItem; // Dönüşüm yapıldı
            ClassGenel._PersonelId = p.PersonelId;
            ClassGenel._PersonelGorevId = p.PersonelGorevId;
            
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinize Emin Misiniz ?","Uyarı !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            ClassGenel gnl = new ClassGenel();
            ClassPersoneller p = new ClassPersoneller();
            bool result = p.personelEntryControl(txtSifre.Text, ClassGenel._PersonelId);

            if (result)
            {
                ClassPersonelHareketleri ch = new ClassPersonelHareketleri();
                ch.PersonelId = ClassGenel._PersonelId;
                ch.Islem = "Giriş Yaptı";
                ch.Tarih = DateTime.Now;
                ch.PersonelActionSave(ch);

                this.Hide();
                FormMenu menu = new FormMenu();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Şifreniz Yanlış ?", "Uyarı !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSifre_Click(object sender, EventArgs e)
        {

        }

        private void FormGiris_Load(object sender, EventArgs e)
        {
            ClassPersoneller p = new ClassPersoneller();
            p.PersonelGetbyInformation(comboKullanici);
        }
    }
}
