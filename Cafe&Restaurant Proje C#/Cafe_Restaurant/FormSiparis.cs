using System;
using System.Collections;
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
    public partial class FormSiparis : Form
    {
        public FormSiparis()
        {
            InitializeComponent();
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
            FormMasa frm = new FormMasa();
            this.Close();
            frm.Show();
        }

        //Hesap işlemi
        void islem(Object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Name)
            {
                case "btn1":
                    txtbxAdet.Text += (1).ToString();
                    break;
                case "btn2":
                    txtbxAdet.Text += (2).ToString();
                    break;
                case "btn3":
                    txtbxAdet.Text += (3).ToString();
                    break;
                case "btn4":
                    txtbxAdet.Text += (4).ToString();
                    break;
                case "btn5":
                    txtbxAdet.Text += (5).ToString();
                    break;
                case "btn6":
                    txtbxAdet.Text += (6).ToString();
                    break;
                case "btn7":
                    txtbxAdet.Text += (7).ToString();
                    break;
                case "btn8":
                    txtbxAdet.Text += (8).ToString();
                    break;
                case "btn9":
                    txtbxAdet.Text += (9).ToString();
                    break;
                case "btn0":
                    txtbxAdet.Text += (0).ToString();
                    break;

                default:
                    MessageBox.Show("Sayı Gir");
                    break;
            }

        }
        int tableId; int AdditionId;
        private void FormSiparis_Load(object sender, EventArgs e)
        {
            lblMasaNo.Text = ClassGenel._ButtonValue;

            ClassMasalar ms = new ClassMasalar();
            tableId = ms.TableGetbyNumber(ClassGenel._ButtonName);
            if (ms.TableGetbyState(tableId,2)==true || ms.TableGetbyState(tableId, 4) == true)
            {
                ClassAdisyon Ad = new ClassAdisyon();
                AdditionId = Ad.getByAddition(tableId);
                ClassSiparis orders = new ClassSiparis();
                orders.getByOrder(lvSiparisler, AdditionId);
            }

            btn1.Click += new EventHandler(islem);
            btn2.Click += new EventHandler(islem);
            btn3.Click += new EventHandler(islem);
            btn4.Click += new EventHandler(islem);
            btn5.Click += new EventHandler(islem);
            btn6.Click += new EventHandler(islem);
            btn7.Click += new EventHandler(islem);
            btn8.Click += new EventHandler(islem);
            btn9.Click += new EventHandler(islem);
            btn0.Click += new EventHandler(islem);
        }

        ClassUrunCesitleri Uc = new ClassUrunCesitleri();
        private void btnAnaYemek3_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnAnaYemek3);
        }

        private void btnİcecekler8_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnİcecekler8);
        }

        private void btnTatlilar7_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnTatlilar7);
        }

        private void btnSalata6_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnSalata6);
        }

        private void btnFastFood5_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnFastFood5);
        }

        private void btnCorba1_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnCorba1);
        }

        private void btnMakarnalar4_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnMakarnalar4);
        }

        private void btnAraSicak2_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnAraSicak2);
        }
        int sayac = 0; int sayac2 = 0;
        private void lvMenu_DoubleClick(object sender, EventArgs e)
        {
            if (txtbxAdet.Text=="")
            {
                txtbxAdet.Text = "1";
            }
            if (lvMenu.Items.Count>0)
            {
                sayac = lvSiparisler.Items.Count;
                lvSiparisler.Items.Add(lvMenu.SelectedItems[0].Text);
                lvSiparisler.Items[sayac].SubItems.Add(txtbxAdet.Text);
                lvSiparisler.Items[sayac].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lvSiparisler.Items[sayac].SubItems.Add((Convert.ToDecimal(lvMenu.SelectedItems[0].SubItems[1].Text) * Convert.ToDecimal(txtbxAdet.Text)).ToString());
                lvSiparisler.Items[sayac].SubItems.Add("0");
                sayac2 = lvYeniEklenenler.Items.Count;
                lvSiparisler.Items[sayac].SubItems.Add(sayac2.ToString());


                lvYeniEklenenler.Items.Add(AdditionId.ToString());
                lvYeniEklenenler.Items[sayac2].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lvYeniEklenenler.Items[sayac2].SubItems.Add(txtbxAdet.Text);
                lvYeniEklenenler.Items[sayac2].SubItems.Add(tableId.ToString());
                lvYeniEklenenler.Items[sayac2].SubItems.Add(sayac2.ToString());

                sayac2++;
                txtbxAdet.Text = "";

            }
        }

        ArrayList silinenler = new ArrayList();

        private void btnSiparis_Click(object sender, EventArgs e)
        {
            // 1-Masa Boş
            // 2-Masa Dolu
            // 3-Masa Rezerve
            // 4-Dolu Rezerve

            FormMasa ms = new FormMasa();
            ClassMasalar masa = new ClassMasalar();
            ClassAdisyon newAddition = new ClassAdisyon();
            ClassSiparis saveOrder = new ClassSiparis();


            bool sonuc = false;

            if (masa.TableGetbyState(tableId, 1) == true)
            {
                newAddition.ServisTurNo = 1;
                
                newAddition.PersonelId = 1;
                newAddition.MasaId = tableId;
                newAddition.Tarih = DateTime.Now;
                sonuc = newAddition.setByAdditionNew(newAddition);
                masa.setChangeTableState(ClassGenel._ButtonName, 2);

                if (lvSiparisler.Items.Count > 0)
                {
                    for (int i = 0; i < lvSiparisler.Items.Count; i++)
                    {
                        saveOrder.MasaId = tableId;
                        saveOrder.UrunId = Convert.ToInt32(lvSiparisler.Items[i].SubItems[2].Text);
                        saveOrder.AdisyonID = newAddition.getByAddition(tableId);
                        saveOrder.Adet = Convert.ToInt32(lvSiparisler.Items[i].SubItems[1].Text);
                        saveOrder.setSaveOrder(saveOrder);
                    }
                    this.Close();
                    ms.Show();

                }
            }
            else if (masa.TableGetbyState(tableId, 2) == true || masa.TableGetbyState(tableId, 4) == true)
            {
               
                if (lvYeniEklenenler.Items.Count > 0)
                {
                    for (int i = 0; i < lvYeniEklenenler.Items.Count; i++)
                    {

                        saveOrder.MasaId = tableId;
                        saveOrder.UrunId = Convert.ToInt32(lvYeniEklenenler.Items[i].SubItems[1].Text);
                        saveOrder.AdisyonID = newAddition.getByAddition(tableId);
                        saveOrder.Adet = Convert.ToInt32(lvYeniEklenenler.Items[i].SubItems[2].Text);
                        saveOrder.setSaveOrder(saveOrder);

                    }
                    ClassGenel._AdisyonId = Convert.ToString(newAddition.getByAddition(tableId));

                }
                if (silinenler.Count > 0)
                {
                    foreach (string item in silinenler)
                    {
                        saveOrder.setDeleteOrder(Convert.ToInt32(item));
                    }
                }

                this.Close();
                ms.Show();
            }
            else if (masa.TableGetbyState(tableId, 3) == true)
            {
                
                //newAddition.ServisTurNo = 1;
                //newAddition.PersonelId = 1;
                //newAddition.MasaId = tableId;
                //newAddition.Tarih = DateTime.Now;
                //sonuc = newAddition.setByAdditionNew(newAddition);
                masa.setChangeTableState(ClassGenel._ButtonName, 4);

                if (lvSiparisler.Items.Count > 0)
                {
                    for (int i = 0; i < lvSiparisler.Items.Count; i++)
                    {
                        saveOrder.MasaId = tableId;
                        saveOrder.UrunId = Convert.ToInt32(lvSiparisler.Items[i].SubItems[2].Text);
                        saveOrder.AdisyonID = newAddition.getByAddition(tableId);
                        saveOrder.Adet = Convert.ToInt32(lvSiparisler.Items[i].SubItems[1].Text);
                        saveOrder.setSaveOrder(saveOrder);
                    }
                    this.Close();
                    ms.Show();
                }
            }
        }

        private void lvSiparisler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSiparisler.Items.Count < 0)
            {
                if (lvSiparisler.SelectedItems[0].SubItems[4].Text != "0")
                {
                    ClassSiparis saveOrder = new ClassSiparis();
                    saveOrder.setDeleteOrder(Convert.ToInt32(lvSiparisler.Items[0].SubItems[4].Text));
                }
                else
                {
                    for (int i = 0; i < lvYeniEklenenler.Items.Count; i++)
                    {
                        if (lvYeniEklenenler.Items[i].SubItems[4].Text == lvSiparisler.SelectedItems[0].SubItems[5].Text)
                        {
                            lvYeniEklenenler.Items.RemoveAt(i);
                        }
                    }
                }
                lvSiparisler.Items.RemoveAt(lvSiparisler.SelectedItems[0].Index);

            }
        }

        private void lvSiparisler_DoubleClick(object sender, EventArgs e)
        {
            if (lvSiparisler.Items.Count > 0)
            {
                if (lvSiparisler.SelectedItems[0].SubItems[4].Text != "0")
                {
                    ClassSiparis saveOrder = new ClassSiparis();
                    saveOrder.setDeleteOrder(Convert.ToInt32(lvSiparisler.SelectedItems[0].SubItems[4].Text));
                }
                else
                {
                    for (int i = 0; i < lvYeniEklenenler.Items.Count; i++)
                    {
                        if (lvYeniEklenenler.Items[i].SubItems[4].Text == lvSiparisler.SelectedItems[0].SubItems[5].Text)
                        {
                            lvYeniEklenenler.Items.RemoveAt(i);
                        }
                    }
                }
                lvSiparisler.Items.RemoveAt(lvSiparisler.SelectedItems[0].Index);
            }
        }

        private void txtbxAra_TextChanged(object sender, EventArgs e)
        {
            if (txtbxAra.Text=="")
            {
                txtbxAra.Text = "" ;

            }
            else
            {
                ClassUrunCesitleri cu = new ClassUrunCesitleri();
                cu.getByProductSearch(lvMenu, Convert.ToInt32(txtbxAra.Text));
            }
            
            
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            ClassGenel._ServisTurNo = 1;
            ClassGenel._AdisyonId = AdditionId.ToString();
            FormBill frm = new FormBill();
            this.Close();
            frm.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
