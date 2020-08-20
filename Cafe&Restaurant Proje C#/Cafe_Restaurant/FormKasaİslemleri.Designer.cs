namespace Cafe_Restaurant
{
    partial class FormKasaİslemleri
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new Cafe_Restaurant.DataSet1();
            this.DataTable2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvAylik = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnAylikRapor = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rpvGunluk = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataTable1TableAdapter = new Cafe_Restaurant.DataSet1TableAdapters.DataTable1TableAdapter();
            this.DataTable2TableAdapter = new Cafe_Restaurant.DataSet1TableAdapters.DataTable2TableAdapter();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnGeriMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DataTable2BindingSource
            // 
            this.DataTable2BindingSource.DataMember = "DataTable2";
            this.DataTable2BindingSource.DataSource = this.DataSet1;
            // 
            // rpvAylik
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DataTable1BindingSource;
            this.rpvAylik.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvAylik.LocalReport.ReportEmbeddedResource = "Cafe_Restaurant.Report3.rdlc";
            this.rpvAylik.Location = new System.Drawing.Point(22, 81);
            this.rpvAylik.Name = "rpvAylik";
            this.rpvAylik.ServerReport.BearerToken = null;
            this.rpvAylik.Size = new System.Drawing.Size(1077, 607);
            this.rpvAylik.TabIndex = 0;
            // 
            // btnAylikRapor
            // 
            this.btnAylikRapor.Location = new System.Drawing.Point(1122, 81);
            this.btnAylikRapor.Name = "btnAylikRapor";
            this.btnAylikRapor.Size = new System.Drawing.Size(267, 156);
            this.btnAylikRapor.TabIndex = 1;
            this.btnAylikRapor.Text = "AYLIK RAPOR";
            this.btnAylikRapor.UseVisualStyleBackColor = true;
            this.btnAylikRapor.Click += new System.EventHandler(this.btnAylikRapor_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1122, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(267, 156);
            this.button1.TabIndex = 2;
            this.button1.Text = "Z RAPORU";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(472, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "AYLIK RAPOR";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rpvGunluk
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.DataTable2BindingSource;
            this.rpvGunluk.LocalReport.DataSources.Add(reportDataSource2);
            this.rpvGunluk.LocalReport.ReportEmbeddedResource = "Cafe_Restaurant.Report2.rdlc";
            this.rpvGunluk.Location = new System.Drawing.Point(39, 81);
            this.rpvGunluk.Name = "rpvGunluk";
            this.rpvGunluk.ServerReport.BearerToken = null;
            this.rpvGunluk.Size = new System.Drawing.Size(1077, 607);
            this.rpvGunluk.TabIndex = 4;
            // 
            // DataTable1TableAdapter
            // 
            this.DataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // DataTable2TableAdapter
            // 
            this.DataTable2TableAdapter.ClearBeforeFill = true;
            // 
            // btnCikis
            // 
            this.btnCikis.BackgroundImage = global::Cafe_Restaurant.Properties.Resources.çıkış2;
            this.btnCikis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCikis.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCikis.ForeColor = System.Drawing.Color.White;
            this.btnCikis.Location = new System.Drawing.Point(1294, 758);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(95, 80);
            this.btnCikis.TabIndex = 15;
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
            this.btnGeriMenu.Location = new System.Drawing.Point(1128, 758);
            this.btnGeriMenu.Name = "btnGeriMenu";
            this.btnGeriMenu.Size = new System.Drawing.Size(160, 80);
            this.btnGeriMenu.TabIndex = 14;
            this.btnGeriMenu.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGeriMenu.UseVisualStyleBackColor = true;
            this.btnGeriMenu.Click += new System.EventHandler(this.btnGeriMenu_Click);
            // 
            // FormKasaİslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Cafe_Restaurant.Properties.Resources.image17;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1400, 850);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnGeriMenu);
            this.Controls.Add(this.rpvGunluk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rpvAylik);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAylikRapor);
            this.Font = new System.Drawing.Font("Bahnschrift", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormKasaİslemleri";
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormKasaİslemleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable2BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvAylik;
        private System.Windows.Forms.Button btnAylikRapor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.DataTable1TableAdapter DataTable1TableAdapter;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer rpvGunluk;
        private System.Windows.Forms.BindingSource DataTable2BindingSource;
        private DataSet1TableAdapters.DataTable2TableAdapter DataTable2TableAdapter;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnGeriMenu;
    }
}