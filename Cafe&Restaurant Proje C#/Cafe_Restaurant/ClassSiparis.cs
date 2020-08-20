using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Cafe_Restaurant
{
    class ClassSiparis
    {
        ClassGenel gnl = new ClassGenel();

        private int _Id;
        private int _adisyonID;
        private int _urunId;
        private int _adet;
        private int _masaId;

        public int Id { get => _Id; set => _Id = value; }
        public int AdisyonID { get => _adisyonID; set => _adisyonID = value; }
        public int UrunId { get => _urunId; set => _urunId = value; }
        public int Adet { get => _adet; set => _adet = value; }
        public int MasaId { get => _masaId; set => _masaId = value; }


        // Siparişleri Getir
        public void getByOrder(ListView lv, int AdisyonId)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select URUNADİ,FİYAT,Satislar.ID,Satislar.URUNID,Satislar.ADET from Satislar Inner join Urunler on Satislar.URUNID=Urunler.ID Where ADİSYONID=@AdisyonId", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("AdisyonId", SqlDbType.Int).Value = AdisyonId;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["URUNADİ"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADET"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNID"].ToString());
                    lv.Items[sayac].SubItems.Add(Convert.ToString(Convert.ToDecimal(dr["FİYAT"]) * Convert.ToDecimal(dr["ADET"])));
                    lv.Items[sayac].SubItems.Add(dr["ID"].ToString());

                    sayac++;


                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /*--------------------------------------------------------------------------------------------*/
        /*internal void setSaveOrder(ClassSiparis saveOrder)
        {
            throw new NotImplementedException();
        }*/
        public bool setSaveOrder(ClassSiparis Bilgiler)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Satislar(ADİSYONID,URUNID,ADET,MASAID) values(@AdisyonNo,@UrunId,@Adet,@masaId)", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@AdisyonNo", SqlDbType.Int).Value = Bilgiler._adisyonID;
                cmd.Parameters.Add("@UrunId", SqlDbType.Int).Value = Bilgiler._urunId;
                cmd.Parameters.Add("@Adet", SqlDbType.Int).Value = Bilgiler._adet;
                cmd.Parameters.Add("@masaId", SqlDbType.Int).Value = Bilgiler._masaId;
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());

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

        public void setDeleteOrder(int satisId)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Delete From Satislar Where ID=@SatisID", con);

            cmd.Parameters.Add("@SatisID", SqlDbType.Int).Value = satisId;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }

        public decimal GenelToplamBul(int musteriId)
        {
            decimal geneltoplam = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            /*  SqlCommand cmd = new SqlCommand("SELECT SUM(dbo.Satislar.ADET * FİYAT) AS fiyat FROM dbo.Musteriler INNER JOIN " +
                  "dbo.PaketSiparis ON dbo.Musteriler.ID = dbo.PaketSiparis.MUSTERİID INNER JOIN Adisyon on Adisyon.ID=PaketSiparis.ADİSYONID" +
                  " INNER JOIN  dbo.Satislar ON dbo.Adisyon.ID = dbo.Satislar.ADİSYONID INNER JOIN dbo.Urunler ON " +
                  "dbo.Satislar.URUNID = dbo.Urunler.ID WHERE(dbo.PaketSiparis.MUSTERİID = @musteriId) AND(dbo.PaketSiparis.DURUM = 0)", con);*/

            SqlCommand cmd = new SqlCommand("select sum(nvl(TOPLAMTUTAR,0)) from HesapOdemeleri where MUSTERİID=@musteriId",con);
            cmd.Parameters.Add("@musteriId", SqlDbType.Int).Value = musteriId;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                
                
                geneltoplam = Convert.ToDecimal(cmd.ExecuteScalar());

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

            return geneltoplam;
        }

        public void adisyonpaketsiparisDetaylari(ListView lv, int adisyonID)
        {

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT Satislar.ID as satisID,Urunler.URUNADİ, Urunler.FİYAT,Satislar.ADET " +
                "from Satislar Inner join Adisyon on Adisyon.ID=Satislar.ADİSYONID" +
                "INNER JOIN Urunler on Urunler.ID=Satislar.URUNID where Satislar.ADİSYONID=@adisyonID", con);
            cmd.Parameters.Add("@adisyonID", SqlDbType.Int).Value = adisyonID;
            SqlDataReader dr = null;
            decimal geneltoplam = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                int i = 0;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lv.Items.Add(dr["satisID"].ToString());
                    lv.Items[i].SubItems.Add(dr["URUNADİ"].ToString());
                    lv.Items[i].SubItems.Add(dr["ADET"].ToString());
                    lv.Items[i].SubItems.Add(dr["FİYAT"].ToString());
                    i++;
                }



                geneltoplam = Convert.ToDecimal(cmd.ExecuteScalar());

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
        }
    }
}
