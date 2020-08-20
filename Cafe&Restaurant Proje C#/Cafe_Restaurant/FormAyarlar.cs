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
    public partial class FormAyarlar : Form
    {
        public FormAyarlar()
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

        private void FormAyarlar_Load(object sender, EventArgs e)
        {
            ClassPersoneller cp = new ClassPersoneller();
            ClassPersonelGorev cpg = new ClassPersonelGorev();
            string gorev = cpg.PersonelGorevTanim(ClassGenel._PersonelGorevId);
            if ("Müdür".Equals(gorev))
            {
                cp.PersonelGetbyInformation(cbPersonel);
                cpg.PersonelGorevGetir(cbGorevi);
                cp.personelBilgileriniGetirLV(lvPersoneller);
                btnYeni.Enabled = true;
                btnSil.Enabled = false;
                btnBilgiDegistir.Enabled = false;
                btnEkle.Enabled = false;
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = false;
                groupBox4.Visible = true;
                txtSifre.ReadOnly = true;
                txtSifreTekrar.ReadOnly = true;
                lvPersoneller.Enabled = true;
                lblBilgi.Text = "Mevki : Müdür / Yetki Sınırısız / Kullanıcı : " + cp.personelBilgiGetirIsim(ClassGenel._PersonelId);
            }
            else
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                groupBox3.Visible = true;
                groupBox4.Visible = false;
                
                lblBilgi.Text = "Mevki : Müdür / Yetki Sınırlı / Kullanıcı : " + cp.personelBilgiGetirIsim(ClassGenel._PersonelId);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtYeniSifre.Text.Trim() != "" || txtYeniSifreTekrar.Text.Trim() != "")
            {

                if (txtYeniSifre.Text == txtYeniSifreTekrar.Text)
                {

                    if (txtPersonelId.Text != "")
                    {
                        ClassPersoneller c = new ClassPersoneller();
                        bool sonuc = c.personelSifreDegistir(Convert.ToInt32(txtPersonelId.Text), txtYeniSifre.Text);
                        if (sonuc)
                        {
                            MessageBox.Show("Şifre Değiştirme İşlemi Başarıyla Gerçekleştirilmiştir. !!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Personel Seçiniz!");
                    }


                }
                else
                {
                    MessageBox.Show("Şifreler Aynı Değil !");
                }
            }
            else
            {
                MessageBox.Show("Şifre Alanını Boş Bırakmayınız !");
            }
        }
        private void cbGorevi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassPersonelGorev c = (ClassPersonelGorev)cbGorevi.SelectedItem;
            txtGorevId2.Text = Convert.ToString(c.PersonelGorevId);
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            btnYeni.Enabled = false;
            btnEkle.Enabled = true;
            btnBilgiDegistir.Enabled = false;
            btnSil.Enabled = false;
            txtSifre.ReadOnly = false;
            txtSifreTekrar.ReadOnly = false;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lvPersoneller.SelectedItems.Count > 0)
            {
                if ( MessageBox.Show("Silmek İstediğinize Emin Misiniz ? ", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ClassPersoneller c = new ClassPersoneller();
                    bool sonuc = c.personelSil(Convert.ToInt32(lvPersoneller.SelectedItems[0].Text)); 
                    if (sonuc)
                    {
                        MessageBox.Show("Kayıt Başarıyla Silinmiştir");
                        c.personelBilgileriniGetirLV(lvPersoneller);
                    }
                    else
                    {
                        MessageBox.Show("Kayıt Silinirken Bir Hata Oluştu");
                    }
                }
                else
                {
                    MessageBox.Show("Kayıt Seçiniz");
                }
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtAd.Text.Trim() !="" & txtSoyad.Text.Trim() != "" & txtSifre.Text.Trim() != "" & txtSifreTekrar.Text.Trim() != "" & txtGorevId2.Text.Trim() != "")
            {
                if ((txtSifreTekrar.Text.Trim()==txtSifre.Text.Trim()) && (txtSifre.Text.Length>5 || txtSifreTekrar.Text.Length>5))
                {
                    ClassPersoneller c = new ClassPersoneller();
                    c.PersonelAd = txtAd.Text.Trim();
                    c.PersonelSoyad = txtSoyad.Text.Trim();
                    c.PersonelParola = txtSifreTekrar.Text;
                    c.PersonelGorevId = Convert.ToInt32(txtGorevId2.Text);
                    bool sonuc = c.personelEkle(c);

                    if (sonuc)
                    {
                        MessageBox.Show("Kayıt Başarıyla Eklenmiştir.");
                        c.personelBilgileriniGetirLV(lvPersoneller);

                    }
                    else
                    {
                        MessageBox.Show("Kayıt Eklenirken Bir Hata Oluştu.");
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler Aynı Değil");
                }
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmayınız");
            }
        }

        private void btnBilgiDegistir_Click(object sender, EventArgs e)
        {
            if (lvPersoneller.SelectedItems.Count > 0)
            {


                if (txtAd.Text != "" || txtSoyad.Text != "" || txtSifre.Text != "" || txtGorevId2.Text != "")
                {
                    if ((txtSifreTekrar.Text.Trim() == txtSifre.Text.Trim()) && (txtSifre.Text.Length > 5 || txtSifreTekrar.Text.Length > 5))
                    {
                        ClassPersoneller c = new ClassPersoneller();
                        c.PersonelAd = txtAd.Text.Trim();
                        c.PersonelSoyad = txtSoyad.Text.Trim();
                        c.PersonelParola = txtSifreTekrar.Text;
                        c.PersonelGorevId = Convert.ToInt32(txtGorevId2.Text);
                        c.personelEkle(c);

                        bool sonuc = c.personelGuncelle(c,Convert.ToInt32(txtPersonelID2));

                        if (sonuc)
                        {
                            MessageBox.Show("Kayıt Başarıyla Eklenmiştir.");
                            c.personelBilgileriniGetirLV(lvPersoneller);
                        }
                        else
                        {
                            MessageBox.Show("Kayıt Eklenirken Bir Hata Oluştu.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler Aynı Değil");
                    }
                }
                else
                {
                    MessageBox.Show("Boş Alan Bırakmayınız");
                }
            }
            else
            {
                MessageBox.Show("Kayıt Seçiniz");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() != "" || textBox3.Text.Trim() != "")
            {

                if (textBox2.Text == textBox3.Text)
                {

                    if (ClassGenel._PersonelId.ToString() != "")
                    {
                        ClassPersoneller c = new ClassPersoneller();
                        bool sonuc = c.personelSifreDegistir(Convert.ToInt32(ClassGenel._PersonelId), textBox2.Text);
                        if (sonuc)
                        {
                            MessageBox.Show("Şifre Değiştirme İşlemi Başarıyla Gerçekleştirilmiştir. !!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Personel Seçiniz!");
                    }


                }
                else
                {
                    MessageBox.Show("Şifreler Aynı Değil !");
                }
            }
            else
            {
                MessageBox.Show("Şifre Alanını Boş Bırakmayınız !");
            }
        }

        private void lvPersoneller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPersoneller.SelectedItems.Count>0)
            {
                btnSil.Enabled = true;
                txtPersonelID2.Text = lvPersoneller.SelectedItems[0].SubItems[0].Text;
                // txtGorevId2.Text = lvPersoneller.SelectedItems[1].Text;
                cbGorevi.SelectedIndex = Convert.ToInt32(lvPersoneller.SelectedItems[0].SubItems[1].Text) ;
                txtAd.Text = lvPersoneller.SelectedItems[0].SubItems[3].Text;
                txtSoyad.Text = lvPersoneller.SelectedItems[0].SubItems[4].Text;

            }
            else
            {
                btnSil.Enabled = false;
            }
               
            
                 
            
            
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void cbGorevi_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
