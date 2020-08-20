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
    class ClassUrunCesitleri
    {
        ClassGenel gnl = new ClassGenel();

        private int _UrunTurNo;
        private string _KategoriAd;
        private string _Aciklama;

        public int UrunTurNo { get => _UrunTurNo; set => _UrunTurNo = value; }
        public string KategoriAd { get => _KategoriAd; set => _KategoriAd = value; }
        public string Aciklama { get => _Aciklama; set => _Aciklama = value; }

        public void getByProductTypes(ListView Cesitler, Button btn ) 
        {
            Cesitler.Items.Clear();
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("Select URUNADi,FİYAT,Urunler.ID From Kategoriler Inner Join Urunler on Kategoriler.ID=Urunler.KATEGORİID where Urunler.KATEGORİID=@KATEGORİID", conn);

            string aa = btn.Name;
            int uzunluk = aa.Length;

            comm.Parameters.Add("@KATEGORİID", SqlDbType.Int).Value = aa.Substring(uzunluk - 1, 1);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader dr = comm.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                Cesitler.Items.Add(dr["URUNADİ"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["FİYAT"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["ID"].ToString());
                i++;

            }
            dr.Close();
            conn.Dispose();
            conn.Close();
        }

        public void getByProductSearch(ListView Cesitler, int txt)
        {
            Cesitler.Items.Clear();
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("Select * from Urunler where ID=@ID", conn);

            

            comm.Parameters.Add("@ID", SqlDbType.Int).Value = txt;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader dr = comm.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                Cesitler.Items.Add(dr["URUNADİ"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["FİYAT"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["ID"].ToString());
                i++;

            }
            dr.Close();
            conn.Dispose();
            conn.Close();
        }
        // Ürün Çeşitlerini getir ComboBox
        public void urunCesitleriniGetir(ComboBox cb)
        {
            cb.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Kategoriler where Durum=0", con);
            SqlDataReader dr = null;


            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ClassUrunCesitleri uc = new ClassUrunCesitleri();
                    uc._UrunTurNo = Convert.ToInt32(dr["ID"]);
                    uc._KategoriAd = dr["KATEGORİADİ"].ToString();
                    uc._Aciklama = dr["ACİKLAMA"].ToString();

                    cb.Items.Add(uc);
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
        // Ürün Çeşitlerini Getir Listview
        public void urunCesitleriniGetir(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Kategoriler where Durum=0", con);
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
                    lv.Items[sayac].SubItems.Add(dr["KATEGORİADİ"].ToString());
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
                //dr.Close();
                con.Dispose();
                con.Close();
            }
        }
        //Ürün Çeşitlerini Getir Listview Arama
        public void urunCesitleriniGetir(ListView lv,string source)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand(" Select * Kategoriler where Durum=0 and KATEGORİADİ like '%' + @source + '%'", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@source", SqlDbType.VarChar).Value = source;


            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();

                dr = cmd.ExecuteReader();

                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORİADİ"].ToString());
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
                //dr.Close();
                con.Dispose();
                con.Close();
            }
        }
        //Ürün Çeşitlerini Ekleme
        public int urunKategoriEkle(ClassUrunCesitleri u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Kategoriler(KATEGORİADİ,ACİKLAMA) values(@KATEGORİADİ,@ACİKLAMA);", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@KATEGORİADİ", SqlDbType.VarChar).Value = u._KategoriAd;
                cmd.Parameters.Add("@ACİKLAMA", SqlDbType.VarChar).Value = u._Aciklama;

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
        //Ürün Çeşitleri Güncelle
        public int UrunKategoriGuncelle(ClassUrunCesitleri u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Kategoriler set KATEGORİADİ=@KATEGORİADİ, ACİKLAMA=@ACİKLAMA where ID=@KATID", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@KATEGORİADİ", SqlDbType.VarChar).Value = u._KategoriAd;
                cmd.Parameters.Add("@ACİKLAMA", SqlDbType.VarChar).Value = u._Aciklama;
                cmd.Parameters.Add("@KATID", SqlDbType.Int).Value = u._UrunTurNo;

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
        //Ürün Çeşitleri Sil
        public int UrunKategoriSil(int  id)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Kategoriler set DURUM = 1 where ID=@KATID", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@KATID", SqlDbType.Int).Value = id;

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

        
        public override string ToString()
        {
            return KategoriAd;
        }
    }
}
