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
    public partial class FormMusteriEkleme : Form
    {
        public FormMusteriEkleme()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            
            if (txtTelefon.Text.Length>6)
            {
                if (txtMusteriAdi.Text == "" || txtSoyad.Text == "")
                {
                    MessageBox.Show("Lütfen Müşterinin ad ve soyad alanını doldurunuz.");
                }
                else
                {
                    ClassMusteriler c = new ClassMusteriler();
                    bool sonuc = c.MusteriVarmı(txtTelefon.Text);
                    if (!sonuc)
                    {
                        c.Musteriad = txtMusteriAdi.Text;
                        c.Musterisoyad = txtSoyad.Text;
                        c.Telefon = txtTelefon.Text;
                        c.Email = txtEmail.Text;
                        c.Adres = txtAdres.Text;

                        txtMusteriNo.Text = c.musteriEkle(c).ToString();
                        if (txtMusteriNo.Text !="")
                        {
                            MessageBox.Show("Müşteri Eklendi");
                        }
                        else
                        {
                            MessageBox.Show("Müşteri Eklenemedi!!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu isimde kayıt bulunmaktadır.Lütfen kontrol ediniz!!!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen en az 7 haneli geçerli bir telefon numarası giriniz.");
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinize Emin Misiniz ?", "Uyarı !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            FormMusteriAra frm = new FormMusteriAra();
            this.Close();
            frm.Show();
        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
            if (ClassGenel._musteriEkleme == 0)
            {
                FormRezervasyon frm = new FormRezervasyon();
                ClassGenel._musteriEkleme = 1;
                this.Close();
                frm.Show();
            }
            /*else if (ClassGenel._musteriEkleme == 1)
            {
                FormPaketSiparis frm = new FormPaketSiparis();
                ClassGenel._musteriEkleme = 0;
                this.Close();
                frm.Show();
            }*/
        }

        private void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {
            if (txtTelefon.Text.Length > 6)
            {
                if (txtMusteriAdi.Text == "" || txtSoyad.Text == "")
                {
                    MessageBox.Show("Lütfen Müşterinin ad ve soyad alanını doldurunuz.");
                }
                else
                {
                    ClassMusteriler c = new ClassMusteriler();

                    c.Musteriad = txtMusteriAdi.Text;
                    c.Musterisoyad = txtSoyad.Text;
                    c.Telefon = txtTelefon.Text;
                    c.Email = txtEmail.Text;
                    c.Adres = txtAdres.Text;
                    c.Musteriid = Convert.ToInt32(txtMusteriNo.Text);
                    bool sonuc=c.musteriBilgileriGuncelle(c);
                   // txtMusteriNo.Text = c.musteriEkle(c).ToString();

                    if (sonuc)
                    {
                        
                        if (txtMusteriNo.Text != "")
                        {
                            MessageBox.Show("Müşteri Güncellendi");
                        }
                        else
                        {
                            MessageBox.Show("Müşteri Güncellenemedi!!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu isimde kayıt bulunmaktadır.Lütfen kontrol ediniz!!!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen en az 7 haneli geçerli bir telefon numarası giriniz.");
            }
        }

        private void FormMusteriEkleme_Load(object sender, EventArgs e)
        {
            if (ClassGenel._musteriId>0)
            {
                ClassMusteriler c = new ClassMusteriler();
                txtMusteriNo.Text = ClassGenel._musteriId.ToString();
                c.musterilerigetirID(Convert.ToInt32(txtMusteriNo.Text), txtMusteriAdi, txtSoyad, txtTelefon, txtAdres, txtEmail);
            }
        }
    }
}
