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
    public partial class FormMutfak : Form
    {
        public FormMutfak()
        {
            InitializeComponent();
        }

        private void FormMutfak_Load(object sender, EventArgs e)
        {
            ClassUrunCesitleri AnaKategori = new ClassUrunCesitleri();
            AnaKategori.urunCesitleriniGetir(cbKategoriler);
            cbKategoriler.Items.Insert(0, "Tüm Kategoriler");
            cbKategoriler.SelectedIndex = 0;

            label5.Visible = false;
            txtArama.Visible = false;

            ClassUrunler c = new ClassUrunler();
            c.urunleriListele(lvGidaListesi);


        }
        private void Temizle()
        {
            txtGidaAdi.Clear();
            txtGidaFiyatı.Clear();
            txtGidaFiyatı.Text = string.Format("{0:##0.00}",0);

            


        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {
                if (txtGidaAdi.Text.Trim()=="" || txtGidaFiyatı.Text.Trim()=="" || cbKategoriler.SelectedItem.ToString()=="Tüm Kategoriler")
                {
                    MessageBox.Show("Gıda Adı Fiyatı ve Kategori Seçilmemiştir.", "Dikkat Bilgiler Eksik",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {
                    ClassUrunler c = new ClassUrunler();
                    c.Fiyat = Convert.ToDecimal(txtGidaFiyatı.Text);
                    c.Urunad = txtGidaAdi.Text;
                    c.Aciklama = "Ürün Eklendi";
                    c.Urunturno = urunturNo;
                    int sonuc = c.urunEkle(c);
                    if (sonuc!=0)
                    {
                        MessageBox.Show("Ürün Eklenmiştir");
                        yenile();
                        Temizle();
                    }
                }
            }
            else
            {
                if (txtKategoriAd.Text.Trim()=="")
                {
                    MessageBox.Show("Lütfen bir Kategori ismi giriniz.","Dikkat Bilgiler Eksik",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {
                    ClassUrunCesitleri gida = new ClassUrunCesitleri();
                    gida.KategoriAd = txtKategoriAd.Text;
                    gida.Aciklama = txtAciklama.Text;
                    int sonuc = gida.urunKategoriEkle(gida);
                    if (sonuc!=0)
                    {
                        MessageBox.Show("Kategori Eklenmiştir");
                        yenile();
                        Temizle();
                    }
                }
            }
        }
        int urunturNo = 0;

        private void cbKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassUrunler u = new ClassUrunler();
            if (cbKategoriler.SelectedItem.ToString()=="Tüm Kategoriler")
            {
                u.urunleriListele(lvGidaListesi);
            }
            else
            {
                ClassUrunCesitleri cesit = (ClassUrunCesitleri)cbKategoriler.SelectedItem;
                urunturNo = cesit.UrunTurNo;
                u.urunleriListeleByUrunAdi(lvGidaListesi,urunturNo);
            }
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {
                if (txtGidaAdi.Text.Trim() == "" || txtGidaFiyatı.Text.Trim() == "" || cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
                {
                    MessageBox.Show("Gıda Adı Fiyatı ve Kategori Seçilmemiştir.", "Dikkat Bilgiler Eksik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ClassUrunler c = new ClassUrunler();
                    c.Fiyat = Convert.ToDecimal(txtGidaFiyatı.Text);
                    c.Urunad = txtGidaAdi.Text;
                    c.Urunid = Convert.ToInt32(txtUrunId.Text);
                    c.Urunturno = urunturNo;
                    c.Aciklama = "Ürün Güncellendi";
                    //c.Urunturno = Convert.ToInt32(txtUrunId.Text);
                    int sonuc = c.UrunGuncelle(c);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Ürün Güncellenmiştir");
                        yenile();
                        
                        Temizle();
                    }
                }
            }
            else
            {
                if (txtKategoriID.Text.Trim() == "")
                {
                    MessageBox.Show("Lütfen bir Kategori ismi seçiniz.", "Dikkat Bilgiler Eksik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ClassUrunCesitleri gida = new ClassUrunCesitleri();
                    gida.KategoriAd = txtKategoriAd.Text;
                    gida.Aciklama = txtAciklama.Text;
                    gida.UrunTurNo = Convert.ToInt32(txtKategoriID.Text);
                    int sonuc = gida.UrunKategoriGuncelle(gida);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Kategori Güncellenmiştir");
                        gida.urunCesitleriniGetir(lvKategoriler);
                        Temizle();
                    }
                }
            }
        }

        private void lvKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvKategoriler.SelectedItems.Count > 0)
            {
                txtKategoriAd.Text = lvKategoriler.SelectedItems[0].SubItems[1].Text;
                txtKategoriID.Text = lvKategoriler.SelectedItems[0].SubItems[0].Text;
                txtAciklama.Text = lvKategoriler.SelectedItems[0].SubItems[2].Text;
                //cbKategoriler.SelectedIndex = Convert.ToInt32(txtUrunId.Text);

            }
        }

        private void lvGidaListesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvGidaListesi.SelectedItems.Count>0)
            {
                txtGidaAdi.Text = lvGidaListesi.SelectedItems[0].SubItems[3].Text;
                txtGidaFiyatı.Text = lvGidaListesi.SelectedItems[0].SubItems[4].Text;
                txtUrunId.Text = lvGidaListesi.SelectedItems[0].SubItems[0].Text;
                //cbKategoriler.SelectedIndex = Convert.ToInt32(txtUrunId.Text);

            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {
                if (lvGidaListesi.SelectedItems.Count>0)
                {

                
                if (MessageBox.Show("Ürün Silmekte Emin Misiniz ?", "Dikkat Bilgiler Silinecektir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    
                        ClassUrunler c = new ClassUrunler();
                        c.Urunid = Convert.ToInt32(txtUrunId.Text);
 
                        int sonuc = c.UrunSil(c,1);
                    
                        if (sonuc != 0)
                    
                        {
                       
                            MessageBox.Show("Ürün Silinmiştir");
                            
                            cbKategoriler_SelectedIndexChanged(sender, e);
                            yenile();
                            Temizle();
                    
                        }
                }
                }
                else
                {
                    MessageBox.Show("Ürün Silmek için Bir Ürün Seçiniz.", "Dikkat, Ürün Seçmediniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                if (lvKategoriler.SelectedItems.Count>0)
                {

                
                if (MessageBox.Show("Ürün Silmekte Emin Misiniz ?", "Dikkat Bilgiler Silinecektir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                        ClassUrunCesitleri uc = new ClassUrunCesitleri();
                        uc.UrunTurNo = Convert.ToInt32(txtKategoriID.Text);

                        int sonuc = uc.UrunKategoriSil(Convert.ToInt32(txtKategoriID.Text));
                    
                        if (sonuc != 0)
                    
                        {
                        
                            MessageBox.Show("Ürün Silinmiştir");
                            ClassUrunler c = new ClassUrunler();
                            c.Urunid = Convert.ToInt32(txtKategoriID.Text);
                            c.UrunSil(c,0);
                            yenile();
                            Temizle();
                   
                        }
                
                    }
                
                }

            }
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

        private void btnBul_Click(object sender, EventArgs e)
        {
            label5.Visible = true;
            txtArama.Visible = true;
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {
                ClassUrunler u = new ClassUrunler();
                u.urunleriListeleByUrunAdi(lvGidaListesi, txtArama.Text);
            }
            else
            {
                ClassUrunCesitleri uc = new ClassUrunCesitleri();
                uc.urunCesitleriniGetir(lvKategoriler, txtArama.Text);

            }
        }

        private void rbAltKategori_CheckedChanged(object sender, EventArgs e)
        {
            panelUrun.Visible = true;
            panelAnaKategori.Visible = false;
            lvKategoriler.Visible = false;
            lvGidaListesi.Visible = true;
            yenile();
        }

        private void rbAnaKategori_CheckedChanged(object sender, EventArgs e)
        {

            panelUrun.Visible = false;
            panelAnaKategori.Visible = true;
            lvKategoriler.Visible = true;
            lvGidaListesi.Visible = false;
            yenile();
            //ClassUrunCesitleri uc = new ClassUrunCesitleri();
            //uc.urunCesitleriniGetir(lvKategoriler);
        }
        private void yenile()
        {
            ClassUrunCesitleri uc = new ClassUrunCesitleri();
            uc.urunCesitleriniGetir(cbKategoriler);
            cbKategoriler.Items.Insert(0,"Tüm Kategoriler");
            cbKategoriler.SelectedIndex = 0;
            uc.urunCesitleriniGetir(lvKategoriler);
            ClassUrunler c = new ClassUrunler();
            c.urunleriListele(lvGidaListesi);
        }
    }
}
