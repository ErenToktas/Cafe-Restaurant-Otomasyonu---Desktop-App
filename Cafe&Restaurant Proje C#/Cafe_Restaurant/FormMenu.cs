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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            
        }

        private void btnMasaSiparis_Click(object sender, EventArgs e)
        {
            FormMasa frm = new FormMasa();
            this.Close();
            frm.Show();
        }

        private void btnRezervasyon_Click_1(object sender, EventArgs e)
        {
            FormRezervasyon frm = new FormRezervasyon();
            this.Close();
            frm.Show();
        }


        private void btnMusteriler_Click(object sender, EventArgs e)
        {
            FormMusteriAra frm = new FormMusteriAra();
            this.Close();
            frm.Show();
        }

        private void btnKasaİslemleri_Click(object sender, EventArgs e)
        {
            FormKasaİslemleri frm = new FormKasaİslemleri();
            this.Close();
            frm.Show();
        }

        private void btnMutfak_Click(object sender, EventArgs e)
        {
            FormMutfak frm = new FormMutfak();
            this.Close();
            frm.Show();
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            FormRaporlar frm = new FormRaporlar();
            this.Close();
            frm.Show();
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            FormAyarlar frm = new FormAyarlar();
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


        private void FormMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
