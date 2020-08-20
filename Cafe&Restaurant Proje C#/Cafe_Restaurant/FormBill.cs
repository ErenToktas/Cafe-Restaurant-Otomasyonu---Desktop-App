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
    public partial class FormBill : Form
    {
        public FormBill()
        {
            InitializeComponent();
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

        private void label5_Click(object sender, EventArgs e)
        {

        }
        ClassSiparis cs = new ClassSiparis();
        int odemeTuru = 0;
        private void FormBill_Load(object sender, EventArgs e)
        {
            gbİndirim.Visible = false;
            if (chkİndirim.Checked)
            
                gbİndirim.Visible = false;
            
            else
            
                gbİndirim.Visible = true;
            
            
            if (ClassGenel._ServisTurNo == 1)
            {
                lblAdisyonId.Text = ClassGenel._AdisyonId;
                txtİndirimTutari.TextChanged += new EventHandler(txtİndirimTutari_TextChanged);
                cs.getByOrder(lvUrunler, Convert.ToInt32(lblAdisyonId.Text));
                if (lvUrunler.Items.Count > 0)
                {
                    decimal toplam = 0;
                    for (int i = 0; i < lvUrunler.Items.Count; i++)
                    {
                        toplam += Convert.ToDecimal(lvUrunler.Items[i].SubItems[3].Text);
                    }
                    lblToplamTutar.Text = string.Format("{0:0.000}", toplam);
                    lblOdenecek.Text = string.Format("{0:0.000}", toplam);
                    decimal kdv = Convert.ToDecimal(lblOdenecek.Text) * 18 / 100;
                    lblKdv.Text = string.Format("{0:0.000}", kdv);
                }
                if (chkİndirim.Checked)

                    gbİndirim.Visible = false;

                else

                    gbİndirim.Visible = true;

                txtİndirimTutari.Clear();
            }
            else if (ClassGenel._ServisTurNo == 2)
            {
                lblAdisyonId.Text = ClassGenel._AdisyonId;
                ClassPaketler pc = new ClassPaketler();
                odemeTuru = pc.OdemeTurIdGetir(Convert.ToInt32(lblAdisyonId.Text));
                txtİndirimTutari.TextChanged += new EventHandler(txtİndirimTutari_TextChanged);
                cs.getByOrder(lvUrunler, Convert.ToInt32(lblAdisyonId.Text));

                if (odemeTuru == 1)
                {
                    rbKrediKart.Checked = true;
                }
                else if (odemeTuru == 2)
                {
                    rbNakit.Checked = true;
                }
                else if (odemeTuru == 3)
                {
                    rbTicket.Checked = true;
                }

                if (lvUrunler.Items.Count > 0)
                {
                    decimal toplam = 0;
                    for (int i = 0; i < lvUrunler.Items.Count; i++)
                    {
                        toplam += Convert.ToDecimal(lvUrunler.Items[i].SubItems[3].Text);
                    }
                    lblToplamTutar.Text = string.Format("{0:0.000}", toplam);
                    lblOdenecek.Text = string.Format("{0:0.000}", toplam);
                    decimal kdv = Convert.ToDecimal(lblOdenecek.Text) * 18 / 100;
                    lblKdv.Text = string.Format("{0:0.000}", kdv);
                }
                if (chkİndirim.Checked)

                    gbİndirim.Visible = false;

                else

                    gbİndirim.Visible = true;

                txtİndirimTutari.Clear();
            }
        }

        private void txtİndirimTutari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtİndirimTutari.Text) < Convert.ToDecimal(lblToplamTutar.Text))
                {
                    try
                    {
                        lblİndirim.Text = string.Format("{0:0.000}", Convert.ToDecimal(txtİndirimTutari.Text));
                    }
                    catch (Exception)
                    {

                        lblİndirim.Text = string.Format("{0:0.000}", 0);
                    }
                }
                else
                {
                    MessageBox.Show("İndirim Tutarı Toplam Tutardan Fazla Olamaz !!!");
                }
            }
            catch (Exception)
            {

                lblİndirim.Text = string.Format("{0:0.000}", 0);
            }
        }

        private void chkİndirim_CheckedChanged(object sender, EventArgs e)
        {
            if (chkİndirim.Checked)
            {
                gbİndirim.Visible = true;
                txtİndirimTutari.Clear();
            }
            else
            {
                gbİndirim.Visible = false;
                txtİndirimTutari.Clear();
            }
        }

        private void lblİndirim_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(lblİndirim.Text)>0)
            {
                decimal odenecek = 0;
                lblOdenecek.Text = lblToplamTutar.Text;
                odenecek = Convert.ToDecimal(lblOdenecek.Text) - Convert.ToDecimal(lblİndirim.Text);
                lblOdenecek.Text = string.Format("{0:0.000}", odenecek);
            }

            decimal kdv = Convert.ToDecimal(lblOdenecek.Text)*18/100;
            lblKdv.Text = string.Format("{0:0.000}", kdv);

        }

        ClassMasalar masalar = new ClassMasalar();
        ClassRezervasyon rezerve = new ClassRezervasyon();

        private void btnHesapKapat_Click(object sender, EventArgs e)
        {
            if (ClassGenel._ServisTurNo == 1)
            {
                int masaid = masalar.TableGetbyNumber(ClassGenel._ButtonName);
                int musteriId = 0;

                if (masalar.TableGetbyState(masaid,4)==true)
                {
                    musteriId = rezerve.getByClientIdFromRezervasyon(masaid);

                }
                else
                {
                    musteriId = 1;
                }

                int odemeTurId = 0;
                if (rbNakit.Checked)
                {
                    odemeTurId = 1;
                }
                if (rbKrediKart.Checked)
                {
                    odemeTurId = 2;
                }
                if (rbTicket.Checked)
                {
                    odemeTurId = 3;
                }
                ClassOdeme odeme = new ClassOdeme();

                odeme.AdisyonID = Convert.ToInt32(lblAdisyonId.Text);
                odeme.OdemeTurId = odemeTurId;
                odeme.MusteriId = musteriId;
                odeme.AraToplam = Convert.ToDecimal(lblOdenecek.Text);
                odeme.Kdvtutari = Convert.ToDecimal(lblKdv.Text);
                odeme.GenelToplam = Convert.ToDecimal(lblToplamTutar.Text);
                odeme.Inidirm = Convert.ToDecimal(lblİndirim.Text);

                bool result = odeme.billClose(odeme);
                if (result)
                {
                    MessageBox.Show("Hesap Kapatılmıştır.");
                    masalar.setChangeTableState(Convert.ToString(masaid), 1);


                    ClassRezervasyon c = new ClassRezervasyon();
                    c.rezervationClose(Convert.ToInt32(lblAdisyonId.Text));

                    ClassAdisyon a = new ClassAdisyon();
                    a.adisyonkapat(Convert.ToInt32(lblAdisyonId.Text), 0);

                    

                    this.Close();
                    FormMasa frm = new FormMasa();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Hesap Kapatılırken Bir Sorunla Karşılaşıldı. Lütfen Bir Yetkiliye Bildiriniz...");
                }
            }// Paket Sipariş
            else if (ClassGenel._ServisTurNo == 2)
            {
                ClassOdeme odeme = new ClassOdeme();

                odeme.AdisyonID = Convert.ToInt32(lblAdisyonId.Text);
                odeme.OdemeTurId = odemeTuru;
                odeme.MusteriId = 1; // paket siparis ıd
                odeme.AraToplam = Convert.ToDecimal(lblOdenecek.Text);
                odeme.Kdvtutari = Convert.ToDecimal(lblKdv.Text);
                odeme.GenelToplam = Convert.ToDecimal(lblToplamTutar.Text);
                odeme.Inidirm = Convert.ToDecimal(lblİndirim.Text);

                bool result = odeme.billClose(odeme);
                if (result)
                {
                    

                    ClassAdisyon a = new ClassAdisyon();
                    a.adisyonkapat(Convert.ToInt32(lblAdisyonId.Text), 1);

                    
                    ClassPaketler p = new ClassPaketler();
                    p.OrderServiceClose(Convert.ToInt32(lblAdisyonId.Text));

                    MessageBox.Show("Hesap Kapatılmıştır.");

                    this.Close();
                    FormMasa frm = new FormMasa();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Hesap Kapatılırken Bir Sorunla Karşılaşıldı. Lütfen Bir Yetkiliye Bildiriniz...");
                }
            }
        }

        private void btnHesapOzeti_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        Font Baslik = new Font("Verdana", 15, FontStyle.Bold);
        Font altBaslik = new Font("Verdana", 12, FontStyle.Regular);
        Font İcerik = new Font("Verdana", 10);
        SolidBrush sb = new SolidBrush(Color.Black);

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat st = new StringFormat();
            st.Alignment = StringAlignment.Near;
            e.Graphics.DrawString("Cafe&Restaurant", Baslik, sb, 350, 100, st);
            e.Graphics.DrawString("-------------------------------", altBaslik, sb, 350, 100, st);
            e.Graphics.DrawString("Ürün Adı                Adet          Fiyat", altBaslik, sb, 150, 250, st);
            e.Graphics.DrawString("---------------------------------------------------", altBaslik, sb, 150, 280, st);
            for (int i = 0; i < lvUrunler.Items.Count; i++)
            {
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[0].Text, İcerik, sb, 150, 300 + i * 30, st);
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[1].Text, İcerik, sb, 350, 300 + i * 30, st);
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[3].Text, İcerik, sb, 420, 300 + i * 30, st);
            }
            e.Graphics.DrawString("---------------------------------------------------", altBaslik, sb, 150, 300 + 30 * lvUrunler.Items.Count, st);
            e.Graphics.DrawString("İndirim Tutarı    :----------------" + lblİndirim.Text + " TL", altBaslik, sb, 250, 300 + 30 * (lvUrunler.Items.Count + 1), st);
            e.Graphics.DrawString("KDV Tutarı        :----------------" + lblKdv.Text + " TL", altBaslik, sb, 250, 300 + 30 * (lvUrunler.Items.Count + 2), st);
            e.Graphics.DrawString("Toplam Tutar      :----------------" + lblToplamTutar.Text + " TL", altBaslik, sb, 250, 300 + 30 * (lvUrunler.Items.Count + 3), st);
            e.Graphics.DrawString("Ödediğiniz Tutarı :----------------" + lblİndirim.Text + " TL", altBaslik, sb, 250, 300 + 30 * (lvUrunler.Items.Count + 4), st);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
