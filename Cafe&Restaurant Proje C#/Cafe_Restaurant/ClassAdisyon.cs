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
    class ClassAdisyon
    {
        ClassGenel gnl = new ClassGenel();

        private int _ID;
        private int _ServisTurNo;
        private decimal _Tutar;
        private DateTime _Tarih;
        private int _PersonelId;
        private int _Durum;
        private int _MasaId;

        public int ID { get => _ID; set => _ID = value; }
        public int ServisTurNo { get => _ServisTurNo; set => _ServisTurNo = value; }
        public decimal Tutar { get => _Tutar; set => _Tutar = value; }
        public DateTime Tarih { get => _Tarih; set => _Tarih = value; }
        public int PersonelId { get => _PersonelId; set => _PersonelId = value; }
        public int Durum { get => _Durum; set => _Durum = value; }
        public int MasaId { get => _MasaId; set => _MasaId = value; }

        public int getByAddition(int MasaId) 
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 ID From Adisyon Where MASAID=@MasaId Order by ID desc",con);

            cmd.Parameters.Add("MasaId", SqlDbType.Int).Value = MasaId;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                MasaId = Convert.ToInt32(cmd.ExecuteScalar());

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

            return MasaId;

        } // Açık olan masanın adisyon numarası

        public bool setByAdditionNew(ClassAdisyon Bilgiler)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Adisyon(SERVİSTURNO,PERSONELID,MASAID,TARİH,DURUM) values(@ServisTurNo,@PersonelID,@MasaId,@Tarih,@Durum)",con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@ServisTurNo", SqlDbType.Int).Value = Bilgiler.ServisTurNo;
                cmd.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = Bilgiler.Tarih;
                cmd.Parameters.Add("@PersonelID", SqlDbType.Int).Value = Bilgiler.PersonelId;
                cmd.Parameters.Add("@MasaId", SqlDbType.Int).Value = Bilgiler.MasaId;
                cmd.Parameters.Add("@Durum", SqlDbType.Bit).Value = 0;
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception ex)
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

        public void adisyonkapat(int adisyonID, int durum)
        {
            


            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Adisyon set durum = @durum where ID=@adisyonId", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@adisyonId", SqlDbType.Int).Value = adisyonID;
                cmd.Parameters.Add("@durum", SqlDbType.Int).Value = durum;
                cmd.ExecuteNonQuery();
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

        public int paketAdisyonIdbulAdedi()
        {
            int miktar = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select count(*) as Sayi from Adisyon where (Durum=0) and (SERVİSTURNO=2)",con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                miktar = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {

                string hata = ex.Message;

            }
            return miktar;
        }

        public void acikPaketAdisyonlar(ListView lv)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select PaketSiparis.MUSTERİID, Musteriler.Ad + ' ' + Musteriler.Soyad as Musteri, Adisyon.ID " +
                "from PaketSiparis Inner Join Musteriler on Musteriler.ID=PaketSiparis.MUSTERİID Inner Join Adisyon on Adisyon.ID=PaketSiparis.ADİSYONID where " +
                "Adisyon.Durum=0", con);

            SqlDataReader dr = null;
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
                    lv.Items.Add(dr["MUSTERİID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["Musteri"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ID"].ToString());
                    
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

        public int musterininsonadisyonId(int musteriId)
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Adisyon.ID from Adisyon Inner Join PaketSiparis on PaketSiparis.ADİSYONID=Adisyon.ID where " +
                "PaketSiparis.durum=0 and Adisyon.durum=0 and PaketSiparis.MUSTERİID=@musteriId", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@musteriId", SqlDbType.Int).Value = musteriId;

                sonuc = Convert.ToInt32(cmd.ExecuteScalar());

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

        public void musteriDetaylar(ListView lv, int musteriId)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select PaketSiparis.MUSTERİID, PaketSiparis.ADİSYONID, Musteriler.AD,Musteriler.SOYAD," +
                "CONVERT(varchar(10),Adisyon.TARİH,104) as tarih from Adisyon Inner Join PaketSiparis on PaketSiparis.ADİSYONID=Adisyon.ID " +
                "Inner Join Musteriler on Musteriler.ID=PaketSiparis.MUSTERİID where Adisyon.SERVİSTURNO=2  and " +
                "PaketSiparis.MUSTERİID=@musteriId", con);

            cmd.Parameters.Add("@musteriId", SqlDbType.Int).Value = musteriId;
            SqlDataReader dr = null;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                int sayac = 0;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lv.Items.Add(dr["MUSTERİID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["tarih"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADİSYONID"].ToString());

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

        public int RezervasyonAdisyon(ClassAdisyon bilgiler)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Adisyon(SERVİSTURNO,TARİH,PERSONELID,MASAID) " +
                "values(@ServisTurNo,@Tarih@PersonelID,@MasaId);", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@ServisTurNo", SqlDbType.Int).Value = bilgiler.ServisTurNo;
                cmd.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = bilgiler.Tarih;
                cmd.Parameters.Add("@PersonelID", SqlDbType.Int).Value = bilgiler.PersonelId;
                cmd.Parameters.Add("@MasaId", SqlDbType.Int).Value = bilgiler.MasaId;

                sonuc = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
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
    }
}
