using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Cafe_Restaurant
{
    class ClassUrunler

    {
        ClassGenel gnl = new ClassGenel();

        private int _urunid;
        private int _urunturno;
        private string _urunad;
        private decimal _fiyat;
        private string _aciklama;

        public int Urunid { get => _urunid; set => _urunid = value; }
        public int Urunturno { get => _urunturno; set => _urunturno = value; }
        public string Urunad { get => _urunad; set => _urunad = value; }
        public decimal Fiyat { get => _fiyat; set => _fiyat = value; }
        public string Aciklama { get => _aciklama; set => _aciklama = value; }

        //Ürün adına göre listeleme
        public void urunleriListeleByUrunAdi(ListView lv, string urunadi)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select Urunler.* ,KATEGORİID from Urunler Inner join Kategoriler on " +
                "Kategoriler.ID=Urunler.KATEGORİID Where Urunler.Durum=0 and URUNADİ like '%' + @urunAdi + '%'", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@urunAdi",SqlDbType.VarChar).Value = urunadi;

            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();

                dr = cmd.ExecuteReader();

                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORİID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNADİ"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ACİKLAMA"].ToString());
                    lv.Items[sayac].SubItems.Add( string.Format("{0:0#00.0}", dr["FİYAT"].ToString()));
                    sayac++;
                }


            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
        }
        // Ürün Ekle
        public int urunEkle(ClassUrunler u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Urunler(URUNADİ,KATEGORİID,ACİKLAMA,FİYAT) values(@urunAd,@katId,@aciklama,@fiyat);", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@urunAd", SqlDbType.VarChar).Value = u._urunad;
                cmd.Parameters.Add("@katId", SqlDbType.Int).Value = u._urunturno;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = u._aciklama;
                cmd.Parameters.Add("@fiyat", SqlDbType.Money).Value = u._fiyat;

                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());

            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }


            return sonuc;
        }
        // Ürünler ve Kategoıriler Listele
        public void urunleriListele(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select Urunler.*,KATEGORİADİ from Urunler inner join Kategoriler on Kategoriler.ID=Urunler.KATEGORİID Where Urunler.Durum=0 ", con);
            SqlDataReader dr = null;


            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();

                dr = cmd.ExecuteReader();

                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORİID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORİADİ"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNADİ"].ToString());
                    lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["FİYAT"].ToString()));
                    lv.Items[sayac].SubItems.Add(dr["ACİKLAMA"].ToString());
                    
                    sayac++;
                }


            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
        }
        //Ürünleri Güncelle
        public int UrunGuncelle(ClassUrunler u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Urunler set URUNADİ=@urunad,KATEGORİID=@katID,ACİKLAMA=@aciklama,FİYAT=@fiyat where ID=@urunID", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@urunad", SqlDbType.VarChar).Value = u._urunad;
                cmd.Parameters.Add("@katID", SqlDbType.Int).Value = u._urunturno;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = u._aciklama;
                cmd.Parameters.Add("@fiyat", SqlDbType.Money).Value = u._fiyat;
                cmd.Parameters.Add("@urunID", SqlDbType.Int).Value = u._urunid;
                
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());

            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }


            return sonuc;
        }
        // ÜrünSil
        public int UrunSil(ClassUrunler u, int kat)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);

            string sql = "Update Urunler set Durum=1 where";
            if (kat == 0)

                sql += " KATEGORİID=@urunID";
            else
                sql += " ID=@urunID";
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@urunID", SqlDbType.Int).Value = u._urunid;

                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());

            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return sonuc;
        }
        //Ürün ID göre listeleme
        public void urunleriListeleByUrunAdi(ListView lv, int urunId)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select Urunler.*,KATEGORİADİ from Urunler inner join Kategoriler on Kategoriler.ID=Urunler.KATEGORİID Where Urunler.Durum=0 and Urunler.KATEGORİID=@urunID ", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@urunID", SqlDbType.VarChar).Value = urunId;

            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();

                dr = cmd.ExecuteReader();

                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORİID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORİADİ"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNADİ"].ToString());
                    //lv.Items[sayac].SubItems.Add(dr["ACİKLAMA"].ToString());
                    lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["FİYAT"].ToString()));
                    sayac++;
                }


            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
        }
        //2 Tarih arası tüm ürünleri getir
        public void urunlerİstatistiklereGoreListele(ListView lv, DateTimePicker Baslangic, DateTimePicker Bitis)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT top 10 dbo.Urunler.URUNADİ, sum(dbo.Satislar.ADET) as adeti FROM dbo.Kategoriler INNER JOIN " +
                "dbo.Urunler ON dbo.Kategoriler.ID = dbo.Urunler.KATEGORİID INNER JOIN dbo.Satislar ON dbo.Urunler.ID = dbo.Satislar.URUNID INNER JOIN " +
                " dbo.Adisyon ON dbo.Satislar.ADİSYONID = dbo.Adisyon.ID WHERE (CONVERT(datetime,TARİH,104) BETWEEN CONVERT(datetime, @Baslangic,104) " +
                "AND CONVERT(datetime,@Bitis,104)) group by dbo.Urunler.URUNADİ order by adeti desc", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@Baslangic", SqlDbType.VarChar).Value = Baslangic.Value.ToShortDateString();
            cmd.Parameters.Add("@Bitis", SqlDbType.VarChar).Value = Bitis.Value.ToShortDateString();


            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();

                dr = cmd.ExecuteReader();

                int sayac = 0;
                while (dr.Read())
                {

                    lv.Items.Add(dr["URUNADİ"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adeti"].ToString());
                    sayac++;
                }


            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
        }
        // Belirli Kategoriye ait ürünleri listele
        public void urunlerİstatistiklereGoreListeleUrunId(ListView lv, DateTimePicker Baslangic, DateTimePicker Bitis, int urunkatId)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT top 10 dbo.Urunler.URUNADİ, sum(dbo.Satislar.ADET) as adeti FROM dbo.Kategoriler INNER JOIN " +
                "dbo.Urunler ON dbo.Kategoriler.ID = dbo.Urunler.KATEGORİID INNER JOIN dbo.Satislar ON dbo.Urunler.ID = dbo.Satislar.URUNID INNER JOIN " +
                " dbo.Adisyon ON dbo.Satislar.ADİSYONID = dbo.Adisyon.ID WHERE (CONVERT(datetime,TARİH,104) BETWEEN CONVERT(datetime, @Baslangic,104) " +
                "AND CONVERT(datetime,@Bitis,104)) and (dbo.Urunler.KATEGORİID=@katId) group by dbo.Urunler.URUNADİ order by adeti desc", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@Baslangic", SqlDbType.VarChar).Value = Baslangic.Value.ToShortDateString();
            cmd.Parameters.Add("@Bitis", SqlDbType.VarChar).Value = Bitis.Value.ToShortDateString();
            cmd.Parameters.Add("@katId", SqlDbType.Int).Value = urunkatId;


            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();

                dr = cmd.ExecuteReader();

                int sayac = 0;
                while (dr.Read())
                {

                    lv.Items.Add(dr["URUNADİ"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adeti"].ToString());
                    sayac++;
                }


            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
        }

    }

   
}
