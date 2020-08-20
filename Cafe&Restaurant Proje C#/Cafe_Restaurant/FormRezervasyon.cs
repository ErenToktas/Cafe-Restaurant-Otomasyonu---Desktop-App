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
    public partial class FormRezervasyon : Form
    {
        public FormRezervasyon()
        {
            InitializeComponent();
        }

        private void FormRezervasyon_Load(object sender, EventArgs e)
        {
            ClassMusteriler m = new ClassMusteriler();
            m.musterileriGetir(lvMüsteriler);

            ClassMasalar masa = new ClassMasalar();
            masa.MasaKapasitesiveDurumGetir(cbMasa);

            dtTarih.MinDate = DateTime.Today;
            dtTarih.Format = DateTimePickerFormat.Time;
        }

        private void txtMusteriAd_TextChanged(object sender, EventArgs e)
        {
            ClassMusteriler m = new ClassMusteriler();
            m.musterigetirAd(lvMüsteriler, txtMusteriAd.Text);
        }

        private void txtTelefon_TextChanged(object sender, EventArgs e)
        {
            ClassMusteriler m = new ClassMusteriler();
            m.musterigetirTlf(lvMüsteriler, txtTelefon.Text);
        }

        private void txtAdres_TextChanged(object sender, EventArgs e)
        {
            ClassMusteriler m = new ClassMusteriler();
            m.musterigetirTlf(lvMüsteriler, txtAdres.Text);
        }
        void temizle()
        {
            txtAdres.Clear();
            txtKisiSayisi.Clear();
            txtMasa.Clear();
            txtTarih.Clear();
            txtAdres.Clear();
        }

        private void btnMüsteriSec_Click(object sender, EventArgs e)
        {
            ClassRezervasyon r = new ClassRezervasyon();
            if (lvMüsteriler.SelectedItems.Count > 0)
            {
                bool sonuc = r.RezervasyonAcikmiKontrol(Convert.ToInt32(lvMüsteriler.SelectedItems[0].SubItems[0].Text));
                if (!sonuc)
                {
                    if (txtTarih.Text != "")
                    {
                        if (txtKisiSayisi.Text != "")
                        {
                            ClassMasalar masa = new ClassMasalar();
                            if (masa.TableGetbyState(Convert.ToInt32(txtMasaNo.Text), 1))
                            {
                                ClassAdisyon a = new ClassAdisyon();
                                a.Tarih = Convert.ToDateTime(txtTarih.Text);
                                a.ServisTurNo = 1;
                                a.MasaId = Convert.ToInt32(txtMasaNo.Text);
                                a.PersonelId = ClassGenel._PersonelId;

                                r.ClientId = Convert.ToInt32(Convert.ToInt32(lvMüsteriler.SelectedItems[0].SubItems[0].Text));
                                r.TableId = Convert.ToInt32(txtMasaNo.Text);
                                r.Date = Convert.ToDateTime(txtTarih.Text);
                                r.CleintCount = Convert.ToInt32(txtKisiSayisi.Text);
                                r.Description = txtAciklama.Text;

                                r.AdditionId = a.RezervasyonAdisyon(a);
                                sonuc = r.RezervasyonAc(r);

                                masa.setChangeTableState(txtMasaNo.Text, 3);

                                if (sonuc)
                                {
                                    MessageBox.Show("Rezervasyon başarıyla açılmıştır");
                                    temizle();
                                }
                                else
                                {
                                    MessageBox.Show("Rezervasyon Kaydı Gerçekleşememiştir Lütfen Yetkiliyle İletişime Geçiniz");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Rezervasyon yapılan masa şu an dolu");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Lütfen kişi sayısı seçiniz");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Lütfen bir tarih seçiniz");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Bu müşteri üzerine açık bir rezervasyon bulunmaktadır.");
                }
                
            }
        }

        private void dtTarih_MouseEnter(object sender, EventArgs e)
        {
            dtTarih.Width = 200;

        }

        private void dtTarih_Enter(object sender, EventArgs e)
        {
            dtTarih.Width = 200;
        }

        private void dtTarih_ValueChanged(object sender, EventArgs e)
        {
            dtTarih.Width = 200;
        }

        private void dtTarih_MouseLeave(object sender, EventArgs e)
        {
            dtTarih.Text = dtTarih.Value.ToString();
        }

        private void cbKisiSayisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKisiSayisi.Text = cbKisiSayisi.SelectedItem.ToString();
        }

        private void cbMasa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbKisiSayisi.Enabled = true;
            txtMasa.Text = cbMasa.SelectedItem.ToString();

            ClassMasalar Kapasitesi = (ClassMasalar)cbMasa.SelectedItem;
            int kapasite = Kapasitesi.KAPASİTE;
            txtMasaNo.Text = Convert.ToString(Kapasitesi.ID);

            cbKisiSayisi.Items.Clear();
            for (int i = 0; i < kapasite; i++)
            {
                cbKisiSayisi.Items.Add(i + 1);
            }
        }

        private void cbMasa_MouseEnter(object sender, EventArgs e)
        {
            cbMasa.Width = 210;
            
        }

        private void cbMasa_MouseLeave(object sender, EventArgs e)
        {
            cbMasa.Width = 23;
        }

        private void cbKisiSayisi_MouseLeave(object sender, EventArgs e)
        {
            cbKisiSayisi.Width = 23;
        }

        private void cbKisiSayisi_MouseEnter(object sender, EventArgs e)
        {
            cbKisiSayisi.Width = 100;
        }

        private void btnSiparisKontrol_Click(object sender, EventArgs e)
        {
            FormSiparisKontrol frm = new FormSiparisKontrol();
            this.Close();
            frm.Show();
        }

        private void btnYeniMüsteri_Click(object sender, EventArgs e)
        {
            FormMusteriEkleme frm = new FormMusteriEkleme();
            ClassGenel._musteriEkleme = 0;
            this.Close();
            frm.Show();
        }

        private void btnMüsteriGüncelle_Click(object sender, EventArgs e)
        {
            if (lvMüsteriler.SelectedItems.Count>0)
            {
                FormMusteriEkleme frm = new FormMusteriEkleme();
                ClassGenel._musteriEkleme = 0;
                ClassGenel._musteriId = Convert.ToInt32(lvMüsteriler.SelectedItems[0].SubItems[0].Text);

                this.Close();
                frm.Show();
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
    }
}
