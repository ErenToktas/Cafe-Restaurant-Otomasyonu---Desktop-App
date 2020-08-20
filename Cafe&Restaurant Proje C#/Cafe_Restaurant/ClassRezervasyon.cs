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
    class ClassRezervasyon
    {
        ClassGenel gnl = new ClassGenel();
        /*------------------------------------------------------------------------*/
        private int _ID;
        private int _TableId;
        private int _ClientId;
        private DateTime _Date;
        private int _CleintCount;
        private string _Description;
        private int _AdditionId;
        /*------------------------------------------------------------------------*/
        public int ID { get => _ID; set => _ID = value; }
        public int TableId { get => _TableId; set => _TableId = value; }
        public int ClientId { get => _ClientId; set => _ClientId = value; }
        public DateTime Date { get => _Date; set => _Date = value; }
        public int CleintCount { get => _CleintCount; set => _CleintCount = value; }
        public string Description { get => _Description; set => _Description = value; }
        public int AdditionId { get => _AdditionId; set => _AdditionId = value; }
        /*------------------------------------------------------------------------*/
        // MusteriId masa numarasına göre
        public int getByClientIdFromRezervasyon(int tableId)
        {
            int clientId = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 MUSTERİID from Rezervasyonlar where MASAID=@masaid order by MUSTERİID Desc", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@masaid", SqlDbType.Int).Value = tableId;

                clientId = Convert.ToInt32(cmd.ExecuteScalar());

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

            return clientId;
        }
        //Rezerve masayı kapat
        public bool rezervationClose(int adisyonID)
        {
            bool result = false;

            
                SqlConnection con = new SqlConnection(gnl.conString);
                SqlCommand cmd = new SqlCommand("Update Rezervasyonlar set durum = 1 where ADİSYONID=@adisyonId", con);

                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                    con.Open();
                    }

                    cmd.Parameters.Add("@adisyonId", SqlDbType.Int).Value = adisyonID;
                result = Convert.ToBoolean(cmd.ExecuteScalar());
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
            return result;

                
            
        }
        // Rezervasyonları Getir
        public void musteriIdGetirFormRezervasyon(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("Select Rezervasyonlar.MUSTERİID, (AD + SOYAD) as musteri from Rezervasyonlar " +
                "Inner Join Musteriler on Rezervasyonlar.MUSTERİID=Musteriler.ID where Rezervasyonlar.Durum=0", conn);


            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader dr = comm.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["MUSTERİID"].ToString());
                lv.Items[i].SubItems.Add(dr["musteri"].ToString());
                i++;

            }
            dr.Close();
            conn.Dispose();
            conn.Close();
        }
        // Eski Rezervasyonları Getir
        public void eskiRezervasyonlariGetir(ListView lv,int mId)
        {
            lv.Items.Clear();
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("Select Rezervasyonlar.MUSTERİID, AD,SOYAD,ADİSYONID,TARİH from Rezervasyonlar " +
                "Inner Join Musteriler on Rezervasyonlar.MUSTERİID=Musteriler.ID where Rezervasyonlar.MUSTERİID=@mId and " +
                "Rezervasyonlar.Durum=0 order by Rezervasyonlar.ID Desc", conn);
            comm.Parameters.Add("mId", SqlDbType.Int).Value = mId;

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader dr = comm.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["MUSTERİID"].ToString());
                lv.Items[i].SubItems.Add(dr["AD"].ToString());
                lv.Items[i].SubItems.Add(dr["SOYAD"].ToString());
                lv.Items[i].SubItems.Add(dr["TARİH"].ToString());
                lv.Items[i].SubItems.Add(dr["ADİSYONID"].ToString());

                i++;

            }
            dr.Close();
            conn.Dispose();
            conn.Close();
        }
        // En son Rezervasyon Tarihini getir
        public DateTime EnsonRezervasyonTarihi(int mId)
        {
            DateTime tar = new DateTime();
            tar = DateTime.Now;
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("Select TARİH from Rezervasyonlar where Rezervasyonlar.MUSTERİID=@mId and " +
                "Rezervasyonlar.Durum=1 order by Rezervasyonlar.ID Desc", conn);
            comm.Parameters.Add("mId", SqlDbType.Int).Value = mId;

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            tar = Convert.ToDateTime(comm.ExecuteScalar());

            conn.Dispose();
            conn.Close();

            return tar;
        }
        // Açık rezervasyonların sayısı
        public int acikRezervasyonSayisi()
        {
            int sonuc = 0;
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("Select count(*) from Rezervasyonlar where Rezervasyonlar.Durum=0", conn);


            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                sonuc = Convert.ToInt32(comm.ExecuteNonQuery());
            }
            catch (Exception)
            {

                throw;
            }
            
            conn.Dispose();
            conn.Close();

            return sonuc;
        }
        // Rezervasyon Acık mı ? Kontrolü
        public bool RezervasyonAcikmiKontrol(int mId)
        {
            bool result = false;


            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 Rezervasyonlar.ID from Rezervasyonlar where MUSTERİID=@mID and " +
                "durum=1 order by ID desc", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@mID", SqlDbType.Int).Value = mId;
                result = Convert.ToBoolean(cmd.ExecuteScalar());
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
            return result;



        }
        // Rezervasyon Aç
        public bool RezervasyonAc(ClassRezervasyon r)
        {
            bool result = false;


            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Rezervasyonlar (MUSTERİID,MASAID,ADİSYONID,KİSİSAYİSİ,TARİH,ACİKLAMA) values" +
                "(@MUSTERİID,@MASAID,@ADİSYONID,@KİSİSAYİSİ,@TARİH,@ACİKLAMA)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("MUSTERİID", SqlDbType.Int).Value = r._ClientId;
                cmd.Parameters.Add("MASAID", SqlDbType.Int).Value = r._TableId;
                cmd.Parameters.Add("ADİSYONID", SqlDbType.Int).Value = r._AdditionId;
                cmd.Parameters.Add("KİSİSAYİSİ", SqlDbType.Int).Value = r._CleintCount;
                cmd.Parameters.Add("TARİH", SqlDbType.Date).Value = r._Date;
                cmd.Parameters.Add("ACİKLAMA", SqlDbType.VarChar).Value = r._Description;
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
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
            return result;



        }
        // Rezerve masanın ID sini getir
        public int RezerveMasaIdGetir(int mId)
        {
            int sonuc = 0;
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("Select Rezervasyonlar.MASAID from Rezervasyonlar INNER JOIN Adisyonlar on " +
                "Rezervasyonlar.ADİSYONID=Adisyonlar.ID where (Rezervasyonlar.Durum=1) and Adisyon.Durum=1 and Rezervasyonlar.MUSTERİID=@mId", conn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                comm.Parameters.Add("mId", SqlDbType.Int).Value = mId;
                sonuc = Convert.ToInt32(comm.ExecuteNonQuery());
            }
            catch (Exception)
            {

                throw;
            }

            conn.Dispose();
            conn.Close();

            return sonuc;
        }
    }
}
