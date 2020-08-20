using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_Restaurant
{
    public partial class FormMasa : Form
    {
        public FormMasa()
        {
            InitializeComponent();
        }

        private void btnMasa1_Click(object sender, EventArgs e)
        {
            FormSiparis frm = new FormSiparis(); 
            int uzunluk = btnMasa1.Text.Length; 

            ClassGenel._ButtonValue = btnMasa1.Text.Substring(uzunluk - 6, 6);
            ClassGenel._ButtonName = btnMasa1.Name;
            this.Close();
            frm.ShowDialog();

        }

        private void btnMasa2_Click(object sender, EventArgs e)
        {
            FormSiparis frm = new FormSiparis();
            int uzunluk = btnMasa2.Text.Length;

            ClassGenel._ButtonValue = btnMasa2.Text.Substring(uzunluk - 6, 6);
            ClassGenel._ButtonName = btnMasa2.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa3_Click(object sender, EventArgs e)
        {
            FormSiparis frm = new FormSiparis();
            int uzunluk = btnMasa3.Text.Length;

            ClassGenel._ButtonValue = btnMasa3.Text.Substring(uzunluk - 6, 6);
            ClassGenel._ButtonName = btnMasa3.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa4_Click(object sender, EventArgs e)
        {
            FormSiparis frm = new FormSiparis();
            int uzunluk = btnMasa4.Text.Length;

            ClassGenel._ButtonValue = btnMasa4.Text.Substring(uzunluk - 6, 6);
            ClassGenel._ButtonName = btnMasa4.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa5_Click(object sender, EventArgs e)
        {
            FormSiparis frm = new FormSiparis();
            int uzunluk = btnMasa5.Text.Length;

            ClassGenel._ButtonValue = btnMasa5.Text.Substring(uzunluk - 6, 6);
            ClassGenel._ButtonName = btnMasa5.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa6_Click(object sender, EventArgs e)
        {
            FormSiparis frm = new FormSiparis();
            int uzunluk = btnMasa6.Text.Length;

            ClassGenel._ButtonValue = btnMasa6.Text.Substring(uzunluk - 6, 6);
            ClassGenel._ButtonName = btnMasa6.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa7_Click(object sender, EventArgs e)
        {
            FormSiparis frm = new FormSiparis();
            int uzunluk = btnMasa7.Text.Length;

            ClassGenel._ButtonValue = btnMasa7.Text.Substring(uzunluk - 6, 6);
            ClassGenel._ButtonName = btnMasa7.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa8_Click(object sender, EventArgs e)
        {
            FormSiparis frm = new FormSiparis();
            int uzunluk = btnMasa8.Text.Length;

            ClassGenel._ButtonValue = btnMasa8.Text.Substring(uzunluk - 6, 6);
            ClassGenel._ButtonName = btnMasa8.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa9_Click(object sender, EventArgs e)
        {
            FormSiparis frm = new FormSiparis();
            int uzunluk = btnMasa9.Text.Length;

            ClassGenel._ButtonValue = btnMasa9.Text.Substring(uzunluk - 6, 6);
            ClassGenel._ButtonName = btnMasa9.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa10_Click(object sender, EventArgs e)
        {
            FormSiparis frm = new FormSiparis();
            int uzunluk = btnMasa10.Text.Length;

            ClassGenel._ButtonValue = btnMasa10.Text.Substring(uzunluk - 6, 6);
            ClassGenel._ButtonName = btnMasa10.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa11_Click(object sender, EventArgs e)
        {
            FormSiparis frm = new FormSiparis();
            int uzunluk = btnMasa11.Text.Length;

            ClassGenel._ButtonValue = btnMasa11.Text.Substring(uzunluk - 6, 6);
            ClassGenel._ButtonName = btnMasa11.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa12_Click(object sender, EventArgs e)
        {
            FormSiparis frm = new FormSiparis();
            int uzunluk = btnMasa12.Text.Length;

            ClassGenel._ButtonValue = btnMasa12.Text.Substring(uzunluk - 6, 6);
            ClassGenel._ButtonName = btnMasa12.Name;
            this.Close();
            frm.ShowDialog();
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
        
        private void FormMasa_Load(object sender, EventArgs e)
        {
            ClassGenel gnl = new ClassGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select DURUM,ID from MASA", con);
            SqlDataReader dr = null;
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                foreach (Control item in this.Controls)
                {
                    if (item is Button)
                    {
                        if (item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "1") // Gelen masa ve durum 1 ise
                        {
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.bos);  // boş masa varsa background yükle
                        }
                        else if (item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "2")
                        {
                            ClassMasalar ms = new ClassMasalar();
                            DateTime dt1 = Convert.ToDateTime(ms.SessionSum(2,dr["ID"].ToString()));
                            DateTime dt2 = DateTime.Now;

                            string str1 = Convert.ToDateTime(ms.SessionSum(2, dr["ID"].ToString())).ToShortTimeString();
                            string str2 = DateTime.Now.ToShortTimeString();

                            DateTime t1 = dt1.AddMinutes(DateTime.Parse(str1).TimeOfDay.TotalMinutes);
                            DateTime t2 = dt2.AddMinutes(DateTime.Parse(str2).TimeOfDay.TotalMinutes);

                            var fark = t2 - t1;

                            item.Text = String.Format("{0}{1}{2}",
                                fark.Days > 0 ? string.Format("{0} gün", fark.Days) : "",
                                fark.Hours > 0 ? string.Format("{0} saat", fark.Hours) : "",
                                fark.Minutes > 0 ? string.Format("{0} dakika", fark.Minutes) : "").Trim() + "\n\n\nMasa" + dr["ID"].ToString();

                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.dolu);
                        }
                        else if (item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "3")
                        {
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.AcikRezerve);
                        }
                        else if (item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "4")
                        {
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.rezerve);
                        }
                    }
                }
            }
        }
    }
}
