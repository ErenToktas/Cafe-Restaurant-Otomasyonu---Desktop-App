namespace Cafe_Restaurant
{
    partial class FormRezervasyon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTarih = new System.Windows.Forms.TextBox();
            this.txtMasa = new System.Windows.Forms.TextBox();
            this.txtKisiSayisi = new System.Windows.Forms.TextBox();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.dtTarih = new System.Windows.Forms.DateTimePicker();
            this.cbMasa = new System.Windows.Forms.ComboBox();
            this.cbKisiSayisi = new System.Windows.Forms.ComboBox();
            this.txtMasaNo = new System.Windows.Forms.TextBox();
            this.txtMusteriAd = new System.Windows.Forms.TextBox();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lvMüsteriler = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnYeniMüsteri = new System.Windows.Forms.Button();
            this.btnMüsteriSec = new System.Windows.Forms.Button();
            this.btnSiparisKontrol = new System.Windows.Forms.Button();
            this.btnMüsteriGüncelle = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnGeriMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(79, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tarih :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(29, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Masa Seç :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(23, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Kişi Sayısı :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(31, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "Açıklama :";
            // 
            // txtTarih
            // 
            this.txtTarih.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTarih.Location = new System.Drawing.Point(194, 67);
            this.txtTarih.Name = "txtTarih";
            this.txtTarih.Size = new System.Drawing.Size(219, 28);
            this.txtTarih.TabIndex = 1;
            // 
            // txtMasa
            // 
            this.txtMasa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMasa.Location = new System.Drawing.Point(194, 112);
            this.txtMasa.Name = "txtMasa";
            this.txtMasa.Size = new System.Drawing.Size(219, 28);
            this.txtMasa.TabIndex = 1;
            // 
            // txtKisiSayisi
            // 
            this.txtKisiSayisi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKisiSayisi.Location = new System.Drawing.Point(194, 159);
            this.txtKisiSayisi.Name = "txtKisiSayisi";
            this.txtKisiSayisi.Size = new System.Drawing.Size(219, 28);
            this.txtKisiSayisi.TabIndex = 1;
            // 
            // txtAciklama
            // 
            this.txtAciklama.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAciklama.Location = new System.Drawing.Point(194, 208);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(219, 249);
            this.txtAciklama.TabIndex = 1;
            // 
            // dtTarih
            // 
            this.dtTarih.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtTarih.Location = new System.Drawing.Point(430, 67);
            this.dtTarih.Name = "dtTarih";
            this.dtTarih.Size = new System.Drawing.Size(21, 35);
            this.dtTarih.TabIndex = 2;
            this.dtTarih.ValueChanged += new System.EventHandler(this.dtTarih_ValueChanged);
            this.dtTarih.Enter += new System.EventHandler(this.dtTarih_Enter);
            this.dtTarih.MouseEnter += new System.EventHandler(this.dtTarih_MouseEnter);
            this.dtTarih.MouseLeave += new System.EventHandler(this.dtTarih_MouseLeave);
            // 
            // cbMasa
            // 
            this.cbMasa.FormattingEnabled = true;
            this.cbMasa.Location = new System.Drawing.Point(430, 112);
            this.cbMasa.Name = "cbMasa";
            this.cbMasa.Size = new System.Drawing.Size(21, 36);
            this.cbMasa.TabIndex = 3;
            this.cbMasa.SelectedIndexChanged += new System.EventHandler(this.cbMasa_SelectedIndexChanged);
            this.cbMasa.MouseEnter += new System.EventHandler(this.cbMasa_MouseEnter);
            this.cbMasa.MouseLeave += new System.EventHandler(this.cbMasa_MouseLeave);
            // 
            // cbKisiSayisi
            // 
            this.cbKisiSayisi.FormattingEnabled = true;
            this.cbKisiSayisi.Location = new System.Drawing.Point(430, 159);
            this.cbKisiSayisi.Name = "cbKisiSayisi";
            this.cbKisiSayisi.Size = new System.Drawing.Size(21, 36);
            this.cbKisiSayisi.TabIndex = 3;
            this.cbKisiSayisi.SelectedIndexChanged += new System.EventHandler(this.cbKisiSayisi_SelectedIndexChanged);
            this.cbKisiSayisi.MouseEnter += new System.EventHandler(this.cbKisiSayisi_MouseEnter);
            this.cbKisiSayisi.MouseLeave += new System.EventHandler(this.cbKisiSayisi_MouseLeave);
            // 
            // txtMasaNo
            // 
            this.txtMasaNo.Location = new System.Drawing.Point(469, 113);
            this.txtMasaNo.Name = "txtMasaNo";
            this.txtMasaNo.ReadOnly = true;
            this.txtMasaNo.Size = new System.Drawing.Size(21, 35);
            this.txtMasaNo.TabIndex = 1;
            this.txtMasaNo.Visible = false;
            // 
            // txtMusteriAd
            // 
            this.txtMusteriAd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMusteriAd.Location = new System.Drawing.Point(638, 67);
            this.txtMusteriAd.Multiline = true;
            this.txtMusteriAd.Name = "txtMusteriAd";
            this.txtMusteriAd.Size = new System.Drawing.Size(266, 35);
            this.txtMusteriAd.TabIndex = 1;
            this.txtMusteriAd.TextChanged += new System.EventHandler(this.txtMusteriAd_TextChanged);
            // 
            // txtTelefon
            // 
            this.txtTelefon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTelefon.Location = new System.Drawing.Point(923, 67);
            this.txtTelefon.Multiline = true;
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(266, 35);
            this.txtTelefon.TabIndex = 1;
            this.txtTelefon.TextChanged += new System.EventHandler(this.txtTelefon_TextChanged);
            // 
            // txtAdres
            // 
            this.txtAdres.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAdres.Location = new System.Drawing.Point(1207, 67);
            this.txtAdres.Multiline = true;
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(266, 35);
            this.txtAdres.TabIndex = 1;
            this.txtAdres.TextChanged += new System.EventHandler(this.txtAdres_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(705, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 29);
            this.label5.TabIndex = 0;
            this.label5.Text = "MÜŞTERİ :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1002, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 29);
            this.label6.TabIndex = 0;
            this.label6.Text = "TELEFON :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(1289, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 29);
            this.label7.TabIndex = 0;
            this.label7.Text = "ADRES :";
            // 
            // lvMüsteriler
            // 
            this.lvMüsteriler.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvMüsteriler.FullRowSelect = true;
            this.lvMüsteriler.GridLines = true;
            this.lvMüsteriler.HideSelection = false;
            this.lvMüsteriler.Location = new System.Drawing.Point(638, 113);
            this.lvMüsteriler.Name = "lvMüsteriler";
            this.lvMüsteriler.Size = new System.Drawing.Size(835, 344);
            this.lvMüsteriler.TabIndex = 4;
            this.lvMüsteriler.UseCompatibleStateImageBehavior = false;
            this.lvMüsteriler.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "MüşteriNo";
            this.columnHeader1.Width = 1;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "AD";
            this.columnHeader2.Width = 168;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "SOYAD";
            this.columnHeader3.Width = 162;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "TELEFON";
            this.columnHeader4.Width = 164;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ADRES";
            this.columnHeader5.Width = 199;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "EMAİL";
            this.columnHeader6.Width = 120;
            // 
            // btnYeniMüsteri
            // 
            this.btnYeniMüsteri.BackColor = System.Drawing.Color.Maroon;
            this.btnYeniMüsteri.Font = new System.Drawing.Font("Bahnschrift", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYeniMüsteri.ForeColor = System.Drawing.Color.White;
            this.btnYeniMüsteri.Location = new System.Drawing.Point(148, 556);
            this.btnYeniMüsteri.Name = "btnYeniMüsteri";
            this.btnYeniMüsteri.Size = new System.Drawing.Size(300, 140);
            this.btnYeniMüsteri.TabIndex = 5;
            this.btnYeniMüsteri.Text = "YENİ MÜŞTERİ";
            this.btnYeniMüsteri.UseVisualStyleBackColor = false;
            this.btnYeniMüsteri.Click += new System.EventHandler(this.btnYeniMüsteri_Click);
            // 
            // btnMüsteriSec
            // 
            this.btnMüsteriSec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMüsteriSec.Font = new System.Drawing.Font("Bahnschrift", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMüsteriSec.ForeColor = System.Drawing.Color.White;
            this.btnMüsteriSec.Location = new System.Drawing.Point(504, 556);
            this.btnMüsteriSec.Name = "btnMüsteriSec";
            this.btnMüsteriSec.Size = new System.Drawing.Size(300, 140);
            this.btnMüsteriSec.TabIndex = 5;
            this.btnMüsteriSec.Text = "REZERVASYON AÇ";
            this.btnMüsteriSec.UseVisualStyleBackColor = false;
            this.btnMüsteriSec.Click += new System.EventHandler(this.btnMüsteriSec_Click);
            // 
            // btnSiparisKontrol
            // 
            this.btnSiparisKontrol.BackColor = System.Drawing.Color.Red;
            this.btnSiparisKontrol.Font = new System.Drawing.Font("Bahnschrift", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSiparisKontrol.ForeColor = System.Drawing.Color.White;
            this.btnSiparisKontrol.Location = new System.Drawing.Point(853, 556);
            this.btnSiparisKontrol.Name = "btnSiparisKontrol";
            this.btnSiparisKontrol.Size = new System.Drawing.Size(300, 140);
            this.btnSiparisKontrol.TabIndex = 5;
            this.btnSiparisKontrol.Text = "REZERVASYONLAR";
            this.btnSiparisKontrol.UseVisualStyleBackColor = false;
            this.btnSiparisKontrol.Click += new System.EventHandler(this.btnSiparisKontrol_Click);
            // 
            // btnMüsteriGüncelle
            // 
            this.btnMüsteriGüncelle.BackColor = System.Drawing.Color.OrangeRed;
            this.btnMüsteriGüncelle.Font = new System.Drawing.Font("Bahnschrift", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMüsteriGüncelle.ForeColor = System.Drawing.Color.White;
            this.btnMüsteriGüncelle.Location = new System.Drawing.Point(1199, 556);
            this.btnMüsteriGüncelle.Name = "btnMüsteriGüncelle";
            this.btnMüsteriGüncelle.Size = new System.Drawing.Size(300, 140);
            this.btnMüsteriGüncelle.TabIndex = 5;
            this.btnMüsteriGüncelle.Text = "MÜŞTERİ GÜNCELLE";
            this.btnMüsteriGüncelle.UseVisualStyleBackColor = false;
            this.btnMüsteriGüncelle.Click += new System.EventHandler(this.btnMüsteriGüncelle_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.BackgroundImage = global::Cafe_Restaurant.Properties.Resources.çıkış2;
            this.btnCikis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCikis.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCikis.ForeColor = System.Drawing.Color.White;
            this.btnCikis.Location = new System.Drawing.Point(1378, 765);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(121, 85);
            this.btnCikis.TabIndex = 20;
            this.btnCikis.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnGeriMenu
            // 
            this.btnGeriMenu.BackgroundImage = global::Cafe_Restaurant.Properties.Resources.GeriTuşu_icon;
            this.btnGeriMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGeriMenu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGeriMenu.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGeriMenu.ForeColor = System.Drawing.Color.White;
            this.btnGeriMenu.Location = new System.Drawing.Point(1143, 765);
            this.btnGeriMenu.Name = "btnGeriMenu";
            this.btnGeriMenu.Size = new System.Drawing.Size(213, 85);
            this.btnGeriMenu.TabIndex = 19;
            this.btnGeriMenu.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGeriMenu.UseVisualStyleBackColor = true;
            this.btnGeriMenu.Click += new System.EventHandler(this.btnGeriMenu_Click);
            // 
            // FormRezervasyon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Cafe_Restaurant.Properties.Resources.image14;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1632, 900);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnGeriMenu);
            this.Controls.Add(this.btnMüsteriGüncelle);
            this.Controls.Add(this.btnSiparisKontrol);
            this.Controls.Add(this.btnMüsteriSec);
            this.Controls.Add(this.btnYeniMüsteri);
            this.Controls.Add(this.lvMüsteriler);
            this.Controls.Add(this.cbKisiSayisi);
            this.Controls.Add(this.cbMasa);
            this.Controls.Add(this.dtTarih);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.txtKisiSayisi);
            this.Controls.Add(this.txtMasa);
            this.Controls.Add(this.txtMasaNo);
            this.Controls.Add(this.txtAdres);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.txtMusteriAd);
            this.Controls.Add(this.txtTarih);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Bahnschrift", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormRezervasyon";
            this.Text = "FormRezervasyon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormRezervasyon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTarih;
        private System.Windows.Forms.TextBox txtMasa;
        private System.Windows.Forms.TextBox txtKisiSayisi;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.DateTimePicker dtTarih;
        private System.Windows.Forms.ComboBox cbMasa;
        private System.Windows.Forms.ComboBox cbKisiSayisi;
        private System.Windows.Forms.TextBox txtMasaNo;
        private System.Windows.Forms.TextBox txtMusteriAd;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView lvMüsteriler;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnYeniMüsteri;
        private System.Windows.Forms.Button btnMüsteriSec;
        private System.Windows.Forms.Button btnSiparisKontrol;
        private System.Windows.Forms.Button btnMüsteriGüncelle;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnGeriMenu;
    }
}